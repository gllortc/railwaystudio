namespace Rwm.Studio.Views
{
   partial class SplashView
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
         this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
         this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
         this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
         ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // marqueeProgressBarControl1
         // 
         this.marqueeProgressBarControl1.EditValue = 0;
         this.marqueeProgressBarControl1.Location = new System.Drawing.Point(23, 235);
         this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
         this.marqueeProgressBarControl1.Size = new System.Drawing.Size(404, 12);
         this.marqueeProgressBarControl1.TabIndex = 5;
         // 
         // labelControl1
         // 
         this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
         this.labelControl1.Location = new System.Drawing.Point(23, 286);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(115, 13);
         this.labelControl1.TabIndex = 6;
         this.labelControl1.Text = "Copyright © 1998-2013";
         // 
         // labelControl2
         // 
         this.labelControl2.Location = new System.Drawing.Point(23, 216);
         this.labelControl2.Name = "labelControl2";
         this.labelControl2.Size = new System.Drawing.Size(120, 13);
         this.labelControl2.TabIndex = 7;
         this.labelControl2.Text = "Starting RailwayStudio...";
         // 
         // pictureEdit2
         // 
         this.pictureEdit2.EditValue = global::Rwm.Studio.Properties.Resources._1__16_2;
         this.pictureEdit2.Location = new System.Drawing.Point(12, 12);
         this.pictureEdit2.Name = "pictureEdit2";
         this.pictureEdit2.Properties.AllowFocused = false;
         this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
         this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
         this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
         this.pictureEdit2.Properties.ShowMenu = false;
         this.pictureEdit2.Size = new System.Drawing.Size(426, 183);
         this.pictureEdit2.TabIndex = 9;
         // 
         // pictureEdit1
         // 
         this.pictureEdit1.EditValue = global::Rwm.Studio.Properties.Resources.rwm_2;
         this.pictureEdit1.Location = new System.Drawing.Point(222, 253);
         this.pictureEdit1.Name = "pictureEdit1";
         this.pictureEdit1.Properties.AllowFocused = false;
         this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
         this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
         this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
         this.pictureEdit1.Properties.ShowMenu = false;
         this.pictureEdit1.Size = new System.Drawing.Size(216, 61);
         this.pictureEdit1.TabIndex = 8;
         // 
         // SplashView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(450, 320);
         this.Controls.Add(this.pictureEdit2);
         this.Controls.Add(this.pictureEdit1);
         this.Controls.Add(this.labelControl2);
         this.Controls.Add(this.labelControl1);
         this.Controls.Add(this.marqueeProgressBarControl1);
         this.Name = "SplashView";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.LabelControl labelControl2;
      private DevExpress.XtraEditors.PictureEdit pictureEdit1;
      private DevExpress.XtraEditors.PictureEdit pictureEdit2;
   }
}
