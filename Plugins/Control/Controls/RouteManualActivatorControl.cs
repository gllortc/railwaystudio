using DevExpress.XtraGrid.Columns;
using RailwayStudio.Common;
using Rwm.Otc;
using Rwm.Otc.Layout;
using System;

namespace Rwm.Studio.Plugins.Control.Controls
{
   public partial class RouteManualActivatorControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="RouteManualActivatorControl"/>.
      /// </summary>
      /// <param name="settings"></param>
      /// <param name="control"></param>
      public RouteManualActivatorControl()
      {
         InitializeComponent();

         this.Refresh();
      }

      #endregion

      #region Methods

      public override void Refresh()
      {
         grdRoute.BeginUpdate();
         grdRouteView.Columns.Clear();
         grdRouteView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name" });
         grdRoute.DataSource = Route.FindAll();
         grdRoute.EndUpdate();

         base.Refresh();
      }

      #endregion

      #region Event Handlers

      private void grdRouteView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_16, e);
      }

      private void grdRouteView_DoubleClick(object sender, EventArgs e)
      {
         cmdRouteActivate_ItemClick(sender, null);
      }

      private void cmdRouteActivate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdRouteView.SelectedRowsCount <= 0)
         {
            return;
         }

         Route route = (Route)grdRouteView.GetRow(grdRouteView.GetSelectedRows()[0]);
         if (route != null)
         {
            route.Activate();
         }
      }

      private void cmdRouteClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         foreach (Switchboard switchboard in Switchboard.FindAll())
         {
            switchboard.ClearRoute();
         }
      }

      #endregion

   }
}
