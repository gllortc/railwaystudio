using DevExpress.XtraEditors.Controls;
using RailwayStudio.Common;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.TrainControl;
using System;
using System.Data;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class FrmAccessoryEditor : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="FrmAccessoryEditor"/>.
      /// </summary>
      public FrmAccessoryEditor()
      {
         InitializeComponent();

         this.Decoder = new Device(Device.DeviceType.AccessoryDecoder);

         tabDecoderOutputs.PageVisible = false;

         ListComboLists();
      }

      /// <summary>
      /// Returns a new instance of <see cref="FrmAccessoryEditor"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      /// <param name="decoder">The decoder to edit in the editor dialogue.</param>
      public FrmAccessoryEditor(Device decoder)
      {
         InitializeComponent();

         this.Decoder = decoder;

         ListComboLists();
         ListOutputs();

         txtName.Text = this.Decoder.Name;
         cboModel.Text = this.Decoder.Model;
         cboManufacturer.EditValue = this.Decoder.Manufacturer;
         txtOutputs.EditValue = this.Decoder.Outputs;
         txtNotes.Text = this.Decoder.Notes;

         txtOutputs.Enabled = false;
      }

      #endregion

      #region Properties

      internal Device Decoder { get; private set; }

      #endregion

      #region Event Handlers

      private void FrmDecoderEditor_Activated(object sender, EventArgs e)
      {
         txtName.SelectAll();
         txtName.Focus();
      }

      private void grdConnectView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_CONNECTION_16, e);
      }

      private void grdConnectView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
      {
         DataRowView drv = grdConnectView.GetRow(e.RowHandle) as DataRowView;
         if (drv != null)
         {
            if ((Int64)drv[4] <= 0)
            {
               e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
               e.Appearance.BackColor2 = System.Drawing.Color.FromArgb(192, 255, 192);
            }
         }
      }

      private void cmdOk_Click(object sender, EventArgs e)
      {
         DataTable dt = null;
         DeviceConnection dc = null;

         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must provide a valid name for the decoder.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return;
         }
         else if (int.Parse(txtOutputs.Text) <= 0)
         {
            MessageBox.Show("Invalid number of decoder digital outputs.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtOutputs.SelectAll();
            txtOutputs.Focus();
            return;
         }

         Cursor.Current = Cursors.WaitCursor;

         this.Decoder.Name = txtName.Text.Trim();
         this.Decoder.Manufacturer = cboManufacturer.EditValue as Manufacturer;
         this.Decoder.Model = cboModel.Text.Trim();
         this.Decoder.Outputs = int.Parse(txtOutputs.Text);
         this.Decoder.Notes = txtNotes.Text.Trim();
         this.Decoder.Type = Device.DeviceType.AccessoryDecoder;

         try
         {
            if (!this.Decoder.IsNew)
            {
               // Update the outputs addresses
               // At this point the module must have all outputs created in DB
               dt = grdConnect.DataSource as DataTable;
               foreach (DataRow row in dt.Rows)
               {
                  dc = DeviceConnection.Get((long)row[0]);
                  dc.Address = (int)row[3];
               }
            }

            Device.Save(this.Decoder);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
         }
         catch (Exception ex)
         {
            Cursor.Current = Cursors.Default;

            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            Cursor.Current = Cursors.Default;
         }
      }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Private Members

      private void ListComboLists()
      {
         ImageComboBoxItem item;

         // Fill manufacturers list
         foreach (Manufacturer manufacturer in Manufacturer.FindAll())
         {
            item = new ImageComboBoxItem();
            item.Value = manufacturer;
            item.Description = manufacturer.Name;
            item.ImageIndex = 1;

            cboManufacturer.Properties.Items.Add(item);
         }

         // Fill models list
         foreach (string stritem in OTCContext.Project.GetDeviceModels())
         {
            item = new ImageComboBoxItem();
            item.Value = stritem;
            item.Description = stritem;
            item.ImageIndex = 2;

            cboModel.Properties.Items.Add(item);
         }
      }

      private void ListOutputs()
      {
         grdConnect.BeginUpdate();
         grdConnect.DataSource = OTCContext.Project.FindDeviceConnections(this.Decoder);
         grdConnectView.Columns[0].Visible = false;
         grdConnectView.Columns[1].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
         grdConnectView.Columns[1].OptionsColumn.AllowEdit = false;
         grdConnectView.Columns[2].OptionsColumn.AllowEdit = false;
         grdConnectView.Columns[3].OptionsColumn.AllowEdit = true;
         grdConnectView.Columns[4].Visible = false;
         grdConnect.EndUpdate();
      }

      #endregion

   }
}