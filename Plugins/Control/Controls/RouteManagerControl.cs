using DevExpress.XtraGrid.Columns;
using RailwayStudio.Common;
using Rwm.Otc.Layout;
using Rwm.Otc.UI.Controls;
using Rwm.Studio.Plugins.Control.Modules;
using Rwm.Studio.Plugins.Control.Views;
using System;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Controls
{
   public partial class RouteManagerControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      /// <summary>
      /// Do not use this constructor. 
      /// It is only for design pourposes.
      /// </summary>
      public RouteManagerControl()
      {
         InitializeComponent();
      }

      /// <summary>
      /// Returns a new instance of <see cref="RouteManagerControl"/>.
      /// </summary>
      /// <param name="settings"></param>
      /// <param name="control"></param>
      public RouteManagerControl(Form ownerView, SwitchboardDesignControl control)
      {
         InitializeComponent();

         this.OwnerView = ownerView as DesignModule;
         this.SwitchboardControl = control;

         this.Refresh();
      }

      #endregion

      #region Properties

      public SwitchboardDesignControl SwitchboardControl { get; private set; }

      public DesignModule OwnerView { get; private set; }

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

      private void cmdRouteNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         // StartRecording();

         RouteEditorView form = new RouteEditorView();
         form.ShowDialog(this);

         if (form.DialogResult == DialogResult.OK)
         {
            this.Refresh();
         }
      }

      private void cmdRouteEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdRouteView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the route you want to edit.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         Route route = (Route)grdRouteView.GetRow(grdRouteView.GetSelectedRows()[0]);
         if (route != null)
         {
            RouteEditorView form = new RouteEditorView(route);
            form.ShowDialog(this);

            if (form.DialogResult == DialogResult.OK)
            {
               this.Refresh();
            }
         }
         else
         {
            MessageBox.Show("ERROR obtaining the route from project file. Please, try again.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
      }

      private void cmdRouteDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdRouteView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the route you want to delete.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            Route route = (Route)grdRouteView.GetRow(grdRouteView.GetSelectedRows()[0]);
            if (route != null)
            {
               if (MessageBox.Show("Are you sure you want to remove the route " + route.Name + "?",
                                   Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
               {
                  Route.Delete(route.ID); // OTCContext.Project.Remove(route);
                  this.Refresh();
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR deleting route:" + Environment.NewLine + Environment.NewLine + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      #endregion

   }
}
