﻿namespace Rwm.Studio.Views
{
   partial class MainView
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
         this.components = new System.ComponentModel.Container();
         DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Rwm.Studio.Views.SplashView), true, true);
         DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
         DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
         DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
         this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.applicationMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
         this.cmdFileSettings = new DevExpress.XtraBars.BarButtonItem();
         this.cmdFileExit = new DevExpress.XtraBars.BarButtonItem();
         this.cmdProjectsAdd = new DevExpress.XtraBars.BarButtonItem();
         this.cmdProjectsOpen = new DevExpress.XtraBars.BarButtonItem();
         this.bsiProjectInfo = new DevExpress.XtraBars.BarStaticItem();
         this.chkViewToolbox = new DevExpress.XtraBars.BarCheckItem();
         this.chkViewConsole = new DevExpress.XtraBars.BarCheckItem();
         this.cmdFileAbout = new DevExpress.XtraBars.BarButtonItem();
         this.rbpMain = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.rpgProjects = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.rpgView = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
         this.riCboProjectSelect = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
         this.hideContainerBottom = new DevExpress.XtraBars.Docking.AutoHideContainer();
         this.dockPanelConsole = new DevExpress.XtraBars.Docking.DockPanel();
         this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
         this.logConsole = new RailwayStudio.Common.Controls.ConsoleControl();
         this.dpToolbox = new DevExpress.XtraBars.Docking.DockPanel();
         this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
         this.nbcPlugins = new DevExpress.XtraNavBar.NavBarControl();
         this.docManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
         this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
         this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.riCboProjectSelect)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
         this.hideContainerBottom.SuspendLayout();
         this.dockPanelConsole.SuspendLayout();
         this.dockPanel2_Container.SuspendLayout();
         this.dpToolbox.SuspendLayout();
         this.dockPanel1_Container.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.nbcPlugins)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.docManager)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
         this.SuspendLayout();
         // 
         // splashScreenManager
         // 
         splashScreenManager.ClosingDelay = 1000;
         // 
         // ribbon
         // 
         this.ribbon.ApplicationButtonDropDownControl = this.applicationMenu;
         this.ribbon.ExpandCollapseItem.Id = 0;
         this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.cmdFileExit,
            this.cmdFileSettings,
            this.cmdProjectsAdd,
            this.cmdProjectsOpen,
            this.bsiProjectInfo,
            this.chkViewToolbox,
            this.chkViewConsole,
            this.cmdFileAbout});
         this.ribbon.Location = new System.Drawing.Point(0, 0);
         this.ribbon.MaxItemId = 1;
         this.ribbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
         this.ribbon.Name = "ribbon";
         this.ribbon.PageHeaderItemLinks.Add(this.cmdFileAbout);
         this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpMain});
         this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.riCboProjectSelect});
         this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
         this.ribbon.Size = new System.Drawing.Size(618, 144);
         this.ribbon.StatusBar = this.ribbonStatusBar;
         // 
         // applicationMenu
         // 
         this.applicationMenu.ItemLinks.Add(this.cmdFileSettings);
         this.applicationMenu.ItemLinks.Add(this.cmdFileExit, true);
         this.applicationMenu.Name = "applicationMenu";
         this.applicationMenu.Ribbon = this.ribbon;
         // 
         // cmdFileSettings
         // 
         this.cmdFileSettings.Caption = "Settings";
         this.cmdFileSettings.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
         this.cmdFileSettings.Glyph = global::Rwm.Studio.Properties.Resources.ICO_CONFIG_16;
         this.cmdFileSettings.Id = 3;
         this.cmdFileSettings.LargeGlyph = global::Rwm.Studio.Properties.Resources.ICO_CONFIG_32;
         this.cmdFileSettings.Name = "cmdFileSettings";
         this.cmdFileSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdFileSettings_ItemClick);
         // 
         // cmdFileExit
         // 
         this.cmdFileExit.Caption = "Exit";
         this.cmdFileExit.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
         this.cmdFileExit.Glyph = global::Rwm.Studio.Properties.Resources.ICO_EXIT_16;
         this.cmdFileExit.Id = 2;
         this.cmdFileExit.LargeGlyph = global::Rwm.Studio.Properties.Resources.ICO_EXIT_32;
         this.cmdFileExit.Name = "cmdFileExit";
         this.cmdFileExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdFileExit_ItemClick);
         // 
         // cmdProjectsAdd
         // 
         this.cmdProjectsAdd.Caption = "New...";
         this.cmdProjectsAdd.Glyph = global::Rwm.Studio.Properties.Resources.ICO_PROJECT_ADD_16;
         this.cmdProjectsAdd.Id = 4;
         this.cmdProjectsAdd.LargeGlyph = global::Rwm.Studio.Properties.Resources.ICO_PROJECT_ADD_32;
         this.cmdProjectsAdd.Name = "cmdProjectsAdd";
         this.cmdProjectsAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdProjectsAdd_ItemClick);
         // 
         // cmdProjectsOpen
         // 
         this.cmdProjectsOpen.Caption = "Open...";
         this.cmdProjectsOpen.Glyph = global::Rwm.Studio.Properties.Resources.ICO_FOLDER_16;
         this.cmdProjectsOpen.Id = 8;
         this.cmdProjectsOpen.LargeGlyph = global::Rwm.Studio.Properties.Resources.ICO_PROJECT_OPEN_32;
         this.cmdProjectsOpen.Name = "cmdProjectsOpen";
         this.cmdProjectsOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdProjectsOpen_ItemClick);
         // 
         // bsiProjectInfo
         // 
         this.bsiProjectInfo.Caption = "<no project>";
         this.bsiProjectInfo.Glyph = global::Rwm.Studio.Properties.Resources.ICO_PROJECT_16;
         this.bsiProjectInfo.Id = 9;
         this.bsiProjectInfo.Name = "bsiProjectInfo";
         superToolTip1.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
         toolTipTitleItem1.Appearance.Image = global::Rwm.Studio.Properties.Resources.ICO_PROJECT_16;
         toolTipTitleItem1.Appearance.Options.UseImage = true;
         toolTipTitleItem1.Image = global::Rwm.Studio.Properties.Resources.ICO_PROJECT_16;
         toolTipTitleItem1.Text = "PROVA";
         toolTipItem1.LeftIndent = 6;
         toolTipItem1.Text = "Location: <i>c:\\test\\folder\\file.dat</i>";
         superToolTip1.Items.Add(toolTipTitleItem1);
         superToolTip1.Items.Add(toolTipItem1);
         this.bsiProjectInfo.SuperTip = superToolTip1;
         this.bsiProjectInfo.TextAlignment = System.Drawing.StringAlignment.Near;
         // 
         // chkViewToolbox
         // 
         this.chkViewToolbox.Caption = "Toolbox";
         this.chkViewToolbox.Glyph = global::Rwm.Studio.Properties.Resources.ICO_SETTINGS_16;
         this.chkViewToolbox.Id = 13;
         this.chkViewToolbox.LargeGlyph = global::Rwm.Studio.Properties.Resources.ICO_SETTINGS_32;
         this.chkViewToolbox.Name = "chkViewToolbox";
         this.chkViewToolbox.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
         this.chkViewToolbox.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkViewToolbox_CheckedChanged);
         // 
         // chkViewConsole
         // 
         this.chkViewConsole.Caption = "Output";
         this.chkViewConsole.Glyph = global::Rwm.Studio.Properties.Resources.ICO_CONSOLE_16;
         this.chkViewConsole.Id = 15;
         this.chkViewConsole.LargeGlyph = global::Rwm.Studio.Properties.Resources.ICO_CONSOLE_32;
         this.chkViewConsole.Name = "chkViewConsole";
         this.chkViewConsole.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
         this.chkViewConsole.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkViewConsole_CheckedChanged);
         // 
         // cmdFileAbout
         // 
         this.cmdFileAbout.Caption = "About";
         this.cmdFileAbout.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
         this.cmdFileAbout.Glyph = global::Rwm.Studio.Properties.Resources.ICO_INFO_16;
         this.cmdFileAbout.Id = 16;
         this.cmdFileAbout.LargeGlyph = global::Rwm.Studio.Properties.Resources.ICO_INFO_32;
         this.cmdFileAbout.Name = "cmdFileAbout";
         this.cmdFileAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdFileAbout_ItemClick);
         // 
         // rbpMain
         // 
         this.rbpMain.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgProjects,
            this.rpgView});
         this.rbpMain.Name = "rbpMain";
         this.rbpMain.Text = "Inicio";
         // 
         // rpgProjects
         // 
         this.rpgProjects.ItemLinks.Add(this.cmdProjectsOpen);
         this.rpgProjects.ItemLinks.Add(this.cmdProjectsAdd);
         this.rpgProjects.Name = "rpgProjects";
         this.rpgProjects.ShowCaptionButton = false;
         this.rpgProjects.Text = "Projects";
         // 
         // rpgView
         // 
         this.rpgView.ItemLinks.Add(this.chkViewToolbox);
         this.rpgView.ItemLinks.Add(this.chkViewConsole);
         this.rpgView.Name = "rpgView";
         this.rpgView.ShowCaptionButton = false;
         this.rpgView.Text = "View";
         // 
         // repositoryItemImageComboBox1
         // 
         this.repositoryItemImageComboBox1.AutoHeight = false;
         this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
         // 
         // riCboProjectSelect
         // 
         this.riCboProjectSelect.AutoHeight = false;
         this.riCboProjectSelect.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.riCboProjectSelect.Name = "riCboProjectSelect";
         this.riCboProjectSelect.SmallImages = this.imageList;
         // 
         // imageList
         // 
         this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
         this.imageList.ImageSize = new System.Drawing.Size(16, 16);
         this.imageList.TransparentColor = System.Drawing.Color.Transparent;
         // 
         // ribbonStatusBar
         // 
         this.ribbonStatusBar.ItemLinks.Add(this.bsiProjectInfo);
         this.ribbonStatusBar.Location = new System.Drawing.Point(0, 529);
         this.ribbonStatusBar.Name = "ribbonStatusBar";
         this.ribbonStatusBar.Ribbon = this.ribbon;
         this.ribbonStatusBar.Size = new System.Drawing.Size(618, 32);
         // 
         // dockManager
         // 
         this.dockManager.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerBottom});
         this.dockManager.Form = this;
         this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpToolbox});
         this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
         // 
         // hideContainerBottom
         // 
         this.hideContainerBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
         this.hideContainerBottom.Controls.Add(this.dockPanelConsole);
         this.hideContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.hideContainerBottom.Location = new System.Drawing.Point(0, 503);
         this.hideContainerBottom.Name = "hideContainerBottom";
         this.hideContainerBottom.Size = new System.Drawing.Size(618, 26);
         // 
         // dockPanelConsole
         // 
         this.dockPanelConsole.Controls.Add(this.dockPanel2_Container);
         this.dockPanelConsole.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
         this.dockPanelConsole.ID = new System.Guid("e3257f5f-3c7c-4df0-b43e-2712c09af103");
         this.dockPanelConsole.Image = global::Rwm.Studio.Properties.Resources.ICO_CONSOLE_16;
         this.dockPanelConsole.Location = new System.Drawing.Point(0, 0);
         this.dockPanelConsole.Name = "dockPanelConsole";
         this.dockPanelConsole.OriginalSize = new System.Drawing.Size(200, 200);
         this.dockPanelConsole.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
         this.dockPanelConsole.SavedIndex = 1;
         this.dockPanelConsole.Size = new System.Drawing.Size(618, 200);
         this.dockPanelConsole.Text = "Console";
         this.dockPanelConsole.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
         this.dockPanelConsole.ClosedPanel += new DevExpress.XtraBars.Docking.DockPanelEventHandler(this.dockPanelConsole_ClosedPanel);
         this.dockPanelConsole.Collapsed += new DevExpress.XtraBars.Docking.DockPanelEventHandler(this.dockPanelConsole_ClosedPanel);
         // 
         // dockPanel2_Container
         // 
         this.dockPanel2_Container.Controls.Add(this.logConsole);
         this.dockPanel2_Container.Location = new System.Drawing.Point(4, 25);
         this.dockPanel2_Container.Name = "dockPanel2_Container";
         this.dockPanel2_Container.Size = new System.Drawing.Size(610, 171);
         this.dockPanel2_Container.TabIndex = 0;
         // 
         // logConsole
         // 
         this.logConsole.Dock = System.Windows.Forms.DockStyle.Fill;
         this.logConsole.ErrorForeColor = System.Drawing.Color.Salmon;
         this.logConsole.InformationForeColor = System.Drawing.Color.White;
         this.logConsole.Location = new System.Drawing.Point(0, 0);
         this.logConsole.MessageIndicator = ">";
         this.logConsole.Name = "logConsole";
         this.logConsole.Size = new System.Drawing.Size(610, 171);
         this.logConsole.TabIndex = 0;
         this.logConsole.WarningForeColor = System.Drawing.Color.Gold;
         // 
         // dpToolbox
         // 
         this.dpToolbox.Controls.Add(this.dockPanel1_Container);
         this.dpToolbox.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
         this.dpToolbox.ID = new System.Guid("24f9eccf-ca44-494f-b178-ef1ef5cef2df");
         this.dpToolbox.Image = global::Rwm.Studio.Properties.Resources.ICO_SETTINGS_16;
         this.dpToolbox.Location = new System.Drawing.Point(0, 144);
         this.dpToolbox.Name = "dpToolbox";
         this.dpToolbox.OriginalSize = new System.Drawing.Size(148, 200);
         this.dpToolbox.Size = new System.Drawing.Size(148, 359);
         this.dpToolbox.Text = "Toolbox";
         this.dpToolbox.ClosedPanel += new DevExpress.XtraBars.Docking.DockPanelEventHandler(this.dpToolbox_ClosedPanel);
         this.dpToolbox.Collapsed += new DevExpress.XtraBars.Docking.DockPanelEventHandler(this.dpToolbox_ClosedPanel);
         // 
         // dockPanel1_Container
         // 
         this.dockPanel1_Container.Controls.Add(this.nbcPlugins);
         this.dockPanel1_Container.Location = new System.Drawing.Point(4, 25);
         this.dockPanel1_Container.Name = "dockPanel1_Container";
         this.dockPanel1_Container.Size = new System.Drawing.Size(140, 330);
         this.dockPanel1_Container.TabIndex = 0;
         // 
         // nbcPlugins
         // 
         this.nbcPlugins.ActiveGroup = null;
         this.nbcPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
         this.nbcPlugins.Enabled = false;
         this.nbcPlugins.Location = new System.Drawing.Point(0, 0);
         this.nbcPlugins.Name = "nbcPlugins";
         this.nbcPlugins.OptionsNavPane.ExpandedWidth = 140;
         this.nbcPlugins.Size = new System.Drawing.Size(140, 330);
         this.nbcPlugins.TabIndex = 0;
         this.nbcPlugins.Text = "navBarControl1";
         // 
         // docManager
         // 
         this.docManager.MdiParent = this;
         this.docManager.MenuManager = this.ribbon;
         this.docManager.RibbonAndBarsMergeStyle = DevExpress.XtraBars.Docking2010.Views.RibbonAndBarsMergeStyle.Always;
         this.docManager.View = this.tabbedView1;
         this.docManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
         this.docManager.DocumentActivate += new DevExpress.XtraBars.Docking2010.Views.DocumentEventHandler(this.docManager_DocumentActivate);
         // 
         // tabbedView1
         // 
         this.tabbedView1.UseLoadingIndicator = DevExpress.Utils.DefaultBoolean.True;
         // 
         // defaultLookAndFeel
         // 
         this.defaultLookAndFeel.LookAndFeel.SkinName = "Office 2010 Blue";
         // 
         // MainView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(618, 561);
         this.Controls.Add(this.dpToolbox);
         this.Controls.Add(this.hideContainerBottom);
         this.Controls.Add(this.ribbonStatusBar);
         this.Controls.Add(this.ribbon);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.IsMdiContainer = true;
         this.Name = "MainView";
         this.Ribbon = this.ribbon;
         this.StatusBar = this.ribbonStatusBar;
         this.Text = "Railway Studio";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Load += new System.EventHandler(this.FrmMain_Load);
         this.Shown += new System.EventHandler(this.MainView_Shown);
         ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.riCboProjectSelect)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
         this.hideContainerBottom.ResumeLayout(false);
         this.dockPanelConsole.ResumeLayout(false);
         this.dockPanel2_Container.ResumeLayout(false);
         this.dpToolbox.ResumeLayout(false);
         this.dockPanel1_Container.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.nbcPlugins)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.docManager)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.Ribbon.RibbonPage rbpMain;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgProjects;
      private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
      private DevExpress.XtraBars.Docking2010.DocumentManager docManager;
      private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
      private DevExpress.XtraBars.Docking.DockPanel dockPanelConsole;
      private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
      private RailwayStudio.Common.Controls.ConsoleControl consoleControl;
      private DevExpress.XtraBars.Docking.DockPanel dpToolbox;
      private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
      private DevExpress.XtraNavBar.NavBarControl nbcPlugins;
      internal DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
      private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu;
      private DevExpress.XtraBars.BarButtonItem cmdFileExit;
      private DevExpress.XtraBars.BarButtonItem cmdFileSettings;
      private DevExpress.XtraBars.BarButtonItem cmdProjectsAdd;
      private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riCboProjectSelect;
      private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
      private System.Windows.Forms.ImageList imageList;
      private DevExpress.XtraBars.BarButtonItem cmdProjectsOpen;
      private DevExpress.XtraBars.BarStaticItem bsiProjectInfo;
      private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
      private DevExpress.XtraBars.BarCheckItem chkViewToolbox;
      private DevExpress.XtraBars.BarCheckItem chkViewConsole;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgView;
      private DevExpress.XtraBars.BarButtonItem cmdFileAbout;
      internal DevExpress.XtraBars.Docking.DockManager dockManager;
      private RailwayStudio.Common.Controls.ConsoleControl logConsole;
      private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerBottom;
   }
}