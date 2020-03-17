namespace Rwm.Studio.Plugins.Control.Modules
{
   partial class ControlModule
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlModule));
         this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.cmdSystemSettings = new DevExpress.XtraBars.BarButtonItem();
         this.cmdSystemManage = new DevExpress.XtraBars.BarButtonItem();
         this.bsiTheme = new DevExpress.XtraBars.BarStaticItem();
         this.bsiSystem = new DevExpress.XtraBars.BarStaticItem();
         this.chkOptionsManualSensorAllowed = new DevExpress.XtraBars.BarCheckItem();
         this.chkOptionsExecuteActions = new DevExpress.XtraBars.BarCheckItem();
         this.cmdCtrlEmergencyStop = new DevExpress.XtraBars.BarButtonItem();
         this.bbgOptions = new DevExpress.XtraBars.BarButtonGroup();
         this.cmdUtilsDigitalAddressCalculator = new DevExpress.XtraBars.BarButtonItem();
         this.cmdSystemDisconnect = new DevExpress.XtraBars.BarButtonItem();
         this.cmdSystemConnect = new DevExpress.XtraBars.BarButtonItem();
         this.cmdCtrlResumeOps = new DevExpress.XtraBars.BarButtonItem();
         this.rptControl = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.rpgSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.rpgControl = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.rpgUtils = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
         this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.pnlContainer = new DevExpress.XtraEditors.PanelControl();
         this.tabPanels = new DevExpress.XtraTab.XtraTabControl();
         this.tabPanel1 = new DevExpress.XtraTab.XtraTabPage();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).BeginInit();
         this.pnlContainer.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.tabPanels)).BeginInit();
         this.tabPanels.SuspendLayout();
         this.SuspendLayout();
         // 
         // ribbonControl
         // 
         this.ribbonControl.ExpandCollapseItem.Id = 0;
         this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.cmdSystemSettings,
            this.cmdSystemManage,
            this.bsiTheme,
            this.bsiSystem,
            this.chkOptionsManualSensorAllowed,
            this.chkOptionsExecuteActions,
            this.cmdCtrlEmergencyStop,
            this.bbgOptions,
            this.cmdUtilsDigitalAddressCalculator,
            this.cmdSystemDisconnect,
            this.cmdSystemConnect,
            this.cmdCtrlResumeOps});
         this.ribbonControl.Location = new System.Drawing.Point(0, 0);
         this.ribbonControl.MaxItemId = 22;
         this.ribbonControl.Name = "ribbonControl";
         this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rptControl});
         this.ribbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
         this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
         this.ribbonControl.Size = new System.Drawing.Size(837, 143);
         this.ribbonControl.StatusBar = this.ribbonStatusBar;
         // 
         // cmdSystemSettings
         // 
         this.cmdSystemSettings.Caption = "Settings";
         this.cmdSystemSettings.Id = 2;
         this.cmdSystemSettings.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEM_SETUP_16;
         this.cmdSystemSettings.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("cmdSystemSettings.ImageOptions.LargeImage")));
         this.cmdSystemSettings.Name = "cmdSystemSettings";
         this.cmdSystemSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdSystemSettings_ItemClick);
         // 
         // cmdSystemManage
         // 
         this.cmdSystemManage.Caption = "Manage systems";
         this.cmdSystemManage.Id = 4;
         this.cmdSystemManage.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEMS_16;
         this.cmdSystemManage.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEMS_32;
         this.cmdSystemManage.Name = "cmdSystemManage";
         this.cmdSystemManage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdSystemManage_ItemClick);
         // 
         // bsiTheme
         // 
         this.bsiTheme.Caption = "<no theme>";
         this.bsiTheme.Id = 5;
         this.bsiTheme.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_THEME_16;
         this.bsiTheme.Name = "bsiTheme";
         // 
         // bsiSystem
         // 
         this.bsiSystem.Caption = "<no system>";
         this.bsiSystem.Id = 6;
         this.bsiSystem.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEM_16;
         this.bsiSystem.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEM_32;
         this.bsiSystem.Name = "bsiSystem";
         // 
         // chkOptionsManualSensorAllowed
         // 
         this.chkOptionsManualSensorAllowed.Caption = "Manual sensor activation";
         this.chkOptionsManualSensorAllowed.Id = 11;
         this.chkOptionsManualSensorAllowed.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.lightning_go_16;
         this.chkOptionsManualSensorAllowed.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.lightning_go;
         this.chkOptionsManualSensorAllowed.Name = "chkOptionsManualSensorAllowed";
         // 
         // chkOptionsExecuteActions
         // 
         this.chkOptionsExecuteActions.Caption = "Activate block actions";
         this.chkOptionsExecuteActions.Id = 12;
         this.chkOptionsExecuteActions.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ACTION_RUN_16;
         this.chkOptionsExecuteActions.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ACTION_RUN_32;
         this.chkOptionsExecuteActions.Name = "chkOptionsExecuteActions";
         // 
         // cmdCtrlEmergencyStop
         // 
         this.cmdCtrlEmergencyStop.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
         this.cmdCtrlEmergencyStop.Caption = "Stop trains";
         this.cmdCtrlEmergencyStop.Id = 13;
         this.cmdCtrlEmergencyStop.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.exclamation_16;
         this.cmdCtrlEmergencyStop.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.exclamation;
         this.cmdCtrlEmergencyStop.Name = "cmdCtrlEmergencyStop";
         this.cmdCtrlEmergencyStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdCtrlEmergencyStop_ItemClick);
         // 
         // bbgOptions
         // 
         this.bbgOptions.Caption = "Options";
         this.bbgOptions.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
         this.bbgOptions.Id = 16;
         this.bbgOptions.ItemLinks.Add(this.chkOptionsManualSensorAllowed);
         this.bbgOptions.ItemLinks.Add(this.chkOptionsExecuteActions);
         this.bbgOptions.Name = "bbgOptions";
         // 
         // cmdUtilsDigitalAddressCalculator
         // 
         this.cmdUtilsDigitalAddressCalculator.Caption = "Digital address calculator";
         this.cmdUtilsDigitalAddressCalculator.Id = 17;
         this.cmdUtilsDigitalAddressCalculator.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_CALCULATOR_16;
         this.cmdUtilsDigitalAddressCalculator.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_CALCULATOR_32;
         this.cmdUtilsDigitalAddressCalculator.Name = "cmdUtilsDigitalAddressCalculator";
         this.cmdUtilsDigitalAddressCalculator.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
         this.cmdUtilsDigitalAddressCalculator.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdUtilsDigitalAddressCalculator_ItemClick);
         // 
         // cmdSystemDisconnect
         // 
         this.cmdSystemDisconnect.Caption = "Disconnect";
         this.cmdSystemDisconnect.Enabled = false;
         this.cmdSystemDisconnect.Id = 18;
         this.cmdSystemDisconnect.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEMS_UNSELECTED_16;
         this.cmdSystemDisconnect.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.server_delete_32;
         this.cmdSystemDisconnect.Name = "cmdSystemDisconnect";
         this.cmdSystemDisconnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdSystemDisconnect_ItemClick);
         // 
         // cmdSystemConnect
         // 
         this.cmdSystemConnect.Caption = "Connect";
         this.cmdSystemConnect.Id = 19;
         this.cmdSystemConnect.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEM_CONNECT_16;
         this.cmdSystemConnect.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEM_CONNECT_32;
         this.cmdSystemConnect.Name = "cmdSystemConnect";
         this.cmdSystemConnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdSystemConnect_ItemClick);
         // 
         // cmdCtrlResumeOps
         // 
         this.cmdCtrlResumeOps.Caption = "Resume operations";
         this.cmdCtrlResumeOps.Enabled = false;
         this.cmdCtrlResumeOps.Id = 21;
         this.cmdCtrlResumeOps.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.control_play_blue_16;
         this.cmdCtrlResumeOps.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.control_play_blue_32;
         this.cmdCtrlResumeOps.Name = "cmdCtrlResumeOps";
         this.cmdCtrlResumeOps.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdCtrlResumeOps_ItemClick);
         // 
         // rptControl
         // 
         this.rptControl.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgSystem,
            this.rpgControl,
            this.rpgUtils});
         this.rptControl.Name = "rptControl";
         this.rptControl.Text = "Control";
         // 
         // rpgSystem
         // 
         this.rpgSystem.ItemLinks.Add(this.cmdSystemManage, true);
         this.rpgSystem.ItemLinks.Add(this.cmdSystemSettings);
         this.rpgSystem.ItemLinks.Add(this.cmdSystemConnect);
         this.rpgSystem.ItemLinks.Add(this.cmdSystemDisconnect);
         this.rpgSystem.Name = "rpgSystem";
         this.rpgSystem.ShowCaptionButton = false;
         this.rpgSystem.Text = "Digital system";
         // 
         // rpgControl
         // 
         this.rpgControl.Enabled = false;
         this.rpgControl.ItemLinks.Add(this.cmdCtrlEmergencyStop);
         this.rpgControl.ItemLinks.Add(this.cmdCtrlResumeOps);
         this.rpgControl.ItemLinks.Add(this.bbgOptions, true);
         this.rpgControl.Name = "rpgControl";
         this.rpgControl.ShowCaptionButton = false;
         this.rpgControl.Text = "Control";
         // 
         // rpgUtils
         // 
         this.rpgUtils.ItemLinks.Add(this.cmdUtilsDigitalAddressCalculator);
         this.rpgUtils.Name = "rpgUtils";
         this.rpgUtils.ShowCaptionButton = false;
         this.rpgUtils.Text = "Tools";
         // 
         // repositoryItemImageComboBox1
         // 
         this.repositoryItemImageComboBox1.AutoHeight = false;
         this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
         // 
         // ribbonStatusBar
         // 
         this.ribbonStatusBar.ItemLinks.Add(this.bsiSystem);
         this.ribbonStatusBar.ItemLinks.Add(this.bsiTheme);
         this.ribbonStatusBar.Location = new System.Drawing.Point(0, 466);
         this.ribbonStatusBar.Name = "ribbonStatusBar";
         this.ribbonStatusBar.Ribbon = this.ribbonControl;
         this.ribbonStatusBar.Size = new System.Drawing.Size(837, 31);
         // 
         // pnlContainer
         // 
         this.pnlContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
         this.pnlContainer.Controls.Add(this.tabPanels);
         this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlContainer.Location = new System.Drawing.Point(0, 143);
         this.pnlContainer.Name = "pnlContainer";
         this.pnlContainer.Padding = new System.Windows.Forms.Padding(5);
         this.pnlContainer.Size = new System.Drawing.Size(837, 323);
         this.pnlContainer.TabIndex = 5;
         // 
         // tabPanels
         // 
         this.tabPanels.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabPanels.Location = new System.Drawing.Point(5, 5);
         this.tabPanels.Name = "tabPanels";
         this.tabPanels.SelectedTabPage = this.tabPanel1;
         this.tabPanels.Size = new System.Drawing.Size(827, 313);
         this.tabPanels.TabIndex = 3;
         this.tabPanels.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPanel1});
         // 
         // tabPanel1
         // 
         this.tabPanel1.Name = "tabPanel1";
         this.tabPanel1.Padding = new System.Windows.Forms.Padding(5);
         this.tabPanel1.Size = new System.Drawing.Size(821, 285);
         this.tabPanel1.Text = "Page1";
         // 
         // ControlModule
         // 
         this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(837, 497);
         this.Controls.Add(this.pnlContainer);
         this.Controls.Add(this.ribbonStatusBar);
         this.Controls.Add(this.ribbonControl);
         this.Name = "ControlModule";
         this.Ribbon = this.ribbonControl;
         this.StatusBar = this.ribbonStatusBar;
         this.Text = "Layout control";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ControlModule_FormClosed);
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).EndInit();
         this.pnlContainer.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.tabPanels)).EndInit();
         this.tabPanels.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
      private DevExpress.XtraBars.Ribbon.RibbonPage rptControl;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSystem;
      private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
      private DevExpress.XtraEditors.PanelControl pnlContainer;
      private DevExpress.XtraTab.XtraTabControl tabPanels;
      private DevExpress.XtraTab.XtraTabPage tabPanel1;
      private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
      private DevExpress.XtraBars.BarButtonItem cmdSystemSettings;
      private DevExpress.XtraBars.BarButtonItem cmdSystemManage;
      private DevExpress.XtraBars.BarStaticItem bsiTheme;
      private DevExpress.XtraBars.BarStaticItem bsiSystem;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgControl;
      private DevExpress.XtraBars.BarCheckItem chkOptionsManualSensorAllowed;
      private DevExpress.XtraBars.BarCheckItem chkOptionsExecuteActions;
      private DevExpress.XtraBars.BarButtonItem cmdCtrlEmergencyStop;
      private DevExpress.XtraBars.BarButtonGroup bbgOptions;
        private DevExpress.XtraBars.BarButtonItem cmdUtilsDigitalAddressCalculator;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgUtils;
        private DevExpress.XtraBars.BarButtonItem cmdSystemDisconnect;
        private DevExpress.XtraBars.BarButtonItem cmdSystemConnect;
        private DevExpress.XtraBars.BarButtonItem cmdCtrlResumeOps;
    }
}

