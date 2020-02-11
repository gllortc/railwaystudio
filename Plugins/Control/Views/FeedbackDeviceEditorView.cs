using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.TrainControl;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class FeedbackDeviceEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="FeedbackDeviceEditorView"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      public FeedbackDeviceEditorView()
      {
         InitializeComponent();

         this.Decoder = new FeedbackDecoder();

         tabDecoderInputs.PageVisible = false;
         txtInputs.Value = 4;

         ListComboLists();
      }

      /// <summary>
      /// Returns a new instance of <see cref="FeedbackDeviceEditorView"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      /// <param name="decoder">The decoder to edit in the editor dialogue.</param>
      public FeedbackDeviceEditorView(FeedbackDecoder decoder)
      {
         InitializeComponent();

         this.Decoder = decoder;

         ListComboLists();
         ListInputs();

         txtName.Text = this.Decoder.Name;
         cboModel.Text = this.Decoder.Model;
         cboManufacturer.EditValue = this.Decoder.Manufacturer;
         nudAddress.EditValue = this.Decoder.StartAddress;
         txtInputs.EditValue = this.Decoder.Inputs;
         txtNotes.Text = this.Decoder.Notes;
      }

      #endregion

      #region Properties

      internal FeedbackDecoder Decoder { get; private set; }

      #endregion

      #region Event Handlers

      private void FrmDecoderEditor_Activated(object sender, EventArgs e)
      {
         txtName.SelectAll();
         txtName.Focus();
      }

      private void NudAddress_EditValueChanged(object sender, EventArgs e)
      {
         if (!tabDecoderInputs.PageVisible)
         {
            return;
         }

         int addr = (int)nudAddress.Value;

         for (int i = 0; i < grdConnectView.RowCount; i++)
         {
            if (grdConnectView.GetRow(0) is DataRowView)
            {
               grdConnectView.SetRowCellValue(i, "Address", addr);

               // Update address by sensor output group
               if ((i + 1) % 4 == 0) addr++;
            }
         }
      }

      private void GrdConnectView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
      {
         if (grdConnectView.GetRow(e.RowHandle) is AccessoryDecoderConnection connection)
         {
            if (connection.Element != null)
            {
               e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
               e.Appearance.BackColor2 = System.Drawing.Color.FromArgb(192, 255, 192);
            }
         }
      }

      private void CmdOk_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must provide a valid name for the decoder.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return;
         }
         else if (int.Parse(txtInputs.Text) <= 0)
         {
            MessageBox.Show("Invalid number of sensor module inputs per address.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtInputs.SelectAll();
            txtInputs.Focus();
            return;
         }

         Cursor.Current = Cursors.WaitCursor;

         this.Decoder.Project = OTCContext.Project;
         this.Decoder.Name = txtName.Text.Trim();
         this.Decoder.Manufacturer = cboManufacturer.EditValue as Manufacturer;
         this.Decoder.Model = cboModel.Text.Trim();
         this.Decoder.StartAddress = (int)nudAddress.Value;
         this.Decoder.Inputs = int.Parse(txtInputs.Text);
         this.Decoder.Notes = txtNotes.Text.Trim();

         try
         {
            FeedbackDecoder.Save(this.Decoder);

            this.DialogResult = DialogResult.OK;
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

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Private Members

      private void ListComboLists()
      {
         ImageComboBoxItem item;
         List<string> deviceModels = new List<string>();

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
         foreach (AccessoryDecoder device in AccessoryDecoder.FindAll())
         {
            if (!deviceModels.Contains(device.Name))
            {
               item = new ImageComboBoxItem();
               item.Value = device.Name;
               item.Description = device.Name;
               item.ImageIndex = 2;

               cboModel.Properties.Items.Add(item);
            }
         }
      }

      public void ListInputs()
      {
         Dictionary<int, FeedbackDecoderConnection> connections = new Dictionary<int, FeedbackDecoderConnection>();

         // Create the non existing connections
         foreach (FeedbackDecoderConnection connection in this.Decoder.Connections)
            connections.Add(connection.DecoderOutput, connection);

         for (int output = 1; output <= this.Decoder.Inputs; output++)
            if (!connections.ContainsKey(output))
               connections.Add(output, new FeedbackDecoderConnection() { DecoderOutput = output, Device = this.Decoder, Element = null });

         grdConnect.BeginUpdate();
         grdConnect.DataSource = null;

         grdConnectView.Columns.Clear();
         grdConnectView.OptionsBehavior.AutoPopulateColumns = false;
         grdConnectView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Input", Visible = true, FieldName = "DecoderOutput", Width = 50 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Element", Visible = true, FieldName = "Element.Name" });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Address", Visible = true, FieldName = "Address", Width = 60 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Delay", Visible = true, FieldName = "DelayTime", Width = 60 });

         grdConnect.DataSource = connections.Values;

         grdConnectView.Columns["DecoderOutput"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["DecoderOutput"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

         grdConnectView.Columns["Address"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Address"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Address"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         grdConnectView.Columns["Address"].DisplayFormat.FormatString = "{0:d3}";

         grdConnectView.Columns["Element.Name"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Element.Name"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

         grdConnectView.Columns["DelayTime"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         grdConnectView.Columns["DelayTime"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         grdConnectView.Columns["DelayTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         grdConnectView.Columns["DelayTime"].DisplayFormat.FormatString = "{0:d} ms";

         grdConnect.EndUpdate();
      }

      #endregion

   }
}