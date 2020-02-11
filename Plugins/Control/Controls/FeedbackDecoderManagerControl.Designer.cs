namespace Rwm.Studio.Plugins.Control.Controls
{
   partial class FeedbackDecoderManagerControl
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
         this.barManager = new DevExpress.XtraBars.BarManager(this.components);
         this.barModuleManager = new DevExpress.XtraBars.Bar();
         this.cmdDecoderAdd = new DevExpress.XtraBars.BarButtonItem();
         this.cmdModuleEdit = new DevExpress.XtraBars.BarButtonItem();
         this.cmdModuleDelete = new DevExpress.XtraBars.BarButtonItem();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.grdModule = new DevExpress.XtraGrid.GridControl();
         this.grdModuleView = new DevExpress.XtraGrid.Views.Grid.GridView();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdModule)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdModuleView)).BeginInit();
         this.SuspendLayout();
         // 
         // barManager
         // 
         this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barModuleManager});
         this.barManager.DockControls.Add(this.barDockControlTop);
         this.barManager.DockControls.Add(this.barDockControlBottom);
         this.barManager.DockControls.Add(this.barDockControlLeft);
         this.barManager.DockControls.Add(this.barDockControlRight);
         this.barManager.Form = this;
         this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.cmdModuleEdit,
            this.cmdModuleDelete,
            this.cmdDecoderAdd});
         this.barManager.MaxItemId = 8;
         // 
         // barModuleManager
         // 
         this.barModuleManager.BarName = "Herramientas";
         this.barModuleManager.DockCol = 0;
         this.barModuleManager.DockRow = 0;
         this.barModuleManager.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.barModuleManager.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdDecoderAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdModuleEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdModuleDelete)});
         this.barModuleManager.OptionsBar.AllowQuickCustomization = false;
         this.barModuleManager.OptionsBar.DisableClose = true;
         this.barModuleManager.OptionsBar.DrawBorder = false;
         this.barModuleManager.OptionsBar.UseWholeRow = true;
         this.barModuleManager.Text = "Herramientas";
         // 
         // cmdDecoderAdd
         // 
         this.cmdDecoderAdd.Caption = "Add new feedback decoder";
         this.cmdDecoderAdd.Id = 7;
         this.cmdDecoderAdd.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_MODULE_ADD_16;
         this.cmdDecoderAdd.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_MODULE_ADD_32;
         this.cmdDecoderAdd.Name = "cmdDecoderAdd";
         this.cmdDecoderAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdDecoderAdd_ItemClick);
         // 
         // cmdModuleEdit
         // 
         this.cmdModuleEdit.Caption = "Edit selected decoder";
         this.cmdModuleEdit.Id = 1;
         this.cmdModuleEdit.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_MODULE_EDIT_16;
         this.cmdModuleEdit.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_MODULE_EDIT_32;
         this.cmdModuleEdit.Name = "cmdModuleEdit";
         this.cmdModuleEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdModuleEdit_ItemClick);
         // 
         // cmdModuleDelete
         // 
         this.cmdModuleDelete.Caption = "Delete selected decoder";
         this.cmdModuleDelete.Id = 2;
         this.cmdModuleDelete.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_MODULE_DELETE_16;
         this.cmdModuleDelete.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_MODULE_DELETE_32;
         this.cmdModuleDelete.Name = "cmdModuleDelete";
         this.cmdModuleDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdModuleDelete_ItemClick);
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
         this.barDockControlTop.Manager = this.barManager;
         this.barDockControlTop.Size = new System.Drawing.Size(333, 31);
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point(0, 454);
         this.barDockControlBottom.Manager = this.barManager;
         this.barDockControlBottom.Size = new System.Drawing.Size(333, 0);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
         this.barDockControlLeft.Manager = this.barManager;
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 423);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(333, 31);
         this.barDockControlRight.Manager = this.barManager;
         this.barDockControlRight.Size = new System.Drawing.Size(0, 423);
         // 
         // grdModule
         // 
         this.grdModule.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdModule.Location = new System.Drawing.Point(0, 31);
         this.grdModule.MainView = this.grdModuleView;
         this.grdModule.MenuManager = this.barManager;
         this.grdModule.Name = "grdModule";
         this.grdModule.Size = new System.Drawing.Size(333, 423);
         this.grdModule.TabIndex = 4;
         this.grdModule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdModuleView});
         // 
         // grdModuleView
         // 
         this.grdModuleView.GridControl = this.grdModule;
         this.grdModuleView.Name = "grdModuleView";
         this.grdModuleView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdModuleView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdModuleView.OptionsBehavior.AutoPopulateColumns = false;
         this.grdModuleView.OptionsBehavior.Editable = false;
         this.grdModuleView.OptionsBehavior.ReadOnly = true;
         this.grdModuleView.OptionsCustomization.AllowColumnMoving = false;
         this.grdModuleView.OptionsCustomization.AllowGroup = false;
         this.grdModuleView.OptionsDetail.EnableMasterViewMode = false;
         this.grdModuleView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdModuleView.OptionsView.ShowGroupPanel = false;
         this.grdModuleView.OptionsView.ShowIndicator = false;
         this.grdModuleView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.GrdModuleView_CustomDrawCell);
         this.grdModuleView.DoubleClick += new System.EventHandler(this.GrdModuleView_DoubleClick);
         // 
         // FeedbackDecoderManagerControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grdModule);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.Name = "FeedbackDecoderManagerControl";
         this.Size = new System.Drawing.Size(333, 454);
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdModule)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdModuleView)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.BarManager barManager;
      private DevExpress.XtraBars.Bar barModuleManager;
      private DevExpress.XtraBars.BarButtonItem cmdModuleEdit;
      private DevExpress.XtraBars.BarButtonItem cmdModuleDelete;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraGrid.GridControl grdModule;
      private DevExpress.XtraGrid.Views.Grid.GridView grdModuleView;
        private DevExpress.XtraBars.BarButtonItem cmdDecoderAdd;
    }
}
