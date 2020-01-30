namespace Rwm.Studio.Views
{
   partial class AboutView
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
         this.lblProductName = new DevExpress.XtraEditors.LabelControl();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.lblProductVersion = new DevExpress.XtraEditors.LabelControl();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // cmdClose
         // 
         this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdClose.Location = new System.Drawing.Point(421, 265);
         this.cmdClose.Name = "cmdClose";
         this.cmdClose.Size = new System.Drawing.Size(75, 23);
         this.cmdClose.TabIndex = 0;
         this.cmdClose.Text = "OK";
         this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
         // 
         // lblProductName
         // 
         this.lblProductName.Appearance.FontSizeDelta = 2;
         this.lblProductName.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
         this.lblProductName.Location = new System.Drawing.Point(12, 209);
         this.lblProductName.Name = "lblProductName";
         this.lblProductName.Size = new System.Drawing.Size(117, 17);
         this.lblProductName.TabIndex = 3;
         this.lblProductName.Text = "<ProductName>";
         // 
         // pictureBox1
         // 
         this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
         this.pictureBox1.Image = global::Rwm.Studio.Properties.Resources.IMG_ABOUT;
         this.pictureBox1.Location = new System.Drawing.Point(0, 0);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(508, 193);
         this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.pictureBox1.TabIndex = 1;
         this.pictureBox1.TabStop = false;
         // 
         // lblProductVersion
         // 
         this.lblProductVersion.Location = new System.Drawing.Point(12, 232);
         this.lblProductVersion.Name = "lblProductVersion";
         this.lblProductVersion.Size = new System.Drawing.Size(88, 13);
         this.lblProductVersion.TabIndex = 4;
         this.lblProductVersion.Text = "<ProductVersion>";
         // 
         // FrmAbout
         // 
         this.AcceptButton = this.cmdClose;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdClose;
         this.ClientSize = new System.Drawing.Size(508, 300);
         this.Controls.Add(this.lblProductVersion);
         this.Controls.Add(this.lblProductName);
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this.cmdClose);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmAbout";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "About";
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.SimpleButton cmdClose;
      private System.Windows.Forms.PictureBox pictureBox1;
      private DevExpress.XtraEditors.LabelControl lblProductName;
      private DevExpress.XtraEditors.LabelControl lblProductVersion;
   }
}