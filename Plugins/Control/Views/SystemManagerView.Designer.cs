namespace Rwm.Studio.Plugins.Control.Views
{
   partial class SystemManagerView
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
         this.barManager = new DevExpress.XtraBars.BarManager();
         this.barSystems = new DevExpress.XtraBars.Bar();
         this.cmdSystemSelect = new DevExpress.XtraBars.BarButtonItem();
         this.cmdSystemRemove = new DevExpress.XtraBars.BarButtonItem();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.grdSystems = new DevExpress.XtraGrid.GridControl();
         this.grdSystemsView = new DevExpress.XtraGrid.Views.Grid.GridView();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdSystems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdSystemsView)).BeginInit();
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
            this.cmdSystemSelect,
            this.cmdSystemRemove});
         this.barManager.MaxItemId = 2;
         // 
         // barSystems
         // 
         this.barSystems.BarName = "Systems";
         this.barSystems.DockCol = 0;
         this.barSystems.DockRow = 0;
         this.barSystems.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.barSystems.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdSystemSelect)});
         this.barSystems.OptionsBar.AllowQuickCustomization = false;
         this.barSystems.OptionsBar.DisableClose = true;
         this.barSystems.OptionsBar.DisableCustomization = true;
         this.barSystems.OptionsBar.DrawDragBorder = false;
         this.barSystems.OptionsBar.UseWholeRow = true;
         this.barSystems.Text = "Systems";
         // 
         // cmdSystemSelect
         // 
         this.cmdSystemSelect.Caption = "Add system";
         this.cmdSystemSelect.Id = 0;
         this.cmdSystemSelect.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.SYSTEM_SELECT_32;
         this.cmdSystemSelect.Name = "cmdSystemSelect";
         this.cmdSystemSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdSystemSelect_ItemClick);
         // 
         // cmdSystemRemove
         // 
         this.cmdSystemRemove.Caption = "Remove system";
         this.cmdSystemRemove.Id = 1;
         this.cmdSystemRemove.ImageOptions.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_DECODER_DELETE_32;
         this.cmdSystemRemove.Name = "cmdSystemRemove";
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
         this.barDockControlBottom.Location = new System.Drawing.Point(0, 416);
         this.barDockControlBottom.Manager = this.barManager;
         this.barDockControlBottom.Size = new System.Drawing.Size(537, 0);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
         this.barDockControlLeft.Manager = this.barManager;
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 369);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(537, 47);
         this.barDockControlRight.Manager = this.barManager;
         this.barDockControlRight.Size = new System.Drawing.Size(0, 369);
         // 
         // grdSystems
         // 
         this.grdSystems.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdSystems.Location = new System.Drawing.Point(0, 47);
         this.grdSystems.MainView = this.grdSystemsView;
         this.grdSystems.MenuManager = this.barManager;
         this.grdSystems.Name = "grdSystems";
         this.grdSystems.Size = new System.Drawing.Size(537, 369);
         this.grdSystems.TabIndex = 5;
         this.grdSystems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdSystemsView});
         // 
         // grdSystemsView
         // 
         this.grdSystemsView.GridControl = this.grdSystems;
         this.grdSystemsView.Name = "grdSystemsView";
         this.grdSystemsView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdSystemsView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdSystemsView.OptionsBehavior.Editable = false;
         this.grdSystemsView.OptionsBehavior.ReadOnly = true;
         this.grdSystemsView.OptionsCustomization.AllowColumnMoving = false;
         this.grdSystemsView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdSystemsView.OptionsView.ShowGroupPanel = false;
         this.grdSystemsView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.GrdSystemsView_CustomDrawCell);
         // 
         // SystemManagerView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(537, 416);
         this.Controls.Add(this.grdSystems);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SystemManagerView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Manage digital systems";
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdSystems)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdSystemsView)).EndInit();
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
      private DevExpress.XtraBars.BarButtonItem cmdSystemSelect;
      private DevExpress.XtraBars.BarButtonItem cmdSystemRemove;
      private DevExpress.XtraGrid.GridControl grdSystems;
      private DevExpress.XtraGrid.Views.Grid.GridView grdSystemsView;
   }
}