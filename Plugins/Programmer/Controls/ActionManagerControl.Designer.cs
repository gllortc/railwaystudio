namespace Rwm.Studio.Plugins.Designer.Controls
{
   partial class ActionManagerControl
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
         this.tbrActions = new DevExpress.XtraBars.Bar();
         this.blcActions = new DevExpress.XtraBars.BarLinkContainerItem();
         this.cmdActionRoute = new DevExpress.XtraBars.BarButtonItem();
         this.cmdActionStatus = new DevExpress.XtraBars.BarButtonItem();
         this.cmdActionSound = new DevExpress.XtraBars.BarButtonItem();
         this.cmdActionEdit = new DevExpress.XtraBars.BarButtonItem();
         this.cmdActionDelete = new DevExpress.XtraBars.BarButtonItem();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.grdData = new DevExpress.XtraGrid.GridControl();
         this.grdDataView = new DevExpress.XtraGrid.Views.Grid.GridView();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).BeginInit();
         this.SuspendLayout();
         // 
         // barManager
         // 
         this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.tbrActions});
         this.barManager.DockControls.Add(this.barDockControlTop);
         this.barManager.DockControls.Add(this.barDockControlBottom);
         this.barManager.DockControls.Add(this.barDockControlLeft);
         this.barManager.DockControls.Add(this.barDockControlRight);
         this.barManager.Form = this;
         this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.cmdActionDelete,
            this.blcActions,
            this.cmdActionRoute,
            this.cmdActionStatus,
            this.cmdActionSound,
            this.cmdActionEdit});
         this.barManager.MaxItemId = 7;
         // 
         // tbrActions
         // 
         this.tbrActions.BarName = "Herramientas";
         this.tbrActions.DockCol = 0;
         this.tbrActions.DockRow = 0;
         this.tbrActions.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.tbrActions.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.blcActions),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdActionEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdActionDelete)});
         this.tbrActions.OptionsBar.AllowQuickCustomization = false;
         this.tbrActions.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
         this.tbrActions.OptionsBar.DisableClose = true;
         this.tbrActions.OptionsBar.DisableCustomization = true;
         this.tbrActions.OptionsBar.DrawBorder = false;
         this.tbrActions.Text = "Herramientas";
         // 
         // blcActions
         // 
         this.blcActions.Caption = "Add action";
         this.blcActions.Glyph = Properties.Resources.ICO_ACTION_ADD_16;
         this.blcActions.Id = 2;
         this.blcActions.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdActionRoute),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdActionStatus),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdActionSound)});
         this.blcActions.Name = "blcActions";
         this.blcActions.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
         // 
         // cmdActionRoute
         // 
         this.cmdActionRoute.Caption = "Activate route";
         this.cmdActionRoute.Glyph = Properties.Resources.ICO_ACTION_ROUTE_16;
         this.cmdActionRoute.Id = 3;
         this.cmdActionRoute.Name = "cmdActionRoute";
         this.cmdActionRoute.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdActionRoute_ItemClick);
         // 
         // cmdActionStatus
         // 
         this.cmdActionStatus.Caption = "Set element status";
         this.cmdActionStatus.Glyph = Properties.Resources.ICO_BLOCK_GO_16;
         this.cmdActionStatus.Id = 4;
         this.cmdActionStatus.Name = "cmdActionStatus";
         this.cmdActionStatus.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdActionStatus_ItemClick);
         // 
         // cmdActionSound
         // 
         this.cmdActionSound.Caption = "Play sound";
         this.cmdActionSound.Glyph = Otc.Layout.Sound.SmallIcon;
         this.cmdActionSound.Id = 5;
         this.cmdActionSound.Name = "cmdActionSound";
         this.cmdActionSound.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdActionSound_ItemClick);
         // 
         // cmdActionEdit
         // 
         this.cmdActionEdit.Caption = "Edit";
         this.cmdActionEdit.Glyph = Properties.Resources.ICO_ACTION_EDIT_16;
         this.cmdActionEdit.Id = 6;
         this.cmdActionEdit.Name = "cmdActionEdit";
         this.cmdActionEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdActionEdit_ItemClick);
         // 
         // cmdActionDelete
         // 
         this.cmdActionDelete.Caption = "Delete";
         this.cmdActionDelete.Glyph = Properties.Resources.ICO_ACTION_DELETE_16;
         this.cmdActionDelete.Id = 1;
         this.cmdActionDelete.Name = "cmdActionDelete";
         this.cmdActionDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdActionDelete_ItemClick);
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
         this.barDockControlTop.Size = new System.Drawing.Size(434, 31);
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point(0, 314);
         this.barDockControlBottom.Size = new System.Drawing.Size(434, 0);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 283);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(434, 31);
         this.barDockControlRight.Size = new System.Drawing.Size(0, 283);
         // 
         // grdData
         // 
         this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdData.Location = new System.Drawing.Point(0, 31);
         this.grdData.MainView = this.grdDataView;
         this.grdData.Name = "grdData";
         this.grdData.Size = new System.Drawing.Size(434, 283);
         this.grdData.TabIndex = 6;
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
         this.grdDataView.OptionsDetail.EnableMasterViewMode = false;
         this.grdDataView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdDataView.OptionsView.ShowGroupPanel = false;
         this.grdDataView.OptionsView.ShowIndicator = false;
         this.grdDataView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdDataView_CustomDrawCell);
         this.grdDataView.DoubleClick += new System.EventHandler(this.grdDataView_DoubleClick);
         // 
         // ActionManagerControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grdData);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.Name = "ActionManagerControl";
         this.Size = new System.Drawing.Size(434, 314);
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.BarManager barManager;
      private DevExpress.XtraBars.Bar tbrActions;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarButtonItem cmdActionDelete;
      private DevExpress.XtraGrid.GridControl grdData;
      private DevExpress.XtraGrid.Views.Grid.GridView grdDataView;
      private DevExpress.XtraBars.BarLinkContainerItem blcActions;
      private DevExpress.XtraBars.BarButtonItem cmdActionRoute;
      private DevExpress.XtraBars.BarButtonItem cmdActionStatus;
      private DevExpress.XtraBars.BarButtonItem cmdActionSound;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraBars.BarButtonItem cmdActionEdit;
   }
}
