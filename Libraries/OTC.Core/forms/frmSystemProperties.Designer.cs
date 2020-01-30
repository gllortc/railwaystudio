namespace otc.forms
{
   partial class frmSystemProperties
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystemProperties));
         this.pnlTitle = new System.Windows.Forms.Panel();
         this.lblTitleTop = new System.Windows.Forms.Label();
         this.picWizard = new System.Windows.Forms.PictureBox();
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabPropertiesGeneral = new System.Windows.Forms.TabPage();
         this.label3 = new System.Windows.Forms.Label();
         this.lvwParameters = new System.Windows.Forms.ListView();
         this.btnSetup = new System.Windows.Forms.Button();
         this.grpController = new System.Windows.Forms.GroupBox();
         this.lblVersion = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.lblClass = new System.Windows.Forms.Label();
         this.lblFile = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.lblDescription = new System.Windows.Forms.Label();
         this.picIcon = new System.Windows.Forms.PictureBox();
         this.lblName = new System.Windows.Forms.Label();
         this.btnClose = new System.Windows.Forms.Button();
         this.pnlTitle.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picWizard)).BeginInit();
         this.tabControl1.SuspendLayout();
         this.tabPropertiesGeneral.SuspendLayout();
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
         this.lblTitleTop.Size = new System.Drawing.Size(166, 13);
         this.lblTitleTop.TabIndex = 1;
         this.lblTitleTop.Text = "Propiedades del controlador";
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
         this.tabPropertiesGeneral.Controls.Add(this.label3);
         this.tabPropertiesGeneral.Controls.Add(this.lvwParameters);
         this.tabPropertiesGeneral.Controls.Add(this.btnSetup);
         this.tabPropertiesGeneral.Controls.Add(this.grpController);
         this.tabPropertiesGeneral.Controls.Add(this.lblDescription);
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
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(13, 151);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(148, 13);
         this.label3.TabIndex = 6;
         this.label3.Text = "Parámetros de configuración:";
         // 
         // lvwParameters
         // 
         this.lvwParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.lvwParameters.Location = new System.Drawing.Point(13, 167);
         this.lvwParameters.Name = "lvwParameters";
         this.lvwParameters.Size = new System.Drawing.Size(300, 119);
         this.lvwParameters.TabIndex = 5;
         this.lvwParameters.UseCompatibleStateImageBehavior = false;
         // 
         // btnSetup
         // 
         this.btnSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.btnSetup.Location = new System.Drawing.Point(13, 292);
         this.btnSetup.Name = "btnSetup";
         this.btnSetup.Size = new System.Drawing.Size(75, 23);
         this.btnSetup.TabIndex = 4;
         this.btnSetup.Text = "Configurar";
         this.btnSetup.UseVisualStyleBackColor = true;
         this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
         // 
         // grpController
         // 
         this.grpController.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.grpController.Controls.Add(this.lblVersion);
         this.grpController.Controls.Add(this.label5);
         this.grpController.Controls.Add(this.lblClass);
         this.grpController.Controls.Add(this.lblFile);
         this.grpController.Controls.Add(this.label2);
         this.grpController.Controls.Add(this.label1);
         this.grpController.Location = new System.Drawing.Point(13, 51);
         this.grpController.Name = "grpController";
         this.grpController.Padding = new System.Windows.Forms.Padding(10);
         this.grpController.Size = new System.Drawing.Size(300, 85);
         this.grpController.TabIndex = 3;
         this.grpController.TabStop = false;
         this.grpController.Text = "Controlador";
         // 
         // lblVersion
         // 
         this.lblVersion.AutoSize = true;
         this.lblVersion.Location = new System.Drawing.Point(71, 60);
         this.lblVersion.Name = "lblVersion";
         this.lblVersion.Size = new System.Drawing.Size(58, 13);
         this.lblVersion.TabIndex = 5;
         this.lblVersion.Text = "<Version>";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(13, 60);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(42, 13);
         this.label5.TabIndex = 4;
         this.label5.Text = "Versión";
         // 
         // lblClass
         // 
         this.lblClass.AutoSize = true;
         this.lblClass.Location = new System.Drawing.Point(71, 42);
         this.lblClass.Name = "lblClass";
         this.lblClass.Size = new System.Drawing.Size(48, 13);
         this.lblClass.TabIndex = 3;
         this.lblClass.Text = "<Class>";
         // 
         // lblFile
         // 
         this.lblFile.AutoSize = true;
         this.lblFile.Location = new System.Drawing.Point(71, 24);
         this.lblFile.Name = "lblFile";
         this.lblFile.Size = new System.Drawing.Size(39, 13);
         this.lblFile.TabIndex = 2;
         this.lblFile.Text = "<File>";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(13, 42);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(33, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Clase";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 24);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(43, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Archivo";
         // 
         // lblDescription
         // 
         this.lblDescription.AutoSize = true;
         this.lblDescription.Location = new System.Drawing.Point(51, 27);
         this.lblDescription.Name = "lblDescription";
         this.lblDescription.Size = new System.Drawing.Size(76, 13);
         this.lblDescription.TabIndex = 2;
         this.lblDescription.Text = "<Description>";
         // 
         // picIcon
         // 
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
         // frmSystemProperties
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
         this.Name = "frmSystemProperties";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "OTC - Open Train Control";
         this.Load += new System.EventHandler(this.frmSystemProperties_Load);
         this.pnlTitle.ResumeLayout(false);
         this.pnlTitle.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picWizard)).EndInit();
         this.tabControl1.ResumeLayout(false);
         this.tabPropertiesGeneral.ResumeLayout(false);
         this.tabPropertiesGeneral.PerformLayout();
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
      private System.Windows.Forms.Button btnSetup;
      private System.Windows.Forms.Label lblVersion;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label lblClass;
      private System.Windows.Forms.Label lblFile;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ListView lvwParameters;
   }
}