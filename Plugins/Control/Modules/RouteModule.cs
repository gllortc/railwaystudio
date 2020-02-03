using System.Drawing;
using RailwayStudio.Common;

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

      public Image LargeIcon
      {
         get { return Properties.Resources.ICO_DESIGN_32; }
      }

      public Image SmallIcon
      {
         get { return Properties.Resources.ICO_DESIGN_16; }
      }

      public string ModuleID
      {
         get { return MODULE_GUID; }
      }

      public string ModuleName
      {
         get { return "Route designer"; }
      }

      public string DocumentName
      {
         get { return this.ModuleName; }
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
         this.RefreshRouteList();
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
         tabPanels.Dock = System.Windows.Forms.DockStyle.Fill;

         this.HasChanges = false;
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

      private void CmdRouteProperties_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.RouteProperties();
      }

      private void CmdRouteSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.RouteSave();
      }

      private void CmdRouteClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.RouteClose();
      }

      #endregion

   }
}
