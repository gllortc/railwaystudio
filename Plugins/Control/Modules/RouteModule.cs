using System.Drawing;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Control.Modules
{
   public partial class RouteModule : DevExpress.XtraBars.Ribbon.RibbonForm, IPluginModule
   {

      #region Constants

      private const string MODULE_GUID = "6269D397-85FB-45A8-8FB5-EECD59640B29";

      private const string DOCKPANEL_DESIGN = "dpDesign";

      #endregion

      #region Constructors

      public RouteModule()
      {
         InitializeComponent();
      }

      #endregion

      #region IPluginModule Implementation

      public string ID
      {
         get { return MODULE_GUID; }
      }

      public Image LargeIcon
      {
         get { return Properties.Resources.ICO_MODULE_ROUTES_32; }
      }

      public Image SmallIcon
      {
         get { return Properties.Resources.ICO_DESIGN_16; }
      }

      public string Caption
      {
         get { return "Route designer"; }
      }

      public string DocumentName
      {
         get { return this.Caption; }
      }

      public bool IsMultiInstance
      {
         get { return true; }
      }

      public object StartupRibbonPage
      {
         get { return rbpDesign; }
      }

      public object RibbonStatusBar
      {
         get { return ribbonStatusBar; }
      }

      public bool UseProject
      {
         get { return true; }
      }

      public void Initialize(params object[] args)
      {
         // Nothing to do here
      }

      public void CreatePanels() { }

      /// <summary>
      /// Remove all dockable panels created when the module was loaded.
      /// </summary>
      public void DestoryPanels() { }

      #endregion

      #region Event Handlers

      private void RouteModule_Load(object sender, System.EventArgs e)
      {
         grdData.Dock = System.Windows.Forms.DockStyle.Fill;
         pnlRoute.Dock = System.Windows.Forms.DockStyle.Fill;

         this.ShowRoutesList();
         this.RefreshViewStatus();
      }

      private void GrdDataView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_ROUTE_16, e);
      }

      private void GrdData_DoubleClick(object sender, System.EventArgs e)
      {
         this.RouteEdit();
      }

      private void GrdConnectView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
      {
         System.Data.DataRowView drv = grdConnectView.GetRow(e.RowHandle) as System.Data.DataRowView;
         if (drv != null)
         {
            if ((int)drv[0] <= 0)
            {
               e.Appearance.BackColor = Color.FromArgb(192, 255, 192);
               e.Appearance.BackColor2 = Color.FromArgb(192, 255, 192);
            }
         }
      }

      private void CmdRouteAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.RouteAdd();
      }

      private void CmdRouteEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.RouteEdit();
      }

      private void CmdRouteDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.RouteDelete();
      }

      private void CmdRouteSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.RouteSave();
      }

      private void CmdRouteSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.RouteSaveAndClose();
      }

      private void CmdRouteClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.RouteClose();
      }

      private void ChkIsBlock_CheckedChanged(object sender, System.EventArgs e)
      {
         grpBlockConnections.Enabled = chkIsBlock.Checked;
      }

      #endregion

   }
}
