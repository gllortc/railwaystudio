using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class SoundsManagerView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public SoundsManagerView()
      {
         InitializeComponent();

         this.ListObjects();
      }

      #endregion

      #region Event Handlers

      private void GrdAreasView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_SOUND_16, e);
      }

      private void CmdSoundAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         SoundEditorView form = new SoundEditorView();
         if (form.ShowDialog(this) == DialogResult.OK)
         {
            this.ListObjects();
         }
      }

      private void CmdSoundEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdAreasView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("No sound has been selected from list.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            int[] selRows = grdAreasView.GetSelectedRows();
            Sound sound = grdAreasView.GetRow(selRows[0]) as Sound;

            SoundEditorView form = new SoundEditorView(sound);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               this.ListObjects();
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void CmdSoundDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdAreasView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("No sound has been selected from list.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            int[] selRows = grdAreasView.GetSelectedRows();
            if (grdAreasView.GetRow(selRows[0]) is Sound sound)
            {
               if (MessageBox.Show("Are you sure you want to remove the selected sound?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
               {
                  Sound.Delete(sound);
                  this.ListObjects();
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void CmdSoundPlay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdAreasView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("No sound has been selected from list.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            int[] selRows = grdAreasView.GetSelectedRows();
            if (grdAreasView.GetRow(selRows[0]) is Sound sound)
            {
               sound.Play();
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void CmdClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      #endregion

      #region Private Members

      private void ListObjects()
      {
         try
         {
            grdAreas.BeginUpdate();

            grdAreasView.OptionsBehavior.AutoPopulateColumns = false;
            grdAreasView.Columns.Clear();
            grdAreasView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
            grdAreasView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name" });
            grdAreas.DataSource = Sound.FindAll();

            grdAreas.EndUpdate();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

        #endregion

    }
}