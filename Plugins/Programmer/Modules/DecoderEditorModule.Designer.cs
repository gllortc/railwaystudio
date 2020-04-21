namespace Rwm.Studio.Plugins.Designer.Modules
{
   partial class DecoderEditorModule
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
         this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.cmdDataDelete = new DevExpress.XtraBars.BarButtonItem();
         this.cmdBurn = new DevExpress.XtraBars.BarButtonItem();
         this.cmdDecoderSave = new DevExpress.XtraBars.BarButtonItem();
         this.rbpData = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.rpgDecoder = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.rpgReports = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.grpGeneral = new DevExpress.XtraEditors.GroupControl();
         this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
         this.imageComboBoxEdit4 = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
         this.spinEdit4 = new DevExpress.XtraEditors.SpinEdit();
         this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
         this.checkEdit4 = new DevExpress.XtraEditors.CheckEdit();
         this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
         this.imageComboBoxEdit3 = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
         this.spinEdit3 = new DevExpress.XtraEditors.SpinEdit();
         this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
         this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
         this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
         this.imageComboBoxEdit2 = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
         this.spinEdit2 = new DevExpress.XtraEditors.SpinEdit();
         this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
         this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
         this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
         this.imageComboBoxEdit1 = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
         this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
         this.rtfOutput = new DevExpress.XtraRichEdit.RichEditControl();
         ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).BeginInit();
         this.grpGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
         this.groupControl5.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit4.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.spinEdit4.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
         this.groupControl4.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit3.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.spinEdit3.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
         this.groupControl3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit2.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.spinEdit2.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
         this.groupControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
         this.groupControl2.SuspendLayout();
         this.SuspendLayout();
         // 
         // ribbon
         // 
         this.ribbon.ExpandCollapseItem.Id = 0;
         this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.cmdDataDelete,
            this.cmdBurn,
            this.cmdDecoderSave});
         this.ribbon.Location = new System.Drawing.Point(0, 0);
         this.ribbon.MaxItemId = 26;
         this.ribbon.Name = "ribbon";
         this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpData});
         this.ribbon.Size = new System.Drawing.Size(791, 143);
         this.ribbon.StatusBar = this.ribbonStatusBar;
         // 
         // cmdDataDelete
         // 
         this.cmdDataDelete.Caption = "Delete";
         this.cmdDataDelete.Id = 17;
         this.cmdDataDelete.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_DEVICE_DELETE_16;
         this.cmdDataDelete.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_DEVICE_DELETE_32;
         this.cmdDataDelete.Name = "cmdDataDelete";
         this.cmdDataDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdDataDelete_ItemClick);
         // 
         // cmdBurn
         // 
         this.cmdBurn.Caption = "Decoder program";
         this.cmdBurn.Id = 24;
         this.cmdBurn.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_DECODER_PROGRAM_32;
         this.cmdBurn.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_DECODER_PROGRAM_32;
         this.cmdBurn.Name = "cmdBurn";
         this.cmdBurn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CmdBurn_ItemClick);
         // 
         // cmdDecoderSave
         // 
         this.cmdDecoderSave.Caption = "Save";
         this.cmdDecoderSave.Id = 25;
         this.cmdDecoderSave.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_SAVE_16;
         this.cmdDecoderSave.ImageOptions.LargeImage = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_SAVE_32;
         this.cmdDecoderSave.Name = "cmdDecoderSave";
         // 
         // rbpData
         // 
         this.rbpData.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgDecoder,
            this.rpgReports});
         this.rbpData.Name = "rbpData";
         this.rbpData.Text = "Data";
         // 
         // rpgDecoder
         // 
         this.rpgDecoder.ItemLinks.Add(this.cmdDecoderSave);
         this.rpgDecoder.ItemLinks.Add(this.cmdDataDelete);
         this.rpgDecoder.Name = "rpgDecoder";
         this.rpgDecoder.ShowCaptionButton = false;
         this.rpgDecoder.Text = "Decoder";
         // 
         // rpgReports
         // 
         this.rpgReports.ItemLinks.Add(this.cmdBurn);
         this.rpgReports.Name = "rpgReports";
         this.rpgReports.ShowCaptionButton = false;
         this.rpgReports.Text = "Program";
         // 
         // ribbonStatusBar
         // 
         this.ribbonStatusBar.Location = new System.Drawing.Point(0, 600);
         this.ribbonStatusBar.Name = "ribbonStatusBar";
         this.ribbonStatusBar.Ribbon = this.ribbon;
         this.ribbonStatusBar.Size = new System.Drawing.Size(791, 31);
         // 
         // grpGeneral
         // 
         this.grpGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpGeneral.Controls.Add(this.groupControl5);
         this.grpGeneral.Controls.Add(this.groupControl4);
         this.grpGeneral.Controls.Add(this.groupControl3);
         this.grpGeneral.Controls.Add(this.groupControl1);
         this.grpGeneral.Controls.Add(this.txtName);
         this.grpGeneral.Controls.Add(this.lblName);
         this.grpGeneral.Location = new System.Drawing.Point(3, 145);
         this.grpGeneral.Name = "grpGeneral";
         this.grpGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.grpGeneral.Size = new System.Drawing.Size(785, 188);
         this.grpGeneral.TabIndex = 6;
         this.grpGeneral.Text = "General";
         // 
         // groupControl5
         // 
         this.groupControl5.Controls.Add(this.imageComboBoxEdit4);
         this.groupControl5.Controls.Add(this.labelControl7);
         this.groupControl5.Controls.Add(this.spinEdit4);
         this.groupControl5.Controls.Add(this.labelControl8);
         this.groupControl5.Controls.Add(this.checkEdit4);
         this.groupControl5.Location = new System.Drawing.Point(575, 59);
         this.groupControl5.Name = "groupControl5";
         this.groupControl5.Padding = new System.Windows.Forms.Padding(5);
         this.groupControl5.Size = new System.Drawing.Size(164, 115);
         this.groupControl5.TabIndex = 13;
         this.groupControl5.Text = "Output 4";
         // 
         // imageComboBoxEdit4
         // 
         this.imageComboBoxEdit4.Location = new System.Drawing.Point(69, 79);
         this.imageComboBoxEdit4.MenuManager = this.ribbon;
         this.imageComboBoxEdit4.Name = "imageComboBoxEdit4";
         this.imageComboBoxEdit4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.imageComboBoxEdit4.Size = new System.Drawing.Size(85, 20);
         this.imageComboBoxEdit4.TabIndex = 10;
         // 
         // labelControl7
         // 
         this.labelControl7.Location = new System.Drawing.Point(10, 82);
         this.labelControl7.Name = "labelControl7";
         this.labelControl7.Size = new System.Drawing.Size(24, 13);
         this.labelControl7.TabIndex = 9;
         this.labelControl7.Text = "Type";
         // 
         // spinEdit4
         // 
         this.spinEdit4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.spinEdit4.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.spinEdit4.Location = new System.Drawing.Point(69, 53);
         this.spinEdit4.MenuManager = this.ribbon;
         this.spinEdit4.Name = "spinEdit4";
         this.spinEdit4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.spinEdit4.Size = new System.Drawing.Size(85, 20);
         this.spinEdit4.TabIndex = 8;
         // 
         // labelControl8
         // 
         this.labelControl8.Location = new System.Drawing.Point(10, 56);
         this.labelControl8.Name = "labelControl8";
         this.labelControl8.Size = new System.Drawing.Size(39, 13);
         this.labelControl8.TabIndex = 7;
         this.labelControl8.Text = "Address";
         // 
         // checkEdit4
         // 
         this.checkEdit4.Location = new System.Drawing.Point(10, 28);
         this.checkEdit4.MenuManager = this.ribbon;
         this.checkEdit4.Name = "checkEdit4";
         this.checkEdit4.Properties.Caption = "Enabled";
         this.checkEdit4.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
         this.checkEdit4.Size = new System.Drawing.Size(68, 19);
         this.checkEdit4.TabIndex = 6;
         // 
         // groupControl4
         // 
         this.groupControl4.Controls.Add(this.imageComboBoxEdit3);
         this.groupControl4.Controls.Add(this.labelControl5);
         this.groupControl4.Controls.Add(this.spinEdit3);
         this.groupControl4.Controls.Add(this.labelControl6);
         this.groupControl4.Controls.Add(this.checkEdit3);
         this.groupControl4.Location = new System.Drawing.Point(405, 59);
         this.groupControl4.Name = "groupControl4";
         this.groupControl4.Padding = new System.Windows.Forms.Padding(5);
         this.groupControl4.Size = new System.Drawing.Size(164, 115);
         this.groupControl4.TabIndex = 12;
         this.groupControl4.Text = "Output 3";
         // 
         // imageComboBoxEdit3
         // 
         this.imageComboBoxEdit3.Location = new System.Drawing.Point(69, 79);
         this.imageComboBoxEdit3.MenuManager = this.ribbon;
         this.imageComboBoxEdit3.Name = "imageComboBoxEdit3";
         this.imageComboBoxEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.imageComboBoxEdit3.Size = new System.Drawing.Size(85, 20);
         this.imageComboBoxEdit3.TabIndex = 10;
         // 
         // labelControl5
         // 
         this.labelControl5.Location = new System.Drawing.Point(10, 82);
         this.labelControl5.Name = "labelControl5";
         this.labelControl5.Size = new System.Drawing.Size(24, 13);
         this.labelControl5.TabIndex = 9;
         this.labelControl5.Text = "Type";
         // 
         // spinEdit3
         // 
         this.spinEdit3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.spinEdit3.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.spinEdit3.Location = new System.Drawing.Point(69, 53);
         this.spinEdit3.MenuManager = this.ribbon;
         this.spinEdit3.Name = "spinEdit3";
         this.spinEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.spinEdit3.Size = new System.Drawing.Size(85, 20);
         this.spinEdit3.TabIndex = 8;
         // 
         // labelControl6
         // 
         this.labelControl6.Location = new System.Drawing.Point(10, 56);
         this.labelControl6.Name = "labelControl6";
         this.labelControl6.Size = new System.Drawing.Size(39, 13);
         this.labelControl6.TabIndex = 7;
         this.labelControl6.Text = "Address";
         // 
         // checkEdit3
         // 
         this.checkEdit3.Location = new System.Drawing.Point(10, 28);
         this.checkEdit3.MenuManager = this.ribbon;
         this.checkEdit3.Name = "checkEdit3";
         this.checkEdit3.Properties.Caption = "Enabled";
         this.checkEdit3.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
         this.checkEdit3.Size = new System.Drawing.Size(68, 19);
         this.checkEdit3.TabIndex = 6;
         // 
         // groupControl3
         // 
         this.groupControl3.Controls.Add(this.imageComboBoxEdit2);
         this.groupControl3.Controls.Add(this.labelControl3);
         this.groupControl3.Controls.Add(this.spinEdit2);
         this.groupControl3.Controls.Add(this.labelControl4);
         this.groupControl3.Controls.Add(this.checkEdit2);
         this.groupControl3.Location = new System.Drawing.Point(235, 59);
         this.groupControl3.Name = "groupControl3";
         this.groupControl3.Padding = new System.Windows.Forms.Padding(5);
         this.groupControl3.Size = new System.Drawing.Size(164, 115);
         this.groupControl3.TabIndex = 11;
         this.groupControl3.Text = "Output 2";
         // 
         // imageComboBoxEdit2
         // 
         this.imageComboBoxEdit2.Location = new System.Drawing.Point(69, 79);
         this.imageComboBoxEdit2.MenuManager = this.ribbon;
         this.imageComboBoxEdit2.Name = "imageComboBoxEdit2";
         this.imageComboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.imageComboBoxEdit2.Size = new System.Drawing.Size(85, 20);
         this.imageComboBoxEdit2.TabIndex = 10;
         // 
         // labelControl3
         // 
         this.labelControl3.Location = new System.Drawing.Point(10, 82);
         this.labelControl3.Name = "labelControl3";
         this.labelControl3.Size = new System.Drawing.Size(24, 13);
         this.labelControl3.TabIndex = 9;
         this.labelControl3.Text = "Type";
         // 
         // spinEdit2
         // 
         this.spinEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.spinEdit2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.spinEdit2.Location = new System.Drawing.Point(69, 53);
         this.spinEdit2.MenuManager = this.ribbon;
         this.spinEdit2.Name = "spinEdit2";
         this.spinEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.spinEdit2.Size = new System.Drawing.Size(85, 20);
         this.spinEdit2.TabIndex = 8;
         // 
         // labelControl4
         // 
         this.labelControl4.Location = new System.Drawing.Point(10, 56);
         this.labelControl4.Name = "labelControl4";
         this.labelControl4.Size = new System.Drawing.Size(39, 13);
         this.labelControl4.TabIndex = 7;
         this.labelControl4.Text = "Address";
         // 
         // checkEdit2
         // 
         this.checkEdit2.Location = new System.Drawing.Point(10, 28);
         this.checkEdit2.MenuManager = this.ribbon;
         this.checkEdit2.Name = "checkEdit2";
         this.checkEdit2.Properties.Caption = "Enabled";
         this.checkEdit2.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
         this.checkEdit2.Size = new System.Drawing.Size(68, 19);
         this.checkEdit2.TabIndex = 6;
         // 
         // groupControl1
         // 
         this.groupControl1.Controls.Add(this.imageComboBoxEdit1);
         this.groupControl1.Controls.Add(this.labelControl2);
         this.groupControl1.Controls.Add(this.spinEdit1);
         this.groupControl1.Controls.Add(this.labelControl1);
         this.groupControl1.Controls.Add(this.checkEdit1);
         this.groupControl1.Location = new System.Drawing.Point(65, 59);
         this.groupControl1.Name = "groupControl1";
         this.groupControl1.Padding = new System.Windows.Forms.Padding(5);
         this.groupControl1.Size = new System.Drawing.Size(164, 115);
         this.groupControl1.TabIndex = 7;
         this.groupControl1.Text = "Output 1";
         // 
         // imageComboBoxEdit1
         // 
         this.imageComboBoxEdit1.Location = new System.Drawing.Point(69, 79);
         this.imageComboBoxEdit1.MenuManager = this.ribbon;
         this.imageComboBoxEdit1.Name = "imageComboBoxEdit1";
         this.imageComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.imageComboBoxEdit1.Size = new System.Drawing.Size(85, 20);
         this.imageComboBoxEdit1.TabIndex = 10;
         // 
         // labelControl2
         // 
         this.labelControl2.Location = new System.Drawing.Point(10, 82);
         this.labelControl2.Name = "labelControl2";
         this.labelControl2.Size = new System.Drawing.Size(24, 13);
         this.labelControl2.TabIndex = 9;
         this.labelControl2.Text = "Type";
         // 
         // spinEdit1
         // 
         this.spinEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.spinEdit1.Location = new System.Drawing.Point(69, 53);
         this.spinEdit1.MenuManager = this.ribbon;
         this.spinEdit1.Name = "spinEdit1";
         this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.spinEdit1.Size = new System.Drawing.Size(85, 20);
         this.spinEdit1.TabIndex = 8;
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(10, 56);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(39, 13);
         this.labelControl1.TabIndex = 7;
         this.labelControl1.Text = "Address";
         // 
         // checkEdit1
         // 
         this.checkEdit1.Location = new System.Drawing.Point(10, 28);
         this.checkEdit1.MenuManager = this.ribbon;
         this.checkEdit1.Name = "checkEdit1";
         this.checkEdit1.Properties.Caption = "Enabled";
         this.checkEdit1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
         this.checkEdit1.Size = new System.Drawing.Size(68, 19);
         this.checkEdit1.TabIndex = 6;
         // 
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Location = new System.Drawing.Point(65, 33);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(705, 20);
         this.txtName.TabIndex = 5;
         // 
         // lblName
         // 
         this.lblName.Location = new System.Drawing.Point(15, 36);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(27, 13);
         this.lblName.TabIndex = 4;
         this.lblName.Text = "Name";
         // 
         // groupControl2
         // 
         this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupControl2.CaptionImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_ARDUINO_16;
         this.groupControl2.Controls.Add(this.rtfOutput);
         this.groupControl2.Location = new System.Drawing.Point(3, 339);
         this.groupControl2.Name = "groupControl2";
         this.groupControl2.Padding = new System.Windows.Forms.Padding(5);
         this.groupControl2.Size = new System.Drawing.Size(785, 255);
         this.groupControl2.TabIndex = 10;
         this.groupControl2.Text = "Arduino compiler output";
         // 
         // rtfOutput
         // 
         this.rtfOutput.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
         this.rtfOutput.Appearance.Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.rtfOutput.Appearance.Text.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.rtfOutput.Appearance.Text.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.rtfOutput.Appearance.Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
         this.rtfOutput.Appearance.Text.Options.UseBackColor = true;
         this.rtfOutput.Appearance.Text.Options.UseFont = true;
         this.rtfOutput.Appearance.Text.Options.UseForeColor = true;
         this.rtfOutput.Dock = System.Windows.Forms.DockStyle.Fill;
         this.rtfOutput.EnableToolTips = false;
         this.rtfOutput.Location = new System.Drawing.Point(7, 28);
         this.rtfOutput.MenuManager = this.ribbon;
         this.rtfOutput.Name = "rtfOutput";
         this.rtfOutput.Options.DocumentCapabilities.Bookmarks = DevExpress.XtraRichEdit.DocumentCapability.Disabled;
         this.rtfOutput.Options.DocumentCapabilities.Comments = DevExpress.XtraRichEdit.DocumentCapability.Disabled;
         this.rtfOutput.Options.DocumentCapabilities.EndNotes = DevExpress.XtraRichEdit.DocumentCapability.Disabled;
         this.rtfOutput.Options.DocumentCapabilities.Fields = DevExpress.XtraRichEdit.DocumentCapability.Disabled;
         this.rtfOutput.Options.DocumentCapabilities.FloatingObjects = DevExpress.XtraRichEdit.DocumentCapability.Disabled;
         this.rtfOutput.Options.DocumentCapabilities.FootNotes = DevExpress.XtraRichEdit.DocumentCapability.Disabled;
         this.rtfOutput.Options.DocumentCapabilities.HeadersFooters = DevExpress.XtraRichEdit.DocumentCapability.Disabled;
         this.rtfOutput.Options.DocumentCapabilities.InlinePictures = DevExpress.XtraRichEdit.DocumentCapability.Disabled;
         this.rtfOutput.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
         this.rtfOutput.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
         this.rtfOutput.ReadOnly = true;
         this.rtfOutput.Size = new System.Drawing.Size(771, 220);
         this.rtfOutput.TabIndex = 0;
         this.rtfOutput.Text = "richEditControl1";
         // 
         // DecoderEditorModule
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(791, 631);
         this.Controls.Add(this.groupControl2);
         this.Controls.Add(this.grpGeneral);
         this.Controls.Add(this.ribbonStatusBar);
         this.Controls.Add(this.ribbon);
         this.Name = "DecoderEditorModule";
         this.Ribbon = this.ribbon;
         this.StatusBar = this.ribbonStatusBar;
         this.Text = "Decoder programmer";
         this.Load += new System.EventHandler(this.DecoderEditorModule_Load);
         ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).EndInit();
         this.grpGeneral.ResumeLayout(false);
         this.grpGeneral.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
         this.groupControl5.ResumeLayout(false);
         this.groupControl5.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit4.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.spinEdit4.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
         this.groupControl4.ResumeLayout(false);
         this.groupControl4.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit3.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.spinEdit3.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
         this.groupControl3.ResumeLayout(false);
         this.groupControl3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit2.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.spinEdit2.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
         this.groupControl1.ResumeLayout(false);
         this.groupControl1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
         this.groupControl2.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
      private DevExpress.XtraBars.Ribbon.RibbonPage rbpData;
      private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgDecoder;
      private DevExpress.XtraBars.BarButtonItem cmdDataDelete;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgReports;
        private DevExpress.XtraBars.BarButtonItem cmdBurn;
        private DevExpress.XtraBars.BarButtonItem cmdDecoderSave;
        private DevExpress.XtraEditors.GroupControl grpGeneral;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEdit4;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SpinEdit spinEdit4;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.CheckEdit checkEdit4;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEdit3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SpinEdit spinEdit3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.CheckEdit checkEdit3;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit spinEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraRichEdit.RichEditControl rtfOutput;
    }
}