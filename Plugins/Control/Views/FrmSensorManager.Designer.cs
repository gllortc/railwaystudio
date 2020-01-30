namespace Rwm.Studio.Plugins.Control.Views
{
   partial class FrmSensorManager
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
         this.barDecoders = new DevExpress.XtraBars.Bar();
         this.cmdDecoderAdd = new DevExpress.XtraBars.BarButtonItem();
         this.cmdDecoderEdit = new DevExpress.XtraBars.BarButtonItem();
         this.cmdDecoderDelete = new DevExpress.XtraBars.BarButtonItem();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.grdModules = new DevExpress.XtraGrid.GridControl();
         this.grdModulesView = new DevExpress.XtraGrid.Views.Grid.GridView();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdModules)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdModulesView)).BeginInit();
         this.SuspendLayout();
         // 
         // barManager
         // 
         this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barDecoders});
         this.barManager.DockControls.Add(this.barDockControlTop);
         this.barManager.DockControls.Add(this.barDockControlBottom);
         this.barManager.DockControls.Add(this.barDockControlLeft);
         this.barManager.DockControls.Add(this.barDockControlRight);
         this.barManager.Form = this;
         this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.cmdDecoderAdd,
            this.cmdDecoderEdit,
            this.cmdDecoderDelete});
         this.barManager.MaxItemId = 3;
         // 
         // barDecoders
         // 
         this.barDecoders.BarName = "Decodres";
         this.barDecoders.DockCol = 0;
         this.barDecoders.DockRow = 0;
         this.barDecoders.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.barDecoders.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdDecoderAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdDecoderEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdDecoderDelete)});
         this.barDecoders.OptionsBar.AllowQuickCustomization = false;
         this.barDecoders.OptionsBar.DrawDragBorder = false;
         this.barDecoders.OptionsBar.UseWholeRow = true;
         this.barDecoders.Text = "Herramientas";
         // 
         // cmdDecoderAdd
         // 
         this.cmdDecoderAdd.Caption = "New module";
         this.cmdDecoderAdd.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_MODULE_ADD_32;
         this.cmdDecoderAdd.Id = 0;
         this.cmdDecoderAdd.Name = "cmdDecoderAdd";
         this.cmdDecoderAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdDecoderAdd_ItemClick);
         // 
         // cmdDecoderEdit
         // 
         this.cmdDecoderEdit.Caption = "Edit module";
         this.cmdDecoderEdit.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_MODULE_EDIT_32;
         this.cmdDecoderEdit.Id = 1;
         this.cmdDecoderEdit.Name = "cmdDecoderEdit";
         this.cmdDecoderEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdDecoderEdit_ItemClick);
         // 
         // cmdDecoderDelete
         // 
         this.cmdDecoderDelete.Caption = "Delete module";
         this.cmdDecoderDelete.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_MODULE_DELETE_32;
         this.cmdDecoderDelete.Id = 2;
         this.cmdDecoderDelete.Name = "cmdDecoderDelete";
         this.cmdDecoderDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdDecoderDelete_ItemClick);
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
         this.barDockControlTop.Size = new System.Drawing.Size(537, 47);
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point(0, 416);
         this.barDockControlBottom.Size = new System.Drawing.Size(537, 0);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 369);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(537, 47);
         this.barDockControlRight.Size = new System.Drawing.Size(0, 369);
         // 
         // grdModules
         // 
         this.grdModules.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdModules.Location = new System.Drawing.Point(0, 47);
         this.grdModules.MainView = this.grdModulesView;
         this.grdModules.MenuManager = this.barManager;
         this.grdModules.Name = "grdModules";
         this.grdModules.Size = new System.Drawing.Size(537, 369);
         this.grdModules.TabIndex = 4;
         this.grdModules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdModulesView});
         // 
         // grdModulesView
         // 
         this.grdModulesView.GridControl = this.grdModules;
         this.grdModulesView.Name = "grdModulesView";
         this.grdModulesView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdModulesView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdModulesView.OptionsBehavior.Editable = false;
         this.grdModulesView.OptionsBehavior.ReadOnly = true;
         this.grdModulesView.OptionsCustomization.AllowColumnMoving = false;
         this.grdModulesView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdModulesView.OptionsView.ShowGroupPanel = false;
         this.grdModulesView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdDecodersView_CustomDrawCell);
         // 
         // FrmSensorManager
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(537, 416);
         this.Controls.Add(this.grdModules);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmSensorManager";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Sensor modules";
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdModules)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdModulesView)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.BarManager barManager;
      private DevExpress.XtraBars.Bar barDecoders;
      private DevExpress.XtraBars.BarButtonItem cmdDecoderAdd;
      private DevExpress.XtraBars.BarButtonItem cmdDecoderEdit;
      private DevExpress.XtraBars.BarButtonItem cmdDecoderDelete;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraGrid.GridControl grdModules;
      private DevExpress.XtraGrid.Views.Grid.GridView grdModulesView;
   }
}