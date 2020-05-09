﻿namespace Rwm.Studio.Plugins.Control.Modules
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
         this.chkOptionsManualSensorAllowed = new DevExpress.XtraBars.BarCheckItem();
         this.chkOptionsExecuteActions = new DevExpress.XtraBars.BarCheckItem();
         this.cmdCtrlEmergencyStop = new DevExpress.XtraBars.BarButtonItem();
         this.bbgOptions = new DevExpress.XtraBars.BarButtonGroup();
         this.cmdUtilsDigitalAddressCalculator = new DevExpress.XtraBars.BarButtonItem();
         this.cmdSystemDisconnect = new DevExpress.XtraBars.BarButtonItem();
         this.cmdSystemConnect = new DevExpress.XtraBars.BarButtonItem();
         this.cmdCtrlResumeOps = new DevExpress.XtraBars.BarButtonItem();
         this.bbtnSystemsManage = new DevExpress.XtraBars.BarButtonItem();
         this.bbtnThemesManage = new DevExpress.XtraBars.BarButtonItem();
         this.rptControl = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.rpgSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.rpgControl = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.rpgUtils = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.pnlContainer = new DevExpress.XtraEditors.PanelControl();
         this.tabPanels = new DevExpress.XtraTab.XtraTabControl();
         this.tabPanel1 = new DevExpress.XtraTab.XtraTabPage();
         this.dockManager = new DevExpress.XtraBars.Docking.DockManager();
         this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
         this.dockPanelRoutes = new DevExpress.XtraBars.Docking.DockPanel();
         this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
         this.rmaRoutes = new Rwm.Studio.Plugins.Control.Controls.RouteManualActivatorControl();
         this.dockPanelTrains = new DevExpress.XtraBars.Docking.DockPanel();
         this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
         this.tscTrains = new Rwm.Studio.Plugins.Control.Controls.TrainSelectionControl();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).BeginInit();
         this.pnlContainer.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.tabPanels)).BeginInit();
         this.tabPanels.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
         this.hideContainerRight.SuspendLayout();
         this.dockPanelRoutes.SuspendLayout();
         this.dockPanel1_Container.SuspendLayout();
         this.dockPanelTrains.SuspendLayout();
         this.controlContainer1.SuspendLayout();
         this.SuspendLayout();
         // 
         // ribbonControl
         // 
         this.ribbonControl.ExpandCollapseItem.Id = 0;
         this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.cmdSystemSettings,
            this.cmdSystemManage,
            this.chkOptionsManualSensorAllowed,
            this.chkOptionsExecuteActions,
            this.cmdCtrlEmergencyStop,
            this.bbgOptions,
            this.cmdUtilsDigitalAddressCalculator,
            this.cmdSystemDisconnect,
            this.cmdSystemConnect,
            this.cmdCtrlResumeOps,
            this.bbtnSystemsManage,
            this.bbtnThemesManage});
         this.ribbonControl.Location = new System.Drawing.Point(0, 0);
         this.ribbonControl.MaxItemId = 24;
         this.ribbonControl.Name = "ribbonControl";
         this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rptControl});
         this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
         this.ribbonControl.Size = new System.Drawing.Size(837, 144);
         this.ribbonControl.StatusBar = this.ribbonStatusBar;
         // 
         // cmdSystemSettings
         // 
         this.cmdSystemSettings.Caption = "Settings";
         this.cmdSystemSettings.Id = 2;
         this.cmdSystemSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmdSystemSettings.ImageOptions.Image")));
         this.cmdSystemSettings.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEM_SETUP_32;
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
         this.cmdCtrlEmergencyStop.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_EXCLAMATION_16;
         this.cmdCtrlEmergencyStop.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_EXCLAMATION_32;
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
         this.cmdSystemDisconnect.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEM_DISCONNECT_16;
         this.cmdSystemDisconnect.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEM_DISCONNECT_32;
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
         this.cmdCtrlResumeOps.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_EMERGENCY_RESUME_16;
         this.cmdCtrlResumeOps.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_EMERGENCY_RESUME_32;
         this.cmdCtrlResumeOps.Name = "cmdCtrlResumeOps";
         this.cmdCtrlResumeOps.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdCtrlResumeOps_ItemClick);
         // 
         // bbtnSystemsManage
         // 
         this.bbtnSystemsManage.Caption = "<no system>";
         this.bbtnSystemsManage.Id = 22;
         this.bbtnSystemsManage.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEM_16;
         this.bbtnSystemsManage.Name = "bbtnSystemsManage";
         this.bbtnSystemsManage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdSystemManage_ItemClick);
         // 
         // bbtnThemesManage
         // 
         this.bbtnThemesManage.Caption = "<no theme>";
         this.bbtnThemesManage.Id = 23;
         this.bbtnThemesManage.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_THEME_16;
         this.bbtnThemesManage.Name = "bbtnThemesManage";
         this.bbtnThemesManage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbtnThemesManage_ItemClick);
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
         // ribbonStatusBar
         // 
         this.ribbonStatusBar.ItemLinks.Add(this.bbtnSystemsManage);
         this.ribbonStatusBar.ItemLinks.Add(this.bbtnThemesManage);
         this.ribbonStatusBar.Location = new System.Drawing.Point(0, 465);
         this.ribbonStatusBar.Name = "ribbonStatusBar";
         this.ribbonStatusBar.Ribbon = this.ribbonControl;
         this.ribbonStatusBar.Size = new System.Drawing.Size(837, 32);
         // 
         // pnlContainer
         // 
         this.pnlContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
         this.pnlContainer.Controls.Add(this.tabPanels);
         this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlContainer.Location = new System.Drawing.Point(0, 144);
         this.pnlContainer.Name = "pnlContainer";
         this.pnlContainer.Padding = new System.Windows.Forms.Padding(5);
         this.pnlContainer.Size = new System.Drawing.Size(811, 321);
         this.pnlContainer.TabIndex = 5;
         // 
         // tabPanels
         // 
         this.tabPanels.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabPanels.Location = new System.Drawing.Point(5, 5);
         this.tabPanels.Name = "tabPanels";
         this.tabPanels.SelectedTabPage = this.tabPanel1;
         this.tabPanels.Size = new System.Drawing.Size(801, 311);
         this.tabPanels.TabIndex = 3;
         this.tabPanels.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPanel1});
         // 
         // tabPanel1
         // 
         this.tabPanel1.Name = "tabPanel1";
         this.tabPanel1.Padding = new System.Windows.Forms.Padding(5);
         this.tabPanel1.Size = new System.Drawing.Size(795, 283);
         this.tabPanel1.Text = "Page1";
         // 
         // dockManager
         // 
         this.dockManager.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerRight});
         this.dockManager.Form = this;
         this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
         // 
         // hideContainerRight
         // 
         this.hideContainerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
         this.hideContainerRight.Controls.Add(this.dockPanelRoutes);
         this.hideContainerRight.Controls.Add(this.dockPanelTrains);
         this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.hideContainerRight.Location = new System.Drawing.Point(811, 144);
         this.hideContainerRight.Name = "hideContainerRight";
         this.hideContainerRight.Size = new System.Drawing.Size(26, 321);
         // 
         // dockPanelRoutes
         // 
         this.dockPanelRoutes.Controls.Add(this.dockPanel1_Container);
         this.dockPanelRoutes.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
         this.dockPanelRoutes.ID = new System.Guid("d7730765-2068-42f9-90cd-5cdd0afaff72");
         this.dockPanelRoutes.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_16;
         this.dockPanelRoutes.Location = new System.Drawing.Point(0, 0);
         this.dockPanelRoutes.Name = "dockPanelRoutes";
         this.dockPanelRoutes.OriginalSize = new System.Drawing.Size(200, 200);
         this.dockPanelRoutes.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
         this.dockPanelRoutes.SavedIndex = 0;
         this.dockPanelRoutes.SavedParent = this.dockPanelTrains;
         this.dockPanelRoutes.Size = new System.Drawing.Size(200, 321);
         this.dockPanelRoutes.Text = "Routes";
         this.dockPanelRoutes.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
         // 
         // dockPanel1_Container
         // 
         this.dockPanel1_Container.Controls.Add(this.rmaRoutes);
         this.dockPanel1_Container.Location = new System.Drawing.Point(5, 25);
         this.dockPanel1_Container.Name = "dockPanel1_Container";
         this.dockPanel1_Container.Size = new System.Drawing.Size(191, 292);
         this.dockPanel1_Container.TabIndex = 0;
         // 
         // rmaRoutes
         // 
         this.rmaRoutes.Dock = System.Windows.Forms.DockStyle.Fill;
         this.rmaRoutes.Location = new System.Drawing.Point(0, 0);
         this.rmaRoutes.Name = "rmaRoutes";
         this.rmaRoutes.Size = new System.Drawing.Size(191, 292);
         this.rmaRoutes.TabIndex = 0;
         // 
         // dockPanelTrains
         // 
         this.dockPanelTrains.Controls.Add(this.controlContainer1);
         this.dockPanelTrains.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
         this.dockPanelTrains.ID = new System.Guid("8316fd95-f956-4c38-a22d-76c29a432a48");
         this.dockPanelTrains.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_TRAIN_16;
         this.dockPanelTrains.Location = new System.Drawing.Point(0, 0);
         this.dockPanelTrains.Name = "dockPanelTrains";
         this.dockPanelTrains.OriginalSize = new System.Drawing.Size(200, 200);
         this.dockPanelTrains.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
         this.dockPanelTrains.SavedIndex = 0;
         this.dockPanelTrains.Size = new System.Drawing.Size(200, 321);
         this.dockPanelTrains.Text = "Trains";
         this.dockPanelTrains.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
         // 
         // controlContainer1
         // 
         this.controlContainer1.Controls.Add(this.tscTrains);
         this.controlContainer1.Location = new System.Drawing.Point(5, 25);
         this.controlContainer1.Name = "controlContainer1";
         this.controlContainer1.Size = new System.Drawing.Size(191, 292);
         this.controlContainer1.TabIndex = 0;
         // 
         // tscTrains
         // 
         this.tscTrains.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tscTrains.Location = new System.Drawing.Point(0, 0);
         this.tscTrains.Name = "tscTrains";
         this.tscTrains.Size = new System.Drawing.Size(191, 292);
         this.tscTrains.TabIndex = 0;
         // 
         // ControlModule
         // 
         this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(837, 497);
         this.Controls.Add(this.pnlContainer);
         this.Controls.Add(this.hideContainerRight);
         this.Controls.Add(this.ribbonStatusBar);
         this.Controls.Add(this.ribbonControl);
         this.Name = "ControlModule";
         this.Ribbon = this.ribbonControl;
         this.StatusBar = this.ribbonStatusBar;
         this.Text = "Layout control";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ControlModule_FormClosed);
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).EndInit();
         this.pnlContainer.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.tabPanels)).EndInit();
         this.tabPanels.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
         this.hideContainerRight.ResumeLayout(false);
         this.dockPanelRoutes.ResumeLayout(false);
         this.dockPanel1_Container.ResumeLayout(false);
         this.dockPanelTrains.ResumeLayout(false);
         this.controlContainer1.ResumeLayout(false);
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
      // private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
      private DevExpress.XtraBars.BarButtonItem cmdSystemSettings;
      private DevExpress.XtraBars.BarButtonItem cmdSystemManage;
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
      private DevExpress.XtraBars.BarButtonItem bbtnSystemsManage;
      private DevExpress.XtraBars.BarButtonItem bbtnThemesManage;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelRoutes;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private Controls.RouteManualActivatorControl rmaRoutes;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelTrains;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
        private Controls.TrainSelectionControl tscTrains;
    }
}

