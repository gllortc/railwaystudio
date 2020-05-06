namespace Rwm.Studio.Plugins.Designer.Views
{
   partial class AccessoryDecoderOutputEditorView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessoryDecoderOutputEditorView));
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
         this.spnAddress = new DevExpress.XtraEditors.SpinEdit();
         this.lblAddress = new DevExpress.XtraEditors.LabelControl();
         this.cboMode = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.lblMode = new DevExpress.XtraEditors.LabelControl();
         this.grpGeneral = new DevExpress.XtraEditors.GroupControl();
         this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
         this.lblParameterUnits3 = new DevExpress.XtraEditors.LabelControl();
         this.spnParameter3 = new DevExpress.XtraEditors.SpinEdit();
         this.lblParameter3 = new DevExpress.XtraEditors.LabelControl();
         this.lblParameterUnits2 = new DevExpress.XtraEditors.LabelControl();
         this.spnParameter2 = new DevExpress.XtraEditors.SpinEdit();
         this.lblParameter2 = new DevExpress.XtraEditors.LabelControl();
         this.lblParameterUnits1 = new DevExpress.XtraEditors.LabelControl();
         this.spnParameter1 = new DevExpress.XtraEditors.SpinEdit();
         this.lblParameter1 = new DevExpress.XtraEditors.LabelControl();
         this.cmdDisconnect = new DevExpress.XtraEditors.SimpleButton();
         this.grpConnection = new DevExpress.XtraEditors.GroupControl();
         this.lblConnectionInputElement = new DevExpress.XtraEditors.LabelControl();
         this.lblConnectionInput = new DevExpress.XtraEditors.LabelControl();
         this.lblConnectionElement = new DevExpress.XtraEditors.LabelControl();
         this.lblConnection = new DevExpress.XtraEditors.LabelControl();
         this.imlIcons = new System.Windows.Forms.ImageList(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.spnAddress.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboMode.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).BeginInit();
         this.grpGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
         this.groupControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spnParameter3.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.spnParameter2.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.spnParameter1.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpConnection)).BeginInit();
         this.grpConnection.SuspendLayout();
         this.SuspendLayout();
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.Location = new System.Drawing.Point(210, 361);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 0;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
         // 
         // cmdOK
         // 
         this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOK.Location = new System.Drawing.Point(129, 361);
         this.cmdOK.Name = "cmdOK";
         this.cmdOK.Size = new System.Drawing.Size(75, 23);
         this.cmdOK.TabIndex = 1;
         this.cmdOK.Text = "OK";
         this.cmdOK.Click += new System.EventHandler(this.CmdOK_Click);
         // 
         // spnAddress
         // 
         this.spnAddress.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.spnAddress.Location = new System.Drawing.Point(102, 33);
         this.spnAddress.Name = "spnAddress";
         this.spnAddress.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.spnAddress.Properties.Appearance.Options.UseFont = true;
         this.spnAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.spnAddress.Properties.Mask.EditMask = "4D";
         this.spnAddress.Size = new System.Drawing.Size(74, 20);
         this.spnAddress.TabIndex = 2;
         // 
         // lblAddress
         // 
         this.lblAddress.Location = new System.Drawing.Point(15, 36);
         this.lblAddress.Name = "lblAddress";
         this.lblAddress.Size = new System.Drawing.Size(39, 13);
         this.lblAddress.TabIndex = 3;
         this.lblAddress.Text = "Address";
         // 
         // cboMode
         // 
         this.cboMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboMode.Location = new System.Drawing.Point(102, 33);
         this.cboMode.Name = "cboMode";
         this.cboMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboMode.Properties.LargeImages = this.imlIcons;
         this.cboMode.Properties.SmallImages = this.imlIcons;
         this.cboMode.Size = new System.Drawing.Size(156, 20);
         this.cboMode.TabIndex = 4;
         this.cboMode.EditValueChanged += new System.EventHandler(this.CboMode_EditValueChanged);
         // 
         // lblMode
         // 
         this.lblMode.Location = new System.Drawing.Point(15, 36);
         this.lblMode.Name = "lblMode";
         this.lblMode.Size = new System.Drawing.Size(26, 13);
         this.lblMode.TabIndex = 5;
         this.lblMode.Text = "Mode";
         // 
         // grpGeneral
         // 
         this.grpGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpGeneral.Controls.Add(this.spnAddress);
         this.grpGeneral.Controls.Add(this.lblAddress);
         this.grpGeneral.Location = new System.Drawing.Point(12, 12);
         this.grpGeneral.Name = "grpGeneral";
         this.grpGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.grpGeneral.Size = new System.Drawing.Size(273, 66);
         this.grpGeneral.TabIndex = 7;
         this.grpGeneral.Text = "General";
         // 
         // groupControl1
         // 
         this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupControl1.Controls.Add(this.lblParameterUnits3);
         this.groupControl1.Controls.Add(this.spnParameter3);
         this.groupControl1.Controls.Add(this.lblParameter3);
         this.groupControl1.Controls.Add(this.lblParameterUnits2);
         this.groupControl1.Controls.Add(this.spnParameter2);
         this.groupControl1.Controls.Add(this.lblParameter2);
         this.groupControl1.Controls.Add(this.lblParameterUnits1);
         this.groupControl1.Controls.Add(this.cboMode);
         this.groupControl1.Controls.Add(this.lblMode);
         this.groupControl1.Controls.Add(this.spnParameter1);
         this.groupControl1.Controls.Add(this.lblParameter1);
         this.groupControl1.Location = new System.Drawing.Point(12, 84);
         this.groupControl1.Name = "groupControl1";
         this.groupControl1.Padding = new System.Windows.Forms.Padding(10);
         this.groupControl1.Size = new System.Drawing.Size(273, 146);
         this.groupControl1.TabIndex = 8;
         this.groupControl1.Text = "Operation mode";
         // 
         // lblParameterUnits3
         // 
         this.lblParameterUnits3.Location = new System.Drawing.Point(182, 114);
         this.lblParameterUnits3.Name = "lblParameterUnits3";
         this.lblParameterUnits3.Size = new System.Drawing.Size(55, 13);
         this.lblParameterUnits3.TabIndex = 12;
         this.lblParameterUnits3.Text = "milliseconds";
         // 
         // spnParameter3
         // 
         this.spnParameter3.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.spnParameter3.Location = new System.Drawing.Point(102, 111);
         this.spnParameter3.Name = "spnParameter3";
         this.spnParameter3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.spnParameter3.Properties.Mask.EditMask = "4D";
         this.spnParameter3.Size = new System.Drawing.Size(74, 20);
         this.spnParameter3.TabIndex = 10;
         // 
         // lblParameter3
         // 
         this.lblParameter3.Location = new System.Drawing.Point(15, 114);
         this.lblParameter3.Name = "lblParameter3";
         this.lblParameter3.Size = new System.Drawing.Size(41, 13);
         this.lblParameter3.TabIndex = 11;
         this.lblParameter3.Text = "Duration";
         // 
         // lblParameterUnits2
         // 
         this.lblParameterUnits2.Location = new System.Drawing.Point(182, 88);
         this.lblParameterUnits2.Name = "lblParameterUnits2";
         this.lblParameterUnits2.Size = new System.Drawing.Size(55, 13);
         this.lblParameterUnits2.TabIndex = 9;
         this.lblParameterUnits2.Text = "milliseconds";
         // 
         // spnParameter2
         // 
         this.spnParameter2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.spnParameter2.Location = new System.Drawing.Point(102, 85);
         this.spnParameter2.Name = "spnParameter2";
         this.spnParameter2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.spnParameter2.Properties.Mask.EditMask = "4D";
         this.spnParameter2.Size = new System.Drawing.Size(74, 20);
         this.spnParameter2.TabIndex = 7;
         // 
         // lblParameter2
         // 
         this.lblParameter2.Location = new System.Drawing.Point(15, 88);
         this.lblParameter2.Name = "lblParameter2";
         this.lblParameter2.Size = new System.Drawing.Size(41, 13);
         this.lblParameter2.TabIndex = 8;
         this.lblParameter2.Text = "Duration";
         // 
         // lblParameterUnits1
         // 
         this.lblParameterUnits1.Location = new System.Drawing.Point(182, 62);
         this.lblParameterUnits1.Name = "lblParameterUnits1";
         this.lblParameterUnits1.Size = new System.Drawing.Size(55, 13);
         this.lblParameterUnits1.TabIndex = 6;
         this.lblParameterUnits1.Text = "milliseconds";
         // 
         // spnParameter1
         // 
         this.spnParameter1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.spnParameter1.Location = new System.Drawing.Point(102, 59);
         this.spnParameter1.Name = "spnParameter1";
         this.spnParameter1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.spnParameter1.Properties.Mask.EditMask = "4D";
         this.spnParameter1.Size = new System.Drawing.Size(74, 20);
         this.spnParameter1.TabIndex = 4;
         // 
         // lblParameter1
         // 
         this.lblParameter1.Location = new System.Drawing.Point(15, 62);
         this.lblParameter1.Name = "lblParameter1";
         this.lblParameter1.Size = new System.Drawing.Size(41, 13);
         this.lblParameter1.TabIndex = 5;
         this.lblParameter1.Text = "Duration";
         // 
         // cmdDisconnect
         // 
         this.cmdDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.cmdDisconnect.Enabled = false;
         this.cmdDisconnect.ImageOptions.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources.ICO_CONNECTION_OFF_16;
         this.cmdDisconnect.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftTop;
         this.cmdDisconnect.Location = new System.Drawing.Point(15, 81);
         this.cmdDisconnect.Name = "cmdDisconnect";
         this.cmdDisconnect.Size = new System.Drawing.Size(88, 23);
         this.cmdDisconnect.TabIndex = 10;
         this.cmdDisconnect.Text = "Disconnect";
         // 
         // grpConnection
         // 
         this.grpConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpConnection.Controls.Add(this.lblConnectionInputElement);
         this.grpConnection.Controls.Add(this.lblConnectionInput);
         this.grpConnection.Controls.Add(this.lblConnectionElement);
         this.grpConnection.Controls.Add(this.cmdDisconnect);
         this.grpConnection.Controls.Add(this.lblConnection);
         this.grpConnection.Location = new System.Drawing.Point(12, 236);
         this.grpConnection.Name = "grpConnection";
         this.grpConnection.Padding = new System.Windows.Forms.Padding(10);
         this.grpConnection.Size = new System.Drawing.Size(273, 119);
         this.grpConnection.TabIndex = 8;
         this.grpConnection.Text = "Connection";
         // 
         // lblConnectionInputElement
         // 
         this.lblConnectionInputElement.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.lblConnectionInputElement.Appearance.Options.UseFont = true;
         this.lblConnectionInputElement.Location = new System.Drawing.Point(102, 55);
         this.lblConnectionInputElement.Name = "lblConnectionInputElement";
         this.lblConnectionInputElement.Size = new System.Drawing.Size(99, 13);
         this.lblConnectionInputElement.TabIndex = 12;
         this.lblConnectionInputElement.Text = "<not connected>";
         // 
         // lblConnectionInput
         // 
         this.lblConnectionInput.Location = new System.Drawing.Point(15, 55);
         this.lblConnectionInput.Name = "lblConnectionInput";
         this.lblConnectionInput.Size = new System.Drawing.Size(76, 13);
         this.lblConnectionInput.TabIndex = 11;
         this.lblConnectionInput.Text = "Accessory input";
         // 
         // lblConnectionElement
         // 
         this.lblConnectionElement.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.lblConnectionElement.Appearance.Options.UseFont = true;
         this.lblConnectionElement.Location = new System.Drawing.Point(102, 36);
         this.lblConnectionElement.Name = "lblConnectionElement";
         this.lblConnectionElement.Size = new System.Drawing.Size(99, 13);
         this.lblConnectionElement.TabIndex = 4;
         this.lblConnectionElement.Text = "<not connected>";
         // 
         // lblConnection
         // 
         this.lblConnection.Location = new System.Drawing.Point(15, 36);
         this.lblConnection.Name = "lblConnection";
         this.lblConnection.Size = new System.Drawing.Size(65, 13);
         this.lblConnection.TabIndex = 3;
         this.lblConnection.Text = "Connected to";
         // 
         // imlIcons
         // 
         this.imlIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlIcons.ImageStream")));
         this.imlIcons.TransparentColor = System.Drawing.Color.Transparent;
         this.imlIcons.Images.SetKeyName(0, "signal_continuous_16.png");
         this.imlIcons.Images.SetKeyName(1, "signal_shot_16.png");
         this.imlIcons.Images.SetKeyName(2, "signal_flash_16.png");
         this.imlIcons.Images.SetKeyName(3, "cog_go_16.png");
         // 
         // AccessoryDecoderOutputEditorView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(297, 396);
         this.Controls.Add(this.grpConnection);
         this.Controls.Add(this.groupControl1);
         this.Controls.Add(this.grpGeneral);
         this.Controls.Add(this.cmdOK);
         this.Controls.Add(this.cmdCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AccessoryDecoderOutputEditorView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Accessory decoder output properties";
         ((System.ComponentModel.ISupportInitialize)(this.spnAddress.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboMode.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).EndInit();
         this.grpGeneral.ResumeLayout(false);
         this.grpGeneral.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
         this.groupControl1.ResumeLayout(false);
         this.groupControl1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spnParameter3.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.spnParameter2.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.spnParameter1.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpConnection)).EndInit();
         this.grpConnection.ResumeLayout(false);
         this.grpConnection.PerformLayout();
         this.ResumeLayout(false);

      }

        #endregion

        private DevExpress.XtraEditors.SimpleButton cmdCancel;
        private DevExpress.XtraEditors.SimpleButton cmdOK;
        private DevExpress.XtraEditors.SpinEdit spnAddress;
        private DevExpress.XtraEditors.LabelControl lblAddress;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboMode;
        private DevExpress.XtraEditors.LabelControl lblMode;
        private DevExpress.XtraEditors.GroupControl grpGeneral;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblParameterUnits1;
        private DevExpress.XtraEditors.SpinEdit spnParameter1;
        private DevExpress.XtraEditors.LabelControl lblParameter1;
        private DevExpress.XtraEditors.LabelControl lblParameterUnits3;
        private DevExpress.XtraEditors.SpinEdit spnParameter3;
        private DevExpress.XtraEditors.LabelControl lblParameter3;
        private DevExpress.XtraEditors.LabelControl lblParameterUnits2;
        private DevExpress.XtraEditors.SpinEdit spnParameter2;
        private DevExpress.XtraEditors.LabelControl lblParameter2;
        private DevExpress.XtraEditors.SimpleButton cmdDisconnect;
        private DevExpress.XtraEditors.GroupControl grpConnection;
        private DevExpress.XtraEditors.LabelControl lblConnectionElement;
        private DevExpress.XtraEditors.LabelControl lblConnection;
        private DevExpress.XtraEditors.LabelControl lblConnectionInputElement;
        private DevExpress.XtraEditors.LabelControl lblConnectionInput;
        private System.Windows.Forms.ImageList imlIcons;
    }
}