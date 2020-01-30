namespace Rwm.Studio.Plugins.Control.Controls
{
   partial class SoundManagerControl
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
         this.grdData = new DevExpress.XtraGrid.GridControl();
         this.grdDataView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.barManager = new DevExpress.XtraBars.BarManager(this.components);
         this.barRoutes = new DevExpress.XtraBars.Bar();
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
         this.grdData.Location = new System.Drawing.Point(0, 31);
         this.grdData.MainView = this.grdDataView;
         this.grdData.Name = "grdData";
         this.grdData.Size = new System.Drawing.Size(348, 379);
         this.grdData.TabIndex = 4;
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
         this.grdDataView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdDataView.OptionsView.ShowGroupPanel = false;
         this.grdDataView.OptionsView.ShowIndicator = false;
         this.grdDataView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdDataView_CustomDrawCell);
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
            this.cmdSoundAdd,
            this.cmdSoundDelete,
            this.cmdSoundPlay});
         this.barManager.MaxItemId = 10;
         // 
         // barRoutes
         // 
         this.barRoutes.BarName = "Routes";
         this.barRoutes.DockCol = 0;
         this.barRoutes.DockRow = 0;
         this.barRoutes.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.barRoutes.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdSoundAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdSoundDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdSoundPlay, true)});
         this.barRoutes.OptionsBar.AllowQuickCustomization = false;
         this.barRoutes.OptionsBar.DisableClose = true;
         this.barRoutes.OptionsBar.DisableCustomization = true;
         this.barRoutes.OptionsBar.DrawBorder = false;
         this.barRoutes.OptionsBar.DrawDragBorder = false;
         this.barRoutes.OptionsBar.UseWholeRow = true;
         this.barRoutes.Text = "Herramientas";
         // 
         // cmdSoundAdd
         // 
         this.cmdSoundAdd.Caption = "New route";
         this.cmdSoundAdd.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SOUND_ADD_16;
         this.cmdSoundAdd.Id = 0;
         this.cmdSoundAdd.LargeGlyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_ADD_32;
         this.cmdSoundAdd.Name = "cmdSoundAdd";
         this.cmdSoundAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdSoundAdd_ItemClick);
         // 
         // cmdSoundDelete
         // 
         this.cmdSoundDelete.Caption = "Delete";
         this.cmdSoundDelete.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SOUND_DELETE_16;
         this.cmdSoundDelete.Id = 3;
         this.cmdSoundDelete.LargeGlyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_DELETE_32;
         this.cmdSoundDelete.Name = "cmdSoundDelete";
         this.cmdSoundDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdSoundDelete_ItemClick);
         // 
         // cmdSoundPlay
         // 
         this.cmdSoundPlay.Caption = "Play sound";
         this.cmdSoundPlay.Glyph = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SOUND_PLAY_16;
         this.cmdSoundPlay.Id = 9;
         this.cmdSoundPlay.Name = "cmdSoundPlay";
         this.cmdSoundPlay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdSoundPlay_ItemClick);
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
         // SoundManagerControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.Controls.Add(this.grdData);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.Name = "SoundManagerControl";
         this.Size = new System.Drawing.Size(348, 410);
         ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraGrid.GridControl grdData;
      private DevExpress.XtraGrid.Views.Grid.GridView grdDataView;
      private DevExpress.XtraBars.BarManager barManager;
      private DevExpress.XtraBars.Bar barRoutes;
      private DevExpress.XtraBars.BarButtonItem cmdSoundAdd;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraBars.BarButtonItem cmdSoundDelete;
      private DevExpress.XtraBars.BarButtonItem cmdSoundPlay;
   }
}
