using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.Layout.EasyConnect;
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

      private void grdActionsView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         if (sender is GridView gridView)
         {
            if (gridView.GetRow(e.RowHandle) is IEMotionAction action)
            {
               StudioContext.UI.DrawRowIcon(action.SmallIcon, e);
            }
         }
      }

      private void CmdAddLampFailure_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         EMotionActionFailigLampEditorView view = new EMotionActionFailigLampEditorView();
         if (view.ShowDialog(this) == DialogResult.OK)
         {
            this.Module.Actions.Add(view.Action);
            RefreshActionsList();
         }
      }

      private void CmdAddSirenLights_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         EMotionActionSirenLightsEditorView view = new EMotionActionSirenLightsEditorView();
         if (view.ShowDialog(this) == DialogResult.OK)
         {
            this.Module.Actions.Add(view.Action);
            RefreshActionsList();
         }
      }

      private void ChkPushbutton1_CheckedChanged(object sender, EventArgs e)
      {
         lblPushbutton1.Enabled = chkPushbutton1.Checked;
         lblPushbuttonTime1.Enabled = chkPushbutton1.Checked;
         spinPushbuttonTime1.Enabled = chkPushbutton1.Checked;
      }

      private void ChkPushbutton2_CheckedChanged(object sender, EventArgs e)
      {
         lblPushbutton2.Enabled = chkPushbutton2.Checked;
         lblPushbuttonTime2.Enabled = chkPushbutton2.Checked;
         spinPushbuttonTime2.Enabled = chkPushbutton2.Checked;
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

         chkPushbutton1.Checked = this.Module.Button1Enabled;
         spinPushbuttonTime1.Value = this.Module.Button1Interval;
         chkPushbutton2.Checked = this.Module.Button2Enabled;
         spinPushbuttonTime2.Value = this.Module.Button2Interval;

         cboModel.Enabled = false;

         RefreshActionsList();
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

         this.Module.Button1Enabled = chkPushbutton1.Checked;
         this.Module.Button1Interval = Decimal.ToInt32(spinPushbuttonTime1.Value);
         this.Module.Button2Enabled = chkPushbutton2.Checked;
         this.Module.Button2Interval = Decimal.ToInt32(spinPushbuttonTime2.Value);

         return true;
      }

      private void RefreshActionsList()
      {
         try
         {
            grdActions.BeginUpdate();

            grdActionsView.OptionsBehavior.AutoPopulateColumns = false;
            grdActionsView.Columns.Clear();
            grdActionsView.Columns.Add(new GridColumn() { Caption = "ID",              Visible = false,  FieldName = "ID" });
            grdActionsView.Columns.Add(new GridColumn() { Caption = "Type",            Visible = true,   FieldName = "Name" });
            grdActionsView.Columns.Add(new GridColumn() { Caption = "LED connections", Visible = true,   FieldName = "LedPins" });
            grdActionsView.Columns.Add(new GridColumn() { Caption = "Activated by",    Visible = true,   FieldName = "ActivatedBy" });
            grdActions.DataSource = this.Module.Actions;

            grdActions.EndUpdate();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      #endregion

   }
}