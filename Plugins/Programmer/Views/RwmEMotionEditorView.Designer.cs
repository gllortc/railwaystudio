namespace Rwm.Studio.Plugins.Designer.Views
{
   partial class RwmEMotionEditorView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RwmEMotionEditorView));
         this.txtNotes = new DevExpress.XtraEditors.MemoEdit();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdOk = new DevExpress.XtraEditors.SimpleButton();
         this.tabDecoder = new DevExpress.XtraTab.XtraTabControl();
         this.tabDecoderGeneral = new DevExpress.XtraTab.XtraTabPage();
         this.grpGeneral = new DevExpress.XtraEditors.GroupControl();
         this.cboSection = new Rwm.Studio.Plugins.Common.Controls.SectionImageComboBoxEdit();
         this.lblSection = new DevExpress.XtraEditors.LabelControl();
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         this.cboModel = new DevExpress.XtraEditors.ComboBoxEdit();
         this.lblModel = new DevExpress.XtraEditors.LabelControl();
         this.grpDigital = new DevExpress.XtraEditors.GroupControl();
         this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
         this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
         this.barEffects = new DevExpress.XtraBars.Bar();
         this.cmdEffectAdd = new DevExpress.XtraBars.BarButtonItem();
         this.cmdEffectEdit = new DevExpress.XtraBars.BarButtonItem();
         this.cmdEffectDelete = new DevExpress.XtraBars.BarButtonItem();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.grdConfig = new DevExpress.XtraGrid.GridControl();
         this.grdConfigView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.tabDecoderNotes = new DevExpress.XtraTab.XtraTabPage();
         this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabDecoder)).BeginInit();
         this.tabDecoder.SuspendLayout();
         this.tabDecoderGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).BeginInit();
         this.grpGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboSection.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboModel.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpDigital)).BeginInit();
         this.grpDigital.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdConfig)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdConfigView)).BeginInit();
         this.tabDecoderNotes.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // txtNotes
         // 
         this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
         this.txtNotes.Location = new System.Drawing.Point(5, 5);
         this.txtNotes.Name = "txtNotes";
         this.txtNotes.Size = new System.Drawing.Size(493, 525);
         this.txtNotes.TabIndex = 204;
         // 
         // lblName
         // 
         this.lblName.Location = new System.Drawing.Point(15, 36);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(27, 13);
         this.lblName.TabIndex = 0;
         this.lblName.Text = "Name";
         // 
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Location = new System.Drawing.Point(109, 33);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(353, 20);
         this.txtName.TabIndex = 1;
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(446, 484);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 200;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
         // 
         // cmdOk
         // 
         this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOk.Location = new System.Drawing.Point(365, 484);
         this.cmdOk.Name = "cmdOk";
         this.cmdOk.Size = new System.Drawing.Size(75, 23);
         this.cmdOk.TabIndex = 100;
         this.cmdOk.Text = "OK";
         this.cmdOk.Click += new System.EventHandler(this.CmdOk_Click);
         // 
         // tabDecoder
         // 
         this.tabDecoder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabDecoder.Location = new System.Drawing.Point(12, 12);
         this.tabDecoder.Name = "tabDecoder";
         this.tabDecoder.SelectedTabPage = this.tabDecoderGeneral;
         this.tabDecoder.Size = new System.Drawing.Size(509, 466);
         this.tabDecoder.TabIndex = 8;
         this.tabDecoder.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabDecoderGeneral,
            this.tabDecoderNotes});
         // 
         // tabDecoderGeneral
         // 
         this.tabDecoderGeneral.Controls.Add(this.grpGeneral);
         this.tabDecoderGeneral.Controls.Add(this.grpDigital);
         this.tabDecoderGeneral.Name = "tabDecoderGeneral";
         this.tabDecoderGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.tabDecoderGeneral.Size = new System.Drawing.Size(503, 438);
         this.tabDecoderGeneral.Text = "Properties";
         // 
         // grpGeneral
         // 
         this.grpGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpGeneral.Controls.Add(this.cboSection);
         this.grpGeneral.Controls.Add(this.lblSection);
         this.grpGeneral.Controls.Add(this.cboModel);
         this.grpGeneral.Controls.Add(this.lblName);
         this.grpGeneral.Controls.Add(this.txtName);
         this.grpGeneral.Controls.Add(this.lblModel);
         this.grpGeneral.Location = new System.Drawing.Point(13, 13);
         this.grpGeneral.Name = "grpGeneral";
         this.grpGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.grpGeneral.Size = new System.Drawing.Size(477, 123);
         this.grpGeneral.TabIndex = 216;
         this.grpGeneral.Text = "General";
         // 
         // cboSection
         // 
         this.cboSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboSection.Location = new System.Drawing.Point(109, 85);
         this.cboSection.Name = "cboSection";
         this.cboSection.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboSection.Size = new System.Drawing.Size(353, 20);
         this.cboSection.TabIndex = 9;
         // 
         // lblSection
         // 
         this.lblSection.Location = new System.Drawing.Point(15, 88);
         this.lblSection.Name = "lblSection";
         this.lblSection.Size = new System.Drawing.Size(84, 13);
         this.lblSection.TabIndex = 8;
         this.lblSection.Text = "Location / Module";
         // 
         // imageList
         // 
         this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
         this.imageList.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList.Images.SetKeyName(0, "ICO_OUTPUT");
         this.imageList.Images.SetKeyName(1, "ICO_MANUFACTURER");
         this.imageList.Images.SetKeyName(2, "ICO_MODEL");
         // 
         // cboModel
         // 
         this.cboModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboModel.Location = new System.Drawing.Point(109, 59);
         this.cboModel.Name = "cboModel";
         this.cboModel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboModel.Size = new System.Drawing.Size(353, 20);
         this.cboModel.TabIndex = 5;
         // 
         // lblModel
         // 
         this.lblModel.Location = new System.Drawing.Point(15, 62);
         this.lblModel.Name = "lblModel";
         this.lblModel.Size = new System.Drawing.Size(78, 13);
         this.lblModel.TabIndex = 4;
         this.lblModel.Text = "Model / Ref / PN";
         // 
         // grpDigital
         // 
         this.grpDigital.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpDigital.Controls.Add(this.standaloneBarDockControl1);
         this.grpDigital.Controls.Add(this.grdConfig);
         this.grpDigital.Location = new System.Drawing.Point(13, 142);
         this.grpDigital.Name = "grpDigital";
         this.grpDigital.Size = new System.Drawing.Size(477, 283);
         this.grpDigital.TabIndex = 215;
         this.grpDigital.Text = "Effects";
         // 
         // standaloneBarDockControl1
         // 
         this.standaloneBarDockControl1.CausesValidation = false;
         this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
         this.standaloneBarDockControl1.Location = new System.Drawing.Point(2, 20);
         this.standaloneBarDockControl1.Manager = this.barManager1;
         this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
         this.standaloneBarDockControl1.Size = new System.Drawing.Size(473, 32);
         this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
         // 
         // barManager1
         // 
         this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barEffects});
         this.barManager1.DockControls.Add(this.barDockControlTop);
         this.barManager1.DockControls.Add(this.barDockControlBottom);
         this.barManager1.DockControls.Add(this.barDockControlLeft);
         this.barManager1.DockControls.Add(this.barDockControlRight);
         this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
         this.barManager1.Form = this;
         this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.cmdEffectAdd,
            this.cmdEffectEdit,
            this.cmdEffectDelete});
         this.barManager1.MaxItemId = 3;
         // 
         // barEffects
         // 
         this.barEffects.BarName = "Personalizada 5";
         this.barEffects.DockCol = 0;
         this.barEffects.DockRow = 0;
         this.barEffects.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
         this.barEffects.FloatLocation = new System.Drawing.Point(1877, 354);
         this.barEffects.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdEffectAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdEffectEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdEffectDelete)});
         this.barEffects.OptionsBar.AllowQuickCustomization = false;
         this.barEffects.OptionsBar.DisableClose = true;
         this.barEffects.OptionsBar.DisableCustomization = true;
         this.barEffects.OptionsBar.DrawBorder = false;
         this.barEffects.OptionsBar.DrawDragBorder = false;
         this.barEffects.OptionsBar.UseWholeRow = true;
         this.barEffects.StandaloneBarDockControl = this.standaloneBarDockControl1;
         this.barEffects.Text = "Personalizada 5";
         // 
         // cmdEffectAdd
         // 
         this.cmdEffectAdd.Caption = "New...";
         this.cmdEffectAdd.Id = 0;
         this.cmdEffectAdd.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.add_16;
         this.cmdEffectAdd.Name = "cmdEffectAdd";
         this.cmdEffectAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
         // 
         // cmdEffectEdit
         // 
         this.cmdEffectEdit.Caption = "Modify";
         this.cmdEffectEdit.Id = 1;
         this.cmdEffectEdit.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.pencil_16;
         this.cmdEffectEdit.Name = "cmdEffectEdit";
         // 
         // cmdEffectDelete
         // 
         this.cmdEffectDelete.Caption = "Remove";
         this.cmdEffectDelete.Id = 2;
         this.cmdEffectDelete.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.cross_16;
         this.cmdEffectDelete.Name = "cmdEffectDelete";
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
         this.barDockControlTop.Manager = this.barManager1;
         this.barDockControlTop.Size = new System.Drawing.Size(533, 0);
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point(0, 519);
         this.barDockControlBottom.Manager = this.barManager1;
         this.barDockControlBottom.Size = new System.Drawing.Size(533, 0);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
         this.barDockControlLeft.Manager = this.barManager1;
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 519);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(533, 0);
         this.barDockControlRight.Manager = this.barManager1;
         this.barDockControlRight.Size = new System.Drawing.Size(0, 519);
         // 
         // grdConfig
         // 
         this.grdConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grdConfig.Location = new System.Drawing.Point(5, 58);
         this.grdConfig.MainView = this.grdConfigView;
         this.grdConfig.Name = "grdConfig";
         this.grdConfig.Size = new System.Drawing.Size(467, 220);
         this.grdConfig.TabIndex = 0;
         this.grdConfig.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdConfigView});
         // 
         // grdConfigView
         // 
         this.grdConfigView.GridControl = this.grdConfig;
         this.grdConfigView.Name = "grdConfigView";
         this.grdConfigView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdConfigView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdConfigView.OptionsBehavior.Editable = false;
         this.grdConfigView.OptionsBehavior.ReadOnly = true;
         this.grdConfigView.OptionsView.ShowGroupPanel = false;
         // 
         // tabDecoderNotes
         // 
         this.tabDecoderNotes.Controls.Add(this.txtNotes);
         this.tabDecoderNotes.Name = "tabDecoderNotes";
         this.tabDecoderNotes.Padding = new System.Windows.Forms.Padding(5);
         this.tabDecoderNotes.Size = new System.Drawing.Size(503, 535);
         this.tabDecoderNotes.Text = "Notes";
         // 
         // labelControl5
         // 
         this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.labelControl5.Location = new System.Drawing.Point(34, 492);
         this.labelControl5.Name = "labelControl5";
         this.labelControl5.Size = new System.Drawing.Size(97, 13);
         this.labelControl5.TabIndex = 201;
         this.labelControl5.Text = "Powered by Arduino";
         // 
         // pictureBox1
         // 
         this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.pictureBox1.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_ARDUINO_16;
         this.pictureBox1.Location = new System.Drawing.Point(12, 491);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(16, 16);
         this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
         this.pictureBox1.TabIndex = 202;
         this.pictureBox1.TabStop = false;
         // 
         // RwmEMotionEditorView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(533, 519);
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this.labelControl5);
         this.Controls.Add(this.tabDecoder);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.cmdOk);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "RwmEMotionEditorView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Railwaymania EasyConnect eMotion editor";
         this.Activated += new System.EventHandler(this.FrmDecoderEditor_Activated);
         ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabDecoder)).EndInit();
         this.tabDecoder.ResumeLayout(false);
         this.tabDecoderGeneral.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).EndInit();
         this.grpGeneral.ResumeLayout(false);
         this.grpGeneral.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboSection.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboModel.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpDigital)).EndInit();
         this.grpDigital.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdConfig)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdConfigView)).EndInit();
         this.tabDecoderNotes.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.MemoEdit txtNotes;
      private DevExpress.XtraEditors.LabelControl lblName;
      private DevExpress.XtraEditors.TextEdit txtName;
      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.SimpleButton cmdOk;
      private DevExpress.XtraTab.XtraTabControl tabDecoder;
      private DevExpress.XtraTab.XtraTabPage tabDecoderGeneral;
      private DevExpress.XtraEditors.LabelControl lblModel;
      private DevExpress.XtraTab.XtraTabPage tabDecoderNotes;
      private DevExpress.XtraEditors.GroupControl grpGeneral;
      private DevExpress.XtraEditors.GroupControl grpDigital;
      private System.Windows.Forms.ImageList imageList;
      private DevExpress.XtraEditors.ComboBoxEdit cboModel;
      private DevExpress.XtraEditors.LabelControl lblSection;
      private Common.Controls.SectionImageComboBoxEdit cboSection;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.PictureBox pictureBox1;
      private DevExpress.XtraGrid.GridControl grdConfig;
      private DevExpress.XtraGrid.Views.Grid.GridView grdConfigView;
      private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
      private DevExpress.XtraBars.BarManager barManager1;
      private DevExpress.XtraBars.Bar barEffects;
      private DevExpress.XtraBars.BarButtonItem cmdEffectAdd;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraBars.BarButtonItem cmdEffectEdit;
      private DevExpress.XtraBars.BarButtonItem cmdEffectDelete;
   }
}