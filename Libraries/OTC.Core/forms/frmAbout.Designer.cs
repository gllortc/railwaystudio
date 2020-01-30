namespace otc.forms
{
    partial class frmAbout
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
           this.lblProductName = new System.Windows.Forms.Label();
           this.lblVersion = new System.Windows.Forms.Label();
           this.lblFramework = new System.Windows.Forms.Label();
           this.lblCopyright = new System.Windows.Forms.Label();
           this.lblInfo = new System.Windows.Forms.Label();
           this.picOTC = new System.Windows.Forms.PictureBox();
           this.cmdAccept = new System.Windows.Forms.Button();
           ((System.ComponentModel.ISupportInitialize)(this.picOTC)).BeginInit();
           this.SuspendLayout();
           // 
           // lblProductName
           // 
           this.lblProductName.AutoSize = true;
           this.lblProductName.BackColor = System.Drawing.Color.Transparent;
           this.lblProductName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.lblProductName.Location = new System.Drawing.Point(104, 43);
           this.lblProductName.Name = "lblProductName";
           this.lblProductName.Size = new System.Drawing.Size(83, 16);
           this.lblProductName.TabIndex = 1;
           this.lblProductName.Text = "<AppTitle>";
           // 
           // lblVersion
           // 
           this.lblVersion.AutoSize = true;
           this.lblVersion.BackColor = System.Drawing.Color.Transparent;
           this.lblVersion.Location = new System.Drawing.Point(104, 63);
           this.lblVersion.Name = "lblVersion";
           this.lblVersion.Size = new System.Drawing.Size(58, 13);
           this.lblVersion.TabIndex = 2;
           this.lblVersion.Text = "<Version>";
           // 
           // lblFramework
           // 
           this.lblFramework.AutoSize = true;
           this.lblFramework.BackColor = System.Drawing.Color.Transparent;
           this.lblFramework.Location = new System.Drawing.Point(104, 93);
           this.lblFramework.Name = "lblFramework";
           this.lblFramework.Size = new System.Drawing.Size(76, 13);
           this.lblFramework.TabIndex = 3;
           this.lblFramework.Text = "<Framework>";
           // 
           // lblCopyright
           // 
           this.lblCopyright.AutoSize = true;
           this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
           this.lblCopyright.Location = new System.Drawing.Point(104, 125);
           this.lblCopyright.Name = "lblCopyright";
           this.lblCopyright.Size = new System.Drawing.Size(70, 13);
           this.lblCopyright.TabIndex = 4;
           this.lblCopyright.Text = "<Copyright>";
           // 
           // lblInfo
           // 
           this.lblInfo.BackColor = System.Drawing.Color.Transparent;
           this.lblInfo.Location = new System.Drawing.Point(104, 154);
           this.lblInfo.Name = "lblInfo";
           this.lblInfo.Size = new System.Drawing.Size(283, 87);
           this.lblInfo.TabIndex = 5;
           this.lblInfo.Text = resources.GetString("lblInfo.Text");
           // 
           // picOTC
           // 
           this.picOTC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
           this.picOTC.Image = global::otc.Properties.Resources.IMG_LOGO_OTC;
           this.picOTC.Location = new System.Drawing.Point(345, 38);
           this.picOTC.Name = "picOTC";
           this.picOTC.Size = new System.Drawing.Size(42, 45);
           this.picOTC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
           this.picOTC.TabIndex = 6;
           this.picOTC.TabStop = false;
           // 
           // cmdAccept
           // 
           this.cmdAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.cmdAccept.Location = new System.Drawing.Point(312, 248);
           this.cmdAccept.Name = "cmdAccept";
           this.cmdAccept.Size = new System.Drawing.Size(75, 23);
           this.cmdAccept.TabIndex = 8;
           this.cmdAccept.Text = "Aceptar";
           this.cmdAccept.UseVisualStyleBackColor = true;
           this.cmdAccept.Click += new System.EventHandler(this.btnAccept_Click);
           // 
           // frmAbout
           // 
           this.AcceptButton = this.cmdAccept;
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.BackgroundImage = global::otc.Properties.Resources.IMG_FORMS_BACKGROUND;
           this.CancelButton = this.cmdAccept;
           this.ClientSize = new System.Drawing.Size(399, 283);
           this.Controls.Add(this.cmdAccept);
           this.Controls.Add(this.picOTC);
           this.Controls.Add(this.lblInfo);
           this.Controls.Add(this.lblCopyright);
           this.Controls.Add(this.lblFramework);
           this.Controls.Add(this.lblVersion);
           this.Controls.Add(this.lblProductName);
           this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "frmAbout";
           this.ShowInTaskbar = false;
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
           this.Text = "Acerca de...";
           ((System.ComponentModel.ISupportInitialize)(this.picOTC)).EndInit();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblFramework;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.PictureBox picOTC;
        private System.Windows.Forms.Button cmdAccept;
    }
}