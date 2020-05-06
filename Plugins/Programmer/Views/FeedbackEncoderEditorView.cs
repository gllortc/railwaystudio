using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.Trains;

namespace Rwm.Studio.Plugins.Designer.Views
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

         this.ListComboLists();
         this.MapModelToView(new FeedbackEncoder());

         this.IsLoaded = true;
      }

      /// <summary>
      /// Returns a new instance of <see cref="FeedbackEncoderEditorView"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      /// <param name="decoder">The decoder to edit in the editor dialogue.</param>
      public FeedbackEncoderEditorView(FeedbackEncoder decoder)
      {
         InitializeComponent();

         this.ListComboLists();
         this.MapModelToView(decoder);

         this.IsLoaded = true;
      }

      #endregion

      #region Properties

      private bool IsLoaded { get; set; } = false;

      internal FeedbackEncoder Decoder { get; private set; }

      private int InputsPerAddress
      {
         get { return (OTCContext.Project.DigitalSystem != null ? OTCContext.Project.DigitalSystem.PointAddressesByFeedbackAddress : 8); }
      }

      #endregion

      #region Event Handlers

      private void FrmDecoderEditor_Activated(object sender, EventArgs e)
      {
         this.ListInputs();

         txtName.SelectAll();
         txtName.Focus();
      }

      private void GrdConnectView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
      {
         if (grdConnectView.GetRow(e.RowHandle) is FeedbackEncoderInput connection)
         {
            if (connection.FeedbackConnection == null)
            {
               e.Appearance.BackColor = System.Drawing.Color.FromArgb(210, 237, 210);
               e.Appearance.BackColor2 = System.Drawing.Color.FromArgb(210, 237, 210);
            }
         }
      }

      private void Edit_ButtonClick(object sender, ButtonPressedEventArgs e)
      {
         if (grdConnectView.GetRow(grdConnectView.FocusedRowHandle) is AccessoryDecoderOutput output)
         {
            AccessoryDecoderOutputEditorView form = new AccessoryDecoderOutputEditorView(output);
            //if (form.ShowDialog(this) == DialogResult.OK)
            //{
            //   this.ListOutputs();
            //}
         }
      }

      private void CmdOk_Click(object sender, EventArgs e)
      {
         try
         {
            if (!this.MapViewToModel()) return;

            Cursor.Current = Cursors.WaitCursor;

            FeedbackEncoder.Save(this.Decoder);

            // Add the decoder into the project
            if (!OTCContext.Project.FeedbackEncoders.Contains(this.Decoder))
               OTCContext.Project.FeedbackEncoders.Add(this.Decoder);

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

      private void MapModelToView(FeedbackEncoder decoder)
      {
         this.Decoder = decoder;

         txtName.Text = this.Decoder.Name;
         cboModel.Text = this.Decoder.Model;
         cboManufacturer.EditValue = this.Decoder.Manufacturer;
         lblInputsCount.Text = this.Decoder.Inputs.Count.ToString();
         txtNotes.Text = this.Decoder.Notes;
         cboSection.SetSelectedElement(this.Decoder.Section);
      }

      private bool MapViewToModel()
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must provide a valid name for the decoder.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return false;
         }

         Cursor.Current = Cursors.WaitCursor;

         this.Decoder.Project = OTCContext.Project;
         this.Decoder.Name = txtName.Text.Trim();
         this.Decoder.Manufacturer = cboManufacturer.EditValue as Manufacturer;
         this.Decoder.Model = cboModel.Text.Trim();
         this.Decoder.Notes = txtNotes.Text.Trim();
         this.Decoder.Section = cboSection.SelectedSection;

         return true;
      }

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
         foreach (FeedbackEncoder decoder in FeedbackEncoder.FindAll())
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

      private void ListInputs()
      {
         RepositoryItemSpinEdit spedit = new RepositoryItemSpinEdit();
         spedit.MinValue = 0;
         spedit.MaxValue = OTCContext.Project.DigitalSystem.FeedbackAddressRange.Maximum;
         spedit.Mask.EditMask = "D4";

         RepositoryItemButtonEdit edit = new RepositoryItemButtonEdit();
         edit.TextEditStyle = TextEditStyles.HideTextEditor;
         edit.ButtonClick += Edit_ButtonClick;
         edit.Buttons[0].Caption = "Edit output properties";
         edit.Buttons[0].Kind = ButtonPredefines.Ellipsis;

         grdConnect.BeginUpdate();

         grdConnect.DataSource = null;
         grdConnectView.Columns.Clear();
         grdConnectView.OptionsBehavior.AutoPopulateColumns = false;

         grdConnectView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Input", Visible = true, FieldName = "Index", Width = 20 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Address", Visible = true, FieldName = "Address", Width = 30, ColumnEdit = spedit });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Point", Visible = true, FieldName = "PointAddress", Width = 25 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Connected to", Visible = true, FieldName = "FeedbackConnection.Element.DisplayName" });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Actions", Visible = true, FieldName = "ActionButtons", UnboundType = DevExpress.Data.UnboundColumnType.Object, Width = 30, ColumnEdit = edit });

         grdConnect.DataSource = this.Decoder.Inputs;

         grdConnectView.Columns["Index"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Index"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Index"].OptionsColumn.AllowEdit = false;

         grdConnectView.Columns["Address"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Address"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Address"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         grdConnectView.Columns["Address"].DisplayFormat.FormatString = "{0:d4}";
         grdConnectView.Columns["Address"].OptionsColumn.AllowEdit = true;

         grdConnectView.Columns["PointAddress"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["PointAddress"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["PointAddress"].OptionsColumn.AllowEdit = false;

         grdConnectView.Columns["PointAddress"].OptionsColumn.AllowEdit = false;

         grdConnectView.Columns["FeedbackConnection.Element.DisplayName"].OptionsColumn.AllowEdit = false;

         grdConnect.EndUpdate();
      }

      #endregion

   }
}