namespace Rwm.Studio.Plugins.Control.Controls
{
   partial class SettingsControl
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.grpControl = new DevExpress.XtraEditors.GroupControl();
         this.chkControlAllowManualSensors = new DevExpress.XtraEditors.CheckEdit();
         ((System.ComponentModel.ISupportInitialize)(this.grpControl)).BeginInit();
         this.grpControl.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chkControlAllowManualSensors.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // grpControl
         // 
         this.grpControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpControl.Controls.Add(this.chkControlAllowManualSensors);
         this.grpControl.Location = new System.Drawing.Point(3, 3);
         this.grpControl.Name = "grpControl";
         this.grpControl.Padding = new System.Windows.Forms.Padding(10);
         this.grpControl.Size = new System.Drawing.Size(347, 72);
         this.grpControl.TabIndex = 0;
         this.grpControl.Text = "Layout control";
         // 
         // chkControlAllowManualSensors
         // 
         this.chkControlAllowManualSensors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.chkControlAllowManualSensors.Location = new System.Drawing.Point(15, 33);
         this.chkControlAllowManualSensors.Name = "chkControlAllowManualSensors";
         this.chkControlAllowManualSensors.Properties.Caption = "Allow manually activate sensors (by mouseclick)";
         this.chkControlAllowManualSensors.Size = new System.Drawing.Size(317, 19);
         this.chkControlAllowManualSensors.TabIndex = 0;
         this.chkControlAllowManualSensors.CheckedChanged += new System.EventHandler(this.chkControlAllowManualSensors_CheckedChanged);
         // 
         // SettingsControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grpControl);
         this.Name = "SettingsControl";
         this.Size = new System.Drawing.Size(353, 98);
         ((System.ComponentModel.ISupportInitialize)(this.grpControl)).EndInit();
         this.grpControl.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.chkControlAllowManualSensors.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.GroupControl grpControl;
      private DevExpress.XtraEditors.CheckEdit chkControlAllowManualSensors;
   }
}
