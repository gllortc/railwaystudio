namespace RailwayStudio.Common.Views
{
   partial class TrainAddressView
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
         this.grpAddress = new DevExpress.XtraEditors.GroupControl();
         this.lblOutputs = new DevExpress.XtraEditors.LabelControl();
         this.txtAddress = new DevExpress.XtraEditors.SpinEdit();
         this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
         this.txtCv18 = new DevExpress.XtraEditors.TextEdit();
         this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
         this.txtCv17 = new DevExpress.XtraEditors.TextEdit();
         this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
         this.txtCv1 = new DevExpress.XtraEditors.TextEdit();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.cmdClose = new DevExpress.XtraEditors.SimpleButton();
         ((System.ComponentModel.ISupportInitialize)(this.grpAddress)).BeginInit();
         this.grpAddress.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
         this.groupControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtCv18.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtCv17.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtCv1.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // grpAddress
         // 
         this.grpAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpAddress.Controls.Add(this.lblOutputs);
         this.grpAddress.Controls.Add(this.txtAddress);
         this.grpAddress.Location = new System.Drawing.Point(12, 12);
         this.grpAddress.Name = "grpAddress";
         this.grpAddress.Padding = new System.Windows.Forms.Padding(15);
         this.grpAddress.Size = new System.Drawing.Size(240, 77);
         this.grpAddress.TabIndex = 216;
         this.grpAddress.Text = "Digital properties";
         // 
         // lblOutputs
         // 
         this.lblOutputs.Location = new System.Drawing.Point(20, 41);
         this.lblOutputs.Name = "lblOutputs";
         this.lblOutputs.Size = new System.Drawing.Size(77, 13);
         this.lblOutputs.TabIndex = 6;
         this.lblOutputs.Text = "Desired address";
         // 
         // txtAddress
         // 
         this.txtAddress.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtAddress.Location = new System.Drawing.Point(131, 38);
         this.txtAddress.Name = "txtAddress";
         this.txtAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.txtAddress.Properties.IsFloatValue = false;
         this.txtAddress.Properties.Mask.EditMask = "N00";
         this.txtAddress.Properties.MaxValue = new decimal(new int[] {
            10239,
            0,
            0,
            0});
         this.txtAddress.Size = new System.Drawing.Size(87, 20);
         this.txtAddress.TabIndex = 7;
         this.txtAddress.EditValueChanged += new System.EventHandler(this.TxtAddress_EditValueChanged);
         // 
         // groupControl1
         // 
         this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupControl1.Controls.Add(this.txtCv18);
         this.groupControl1.Controls.Add(this.labelControl3);
         this.groupControl1.Controls.Add(this.txtCv17);
         this.groupControl1.Controls.Add(this.labelControl2);
         this.groupControl1.Controls.Add(this.txtCv1);
         this.groupControl1.Controls.Add(this.labelControl1);
         this.groupControl1.Location = new System.Drawing.Point(12, 95);
         this.groupControl1.Name = "groupControl1";
         this.groupControl1.Padding = new System.Windows.Forms.Padding(15);
         this.groupControl1.Size = new System.Drawing.Size(240, 130);
         this.groupControl1.TabIndex = 217;
         this.groupControl1.Text = "Digital properties";
         // 
         // txtCv18
         // 
         this.txtCv18.Location = new System.Drawing.Point(131, 90);
         this.txtCv18.Name = "txtCv18";
         this.txtCv18.Size = new System.Drawing.Size(87, 20);
         this.txtCv18.TabIndex = 12;
         // 
         // labelControl3
         // 
         this.labelControl3.Location = new System.Drawing.Point(20, 93);
         this.labelControl3.Name = "labelControl3";
         this.labelControl3.Size = new System.Drawing.Size(25, 13);
         this.labelControl3.TabIndex = 11;
         this.labelControl3.Text = "CV18";
         // 
         // txtCv17
         // 
         this.txtCv17.Location = new System.Drawing.Point(131, 64);
         this.txtCv17.Name = "txtCv17";
         this.txtCv17.Size = new System.Drawing.Size(87, 20);
         this.txtCv17.TabIndex = 10;
         // 
         // labelControl2
         // 
         this.labelControl2.Location = new System.Drawing.Point(20, 67);
         this.labelControl2.Name = "labelControl2";
         this.labelControl2.Size = new System.Drawing.Size(25, 13);
         this.labelControl2.TabIndex = 9;
         this.labelControl2.Text = "CV17";
         // 
         // txtCv1
         // 
         this.txtCv1.Location = new System.Drawing.Point(131, 38);
         this.txtCv1.Name = "txtCv1";
         this.txtCv1.Size = new System.Drawing.Size(87, 20);
         this.txtCv1.TabIndex = 8;
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(20, 41);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(96, 13);
         this.labelControl1.TabIndex = 7;
         this.labelControl1.Text = "CV1 (short address)";
         // 
         // cmdClose
         // 
         this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdClose.Location = new System.Drawing.Point(177, 231);
         this.cmdClose.Name = "cmdClose";
         this.cmdClose.Size = new System.Drawing.Size(75, 23);
         this.cmdClose.TabIndex = 218;
         this.cmdClose.Text = "Close";
         this.cmdClose.Click += new System.EventHandler(this.CmdClose_Click);
         // 
         // TrainAddressView
         // 
         this.AcceptButton = this.cmdClose;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdClose;
         this.ClientSize = new System.Drawing.Size(264, 266);
         this.Controls.Add(this.cmdClose);
         this.Controls.Add(this.groupControl1);
         this.Controls.Add(this.grpAddress);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "TrainAddressView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.Text = "Train address calculator";
         ((System.ComponentModel.ISupportInitialize)(this.grpAddress)).EndInit();
         this.grpAddress.ResumeLayout(false);
         this.grpAddress.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
         this.groupControl1.ResumeLayout(false);
         this.groupControl1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtCv18.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtCv17.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtCv1.Properties)).EndInit();
         this.ResumeLayout(false);

      }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpAddress;
        private DevExpress.XtraEditors.LabelControl lblOutputs;
        private DevExpress.XtraEditors.SpinEdit txtAddress;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtCv18;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtCv17;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtCv1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton cmdClose;
    }
}