﻿using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Designer.Modules
{
   public partial class RouteModule : DevExpress.XtraBars.Ribbon.RibbonForm, IPluginModule
   {

      #region Constants

      //private const string MODULE_GUID = "6269D397-85FB-45A8-8FB5-EECD59640B29";

      private const string DOCKPANEL_DESIGN = "dpDesign";

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="RouteModule"/>.
      /// </summary>
      public RouteModule()
      {
         InitializeComponent();

         this.Description = new RouteModuleDescriptor();
      }

      #endregion

      #region IPluginModule Implementation

      /// <summary>
      /// Gets the plugin module description properties.
      /// </summary>
      public IPluginModuleDescriptor Description { get; private set; }

      public string DocumentName
      {
         get { return this.Description.Caption; }
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

      public void Initialize(params object[] args) { }

      #endregion

      #region Event Handlers

      private void RouteModule_Load(object sender, System.EventArgs e)
      {
         grdData.Dock = System.Windows.Forms.DockStyle.Fill;
         pnlRoute.Dock = System.Windows.Forms.DockStyle.Fill;

         this.ShowRoutesList();
         this.RefreshViewStatus();
      }

      private void RouteModule_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
      {
         Otc.Layout.Route.ClearAll();
      }

      private void GrdDataView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(Otc.Layout.Route.SmallIcon, e);
      }

      private void GrdData_DoubleClick(object sender, System.EventArgs e)
      {
         this.RouteEdit();
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

      private void CmdGenerateName_Click(object sender, System.EventArgs e)
      {
         this.GenerateRouteName();
      }

      #endregion

   }
}
