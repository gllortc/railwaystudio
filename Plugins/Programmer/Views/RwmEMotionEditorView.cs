using System;
using System.Windows.Forms;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.Layout.EasyConnect;
using Rwm.Otc.Trains;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class RwmEMotionEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="RwmEMotionEditorView"/>.
      /// </summary>
      public RwmEMotionEditorView()
      {
         InitializeComponent();

         this.MapModelToView(new EmotionModule());
      }

      /// <summary>
      /// Returns a new instance of <see cref="RwmEMotionEditorView"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      /// <param name="module">The decoder to edit in the editor dialogue.</param>
      public RwmEMotionEditorView(EmotionModule module)
      {
         InitializeComponent();

         this.MapModelToView(module);
      }

      #endregion

      #region Properties

      private bool IsLoaded { get; set; } = false;

      internal EmotionModule Module { get; private set; }

      #endregion

      #region Event Handlers

      private void FrmDecoderEditor_Activated(object sender, EventArgs e)
      {
         txtName.SelectAll();
         txtName.Focus();
      }

      private void GrdConnectView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(AccessoryDecoderConnection.SmallIcon, e);
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

            EmotionModule.Save(this.Module);

            // Add the decoder into the project
            if (!OTCContext.Project.EasyConnectEmotionModules.Contains(this.Module))
               OTCContext.Project.EasyConnectEmotionModules.Add(this.Module);

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

      private void MapModelToView(EmotionModule module)
      {
         AccessoryDecoderOutput output;

         this.Module = module;

         txtName.Text = this.Module.Name;
         cboModel.Text = "Railwaymania EasyConnect eMotion";
         cboSection.SetSelectedElement(this.Module.Module);
         txtNotes.Text = this.Module.Notes;

         cboModel.Enabled = false;
      }

      private bool MapViewToModel()
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must provide a valid name for the module.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return false;
         }

         this.Module.Project = OTCContext.Project;
         this.Module.Name = txtName.Text.Trim();
         this.Module.Model = cboModel.Text.Trim();
         this.Module.Module = cboSection.SelectedSection;
         this.Module.Notes = txtNotes.Text.Trim();

         return true;
      }

      #endregion

   }
}