namespace Rwm.Studio.Plugins.Control.Views
{
   partial class FrmModuleSelector
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
         this.cmdModuleAdd = new DevExpress.XtraBars.BarButtonItem();
         this.cmdModuleEdit = new DevExpress.XtraBars.BarButtonItem();
         this.cmdModuleDelete = new DevExpress.XtraBars.BarButtonItem();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.grdAccessory = new DevExpress.XtraGrid.GridControl();
         this.grdAccessoryView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.tabModules = new DevExpress.XtraTab.XtraTabControl();
         this.tabModulesAccessories = new DevExpress.XtraTab.XtraTabPage();
         this.tabModulesSensors = new DevExpress.XtraTab.XtraTabPage();
         this.grdSensor = new DevExpress.XtraGrid.GridControl();
         this.grdSensorView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
         this.cmdSelect = new DevExpress.XtraEditors.SimpleButton();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdAccessory)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdAccessoryView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabModules)).BeginInit();
         this.tabModules.SuspendLayout();
         this.tabModulesAccessories.SuspendLayout();
         this.tabModulesSensors.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdSensor)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdSensorView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
         this.panelControl1.SuspendLayout();
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
            this.cmdModuleAdd,
            this.cmdModuleEdit,
            this.cmdModuleDelete});
         this.barManager.MaxItemId = 3;
         // 
         // barDecoders
         // 
         this.barDecoders.BarName = "Decodres";
         this.barDecoders.DockCol = 0;
         this.barDecoders.DockRow = 0;
         this.barDecoders.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.barDecoders.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdModuleAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdModuleEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdModuleDelete)});
         this.barDecoders.OptionsBar.AllowQuickCustomization = false;
         this.barDecoders.OptionsBar.DrawDragBorder = false;
         this.barDecoders.OptionsBar.UseWholeRow = true;
         this.barDecoders.Text = "Herramientas";
         // 
         // cmdModuleAdd
         // 
         this.cmdModuleAdd.Caption = "New decoder";
         this.cmdModuleAdd.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_MODULE_ADD_32;
         this.cmdModuleAdd.Id = 0;
         this.cmdModuleAdd.Name = "cmdModuleAdd";
         this.cmdModuleAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdModuleAdd_ItemClick);
         // 
         // cmdModuleEdit
         // 
         this.cmdModuleEdit.Caption = "Edit decoder";
         this.cmdModuleEdit.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_MODULE_EDIT_32;
         this.cmdModuleEdit.Id = 1;
         this.cmdModuleEdit.Name = "cmdModuleEdit";
         this.cmdModuleEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdModuleEdit_ItemClick);
         // 
         // cmdModuleDelete
         // 
         this.cmdModuleDelete.Caption = "Delete decoder";
         this.cmdModuleDelete.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_MODULE_DELETE_32;
         this.cmdModuleDelete.Id = 2;
         this.cmdModuleDelete.Name = "cmdModuleDelete";
         this.cmdModuleDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdModuleDelete_ItemClick);
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
         // grdAccessory
         // 
         this.grdAccessory.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdAccessory.Location = new System.Drawing.Point(5, 5);
         this.grdAccessory.MainView = this.grdAccessoryView;
         this.grdAccessory.MenuManager = this.barManager;
         this.grdAccessory.Name = "grdAccessory";
         this.grdAccessory.Size = new System.Drawing.Size(521, 281);
         this.grdAccessory.TabIndex = 4;
         this.grdAccessory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdAccessoryView});
         // 
         // grdAccessoryView
         // 
         this.grdAccessoryView.GridControl = this.grdAccessory;
         this.grdAccessoryView.Name = "grdAccessoryView";
         this.grdAccessoryView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdAccessoryView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdAccessoryView.OptionsBehavior.Editable = false;
         this.grdAccessoryView.OptionsBehavior.ReadOnly = true;
         this.grdAccessoryView.OptionsCustomization.AllowColumnMoving = false;
         this.grdAccessoryView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdAccessoryView.OptionsView.ShowGroupPanel = false;
         this.grdAccessoryView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grdAccessoryView_RowClick);
         this.grdAccessoryView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdAccessoryView_CustomDrawCell);
         // 
         // tabModules
         // 
         this.tabModules.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabModules.Location = new System.Drawing.Point(0, 47);
         this.tabModules.Name = "tabModules";
         this.tabModules.SelectedTabPage = this.tabModulesAccessories;
         this.tabModules.Size = new System.Drawing.Size(537, 322);
         this.tabModules.TabIndex = 9;
         this.tabModules.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabModulesAccessories,
            this.tabModulesSensors});
         // 
         // tabModulesAccessories
         // 
         this.tabModulesAccessories.Controls.Add(this.grdAccessory);
         this.tabModulesAccessories.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ACCESSORIES_16;
         this.tabModulesAccessories.Name = "tabModulesAccessories";
         this.tabModulesAccessories.Padding = new System.Windows.Forms.Padding(5);
         this.tabModulesAccessories.Size = new System.Drawing.Size(531, 291);
         this.tabModulesAccessories.Text = "Accessories";
         // 
         // tabModulesSensors
         // 
         this.tabModulesSensors.Controls.Add(this.grdSensor);
         this.tabModulesSensors.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SENSORS_16;
         this.tabModulesSensors.Name = "tabModulesSensors";
         this.tabModulesSensors.Padding = new System.Windows.Forms.Padding(5);
         this.tabModulesSensors.Size = new System.Drawing.Size(531, 338);
         this.tabModulesSensors.Text = "Sensors";
         // 
         // grdSensor
         // 
         this.grdSensor.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdSensor.Location = new System.Drawing.Point(5, 5);
         this.grdSensor.MainView = this.grdSensorView;
         this.grdSensor.MenuManager = this.barManager;
         this.grdSensor.Name = "grdSensor";
         this.grdSensor.Size = new System.Drawing.Size(521, 328);
         this.grdSensor.TabIndex = 5;
         this.grdSensor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdSensorView});
         // 
         // grdSensorView
         // 
         this.grdSensorView.GridControl = this.grdSensor;
         this.grdSensorView.Name = "grdSensorView";
         this.grdSensorView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdSensorView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdSensorView.OptionsBehavior.Editable = false;
         this.grdSensorView.OptionsBehavior.ReadOnly = true;
         this.grdSensorView.OptionsCustomization.AllowColumnMoving = false;
         this.grdSensorView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdSensorView.OptionsView.ShowGroupPanel = false;
         this.grdSensorView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grdSensorView_RowClick);
         this.grdSensorView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdSensorView_CustomDrawCell);
         // 
         // panelControl1
         // 
         this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
         this.panelControl1.Controls.Add(this.cmdCancel);
         this.panelControl1.Controls.Add(this.cmdSelect);
         this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panelControl1.Location = new System.Drawing.Point(0, 369);
         this.panelControl1.Name = "panelControl1";
         this.panelControl1.Size = new System.Drawing.Size(537, 47);
         this.panelControl1.TabIndex = 5;
         // 
         // cmdSelect
         // 
         this.cmdSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdSelect.Location = new System.Drawing.Point(369, 12);
         this.cmdSelect.Name = "cmdSelect";
         this.cmdSelect.Size = new System.Drawing.Size(75, 23);
         this.cmdSelect.TabIndex = 0;
         this.cmdSelect.Text = "Select";
         this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.Location = new System.Drawing.Point(450, 12);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 1;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // FrmModuleSelector
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(537, 416);
         this.Controls.Add(this.tabModules);
         this.Controls.Add(this.panelControl1);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmModuleSelector";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Control module selection";
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdAccessory)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdAccessoryView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabModules)).EndInit();
         this.tabModules.ResumeLayout(false);
         this.tabModulesAccessories.ResumeLayout(false);
         this.tabModulesSensors.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdSensor)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdSensorView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
         this.panelControl1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.BarManager barManager;
      private DevExpress.XtraBars.Bar barDecoders;
      private DevExpress.XtraBars.BarButtonItem cmdModuleAdd;
      private DevExpress.XtraBars.BarButtonItem cmdModuleEdit;
      private DevExpress.XtraBars.BarButtonItem cmdModuleDelete;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraGrid.GridControl grdAccessory;
      private DevExpress.XtraGrid.Views.Grid.GridView grdAccessoryView;
      private DevExpress.XtraTab.XtraTabControl tabModules;
      private DevExpress.XtraTab.XtraTabPage tabModulesAccessories;
      private DevExpress.XtraTab.XtraTabPage tabModulesSensors;
      private DevExpress.XtraGrid.GridControl grdSensor;
      private DevExpress.XtraGrid.Views.Grid.GridView grdSensorView;
      private DevExpress.XtraEditors.PanelControl panelControl1;
      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.SimpleButton cmdSelect;
   }
}