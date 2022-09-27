namespace Rwm.Studio.Plugins.Designer.Modules
{
   partial class DecoderManagerModule
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DecoderManagerModule));
         this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.cmdDeviceEdit = new DevExpress.XtraBars.BarButtonItem();
         this.cmdDeviceDelete = new DevExpress.XtraBars.BarButtonItem();
         this.barLinkContainerItem1 = new DevExpress.XtraBars.BarLinkContainerItem();
         this.cmdAccessoryDecoderAdd = new DevExpress.XtraBars.BarButtonItem();
         this.cmdDeviceAddGenericFb = new DevExpress.XtraBars.BarButtonItem();
         this.cmdDeviceAddRwmAcc = new DevExpress.XtraBars.BarButtonItem();
         this.cmdDeviceAddRwmeMotion = new DevExpress.XtraBars.BarButtonItem();
         this.cmdViewByType = new DevExpress.XtraBars.BarCheckItem();
         this.cmdViewByArea = new DevExpress.XtraBars.BarCheckItem();
         this.cmdRefreshView = new DevExpress.XtraBars.BarButtonItem();
         this.bsiElementCounter = new DevExpress.XtraBars.BarStaticItem();
         this.cmdDecoderProgram = new DevExpress.XtraBars.BarButtonItem();
         this.cmdModuleAdd = new DevExpress.XtraBars.BarButtonItem();
         this.rbpData = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.rpgModules = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.rpgDecoders = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.rpgView = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.imlIcons = new System.Windows.Forms.ImageList(this.components);
         this.tlsDecoders = new DevExpress.XtraTreeList.TreeList();
         ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tlsDecoders)).BeginInit();
         this.SuspendLayout();
         // 
         // ribbon
         // 
         this.ribbon.ExpandCollapseItem.Id = 0;
         this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.cmdDeviceEdit,
            this.cmdDeviceDelete,
            this.barLinkContainerItem1,
            this.cmdDeviceAddRwmAcc,
            this.cmdDeviceAddGenericFb,
            this.cmdViewByType,
            this.cmdViewByArea,
            this.cmdRefreshView,
            this.bsiElementCounter,
            this.cmdDecoderProgram,
            this.cmdAccessoryDecoderAdd,
            this.cmdDeviceAddRwmeMotion,
            this.cmdModuleAdd});
         this.ribbon.Location = new System.Drawing.Point(0, 0);
         this.ribbon.MaxItemId = 48;
         this.ribbon.Name = "ribbon";
         this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpData});
         this.ribbon.Size = new System.Drawing.Size(920, 143);
         this.ribbon.StatusBar = this.ribbonStatusBar;
         // 
         // cmdDeviceEdit
         // 
         this.cmdDeviceEdit.Caption = "Edit";
         this.cmdDeviceEdit.Id = 16;
         this.cmdDeviceEdit.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_DATA_EDIT_16;
         this.cmdDeviceEdit.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_DEVICE_EDIT_32;
         this.cmdDeviceEdit.Name = "cmdDeviceEdit";
         this.cmdDeviceEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
         this.cmdDeviceEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdDeviceEdit_ItemClick);
         // 
         // cmdDeviceDelete
         // 
         this.cmdDeviceDelete.Caption = "Delete";
         this.cmdDeviceDelete.Id = 17;
         this.cmdDeviceDelete.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_DATA_DELETE_16;
         this.cmdDeviceDelete.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_DEVICE_DELETE_32;
         this.cmdDeviceDelete.Name = "cmdDeviceDelete";
         this.cmdDeviceDelete.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
         this.cmdDeviceDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdDeviceDelete_ItemClick);
         // 
         // barLinkContainerItem1
         // 
         this.barLinkContainerItem1.Caption = "New device";
         this.barLinkContainerItem1.Id = 25;
         this.barLinkContainerItem1.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_DEVICE_ADD_32;
         this.barLinkContainerItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdAccessoryDecoderAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdDeviceAddGenericFb),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdDeviceAddRwmAcc, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdDeviceAddRwmeMotion)});
         this.barLinkContainerItem1.Name = "barLinkContainerItem1";
         // 
         // cmdAccessoryDecoderAdd
         // 
         this.cmdAccessoryDecoderAdd.Caption = "Generic accessory decoder";
         this.cmdAccessoryDecoderAdd.Id = 43;
         this.cmdAccessoryDecoderAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmdAccessoryDecoderAdd.ImageOptions.Image")));
         this.cmdAccessoryDecoderAdd.Name = "cmdAccessoryDecoderAdd";
         this.cmdAccessoryDecoderAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdAccessoryDecoderAdd_ItemClick);
         // 
         // cmdDeviceAddGenericFb
         // 
         this.cmdDeviceAddGenericFb.Caption = "Generic feedback encoder";
         this.cmdDeviceAddGenericFb.Id = 28;
         this.cmdDeviceAddGenericFb.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmdDeviceAddGenericFb.ImageOptions.Image")));
         this.cmdDeviceAddGenericFb.Name = "cmdDeviceAddGenericFb";
         this.cmdDeviceAddGenericFb.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdDeviceAddGenericFb_ItemClick);
         // 
         // cmdDeviceAddRwmAcc
         // 
         this.cmdDeviceAddRwmAcc.Caption = "RWM EasyConnect decoder";
         this.cmdDeviceAddRwmAcc.Id = 27;
         this.cmdDeviceAddRwmAcc.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_ARDUINO_16;
         this.cmdDeviceAddRwmAcc.Name = "cmdDeviceAddRwmAcc";
         this.cmdDeviceAddRwmAcc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdDeviceAddRwmAcc_ItemClick);
         // 
         // cmdDeviceAddRwmeMotion
         // 
         this.cmdDeviceAddRwmeMotion.Caption = "RWM EasyConnect eMotion";
         this.cmdDeviceAddRwmeMotion.Id = 44;
         this.cmdDeviceAddRwmeMotion.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_ARDUINO_16;
         this.cmdDeviceAddRwmeMotion.Name = "cmdDeviceAddRwmeMotion";
         this.cmdDeviceAddRwmeMotion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdDeviceAddRwmeMotion_ItemClick);
         // 
         // cmdViewByType
         // 
         this.cmdViewByType.BindableChecked = true;
         this.cmdViewByType.Caption = "Group by type";
         this.cmdViewByType.Checked = true;
         this.cmdViewByType.GroupIndex = 1;
         this.cmdViewByType.Id = 31;
         this.cmdViewByType.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_DEVICE_16;
         this.cmdViewByType.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_DEVICE_32;
         this.cmdViewByType.Name = "cmdViewByType";
         this.cmdViewByType.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
         // 
         // cmdViewByArea
         // 
         this.cmdViewByArea.Caption = "Group by module";
         this.cmdViewByArea.GroupIndex = 1;
         this.cmdViewByArea.Id = 33;
         this.cmdViewByArea.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmdViewByArea.ImageOptions.Image")));
         this.cmdViewByArea.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("cmdViewByArea.ImageOptions.LargeImage")));
         this.cmdViewByArea.Name = "cmdViewByArea";
         this.cmdViewByArea.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
         // 
         // cmdRefreshView
         // 
         this.cmdRefreshView.Caption = "Refresh";
         this.cmdRefreshView.Id = 34;
         this.cmdRefreshView.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_REFRESH_16;
         this.cmdRefreshView.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_REFRESH_32;
         this.cmdRefreshView.Name = "cmdRefreshView";
         this.cmdRefreshView.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
         this.cmdRefreshView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdRefreshView_ItemClick);
         // 
         // bsiElementCounter
         // 
         this.bsiElementCounter.Caption = "0 devices";
         this.bsiElementCounter.Id = 35;
         this.bsiElementCounter.Name = "bsiElementCounter";
         // 
         // cmdDecoderProgram
         // 
         this.cmdDecoderProgram.Caption = "Program";
         this.cmdDecoderProgram.Enabled = false;
         this.cmdDecoderProgram.Id = 36;
         this.cmdDecoderProgram.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_DECODER_PROGRAM_16;
         this.cmdDecoderProgram.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_DECODER_PROGRAM_32;
         this.cmdDecoderProgram.Name = "cmdDecoderProgram";
         this.cmdDecoderProgram.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdDecoderProgram_ItemClick);
         // 
         // cmdModuleAdd
         // 
         this.cmdModuleAdd.Caption = "New module";
         this.cmdModuleAdd.Id = 45;
         this.cmdModuleAdd.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_MODULE_ADD_16;
         this.cmdModuleAdd.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_MODULE_ADD_32;
         this.cmdModuleAdd.Name = "cmdModuleAdd";
         this.cmdModuleAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdModuleAdd_ItemClick);
         // 
         // rbpData
         // 
         this.rbpData.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgModules,
            this.rpgDecoders,
            this.rpgView});
         this.rbpData.Name = "rbpData";
         this.rbpData.Text = "Data";
         // 
         // rpgModules
         // 
         this.rpgModules.ItemLinks.Add(this.cmdModuleAdd);
         this.rpgModules.ItemLinks.Add(this.barLinkContainerItem1);
         this.rpgModules.ItemLinks.Add(this.cmdDeviceEdit);
         this.rpgModules.ItemLinks.Add(this.cmdDeviceDelete);
         this.rpgModules.Name = "rpgModules";
         this.rpgModules.ShowCaptionButton = false;
         this.rpgModules.Text = "Manage";
         // 
         // rpgDecoders
         // 
         this.rpgDecoders.ItemLinks.Add(this.cmdDecoderProgram, true);
         this.rpgDecoders.Name = "rpgDecoders";
         this.rpgDecoders.ShowCaptionButton = false;
         this.rpgDecoders.Text = "Decoders";
         // 
         // rpgView
         // 
         this.rpgView.ItemLinks.Add(this.cmdViewByType);
         this.rpgView.ItemLinks.Add(this.cmdViewByArea);
         this.rpgView.ItemLinks.Add(this.cmdRefreshView);
         this.rpgView.Name = "rpgView";
         this.rpgView.ShowCaptionButton = false;
         this.rpgView.Text = "View";
         // 
         // ribbonStatusBar
         // 
         this.ribbonStatusBar.ItemLinks.Add(this.bsiElementCounter);
         this.ribbonStatusBar.Location = new System.Drawing.Point(0, 537);
         this.ribbonStatusBar.Name = "ribbonStatusBar";
         this.ribbonStatusBar.Ribbon = this.ribbon;
         this.ribbonStatusBar.Size = new System.Drawing.Size(920, 31);
         // 
         // imlIcons
         // 
         this.imlIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlIcons.ImageStream")));
         this.imlIcons.TransparentColor = System.Drawing.Color.Transparent;
         this.imlIcons.Images.SetKeyName(0, "ICO_FOLDER");
         this.imlIcons.Images.SetKeyName(1, "ICO_DECODER_FOLDER");
         this.imlIcons.Images.SetKeyName(2, "ICO_DECODER_ACC");
         this.imlIcons.Images.SetKeyName(3, "ICO_DECODER_FB");
         this.imlIcons.Images.SetKeyName(4, "ICO_ARDUINO");
         // 
         // tlsDecoders
         // 
         this.tlsDecoders.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
         this.tlsDecoders.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlsDecoders.Location = new System.Drawing.Point(0, 143);
         this.tlsDecoders.Name = "tlsDecoders";
         this.tlsDecoders.OptionsBehavior.Editable = false;
         this.tlsDecoders.OptionsBehavior.ReadOnly = true;
         this.tlsDecoders.OptionsCustomization.AllowBandMoving = false;
         this.tlsDecoders.OptionsCustomization.AllowBandResizing = false;
         this.tlsDecoders.OptionsLayout.AddNewColumns = false;
         this.tlsDecoders.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.tlsDecoders.OptionsView.ShowHorzLines = false;
         this.tlsDecoders.OptionsView.ShowIndicator = false;
         this.tlsDecoders.OptionsView.ShowVertLines = false;
         this.tlsDecoders.Size = new System.Drawing.Size(920, 394);
         this.tlsDecoders.StateImageList = this.imlIcons;
         this.tlsDecoders.TabIndex = 0;
         this.tlsDecoders.Click += new System.EventHandler(this.TlsDecoders_Click);
         this.tlsDecoders.DoubleClick += new System.EventHandler(this.TlsDecoders_DoubleClick);
         // 
         // DecoderManagerModule
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(920, 568);
         this.Controls.Add(this.tlsDecoders);
         this.Controls.Add(this.ribbonStatusBar);
         this.Controls.Add(this.ribbon);
         this.Name = "DecoderManagerModule";
         this.Ribbon = this.ribbon;
         this.StatusBar = this.ribbonStatusBar;
         this.Text = "Digital device manager";
         ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tlsDecoders)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
      private DevExpress.XtraBars.Ribbon.RibbonPage rbpData;
      private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgDecoders;
      private DevExpress.XtraBars.BarButtonItem cmdDeviceEdit;
      private DevExpress.XtraBars.BarButtonItem cmdDeviceDelete;
      private System.Windows.Forms.ImageList imlIcons;
      private DevExpress.XtraTreeList.TreeList tlsDecoders;
      private DevExpress.XtraBars.BarLinkContainerItem barLinkContainerItem1;
      private DevExpress.XtraBars.BarButtonItem cmdDeviceAddRwmAcc;
      private DevExpress.XtraBars.BarButtonItem cmdDeviceAddGenericFb;
      private DevExpress.XtraBars.BarCheckItem cmdViewByType;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgView;
      private DevExpress.XtraBars.BarCheckItem cmdViewByArea;
      private DevExpress.XtraBars.BarButtonItem cmdRefreshView;
      private DevExpress.XtraBars.BarStaticItem bsiElementCounter;
      private DevExpress.XtraBars.BarButtonItem cmdDecoderProgram;
      private DevExpress.XtraBars.BarButtonItem cmdAccessoryDecoderAdd;
      private DevExpress.XtraBars.BarButtonItem cmdDeviceAddRwmeMotion;
      private DevExpress.XtraBars.BarButtonItem cmdModuleAdd;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgModules;
   }
}