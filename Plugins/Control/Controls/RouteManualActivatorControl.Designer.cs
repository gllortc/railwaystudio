namespace Rwm.Studio.Plugins.Control.Controls
{
   partial class RouteManualActivatorControl
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
         this.grdRoute = new DevExpress.XtraGrid.GridControl();
         this.grdRouteView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.barManager = new DevExpress.XtraBars.BarManager();
         this.barRoutes = new DevExpress.XtraBars.Bar();
         this.cmdRouteActivate = new DevExpress.XtraBars.BarButtonItem();
         this.cmdRouteClear = new DevExpress.XtraBars.BarButtonItem();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.alertControl = new DevExpress.XtraBars.Alerter.AlertControl();
         ((System.ComponentModel.ISupportInitialize)(this.grdRoute)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdRouteView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
         this.SuspendLayout();
         // 
         // grdRoute
         // 
         this.grdRoute.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdRoute.Location = new System.Drawing.Point(0, 29);
         this.grdRoute.MainView = this.grdRouteView;
         this.grdRoute.Name = "grdRoute";
         this.grdRoute.Size = new System.Drawing.Size(325, 469);
         this.grdRoute.TabIndex = 4;
         this.grdRoute.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdRouteView});
         // 
         // grdRouteView
         // 
         this.grdRouteView.GridControl = this.grdRoute;
         this.grdRouteView.Name = "grdRouteView";
         this.grdRouteView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdRouteView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdRouteView.OptionsBehavior.Editable = false;
         this.grdRouteView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdRouteView.OptionsSelection.EnableAppearanceFocusedRow = false;
         this.grdRouteView.OptionsSelection.UseIndicatorForSelection = false;
         this.grdRouteView.OptionsView.ShowGroupPanel = false;
         this.grdRouteView.OptionsView.ShowIndicator = false;
         this.grdRouteView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.GrdRouteView_CustomDrawCell);
         this.grdRouteView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.GrdRouteView_RowStyle);
         this.grdRouteView.DoubleClick += new System.EventHandler(this.GrdRouteView_DoubleClick);
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
            this.cmdRouteClear});
         this.barManager.MaxItemId = 7;
         // 
         // barRoutes
         // 
         this.barRoutes.BarName = "Routes";
         this.barRoutes.DockCol = 0;
         this.barRoutes.DockRow = 0;
         this.barRoutes.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.barRoutes.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdRouteActivate),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdRouteClear)});
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
         // cmdRouteClear
         // 
         this.cmdRouteClear.Caption = "Clear active routes";
         this.cmdRouteClear.Id = 4;
         this.cmdRouteClear.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_CLEAR_16;
         this.cmdRouteClear.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_CLEAR_16;
         this.cmdRouteClear.Name = "cmdRouteClear";
         this.cmdRouteClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdRouteClear_ItemClick);
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
         // RouteManualActivatorControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grdRoute);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.Name = "RouteManualActivatorControl";
         this.Size = new System.Drawing.Size(325, 498);
         ((System.ComponentModel.ISupportInitialize)(this.grdRoute)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdRouteView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraGrid.GridControl grdRoute;
      private DevExpress.XtraGrid.Views.Grid.GridView grdRouteView;
      private DevExpress.XtraBars.BarManager barManager;
      private DevExpress.XtraBars.Bar barRoutes;
      private DevExpress.XtraBars.BarButtonItem cmdRouteActivate;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraBars.BarButtonItem cmdRouteClear;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl;
    }
}
