namespace otc
{
    partial class frmSystemRegister
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystemRegister));
           this.grpLibrary = new System.Windows.Forms.GroupBox();
           this.cboClasses = new System.Windows.Forms.ComboBox();
           this.txtFilename = new System.Windows.Forms.TextBox();
           this.tbrFile = new System.Windows.Forms.ToolStrip();
           this.btnFileSelect = new System.Windows.Forms.ToolStripButton();
           this.label3 = new System.Windows.Forms.Label();
           this.label2 = new System.Windows.Forms.Label();
           this.label1 = new System.Windows.Forms.Label();
           this.imlIcons = new System.Windows.Forms.ImageList(this.components);
           this.lblInfo = new System.Windows.Forms.Label();
           this.pnlTitle = new System.Windows.Forms.Panel();
           this.label4 = new System.Windows.Forms.Label();
           this.lblTitleTop = new System.Windows.Forms.Label();
           this.picWizard = new System.Windows.Forms.PictureBox();
           this.btnRegister = new System.Windows.Forms.Button();
           this.btnCancel = new System.Windows.Forms.Button();
           this.grpLibrary.SuspendLayout();
           this.tbrFile.SuspendLayout();
           this.pnlTitle.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.picWizard)).BeginInit();
           this.SuspendLayout();
           // 
           // grpLibrary
           // 
           this.grpLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.grpLibrary.Controls.Add(this.cboClasses);
           this.grpLibrary.Controls.Add(this.txtFilename);
           this.grpLibrary.Controls.Add(this.tbrFile);
           this.grpLibrary.Controls.Add(this.label3);
           this.grpLibrary.Controls.Add(this.label2);
           this.grpLibrary.Controls.Add(this.label1);
           this.grpLibrary.Location = new System.Drawing.Point(12, 74);
           this.grpLibrary.Name = "grpLibrary";
           this.grpLibrary.Padding = new System.Windows.Forms.Padding(10);
           this.grpLibrary.Size = new System.Drawing.Size(454, 106);
           this.grpLibrary.TabIndex = 4;
           this.grpLibrary.TabStop = false;
           this.grpLibrary.Text = "Libreria";
           // 
           // cboClasses
           // 
           this.cboClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.cboClasses.FormattingEnabled = true;
           this.cboClasses.Location = new System.Drawing.Point(112, 54);
           this.cboClasses.Name = "cboClasses";
           this.cboClasses.Size = new System.Drawing.Size(329, 21);
           this.cboClasses.TabIndex = 3;
           this.cboClasses.SelectedIndexChanged += new System.EventHandler(this.cboClasses_SelectedIndexChanged);
           // 
           // txtFilename
           // 
           this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.txtFilename.Location = new System.Drawing.Point(112, 27);
           this.txtFilename.Name = "txtFilename";
           this.txtFilename.ReadOnly = true;
           this.txtFilename.Size = new System.Drawing.Size(303, 21);
           this.txtFilename.TabIndex = 1;
           // 
           // tbrFile
           // 
           this.tbrFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
           this.tbrFile.BackColor = System.Drawing.Color.Transparent;
           this.tbrFile.Dock = System.Windows.Forms.DockStyle.None;
           this.tbrFile.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
           this.tbrFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFileSelect});
           this.tbrFile.Location = new System.Drawing.Point(418, 24);
           this.tbrFile.Name = "tbrFile";
           this.tbrFile.Size = new System.Drawing.Size(26, 25);
           this.tbrFile.TabIndex = 14;
           this.tbrFile.Text = "toolStrip1";
           // 
           // btnFileSelect
           // 
           this.btnFileSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.btnFileSelect.Image = global::otc.Properties.Resources.folder_open;
           this.btnFileSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.btnFileSelect.Name = "btnFileSelect";
           this.btnFileSelect.Size = new System.Drawing.Size(23, 22);
           this.btnFileSelect.Text = "toolStripButton1";
           this.btnFileSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
           this.label3.Location = new System.Drawing.Point(109, 80);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(300, 13);
           this.label3.TabIndex = 7;
           this.label3.Text = "Usualmente, la clase del controlador usa el nombre Controller";
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(13, 57);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(93, 13);
           this.label2.TabIndex = 2;
           this.label2.Text = "Clases disponibles";
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(13, 30);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(43, 13);
           this.label1.TabIndex = 0;
           this.label1.Text = "Archivo";
           // 
           // imlIcons
           // 
           this.imlIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlIcons.ImageStream")));
           this.imlIcons.TransparentColor = System.Drawing.Color.Transparent;
           this.imlIcons.Images.SetKeyName(0, "IMG_SYSTEMS_CLASS");
           // 
           // lblInfo
           // 
           this.lblInfo.AutoSize = true;
           this.lblInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.lblInfo.Location = new System.Drawing.Point(12, 183);
           this.lblInfo.Name = "lblInfo";
           this.lblInfo.Size = new System.Drawing.Size(80, 13);
           this.lblInfo.TabIndex = 7;
           this.lblInfo.Text = "<controller>";
           this.lblInfo.Visible = false;
           // 
           // pnlTitle
           // 
           this.pnlTitle.BackColor = System.Drawing.Color.White;
           this.pnlTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTitle.BackgroundImage")));
           this.pnlTitle.Controls.Add(this.label4);
           this.pnlTitle.Controls.Add(this.lblTitleTop);
           this.pnlTitle.Controls.Add(this.picWizard);
           this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
           this.pnlTitle.Location = new System.Drawing.Point(0, 0);
           this.pnlTitle.Name = "pnlTitle";
           this.pnlTitle.Size = new System.Drawing.Size(478, 68);
           this.pnlTitle.TabIndex = 8;
           // 
           // label4
           // 
           this.label4.AutoSize = true;
           this.label4.Location = new System.Drawing.Point(12, 26);
           this.label4.Name = "label4";
           this.label4.Size = new System.Drawing.Size(89, 13);
           this.label4.TabIndex = 2;
           this.label4.Text = "de sistema digital";
           // 
           // lblTitleTop
           // 
           this.lblTitleTop.AutoSize = true;
           this.lblTitleTop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.lblTitleTop.Location = new System.Drawing.Point(13, 13);
           this.lblTitleTop.Name = "lblTitleTop";
           this.lblTitleTop.Size = new System.Drawing.Size(167, 13);
           this.lblTitleTop.TabIndex = 1;
           this.lblTitleTop.Text = "Registrar nuevo controlador";
           // 
           // picWizard
           // 
           this.picWizard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
           this.picWizard.Image = global::otc.Properties.Resources.WIZARD_OTC;
           this.picWizard.Location = new System.Drawing.Point(402, 0);
           this.picWizard.Name = "picWizard";
           this.picWizard.Size = new System.Drawing.Size(75, 66);
           this.picWizard.TabIndex = 0;
           this.picWizard.TabStop = false;
           // 
           // btnRegister
           // 
           this.btnRegister.Location = new System.Drawing.Point(310, 204);
           this.btnRegister.Name = "btnRegister";
           this.btnRegister.Size = new System.Drawing.Size(75, 23);
           this.btnRegister.TabIndex = 12;
           this.btnRegister.Text = "Registrar";
           this.btnRegister.UseVisualStyleBackColor = true;
           this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
           // 
           // btnCancel
           // 
           this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.btnCancel.Location = new System.Drawing.Point(391, 204);
           this.btnCancel.Name = "btnCancel";
           this.btnCancel.Size = new System.Drawing.Size(75, 23);
           this.btnCancel.TabIndex = 13;
           this.btnCancel.Text = "Cancelar";
           this.btnCancel.UseVisualStyleBackColor = true;
           this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
           // 
           // frmSystemRegister
           // 
           this.AcceptButton = this.btnRegister;
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.CancelButton = this.btnCancel;
           this.ClientSize = new System.Drawing.Size(478, 239);
           this.Controls.Add(this.btnCancel);
           this.Controls.Add(this.btnRegister);
           this.Controls.Add(this.pnlTitle);
           this.Controls.Add(this.lblInfo);
           this.Controls.Add(this.grpLibrary);
           this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "frmSystemRegister";
           this.ShowInTaskbar = false;
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "OTC - Open Train Control";
           this.Load += new System.EventHandler(this.frmSystemRegister_Load);
           this.grpLibrary.ResumeLayout(false);
           this.grpLibrary.PerformLayout();
           this.tbrFile.ResumeLayout(false);
           this.tbrFile.PerformLayout();
           this.pnlTitle.ResumeLayout(false);
           this.pnlTitle.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.picWizard)).EndInit();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLibrary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitleTop;
        private System.Windows.Forms.PictureBox picWizard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ImageList imlIcons;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStrip tbrFile;
        private System.Windows.Forms.ToolStripButton btnFileSelect;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.ComboBox cboClasses;
    }
}