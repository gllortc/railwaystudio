using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using RailwayStudio.Common;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.TrainControl;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class AccessoryDeviceEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="AccessoryDeviceEditorView"/>.
      /// </summary>
      public AccessoryDeviceEditorView()
      {
         InitializeComponent();

         this.Decoder = new Device(Device.DeviceType.AccessoryDecoder);

         tabDecoderOutputs.PageVisible = false;

         ListComboLists();
      }

      /// <summary>
      /// Returns a new instance of <see cref="AccessoryDeviceEditorView"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      /// <param name="decoder">The decoder to edit in the editor dialogue.</param>
      public AccessoryDeviceEditorView(Device decoder)
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

      private void GrdConnectView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_CONNECTION_16, e);
      }

      private void GrdConnectView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
      {
         if (grdConnectView.GetRow(e.RowHandle) is DeviceConnection connection)
         {
            if (connection.Element == null)
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
         else if (int.Parse(txtOutputs.Text) <= 0)
         {
            MessageBox.Show("Invalid number of decoder digital outputs.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtOutputs.SelectAll();
            txtOutputs.Focus();
            return;
         }

         Cursor.Current = Cursors.WaitCursor;

         this.Decoder.Project = OTCContext.Project;
         this.Decoder.Name = txtName.Text.Trim();
         this.Decoder.Manufacturer = cboManufacturer.EditValue as Manufacturer;
         this.Decoder.Model = cboModel.Text.Trim();
         this.Decoder.Outputs = int.Parse(txtOutputs.Text);
         this.Decoder.Notes = txtNotes.Text.Trim();
         this.Decoder.Type = Device.DeviceType.AccessoryDecoder;

         try
         {
            Device.Save(this.Decoder);

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
         List<String> deviceModels = new List<string>();

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
         foreach (Device device in Device.FindAll())
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

      private void ListOutputs()
      {
         Dictionary<int, DeviceConnection> connections = new Dictionary<int, DeviceConnection>();

         // Create the non existing connections
         foreach (DeviceConnection connection in this.Decoder.Connections)
            connections.Add(connection.Output, connection);

         for (int output = 1; output <= this.Decoder.Outputs; output++)
            if (!connections.ContainsKey(output))
               connections.Add(output, new DeviceConnection() { Output = output, Device = this.Decoder, Element = null });

         grdConnect.BeginUpdate();
         grdConnect.DataSource = null;

         grdConnectView.Columns.Clear();
         grdConnectView.OptionsBehavior.AutoPopulateColumns = false;
         grdConnectView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Output", Visible = true, FieldName = "Output", Width = 50 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Element", Visible = true, FieldName = "Element.Name" });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Address", Visible = true, FieldName = "Address", Width = 60 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Switch time", Visible = true, FieldName = "SwitchTime", Width = 60 });

         grdConnect.DataSource = connections.Values;

         grdConnectView.Columns["Output"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Output"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

         grdConnectView.Columns["Address"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Address"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Address"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         grdConnectView.Columns["Address"].DisplayFormat.FormatString = "{0:d3}";

         grdConnectView.Columns["Element.Name"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Element.Name"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

         grdConnectView.Columns["SwitchTime"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         grdConnectView.Columns["SwitchTime"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         grdConnectView.Columns["SwitchTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         grdConnectView.Columns["SwitchTime"].DisplayFormat.FormatString = "{0:d} ms";

         grdConnect.EndUpdate();
      }

      #endregion

   }
}