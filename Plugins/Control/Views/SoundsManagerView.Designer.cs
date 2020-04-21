namespace Rwm.Studio.Plugins.Control.Views
{
   partial class SoundsManagerView
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
         this.cmdSoundAdd = new DevExpress.XtraBars.BarButtonItem();
         this.cmdSoundEdit = new DevExpress.XtraBars.BarButtonItem();
         this.cmdSoundDelete = new DevExpress.XtraBars.BarButtonItem();
         this.cmdSoundPlay = new DevExpress.XtraBars.BarButtonItem();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.cmdSystemRemove = new DevExpress.XtraBars.BarButtonItem();
         this.grdAreas = new DevExpress.XtraGrid.GridControl();
         this.grdAreasView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.cmdClose = new DevExpress.XtraEditors.SimpleButton();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdAreas)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdAreasView)).BeginInit();
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
            this.cmdSoundAdd,
            this.cmdSystemRemove,
            this.cmdSoundEdit,
            this.cmdSoundDelete,
            this.cmdSoundPlay});
         this.barManager.MaxItemId = 5;
         // 
         // barSystems
         // 
         this.barSystems.BarName = "Systems";
         this.barSystems.DockCol = 0;
         this.barSystems.DockRow = 0;
         this.barSystems.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.barSystems.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdSoundAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdSoundEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdSoundDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdSoundPlay, true)});
         this.barSystems.OptionsBar.AllowQuickCustomization = false;
         this.barSystems.OptionsBar.DisableClose = true;
         this.barSystems.OptionsBar.DisableCustomization = true;
         this.barSystems.OptionsBar.DrawDragBorder = false;
         this.barSystems.OptionsBar.UseWholeRow = true;
         this.barSystems.Text = "Systems";
         // 
         // cmdSoundAdd
         // 
         this.cmdSoundAdd.Caption = "Add new sound";
         this.cmdSoundAdd.Id = 0;
         this.cmdSoundAdd.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SOUND_ADD_32;
         this.cmdSoundAdd.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SOUND_ADD_32;
         this.cmdSoundAdd.Name = "cmdSoundAdd";
         this.cmdSoundAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdSoundAdd_ItemClick);
         // 
         // cmdSoundEdit
         // 
         this.cmdSoundEdit.Caption = "Edit sound";
         this.cmdSoundEdit.Id = 2;
         this.cmdSoundEdit.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.sound_edit_32;
         this.cmdSoundEdit.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.sound_edit_32;
         this.cmdSoundEdit.Name = "cmdSoundEdit";
         this.cmdSoundEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdSoundEdit_ItemClick);
         // 
         // cmdSoundDelete
         // 
         this.cmdSoundDelete.Caption = "Delete sound";
         this.cmdSoundDelete.Id = 3;
         this.cmdSoundDelete.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SOUND_DELETE_32;
         this.cmdSoundDelete.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SOUND_DELETE_32;
         this.cmdSoundDelete.Name = "cmdSoundDelete";
         this.cmdSoundDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdSoundDelete_ItemClick);
         // 
         // cmdSoundPlay
         // 
         this.cmdSoundPlay.Caption = "Play sound";
         this.cmdSoundPlay.Id = 4;
         this.cmdSoundPlay.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SOUND_PLAY_32;
         this.cmdSoundPlay.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SOUND_PLAY_32;
         this.cmdSoundPlay.Name = "cmdSoundPlay";
         this.cmdSoundPlay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdSoundPlay_ItemClick);
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
         this.cmdSystemRemove.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_DECODER_DELETE_32;
         this.cmdSystemRemove.Name = "cmdSystemRemove";
         // 
         // grdAreas
         // 
         this.grdAreas.Location = new System.Drawing.Point(0, 47);
         this.grdAreas.MainView = this.grdAreasView;
         this.grdAreas.MenuManager = this.barManager;
         this.grdAreas.Name = "grdAreas";
         this.grdAreas.Size = new System.Drawing.Size(537, 366);
         this.grdAreas.TabIndex = 5;
         this.grdAreas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdAreasView});
         // 
         // grdAreasView
         // 
         this.grdAreasView.GridControl = this.grdAreas;
         this.grdAreasView.Name = "grdAreasView";
         this.grdAreasView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdAreasView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdAreasView.OptionsBehavior.Editable = false;
         this.grdAreasView.OptionsBehavior.ReadOnly = true;
         this.grdAreasView.OptionsCustomization.AllowColumnMoving = false;
         this.grdAreasView.OptionsCustomization.AllowColumnResizing = false;
         this.grdAreasView.OptionsCustomization.AllowFilter = false;
         this.grdAreasView.OptionsCustomization.AllowGroup = false;
         this.grdAreasView.OptionsCustomization.AllowSort = false;
         this.grdAreasView.OptionsFilter.AllowColumnMRUFilterList = false;
         this.grdAreasView.OptionsFilter.AllowFilterEditor = false;
         this.grdAreasView.OptionsFind.AllowFindPanel = false;
         this.grdAreasView.OptionsFind.ShowClearButton = false;
         this.grdAreasView.OptionsFind.ShowCloseButton = false;
         this.grdAreasView.OptionsFind.ShowFindButton = false;
         this.grdAreasView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdAreasView.OptionsView.ShowGroupPanel = false;
         this.grdAreasView.OptionsView.ShowIndicator = false;
         this.grdAreasView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.GrdAreasView_CustomDrawCell);
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
         // SoundsManagerView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdClose;
         this.ClientSize = new System.Drawing.Size(537, 459);
         this.Controls.Add(this.cmdClose);
         this.Controls.Add(this.grdAreas);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SoundsManagerView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Manage layout sounds";
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdAreas)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdAreasView)).EndInit();
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
      private DevExpress.XtraBars.BarButtonItem cmdSoundAdd;
      private DevExpress.XtraBars.BarButtonItem cmdSystemRemove;
      private DevExpress.XtraGrid.GridControl grdAreas;
      private DevExpress.XtraGrid.Views.Grid.GridView grdAreasView;
      private DevExpress.XtraBars.BarButtonItem cmdSoundEdit;
      private DevExpress.XtraEditors.SimpleButton cmdClose;
      private DevExpress.XtraBars.BarButtonItem cmdSoundDelete;
        private DevExpress.XtraBars.BarButtonItem cmdSoundPlay;
    }
}