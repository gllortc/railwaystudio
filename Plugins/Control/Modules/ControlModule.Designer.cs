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
         this.chkSystemConnect = new DevExpress.XtraBars.BarCheckItem();
         this.bbgOptions = new DevExpress.XtraBars.BarButtonGroup();
         this.rptControl = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.rpgSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.rpgControl = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
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
            this.chkSystemConnect,
            this.bbgOptions});
         this.ribbonControl.Location = new System.Drawing.Point(0, 0);
         this.ribbonControl.MaxItemId = 17;
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
         this.cmdSystemSettings.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEM_SETUP_16;
         this.cmdSystemSettings.Id = 2;
         this.cmdSystemSettings.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("cmdSystemSettings.LargeGlyph")));
         this.cmdSystemSettings.Name = "cmdSystemSettings";
         this.cmdSystemSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdSystemSettings_ItemClick);
         // 
         // cmdSystemManage
         // 
         this.cmdSystemManage.Caption = "Manage systems";
         this.cmdSystemManage.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEMS_16;
         this.cmdSystemManage.Id = 4;
         this.cmdSystemManage.LargeGlyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEMS_32;
         this.cmdSystemManage.Name = "cmdSystemManage";
         this.cmdSystemManage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdSystemManage_ItemClick);
         // 
         // bsiTheme
         // 
         this.bsiTheme.Caption = "<no theme>";
         this.bsiTheme.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_THEME_16;
         this.bsiTheme.Id = 5;
         this.bsiTheme.Name = "bsiTheme";
         this.bsiTheme.TextAlignment = System.Drawing.StringAlignment.Near;
         // 
         // bsiSystem
         // 
         this.bsiSystem.Caption = "<no system>";
         this.bsiSystem.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEM_16;
         this.bsiSystem.Id = 6;
         this.bsiSystem.LargeGlyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEM_32;
         this.bsiSystem.Name = "bsiSystem";
         this.bsiSystem.TextAlignment = System.Drawing.StringAlignment.Near;
         // 
         // chkOptionsManualSensorAllowed
         // 
         this.chkOptionsManualSensorAllowed.Caption = "Manual sensor activation";
         this.chkOptionsManualSensorAllowed.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.lightning_go_16;
         this.chkOptionsManualSensorAllowed.Id = 11;
         this.chkOptionsManualSensorAllowed.LargeGlyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.lightning_go;
         this.chkOptionsManualSensorAllowed.Name = "chkOptionsManualSensorAllowed";
         // 
         // chkExecuteActions
         // 
         this.chkOptionsExecuteActions.Caption = "Activate block actions";
         this.chkOptionsExecuteActions.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.cog_go_16;
         this.chkOptionsExecuteActions.Id = 12;
         this.chkOptionsExecuteActions.LargeGlyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.cog_go;
         this.chkOptionsExecuteActions.Name = "chkExecuteActions";
         // 
         // cmdCtrlEmergencyStop
         // 
         this.cmdCtrlEmergencyStop.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
         this.cmdCtrlEmergencyStop.Caption = "Emergency stop";
         this.cmdCtrlEmergencyStop.Id = 13;
         this.cmdCtrlEmergencyStop.LargeGlyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_EMERGENCY_STOP_32;
         this.cmdCtrlEmergencyStop.Name = "cmdCtrlEmergencyStop";
         this.cmdCtrlEmergencyStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdCtrlEmergencyStop_ItemClick);
         // 
         // chkSystemConnect
         // 
         this.chkSystemConnect.Caption = "Connect";
         this.chkSystemConnect.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEM_CONNECT_16;
         this.chkSystemConnect.Id = 14;
         this.chkSystemConnect.LargeGlyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SYSTEM_CONNECT_32;
         this.chkSystemConnect.Name = "chkSystemConnect";
         this.chkSystemConnect.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkSystemConnect_CheckedChanged);
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
         this.rpgSystem.ItemLinks.Add(this.chkSystemConnect, true);
         this.rpgSystem.ItemLinks.Add(this.cmdSystemSettings);
         this.rpgSystem.Name = "rpgSystem";
         this.rpgSystem.ShowCaptionButton = false;
         this.rpgSystem.Text = "Digital system";
         // 
         // rpgControl
         // 
         this.rpgControl.Enabled = false;
         this.rpgControl.ItemLinks.Add(this.cmdCtrlEmergencyStop);
         this.rpgControl.ItemLinks.Add(this.bbgOptions, true);
         this.rpgControl.Name = "rpgControl";
         this.rpgControl.ShowCaptionButton = false;
         this.rpgControl.Text = "Control";
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
      private DevExpress.XtraBars.BarCheckItem chkSystemConnect;
      private DevExpress.XtraBars.BarButtonGroup bbgOptions;
   }
}

