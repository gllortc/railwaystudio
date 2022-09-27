namespace Rwm.Studio.Plugins.Designer.Views
{
   partial class DecoderBuildView
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
         this.cmdClose = new DevExpress.XtraEditors.SimpleButton();
         this.cmdBurn = new DevExpress.XtraEditors.SimpleButton();
         this.txtOutput = new DevExpress.XtraEditors.MemoEdit();
         this.lblOutput = new DevExpress.XtraEditors.LabelControl();
         ((System.ComponentModel.ISupportInitialize)(this.txtOutput.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // cmdClose
         // 
         this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdClose.Location = new System.Drawing.Point(500, 363);
         this.cmdClose.Name = "cmdClose";
         this.cmdClose.Size = new System.Drawing.Size(75, 23);
         this.cmdClose.TabIndex = 0;
         this.cmdClose.Text = "Close";
         this.cmdClose.Click += new System.EventHandler(this.CmdClose_Click);
         // 
         // cmdBurn
         // 
         this.cmdBurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdBurn.Location = new System.Drawing.Point(454, 12);
         this.cmdBurn.Name = "cmdBurn";
         this.cmdBurn.Size = new System.Drawing.Size(121, 23);
         this.cmdBurn.TabIndex = 1;
         this.cmdBurn.Text = "Configure decoder";
         this.cmdBurn.Click += new System.EventHandler(this.CmdBurn_Click);
         // 
         // txtOutput
         // 
         this.txtOutput.EditValue = "Ready...";
         this.txtOutput.Location = new System.Drawing.Point(12, 125);
         this.txtOutput.Name = "txtOutput";
         this.txtOutput.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.txtOutput.Properties.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.txtOutput.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
         this.txtOutput.Properties.Appearance.Options.UseBackColor = true;
         this.txtOutput.Properties.Appearance.Options.UseForeColor = true;
         this.txtOutput.Size = new System.Drawing.Size(563, 232);
         this.txtOutput.TabIndex = 2;
         // 
         // lblOutput
         // 
         this.lblOutput.Location = new System.Drawing.Point(12, 106);
         this.lblOutput.Name = "lblOutput";
         this.lblOutput.Size = new System.Drawing.Size(72, 13);
         this.lblOutput.TabIndex = 3;
         this.lblOutput.Text = "Process output";
         // 
         // DecoderBuildView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(587, 398);
         this.Controls.Add(this.lblOutput);
         this.Controls.Add(this.txtOutput);
         this.Controls.Add(this.cmdBurn);
         this.Controls.Add(this.cmdClose);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "DecoderBuildView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Program decoder";
         ((System.ComponentModel.ISupportInitialize)(this.txtOutput.Properties)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.SimpleButton cmdClose;
      private DevExpress.XtraEditors.SimpleButton cmdBurn;
      private DevExpress.XtraEditors.MemoEdit txtOutput;
      private DevExpress.XtraEditors.LabelControl lblOutput;
   }
}