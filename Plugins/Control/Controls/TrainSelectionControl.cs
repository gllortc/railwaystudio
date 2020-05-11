using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Rwm.Otc.Layout;
using Rwm.Otc.Trains;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Control.Controls
{
   public partial class TrainSelectionControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="TrainSelectionControl"/>.
      /// </summary>
      /// <param name="settings"></param>
      /// <param name="control"></param>
      public TrainSelectionControl()
      {
         InitializeComponent();
      }

      #endregion

      #region Properties

      private GridHitInfo MouseDownHitInfo { get; set; } = null;

      public Train SelectedTrain
      {
         get
         {
            if (grdTrainView.SelectedRowsCount <= 0)
               return null;

            Train train = (Train)grdTrainView.GetRow(grdTrainView.GetSelectedRows()[0]);
            if (train == null) return null;

            return train;
         }
      }

      #endregion

      #region Methods

      public void RefreshTrainList()
      {
         grdTrainView.BeginUpdate();

         if (grdTrainView.Columns.Count <= 0)
         {
            grdTrainView.OptionsBehavior.AutoPopulateColumns = false;
            grdTrainView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
            grdTrainView.Columns.Add(new GridColumn() { Caption = "Image", Visible = true, FieldName = "Picture" });
            grdTrainView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name" });
            grdTrainView.Columns.Add(new GridColumn() { Caption = "Block", Visible = true, FieldName = "BlockOccupied.DisplayName" });

            grdTrainView.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdTrainView.Columns[2].AppearanceCell.FontStyleDelta = FontStyle.Bold;
         }

         grdTrain.DataSource = null;
         grdTrain.DataSource = Train.FindAllDigital();

         grdTrainView.EndUpdate();
      }

      #endregion

      #region Event Handlers

      private void GrdTrainView_RowStyle(object sender, RowStyleEventArgs e)
      {
         if (!(grdTrainView.GetRow(e.RowHandle) is Train train)) return;

         if (train.BlockOccupied != null)
         {
            e.Appearance.BackColor = Color.LightPink;
            e.Appearance.BackColor2 = Color.LightPink;
         }
      }

      private void GrdTrainView_MouseDown(object sender, MouseEventArgs e)
      {
         GridView view = sender as GridView;
         this.MouseDownHitInfo = null;

         GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
         if (System.Windows.Forms.Control.ModifierKeys != Keys.None) return;
         if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
            this.MouseDownHitInfo = hitInfo;
      }

      private void GrdTrainView_MouseMove(object sender, MouseEventArgs e)
      {
         GridView view = sender as GridView;
         if (e.Button == MouseButtons.Left && this.MouseDownHitInfo != null)
         {
            Size dragSize = SystemInformation.DragSize;
            Rectangle dragRect = new Rectangle(new Point(this.MouseDownHitInfo.HitPoint.X - dragSize.Width / 2,
                                                         this.MouseDownHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

            if (!dragRect.Contains(new Point(e.X, e.Y)))
            {
               Train train = view.GetRow(this.MouseDownHitInfo.RowHandle) as Train;
               view.GridControl.DoDragDrop(train, DragDropEffects.Move);
               this.MouseDownHitInfo = null;
               DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
            }
         }
      }

      private void CmdTrainEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (this.SelectedTrain == null) return;

         StudioContext.OpenPluginModule("8458EC08-4224-42B0-8CF5-84FCD5AAFB3C", this.SelectedTrain.ID); 
      }

      private void CmdTrainUnassign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (this.SelectedTrain == null) return;

         Element.UnassignTrain(this.SelectedTrain);
         this.RefreshTrainList();
      }

      private void CmdTrainClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         string msg = "Are you sure you want to unassign all trains from their current positions?" + Environment.NewLine + Environment.NewLine + "This action cannot be undone.";

         if (MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            return;

         foreach (Train train in (ICollection<Train>)grdTrain.DataSource)
         {
            Element.UnassignTrain(train);
         }

         this.RefreshTrainList();
      }

      #endregion

   }
}
