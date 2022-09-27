namespace Rwm.Studio.Plugins.Designer.Modules
{
   partial class TesterModule
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TesterModule));
         this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.cmdSystemSettings = new DevExpress.XtraBars.BarButtonItem();
         this.cmdSystemManage = new DevExpress.XtraBars.BarButtonItem();
         this.cmdCtrlEmergencyStop = new DevExpress.XtraBars.BarButtonItem();
         this.cmdSystemDisconnect = new DevExpress.XtraBars.BarButtonItem();
         this.cmdSystemConnect = new DevExpress.XtraBars.BarButtonItem();
         this.cmdCtrlResumeOps = new DevExpress.XtraBars.BarButtonItem();
         this.bbtnSystemsManage = new DevExpress.XtraBars.BarButtonItem();
         this.bbtnThemesManage = new DevExpress.XtraBars.BarButtonItem();
         this.rptControl = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.rpgSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.rpgControl = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.pnlContainer = new DevExpress.XtraEditors.PanelControl();
         this.tabTest = new DevExpress.XtraTab.XtraTabControl();
         this.tabTestFeedback = new DevExpress.XtraTab.XtraTabPage();
         this.feedbackTesterControl = new Rwm.Studio.Plugins.Designer.Controls.FeedbackTesterControl();
         this.tabTestAddress = new DevExpress.XtraTab.XtraTabPage();
         this.panel1 = new System.Windows.Forms.Panel();
         this.grdAddress = new DevExpress.XtraGrid.GridControl();
         this.grdAddressView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
         this.cmdAdrCalc = new DevExpress.XtraEditors.SimpleButton();
         this.txtAddress = new DevExpress.XtraEditors.SpinEdit();
         this.lblOutputs = new DevExpress.XtraEditors.LabelControl();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).BeginInit();
         this.pnlContainer.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.tabTest)).BeginInit();
         this.tabTest.SuspendLayout();
         this.tabTestFeedback.SuspendLayout();
         this.tabTestAddress.SuspendLayout();
         this.panel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdAddress)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdAddressView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
         this.panelControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // ribbonControl
         // 
         this.ribbonControl.ExpandCollapseItem.Id = 0;
         this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.cmdSystemSettings,
            this.cmdSystemManage,
            this.cmdCtrlEmergencyStop,
            this.cmdSystemDisconnect,
            this.cmdSystemConnect,
            this.cmdCtrlResumeOps,
            this.bbtnSystemsManage,
            this.bbtnThemesManage});
         this.ribbonControl.Location = new System.Drawing.Point(0, 0);
         this.ribbonControl.MaxItemId = 25;
         this.ribbonControl.Name = "ribbonControl";
         this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rptControl});
         this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
         this.ribbonControl.Size = new System.Drawing.Size(877, 143);
         this.ribbonControl.StatusBar = this.ribbonStatusBar;
         // 
         // cmdSystemSettings
         // 
         this.cmdSystemSettings.Caption = "Settings";
         this.cmdSystemSettings.Id = 2;
         this.cmdSystemSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmdSystemSettings.ImageOptions.Image")));
         this.cmdSystemSettings.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_SYSTEM_SETUP_32;
         this.cmdSystemSettings.Name = "cmdSystemSettings";
         this.cmdSystemSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdSystemSettings_ItemClick);
         // 
         // cmdSystemManage
         // 
         this.cmdSystemManage.Caption = "Manage systems";
         this.cmdSystemManage.Id = 4;
         this.cmdSystemManage.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_SYSTEMS_16;
         this.cmdSystemManage.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_SYSTEMS_32;
         this.cmdSystemManage.Name = "cmdSystemManage";
         this.cmdSystemManage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdSystemManage_ItemClick);
         // 
         // cmdCtrlEmergencyStop
         // 
         this.cmdCtrlEmergencyStop.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
         this.cmdCtrlEmergencyStop.Caption = "Stop trains";
         this.cmdCtrlEmergencyStop.Id = 13;
         this.cmdCtrlEmergencyStop.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_EXCLAMATION_16;
         this.cmdCtrlEmergencyStop.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_EXCLAMATION_32;
         this.cmdCtrlEmergencyStop.Name = "cmdCtrlEmergencyStop";
         this.cmdCtrlEmergencyStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdCtrlEmergencyStop_ItemClick);
         // 
         // cmdSystemDisconnect
         // 
         this.cmdSystemDisconnect.Caption = "Disconnect";
         this.cmdSystemDisconnect.Enabled = false;
         this.cmdSystemDisconnect.Id = 18;
         this.cmdSystemDisconnect.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_SYSTEM_DISCONNECT_16;
         this.cmdSystemDisconnect.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_SYSTEM_DISCONNECT_32;
         this.cmdSystemDisconnect.Name = "cmdSystemDisconnect";
         this.cmdSystemDisconnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdSystemDisconnect_ItemClick);
         // 
         // cmdSystemConnect
         // 
         this.cmdSystemConnect.Caption = "Connect";
         this.cmdSystemConnect.Id = 19;
         this.cmdSystemConnect.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_SYSTEM_CONNECT_16;
         this.cmdSystemConnect.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_SYSTEM_CONNECT_32;
         this.cmdSystemConnect.Name = "cmdSystemConnect";
         this.cmdSystemConnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdSystemConnect_ItemClick);
         // 
         // cmdCtrlResumeOps
         // 
         this.cmdCtrlResumeOps.Caption = "Resume operations";
         this.cmdCtrlResumeOps.Enabled = false;
         this.cmdCtrlResumeOps.Id = 21;
         this.cmdCtrlResumeOps.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_EMERGENCY_RESUME_16;
         this.cmdCtrlResumeOps.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_EMERGENCY_RESUME_32;
         this.cmdCtrlResumeOps.Name = "cmdCtrlResumeOps";
         this.cmdCtrlResumeOps.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdCtrlResumeOps_ItemClick);
         // 
         // bbtnSystemsManage
         // 
         this.bbtnSystemsManage.Caption = "<no system>";
         this.bbtnSystemsManage.Id = 22;
         this.bbtnSystemsManage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtnSystemsManage.ImageOptions.Image")));
         this.bbtnSystemsManage.Name = "bbtnSystemsManage";
         this.bbtnSystemsManage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdSystemManage_ItemClick);
         // 
         // bbtnThemesManage
         // 
         this.bbtnThemesManage.Caption = "<no theme>";
         this.bbtnThemesManage.Id = 23;
         this.bbtnThemesManage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtnThemesManage.ImageOptions.Image")));
         this.bbtnThemesManage.Name = "bbtnThemesManage";
         this.bbtnThemesManage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbtnThemesManage_ItemClick);
         // 
         // rptControl
         // 
         this.rptControl.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgSystem,
            this.rpgControl});
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
         this.rpgControl.Name = "rpgControl";
         this.rpgControl.ShowCaptionButton = false;
         this.rpgControl.Text = "Control";
         // 
         // ribbonStatusBar
         // 
         this.ribbonStatusBar.ItemLinks.Add(this.bbtnSystemsManage);
         this.ribbonStatusBar.ItemLinks.Add(this.bbtnThemesManage);
         this.ribbonStatusBar.Location = new System.Drawing.Point(0, 597);
         this.ribbonStatusBar.Name = "ribbonStatusBar";
         this.ribbonStatusBar.Ribbon = this.ribbonControl;
         this.ribbonStatusBar.Size = new System.Drawing.Size(877, 31);
         // 
         // pnlContainer
         // 
         this.pnlContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
         this.pnlContainer.Controls.Add(this.tabTest);
         this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlContainer.Location = new System.Drawing.Point(0, 143);
         this.pnlContainer.Name = "pnlContainer";
         this.pnlContainer.Padding = new System.Windows.Forms.Padding(5);
         this.pnlContainer.Size = new System.Drawing.Size(877, 454);
         this.pnlContainer.TabIndex = 5;
         // 
         // tabTest
         // 
         this.tabTest.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabTest.Location = new System.Drawing.Point(5, 5);
         this.tabTest.Name = "tabTest";
         this.tabTest.SelectedTabPage = this.tabTestFeedback;
         this.tabTest.Size = new System.Drawing.Size(867, 444);
         this.tabTest.TabIndex = 3;
         this.tabTest.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabTestFeedback,
            this.tabTestAddress});
         // 
         // tabTestFeedback
         // 
         this.tabTestFeedback.Controls.Add(this.feedbackTesterControl);
         this.tabTestFeedback.Image = ((System.Drawing.Image)(resources.GetObject("tabTestFeedback.Image")));
         this.tabTestFeedback.Name = "tabTestFeedback";
         this.tabTestFeedback.Padding = new System.Windows.Forms.Padding(5);
         this.tabTestFeedback.Size = new System.Drawing.Size(861, 413);
         this.tabTestFeedback.Text = "Feedback sensors";
         // 
         // feedbackTesterControl
         // 
         this.feedbackTesterControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.feedbackTesterControl.Location = new System.Drawing.Point(5, 5);
         this.feedbackTesterControl.Name = "feedbackTesterControl";
         this.feedbackTesterControl.Size = new System.Drawing.Size(851, 403);
         this.feedbackTesterControl.TabIndex = 0;
         // 
         // tabTestAddress
         // 
         this.tabTestAddress.Controls.Add(this.panel1);
         this.tabTestAddress.Controls.Add(this.panelControl1);
         this.tabTestAddress.Name = "tabTestAddress";
         this.tabTestAddress.Padding = new System.Windows.Forms.Padding(5);
         this.tabTestAddress.Size = new System.Drawing.Size(861, 413);
         this.tabTestAddress.Text = "Train addresses";
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.grdAddress);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel1.Location = new System.Drawing.Point(5, 58);
         this.panel1.Name = "panel1";
         this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
         this.panel1.Size = new System.Drawing.Size(851, 350);
         this.panel1.TabIndex = 3;
         // 
         // grdAddress
         // 
         this.grdAddress.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdAddress.Location = new System.Drawing.Point(0, 5);
         this.grdAddress.MainView = this.grdAddressView;
         this.grdAddress.MenuManager = this.ribbonControl;
         this.grdAddress.Name = "grdAddress";
         this.grdAddress.Size = new System.Drawing.Size(851, 345);
         this.grdAddress.TabIndex = 1;
         this.grdAddress.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdAddressView});
         // 
         // grdAddressView
         // 
         this.grdAddressView.GridControl = this.grdAddress;
         this.grdAddressView.Name = "grdAddressView";
         this.grdAddressView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdAddressView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdAddressView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
         this.grdAddressView.OptionsBehavior.AllowGroupExpandAnimation = DevExpress.Utils.DefaultBoolean.False;
         this.grdAddressView.OptionsBehavior.AllowPartialGroups = DevExpress.Utils.DefaultBoolean.False;
         this.grdAddressView.OptionsBehavior.Editable = false;
         this.grdAddressView.OptionsBehavior.ReadOnly = true;
         this.grdAddressView.OptionsCustomization.AllowColumnMoving = false;
         this.grdAddressView.OptionsCustomization.AllowColumnResizing = false;
         this.grdAddressView.OptionsCustomization.AllowFilter = false;
         this.grdAddressView.OptionsCustomization.AllowGroup = false;
         this.grdAddressView.OptionsCustomization.AllowQuickHideColumns = false;
         this.grdAddressView.OptionsDetail.AllowZoomDetail = false;
         this.grdAddressView.OptionsDetail.EnableMasterViewMode = false;
         this.grdAddressView.OptionsDetail.ShowDetailTabs = false;
         this.grdAddressView.OptionsDetail.ShowEmbeddedDetailIndent = DevExpress.Utils.DefaultBoolean.False;
         this.grdAddressView.OptionsDetail.SmartDetailExpand = false;
         this.grdAddressView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
         this.grdAddressView.OptionsFilter.AllowColumnMRUFilterList = false;
         this.grdAddressView.OptionsFilter.AllowFilterEditor = false;
         this.grdAddressView.OptionsFilter.AllowFilterIncrementalSearch = false;
         this.grdAddressView.OptionsFilter.AllowMRUFilterList = false;
         this.grdAddressView.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
         this.grdAddressView.OptionsFilter.FilterEditorUseMenuForOperandsAndOperators = false;
         this.grdAddressView.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = false;
         this.grdAddressView.OptionsFind.AllowFindPanel = false;
         this.grdAddressView.OptionsMenu.EnableColumnMenu = false;
         this.grdAddressView.OptionsMenu.EnableFooterMenu = false;
         this.grdAddressView.OptionsMenu.EnableGroupPanelMenu = false;
         this.grdAddressView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdAddressView.OptionsView.ColumnAutoWidth = false;
         this.grdAddressView.OptionsView.ShowDetailButtons = false;
         this.grdAddressView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
         this.grdAddressView.OptionsView.ShowGroupExpandCollapseButtons = false;
         this.grdAddressView.OptionsView.ShowGroupPanel = false;
         this.grdAddressView.OptionsView.ShowIndicator = false;
         // 
         // panelControl1
         // 
         this.panelControl1.Controls.Add(this.cmdAdrCalc);
         this.panelControl1.Controls.Add(this.txtAddress);
         this.panelControl1.Controls.Add(this.lblOutputs);
         this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelControl1.Location = new System.Drawing.Point(5, 5);
         this.panelControl1.Name = "panelControl1";
         this.panelControl1.Padding = new System.Windows.Forms.Padding(10);
         this.panelControl1.Size = new System.Drawing.Size(851, 53);
         this.panelControl1.TabIndex = 2;
         // 
         // cmdAdrCalc
         // 
         this.cmdAdrCalc.Location = new System.Drawing.Point(221, 15);
         this.cmdAdrCalc.Name = "cmdAdrCalc";
         this.cmdAdrCalc.Size = new System.Drawing.Size(75, 23);
         this.cmdAdrCalc.TabIndex = 10;
         this.cmdAdrCalc.Text = "Calculate";
         this.cmdAdrCalc.Click += new System.EventHandler(this.CmdAdrCalc_Click);
         // 
         // txtAddress
         // 
         this.txtAddress.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtAddress.Location = new System.Drawing.Point(128, 17);
         this.txtAddress.Name = "txtAddress";
         this.txtAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.txtAddress.Properties.IsFloatValue = false;
         this.txtAddress.Properties.Mask.EditMask = "N00";
         this.txtAddress.Properties.MaxValue = new decimal(new int[] {
            10239,
            0,
            0,
            0});
         this.txtAddress.Size = new System.Drawing.Size(87, 20);
         this.txtAddress.TabIndex = 9;
         // 
         // lblOutputs
         // 
         this.lblOutputs.Location = new System.Drawing.Point(15, 20);
         this.lblOutputs.Name = "lblOutputs";
         this.lblOutputs.Size = new System.Drawing.Size(102, 13);
         this.lblOutputs.TabIndex = 8;
         this.lblOutputs.Text = "Desired train address";
         // 
         // TesterModule
         // 
         this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(877, 628);
         this.Controls.Add(this.pnlContainer);
         this.Controls.Add(this.ribbonStatusBar);
         this.Controls.Add(this.ribbonControl);
         this.Name = "TesterModule";
         this.Ribbon = this.ribbonControl;
         this.StatusBar = this.ribbonStatusBar;
         this.Text = "Tester module";
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).EndInit();
         this.pnlContainer.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.tabTest)).EndInit();
         this.tabTest.ResumeLayout(false);
         this.tabTestFeedback.ResumeLayout(false);
         this.tabTestAddress.ResumeLayout(false);
         this.panel1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdAddress)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdAddressView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
         this.panelControl1.ResumeLayout(false);
         this.panelControl1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
      private DevExpress.XtraBars.Ribbon.RibbonPage rptControl;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSystem;
      private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
      private DevExpress.XtraEditors.PanelControl pnlContainer;
      private DevExpress.XtraTab.XtraTabControl tabTest;
      private DevExpress.XtraTab.XtraTabPage tabTestFeedback;
      private DevExpress.XtraBars.BarButtonItem cmdSystemSettings;
      private DevExpress.XtraBars.BarButtonItem cmdSystemManage;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgControl;
      private DevExpress.XtraBars.BarButtonItem cmdCtrlEmergencyStop;
      private DevExpress.XtraBars.BarButtonItem cmdSystemDisconnect;
      private DevExpress.XtraBars.BarButtonItem cmdSystemConnect;
      private DevExpress.XtraBars.BarButtonItem cmdCtrlResumeOps;
      private DevExpress.XtraBars.BarButtonItem bbtnSystemsManage;
      private DevExpress.XtraBars.BarButtonItem bbtnThemesManage;
      private Controls.FeedbackTesterControl feedbackTesterControl;
      private DevExpress.XtraTab.XtraTabPage tabTestAddress;
      private DevExpress.XtraEditors.LabelControl lblOutputs;
      private DevExpress.XtraEditors.SpinEdit txtAddress;
      private DevExpress.XtraEditors.SimpleButton cmdAdrCalc;
      private DevExpress.XtraGrid.GridControl grdAddress;
      private DevExpress.XtraGrid.Views.Grid.GridView grdAddressView;
      private System.Windows.Forms.Panel panel1;
      private DevExpress.XtraEditors.PanelControl panelControl1;
   }
}

