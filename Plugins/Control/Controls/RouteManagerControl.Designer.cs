namespace Rwm.Studio.Plugins.Control.Controls
{
   partial class RouteManagerControl
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
         this.grdRoute = new DevExpress.XtraGrid.GridControl();
         this.grdRouteView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.barManager = new DevExpress.XtraBars.BarManager(this.components);
         this.barRoutes = new DevExpress.XtraBars.Bar();
         this.cmdRouteNew = new DevExpress.XtraBars.BarButtonItem();
         this.cmdRouteEdit = new DevExpress.XtraBars.BarButtonItem();
         this.cmdRouteDelete = new DevExpress.XtraBars.BarButtonItem();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         ((System.ComponentModel.ISupportInitialize)(this.grdRoute)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdRouteView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
         this.SuspendLayout();
         // 
         // grdRoute
         // 
         this.grdRoute.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdRoute.Location = new System.Drawing.Point(0, 31);
         this.grdRoute.MainView = this.grdRouteView;
         this.grdRoute.Name = "grdRoute";
         this.grdRoute.Size = new System.Drawing.Size(348, 379);
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
         this.grdRouteView.OptionsDetail.EnableMasterViewMode = false;
         this.grdRouteView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdRouteView.OptionsView.ShowGroupPanel = false;
         this.grdRouteView.OptionsView.ShowIndicator = false;
         this.grdRouteView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdRouteView_CustomDrawCell);
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
            this.cmdRouteNew,
            this.cmdRouteDelete,
            this.cmdRouteEdit});
         this.barManager.MaxItemId = 7;
         // 
         // barRoutes
         // 
         this.barRoutes.BarName = "Routes";
         this.barRoutes.DockCol = 0;
         this.barRoutes.DockRow = 0;
         this.barRoutes.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.barRoutes.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdRouteNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdRouteEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdRouteDelete)});
         this.barRoutes.OptionsBar.AllowQuickCustomization = false;
         this.barRoutes.OptionsBar.DisableClose = true;
         this.barRoutes.OptionsBar.DisableCustomization = true;
         this.barRoutes.OptionsBar.DrawBorder = false;
         this.barRoutes.OptionsBar.DrawDragBorder = false;
         this.barRoutes.OptionsBar.UseWholeRow = true;
         this.barRoutes.Text = "Herramientas";
         // 
         // cmdRouteNew
         // 
         this.cmdRouteNew.Caption = "New route";
         this.cmdRouteNew.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_ADD_16;
         this.cmdRouteNew.Id = 0;
         this.cmdRouteNew.LargeGlyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_ADD_32;
         this.cmdRouteNew.Name = "cmdRouteNew";
         this.cmdRouteNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdRouteNew_ItemClick);
         // 
         // cmdRouteEdit
         // 
         this.cmdRouteEdit.Caption = "Edit";
         this.cmdRouteEdit.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_EDIT_16;
         this.cmdRouteEdit.Id = 4;
         this.cmdRouteEdit.LargeGlyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_EDIT_32;
         this.cmdRouteEdit.Name = "cmdRouteEdit";
         this.cmdRouteEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdRouteEdit_ItemClick);
         // 
         // cmdRouteDelete
         // 
         this.cmdRouteDelete.Caption = "Delete";
         this.cmdRouteDelete.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_DELETE_16;
         this.cmdRouteDelete.Id = 3;
         this.cmdRouteDelete.LargeGlyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_DELETE_32;
         this.cmdRouteDelete.Name = "cmdRouteDelete";
         this.cmdRouteDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdRouteDelete_ItemClick);
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
         this.barDockControlTop.Size = new System.Drawing.Size(348, 31);
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point(0, 410);
         this.barDockControlBottom.Size = new System.Drawing.Size(348, 0);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 379);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(348, 31);
         this.barDockControlRight.Size = new System.Drawing.Size(0, 379);
         // 
         // RouteManagerControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.Controls.Add(this.grdRoute);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.Name = "RouteManagerControl";
         this.Size = new System.Drawing.Size(348, 410);
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
      private DevExpress.XtraBars.BarButtonItem cmdRouteNew;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraBars.BarButtonItem cmdRouteDelete;
      private DevExpress.XtraBars.BarButtonItem cmdRouteEdit;
   }
}
