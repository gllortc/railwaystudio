namespace Rwm.Studio.Plugins.Designer.Views
{
   partial class DecodersManagerView
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
         this.barManager = new DevExpress.XtraBars.BarManager(this.components);
         this.barSystems = new DevExpress.XtraBars.Bar();
         this.cmdDecoderAdd = new DevExpress.XtraBars.BarButtonItem();
         this.cmdDecoderEdit = new DevExpress.XtraBars.BarButtonItem();
         this.cmdDecoderDelete = new DevExpress.XtraBars.BarButtonItem();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.cmdSystemRemove = new DevExpress.XtraBars.BarButtonItem();
         this.grdAcc = new DevExpress.XtraGrid.GridControl();
         this.grdAccView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.cmdClose = new DevExpress.XtraEditors.SimpleButton();
         this.tabDecoder = new DevExpress.XtraTab.XtraTabControl();
         this.tabDecoderAcc = new DevExpress.XtraTab.XtraTabPage();
         this.tabDecoderFb = new DevExpress.XtraTab.XtraTabPage();
         this.grdFb = new DevExpress.XtraGrid.GridControl();
         this.grdFbView = new DevExpress.XtraGrid.Views.Grid.GridView();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdAcc)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdAccView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabDecoder)).BeginInit();
         this.tabDecoder.SuspendLayout();
         this.tabDecoderAcc.SuspendLayout();
         this.tabDecoderFb.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdFb)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdFbView)).BeginInit();
         this.SuspendLayout();
         // 
         // barManager
         // 
         this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barSystems});
         this.barManager.DockControls.Add(this.barDockControlTop);
         this.barManager.DockControls.Add(this.barDockControlBottom);
         this.barManager.DockControls.Add(this.barDockControlLeft);
         this.barManager.DockControls.Add(this.barDockControlRight);
         this.barManager.Form = this;
         this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.cmdDecoderAdd,
            this.cmdSystemRemove,
            this.cmdDecoderEdit,
            this.cmdDecoderDelete});
         this.barManager.MaxItemId = 5;
         // 
         // barSystems
         // 
         this.barSystems.BarName = "Systems";
         this.barSystems.DockCol = 0;
         this.barSystems.DockRow = 0;
         this.barSystems.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.barSystems.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdDecoderAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdDecoderEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdDecoderDelete)});
         this.barSystems.OptionsBar.AllowQuickCustomization = false;
         this.barSystems.OptionsBar.DisableClose = true;
         this.barSystems.OptionsBar.DisableCustomization = true;
         this.barSystems.OptionsBar.DrawDragBorder = false;
         this.barSystems.OptionsBar.UseWholeRow = true;
         this.barSystems.Text = "Systems";
         // 
         // cmdDecoderAdd
         // 
         this.cmdDecoderAdd.Caption = "Add new decoder";
         this.cmdDecoderAdd.Id = 0;
         this.cmdDecoderAdd.ImageOptions.Image = Properties.Resources.ICO_DEVICE_ADD_32;
         this.cmdDecoderAdd.ImageOptions.LargeImage = Properties.Resources.ICO_DEVICE_ADD_32;
         this.cmdDecoderAdd.Name = "cmdDecoderAdd";
         this.cmdDecoderAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdDecoderAdd_ItemClick);
         // 
         // cmdDecoderEdit
         // 
         this.cmdDecoderEdit.Caption = "Edit decoder";
         this.cmdDecoderEdit.Id = 2;
         this.cmdDecoderEdit.ImageOptions.Image = Properties.Resources.ICO_DEVICE_EDIT_32;
         this.cmdDecoderEdit.ImageOptions.LargeImage = Properties.Resources.ICO_DEVICE_EDIT_32;
         this.cmdDecoderEdit.Name = "cmdDecoderEdit";
         this.cmdDecoderEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdDecoderEdit_ItemClick);
         // 
         // cmdDecoderDelete
         // 
         this.cmdDecoderDelete.Caption = "Delete decoder";
         this.cmdDecoderDelete.Id = 3;
         this.cmdDecoderDelete.ImageOptions.Image = Properties.Resources.ICO_DEVICE_DELETE_32;
         this.cmdDecoderDelete.ImageOptions.LargeImage = Properties.Resources.ICO_DEVICE_DELETE_32;
         this.cmdDecoderDelete.Name = "cmdDecoderDelete";
         this.cmdDecoderDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdDecoderDelete_ItemClick);
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
         this.barDockControlTop.Manager = this.barManager;
         this.barDockControlTop.Size = new System.Drawing.Size(537, 47);
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point(0, 459);
         this.barDockControlBottom.Manager = this.barManager;
         this.barDockControlBottom.Size = new System.Drawing.Size(537, 0);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
         this.barDockControlLeft.Manager = this.barManager;
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 412);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(537, 47);
         this.barDockControlRight.Manager = this.barManager;
         this.barDockControlRight.Size = new System.Drawing.Size(0, 412);
         // 
         // cmdSystemRemove
         // 
         this.cmdSystemRemove.Caption = "Remove system";
         this.cmdSystemRemove.Id = 1;
         this.cmdSystemRemove.ImageOptions.Image = Properties.Resources.ICO_DECODER_DELETE_32;
         this.cmdSystemRemove.Name = "cmdSystemRemove";
         // 
         // grdAcc
         // 
         this.grdAcc.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdAcc.Location = new System.Drawing.Point(0, 0);
         this.grdAcc.MainView = this.grdAccView;
         this.grdAcc.MenuManager = this.barManager;
         this.grdAcc.Name = "grdAcc";
         this.grdAcc.Size = new System.Drawing.Size(531, 340);
         this.grdAcc.TabIndex = 5;
         this.grdAcc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdAccView});
         // 
         // grdAccView
         // 
         this.grdAccView.GridControl = this.grdAcc;
         this.grdAccView.Name = "grdAccView";
         this.grdAccView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdAccView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdAccView.OptionsBehavior.Editable = false;
         this.grdAccView.OptionsBehavior.ReadOnly = true;
         this.grdAccView.OptionsCustomization.AllowColumnMoving = false;
         this.grdAccView.OptionsCustomization.AllowColumnResizing = false;
         this.grdAccView.OptionsCustomization.AllowFilter = false;
         this.grdAccView.OptionsCustomization.AllowGroup = false;
         this.grdAccView.OptionsCustomization.AllowSort = false;
         this.grdAccView.OptionsFilter.AllowColumnMRUFilterList = false;
         this.grdAccView.OptionsFilter.AllowFilterEditor = false;
         this.grdAccView.OptionsFind.AllowFindPanel = false;
         this.grdAccView.OptionsFind.ShowClearButton = false;
         this.grdAccView.OptionsFind.ShowCloseButton = false;
         this.grdAccView.OptionsFind.ShowFindButton = false;
         this.grdAccView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdAccView.OptionsView.ShowGroupPanel = false;
         this.grdAccView.OptionsView.ShowIndicator = false;
         this.grdAccView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.GrdAccView_CustomDrawCell);
         // 
         // cmdClose
         // 
         this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdClose.Location = new System.Drawing.Point(450, 424);
         this.cmdClose.Name = "cmdClose";
         this.cmdClose.Size = new System.Drawing.Size(75, 23);
         this.cmdClose.TabIndex = 10;
         this.cmdClose.Text = "Close";
         this.cmdClose.Click += new System.EventHandler(this.CmdClose_Click);
         // 
         // tabDecoder
         // 
         this.tabDecoder.Dock = System.Windows.Forms.DockStyle.Top;
         this.tabDecoder.Location = new System.Drawing.Point(0, 47);
         this.tabDecoder.Name = "tabDecoder";
         this.tabDecoder.SelectedTabPage = this.tabDecoderAcc;
         this.tabDecoder.Size = new System.Drawing.Size(537, 371);
         this.tabDecoder.TabIndex = 15;
         this.tabDecoder.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabDecoderAcc,
            this.tabDecoderFb});
         // 
         // tabDecoderAcc
         // 
         this.tabDecoderAcc.Controls.Add(this.grdAcc);
         this.tabDecoderAcc.Image = Otc.Layout.AccessoryDecoder.SmallIcon;
         this.tabDecoderAcc.Name = "tabDecoderAcc";
         this.tabDecoderAcc.Size = new System.Drawing.Size(531, 340);
         this.tabDecoderAcc.Text = "Accessory decoders";
         // 
         // tabDecoderFb
         // 
         this.tabDecoderFb.Controls.Add(this.grdFb);
         this.tabDecoderFb.Image = Otc.Layout.FeedbackEncoder.SmallIcon;
         this.tabDecoderFb.Name = "tabDecoderFb";
         this.tabDecoderFb.Size = new System.Drawing.Size(531, 340);
         this.tabDecoderFb.Text = "Feedback encoders";
         // 
         // grdFb
         // 
         this.grdFb.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdFb.Location = new System.Drawing.Point(0, 0);
         this.grdFb.MainView = this.grdFbView;
         this.grdFb.MenuManager = this.barManager;
         this.grdFb.Name = "grdFb";
         this.grdFb.Size = new System.Drawing.Size(531, 340);
         this.grdFb.TabIndex = 6;
         this.grdFb.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdFbView});
         // 
         // grdFbView
         // 
         this.grdFbView.GridControl = this.grdFb;
         this.grdFbView.Name = "grdFbView";
         this.grdFbView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdFbView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdFbView.OptionsBehavior.Editable = false;
         this.grdFbView.OptionsBehavior.ReadOnly = true;
         this.grdFbView.OptionsCustomization.AllowColumnMoving = false;
         this.grdFbView.OptionsCustomization.AllowColumnResizing = false;
         this.grdFbView.OptionsCustomization.AllowFilter = false;
         this.grdFbView.OptionsCustomization.AllowGroup = false;
         this.grdFbView.OptionsCustomization.AllowSort = false;
         this.grdFbView.OptionsFilter.AllowColumnMRUFilterList = false;
         this.grdFbView.OptionsFilter.AllowFilterEditor = false;
         this.grdFbView.OptionsFind.AllowFindPanel = false;
         this.grdFbView.OptionsFind.ShowClearButton = false;
         this.grdFbView.OptionsFind.ShowCloseButton = false;
         this.grdFbView.OptionsFind.ShowFindButton = false;
         this.grdFbView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdFbView.OptionsView.ShowGroupPanel = false;
         this.grdFbView.OptionsView.ShowIndicator = false;
         this.grdFbView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.GrdFbView_CustomDrawCell);
         // 
         // DecodersManagerView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdClose;
         this.ClientSize = new System.Drawing.Size(537, 459);
         this.Controls.Add(this.tabDecoder);
         this.Controls.Add(this.cmdClose);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "DecodersManagerView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Manage digital components";
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdAcc)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdAccView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabDecoder)).EndInit();
         this.tabDecoder.ResumeLayout(false);
         this.tabDecoderAcc.ResumeLayout(false);
         this.tabDecoderFb.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdFb)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdFbView)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.BarManager barManager;
      private DevExpress.XtraBars.Bar barSystems;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraBars.BarButtonItem cmdDecoderAdd;
      private DevExpress.XtraBars.BarButtonItem cmdSystemRemove;
      private DevExpress.XtraGrid.GridControl grdAcc;
      private DevExpress.XtraGrid.Views.Grid.GridView grdAccView;
      private DevExpress.XtraBars.BarButtonItem cmdDecoderEdit;
      private DevExpress.XtraEditors.SimpleButton cmdClose;
      private DevExpress.XtraBars.BarButtonItem cmdDecoderDelete;
      private DevExpress.XtraTab.XtraTabControl tabDecoder;
      private DevExpress.XtraTab.XtraTabPage tabDecoderAcc;
      private DevExpress.XtraTab.XtraTabPage tabDecoderFb;
      private DevExpress.XtraGrid.GridControl grdFb;
      private DevExpress.XtraGrid.Views.Grid.GridView grdFbView;
   }
}