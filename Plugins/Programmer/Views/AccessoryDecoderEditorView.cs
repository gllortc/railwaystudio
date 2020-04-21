using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.Trains;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class AccessoryDecoderEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="AccessoryDecoderEditorView"/>.
      /// </summary>
      public AccessoryDecoderEditorView()
      {
         InitializeComponent();

         this.Decoder = new AccessoryDecoder();

         ListComboLists();
      }

      /// <summary>
      /// Returns a new instance of <see cref="AccessoryDecoderEditorView"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      /// <param name="decoder">The decoder to edit in the editor dialogue.</param>
      public AccessoryDecoderEditorView(AccessoryDecoder decoder)
      {
         InitializeComponent();

         this.Decoder = decoder;

         ListComboLists();
         ListOutputs();

         txtName.Text = this.Decoder.Name;
         cboModel.Text = this.Decoder.Model;
         cboManufacturer.EditValue = this.Decoder.Manufacturer;
         cboSection.SetSelectedElement(this.Decoder.Section);
         nudAddress.EditValue = this.Decoder.StartAddress;
         txtOutputs.EditValue = this.Decoder.NumberOfOutputs;
         txtNotes.Text = this.Decoder.Notes;

         txtOutputs.Enabled = false;
      }

      #endregion

      #region Properties

      private bool IsLoaded { get; set; } = false;

      internal AccessoryDecoder Decoder { get; private set; }

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
         if (grdConnectView.GetRow(e.RowHandle) is AccessoryDecoderConnection connection)
         {
            if (connection.Element == null)
            {
               e.Appearance.BackColor = System.Drawing.Color.FromArgb(210, 237, 210);
               e.Appearance.BackColor2 = System.Drawing.Color.FromArgb(210, 237, 210);
            }
         }
      }

      private void GrdConnectView_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
      {
         int[] selRows = grdConnectView.GetSelectedRows();
         if (selRows.Length <= 0)
         {
            e.Cancel = true;
            return;
         }

         if (!(grdConnectView.GetRow(selRows[0]) is AccessoryDecoderConnection connection))
         {
            e.Cancel = true;
            return;
         }

         if (connection.Element == null)
         {
            e.Cancel = true;
            return;
         }
      }

      private void GrdConnectView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
      {
         if (e.Row is AccessoryDecoderConnection connection)
         {
            try
            {
               // TODO: Check if address is free!
               AccessoryDecoderConnection.Save(connection);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      private void NudAddress_EditValueChanged(object sender, EventArgs e)
      {
         if (!this.IsLoaded) return;

         Cursor.Current = Cursors.WaitCursor;

         this.Decoder.StartAddress = (int)nudAddress.Value;
         this.ListOutputs();

         Cursor.Current = Cursors.Default;
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
         this.Decoder.Section = cboSection.SelectedSection;
         this.Decoder.StartAddress = (int)nudAddress.Value;
         this.Decoder.NumberOfOutputs = int.Parse(txtOutputs.Text);
         this.Decoder.Notes = txtNotes.Text.Trim();

         try
         {
            AccessoryDecoder.Save(this.Decoder);

            // Add the decoder into the project
            if (!OTCContext.Project.AccessoryDecoders.Contains(this.Decoder))
               OTCContext.Project.AccessoryDecoders.Add(this.Decoder);

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
         List<string> models = new List<string>();
         List<string> modules = new List<string>();

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
         foreach (AccessoryDecoder decoder in AccessoryDecoder.FindAll())
         {
            if (!string.IsNullOrEmpty(decoder.Model) && !models.Contains(decoder.Model))
            {
               item = new ImageComboBoxItem();
               item.Value = decoder.Model;
               item.Description = decoder.Model;
               item.ImageIndex = 2;

               cboModel.Properties.Items.Add(item);
            }
         }
      }

      private void ListOutputs()
      {
         int currentAddress;
         Dictionary<int, AccessoryDecoderConnection> connections = new Dictionary<int, AccessoryDecoderConnection>();

         // Create the non existing connections
         foreach (AccessoryDecoderConnection connection in this.Decoder.Connections)
            connections.Add(connection.DecoderOutput, connection);

         currentAddress = this.Decoder.StartAddress;
         for (int output = 1; output <= this.Decoder.NumberOfOutputs; output++)
         {
            if (!connections.ContainsKey(output))
            {
               connections.Add(output, new AccessoryDecoderConnection() { DecoderOutput = output, Decoder = this.Decoder, Element = null, SwitchTime = 0 });
               currentAddress++;
            }
         }

         grdConnect.BeginUpdate();
         grdConnect.DataSource = null;

         grdConnectView.Columns.Clear();
         grdConnectView.OptionsBehavior.AutoPopulateColumns = false;
         grdConnectView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Output", Visible = true, FieldName = "DecoderOutput", Width = 35 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Address", Visible = true, FieldName = "Address", Width = 50 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Element", Visible = true, FieldName = "Element.Name" });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Pin", Visible = true, FieldName = "ElementPinIndex", Width = 35 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Switch time", Visible = true, FieldName = "SwitchTime", Width = 40 });

         grdConnect.DataSource = connections.Values;

         grdConnectView.Columns["DecoderOutput"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["DecoderOutput"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["DecoderOutput"].OptionsColumn.AllowEdit = false;

         grdConnectView.Columns["Address"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Address"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Address"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         grdConnectView.Columns["Address"].DisplayFormat.FormatString = "{0:d4}";
         grdConnectView.Columns["Address"].OptionsColumn.AllowEdit = true;

         grdConnectView.Columns["Element.Name"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Element.Name"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Element.Name"].OptionsColumn.AllowEdit = false;

         grdConnectView.Columns["ElementPinIndex"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["ElementPinIndex"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["ElementPinIndex"].OptionsColumn.AllowEdit = false;

         grdConnectView.Columns["SwitchTime"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         grdConnectView.Columns["SwitchTime"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         grdConnectView.Columns["SwitchTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         grdConnectView.Columns["SwitchTime"].DisplayFormat.FormatString = "{0:d} ms";
         grdConnectView.Columns["SwitchTime"].OptionsColumn.AllowEdit = true;

         grdConnect.EndUpdate();
      }

      #endregion

   }
}