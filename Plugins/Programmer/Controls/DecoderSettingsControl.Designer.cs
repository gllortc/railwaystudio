namespace Rwm.Studio.Plugins.Designer.Controls
{
   partial class DecoderSettingsControl
   {
      /// <summary> 
      /// Variable del diseñador necesaria.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Limpiar los recursos que se estén usando.
      /// </summary>
      /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Código generado por el Diseñador de componentes

      /// <summary> 
      /// Método necesario para admitir el Diseñador. No se puede modificar
      /// el contenido de este método con el editor de código.
      /// </summary>
      private void InitializeComponent()
      {
         this.grpOutput = new DevExpress.XtraEditors.GroupControl();
         this.txtPin2 = new DevExpress.XtraEditors.SpinEdit();
         this.lblPin2 = new DevExpress.XtraEditors.LabelControl();
         this.txtPin1 = new DevExpress.XtraEditors.SpinEdit();
         this.lblPin1 = new DevExpress.XtraEditors.LabelControl();
         this.cboType = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.lblType = new DevExpress.XtraEditors.LabelControl();
         this.txtAddress = new DevExpress.XtraEditors.SpinEdit();
         this.lblAddress = new DevExpress.XtraEditors.LabelControl();
         this.grpGeneral = new DevExpress.XtraEditors.GroupControl();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.txtNumOutputs = new DevExpress.XtraEditors.SpinEdit();
         this.lblNumOutputs = new DevExpress.XtraEditors.LabelControl();
         this.grpOutputs = new DevExpress.XtraEditors.GroupControl();
         this.trlOutputs = new DevExpress.XtraTreeList.TreeList();
         ((System.ComponentModel.ISupportInitialize)(this.grpOutput)).BeginInit();
         this.grpOutput.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtPin2.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtPin1.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).BeginInit();
         this.grpGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtNumOutputs.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpOutputs)).BeginInit();
         this.grpOutputs.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.trlOutputs)).BeginInit();
         this.SuspendLayout();
         // 
         // grpOutput
         // 
         this.grpOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpOutput.Controls.Add(this.txtPin2);
         this.grpOutput.Controls.Add(this.lblPin2);
         this.grpOutput.Controls.Add(this.txtPin1);
         this.grpOutput.Controls.Add(this.lblPin1);
         this.grpOutput.Controls.Add(this.cboType);
         this.grpOutput.Controls.Add(this.lblType);
         this.grpOutput.Controls.Add(this.txtAddress);
         this.grpOutput.Controls.Add(this.lblAddress);
         this.grpOutput.Location = new System.Drawing.Point(227, 103);
         this.grpOutput.Name = "grpOutput";
         this.grpOutput.Padding = new System.Windows.Forms.Padding(10);
         this.grpOutput.Size = new System.Drawing.Size(352, 381);
         this.grpOutput.TabIndex = 0;
         this.grpOutput.Text = "Output";
         // 
         // txtPin2
         // 
         this.txtPin2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtPin2.Location = new System.Drawing.Point(99, 85);
         this.txtPin2.Name = "txtPin2";
         this.txtPin2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.txtPin2.Size = new System.Drawing.Size(49, 20);
         this.txtPin2.TabIndex = 7;
         // 
         // lblPin2
         // 
         this.lblPin2.Location = new System.Drawing.Point(15, 88);
         this.lblPin2.Name = "lblPin2";
         this.lblPin2.Size = new System.Drawing.Size(63, 13);
         this.lblPin2.TabIndex = 6;
         this.lblPin2.Text = "Arduino pin 2";
         // 
         // txtPin1
         // 
         this.txtPin1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtPin1.Location = new System.Drawing.Point(99, 59);
         this.txtPin1.Name = "txtPin1";
         this.txtPin1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.txtPin1.Size = new System.Drawing.Size(49, 20);
         this.txtPin1.TabIndex = 5;
         // 
         // lblPin1
         // 
         this.lblPin1.Location = new System.Drawing.Point(15, 62);
         this.lblPin1.Name = "lblPin1";
         this.lblPin1.Size = new System.Drawing.Size(63, 13);
         this.lblPin1.TabIndex = 4;
         this.lblPin1.Text = "Arduino pin 1";
         // 
         // cboType
         // 
         this.cboType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboType.Location = new System.Drawing.Point(99, 111);
         this.cboType.Name = "cboType";
         this.cboType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboType.Size = new System.Drawing.Size(238, 20);
         this.cboType.TabIndex = 3;
         // 
         // lblType
         // 
         this.lblType.Location = new System.Drawing.Point(15, 114);
         this.lblType.Name = "lblType";
         this.lblType.Size = new System.Drawing.Size(59, 13);
         this.lblType.TabIndex = 2;
         this.lblType.Text = "Output type";
         // 
         // txtAddress
         // 
         this.txtAddress.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtAddress.Location = new System.Drawing.Point(99, 33);
         this.txtAddress.Name = "txtAddress";
         this.txtAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.txtAddress.Size = new System.Drawing.Size(73, 20);
         this.txtAddress.TabIndex = 1;
         // 
         // lblAddress
         // 
         this.lblAddress.Location = new System.Drawing.Point(15, 36);
         this.lblAddress.Name = "lblAddress";
         this.lblAddress.Size = new System.Drawing.Size(39, 13);
         this.lblAddress.TabIndex = 0;
         this.lblAddress.Text = "Address";
         // 
         // grpGeneral
         // 
         this.grpGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpGeneral.Controls.Add(this.txtName);
         this.grpGeneral.Controls.Add(this.lblName);
         this.grpGeneral.Controls.Add(this.txtNumOutputs);
         this.grpGeneral.Controls.Add(this.lblNumOutputs);
         this.grpGeneral.Location = new System.Drawing.Point(3, 3);
         this.grpGeneral.Name = "grpGeneral";
         this.grpGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.grpGeneral.Size = new System.Drawing.Size(576, 94);
         this.grpGeneral.TabIndex = 1;
         this.grpGeneral.Text = "General";
         // 
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Location = new System.Drawing.Point(126, 33);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(435, 20);
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
         // txtNumOutputs
         // 
         this.txtNumOutputs.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtNumOutputs.Location = new System.Drawing.Point(126, 59);
         this.txtNumOutputs.Name = "txtNumOutputs";
         this.txtNumOutputs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.txtNumOutputs.Size = new System.Drawing.Size(73, 20);
         this.txtNumOutputs.TabIndex = 3;
         // 
         // lblNumOutputs
         // 
         this.lblNumOutputs.Location = new System.Drawing.Point(15, 62);
         this.lblNumOutputs.Name = "lblNumOutputs";
         this.lblNumOutputs.Size = new System.Drawing.Size(90, 13);
         this.lblNumOutputs.TabIndex = 2;
         this.lblNumOutputs.Text = "Number of outputs";
         // 
         // grpOutputs
         // 
         this.grpOutputs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
         this.grpOutputs.Controls.Add(this.trlOutputs);
         this.grpOutputs.Location = new System.Drawing.Point(3, 103);
         this.grpOutputs.Name = "grpOutputs";
         this.grpOutputs.Size = new System.Drawing.Size(220, 381);
         this.grpOutputs.TabIndex = 2;
         this.grpOutputs.Text = "Decoder outputs";
         // 
         // trlOutputs
         // 
         this.trlOutputs.Dock = System.Windows.Forms.DockStyle.Fill;
         this.trlOutputs.Location = new System.Drawing.Point(2, 20);
         this.trlOutputs.Name = "trlOutputs";
         this.trlOutputs.Size = new System.Drawing.Size(216, 359);
         this.trlOutputs.TabIndex = 0;
         // 
         // DecoderSettingsControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grpOutputs);
         this.Controls.Add(this.grpGeneral);
         this.Controls.Add(this.grpOutput);
         this.Name = "DecoderSettingsControl";
         this.Size = new System.Drawing.Size(582, 487);
         ((System.ComponentModel.ISupportInitialize)(this.grpOutput)).EndInit();
         this.grpOutput.ResumeLayout(false);
         this.grpOutput.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtPin2.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtPin1.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).EndInit();
         this.grpGeneral.ResumeLayout(false);
         this.grpGeneral.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtNumOutputs.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpOutputs)).EndInit();
         this.grpOutputs.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.trlOutputs)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.GroupControl grpOutput;
      private DevExpress.XtraEditors.ImageComboBoxEdit cboType;
      private DevExpress.XtraEditors.LabelControl lblType;
      private DevExpress.XtraEditors.SpinEdit txtAddress;
      private DevExpress.XtraEditors.LabelControl lblAddress;
      private DevExpress.XtraEditors.GroupControl grpGeneral;
      private DevExpress.XtraEditors.TextEdit txtName;
      private DevExpress.XtraEditors.LabelControl lblName;
      private DevExpress.XtraEditors.SpinEdit txtNumOutputs;
      private DevExpress.XtraEditors.LabelControl lblNumOutputs;
      private DevExpress.XtraEditors.GroupControl grpOutputs;
      private DevExpress.XtraTreeList.TreeList trlOutputs;
      private DevExpress.XtraEditors.SpinEdit txtPin2;
      private DevExpress.XtraEditors.LabelControl lblPin2;
      private DevExpress.XtraEditors.SpinEdit txtPin1;
      private DevExpress.XtraEditors.LabelControl lblPin1;
   }
}
