namespace Rwm.Studio.Plugins.Control.Views
{
   partial class FrmConnectionEditor
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
         DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdAccept = new DevExpress.XtraEditors.SimpleButton();
         this.txtOutput = new DevExpress.XtraEditors.ButtonEdit();
         this.lblOutput = new DevExpress.XtraEditors.LabelControl();
         this.lblSwitchDelay = new DevExpress.XtraEditors.LabelControl();
         this.txtSwitchDelay = new DevExpress.XtraEditors.SpinEdit();
         this.lblSwitchDelayUnit = new DevExpress.XtraEditors.LabelControl();
         this.chkInverted = new DevExpress.XtraEditors.CheckEdit();
         ((System.ComponentModel.ISupportInitialize)(this.txtOutput.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtSwitchDelay.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.chkInverted.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(236, 159);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 0;
         this.cmdCancel.Text = "Cancel";
         // 
         // cmdAccept
         // 
         this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdAccept.Location = new System.Drawing.Point(155, 159);
         this.cmdAccept.Name = "cmdAccept";
         this.cmdAccept.Size = new System.Drawing.Size(75, 23);
         this.cmdAccept.TabIndex = 1;
         this.cmdAccept.Text = "Accept";
         // 
         // txtOutput
         // 
         this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtOutput.Location = new System.Drawing.Point(12, 31);
         this.txtOutput.Name = "txtOutput";
         this.txtOutput.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_FIND_16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
         this.txtOutput.Size = new System.Drawing.Size(299, 22);
         this.txtOutput.TabIndex = 2;
         this.txtOutput.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtOutput_ButtonClick);
         // 
         // lblOutput
         // 
         this.lblOutput.Location = new System.Drawing.Point(12, 12);
         this.lblOutput.Name = "lblOutput";
         this.lblOutput.Size = new System.Drawing.Size(88, 13);
         this.lblOutput.TabIndex = 3;
         this.lblOutput.Text = "Connect to output";
         // 
         // lblSwitchDelay
         // 
         this.lblSwitchDelay.Location = new System.Drawing.Point(12, 62);
         this.lblSwitchDelay.Name = "lblSwitchDelay";
         this.lblSwitchDelay.Size = new System.Drawing.Size(60, 13);
         this.lblSwitchDelay.TabIndex = 4;
         this.lblSwitchDelay.Text = "Switch delay";
         // 
         // txtSwitchDelay
         // 
         this.txtSwitchDelay.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtSwitchDelay.Location = new System.Drawing.Point(12, 81);
         this.txtSwitchDelay.Name = "txtSwitchDelay";
         this.txtSwitchDelay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.txtSwitchDelay.Size = new System.Drawing.Size(100, 20);
         this.txtSwitchDelay.TabIndex = 5;
         // 
         // lblSwitchDelayUnit
         // 
         this.lblSwitchDelayUnit.Location = new System.Drawing.Point(118, 84);
         this.lblSwitchDelayUnit.Name = "lblSwitchDelayUnit";
         this.lblSwitchDelayUnit.Size = new System.Drawing.Size(25, 13);
         this.lblSwitchDelayUnit.TabIndex = 6;
         this.lblSwitchDelayUnit.Text = "mSec";
         // 
         // chkInverted
         // 
         this.chkInverted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.chkInverted.Location = new System.Drawing.Point(12, 119);
         this.chkInverted.Name = "chkInverted";
         this.chkInverted.Properties.Caption = "Invert outputs";
         this.chkInverted.Size = new System.Drawing.Size(299, 19);
         this.chkInverted.TabIndex = 7;
         // 
         // FrmConnectionEditor
         // 
         this.AcceptButton = this.cmdAccept;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(323, 194);
         this.Controls.Add(this.chkInverted);
         this.Controls.Add(this.lblSwitchDelayUnit);
         this.Controls.Add(this.txtSwitchDelay);
         this.Controls.Add(this.lblSwitchDelay);
         this.Controls.Add(this.lblOutput);
         this.Controls.Add(this.txtOutput);
         this.Controls.Add(this.cmdAccept);
         this.Controls.Add(this.cmdCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmConnectionEditor";
         this.Text = "Connection editor";
         ((System.ComponentModel.ISupportInitialize)(this.txtOutput.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtSwitchDelay.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.chkInverted.Properties)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.SimpleButton cmdAccept;
      private DevExpress.XtraEditors.ButtonEdit txtOutput;
      private DevExpress.XtraEditors.LabelControl lblOutput;
      private DevExpress.XtraEditors.LabelControl lblSwitchDelay;
      private DevExpress.XtraEditors.SpinEdit txtSwitchDelay;
      private DevExpress.XtraEditors.LabelControl lblSwitchDelayUnit;
      private DevExpress.XtraEditors.CheckEdit chkInverted;
   }
}