namespace Rwm.Studio.Plugins.Designer.Views
{
   partial class EMotionActionSirenLightsEditorView
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
         this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
         this.lblOutput1 = new DevExpress.XtraEditors.LabelControl();
         this.spinOutput1 = new DevExpress.XtraEditors.SpinEdit();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
         this.lblButton = new DevExpress.XtraEditors.LabelControl();
         this.cboButton = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.grpActivation = new DevExpress.XtraEditors.GroupControl();
         this.lblOutput2 = new DevExpress.XtraEditors.LabelControl();
         this.spinOutput2 = new DevExpress.XtraEditors.SpinEdit();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
         this.groupControl2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spinOutput1.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboButton.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpActivation)).BeginInit();
         this.grpActivation.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spinOutput2.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // groupControl2
         // 
         this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupControl2.Controls.Add(this.lblOutput2);
         this.groupControl2.Controls.Add(this.spinOutput2);
         this.groupControl2.Controls.Add(this.lblOutput1);
         this.groupControl2.Controls.Add(this.spinOutput1);
         this.groupControl2.Location = new System.Drawing.Point(12, 12);
         this.groupControl2.Name = "groupControl2";
         this.groupControl2.Padding = new System.Windows.Forms.Padding(10);
         this.groupControl2.Size = new System.Drawing.Size(317, 96);
         this.groupControl2.TabIndex = 5;
         this.groupControl2.Text = "Connection";
         // 
         // lblOutput1
         // 
         this.lblOutput1.Location = new System.Drawing.Point(15, 36);
         this.lblOutput1.Name = "lblOutput1";
         this.lblOutput1.Size = new System.Drawing.Size(128, 13);
         this.lblOutput1.TabIndex = 1;
         this.lblOutput1.Text = "LED 1 connected to output";
         // 
         // spinOutput1
         // 
         this.spinOutput1.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.spinOutput1.Location = new System.Drawing.Point(151, 33);
         this.spinOutput1.Name = "spinOutput1";
         this.spinOutput1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.spinOutput1.Properties.MaxValue = new decimal(new int[] {
            8,
            0,
            0,
            0});
         this.spinOutput1.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.spinOutput1.Size = new System.Drawing.Size(64, 20);
         this.spinOutput1.TabIndex = 0;
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(254, 188);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 1;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
         // 
         // cmdOK
         // 
         this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOK.Location = new System.Drawing.Point(173, 188);
         this.cmdOK.Name = "cmdOK";
         this.cmdOK.Size = new System.Drawing.Size(75, 23);
         this.cmdOK.TabIndex = 2;
         this.cmdOK.Text = "OK";
         this.cmdOK.Click += new System.EventHandler(this.CmdOK_Click);
         // 
         // lblButton
         // 
         this.lblButton.Location = new System.Drawing.Point(15, 36);
         this.lblButton.Name = "lblButton";
         this.lblButton.Size = new System.Drawing.Size(122, 13);
         this.lblButton.TabIndex = 2;
         this.lblButton.Text = "Activated by push button";
         // 
         // cboButton
         // 
         this.cboButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboButton.Location = new System.Drawing.Point(151, 33);
         this.cboButton.Name = "cboButton";
         this.cboButton.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboButton.Size = new System.Drawing.Size(151, 20);
         this.cboButton.TabIndex = 3;
         // 
         // grpActivation
         // 
         this.grpActivation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpActivation.Controls.Add(this.cboButton);
         this.grpActivation.Controls.Add(this.lblButton);
         this.grpActivation.Location = new System.Drawing.Point(12, 114);
         this.grpActivation.Name = "grpActivation";
         this.grpActivation.Padding = new System.Windows.Forms.Padding(10);
         this.grpActivation.Size = new System.Drawing.Size(317, 68);
         this.grpActivation.TabIndex = 6;
         this.grpActivation.Text = "Activation";
         // 
         // lblOutput2
         // 
         this.lblOutput2.Location = new System.Drawing.Point(15, 62);
         this.lblOutput2.Name = "lblOutput2";
         this.lblOutput2.Size = new System.Drawing.Size(128, 13);
         this.lblOutput2.TabIndex = 3;
         this.lblOutput2.Text = "LED 2 connected to output";
         // 
         // spinOutput2
         // 
         this.spinOutput2.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.spinOutput2.Location = new System.Drawing.Point(151, 59);
         this.spinOutput2.Name = "spinOutput2";
         this.spinOutput2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.spinOutput2.Properties.MaxValue = new decimal(new int[] {
            8,
            0,
            0,
            0});
         this.spinOutput2.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.spinOutput2.Size = new System.Drawing.Size(64, 20);
         this.spinOutput2.TabIndex = 2;
         // 
         // EMotionActionSirenLightsEditorView
         // 
         this.AcceptButton = this.cmdOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(341, 223);
         this.Controls.Add(this.grpActivation);
         this.Controls.Add(this.groupControl2);
         this.Controls.Add(this.cmdOK);
         this.Controls.Add(this.cmdCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "EMotionActionSirenLightsEditorView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Siren lights action";
         ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
         this.groupControl2.ResumeLayout(false);
         this.groupControl2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spinOutput1.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboButton.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpActivation)).EndInit();
         this.grpActivation.ResumeLayout(false);
         this.grpActivation.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spinOutput2.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion
      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.SimpleButton cmdOK;
      private DevExpress.XtraEditors.GroupControl groupControl2;
      private DevExpress.XtraEditors.LabelControl lblOutput1;
      private DevExpress.XtraEditors.SpinEdit spinOutput1;
      private DevExpress.XtraEditors.LabelControl lblButton;
      private DevExpress.XtraEditors.ImageComboBoxEdit cboButton;
      private DevExpress.XtraEditors.GroupControl grpActivation;
      private DevExpress.XtraEditors.LabelControl lblOutput2;
      private DevExpress.XtraEditors.SpinEdit spinOutput2;
   }
}