namespace Rwm.Studio.Plugins.Control.Modules
{
   partial class RouteModule
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
         DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup3 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
         DevExpress.XtraBars.Ribbon.GalleryItem galleryItem9 = new DevExpress.XtraBars.Ribbon.GalleryItem();
         DevExpress.XtraBars.Ribbon.GalleryItem galleryItem10 = new DevExpress.XtraBars.Ribbon.GalleryItem();
         DevExpress.XtraBars.Ribbon.GalleryItem galleryItem11 = new DevExpress.XtraBars.Ribbon.GalleryItem();
         DevExpress.XtraBars.Ribbon.GalleryItem galleryItem12 = new DevExpress.XtraBars.Ribbon.GalleryItem();
         DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup4 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
         DevExpress.XtraBars.Ribbon.GalleryItem galleryItem13 = new DevExpress.XtraBars.Ribbon.GalleryItem();
         DevExpress.XtraBars.Ribbon.GalleryItem galleryItem14 = new DevExpress.XtraBars.Ribbon.GalleryItem();
         DevExpress.XtraBars.Ribbon.GalleryItem galleryItem15 = new DevExpress.XtraBars.Ribbon.GalleryItem();
         DevExpress.XtraBars.Ribbon.GalleryItem galleryItem16 = new DevExpress.XtraBars.Ribbon.GalleryItem();
         this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.cmdRouteAdd = new DevExpress.XtraBars.BarButtonItem();
         this.cmdRouteEdit = new DevExpress.XtraBars.BarButtonItem();
         this.cmdRouteDelete = new DevExpress.XtraBars.BarButtonItem();
         this.ribbonGalleryBarItem1 = new DevExpress.XtraBars.RibbonGalleryBarItem();
         this.bbgBlockEditStatus = new DevExpress.XtraBars.BarButtonGroup();
         this.barBtnGroupMove = new DevExpress.XtraBars.BarButtonGroup();
         this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
         this.cmdRouteProperties = new DevExpress.XtraBars.BarButtonItem();
         this.cmdRouteSave = new DevExpress.XtraBars.BarButtonItem();
         this.cmdRouteClose = new DevExpress.XtraBars.BarButtonItem();
         this.rbpDesign = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.rpgRoutes = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.tabPanels = new DevExpress.XtraTab.XtraTabControl();
         this.tabPanel1 = new DevExpress.XtraTab.XtraTabPage();
         this.pnlContainer = new DevExpress.XtraEditors.PanelControl();
         this.grdData = new DevExpress.XtraGrid.GridControl();
         this.grdDataView = new DevExpress.XtraGrid.Views.Grid.GridView();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabPanels)).BeginInit();
         this.tabPanels.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).BeginInit();
         this.pnlContainer.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).BeginInit();
         this.SuspendLayout();
         // 
         // ribbonControl1
         // 
         this.ribbonControl1.ExpandCollapseItem.Id = 0;
         this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.cmdRouteAdd,
            this.cmdRouteEdit,
            this.cmdRouteDelete,
            this.ribbonGalleryBarItem1,
            this.bbgBlockEditStatus,
            this.barBtnGroupMove,
            this.barButtonGroup1,
            this.cmdRouteProperties,
            this.cmdRouteSave,
            this.cmdRouteClose});
         this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
         this.ribbonControl1.MaxItemId = 42;
         this.ribbonControl1.Name = "ribbonControl1";
         this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpDesign});
         this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
         this.ribbonControl1.Size = new System.Drawing.Size(808, 143);
         this.ribbonControl1.StatusBar = this.ribbonStatusBar;
         // 
         // cmdRouteAdd
         // 
         this.cmdRouteAdd.Caption = "New route";
         this.cmdRouteAdd.Id = 1;
         this.cmdRouteAdd.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_PANEL_ADD_16;
         this.cmdRouteAdd.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_PANEL_ADD_32;
         this.cmdRouteAdd.Name = "cmdRouteAdd";
         this.cmdRouteAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdRouteAdd_ItemClick);
         // 
         // cmdRouteEdit
         // 
         this.cmdRouteEdit.Caption = "Edit route";
         this.cmdRouteEdit.Id = 2;
         this.cmdRouteEdit.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_PANEL_EDIT_16;
         this.cmdRouteEdit.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_PANEL_EDIT_32;
         this.cmdRouteEdit.Name = "cmdRouteEdit";
         this.cmdRouteEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
         this.cmdRouteEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdRouteEdit_ItemClick);
         // 
         // cmdRouteDelete
         // 
         this.cmdRouteDelete.Caption = "Delete route";
         this.cmdRouteDelete.Id = 3;
         this.cmdRouteDelete.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_PANEL_DELETE_16;
         this.cmdRouteDelete.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_PANEL_DELETE_32;
         this.cmdRouteDelete.Name = "cmdRouteDelete";
         this.cmdRouteDelete.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
         this.cmdRouteDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdRouteDelete_ItemClick);
         // 
         // ribbonGalleryBarItem1
         // 
         this.ribbonGalleryBarItem1.Caption = "InplaceGallery1";
         // 
         // 
         // 
         galleryItemGroup3.Caption = "Group1";
         galleryItem9.Caption = "Item5";
         galleryItem10.Caption = "Item6";
         galleryItem11.Caption = "Item7";
         galleryItem12.Caption = "Item8";
         galleryItemGroup3.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            galleryItem9,
            galleryItem10,
            galleryItem11,
            galleryItem12});
         galleryItemGroup4.Caption = "Group2";
         galleryItem13.Caption = "Item1";
         galleryItem14.Caption = "Item2";
         galleryItem15.Caption = "Item3";
         galleryItem16.Caption = "Item4";
         galleryItemGroup4.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            galleryItem13,
            galleryItem14,
            galleryItem15,
            galleryItem16});
         this.ribbonGalleryBarItem1.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup3,
            galleryItemGroup4});
         this.ribbonGalleryBarItem1.Id = 7;
         this.ribbonGalleryBarItem1.Name = "ribbonGalleryBarItem1";
         // 
         // bbgBlockEditStatus
         // 
         this.bbgBlockEditStatus.Id = 15;
         this.bbgBlockEditStatus.Name = "bbgBlockEditStatus";
         this.bbgBlockEditStatus.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
         this.bbgBlockEditStatus.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
         // 
         // barBtnGroupMove
         // 
         this.barBtnGroupMove.Caption = "Move";
         this.barBtnGroupMove.Id = 35;
         this.barBtnGroupMove.Name = "barBtnGroupMove";
         // 
         // barButtonGroup1
         // 
         this.barButtonGroup1.Caption = "barButtonGroup1";
         this.barButtonGroup1.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
         this.barButtonGroup1.Id = 37;
         this.barButtonGroup1.Name = "barButtonGroup1";
         // 
         // cmdRouteProperties
         // 
         this.cmdRouteProperties.Caption = "Properties";
         this.cmdRouteProperties.Enabled = false;
         this.cmdRouteProperties.Id = 38;
         this.cmdRouteProperties.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_PROPERTIES_16;
         this.cmdRouteProperties.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_PROPERTIES_32;
         this.cmdRouteProperties.Name = "cmdRouteProperties";
         this.cmdRouteProperties.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdRouteProperties_ItemClick);
         // 
         // cmdRouteSave
         // 
         this.cmdRouteSave.Caption = "Save";
         this.cmdRouteSave.Enabled = false;
         this.cmdRouteSave.Id = 39;
         this.cmdRouteSave.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SAVE_16;
         this.cmdRouteSave.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SAVE_32;
         this.cmdRouteSave.Name = "cmdRouteSave";
         this.cmdRouteSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdRouteSave_ItemClick);
         // 
         // cmdRouteClose
         // 
         this.cmdRouteClose.Caption = "Back to routes list";
         this.cmdRouteClose.Enabled = false;
         this.cmdRouteClose.Id = 41;
         this.cmdRouteClose.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_16;
         this.cmdRouteClose.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_32;
         this.cmdRouteClose.Name = "cmdRouteClose";
         this.cmdRouteClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdRouteClose_ItemClick);
         // 
         // rbpDesign
         // 
         this.rbpDesign.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgRoutes});
         this.rbpDesign.Name = "rbpDesign";
         this.rbpDesign.Text = "Design";
         // 
         // rpgRoutes
         // 
         this.rpgRoutes.ItemLinks.Add(this.cmdRouteAdd);
         this.rpgRoutes.ItemLinks.Add(this.cmdRouteEdit, true);
         this.rpgRoutes.ItemLinks.Add(this.cmdRouteDelete);
         this.rpgRoutes.ItemLinks.Add(this.cmdRouteProperties, true);
         this.rpgRoutes.ItemLinks.Add(this.cmdRouteSave);
         this.rpgRoutes.ItemLinks.Add(this.cmdRouteClose, true);
         this.rpgRoutes.Name = "rpgRoutes";
         this.rpgRoutes.ShowCaptionButton = false;
         this.rpgRoutes.Text = "Routes";
         // 
         // ribbonStatusBar
         // 
         this.ribbonStatusBar.Location = new System.Drawing.Point(0, 594);
         this.ribbonStatusBar.Name = "ribbonStatusBar";
         this.ribbonStatusBar.Ribbon = this.ribbonControl1;
         this.ribbonStatusBar.Size = new System.Drawing.Size(808, 31);
         // 
         // tabPanels
         // 
         this.tabPanels.Location = new System.Drawing.Point(430, 18);
         this.tabPanels.Name = "tabPanels";
         this.tabPanels.SelectedTabPage = this.tabPanel1;
         this.tabPanels.Size = new System.Drawing.Size(350, 407);
         this.tabPanels.TabIndex = 3;
         this.tabPanels.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPanel1});
         this.tabPanels.Visible = false;
         // 
         // tabPanel1
         // 
         this.tabPanel1.Name = "tabPanel1";
         this.tabPanel1.Padding = new System.Windows.Forms.Padding(5);
         this.tabPanel1.Size = new System.Drawing.Size(344, 379);
         this.tabPanel1.Text = "Switchboards";
         // 
         // pnlContainer
         // 
         this.pnlContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
         this.pnlContainer.Controls.Add(this.grdData);
         this.pnlContainer.Controls.Add(this.tabPanels);
         this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlContainer.Location = new System.Drawing.Point(0, 143);
         this.pnlContainer.Name = "pnlContainer";
         this.pnlContainer.Padding = new System.Windows.Forms.Padding(5);
         this.pnlContainer.Size = new System.Drawing.Size(808, 451);
         this.pnlContainer.TabIndex = 4;
         // 
         // grdData
         // 
         this.grdData.Location = new System.Drawing.Point(30, 18);
         this.grdData.MainView = this.grdDataView;
         this.grdData.MenuManager = this.ribbonControl1;
         this.grdData.Name = "grdData";
         this.grdData.Size = new System.Drawing.Size(341, 402);
         this.grdData.TabIndex = 4;
         this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDataView});
         this.grdData.DoubleClick += new System.EventHandler(this.GrdData_DoubleClick);
         // 
         // grdDataView
         // 
         this.grdDataView.GridControl = this.grdData;
         this.grdDataView.Name = "grdDataView";
         this.grdDataView.OptionsBehavior.Editable = false;
         this.grdDataView.OptionsCustomization.AllowColumnMoving = false;
         this.grdDataView.OptionsCustomization.AllowFilter = false;
         this.grdDataView.OptionsCustomization.AllowGroup = false;
         this.grdDataView.OptionsDetail.AllowZoomDetail = false;
         this.grdDataView.OptionsDetail.EnableMasterViewMode = false;
         this.grdDataView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdDataView.OptionsView.ShowGroupPanel = false;
         // 
         // RouteModule
         // 
         this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(808, 625);
         this.Controls.Add(this.pnlContainer);
         this.Controls.Add(this.ribbonStatusBar);
         this.Controls.Add(this.ribbonControl1);
         this.Name = "RouteModule";
         this.Ribbon = this.ribbonControl1;
         this.StatusBar = this.ribbonStatusBar;
         this.Text = "Route designer";
         this.Load += new System.EventHandler(this.RouteModule_Load);
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabPanels)).EndInit();
         this.tabPanels.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).EndInit();
         this.pnlContainer.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
      private DevExpress.XtraBars.Ribbon.RibbonPage rbpDesign;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgRoutes;
      private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
      private DevExpress.XtraTab.XtraTabControl tabPanels;
      private DevExpress.XtraTab.XtraTabPage tabPanel1;
      private DevExpress.XtraEditors.PanelControl pnlContainer;
      private DevExpress.XtraBars.BarButtonItem cmdRouteAdd;
      private DevExpress.XtraBars.BarButtonItem cmdRouteEdit;
      private DevExpress.XtraBars.BarButtonItem cmdRouteDelete;
      private DevExpress.XtraBars.RibbonGalleryBarItem ribbonGalleryBarItem1;
      private DevExpress.XtraBars.BarButtonGroup bbgBlockEditStatus;
      private DevExpress.XtraBars.BarButtonGroup barBtnGroupMove;
      private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDataView;
      private DevExpress.XtraBars.BarButtonItem cmdRouteProperties;
      private DevExpress.XtraBars.BarButtonItem cmdRouteSave;
      private DevExpress.XtraBars.BarButtonItem cmdRouteClose;
   }
}

