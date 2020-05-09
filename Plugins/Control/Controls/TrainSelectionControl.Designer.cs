namespace Rwm.Studio.Plugins.Control.Controls
{
   partial class TrainSelectionControl
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
         this.grdTrain = new DevExpress.XtraGrid.GridControl();
         this.grdTrainView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.barManager = new DevExpress.XtraBars.BarManager();
         this.barRoutes = new DevExpress.XtraBars.Bar();
         this.cmdRouteActivate = new DevExpress.XtraBars.BarButtonItem();
         this.cmdTrainUnassign = new DevExpress.XtraBars.BarButtonItem();
         this.cmdTrainClear = new DevExpress.XtraBars.BarButtonItem();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.alertControl = new DevExpress.XtraBars.Alerter.AlertControl();
         ((System.ComponentModel.ISupportInitialize)(this.grdTrain)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdTrainView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
         this.SuspendLayout();
         // 
         // grdTrain
         // 
         this.grdTrain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdTrain.Location = new System.Drawing.Point(0, 29);
         this.grdTrain.MainView = this.grdTrainView;
         this.grdTrain.Name = "grdTrain";
         this.grdTrain.Size = new System.Drawing.Size(325, 469);
         this.grdTrain.TabIndex = 4;
         this.grdTrain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdTrainView});
         // 
         // grdTrainView
         // 
         this.grdTrainView.GridControl = this.grdTrain;
         this.grdTrainView.Name = "grdTrainView";
         this.grdTrainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdTrainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdTrainView.OptionsBehavior.Editable = false;
         this.grdTrainView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdTrainView.OptionsSelection.EnableAppearanceFocusedRow = false;
         this.grdTrainView.OptionsSelection.UseIndicatorForSelection = false;
         this.grdTrainView.OptionsView.ShowGroupPanel = false;
         this.grdTrainView.OptionsView.ShowIndicator = false;
         this.grdTrainView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.GrdRouteView_CustomDrawCell);
         this.grdTrainView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.GrdRouteView_RowStyle);
         this.grdTrainView.DoubleClick += new System.EventHandler(this.GrdRouteView_DoubleClick);
         // 
         // barManager
         // 
         this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barRoutes});
         this.barManager.DockControls.Add(this.barDockControlTop);
         this.barManager.DockControls.Add(this.barDockControlBottom);
         this.barManager.DockControls.Add(this.barDockControlLeft);
         this.barManager.DockControls.Add(this.barDockControlRight);
         this.barManager.Form = this;
         this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.cmdRouteActivate,
            this.cmdTrainClear,
            this.cmdTrainUnassign});
         this.barManager.MaxItemId = 8;
         // 
         // barRoutes
         // 
         this.barRoutes.BarName = "Routes";
         this.barRoutes.DockCol = 0;
         this.barRoutes.DockRow = 0;
         this.barRoutes.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.barRoutes.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdRouteActivate),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdTrainUnassign),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdTrainClear, true)});
         this.barRoutes.OptionsBar.AllowQuickCustomization = false;
         this.barRoutes.OptionsBar.DisableClose = true;
         this.barRoutes.OptionsBar.DisableCustomization = true;
         this.barRoutes.OptionsBar.DrawBorder = false;
         this.barRoutes.OptionsBar.DrawDragBorder = false;
         this.barRoutes.OptionsBar.UseWholeRow = true;
         this.barRoutes.Text = "Route tools";
         // 
         // cmdRouteActivate
         // 
         this.cmdRouteActivate.Caption = "Toggle route activation";
         this.cmdRouteActivate.Id = 0;
         this.cmdRouteActivate.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_ACTIVATE_16;
         this.cmdRouteActivate.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_ACTIVATE_16;
         this.cmdRouteActivate.Name = "cmdRouteActivate";
         this.cmdRouteActivate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdRouteActivate_ItemClick);
         // 
         // cmdTrainUnassign
         // 
         this.cmdTrainUnassign.Caption = "Unassign";
         this.cmdTrainUnassign.Id = 7;
         this.cmdTrainUnassign.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_TRAIN_UNASSIGN_16;
         this.cmdTrainUnassign.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_TRAIN_UNASSIGN_16;
         this.cmdTrainUnassign.Name = "cmdTrainUnassign";
         this.cmdTrainUnassign.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdTrainUnassign_ItemClick);
         // 
         // cmdTrainClear
         // 
         this.cmdTrainClear.Caption = "Clear all train assignments";
         this.cmdTrainClear.Id = 4;
         this.cmdTrainClear.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_TRAIN_CLEAR_16;
         this.cmdTrainClear.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_TRAIN_CLEAR_16;
         this.cmdTrainClear.Name = "cmdTrainClear";
         this.cmdTrainClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdTrainClear_ItemClick);
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
         this.barDockControlTop.Manager = this.barManager;
         this.barDockControlTop.Size = new System.Drawing.Size(325, 29);
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point(0, 498);
         this.barDockControlBottom.Manager = this.barManager;
         this.barDockControlBottom.Size = new System.Drawing.Size(325, 0);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
         this.barDockControlLeft.Manager = this.barManager;
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 469);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(325, 29);
         this.barDockControlRight.Manager = this.barManager;
         this.barDockControlRight.Size = new System.Drawing.Size(0, 469);
         // 
         // alertControl
         // 
         this.alertControl.AllowHtmlText = true;
         this.alertControl.FormShowingEffect = DevExpress.XtraBars.Alerter.AlertFormShowingEffect.SlideVertical;
         this.alertControl.ShowPinButton = false;
         this.alertControl.ShowToolTips = false;
         // 
         // TrainSelectionControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grdTrain);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.Name = "TrainSelectionControl";
         this.Size = new System.Drawing.Size(325, 498);
         ((System.ComponentModel.ISupportInitialize)(this.grdTrain)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdTrainView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraGrid.GridControl grdTrain;
      private DevExpress.XtraGrid.Views.Grid.GridView grdTrainView;
      private DevExpress.XtraBars.BarManager barManager;
      private DevExpress.XtraBars.Bar barRoutes;
      private DevExpress.XtraBars.BarButtonItem cmdRouteActivate;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraBars.BarButtonItem cmdTrainClear;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl;
        private DevExpress.XtraBars.BarButtonItem cmdTrainUnassign;
    }
}
