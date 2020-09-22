using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class AccessoryDecoderEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="AccessoryDecoderEditorView"/>.
      /// </summary>
      public AccessoryDecoderEditorView(int outputs)
      {
         InitializeComponent();
         MapModelToView(new AccessoryDecoder(outputs));
      }

      /// <summary>
      /// Returns a new instance of <see cref="AccessoryDecoderEditorView"/>.
      /// </summary>
      /// <param name="decoder">The decoder to edit in the editor dialogue.</param>
      public AccessoryDecoderEditorView(AccessoryDecoder decoder)
      {
         InitializeComponent();
         MapModelToView(decoder);
      }

      #endregion

      #region Properties

      internal AccessoryDecoder Decoder { get; private set; }

      #endregion

      #region Event Handlers

      private void FrmDecoderEditor_Activated(object sender, EventArgs e)
      {
         txtName.SelectAll();
         txtName.Focus();
      }

      private void GrdOutView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(AccessoryDecoderConnection.SmallIcon, e);
      }

      private void GrdOutView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
      {
         if (grdOutView.GetRow(e.RowHandle) is AccessoryDecoderOutput output)
         {
            if (output.AccessoryConnection == null)
            {
               e.Appearance.BackColor = System.Drawing.Color.FromArgb(210, 237, 210);
               e.Appearance.BackColor2 = System.Drawing.Color.FromArgb(210, 237, 210);
            }
         }
      }

      private void Edit_ButtonClick(object sender, ButtonPressedEventArgs e)
      {
         if (grdOutView.GetRow(grdOutView.FocusedRowHandle) is AccessoryDecoderOutput output)
         {
            AccessoryDecoderOutputEditorView form = new AccessoryDecoderOutputEditorView(output);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               this.ListOutputs();
            }
         }
      }

      private void CmdOk_Click(object sender, EventArgs e)
      {
         if (!this.MapViewToModel()) return;

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

      private void MapModelToView(AccessoryDecoder decoder)
      {
         this.Decoder = decoder;

         txtName.Text = this.Decoder.Name;
         cboManufacturer.SetSelectedElement(this.Decoder.Manufacturer);
         cboSection.SetSelectedElement(this.Decoder.Section);
         lblOutputsCount.Text = this.Decoder.Outputs.Count.ToString();
         txtNotes.Text = this.Decoder.Notes;

         this.SetModelList(this.Decoder.Model);

         this.ListOutputs();
      }

      private bool MapViewToModel()
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must provide a valid name for the decoder.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tabDecoder.SelectedTabPage = tabDecoderGeneral;
            txtName.Focus();
            return false;
         }

         Cursor.Current = Cursors.WaitCursor;

         this.Decoder.Project = OTCContext.Project;
         this.Decoder.Name = txtName.Text.Trim();
         this.Decoder.Manufacturer = cboManufacturer.SelectedManufacturer;
         this.Decoder.Model = cboModel.Text.Trim();
         this.Decoder.Section = cboSection.SelectedSection;
         this.Decoder.Notes = txtNotes.Text.Trim();

         // TODO: get all outputs??

         return true;
      }

      private void SetModelList(string selected)
      {
         ImageComboBoxItem item;
         List<string> models = new List<string>();

         // Fill models list
         cboModel.Properties.Items.Clear();
         foreach (AccessoryDecoder decoder in AccessoryDecoder.FindAll())
         {
            if (!string.IsNullOrEmpty(decoder.Model) && !models.Contains(decoder.Model))
            {
               item = new ImageComboBoxItem();
               item.Value = decoder.Model;
               item.Description = decoder.Model;
               item.ImageIndex = 2;

               cboModel.Properties.Items.Add(item);
               models.Add(decoder.Model);
            }
         }

         if (selected != null)
            cboModel.Text = selected;
      }

      private void ListOutputs()
      {
         RepositoryItemSpinEdit spedit = new RepositoryItemSpinEdit();
         spedit.MinValue = 0;
         spedit.MaxValue = OTCContext.Project.DigitalSystem.AccessoryAddressRange.Maximum;
         spedit.Mask.EditMask = "D4";

         RepositoryItemButtonEdit edit = new RepositoryItemButtonEdit();
         edit.TextEditStyle = TextEditStyles.HideTextEditor;
         edit.ButtonClick += Edit_ButtonClick;
         edit.Buttons[0].Caption = "Edit output properties";
         edit.Buttons[0].Kind = ButtonPredefines.Ellipsis;

         grdOut.BeginUpdate();

         grdOut.DataSource = null;
         grdOutView.Columns.Clear();
         grdOutView.OptionsBehavior.AutoPopulateColumns = false;

         grdOutView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
         grdOutView.Columns.Add(new GridColumn() { Caption = "Output", Visible = true, FieldName = "Index", Width = 30 });
         grdOutView.Columns.Add(new GridColumn() { Caption = "Address", Visible = true, FieldName = "Address", Width = 30, ColumnEdit = spedit });
         grdOutView.Columns.Add(new GridColumn() { Caption = "Mode", Visible = true, FieldName = "DisplayConfiguration" });
         grdOutView.Columns.Add(new GridColumn() { Caption = "Connected to", Visible = true, FieldName = "AccessoryConnection.Element.DisplayName" });
         grdOutView.Columns.Add(new GridColumn() { Caption = "Actions", Visible = true, FieldName = "ActionButtons", UnboundType = DevExpress.Data.UnboundColumnType.Object, Width = 30, ColumnEdit = edit });

         grdOut.DataSource = this.Decoder.Outputs;

         grdOutView.Columns["Index"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdOutView.Columns["Index"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdOutView.Columns["Index"].OptionsColumn.AllowEdit = false;

         grdOutView.Columns["Address"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdOutView.Columns["Address"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdOutView.Columns["Address"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         grdOutView.Columns["Address"].DisplayFormat.FormatString = "{0:d4}";
         grdOutView.Columns["Address"].OptionsColumn.AllowEdit = true;

         grdOutView.Columns["DisplayConfiguration"].OptionsColumn.AllowEdit = false;

         grdOutView.Columns["AccessoryConnection.Element.DisplayName"].OptionsColumn.AllowEdit = false;

         grdOut.EndUpdate();
      }

      #endregion

   }
}