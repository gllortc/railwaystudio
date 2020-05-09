using System;
using System.Drawing;
using Rwm.Otc.Layout;
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

      #region Methods

      public void RefreshTrainList()
      {
         grdTrainView.BeginUpdate();
         grdTrain.DataSource = null;
         grdTrain.DataSource = ElementTrain.ListTrains();
         grdTrainView.Columns[0].Visible = false;
         grdTrainView.Columns[1].Visible = false;

         grdTrainView.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdTrainView.Columns[4].AppearanceCell.FontStyleDelta = FontStyle.Bold;
         grdTrainView.Columns[4].AppearanceCell.FontSizeDelta = 2;

         grdTrainView.EndUpdate();
      }

      #endregion

      #region Event Handlers

      private void GrdRouteView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         if (!(grdTrainView.GetRow(e.RowHandle) is Route route)) return;

         if (route.IsActive)
            StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_ROUTE_ACTIVE_16, e);
         else
            StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_ROUTE_16, e);
      }

      private void GrdRouteView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
      {
         if (!(grdTrainView.GetRow(e.RowHandle) is Route route)) return;

         if (route.IsActive)
         {
            e.Appearance.BackColor = Color.LightBlue;
            e.Appearance.BackColor2 = Color.LightBlue;
         }
      }

      private void GrdRouteView_DoubleClick(object sender, EventArgs e)
      {
         CmdRouteActivate_ItemClick(sender, null);
      }

      private void CmdRouteActivate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdTrainView.SelectedRowsCount <= 0)
         {
            return;
         }

         Route route = (Route)grdTrainView.GetRow(grdTrainView.GetSelectedRows()[0]);
         if (route != null)
         {
            if (!route.IsActive)
            {
               if (!route.Activate())
               {
                  StudioContext.AlertError("<b>Route conflict</b>",
                                           String.Format("Route <b>{0}</b> cannot be activated due to a conflict with current active route(s)", route.Name));
               }
            }
            else
               route.Deactivate();

            this.RefreshTrainList();
         }
      }

      private void CmdTrainUnassign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {

      }

      private void CmdTrainClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         Route.ClearAll();
         this.RefreshTrainList();
      }

        #endregion

    }
}
