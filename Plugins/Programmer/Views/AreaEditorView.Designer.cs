namespace Rwm.Studio.Plugins.Designer.Views
{
   partial class AreaEditorView
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
         this.cmdOk = new DevExpress.XtraEditors.SimpleButton();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
         this.lblDescription = new DevExpress.XtraEditors.LabelControl();
         this.txtAccStartAddr = new DevExpress.XtraEditors.SpinEdit();
         this.txtAccEndAddr = new DevExpress.XtraEditors.SpinEdit();
         this.lblAccStartAddr = new DevExpress.XtraEditors.LabelControl();
         this.lblAccEndAddr = new DevExpress.XtraEditors.LabelControl();
         this.tabArea = new DevExpress.XtraTab.XtraTabControl();
         this.tabAreaGeneral = new DevExpress.XtraTab.XtraTabPage();
         this.tabAreaDigital = new DevExpress.XtraTab.XtraTabPage();
         this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
         this.lblFbStartAddr = new DevExpress.XtraEditors.LabelControl();
         this.lblFbEndAddr = new DevExpress.XtraEditors.LabelControl();
         this.txtFbStartAddr = new DevExpress.XtraEditors.SpinEdit();
         this.txtFbEndAddr = new DevExpress.XtraEditors.SpinEdit();
         this.grpDigitalAcc = new DevExpress.XtraEditors.GroupControl();
         this.tabSchema = new DevExpress.XtraTab.XtraTabPage();
         this.picSchema = new DevExpress.XtraEditors.PictureEdit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtAccStartAddr.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtAccEndAddr.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabArea)).BeginInit();
         this.tabArea.SuspendLayout();
         this.tabAreaGeneral.SuspendLayout();
         this.tabAreaDigital.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
         this.groupControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtFbStartAddr.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtFbEndAddr.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpDigitalAcc)).BeginInit();
         this.grpDigitalAcc.SuspendLayout();
         this.tabSchema.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picSchema.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // cmdOk
         // 
         this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOk.Location = new System.Drawing.Point(378, 371);
         this.cmdOk.Name = "cmdOk";
         this.cmdOk.Size = new System.Drawing.Size(75, 23);
         this.cmdOk.TabIndex = 100;
         this.cmdOk.Text = "OK";
         this.cmdOk.Click += new System.EventHandler(this.CmdOk_Click);
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(459, 371);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 200;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
         // 
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Location = new System.Drawing.Point(79, 13);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(424, 20);
         this.txtName.TabIndex = 1;
         // 
         // lblName
         // 
         this.lblName.Location = new System.Drawing.Point(13, 16);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(27, 13);
         this.lblName.TabIndex = 0;
         this.lblName.Text = "Name";
         // 
         // txtDescription
         // 
         this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtDescription.Location = new System.Drawing.Point(79, 39);
         this.txtDescription.Name = "txtDescription";
         this.txtDescription.Size = new System.Drawing.Size(424, 273);
         this.txtDescription.TabIndex = 3;
         // 
         // lblDescription
         // 
         this.lblDescription.Location = new System.Drawing.Point(13, 41);
         this.lblDescription.Name = "lblDescription";
         this.lblDescription.Size = new System.Drawing.Size(53, 13);
         this.lblDescription.TabIndex = 2;
         this.lblDescription.Text = "Description";
         // 
         // txtAccStartAddr
         // 
         this.txtAccStartAddr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.txtAccStartAddr.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtAccStartAddr.Location = new System.Drawing.Point(97, 33);
         this.txtAccStartAddr.Name = "txtAccStartAddr";
         this.txtAccStartAddr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.txtAccStartAddr.Size = new System.Drawing.Size(71, 20);
         this.txtAccStartAddr.TabIndex = 5;
         // 
         // txtAccEndAddr
         // 
         this.txtAccEndAddr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.txtAccEndAddr.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtAccEndAddr.Location = new System.Drawing.Point(97, 59);
         this.txtAccEndAddr.Name = "txtAccEndAddr";
         this.txtAccEndAddr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.txtAccEndAddr.Size = new System.Drawing.Size(71, 20);
         this.txtAccEndAddr.TabIndex = 8;
         // 
         // lblAccStartAddr
         // 
         this.lblAccStartAddr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.lblAccStartAddr.Location = new System.Drawing.Point(15, 36);
         this.lblAccStartAddr.Name = "lblAccStartAddr";
         this.lblAccStartAddr.Size = new System.Drawing.Size(65, 13);
         this.lblAccStartAddr.TabIndex = 4;
         this.lblAccStartAddr.Text = "Start address";
         // 
         // lblAccEndAddr
         // 
         this.lblAccEndAddr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.lblAccEndAddr.Location = new System.Drawing.Point(15, 62);
         this.lblAccEndAddr.Name = "lblAccEndAddr";
         this.lblAccEndAddr.Size = new System.Drawing.Size(59, 13);
         this.lblAccEndAddr.TabIndex = 7;
         this.lblAccEndAddr.Text = "End address";
         // 
         // tabArea
         // 
         this.tabArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabArea.Location = new System.Drawing.Point(12, 12);
         this.tabArea.Name = "tabArea";
         this.tabArea.SelectedTabPage = this.tabAreaGeneral;
         this.tabArea.Size = new System.Drawing.Size(522, 353);
         this.tabArea.TabIndex = 201;
         this.tabArea.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabAreaGeneral,
            this.tabAreaDigital,
            this.tabSchema});
         // 
         // tabAreaGeneral
         // 
         this.tabAreaGeneral.Controls.Add(this.txtName);
         this.tabAreaGeneral.Controls.Add(this.lblName);
         this.tabAreaGeneral.Controls.Add(this.txtDescription);
         this.tabAreaGeneral.Controls.Add(this.lblDescription);
         this.tabAreaGeneral.Name = "tabAreaGeneral";
         this.tabAreaGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.tabAreaGeneral.Size = new System.Drawing.Size(516, 325);
         this.tabAreaGeneral.Text = "General";
         // 
         // tabAreaDigital
         // 
         this.tabAreaDigital.Controls.Add(this.groupControl1);
         this.tabAreaDigital.Controls.Add(this.grpDigitalAcc);
         this.tabAreaDigital.Name = "tabAreaDigital";
         this.tabAreaDigital.Padding = new System.Windows.Forms.Padding(10);
         this.tabAreaDigital.Size = new System.Drawing.Size(516, 325);
         this.tabAreaDigital.Text = "Digital";
         // 
         // groupControl1
         // 
         this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupControl1.Controls.Add(this.lblFbStartAddr);
         this.groupControl1.Controls.Add(this.lblFbEndAddr);
         this.groupControl1.Controls.Add(this.txtFbStartAddr);
         this.groupControl1.Controls.Add(this.txtFbEndAddr);
         this.groupControl1.Location = new System.Drawing.Point(13, 119);
         this.groupControl1.Name = "groupControl1";
         this.groupControl1.Padding = new System.Windows.Forms.Padding(10);
         this.groupControl1.Size = new System.Drawing.Size(490, 100);
         this.groupControl1.TabIndex = 9;
         this.groupControl1.Text = "Allowed feedback address range";
         // 
         // lblFbStartAddr
         // 
         this.lblFbStartAddr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.lblFbStartAddr.Location = new System.Drawing.Point(15, 36);
         this.lblFbStartAddr.Name = "lblFbStartAddr";
         this.lblFbStartAddr.Size = new System.Drawing.Size(65, 13);
         this.lblFbStartAddr.TabIndex = 9;
         this.lblFbStartAddr.Text = "Start address";
         // 
         // lblFbEndAddr
         // 
         this.lblFbEndAddr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.lblFbEndAddr.Location = new System.Drawing.Point(15, 62);
         this.lblFbEndAddr.Name = "lblFbEndAddr";
         this.lblFbEndAddr.Size = new System.Drawing.Size(59, 13);
         this.lblFbEndAddr.TabIndex = 10;
         this.lblFbEndAddr.Text = "End address";
         // 
         // txtFbStartAddr
         // 
         this.txtFbStartAddr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.txtFbStartAddr.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtFbStartAddr.Location = new System.Drawing.Point(97, 33);
         this.txtFbStartAddr.Name = "txtFbStartAddr";
         this.txtFbStartAddr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.txtFbStartAddr.Size = new System.Drawing.Size(71, 20);
         this.txtFbStartAddr.TabIndex = 5;
         // 
         // txtFbEndAddr
         // 
         this.txtFbEndAddr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.txtFbEndAddr.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtFbEndAddr.Location = new System.Drawing.Point(97, 59);
         this.txtFbEndAddr.Name = "txtFbEndAddr";
         this.txtFbEndAddr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.txtFbEndAddr.Size = new System.Drawing.Size(71, 20);
         this.txtFbEndAddr.TabIndex = 8;
         // 
         // grpDigitalAcc
         // 
         this.grpDigitalAcc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpDigitalAcc.Controls.Add(this.lblAccStartAddr);
         this.grpDigitalAcc.Controls.Add(this.txtAccStartAddr);
         this.grpDigitalAcc.Controls.Add(this.txtAccEndAddr);
         this.grpDigitalAcc.Controls.Add(this.lblAccEndAddr);
         this.grpDigitalAcc.Location = new System.Drawing.Point(13, 13);
         this.grpDigitalAcc.Name = "grpDigitalAcc";
         this.grpDigitalAcc.Padding = new System.Windows.Forms.Padding(10);
         this.grpDigitalAcc.Size = new System.Drawing.Size(490, 100);
         this.grpDigitalAcc.TabIndex = 0;
         this.grpDigitalAcc.Text = "Allowed accessory address range";
         // 
         // tabSchema
         // 
         this.tabSchema.Controls.Add(this.picSchema);
         this.tabSchema.Name = "tabSchema";
         this.tabSchema.Padding = new System.Windows.Forms.Padding(10);
         this.tabSchema.Size = new System.Drawing.Size(516, 325);
         this.tabSchema.Text = "Schema";
         // 
         // picSchema
         // 
         this.picSchema.Cursor = System.Windows.Forms.Cursors.Default;
         this.picSchema.Dock = System.Windows.Forms.DockStyle.Fill;
         this.picSchema.Location = new System.Drawing.Point(10, 10);
         this.picSchema.Name = "picSchema";
         this.picSchema.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
         this.picSchema.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
         this.picSchema.Properties.ZoomAccelerationFactor = 1D;
         this.picSchema.Size = new System.Drawing.Size(496, 305);
         this.picSchema.TabIndex = 1;
         // 
         // AreaEditorView
         // 
         this.AcceptButton = this.cmdOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(546, 406);
         this.Controls.Add(this.tabArea);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.cmdOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AreaEditorView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Layout area editor";
         this.Activated += new System.EventHandler(this.FrmPanelEditor_Activated);
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtAccStartAddr.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtAccEndAddr.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabArea)).EndInit();
         this.tabArea.ResumeLayout(false);
         this.tabAreaGeneral.ResumeLayout(false);
         this.tabAreaGeneral.PerformLayout();
         this.tabAreaDigital.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
         this.groupControl1.ResumeLayout(false);
         this.groupControl1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtFbStartAddr.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtFbEndAddr.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpDigitalAcc)).EndInit();
         this.grpDigitalAcc.ResumeLayout(false);
         this.grpDigitalAcc.PerformLayout();
         this.tabSchema.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.picSchema.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.SimpleButton cmdOk;
      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.TextEdit txtName;
      private DevExpress.XtraEditors.LabelControl lblName;
      private DevExpress.XtraEditors.MemoEdit txtDescription;
      private DevExpress.XtraEditors.LabelControl lblDescription;
      private DevExpress.XtraEditors.SpinEdit txtAccStartAddr;
      private DevExpress.XtraEditors.SpinEdit txtAccEndAddr;
      private DevExpress.XtraEditors.LabelControl lblAccStartAddr;
      private DevExpress.XtraEditors.LabelControl lblAccEndAddr;
        private DevExpress.XtraTab.XtraTabControl tabArea;
        private DevExpress.XtraTab.XtraTabPage tabAreaGeneral;
        private DevExpress.XtraTab.XtraTabPage tabAreaDigital;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblFbStartAddr;
        private DevExpress.XtraEditors.LabelControl lblFbEndAddr;
        private DevExpress.XtraEditors.SpinEdit txtFbStartAddr;
        private DevExpress.XtraEditors.SpinEdit txtFbEndAddr;
        private DevExpress.XtraEditors.GroupControl grpDigitalAcc;
      private DevExpress.XtraTab.XtraTabPage tabSchema;
      private DevExpress.XtraEditors.PictureEdit picSchema;
   }
}