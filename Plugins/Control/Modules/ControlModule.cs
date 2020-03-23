using System.Drawing;
using System.Windows.Forms;
using RailwayStudio.Common;
using Rwm.Otc;
using Rwm.Studio.Plugins.Control.Controls;

namespace Rwm.Studio.Plugins.Control.Modules
{
   public partial class ControlModule : DevExpress.XtraBars.Ribbon.RibbonForm, IPluginModule
   {

      #region Constants

      private const string MODULE_GUID = "DF6D5AB9-D3BF-4A8A-9B55-C8B9BB9DA035";

      private const string DOCKPANEL_CONTROL = "pnlControl";

      #endregion

      #region Constructors

      public ControlModule()
      {
         InitializeComponent();
      }

      #endregion

      #region IPluginModule Implementation

      public Image LargeIcon
      {
         get { return Properties.Resources.ICO_APP_32; }
      }

      public Image SmallIcon
      {
         get { return Properties.Resources.ICO_APP_16; }
      }

      public string ModuleID
      {
         get { return MODULE_GUID; }
      }

      public string ModuleName
      {
         get { return "Layout Control"; }
      }

      public string DocumentName
      {
         get { return ""; }
      }

      public bool IsMultiInstance
      {
         get { return true; }
      }

      public object StartupRibbonPage
      {
         get { return rptControl; }
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
         this.ShowPanels();
         this.RefreshStatus();

         chkOptionsExecuteActions.Checked = OTCContext.Project.ExecuteBlockActions;
         chkOptionsManualSensorAllowed.Checked = OTCContext.Project.AllowManualSensorActivation;

         // Register project events
         OTCContext.Project.DigitalSystem.OnInformationReceived += DigitalSystem_OnInformationReceived;
         OTCContext.Project.DigitalSystem.OnCommandReceived += DigitalSystem_OnCommandReceived;

         // Show module information
         StudioContext.LogInformation("{0} v{1} loaded", this.ModuleName, Application.ProductVersion);
      }

      /// <summary>
      /// Add docable panels to environment.
      /// </summary>
      public void CreatePanels()
      {
         RouteManualActivatorControl ctrl = new RouteManualActivatorControl();
         ctrl.Refresh();

         StudioContext.UI.AddDockPanel(DOCKPANEL_CONTROL,
                                       "Automation toolbox",
                                       ctrl,
                                       global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_16,
                                       DevExpress.XtraBars.Docking.DockingStyle.Right);
      }

      /// <summary>
      /// Remove all dockable panels created when the module was loaded.
      /// </summary>
      public void DestoryPanels()
      {
         StudioContext.UI.RemoveDockPanel(DOCKPANEL_CONTROL);
      }

      #endregion

      #region Event Handlers

      private void ControlModule_FormClosed(object sender, FormClosedEventArgs e)
      {
         Rwm.Otc.OTCContext.Settings.SaveSettings();
      }

      private void CmdSystemManage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.SystemsManage();
      }

      private void CmdSystemConnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.SystemConnect();
      }

      private void CmdSystemDisconnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.SystemDisconnect();
      }

      private void CmdSystemSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.SystemSettings();
      }

      private void CmdCtrlEmergencyStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.EmergencyStopRequest();
      }

      private void CmdCtrlResumeOps_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.ResumeOperationsRequest();
      }

      private void CmdUtilsDigitalAddressCalculator_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         StudioContext.Utils.ShowDigitalAddressCalculator();
      }

      private void BbtnThemesManage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.ThemesManage();
      }

      #endregion

   }
}
