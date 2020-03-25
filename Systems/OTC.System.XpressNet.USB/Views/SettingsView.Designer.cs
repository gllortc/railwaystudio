namespace Rwm.Otc.Systems.XpressNet.Views
{
   partial class SettingsView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsView));
         this.cboPort = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.imlIcons = new System.Windows.Forms.ImageList(this.components);
         this.lblPort = new DevExpress.XtraEditors.LabelControl();
         this.grpCommunications = new DevExpress.XtraEditors.GroupControl();
         this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
         this.chkDebugMode = new DevExpress.XtraEditors.CheckEdit();
         this.spnKeepaliveInterval = new DevExpress.XtraEditors.SpinEdit();
         this.lblTimeout = new DevExpress.XtraEditors.LabelControl();
         this.spnDataBits = new DevExpress.XtraEditors.SpinEdit();
         this.cboBaudRate = new DevExpress.XtraEditors.ComboBoxEdit();
         this.lblDataBits = new DevExpress.XtraEditors.LabelControl();
         this.lblHandshake = new DevExpress.XtraEditors.LabelControl();
         this.lblStopBits = new DevExpress.XtraEditors.LabelControl();
         this.lblParity = new DevExpress.XtraEditors.LabelControl();
         this.cboHandshake = new DevExpress.XtraEditors.ComboBoxEdit();
         this.cboStopBits = new DevExpress.XtraEditors.ComboBoxEdit();
         this.cboParity = new DevExpress.XtraEditors.ComboBoxEdit();
         this.lblBaudRate = new DevExpress.XtraEditors.LabelControl();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.spnRWTimeout = new DevExpress.XtraEditors.SpinEdit();
         this.lblRWTimeout = new DevExpress.XtraEditors.LabelControl();
         ((System.ComponentModel.ISupportInitialize)(this.cboPort.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpCommunications)).BeginInit();
         this.grpCommunications.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.chkDebugMode.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.spnKeepaliveInterval.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.spnDataBits.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboBaudRate.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboHandshake.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboStopBits.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboParity.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.spnRWTimeout.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // cboPort
         // 
         this.cboPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboPort.Location = new System.Drawing.Point(143, 33);
         this.cboPort.Name = "cboPort";
         this.cboPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboPort.Properties.SmallImages = this.imlIcons;
         this.cboPort.Size = new System.Drawing.Size(138, 20);
         this.cboPort.TabIndex = 1;
         // 
         // imlIcons
         // 
         this.imlIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlIcons.ImageStream")));
         this.imlIcons.TransparentColor = System.Drawing.Color.Transparent;
         this.imlIcons.Images.SetKeyName(0, "port.png");
         // 
         // lblPort
         // 
         this.lblPort.Location = new System.Drawing.Point(15, 36);
         this.lblPort.Name = "lblPort";
         this.lblPort.Size = new System.Drawing.Size(20, 13);
         this.lblPort.TabIndex = 0;
         this.lblPort.Text = "Port";
         // 
         // grpCommunications
         // 
         this.grpCommunications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpCommunications.Controls.Add(this.spnRWTimeout);
         this.grpCommunications.Controls.Add(this.lblRWTimeout);
         this.grpCommunications.Controls.Add(this.separatorControl1);
         this.grpCommunications.Controls.Add(this.chkDebugMode);
         this.grpCommunications.Controls.Add(this.spnKeepaliveInterval);
         this.grpCommunications.Controls.Add(this.lblTimeout);
         this.grpCommunications.Controls.Add(this.spnDataBits);
         this.grpCommunications.Controls.Add(this.cboBaudRate);
         this.grpCommunications.Controls.Add(this.lblDataBits);
         this.grpCommunications.Controls.Add(this.lblHandshake);
         this.grpCommunications.Controls.Add(this.lblStopBits);
         this.grpCommunications.Controls.Add(this.lblParity);
         this.grpCommunications.Controls.Add(this.cboHandshake);
         this.grpCommunications.Controls.Add(this.cboStopBits);
         this.grpCommunications.Controls.Add(this.cboParity);
         this.grpCommunications.Controls.Add(this.lblBaudRate);
         this.grpCommunications.Controls.Add(this.lblPort);
         this.grpCommunications.Controls.Add(this.cboPort);
         this.grpCommunications.Location = new System.Drawing.Point(12, 71);
         this.grpCommunications.Name = "grpCommunications";
         this.grpCommunications.Padding = new System.Windows.Forms.Padding(10);
         this.grpCommunications.Size = new System.Drawing.Size(296, 303);
         this.grpCommunications.TabIndex = 2;
         this.grpCommunications.Text = "Communications";
         // 
         // separatorControl1
         // 
         this.separatorControl1.Location = new System.Drawing.Point(15, 241);
         this.separatorControl1.Name = "separatorControl1";
         this.separatorControl1.Size = new System.Drawing.Size(266, 23);
         this.separatorControl1.TabIndex = 11;
         // 
         // chkDebugMode
         // 
         this.chkDebugMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.chkDebugMode.Location = new System.Drawing.Point(15, 270);
         this.chkDebugMode.Name = "chkDebugMode";
         this.chkDebugMode.Properties.Caption = "Mode debugger (use only to verify communication)";
         this.chkDebugMode.Size = new System.Drawing.Size(266, 19);
         this.chkDebugMode.TabIndex = 14;
         // 
         // spnKeepaliveInterval
         // 
         this.spnKeepaliveInterval.EditValue = new decimal(new int[] {
            3000,
            0,
            0,
            0});
         this.spnKeepaliveInterval.Location = new System.Drawing.Point(143, 189);
         this.spnKeepaliveInterval.Name = "spnKeepaliveInterval";
         this.spnKeepaliveInterval.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.spnKeepaliveInterval.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
         this.spnKeepaliveInterval.Size = new System.Drawing.Size(62, 20);
         this.spnKeepaliveInterval.TabIndex = 13;
         // 
         // lblTimeout
         // 
         this.lblTimeout.Location = new System.Drawing.Point(15, 192);
         this.lblTimeout.Name = "lblTimeout";
         this.lblTimeout.Size = new System.Drawing.Size(115, 13);
         this.lblTimeout.TabIndex = 12;
         this.lblTimeout.Text = "Keepalive signal interval";
         // 
         // spnDataBits
         // 
         this.spnDataBits.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.spnDataBits.Enabled = false;
         this.spnDataBits.Location = new System.Drawing.Point(143, 137);
         this.spnDataBits.Name = "spnDataBits";
         this.spnDataBits.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.spnDataBits.Size = new System.Drawing.Size(62, 20);
         this.spnDataBits.TabIndex = 9;
         // 
         // cboBaudRate
         // 
         this.cboBaudRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboBaudRate.Location = new System.Drawing.Point(143, 59);
         this.cboBaudRate.Name = "cboBaudRate";
         this.cboBaudRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboBaudRate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
         this.cboBaudRate.Size = new System.Drawing.Size(138, 20);
         this.cboBaudRate.TabIndex = 3;
         // 
         // lblDataBits
         // 
         this.lblDataBits.Location = new System.Drawing.Point(15, 140);
         this.lblDataBits.Name = "lblDataBits";
         this.lblDataBits.Size = new System.Drawing.Size(43, 13);
         this.lblDataBits.TabIndex = 8;
         this.lblDataBits.Text = "Data bits";
         // 
         // lblHandshake
         // 
         this.lblHandshake.Location = new System.Drawing.Point(15, 166);
         this.lblHandshake.Name = "lblHandshake";
         this.lblHandshake.Size = new System.Drawing.Size(53, 13);
         this.lblHandshake.TabIndex = 10;
         this.lblHandshake.Text = "Handshake";
         // 
         // lblStopBits
         // 
         this.lblStopBits.Location = new System.Drawing.Point(15, 114);
         this.lblStopBits.Name = "lblStopBits";
         this.lblStopBits.Size = new System.Drawing.Size(42, 13);
         this.lblStopBits.TabIndex = 6;
         this.lblStopBits.Text = "Stop bits";
         // 
         // lblParity
         // 
         this.lblParity.Location = new System.Drawing.Point(15, 88);
         this.lblParity.Name = "lblParity";
         this.lblParity.Size = new System.Drawing.Size(28, 13);
         this.lblParity.TabIndex = 4;
         this.lblParity.Text = "Parity";
         // 
         // cboHandshake
         // 
         this.cboHandshake.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboHandshake.Enabled = false;
         this.cboHandshake.Location = new System.Drawing.Point(143, 163);
         this.cboHandshake.Name = "cboHandshake";
         this.cboHandshake.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboHandshake.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
         this.cboHandshake.Size = new System.Drawing.Size(138, 20);
         this.cboHandshake.TabIndex = 11;
         // 
         // cboStopBits
         // 
         this.cboStopBits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboStopBits.Enabled = false;
         this.cboStopBits.Location = new System.Drawing.Point(143, 111);
         this.cboStopBits.Name = "cboStopBits";
         this.cboStopBits.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboStopBits.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
         this.cboStopBits.Size = new System.Drawing.Size(138, 20);
         this.cboStopBits.TabIndex = 7;
         // 
         // cboParity
         // 
         this.cboParity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboParity.Enabled = false;
         this.cboParity.Location = new System.Drawing.Point(143, 85);
         this.cboParity.Name = "cboParity";
         this.cboParity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboParity.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
         this.cboParity.Size = new System.Drawing.Size(138, 20);
         this.cboParity.TabIndex = 5;
         // 
         // lblBaudRate
         // 
         this.lblBaudRate.Location = new System.Drawing.Point(15, 62);
         this.lblBaudRate.Name = "lblBaudRate";
         this.lblBaudRate.Size = new System.Drawing.Size(87, 13);
         this.lblBaudRate.TabIndex = 2;
         this.lblBaudRate.Text = "Baud rate (speed)";
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(233, 380);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 200;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
         // 
         // cmdOK
         // 
         this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOK.Location = new System.Drawing.Point(152, 380);
         this.cmdOK.Name = "cmdOK";
         this.cmdOK.Size = new System.Drawing.Size(75, 23);
         this.cmdOK.TabIndex = 100;
         this.cmdOK.Text = "OK";
         this.cmdOK.Click += new System.EventHandler(this.CmdOK_Click);
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = global::Rwm.Otc.Systems.XpressNet.Properties.Resources.IMG_HEADER;
         this.pictureBox1.Location = new System.Drawing.Point(0, 0);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(320, 65);
         this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox1.TabIndex = 5;
         this.pictureBox1.TabStop = false;
         // 
         // spnRWTimeout
         // 
         this.spnRWTimeout.EditValue = new decimal(new int[] {
            500,
            0,
            0,
            0});
         this.spnRWTimeout.Location = new System.Drawing.Point(143, 215);
         this.spnRWTimeout.Name = "spnRWTimeout";
         this.spnRWTimeout.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.spnRWTimeout.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
         this.spnRWTimeout.Size = new System.Drawing.Size(62, 20);
         this.spnRWTimeout.TabIndex = 16;
         // 
         // lblRWTimeout
         // 
         this.lblRWTimeout.Location = new System.Drawing.Point(15, 218);
         this.lblRWTimeout.Name = "lblRWTimeout";
         this.lblRWTimeout.Size = new System.Drawing.Size(94, 13);
         this.lblRWTimeout.TabIndex = 15;
         this.lblRWTimeout.Text = "Read/Write timeout";
         // 
         // SettingsView
         // 
         this.AcceptButton = this.cmdOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(320, 415);
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this.cmdOK);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.grpCommunications);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SettingsView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "XpressNet USB Interface settings";
         ((System.ComponentModel.ISupportInitialize)(this.cboPort.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpCommunications)).EndInit();
         this.grpCommunications.ResumeLayout(false);
         this.grpCommunications.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.chkDebugMode.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.spnKeepaliveInterval.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.spnDataBits.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboBaudRate.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboHandshake.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboStopBits.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboParity.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.spnRWTimeout.Properties)).EndInit();
         this.ResumeLayout(false);

      }

        #endregion

        private DevExpress.XtraEditors.ImageComboBoxEdit cboPort;
        private DevExpress.XtraEditors.LabelControl lblPort;
        private DevExpress.XtraEditors.GroupControl grpCommunications;
        private DevExpress.XtraEditors.SimpleButton cmdCancel;
        private DevExpress.XtraEditors.SimpleButton cmdOK;
        private DevExpress.XtraEditors.LabelControl lblBaudRate;
        private DevExpress.XtraEditors.ComboBoxEdit cboBaudRate;
        private DevExpress.XtraEditors.LabelControl lblParity;
        private DevExpress.XtraEditors.ComboBoxEdit cboParity;
        private DevExpress.XtraEditors.LabelControl lblStopBits;
        private DevExpress.XtraEditors.ComboBoxEdit cboStopBits;
        private DevExpress.XtraEditors.SpinEdit spnDataBits;
        private DevExpress.XtraEditors.LabelControl lblDataBits;
        private DevExpress.XtraEditors.LabelControl lblHandshake;
        private DevExpress.XtraEditors.ComboBoxEdit cboHandshake;
        private System.Windows.Forms.ImageList imlIcons;
        private DevExpress.XtraEditors.SpinEdit spnKeepaliveInterval;
        private DevExpress.XtraEditors.LabelControl lblTimeout;
        private DevExpress.XtraEditors.CheckEdit chkDebugMode;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.SpinEdit spnRWTimeout;
        private DevExpress.XtraEditors.LabelControl lblRWTimeout;
    }
}