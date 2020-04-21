namespace Rwm.Studio.Plugins.Control.Views
{
   partial class AccessoryDecoderEditorView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessoryDecoderEditorView));
         this.txtNotes = new DevExpress.XtraEditors.MemoEdit();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdOk = new DevExpress.XtraEditors.SimpleButton();
         this.tabDecoder = new DevExpress.XtraTab.XtraTabControl();
         this.tabDecoderGeneral = new DevExpress.XtraTab.XtraTabPage();
         this.grdConnect = new DevExpress.XtraGrid.GridControl();
         this.grdConnectView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.grpGeneral = new DevExpress.XtraEditors.GroupControl();
         this.lblSection = new DevExpress.XtraEditors.LabelControl();
         this.cboManufacturer = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.imageList = new System.Windows.Forms.ImageList();
         this.cboModel = new DevExpress.XtraEditors.ComboBoxEdit();
         this.lblModel = new DevExpress.XtraEditors.LabelControl();
         this.lblManufacturer = new DevExpress.XtraEditors.LabelControl();
         this.grpDigital = new DevExpress.XtraEditors.GroupControl();
         this.lblAddress = new DevExpress.XtraEditors.LabelControl();
         this.nudAddress = new DevExpress.XtraEditors.SpinEdit();
         this.lblOutputs = new DevExpress.XtraEditors.LabelControl();
         this.txtOutputs = new DevExpress.XtraEditors.SpinEdit();
         this.tabDecoderNotes = new DevExpress.XtraTab.XtraTabPage();
         this.cboSection = new Rwm.Studio.Plugins.Common.Controls.SectionImageComboBoxEdit();
         ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabDecoder)).BeginInit();
         this.tabDecoder.SuspendLayout();
         this.tabDecoderGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdConnect)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdConnectView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).BeginInit();
         this.grpGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboManufacturer.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboModel.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpDigital)).BeginInit();
         this.grpDigital.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.nudAddress.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtOutputs.Properties)).BeginInit();
         this.tabDecoderNotes.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboSection.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // txtNotes
         // 
         this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
         this.txtNotes.Location = new System.Drawing.Point(5, 5);
         this.txtNotes.Name = "txtNotes";
         this.txtNotes.Size = new System.Drawing.Size(508, 426);
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
         this.txtName.Location = new System.Drawing.Point(105, 33);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(181, 20);
         this.txtName.TabIndex = 1;
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(461, 482);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 200;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
         // 
         // cmdOk
         // 
         this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOk.Location = new System.Drawing.Point(380, 482);
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
         this.tabDecoder.Size = new System.Drawing.Size(524, 464);
         this.tabDecoder.TabIndex = 8;
         this.tabDecoder.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabDecoderGeneral,
            this.tabDecoderNotes});
         // 
         // tabDecoderGeneral
         // 
         this.tabDecoderGeneral.Controls.Add(this.grdConnect);
         this.tabDecoderGeneral.Controls.Add(this.grpGeneral);
         this.tabDecoderGeneral.Controls.Add(this.grpDigital);
         this.tabDecoderGeneral.Name = "tabDecoderGeneral";
         this.tabDecoderGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.tabDecoderGeneral.Size = new System.Drawing.Size(518, 436);
         this.tabDecoderGeneral.Text = "Properties";
         // 
         // grdConnect
         // 
         this.grdConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grdConnect.Location = new System.Drawing.Point(13, 167);
         this.grdConnect.MainView = this.grdConnectView;
         this.grdConnect.Name = "grdConnect";
         this.grdConnect.Size = new System.Drawing.Size(492, 256);
         this.grdConnect.TabIndex = 5;
         this.grdConnect.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdConnectView});
         // 
         // grdConnectView
         // 
         this.grdConnectView.GridControl = this.grdConnect;
         this.grdConnectView.Name = "grdConnectView";
         this.grdConnectView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdConnectView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdConnectView.OptionsCustomization.AllowColumnMoving = false;
         this.grdConnectView.OptionsCustomization.AllowFilter = false;
         this.grdConnectView.OptionsCustomization.AllowSort = false;
         this.grdConnectView.OptionsFilter.AllowFilterEditor = false;
         this.grdConnectView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdConnectView.OptionsSelection.EnableAppearanceFocusedRow = false;
         this.grdConnectView.OptionsSelection.EnableAppearanceHideSelection = false;
         this.grdConnectView.OptionsView.ShowGroupPanel = false;
         this.grdConnectView.OptionsView.ShowIndicator = false;
         this.grdConnectView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.GrdConnectView_CustomDrawCell);
         this.grdConnectView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.GrdConnectView_RowStyle);
         this.grdConnectView.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.GrdConnectView_ShowingEditor);
         this.grdConnectView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.GrdConnectView_RowUpdated);
         // 
         // grpGeneral
         // 
         this.grpGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpGeneral.Controls.Add(this.cboSection);
         this.grpGeneral.Controls.Add(this.lblSection);
         this.grpGeneral.Controls.Add(this.cboManufacturer);
         this.grpGeneral.Controls.Add(this.cboModel);
         this.grpGeneral.Controls.Add(this.lblName);
         this.grpGeneral.Controls.Add(this.txtName);
         this.grpGeneral.Controls.Add(this.lblModel);
         this.grpGeneral.Controls.Add(this.lblManufacturer);
         this.grpGeneral.Location = new System.Drawing.Point(13, 13);
         this.grpGeneral.Name = "grpGeneral";
         this.grpGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.grpGeneral.Size = new System.Drawing.Size(301, 148);
         this.grpGeneral.TabIndex = 216;
         this.grpGeneral.Text = "General";
         // 
         // lblSection
         // 
         this.lblSection.Location = new System.Drawing.Point(15, 114);
         this.lblSection.Name = "lblSection";
         this.lblSection.Size = new System.Drawing.Size(84, 13);
         this.lblSection.TabIndex = 8;
         this.lblSection.Text = "Location / Module";
         // 
         // cboManufacturer
         // 
         this.cboManufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboManufacturer.Location = new System.Drawing.Point(105, 59);
         this.cboManufacturer.Name = "cboManufacturer";
         this.cboManufacturer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboManufacturer.Properties.SmallImages = this.imageList;
         this.cboManufacturer.Size = new System.Drawing.Size(181, 20);
         this.cboManufacturer.TabIndex = 6;
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
         this.cboModel.Location = new System.Drawing.Point(105, 85);
         this.cboModel.Name = "cboModel";
         this.cboModel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboModel.Size = new System.Drawing.Size(181, 20);
         this.cboModel.TabIndex = 5;
         // 
         // lblModel
         // 
         this.lblModel.Location = new System.Drawing.Point(15, 88);
         this.lblModel.Name = "lblModel";
         this.lblModel.Size = new System.Drawing.Size(78, 13);
         this.lblModel.TabIndex = 4;
         this.lblModel.Text = "Model / Ref / PN";
         // 
         // lblManufacturer
         // 
         this.lblManufacturer.Location = new System.Drawing.Point(15, 62);
         this.lblManufacturer.Name = "lblManufacturer";
         this.lblManufacturer.Size = new System.Drawing.Size(65, 13);
         this.lblManufacturer.TabIndex = 2;
         this.lblManufacturer.Text = "Manufacturer";
         // 
         // grpDigital
         // 
         this.grpDigital.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.grpDigital.Controls.Add(this.lblAddress);
         this.grpDigital.Controls.Add(this.nudAddress);
         this.grpDigital.Controls.Add(this.lblOutputs);
         this.grpDigital.Controls.Add(this.txtOutputs);
         this.grpDigital.Location = new System.Drawing.Point(320, 13);
         this.grpDigital.Name = "grpDigital";
         this.grpDigital.Padding = new System.Windows.Forms.Padding(10);
         this.grpDigital.Size = new System.Drawing.Size(185, 148);
         this.grpDigital.TabIndex = 215;
         this.grpDigital.Text = "Digital properties";
         // 
         // lblAddress
         // 
         this.lblAddress.Location = new System.Drawing.Point(15, 36);
         this.lblAddress.Name = "lblAddress";
         this.lblAddress.Size = new System.Drawing.Size(65, 13);
         this.lblAddress.TabIndex = 12;
         this.lblAddress.Text = "Start address";
         // 
         // nudAddress
         // 
         this.nudAddress.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.nudAddress.Location = new System.Drawing.Point(99, 33);
         this.nudAddress.Name = "nudAddress";
         this.nudAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.nudAddress.Properties.IsFloatValue = false;
         this.nudAddress.Properties.Mask.EditMask = "N00";
         this.nudAddress.Properties.MaxValue = new decimal(new int[] {
            999,
            0,
            0,
            0});
         this.nudAddress.Size = new System.Drawing.Size(71, 20);
         this.nudAddress.TabIndex = 13;
         this.nudAddress.EditValueChanged += new System.EventHandler(this.NudAddress_EditValueChanged);
         // 
         // lblOutputs
         // 
         this.lblOutputs.Location = new System.Drawing.Point(15, 62);
         this.lblOutputs.Name = "lblOutputs";
         this.lblOutputs.Size = new System.Drawing.Size(39, 13);
         this.lblOutputs.TabIndex = 6;
         this.lblOutputs.Text = "Outputs";
         // 
         // txtOutputs
         // 
         this.txtOutputs.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtOutputs.Location = new System.Drawing.Point(99, 59);
         this.txtOutputs.Name = "txtOutputs";
         this.txtOutputs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.txtOutputs.Properties.IsFloatValue = false;
         this.txtOutputs.Properties.Mask.EditMask = "N00";
         this.txtOutputs.Properties.MaxValue = new decimal(new int[] {
            999,
            0,
            0,
            0});
         this.txtOutputs.Size = new System.Drawing.Size(71, 20);
         this.txtOutputs.TabIndex = 7;
         // 
         // tabDecoderNotes
         // 
         this.tabDecoderNotes.Controls.Add(this.txtNotes);
         this.tabDecoderNotes.Name = "tabDecoderNotes";
         this.tabDecoderNotes.Padding = new System.Windows.Forms.Padding(5);
         this.tabDecoderNotes.Size = new System.Drawing.Size(518, 436);
         this.tabDecoderNotes.Text = "Notes";
         // 
         // cboSection
         // 
         this.cboSection.Location = new System.Drawing.Point(105, 111);
         this.cboSection.Name = "cboSection";
         this.cboSection.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboSection.Size = new System.Drawing.Size(181, 20);
         this.cboSection.TabIndex = 9;
         // 
         // AccessoryDecoderEditorView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(548, 517);
         this.Controls.Add(this.tabDecoder);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.cmdOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AccessoryDecoderEditorView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Accessory module editor";
         this.Activated += new System.EventHandler(this.FrmDecoderEditor_Activated);
         ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabDecoder)).EndInit();
         this.tabDecoder.ResumeLayout(false);
         this.tabDecoderGeneral.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdConnect)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdConnectView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).EndInit();
         this.grpGeneral.ResumeLayout(false);
         this.grpGeneral.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboManufacturer.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboModel.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpDigital)).EndInit();
         this.grpDigital.ResumeLayout(false);
         this.grpDigital.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.nudAddress.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtOutputs.Properties)).EndInit();
         this.tabDecoderNotes.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.cboSection.Properties)).EndInit();
         this.ResumeLayout(false);

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
      private DevExpress.XtraEditors.LabelControl lblManufacturer;
      private DevExpress.XtraTab.XtraTabPage tabDecoderNotes;
      private DevExpress.XtraEditors.GroupControl grpGeneral;
      private DevExpress.XtraEditors.GroupControl grpDigital;
      private DevExpress.XtraEditors.LabelControl lblOutputs;
      private DevExpress.XtraEditors.SpinEdit txtOutputs;
      private System.Windows.Forms.ImageList imageList;
      private DevExpress.XtraGrid.GridControl grdConnect;
      private DevExpress.XtraGrid.Views.Grid.GridView grdConnectView;
      private DevExpress.XtraEditors.ComboBoxEdit cboModel;
      private DevExpress.XtraEditors.ImageComboBoxEdit cboManufacturer;
        private DevExpress.XtraEditors.LabelControl lblSection;
        private DevExpress.XtraEditors.LabelControl lblAddress;
        private DevExpress.XtraEditors.SpinEdit nudAddress;
        private Common.Controls.SectionImageComboBoxEdit cboSection;
    }
}