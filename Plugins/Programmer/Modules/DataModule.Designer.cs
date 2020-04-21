namespace Rwm.Studio.Plugins.Collection.Modules
{
   partial class DataModule
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
         this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.cmdDataManufacturers = new DevExpress.XtraBars.BarCheckItem();
         this.cmdDataStores = new DevExpress.XtraBars.BarCheckItem();
         this.cmdDataScales = new DevExpress.XtraBars.BarCheckItem();
         this.cmdDataAdd = new DevExpress.XtraBars.BarButtonItem();
         this.cmdDataEdit = new DevExpress.XtraBars.BarButtonItem();
         this.cmdDataDelete = new DevExpress.XtraBars.BarButtonItem();
         this.cmdDataDecoders = new DevExpress.XtraBars.BarCheckItem();
         this.cmdDataCategories = new DevExpress.XtraBars.BarCheckItem();
         this.cmdDataAdmins = new DevExpress.XtraBars.BarCheckItem();
         this.rbpData = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.rpgFiles = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.rpgData = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.grdData = new DevExpress.XtraGrid.GridControl();
         this.grdDataView = new DevExpress.XtraGrid.Views.Grid.GridView();
         ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).BeginInit();
         this.SuspendLayout();
         // 
         // ribbon
         // 
         this.ribbon.ExpandCollapseItem.Id = 0;
         this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.cmdDataManufacturers,
            this.cmdDataStores,
            this.cmdDataScales,
            this.cmdDataAdd,
            this.cmdDataEdit,
            this.cmdDataDelete,
            this.cmdDataDecoders,
            this.cmdDataCategories,
            this.cmdDataAdmins});
         this.ribbon.Location = new System.Drawing.Point(0, 0);
         this.ribbon.MaxItemId = 22;
         this.ribbon.Name = "ribbon";
         this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpData});
         this.ribbon.Size = new System.Drawing.Size(710, 143);
         this.ribbon.StatusBar = this.ribbonStatusBar;
         // 
         // cmdDataManufacturers
         // 
         this.cmdDataManufacturers.Caption = "Manufacturers";
         this.cmdDataManufacturers.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
         this.cmdDataManufacturers.Glyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_MANUFACTURER_16;
         this.cmdDataManufacturers.Id = 10;
         this.cmdDataManufacturers.LargeGlyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_MANUFACTURER_32;
         this.cmdDataManufacturers.Name = "cmdDataManufacturers";
         this.cmdDataManufacturers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
         this.cmdDataManufacturers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.FileCheck_ItemClick);
         // 
         // cmdDataStores
         // 
         this.cmdDataStores.Caption = "Stores";
         this.cmdDataStores.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
         this.cmdDataStores.Glyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_STORE_16;
         this.cmdDataStores.Id = 13;
         this.cmdDataStores.LargeGlyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_STORE_32;
         this.cmdDataStores.Name = "cmdDataStores";
         this.cmdDataStores.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.FileCheck_ItemClick);
         // 
         // cmdDataScales
         // 
         this.cmdDataScales.Caption = "Scales";
         this.cmdDataScales.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
         this.cmdDataScales.Glyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_SCALE_16;
         this.cmdDataScales.Id = 14;
         this.cmdDataScales.LargeGlyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_SCALE_32;
         this.cmdDataScales.Name = "cmdDataScales";
         this.cmdDataScales.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.FileCheck_ItemClick);
         // 
         // cmdDataAdd
         // 
         this.cmdDataAdd.Caption = "Add new";
         this.cmdDataAdd.Glyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_DATA_ADD_16;
         this.cmdDataAdd.Id = 15;
         this.cmdDataAdd.LargeGlyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_DATA_ADD_32;
         this.cmdDataAdd.Name = "cmdDataAdd";
         this.cmdDataAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdDataAdd_ItemClick);
         // 
         // cmdDataEdit
         // 
         this.cmdDataEdit.Caption = "Edit";
         this.cmdDataEdit.Glyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_DATA_EDIT_16;
         this.cmdDataEdit.Id = 16;
         this.cmdDataEdit.LargeGlyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_DATA_EDIT_32;
         this.cmdDataEdit.Name = "cmdDataEdit";
         this.cmdDataEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdDataEdit_ItemClick);
         // 
         // cmdDataDelete
         // 
         this.cmdDataDelete.Caption = "Delete";
         this.cmdDataDelete.Glyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_DATA_DELETE_16;
         this.cmdDataDelete.Id = 17;
         this.cmdDataDelete.LargeGlyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_DATA_DELETE_32;
         this.cmdDataDelete.Name = "cmdDataDelete";
         // 
         // cmdDataDecoders
         // 
         this.cmdDataDecoders.Caption = "Decoders";
         this.cmdDataDecoders.Glyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_DECODER_16;
         this.cmdDataDecoders.Id = 18;
         this.cmdDataDecoders.LargeGlyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.processor;
         this.cmdDataDecoders.Name = "cmdDataDecoders";
         this.cmdDataDecoders.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.FileCheck_ItemClick);
         // 
         // cmdDataCategories
         // 
         this.cmdDataCategories.Caption = "Categories";
         this.cmdDataCategories.Glyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_TAG_16;
         this.cmdDataCategories.Id = 19;
         this.cmdDataCategories.LargeGlyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_TAG_32;
         this.cmdDataCategories.Name = "cmdDataCategories";
         this.cmdDataCategories.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.FileCheck_ItemClick);
         // 
         // cmdDataAdmins
         // 
         this.cmdDataAdmins.Caption = "Administrations";
         this.cmdDataAdmins.Glyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_ADMIN_16;
         this.cmdDataAdmins.Id = 21;
         this.cmdDataAdmins.LargeGlyph = global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_ADMIN_32;
         this.cmdDataAdmins.Name = "cmdDataAdmins";
         this.cmdDataAdmins.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.FileCheck_ItemClick);
         // 
         // rbpData
         // 
         this.rbpData.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgFiles,
            this.rpgData});
         this.rbpData.Name = "rbpData";
         this.rbpData.Text = "Data";
         // 
         // rpgFiles
         // 
         this.rpgFiles.ItemLinks.Add(this.cmdDataCategories);
         this.rpgFiles.ItemLinks.Add(this.cmdDataScales);
         this.rpgFiles.ItemLinks.Add(this.cmdDataManufacturers);
         this.rpgFiles.ItemLinks.Add(this.cmdDataStores);
         this.rpgFiles.ItemLinks.Add(this.cmdDataDecoders);
         this.rpgFiles.ItemLinks.Add(this.cmdDataAdmins);
         this.rpgFiles.Name = "rpgFiles";
         this.rpgFiles.ShowCaptionButton = false;
         this.rpgFiles.Text = "Files";
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
         // ribbonStatusBar
         // 
         this.ribbonStatusBar.Location = new System.Drawing.Point(0, 463);
         this.ribbonStatusBar.Name = "ribbonStatusBar";
         this.ribbonStatusBar.Ribbon = this.ribbon;
         this.ribbonStatusBar.Size = new System.Drawing.Size(710, 31);
         // 
         // grdData
         // 
         this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdData.Location = new System.Drawing.Point(0, 143);
         this.grdData.MainView = this.grdDataView;
         this.grdData.MenuManager = this.ribbon;
         this.grdData.Name = "grdData";
         this.grdData.Size = new System.Drawing.Size(710, 320);
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
         this.grdDataView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdDataView.OptionsView.ShowGroupPanel = false;
         this.grdDataView.OptionsView.ShowIndicator = false;
         // 
         // DataModule
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(710, 494);
         this.Controls.Add(this.grdData);
         this.Controls.Add(this.ribbonStatusBar);
         this.Controls.Add(this.ribbon);
         this.Name = "DataModule";
         this.Ribbon = this.ribbon;
         this.StatusBar = this.ribbonStatusBar;
         this.Text = "Collection Data Management";
         ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
      private DevExpress.XtraBars.Ribbon.RibbonPage rbpData;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgFiles;
      private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
      private DevExpress.XtraGrid.GridControl grdData;
      private DevExpress.XtraGrid.Views.Grid.GridView grdDataView;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgData;
      private DevExpress.XtraBars.BarCheckItem cmdDataManufacturers;
      private DevExpress.XtraBars.BarCheckItem cmdDataStores;
      private DevExpress.XtraBars.BarCheckItem cmdDataScales;
      private DevExpress.XtraBars.BarButtonItem cmdDataAdd;
      private DevExpress.XtraBars.BarButtonItem cmdDataEdit;
      private DevExpress.XtraBars.BarButtonItem cmdDataDelete;
      private DevExpress.XtraBars.BarCheckItem cmdDataDecoders;
      private DevExpress.XtraBars.BarCheckItem cmdDataCategories;
      private DevExpress.XtraBars.BarCheckItem cmdDataAdmins;
   }
}