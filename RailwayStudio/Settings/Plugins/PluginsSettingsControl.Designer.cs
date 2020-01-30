namespace Rwm.Studio.Settings.Plugins
{
   partial class PluginsSettingsControl
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginsSettingsControl));
         DevExpress.Utils.ContextButton contextButton1 = new DevExpress.Utils.ContextButton();
         DevExpress.Utils.ContextButton contextButton2 = new DevExpress.Utils.ContextButton();
         DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup1 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
         DevExpress.XtraBars.Ribbon.GalleryItem galleryItem1 = new DevExpress.XtraBars.Ribbon.GalleryItem();
         DevExpress.XtraBars.Ribbon.GalleryItem galleryItem2 = new DevExpress.XtraBars.Ribbon.GalleryItem();
         this.imlIcons = new DevExpress.Utils.ImageCollection(this.components);
         this.lblTitle = new DevExpress.XtraEditors.LabelControl();
         this.barManager = new DevExpress.XtraBars.BarManager(this.components);
         this.tbrPlugins = new DevExpress.XtraBars.Bar();
         this.cmdPluginAdd = new DevExpress.XtraBars.BarButtonItem();
         this.cmdPluginEdit = new DevExpress.XtraBars.BarButtonItem();
         this.cmdPluginDelete = new DevExpress.XtraBars.BarButtonItem();
         this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.gcPlugins = new DevExpress.XtraBars.Ribbon.GalleryControl();
         this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
         ((System.ComponentModel.ISupportInitialize)(this.imlIcons)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gcPlugins)).BeginInit();
         this.gcPlugins.SuspendLayout();
         this.SuspendLayout();
         // 
         // imlIcons
         // 
         this.imlIcons.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imlIcons.ImageStream")));
         // 
         // lblTitle
         // 
         this.lblTitle.Appearance.FontSizeDelta = 3;
         this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
         this.lblTitle.Location = new System.Drawing.Point(10, 10);
         this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
         this.lblTitle.Name = "lblTitle";
         this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
         this.lblTitle.Size = new System.Drawing.Size(43, 33);
         this.lblTitle.TabIndex = 1;
         this.lblTitle.Text = "Plugins";
         // 
         // barManager
         // 
         this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.tbrPlugins});
         this.barManager.DockControls.Add(this.barDockControlTop);
         this.barManager.DockControls.Add(this.barDockControlBottom);
         this.barManager.DockControls.Add(this.barDockControlLeft);
         this.barManager.DockControls.Add(this.barDockControlRight);
         this.barManager.DockControls.Add(this.standaloneBarDockControl1);
         this.barManager.Form = this;
         this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.cmdPluginAdd,
            this.cmdPluginEdit,
            this.cmdPluginDelete});
         this.barManager.MaxItemId = 3;
         // 
         // tbrPlugins
         // 
         this.tbrPlugins.BarName = "Plugins";
         this.tbrPlugins.DockCol = 0;
         this.tbrPlugins.DockRow = 0;
         this.tbrPlugins.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
         this.tbrPlugins.FloatLocation = new System.Drawing.Point(1436, 150);
         this.tbrPlugins.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdPluginAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdPluginEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdPluginDelete)});
         this.tbrPlugins.OptionsBar.AllowQuickCustomization = false;
         this.tbrPlugins.OptionsBar.AllowRename = true;
         this.tbrPlugins.OptionsBar.DisableClose = true;
         this.tbrPlugins.OptionsBar.DisableCustomization = true;
         this.tbrPlugins.OptionsBar.DrawBorder = false;
         this.tbrPlugins.OptionsBar.UseWholeRow = true;
         this.tbrPlugins.StandaloneBarDockControl = this.standaloneBarDockControl1;
         this.tbrPlugins.Text = "Plugins";
         // 
         // cmdPluginAdd
         // 
         this.cmdPluginAdd.Caption = "Register plugin";
         this.cmdPluginAdd.Glyph = global::Rwm.Studio.Properties.Resources.ICO_PLUGIN_ADD_16;
         this.cmdPluginAdd.Id = 0;
         this.cmdPluginAdd.LargeGlyph = global::Rwm.Studio.Properties.Resources.ICO_PLUGIN_ADD_32;
         this.cmdPluginAdd.Name = "cmdPluginAdd";
         this.cmdPluginAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdPluginAdd_ItemClick);
         // 
         // cmdPluginEdit
         // 
         this.cmdPluginEdit.Caption = "Edit plugin properties";
         this.cmdPluginEdit.Glyph = global::Rwm.Studio.Properties.Resources.ICO_PLUGIN_EDIT_16;
         this.cmdPluginEdit.Id = 1;
         this.cmdPluginEdit.LargeGlyph = global::Rwm.Studio.Properties.Resources.ICO_PLUGIN_EDIT_32;
         this.cmdPluginEdit.Name = "cmdPluginEdit";
         // 
         // cmdPluginDelete
         // 
         this.cmdPluginDelete.Caption = "Delete plugin";
         this.cmdPluginDelete.Glyph = global::Rwm.Studio.Properties.Resources.ICO_PLUGIN_DELETE_16;
         this.cmdPluginDelete.Id = 2;
         this.cmdPluginDelete.LargeGlyph = global::Rwm.Studio.Properties.Resources.ICO_PLUGIN_DELETE_32;
         this.cmdPluginDelete.Name = "cmdPluginDelete";
         // 
         // standaloneBarDockControl1
         // 
         this.standaloneBarDockControl1.CausesValidation = false;
         this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
         this.standaloneBarDockControl1.Location = new System.Drawing.Point(10, 43);
         this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
         this.standaloneBarDockControl1.Size = new System.Drawing.Size(615, 31);
         this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(10, 10);
         this.barDockControlTop.Size = new System.Drawing.Size(615, 0);
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point(10, 515);
         this.barDockControlBottom.Size = new System.Drawing.Size(615, 0);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(10, 10);
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 505);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(625, 10);
         this.barDockControlRight.Size = new System.Drawing.Size(0, 505);
         // 
         // gcPlugins
         // 
         this.gcPlugins.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
         this.gcPlugins.Controls.Add(this.galleryControlClient1);
         this.gcPlugins.DesignGalleryGroupIndex = 0;
         this.gcPlugins.DesignGalleryItemIndex = 0;
         // 
         // 
         // 
         this.gcPlugins.Gallery.AllowFilter = false;
         this.gcPlugins.Gallery.ContextButtonOptions.TopPanelPadding = new System.Windows.Forms.Padding(5, 5, -240, 5);
         contextButton1.Alignment = DevExpress.Utils.ContextItemAlignment.TopFar;
         contextButton1.Glyph = global::Rwm.Studio.Properties.Resources.ICO_EDIT_16;
         contextButton1.Id = new System.Guid("4b04d652-5480-4936-8e66-e98c02b8a9b8");
         contextButton1.Name = "cbEdit";
         contextButton2.Alignment = DevExpress.Utils.ContextItemAlignment.TopFar;
         contextButton2.Glyph = global::Rwm.Studio.Properties.Resources.cross;
         contextButton2.Id = new System.Guid("210e500a-3827-4eff-997e-3a22b9aadf60");
         contextButton2.Name = "cbDelete";
         this.gcPlugins.Gallery.ContextButtons.Add(contextButton1);
         this.gcPlugins.Gallery.ContextButtons.Add(contextButton2);
         galleryItemGroup1.Caption = "Group1";
         galleryItem1.Caption = "Railway Collection";
         galleryItem1.Description = "A model collection manager.";
         galleryItem1.Image = ((System.Drawing.Image)(resources.GetObject("galleryItem1.Image")));
         galleryItem2.Caption = "Item2";
         galleryItemGroup1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            galleryItem1,
            galleryItem2});
         this.gcPlugins.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup1});
         this.gcPlugins.Gallery.ImageSize = new System.Drawing.Size(32, 32);
         this.gcPlugins.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.MiddleLeft;
         this.gcPlugins.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Left;
         this.gcPlugins.Gallery.ShowGroupCaption = false;
         this.gcPlugins.Gallery.ShowItemText = true;
         this.gcPlugins.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
         this.gcPlugins.Gallery.StretchItems = true;
         this.gcPlugins.Gallery.ContextButtonClick += new DevExpress.Utils.ContextItemClickEventHandler(this.gcPlugins_Gallery_ContextButtonClick);
         this.gcPlugins.Location = new System.Drawing.Point(16, 80);
         this.gcPlugins.Name = "gcPlugins";
         this.gcPlugins.Size = new System.Drawing.Size(292, 435);
         this.gcPlugins.TabIndex = 8;
         this.gcPlugins.Text = "galleryControl1";
         // 
         // galleryControlClient1
         // 
         this.galleryControlClient1.GalleryControl = this.gcPlugins;
         this.galleryControlClient1.Location = new System.Drawing.Point(1, 1);
         this.galleryControlClient1.Size = new System.Drawing.Size(290, 433);
         // 
         // PluginsSettingsControl
         // 
         this.Appearance.BackColor = System.Drawing.Color.Transparent;
         this.Appearance.Options.UseBackColor = true;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.gcPlugins);
         this.Controls.Add(this.standaloneBarDockControl1);
         this.Controls.Add(this.lblTitle);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.Name = "PluginsSettingsControl";
         this.Padding = new System.Windows.Forms.Padding(10);
         this.Size = new System.Drawing.Size(635, 525);
         ((System.ComponentModel.ISupportInitialize)(this.imlIcons)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gcPlugins)).EndInit();
         this.gcPlugins.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.Utils.ImageCollection imlIcons;
      private DevExpress.XtraEditors.LabelControl lblTitle;
      private DevExpress.XtraBars.BarManager barManager;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
      private DevExpress.XtraBars.Bar tbrPlugins;
      private DevExpress.XtraBars.BarButtonItem cmdPluginAdd;
      private DevExpress.XtraBars.BarButtonItem cmdPluginEdit;
      private DevExpress.XtraBars.BarButtonItem cmdPluginDelete;
      private DevExpress.XtraBars.Ribbon.GalleryControl gcPlugins;
      private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
   }
}
