using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.TrainControl;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class FeedbackEncoderEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="FeedbackEncoderEditorView"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      public FeedbackEncoderEditorView()
      {
         InitializeComponent();
         ListComboLists();

         this.Decoder = new FeedbackDecoder();

         txtInputs.Properties.MinValue = this.InputsPerAddress;
         txtInputs.Properties.MaxValue = 9999;
         txtInputs.Properties.Increment = this.InputsPerAddress;
         txtInputs.EditValue = this.InputsPerAddress;

         this.IsLoaded = true;
      }

      /// <summary>
      /// Returns a new instance of <see cref="FeedbackEncoderEditorView"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      /// <param name="decoder">The decoder to edit in the editor dialogue.</param>
      public FeedbackEncoderEditorView(FeedbackDecoder decoder)
      {
         InitializeComponent();
         ListComboLists();

         this.Decoder = decoder;

         txtInputs.Properties.MinValue = this.InputsPerAddress;
         txtInputs.Properties.MaxValue = 9999;
         txtInputs.Properties.Increment = this.InputsPerAddress;

         txtName.Text = this.Decoder.Name;
         cboModel.Text = this.Decoder.Model;
         cboManufacturer.EditValue = this.Decoder.Manufacturer;
         nudAddress.EditValue = this.Decoder.StartAddress;
         txtInputs.EditValue = this.Decoder.Inputs;
         txtNotes.Text = this.Decoder.Notes;

         this.IsLoaded = true;
      }

      #endregion

      #region Properties

      private bool IsLoaded { get; set; } = false;

      internal FeedbackDecoder Decoder { get; private set; }

      private int InputsPerAddress
      {
         get { return (OTCContext.Project.DigitalSystem != null ? OTCContext.Project.DigitalSystem.OutputsBySensorAddress : 8); }
      }

      #endregion

      #region Event Handlers

      private void FrmDecoderEditor_Activated(object sender, EventArgs e)
      {
         this.ListInputs();

         txtName.SelectAll();
         txtName.Focus();
      }

      private void NudAddress_EditValueChanged(object sender, EventArgs e)
      {
         if (!this.IsLoaded) return;

         Cursor.Current = Cursors.WaitCursor;

         this.Decoder.StartAddress = (int)nudAddress.Value;
         this.ListInputs();

         Cursor.Current = Cursors.Default;
      }

      private void TxtInputs_EditValueChanged(object sender, EventArgs e)
      {
         if (!this.IsLoaded) return;

         Cursor.Current = Cursors.WaitCursor;

         this.Decoder.Inputs = int.Parse(txtInputs.Text);
         this.ListInputs();

         Cursor.Current = Cursors.Default;
      }

      private void GrdConnectView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
      {
         if (grdConnectView.GetRow(e.RowHandle) is FeedbackDecoderConnection connection)
         {
            if (connection.Element == null)
            {
               e.Appearance.BackColor = System.Drawing.Color.FromArgb(210, 237, 210);
               e.Appearance.BackColor2 = System.Drawing.Color.FromArgb(210, 237, 210);
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

            // Add the decoder into the project
            if (!OTCContext.Project.FeedbackDecoders.Contains(this.Decoder))
               OTCContext.Project.FeedbackDecoders.Add(this.Decoder);

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
         foreach (FeedbackDecoder decoder in FeedbackDecoder.FindAll())
         {
            if (!deviceModels.Contains(decoder.Name))
            {
               item = new ImageComboBoxItem();
               item.Value = decoder.Name;
               item.Description = decoder.Name;
               item.ImageIndex = 2;

               cboModel.Properties.Items.Add(item);
            }
         }
      }

      public void ListInputs()
      {
         int inputCount;
         int currentAddress;
         Dictionary<int, FeedbackDecoderConnection> connections = new Dictionary<int, FeedbackDecoderConnection>();

         // Create the non existing connections
         foreach (FeedbackDecoderConnection connection in this.Decoder.Connections)
            connections.Add(connection.DecoderInput, connection);

         inputCount = 1;
         currentAddress = this.Decoder.StartAddress;
         for (int output = 1; output <= this.Decoder.Inputs; output++)
         {
            if (!connections.ContainsKey(output))
               connections.Add(output, new FeedbackDecoderConnection() { DecoderInput = output, Device = this.Decoder, Element = null, Address = currentAddress });

            inputCount++;
            if (inputCount > this.InputsPerAddress)
            {
               inputCount = 1;
               currentAddress++;
            }
         }

         grdConnect.BeginUpdate();
         grdConnect.DataSource = null;

         grdConnectView.Columns.Clear();
         grdConnectView.OptionsBehavior.AutoPopulateColumns = false;

         grdConnectView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Input", Visible = true, FieldName = "DecoderInput", Width = 35 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Feedback ad.", Visible = true, FieldName = "Address", Width = 50 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Sensor ad.", Visible = true, FieldName = "SensorAddress", Width = 50 });

         grdConnectView.Columns.Add(new GridColumn() { Caption = "Element", Visible = true, FieldName = "Element.Name" });

         grdConnectView.Columns.Add(new GridColumn() { Caption = "Delay", Visible = true, FieldName = "DelayTime", Width = 30 });

         grdConnect.DataSource = connections.Values;

         grdConnectView.Columns["DecoderInput"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["DecoderInput"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

         grdConnectView.Columns["Address"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Address"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Address"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         grdConnectView.Columns["Address"].DisplayFormat.FormatString = "{0:d3}";

         grdConnectView.Columns["SensorAddress"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["SensorAddress"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["SensorAddress"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         grdConnectView.Columns["SensorAddress"].DisplayFormat.FormatString = "{0:d4}";

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