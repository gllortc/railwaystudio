namespace Rwm.Studio.Plugins.Control.Views
{
   partial class FrmSoundManager
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
         this.grdData = new DevExpress.XtraGrid.GridControl();
         this.grdDataView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.barDecoders = new DevExpress.XtraBars.Bar();
         this.barManager = new DevExpress.XtraBars.BarManager(this.components);
         this.barTheme = new DevExpress.XtraBars.Bar();
         this.cmdSoundAdd = new DevExpress.XtraBars.BarButtonItem();
         this.cmdSoundDelete = new DevExpress.XtraBars.BarButtonItem();
         this.cmdSoundPlay = new DevExpress.XtraBars.BarButtonItem();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
         this.SuspendLayout();
         // 
         // grdData
         // 
         this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdData.Location = new System.Drawing.Point(0, 47);
         this.grdData.MainView = this.grdDataView;
         this.grdData.Name = "grdData";
         this.grdData.Size = new System.Drawing.Size(537, 369);
         this.grdData.TabIndex = 5;
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
         this.grdDataView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdDataView.OptionsView.ShowGroupPanel = false;
         // 
         // barDecoders
         // 
         this.barDecoders.BarName = "Decodres";
         this.barDecoders.DockCol = 0;
         this.barDecoders.DockRow = 0;
         this.barDecoders.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.barDecoders.OptionsBar.AllowQuickCustomization = false;
         this.barDecoders.OptionsBar.DrawDragBorder = false;
         this.barDecoders.OptionsBar.UseWholeRow = true;
         this.barDecoders.Text = "Herramientas";
         // 
         // barManager
         // 
         this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTheme});
         this.barManager.DockControls.Add(this.barDockControlTop);
         this.barManager.DockControls.Add(this.barDockControlBottom);
         this.barManager.DockControls.Add(this.barDockControlLeft);
         this.barManager.DockControls.Add(this.barDockControlRight);
         this.barManager.Form = this;
         this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.cmdSoundAdd,
            this.cmdSoundDelete,
            this.cmdSoundPlay});
         this.barManager.MaxItemId = 5;
         // 
         // barTheme
         // 
         this.barTheme.BarName = "Decodres";
         this.barTheme.DockCol = 0;
         this.barTheme.DockRow = 0;
         this.barTheme.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.barTheme.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdSoundAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdSoundDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdSoundPlay, true)});
         this.barTheme.OptionsBar.AllowQuickCustomization = false;
         this.barTheme.OptionsBar.DrawDragBorder = false;
         this.barTheme.OptionsBar.UseWholeRow = true;
         this.barTheme.Text = "Herramientas";
         // 
         // cmdSoundAdd
         // 
         this.cmdSoundAdd.Caption = "Set theme";
         this.cmdSoundAdd.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.sound_add_32;
         this.cmdSoundAdd.Id = 0;
         this.cmdSoundAdd.Name = "cmdSoundAdd";
         this.cmdSoundAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdSoundAdd_ItemClick);
         // 
         // cmdSoundDelete
         // 
         this.cmdSoundDelete.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.sound_delete_32;
         this.cmdSoundDelete.Id = 3;
         this.cmdSoundDelete.Name = "cmdSoundDelete";
         this.cmdSoundDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdSoundDelete_ItemClick);
         // 
         // cmdSoundPlay
         // 
         this.cmdSoundPlay.Caption = "Play";
         this.cmdSoundPlay.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.control_play_blue_32;
         this.cmdSoundPlay.Id = 4;
         this.cmdSoundPlay.Name = "cmdSoundPlay";
         this.cmdSoundPlay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdSoundPlay_ItemClick);
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
         // FrmSoundManager
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(537, 416);
         this.Controls.Add(this.grdData);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmSoundManager";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Sound manager";
         ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraGrid.GridControl grdData;
      private DevExpress.XtraGrid.Views.Grid.GridView grdDataView;
      private DevExpress.XtraBars.Bar barDecoders;
      private DevExpress.XtraBars.BarManager barManager;
      private DevExpress.XtraBars.Bar barTheme;
      private DevExpress.XtraBars.BarButtonItem cmdSoundAdd;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraBars.BarButtonItem cmdSoundDelete;
      private DevExpress.XtraBars.BarButtonItem cmdSoundPlay;
   }
}