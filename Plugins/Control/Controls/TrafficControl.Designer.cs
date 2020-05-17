namespace Rwm.Studio.Plugins.Control.Controls
{
   partial class TrafficControl
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrafficControl));
         this.barManager = new DevExpress.XtraBars.BarManager(this.components);
         this.barRoutes = new DevExpress.XtraBars.Bar();
         this.cmdRouteActivate = new DevExpress.XtraBars.BarButtonItem();
         this.cmdRouteClear = new DevExpress.XtraBars.BarButtonItem();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.alertControl = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
         this.tvwTraffic = new DevExpress.XtraTreeList.TreeList();
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tvwTraffic)).BeginInit();
         this.SuspendLayout();
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
         // 
         // cmdRouteClear
         // 
         this.cmdRouteClear.Caption = "Clear active routes";
         this.cmdRouteClear.Id = 4;
         this.cmdRouteClear.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_CLEAR_16;
         this.cmdRouteClear.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_CLEAR_16;
         this.cmdRouteClear.Name = "cmdRouteClear";
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
         this.barDockControlTop.Manager = this.barManager;
         this.barDockControlTop.Size = new System.Drawing.Size(325, 31);
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
         this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
         this.barDockControlLeft.Manager = this.barManager;
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 467);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(325, 31);
         this.barDockControlRight.Manager = this.barManager;
         this.barDockControlRight.Size = new System.Drawing.Size(0, 467);
         // 
         // alertControl
         // 
         this.alertControl.AllowHtmlText = true;
         this.alertControl.FormShowingEffect = DevExpress.XtraBars.Alerter.AlertFormShowingEffect.SlideVertical;
         this.alertControl.ShowPinButton = false;
         this.alertControl.ShowToolTips = false;
         // 
         // tvwTraffic
         // 
         this.tvwTraffic.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tvwTraffic.Location = new System.Drawing.Point(0, 31);
         this.tvwTraffic.Name = "tvwTraffic";
         this.tvwTraffic.Size = new System.Drawing.Size(325, 467);
         this.tvwTraffic.StateImageList = this.imageList;
         this.tvwTraffic.TabIndex = 9;
         // 
         // imageList
         // 
         this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
         this.imageList.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList.Images.SetKeyName(0, "timeline_16.png");
         this.imageList.Images.SetKeyName(1, "arrow_switch_stop_16.png");
         this.imageList.Images.SetKeyName(2, "arrow_switch_go_16.png");
         // 
         // TrafficControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tvwTraffic);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.Name = "TrafficControl";
         this.Size = new System.Drawing.Size(325, 498);
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tvwTraffic)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private DevExpress.XtraBars.BarManager barManager;
      private DevExpress.XtraBars.Bar barRoutes;
      private DevExpress.XtraBars.BarButtonItem cmdRouteActivate;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraBars.BarButtonItem cmdRouteClear;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl;
        private DevExpress.XtraTreeList.TreeList tvwTraffic;
        private System.Windows.Forms.ImageList imageList;
    }
}
