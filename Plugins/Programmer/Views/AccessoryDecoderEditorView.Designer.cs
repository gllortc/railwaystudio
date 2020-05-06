namespace Rwm.Studio.Plugins.Designer.Views
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessoryDecoderEditorView));
         this.txtNotes = new DevExpress.XtraEditors.MemoEdit();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdOk = new DevExpress.XtraEditors.SimpleButton();
         this.tabDecoder = new DevExpress.XtraTab.XtraTabControl();
         this.tabDecoderGeneral = new DevExpress.XtraTab.XtraTabPage();
         this.grdOut = new DevExpress.XtraGrid.GridControl();
         this.grdOutView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.grpGeneral = new DevExpress.XtraEditors.GroupControl();
         this.lblOutputsCount = new DevExpress.XtraEditors.LabelControl();
         this.cboManufacturer = new Rwm.Studio.Plugins.Common.Controls.ManufacturerImageComboBoxEdit();
         this.cboSection = new Rwm.Studio.Plugins.Common.Controls.SectionImageComboBoxEdit();
         this.lblSection = new DevExpress.XtraEditors.LabelControl();
         this.lblOutputs = new DevExpress.XtraEditors.LabelControl();
         this.cboModel = new DevExpress.XtraEditors.ComboBoxEdit();
         this.lblModel = new DevExpress.XtraEditors.LabelControl();
         this.lblManufacturer = new DevExpress.XtraEditors.LabelControl();
         this.tabDecoderNotes = new DevExpress.XtraTab.XtraTabPage();
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabDecoder)).BeginInit();
         this.tabDecoder.SuspendLayout();
         this.tabDecoderGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdOut)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdOutView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).BeginInit();
         this.grpGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboManufacturer.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboSection.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboModel.Properties)).BeginInit();
         this.tabDecoderNotes.SuspendLayout();
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
         this.txtName.Size = new System.Drawing.Size(372, 20);
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
         this.tabDecoderGeneral.Controls.Add(this.grdOut);
         this.tabDecoderGeneral.Controls.Add(this.grpGeneral);
         this.tabDecoderGeneral.Name = "tabDecoderGeneral";
         this.tabDecoderGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.tabDecoderGeneral.Size = new System.Drawing.Size(518, 436);
         this.tabDecoderGeneral.Text = "Properties";
         // 
         // grdOut
         // 
         this.grdOut.Location = new System.Drawing.Point(13, 190);
         this.grdOut.MainView = this.grdOutView;
         this.grdOut.Name = "grdOut";
         this.grdOut.Size = new System.Drawing.Size(492, 233);
         this.grdOut.TabIndex = 217;
         this.grdOut.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdOutView});
         // 
         // grdOutView
         // 
         this.grdOutView.GridControl = this.grdOut;
         this.grdOutView.Name = "grdOutView";
         this.grdOutView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.GrdOutView_CustomDrawCell);
         this.grdOutView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.GrdOutView_RowStyle);
         // 
         // grpGeneral
         // 
         this.grpGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpGeneral.Controls.Add(this.lblOutputsCount);
         this.grpGeneral.Controls.Add(this.cboManufacturer);
         this.grpGeneral.Controls.Add(this.cboSection);
         this.grpGeneral.Controls.Add(this.lblSection);
         this.grpGeneral.Controls.Add(this.lblOutputs);
         this.grpGeneral.Controls.Add(this.cboModel);
         this.grpGeneral.Controls.Add(this.lblName);
         this.grpGeneral.Controls.Add(this.txtName);
         this.grpGeneral.Controls.Add(this.lblModel);
         this.grpGeneral.Controls.Add(this.lblManufacturer);
         this.grpGeneral.Location = new System.Drawing.Point(13, 13);
         this.grpGeneral.Name = "grpGeneral";
         this.grpGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.grpGeneral.Size = new System.Drawing.Size(492, 171);
         this.grpGeneral.TabIndex = 216;
         this.grpGeneral.Text = "General";
         // 
         // lblOutputsCount
         // 
         this.lblOutputsCount.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.lblOutputsCount.Appearance.Options.UseFont = true;
         this.lblOutputsCount.Location = new System.Drawing.Point(105, 140);
         this.lblOutputsCount.Name = "lblOutputsCount";
         this.lblOutputsCount.Size = new System.Drawing.Size(7, 13);
         this.lblOutputsCount.TabIndex = 11;
         this.lblOutputsCount.Text = "4";
         // 
         // cboManufacturer
         // 
         this.cboManufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboManufacturer.Location = new System.Drawing.Point(105, 59);
         this.cboManufacturer.Name = "cboManufacturer";
         this.cboManufacturer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboManufacturer.Size = new System.Drawing.Size(372, 20);
         this.cboManufacturer.TabIndex = 10;
         // 
         // cboSection
         // 
         this.cboSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboSection.Location = new System.Drawing.Point(105, 111);
         this.cboSection.Name = "cboSection";
         this.cboSection.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboSection.Size = new System.Drawing.Size(372, 20);
         this.cboSection.TabIndex = 9;
         // 
         // lblSection
         // 
         this.lblSection.Location = new System.Drawing.Point(15, 114);
         this.lblSection.Name = "lblSection";
         this.lblSection.Size = new System.Drawing.Size(84, 13);
         this.lblSection.TabIndex = 8;
         this.lblSection.Text = "Location / Module";
         // 
         // lblOutputs
         // 
         this.lblOutputs.Location = new System.Drawing.Point(15, 140);
         this.lblOutputs.Name = "lblOutputs";
         this.lblOutputs.Size = new System.Drawing.Size(39, 13);
         this.lblOutputs.TabIndex = 6;
         this.lblOutputs.Text = "Outputs";
         // 
         // cboModel
         // 
         this.cboModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboModel.Location = new System.Drawing.Point(105, 85);
         this.cboModel.Name = "cboModel";
         this.cboModel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboModel.Size = new System.Drawing.Size(372, 20);
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
         // tabDecoderNotes
         // 
         this.tabDecoderNotes.Controls.Add(this.txtNotes);
         this.tabDecoderNotes.Name = "tabDecoderNotes";
         this.tabDecoderNotes.Padding = new System.Windows.Forms.Padding(5);
         this.tabDecoderNotes.Size = new System.Drawing.Size(518, 436);
         this.tabDecoderNotes.Text = "Notes";
         // 
         // imageList
         // 
         this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
         this.imageList.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList.Images.SetKeyName(0, "ICO_OUTPUT");
         this.imageList.Images.SetKeyName(1, "ICO_MANUFACTURER");
         this.imageList.Images.SetKeyName(2, "ICO_MODEL");
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
         ((System.ComponentModel.ISupportInitialize)(this.grdOut)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdOutView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).EndInit();
         this.grpGeneral.ResumeLayout(false);
         this.grpGeneral.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboManufacturer.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboSection.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboModel.Properties)).EndInit();
         this.tabDecoderNotes.ResumeLayout(false);
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
      private System.Windows.Forms.ImageList imageList;
      private DevExpress.XtraEditors.ComboBoxEdit cboModel;
      private DevExpress.XtraEditors.LabelControl lblSection;
      private Common.Controls.SectionImageComboBoxEdit cboSection;
      private Common.Controls.ManufacturerImageComboBoxEdit cboManufacturer;
      private DevExpress.XtraGrid.GridControl grdOut;
      private DevExpress.XtraGrid.Views.Grid.GridView grdOutView;
        private DevExpress.XtraEditors.LabelControl lblOutputsCount;
        private DevExpress.XtraEditors.LabelControl lblOutputs;
    }
}