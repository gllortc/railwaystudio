using System.Windows.Forms;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Designer.Modules
{
   public partial class TesterModule : DevExpress.XtraBars.Ribbon.RibbonForm, IPluginModule
   {

      #region Constants

      private const string DOCKPANEL_CONTROL = "pnlControl";

      #endregion

      #region Constructors

      /// <summary>
      /// returns a new instance of <see cref="TesterModule"/>.
      /// </summary>
      public TesterModule()
      {
         InitializeComponent();

         this.Description = new TesterModuleDescriptor();
      }

      #endregion

      #region IPluginModule Implementation

      /// <summary>
      /// Gets the plugin module description properties.
      /// </summary>
      public IPluginModuleDescriptor Description { get; private set; }

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
         this.RefreshStatus();

         // Show module information
         StudioContext.LogInformation("{0} v{1} loaded", this.Description.Caption, Application.ProductVersion);
      }

      #endregion

      #region Event Handlers

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

      private void CmdAdrCalc_Click(object sender, System.EventArgs e)
      {
         this.AddressCalculate();
      }

      private void BbtnThemesManage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         StudioContext.Utils.ShowThemeManager(this);
      }

      #endregion

   }
}
