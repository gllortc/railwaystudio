using System;
using System.Drawing;
using DevExpress.XtraGrid.Columns;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Control.Controls
{
   public partial class RouteActivationControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="RouteActivationControl"/>.
      /// </summary>
      /// <param name="settings"></param>
      /// <param name="control"></param>
      public RouteActivationControl()
      {
         InitializeComponent();
      }

      #endregion

      #region Methods

      public void RefreshRouteList()
      {
         grdRoute.BeginUpdate();
         grdRouteView.Columns.Clear();
         grdRouteView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name" });
         grdRoute.DataSource = Route.FindAll();
         grdRoute.EndUpdate();
      }

      #endregion

      #region Event Handlers

      private void GrdRouteView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         if (!(grdRouteView.GetRow(e.RowHandle) is Route route)) return;

         if (route.IsActive)
            StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_ROUTE_ACTIVE_16, e);
         else
            StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_ROUTE_16, e);
      }

      private void GrdRouteView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
      {
         if (!(grdRouteView.GetRow(e.RowHandle) is Route route)) return;

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
         if (grdRouteView.SelectedRowsCount <= 0)
         {
            return;
         }

         Route route = (Route)grdRouteView.GetRow(grdRouteView.GetSelectedRows()[0]);
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

            this.RefreshRouteList();
         }
      }

      private void CmdRouteClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         Route.ClearAll();
         this.RefreshRouteList();
      }

      #endregion

   }
}
