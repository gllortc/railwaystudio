namespace Rwm.Studio.Plugins.Collection.Modules
{
   partial class ExplorerModule
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerModule));
         this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.cmdDataAdd = new DevExpress.XtraBars.BarButtonItem();
         this.cmdDataEdit = new DevExpress.XtraBars.BarButtonItem();
         this.cmdDataDelete = new DevExpress.XtraBars.BarButtonItem();
         this.cmdPrintPreview = new DevExpress.XtraBars.BarButtonItem();
         this.cmdReportsDigitalAddresses = new DevExpress.XtraBars.BarButtonItem();
         this.rbpData = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.rpgData = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.rpgPrint = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.rpgReports = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.imlIcons = new System.Windows.Forms.ImageList(this.components);
         this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
         this.tlsFolders = new DevExpress.XtraTreeList.TreeList();
         this.grdData = new DevExpress.XtraGrid.GridControl();
         this.grdDataView = new DevExpress.XtraGrid.Views.Grid.GridView();
         ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
         this.splitContainerControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.tlsFolders)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).BeginInit();
         this.SuspendLayout();
         // 
         // ribbon
         // 
         this.ribbon.ExpandCollapseItem.Id = 0;
         this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.cmdDataAdd,
            this.cmdDataEdit,
            this.cmdDataDelete,
            this.cmdPrintPreview,
            this.cmdReportsDigitalAddresses});
         this.ribbon.Location = new System.Drawing.Point(0, 0);
         this.ribbon.MaxItemId = 24;
         this.ribbon.Name = "ribbon";
         this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpData});
         this.ribbon.Size = new System.Drawing.Size(743, 143);
         this.ribbon.StatusBar = this.ribbonStatusBar;
         // 
         // cmdDataAdd
         // 
         this.cmdDataAdd.Caption = "Add new";
         this.cmdDataAdd.Id = 15;
         this.cmdDataAdd.ImageOptions.Image = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_DATA_ADD_16;
         this.cmdDataAdd.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_DATA_ADD_32;
         this.cmdDataAdd.Name = "cmdDataAdd";
         this.cmdDataAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdDataAdd_ItemClick);
         // 
         // cmdDataEdit
         // 
         this.cmdDataEdit.Caption = "Edit";
         this.cmdDataEdit.Id = 16;
         this.cmdDataEdit.ImageOptions.Image = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_DATA_EDIT_16;
         this.cmdDataEdit.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_DATA_EDIT_32;
         this.cmdDataEdit.Name = "cmdDataEdit";
         this.cmdDataEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdDataEdit_ItemClick);
         // 
         // cmdDataDelete
         // 
         this.cmdDataDelete.Caption = "Delete";
         this.cmdDataDelete.Id = 17;
         this.cmdDataDelete.ImageOptions.Image = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_DATA_DELETE_16;
         this.cmdDataDelete.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_DATA_DELETE_32;
         this.cmdDataDelete.Name = "cmdDataDelete";
         this.cmdDataDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdDataDelete_ItemClick);
         // 
         // cmdPrintPreview
         // 
         this.cmdPrintPreview.Caption = "Export / Print";
         this.cmdPrintPreview.Id = 22;
         this.cmdPrintPreview.ImageOptions.Image = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_PRINT_16;
         this.cmdPrintPreview.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_PRINT_32;
         this.cmdPrintPreview.Name = "cmdPrintPreview";
         this.cmdPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdPrintPreview_ItemClick);
         // 
         // cmdReportsDigitalAddresses
         // 
         this.cmdReportsDigitalAddresses.Caption = "Digital addresses";
         this.cmdReportsDigitalAddresses.Id = 23;
         this.cmdReportsDigitalAddresses.ImageOptions.Image = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_REPORT_16;
         this.cmdReportsDigitalAddresses.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_REPORT_32;
         this.cmdReportsDigitalAddresses.Name = "cmdReportsDigitalAddresses";
         this.cmdReportsDigitalAddresses.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdReportsDigitalAddresses_ItemClick);
         // 
         // rbpData
         // 
         this.rbpData.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgData,
            this.rpgReports,
            this.rpgPrint});
         this.rbpData.Name = "rbpData";
         this.rbpData.Text = "Data";
         // 
         // rpgData
         // 
         this.rpgData.ItemLinks.Add(this.cmdDataAdd);
         this.rpgData.ItemLinks.Add(this.cmdDataEdit);
         this.rpgData.ItemLinks.Add(this.cmdDataDelete);
         this.rpgData.Name = "rpgData";
         this.rpgData.ShowCaptionButton = false;
         this.rpgData.Text = "Data";
         // 
         // rpgPrint
         // 
         this.rpgPrint.ItemLinks.Add(this.cmdPrintPreview);
         this.rpgPrint.Name = "rpgPrint";
         this.rpgPrint.ShowCaptionButton = false;
         this.rpgPrint.Text = "Print";
         // 
         // rpgReports
         // 
         this.rpgReports.ItemLinks.Add(this.cmdReportsDigitalAddresses);
         this.rpgReports.Name = "rpgReports";
         this.rpgReports.ShowCaptionButton = false;
         this.rpgReports.Text = "Reports";
         // 
         // ribbonStatusBar
         // 
         this.ribbonStatusBar.Location = new System.Drawing.Point(0, 539);
         this.ribbonStatusBar.Name = "ribbonStatusBar";
         this.ribbonStatusBar.Ribbon = this.ribbon;
         this.ribbonStatusBar.Size = new System.Drawing.Size(743, 31);
         // 
         // imlIcons
         // 
         this.imlIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlIcons.ImageStream")));
         this.imlIcons.TransparentColor = System.Drawing.Color.Transparent;
         this.imlIcons.Images.SetKeyName(0, "ICO_FOLDER");
         this.imlIcons.Images.SetKeyName(1, "ICO_DATA");
         this.imlIcons.Images.SetKeyName(2, "ICO_CATEGORY");
         this.imlIcons.Images.SetKeyName(3, "ICO_STORE");
         this.imlIcons.Images.SetKeyName(4, "ICO_MANUFACTURER");
         this.imlIcons.Images.SetKeyName(5, "ICO_DECODER");
         this.imlIcons.Images.SetKeyName(6, "ICO_SCALE");
         this.imlIcons.Images.SetKeyName(7, "ICO_COMPANIES");
         // 
         // splitContainerControl1
         // 
         this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainerControl1.Location = new System.Drawing.Point(0, 143);
         this.splitContainerControl1.Name = "splitContainerControl1";
         this.splitContainerControl1.Padding = new System.Windows.Forms.Padding(3);
         this.splitContainerControl1.Panel1.Controls.Add(this.tlsFolders);
         this.splitContainerControl1.Panel1.Text = "Panel1";
         this.splitContainerControl1.Panel2.Controls.Add(this.grdData);
         this.splitContainerControl1.Panel2.Text = "Panel2";
         this.splitContainerControl1.Size = new System.Drawing.Size(743, 396);
         this.splitContainerControl1.SplitterPosition = 246;
         this.splitContainerControl1.TabIndex = 3;
         this.splitContainerControl1.Text = "splitContainerControl1";
         // 
         // tlsFolders
         // 
         this.tlsFolders.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlsFolders.Location = new System.Drawing.Point(0, 0);
         this.tlsFolders.Name = "tlsFolders";
         this.tlsFolders.OptionsBehavior.Editable = false;
         this.tlsFolders.OptionsBehavior.ReadOnly = true;
         this.tlsFolders.OptionsCustomization.AllowBandMoving = false;
         this.tlsFolders.OptionsCustomization.AllowBandResizing = false;
         this.tlsFolders.OptionsLayout.AddNewColumns = false;
         this.tlsFolders.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.tlsFolders.OptionsView.ShowHorzLines = false;
         this.tlsFolders.OptionsView.ShowIndicator = false;
         this.tlsFolders.OptionsView.ShowVertLines = false;
         this.tlsFolders.Size = new System.Drawing.Size(246, 390);
         this.tlsFolders.StateImageList = this.imlIcons;
         this.tlsFolders.TabIndex = 0;
         this.tlsFolders.Click += new System.EventHandler(this.TlsFolders_Click);
         // 
         // grdData
         // 
         this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdData.Location = new System.Drawing.Point(0, 0);
         this.grdData.MainView = this.grdDataView;
         this.grdData.MenuManager = this.ribbon;
         this.grdData.Name = "grdData";
         this.grdData.Size = new System.Drawing.Size(486, 390);
         this.grdData.TabIndex = 0;
         this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDataView});
         // 
         // grdDataView
         // 
         this.grdDataView.GridControl = this.grdData;
         this.grdDataView.Name = "grdDataView";
         this.grdDataView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdDataView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdDataView.OptionsBehavior.Editable = false;
         this.grdDataView.OptionsBehavior.ReadOnly = true;
         this.grdDataView.OptionsCustomization.AllowColumnMoving = false;
         this.grdDataView.OptionsCustomization.AllowGroup = false;
         this.grdDataView.OptionsDetail.AllowZoomDetail = false;
         this.grdDataView.OptionsDetail.EnableMasterViewMode = false;
         this.grdDataView.OptionsDetail.SmartDetailExpand = false;
         this.grdDataView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdDataView.OptionsView.ColumnAutoWidth = false;
         this.grdDataView.OptionsView.ShowGroupPanel = false;
         this.grdDataView.OptionsView.ShowIndicator = false;
         this.grdDataView.DoubleClick += new System.EventHandler(this.GrdDataView_DoubleClick);
         // 
         // ExplorerModule
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(743, 570);
         this.Controls.Add(this.splitContainerControl1);
         this.Controls.Add(this.ribbonStatusBar);
         this.Controls.Add(this.ribbon);
         this.Name = "ExplorerModule";
         this.Ribbon = this.ribbon;
         this.StatusBar = this.ribbonStatusBar;
         this.Text = "Collection Data Management";
         ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
         this.splitContainerControl1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.tlsFolders)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
      private DevExpress.XtraBars.Ribbon.RibbonPage rbpData;
      private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgData;
      private DevExpress.XtraBars.BarButtonItem cmdDataAdd;
      private DevExpress.XtraBars.BarButtonItem cmdDataEdit;
      private DevExpress.XtraBars.BarButtonItem cmdDataDelete;
      private System.Windows.Forms.ImageList imlIcons;
      private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
      private DevExpress.XtraTreeList.TreeList tlsFolders;
      private DevExpress.XtraGrid.GridControl grdData;
      private DevExpress.XtraGrid.Views.Grid.GridView grdDataView;
      private DevExpress.XtraBars.BarButtonItem cmdPrintPreview;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgPrint;
        private DevExpress.XtraBars.BarButtonItem cmdReportsDigitalAddresses;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgReports;
    }
}