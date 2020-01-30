namespace RailwayStudio.Common.Controls
{
   partial class PluginManagementControl
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
         this.bar1 = new DevExpress.XtraBars.Bar();
         this.cmdPluginAdd = new DevExpress.XtraBars.BarButtonItem();
         this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.grdPlugins = new DevExpress.XtraGrid.GridControl();
         this.grdPluginsView = new DevExpress.XtraGrid.Views.Grid.GridView();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdPlugins)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdPluginsView)).BeginInit();
         this.SuspendLayout();
         // 
         // barManager
         // 
         this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
         this.barManager.DockControls.Add(this.barDockControlTop);
         this.barManager.DockControls.Add(this.barDockControlBottom);
         this.barManager.DockControls.Add(this.barDockControlLeft);
         this.barManager.DockControls.Add(this.barDockControlRight);
         this.barManager.Form = this;
         this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.cmdPluginAdd,
            this.barButtonItem2});
         this.barManager.MaxItemId = 2;
         // 
         // bar1
         // 
         this.bar1.BarName = "Herramientas";
         this.bar1.DockCol = 0;
         this.bar1.DockRow = 0;
         this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdPluginAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)});
         this.bar1.OptionsBar.AllowQuickCustomization = false;
         this.bar1.OptionsBar.DisableClose = true;
         this.bar1.OptionsBar.DisableCustomization = true;
         this.bar1.OptionsBar.DrawDragBorder = false;
         this.bar1.OptionsBar.UseWholeRow = true;
         this.bar1.Text = "Herramientas";
         // 
         // cmdPluginAdd
         // 
         this.cmdPluginAdd.Caption = "Install";
         this.cmdPluginAdd.Glyph = global::RailwayStudio.Common.Properties.Resources.ICO_PLUGIN_ADD_16;
         this.cmdPluginAdd.Id = 0;
         this.cmdPluginAdd.Name = "cmdPluginAdd";
         this.cmdPluginAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
         this.cmdPluginAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdPluginAdd_ItemClick);
         // 
         // barButtonItem2
         // 
         this.barButtonItem2.Caption = "Remove";
         this.barButtonItem2.Glyph = global::RailwayStudio.Common.Properties.Resources.ICO_PLUGIN_DELETE_16;
         this.barButtonItem2.Id = 1;
         this.barButtonItem2.Name = "barButtonItem2";
         this.barButtonItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
         this.barDockControlTop.Size = new System.Drawing.Size(546, 31);
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point(0, 337);
         this.barDockControlBottom.Size = new System.Drawing.Size(546, 0);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 306);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(546, 31);
         this.barDockControlRight.Size = new System.Drawing.Size(0, 306);
         // 
         // grdPlugins
         // 
         this.grdPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdPlugins.Location = new System.Drawing.Point(0, 31);
         this.grdPlugins.MainView = this.grdPluginsView;
         this.grdPlugins.MenuManager = this.barManager;
         this.grdPlugins.Name = "grdPlugins";
         this.grdPlugins.Size = new System.Drawing.Size(546, 306);
         this.grdPlugins.TabIndex = 4;
         this.grdPlugins.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdPluginsView});
         // 
         // grdPluginsView
         // 
         this.grdPluginsView.GridControl = this.grdPlugins;
         this.grdPluginsView.Name = "grdPluginsView";
         this.grdPluginsView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdPluginsView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdPluginsView.OptionsBehavior.ReadOnly = true;
         this.grdPluginsView.OptionsView.ShowGroupPanel = false;
         this.grdPluginsView.OptionsView.ShowIndicator = false;
         // 
         // PluginManagementControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grdPlugins);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.Name = "PluginManagementControl";
         this.Size = new System.Drawing.Size(546, 337);
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdPlugins)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdPluginsView)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.BarManager barManager;
      private DevExpress.XtraBars.Bar bar1;
      private DevExpress.XtraBars.BarButtonItem cmdPluginAdd;
      private DevExpress.XtraBars.BarButtonItem barButtonItem2;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraGrid.GridControl grdPlugins;
      private DevExpress.XtraGrid.Views.Grid.GridView grdPluginsView;
   }
}
