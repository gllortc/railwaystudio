namespace Rwm.Studio.Plugins.Control.Views
{
   partial class FrmAccessoryEditor
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccessoryEditor));
         this.txtNotes = new DevExpress.XtraEditors.MemoEdit();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdOk = new DevExpress.XtraEditors.SimpleButton();
         this.tabDecoder = new DevExpress.XtraTab.XtraTabControl();
         this.tabDecoderGeneral = new DevExpress.XtraTab.XtraTabPage();
         this.grpGeneral = new DevExpress.XtraEditors.GroupControl();
         this.cboManufacturer = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.cboModel = new DevExpress.XtraEditors.ComboBoxEdit();
         this.lblModel = new DevExpress.XtraEditors.LabelControl();
         this.lblManufacturer = new DevExpress.XtraEditors.LabelControl();
         this.grpDigital = new DevExpress.XtraEditors.GroupControl();
         this.lblOutputs = new DevExpress.XtraEditors.LabelControl();
         this.txtOutputs = new DevExpress.XtraEditors.SpinEdit();
         this.tabDecoderOutputs = new DevExpress.XtraTab.XtraTabPage();
         this.grdConnect = new DevExpress.XtraGrid.GridControl();
         this.grdConnectView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.tabDecoderNotes = new DevExpress.XtraTab.XtraTabPage();
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabDecoder)).BeginInit();
         this.tabDecoder.SuspendLayout();
         this.tabDecoderGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).BeginInit();
         this.grpGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboManufacturer.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboModel.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpDigital)).BeginInit();
         this.grpDigital.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtOutputs.Properties)).BeginInit();
         this.tabDecoderOutputs.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdConnect)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdConnectView)).BeginInit();
         this.tabDecoderNotes.SuspendLayout();
         this.SuspendLayout();
         // 
         // txtNotes
         // 
         this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
         this.txtNotes.Location = new System.Drawing.Point(5, 5);
         this.txtNotes.Name = "txtNotes";
         this.txtNotes.Size = new System.Drawing.Size(361, 222);
         this.txtNotes.TabIndex = 204;
         // 
         // lblName
         // 
         this.lblName.Location = new System.Drawing.Point(20, 38);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(27, 13);
         this.lblName.TabIndex = 0;
         this.lblName.Text = "Name";
         // 
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Location = new System.Drawing.Point(115, 35);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(210, 20);
         this.txtName.TabIndex = 1;
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(314, 278);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 200;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // cmdOk
         // 
         this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOk.Location = new System.Drawing.Point(233, 278);
         this.cmdOk.Name = "cmdOk";
         this.cmdOk.Size = new System.Drawing.Size(75, 23);
         this.cmdOk.TabIndex = 100;
         this.cmdOk.Text = "OK";
         this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
         // 
         // tabDecoder
         // 
         this.tabDecoder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabDecoder.Location = new System.Drawing.Point(12, 12);
         this.tabDecoder.Name = "tabDecoder";
         this.tabDecoder.SelectedTabPage = this.tabDecoderGeneral;
         this.tabDecoder.Size = new System.Drawing.Size(377, 260);
         this.tabDecoder.TabIndex = 8;
         this.tabDecoder.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabDecoderGeneral,
            this.tabDecoderOutputs,
            this.tabDecoderNotes});
         // 
         // tabDecoderGeneral
         // 
         this.tabDecoderGeneral.Controls.Add(this.grpGeneral);
         this.tabDecoderGeneral.Controls.Add(this.grpDigital);
         this.tabDecoderGeneral.Name = "tabDecoderGeneral";
         this.tabDecoderGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.tabDecoderGeneral.Size = new System.Drawing.Size(371, 232);
         this.tabDecoderGeneral.Text = "Properties";
         // 
         // grpGeneral
         // 
         this.grpGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpGeneral.Controls.Add(this.cboManufacturer);
         this.grpGeneral.Controls.Add(this.cboModel);
         this.grpGeneral.Controls.Add(this.lblName);
         this.grpGeneral.Controls.Add(this.txtName);
         this.grpGeneral.Controls.Add(this.lblModel);
         this.grpGeneral.Controls.Add(this.lblManufacturer);
         this.grpGeneral.Location = new System.Drawing.Point(13, 13);
         this.grpGeneral.Name = "grpGeneral";
         this.grpGeneral.Padding = new System.Windows.Forms.Padding(15);
         this.grpGeneral.Size = new System.Drawing.Size(345, 123);
         this.grpGeneral.TabIndex = 216;
         this.grpGeneral.Text = "General";
         // 
         // cboManufacturer
         // 
         this.cboManufacturer.Location = new System.Drawing.Point(115, 61);
         this.cboManufacturer.Name = "cboManufacturer";
         this.cboManufacturer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboManufacturer.Properties.SmallImages = this.imageList;
         this.cboManufacturer.Size = new System.Drawing.Size(210, 20);
         this.cboManufacturer.TabIndex = 6;
         // 
         // cboModel
         // 
         this.cboModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboModel.Location = new System.Drawing.Point(115, 87);
         this.cboModel.Name = "cboModel";
         this.cboModel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboModel.Size = new System.Drawing.Size(210, 20);
         this.cboModel.TabIndex = 5;
         // 
         // lblModel
         // 
         this.lblModel.Location = new System.Drawing.Point(20, 90);
         this.lblModel.Name = "lblModel";
         this.lblModel.Size = new System.Drawing.Size(78, 13);
         this.lblModel.TabIndex = 4;
         this.lblModel.Text = "Model / Ref / PN";
         // 
         // lblManufacturer
         // 
         this.lblManufacturer.Location = new System.Drawing.Point(20, 64);
         this.lblManufacturer.Name = "lblManufacturer";
         this.lblManufacturer.Size = new System.Drawing.Size(65, 13);
         this.lblManufacturer.TabIndex = 2;
         this.lblManufacturer.Text = "Manufacturer";
         // 
         // grpDigital
         // 
         this.grpDigital.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpDigital.Controls.Add(this.lblOutputs);
         this.grpDigital.Controls.Add(this.txtOutputs);
         this.grpDigital.Location = new System.Drawing.Point(13, 142);
         this.grpDigital.Name = "grpDigital";
         this.grpDigital.Padding = new System.Windows.Forms.Padding(15);
         this.grpDigital.Size = new System.Drawing.Size(345, 77);
         this.grpDigital.TabIndex = 215;
         this.grpDigital.Text = "Digital properties";
         // 
         // lblOutputs
         // 
         this.lblOutputs.Location = new System.Drawing.Point(20, 41);
         this.lblOutputs.Name = "lblOutputs";
         this.lblOutputs.Size = new System.Drawing.Size(78, 13);
         this.lblOutputs.TabIndex = 6;
         this.lblOutputs.Text = "Num. of outputs";
         // 
         // txtOutputs
         // 
         this.txtOutputs.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtOutputs.Location = new System.Drawing.Point(115, 38);
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
         // tabDecoderOutputs
         // 
         this.tabDecoderOutputs.Controls.Add(this.grdConnect);
         this.tabDecoderOutputs.Name = "tabDecoderOutputs";
         this.tabDecoderOutputs.Padding = new System.Windows.Forms.Padding(5);
         this.tabDecoderOutputs.Size = new System.Drawing.Size(371, 232);
         this.tabDecoderOutputs.Text = "Connections";
         // 
         // grdConnect
         // 
         this.grdConnect.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdConnect.Location = new System.Drawing.Point(5, 5);
         this.grdConnect.MainView = this.grdConnectView;
         this.grdConnect.Name = "grdConnect";
         this.grdConnect.Size = new System.Drawing.Size(361, 222);
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
         this.grdConnectView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdConnectView.OptionsSelection.EnableAppearanceFocusedRow = false;
         this.grdConnectView.OptionsView.ShowGroupPanel = false;
         this.grdConnectView.OptionsView.ShowIndicator = false;
         this.grdConnectView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdConnectView_CustomDrawCell);
         this.grdConnectView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grdConnectView_RowStyle);
         // 
         // tabDecoderNotes
         // 
         this.tabDecoderNotes.Controls.Add(this.txtNotes);
         this.tabDecoderNotes.Name = "tabDecoderNotes";
         this.tabDecoderNotes.Padding = new System.Windows.Forms.Padding(5);
         this.tabDecoderNotes.Size = new System.Drawing.Size(371, 232);
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
         // FrmAccessoryEditor
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(401, 313);
         this.Controls.Add(this.tabDecoder);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.cmdOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmAccessoryEditor";
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
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).EndInit();
         this.grpGeneral.ResumeLayout(false);
         this.grpGeneral.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboManufacturer.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboModel.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpDigital)).EndInit();
         this.grpDigital.ResumeLayout(false);
         this.grpDigital.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtOutputs.Properties)).EndInit();
         this.tabDecoderOutputs.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdConnect)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdConnectView)).EndInit();
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
      private DevExpress.XtraEditors.GroupControl grpDigital;
      private DevExpress.XtraEditors.LabelControl lblOutputs;
      private DevExpress.XtraEditors.SpinEdit txtOutputs;
      private System.Windows.Forms.ImageList imageList;
      private DevExpress.XtraTab.XtraTabPage tabDecoderOutputs;
      private DevExpress.XtraGrid.GridControl grdConnect;
      private DevExpress.XtraGrid.Views.Grid.GridView grdConnectView;
      private DevExpress.XtraEditors.ComboBoxEdit cboModel;
      private DevExpress.XtraEditors.ImageComboBoxEdit cboManufacturer;
   }
}