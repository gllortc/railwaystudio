namespace otc.forms
{
   partial class frmLibraryProperties
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLibraryProperties));
         this.pnlTitle = new System.Windows.Forms.Panel();
         this.lblTitleTop = new System.Windows.Forms.Label();
         this.picWizard = new System.Windows.Forms.PictureBox();
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabPropertiesGeneral = new System.Windows.Forms.TabPage();
         this.grpLicense = new System.Windows.Forms.GroupBox();
         this.lblLicence = new System.Windows.Forms.Label();
         this.lblAuthor = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.lblBgColor = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.lblHeight = new System.Windows.Forms.Label();
         this.lblWidth = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.grpController = new System.Windows.Forms.GroupBox();
         this.lblVersion = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.lblElements = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.lblDescription = new System.Windows.Forms.Label();
         this.picIcon = new System.Windows.Forms.PictureBox();
         this.lblName = new System.Windows.Forms.Label();
         this.btnClose = new System.Windows.Forms.Button();
         this.txtFile = new System.Windows.Forms.TextBox();
         this.pnlTitle.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picWizard)).BeginInit();
         this.tabControl1.SuspendLayout();
         this.tabPropertiesGeneral.SuspendLayout();
         this.grpLicense.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.grpController.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
         this.SuspendLayout();
         // 
         // pnlTitle
         // 
         this.pnlTitle.BackColor = System.Drawing.Color.White;
         this.pnlTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTitle.BackgroundImage")));
         this.pnlTitle.Controls.Add(this.lblTitleTop);
         this.pnlTitle.Controls.Add(this.picWizard);
         this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
         this.pnlTitle.Location = new System.Drawing.Point(0, 0);
         this.pnlTitle.Name = "pnlTitle";
         this.pnlTitle.Size = new System.Drawing.Size(358, 68);
         this.pnlTitle.TabIndex = 6;
         // 
         // lblTitleTop
         // 
         this.lblTitleTop.AutoSize = true;
         this.lblTitleTop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTitleTop.Location = new System.Drawing.Point(13, 13);
         this.lblTitleTop.Name = "lblTitleTop";
         this.lblTitleTop.Size = new System.Drawing.Size(150, 13);
         this.lblTitleTop.TabIndex = 1;
         this.lblTitleTop.Text = "Propiedades de la librería";
         // 
         // picWizard
         // 
         this.picWizard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.picWizard.Image = global::otc.Properties.Resources.WIZARD_OTC;
         this.picWizard.Location = new System.Drawing.Point(283, 0);
         this.picWizard.Name = "picWizard";
         this.picWizard.Size = new System.Drawing.Size(75, 66);
         this.picWizard.TabIndex = 0;
         this.picWizard.TabStop = false;
         // 
         // tabControl1
         // 
         this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.tabControl1.Controls.Add(this.tabPropertiesGeneral);
         this.tabControl1.Location = new System.Drawing.Point(12, 74);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(334, 354);
         this.tabControl1.TabIndex = 7;
         // 
         // tabPropertiesGeneral
         // 
         this.tabPropertiesGeneral.Controls.Add(this.grpLicense);
         this.tabPropertiesGeneral.Controls.Add(this.groupBox1);
         this.tabPropertiesGeneral.Controls.Add(this.txtFile);
         this.tabPropertiesGeneral.Controls.Add(this.grpController);
         this.tabPropertiesGeneral.Controls.Add(this.picIcon);
         this.tabPropertiesGeneral.Controls.Add(this.lblName);
         this.tabPropertiesGeneral.Location = new System.Drawing.Point(4, 22);
         this.tabPropertiesGeneral.Name = "tabPropertiesGeneral";
         this.tabPropertiesGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.tabPropertiesGeneral.Size = new System.Drawing.Size(326, 328);
         this.tabPropertiesGeneral.TabIndex = 0;
         this.tabPropertiesGeneral.Text = "General";
         this.tabPropertiesGeneral.UseVisualStyleBackColor = true;
         // 
         // grpLicense
         // 
         this.grpLicense.Controls.Add(this.lblLicence);
         this.grpLicense.Controls.Add(this.lblAuthor);
         this.grpLicense.Controls.Add(this.label6);
         this.grpLicense.Controls.Add(this.label3);
         this.grpLicense.Location = new System.Drawing.Point(13, 249);
         this.grpLicense.Name = "grpLicense";
         this.grpLicense.Padding = new System.Windows.Forms.Padding(10);
         this.grpLicense.Size = new System.Drawing.Size(300, 66);
         this.grpLicense.TabIndex = 5;
         this.grpLicense.TabStop = false;
         this.grpLicense.Text = "Información de licéncia";
         // 
         // lblLicence
         // 
         this.lblLicence.AutoSize = true;
         this.lblLicence.Location = new System.Drawing.Point(71, 42);
         this.lblLicence.Name = "lblLicence";
         this.lblLicence.Size = new System.Drawing.Size(93, 13);
         this.lblLicence.TabIndex = 3;
         this.lblLicence.Text = "Sin licéncia de uso";
         // 
         // lblAuthor
         // 
         this.lblAuthor.AutoSize = true;
         this.lblAuthor.Location = new System.Drawing.Point(71, 24);
         this.lblAuthor.Name = "lblAuthor";
         this.lblAuthor.Size = new System.Drawing.Size(96, 13);
         this.lblAuthor.TabIndex = 2;
         this.lblAuthor.Text = "Autor desconocido";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(13, 42);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(44, 13);
         this.label6.TabIndex = 1;
         this.label6.Text = "Licéncia";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(13, 24);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(34, 13);
         this.label3.TabIndex = 0;
         this.label3.Text = "Autor";
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.lblBgColor);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.lblHeight);
         this.groupBox1.Controls.Add(this.lblElements);
         this.groupBox1.Controls.Add(this.lblWidth);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label8);
         this.groupBox1.Controls.Add(this.label9);
         this.groupBox1.Location = new System.Drawing.Point(13, 141);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
         this.groupBox1.Size = new System.Drawing.Size(300, 102);
         this.groupBox1.TabIndex = 4;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Características";
         // 
         // lblBgColor
         // 
         this.lblBgColor.AutoSize = true;
         this.lblBgColor.Location = new System.Drawing.Point(97, 60);
         this.lblBgColor.Name = "lblBgColor";
         this.lblBgColor.Size = new System.Drawing.Size(61, 13);
         this.lblBgColor.TabIndex = 5;
         this.lblBgColor.Text = "<BGColor>";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(13, 60);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(78, 13);
         this.label4.TabIndex = 4;
         this.label4.Text = "Color de fondo";
         // 
         // lblHeight
         // 
         this.lblHeight.AutoSize = true;
         this.lblHeight.Location = new System.Drawing.Point(97, 42);
         this.lblHeight.Name = "lblHeight";
         this.lblHeight.Size = new System.Drawing.Size(54, 13);
         this.lblHeight.TabIndex = 3;
         this.lblHeight.Text = "<Height>";
         // 
         // lblWidth
         // 
         this.lblWidth.AutoSize = true;
         this.lblWidth.Location = new System.Drawing.Point(97, 24);
         this.lblWidth.Name = "lblWidth";
         this.lblWidth.Size = new System.Drawing.Size(51, 13);
         this.lblWidth.TabIndex = 2;
         this.lblWidth.Text = "<Width>";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(13, 42);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(26, 13);
         this.label8.TabIndex = 1;
         this.label8.Text = "Alto";
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(13, 24);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(37, 13);
         this.label9.TabIndex = 0;
         this.label9.Text = "Ancho";
         // 
         // grpController
         // 
         this.grpController.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.grpController.Controls.Add(this.lblDescription);
         this.grpController.Controls.Add(this.lblVersion);
         this.grpController.Controls.Add(this.label5);
         this.grpController.Controls.Add(this.label1);
         this.grpController.Location = new System.Drawing.Point(13, 51);
         this.grpController.Name = "grpController";
         this.grpController.Padding = new System.Windows.Forms.Padding(10);
         this.grpController.Size = new System.Drawing.Size(300, 84);
         this.grpController.TabIndex = 3;
         this.grpController.TabStop = false;
         this.grpController.Text = "Librería";
         // 
         // lblVersion
         // 
         this.lblVersion.AutoSize = true;
         this.lblVersion.Location = new System.Drawing.Point(80, 24);
         this.lblVersion.Name = "lblVersion";
         this.lblVersion.Size = new System.Drawing.Size(58, 13);
         this.lblVersion.TabIndex = 5;
         this.lblVersion.Text = "<Version>";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(13, 24);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(42, 13);
         this.label5.TabIndex = 4;
         this.label5.Text = "Versión";
         // 
         // lblElements
         // 
         this.lblElements.AutoSize = true;
         this.lblElements.Location = new System.Drawing.Point(97, 78);
         this.lblElements.Name = "lblElements";
         this.lblElements.Size = new System.Drawing.Size(73, 13);
         this.lblElements.TabIndex = 3;
         this.lblElements.Text = "<NElements>";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(13, 78);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(56, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Elementos";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 42);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(61, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Descripción";
         // 
         // lblDescription
         // 
         this.lblDescription.Location = new System.Drawing.Point(80, 42);
         this.lblDescription.Name = "lblDescription";
         this.lblDescription.Size = new System.Drawing.Size(207, 32);
         this.lblDescription.TabIndex = 2;
         this.lblDescription.Text = "<Description>";
         // 
         // picIcon
         // 
         this.picIcon.ErrorImage = global::otc.Properties.Resources.IMG_LIBRARY;
         this.picIcon.Image = global::otc.Properties.Resources.IMG_LIBRARY;
         this.picIcon.InitialImage = global::otc.Properties.Resources.IMG_LIBRARY;
         this.picIcon.Location = new System.Drawing.Point(13, 13);
         this.picIcon.Name = "picIcon";
         this.picIcon.Size = new System.Drawing.Size(32, 32);
         this.picIcon.TabIndex = 1;
         this.picIcon.TabStop = false;
         // 
         // lblName
         // 
         this.lblName.AutoSize = true;
         this.lblName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblName.Location = new System.Drawing.Point(51, 13);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(57, 13);
         this.lblName.TabIndex = 0;
         this.lblName.Text = "<Name>";
         // 
         // btnClose
         // 
         this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnClose.Location = new System.Drawing.Point(271, 434);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(75, 23);
         this.btnClose.TabIndex = 8;
         this.btnClose.Text = "Cerrar";
         this.btnClose.UseVisualStyleBackColor = true;
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // txtFile
         // 
         this.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.txtFile.Location = new System.Drawing.Point(54, 29);
         this.txtFile.Name = "txtFile";
         this.txtFile.ReadOnly = true;
         this.txtFile.Size = new System.Drawing.Size(259, 14);
         this.txtFile.TabIndex = 6;
         // 
         // frmLibraryProperties
         // 
         this.AcceptButton = this.btnClose;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnClose;
         this.ClientSize = new System.Drawing.Size(358, 469);
         this.Controls.Add(this.btnClose);
         this.Controls.Add(this.tabControl1);
         this.Controls.Add(this.pnlTitle);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmLibraryProperties";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "OTC - Open Train Control";
         this.pnlTitle.ResumeLayout(false);
         this.pnlTitle.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picWizard)).EndInit();
         this.tabControl1.ResumeLayout(false);
         this.tabPropertiesGeneral.ResumeLayout(false);
         this.tabPropertiesGeneral.PerformLayout();
         this.grpLicense.ResumeLayout(false);
         this.grpLicense.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.grpController.ResumeLayout(false);
         this.grpController.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel pnlTitle;
      private System.Windows.Forms.Label lblTitleTop;
      private System.Windows.Forms.PictureBox picWizard;
      private System.Windows.Forms.TabControl tabControl1;
      private System.Windows.Forms.TabPage tabPropertiesGeneral;
      private System.Windows.Forms.Button btnClose;
      private System.Windows.Forms.Label lblName;
      private System.Windows.Forms.Label lblDescription;
      private System.Windows.Forms.PictureBox picIcon;
      private System.Windows.Forms.GroupBox grpController;
      private System.Windows.Forms.Label lblVersion;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label lblElements;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label lblBgColor;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label lblHeight;
      private System.Windows.Forms.Label lblWidth;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.GroupBox grpLicense;
      private System.Windows.Forms.Label lblLicence;
      private System.Windows.Forms.Label lblAuthor;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox txtFile;
   }
}