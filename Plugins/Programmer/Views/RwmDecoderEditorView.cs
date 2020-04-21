using System;
using System.Windows.Forms;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.Trains;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class RwmDecoderEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="RwmDecoderEditorView"/>.
      /// </summary>
      public RwmDecoderEditorView()
      {
         InitializeComponent();

         this.MapModelToView(new AccessoryDecoder());
      }

      /// <summary>
      /// Returns a new instance of <see cref="RwmDecoderEditorView"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      /// <param name="decoder">The decoder to edit in the editor dialogue.</param>
      public RwmDecoderEditorView(AccessoryDecoder decoder)
      {
         InitializeComponent();

         this.MapModelToView(decoder);
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

      private void CmdOk_Click(object sender, EventArgs e)
      {
         if (!this.MapViewToModel()) return;

         try
         {
            Cursor.Current = Cursors.WaitCursor;

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
         AccessoryDecoderOutput output;

         this.Decoder = decoder;

         txtName.Text = this.Decoder.Name;
         cboModel.Text = "DM.CTRL.DECO";
         // cboManufacturer.Text = "Railwaymania"; // TODO: Use created manufacturer
         cboSection.SetSelectedElement(this.Decoder.Section);
         txtNotes.Text = this.Decoder.Notes;

         output = this.Decoder.GetOutputByIndex(1);
         if (output != null)
         {
            chkOutput1.Checked = true;
            spnAddress1.Value = output.Address;
         }

         cboModel.Enabled = false;
         cboManufacturer.Enabled = false;
      }

      private bool MapViewToModel()
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must provide a valid name for the decoder.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return false;
         }

         this.Decoder.Project = OTCContext.Project;
         this.Decoder.Name = txtName.Text.Trim();
         this.Decoder.Manufacturer = cboManufacturer.EditValue as Manufacturer;
         this.Decoder.Model = cboModel.Text.Trim();
         this.Decoder.Section = cboSection.SelectedSection;
         this.Decoder.Notes = txtNotes.Text.Trim();

         return true;
      }

      #endregion

   }
}