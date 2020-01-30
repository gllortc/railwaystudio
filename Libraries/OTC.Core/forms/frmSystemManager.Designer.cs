namespace otc
{
    partial class frmSystemManager
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystemManager));
           this.pnlTitle = new System.Windows.Forms.Panel();
           this.lblTitleTop = new System.Windows.Forms.Label();
           this.picWizard = new System.Windows.Forms.PictureBox();
           this.btnAddSystem = new System.Windows.Forms.Button();
           this.btnClose = new System.Windows.Forms.Button();
           this.drpSystems = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
           this.btnSelect = new System.Windows.Forms.Button();
           this.btnProperties = new System.Windows.Forms.Button();
           this.lblVersion = new System.Windows.Forms.Label();
           this.cmdDelete = new System.Windows.Forms.Button();
           this.cmdSetup = new System.Windows.Forms.Button();
           this.lblDescription = new System.Windows.Forms.Label();
           this.lblName = new System.Windows.Forms.Label();
           this.picIcon = new System.Windows.Forms.PictureBox();
           this.pnlTitle.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.picWizard)).BeginInit();
           this.drpSystems.ItemTemplate.SuspendLayout();
           this.drpSystems.SuspendLayout();
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
           this.pnlTitle.Size = new System.Drawing.Size(591, 68);
           this.pnlTitle.TabIndex = 5;
           // 
           // lblTitleTop
           // 
           this.lblTitleTop.AutoSize = true;
           this.lblTitleTop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.lblTitleTop.Location = new System.Drawing.Point(13, 13);
           this.lblTitleTop.Name = "lblTitleTop";
           this.lblTitleTop.Size = new System.Drawing.Size(178, 13);
           this.lblTitleTop.TabIndex = 1;
           this.lblTitleTop.Text = "Sistemas digitales registrados";
           // 
           // picWizard
           // 
           this.picWizard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
           this.picWizard.Image = global::otc.Properties.Resources.WIZARD_OTC;
           this.picWizard.Location = new System.Drawing.Point(516, 0);
           this.picWizard.Name = "picWizard";
           this.picWizard.Size = new System.Drawing.Size(75, 66);
           this.picWizard.TabIndex = 0;
           this.picWizard.TabStop = false;
           // 
           // btnAddSystem
           // 
           this.btnAddSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
           this.btnAddSystem.Location = new System.Drawing.Point(12, 478);
           this.btnAddSystem.Name = "btnAddSystem";
           this.btnAddSystem.Size = new System.Drawing.Size(94, 23);
           this.btnAddSystem.TabIndex = 13;
           this.btnAddSystem.Text = "Instalar";
           this.btnAddSystem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
           this.btnAddSystem.UseVisualStyleBackColor = true;
           this.btnAddSystem.Click += new System.EventHandler(this.btnAddSystem_Click);
           // 
           // btnClose
           // 
           this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.btnClose.Location = new System.Drawing.Point(485, 478);
           this.btnClose.Name = "btnClose";
           this.btnClose.Size = new System.Drawing.Size(94, 23);
           this.btnClose.TabIndex = 17;
           this.btnClose.Text = "Cerrar";
           this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
           this.btnClose.UseVisualStyleBackColor = true;
           this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
           // 
           // drpSystems
           // 
           this.drpSystems.AllowUserToAddItems = false;
           this.drpSystems.AllowUserToDeleteItems = false;
           this.drpSystems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.drpSystems.BackColor = System.Drawing.SystemColors.Window;
           this.drpSystems.ItemHeaderVisible = false;
           // 
           // drpSystems.ItemTemplate
           // 
           this.drpSystems.ItemTemplate.CausesValidation = false;
           this.drpSystems.ItemTemplate.Controls.Add(this.btnSelect);
           this.drpSystems.ItemTemplate.Controls.Add(this.btnProperties);
           this.drpSystems.ItemTemplate.Controls.Add(this.lblVersion);
           this.drpSystems.ItemTemplate.Controls.Add(this.cmdDelete);
           this.drpSystems.ItemTemplate.Controls.Add(this.cmdSetup);
           this.drpSystems.ItemTemplate.Controls.Add(this.lblDescription);
           this.drpSystems.ItemTemplate.Controls.Add(this.lblName);
           this.drpSystems.ItemTemplate.Controls.Add(this.picIcon);
           this.drpSystems.ItemTemplate.Margin = new System.Windows.Forms.Padding(5);
           this.drpSystems.ItemTemplate.Size = new System.Drawing.Size(559, 73);
           this.drpSystems.Location = new System.Drawing.Point(12, 74);
           this.drpSystems.Name = "drpSystems";
           this.drpSystems.Size = new System.Drawing.Size(567, 398);
           this.drpSystems.TabIndex = 19;
           this.drpSystems.Text = "dataRepeater1";
           // 
           // btnSelect
           // 
           this.btnSelect.Location = new System.Drawing.Point(44, 42);
           this.btnSelect.Name = "btnSelect";
           this.btnSelect.Size = new System.Drawing.Size(117, 23);
           this.btnSelect.TabIndex = 8;
           this.btnSelect.Text = "Usar este sistema";
           this.btnSelect.UseVisualStyleBackColor = true;
           this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
           // 
           // btnProperties
           // 
           this.btnProperties.Location = new System.Drawing.Point(317, 42);
           this.btnProperties.Name = "btnProperties";
           this.btnProperties.Size = new System.Drawing.Size(75, 23);
           this.btnProperties.TabIndex = 7;
           this.btnProperties.Text = "Propiedades";
           this.btnProperties.UseVisualStyleBackColor = true;
           this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
           // 
           // lblVersion
           // 
           this.lblVersion.AutoSize = true;
           this.lblVersion.Location = new System.Drawing.Point(510, 3);
           this.lblVersion.Name = "lblVersion";
           this.lblVersion.Size = new System.Drawing.Size(42, 13);
           this.lblVersion.TabIndex = 6;
           this.lblVersion.Text = "Version";
           this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
           // 
           // cmdDelete
           // 
           this.cmdDelete.Location = new System.Drawing.Point(479, 42);
           this.cmdDelete.Name = "cmdDelete";
           this.cmdDelete.Size = new System.Drawing.Size(75, 23);
           this.cmdDelete.TabIndex = 5;
           this.cmdDelete.Text = "Desinstalar";
           this.cmdDelete.UseVisualStyleBackColor = true;
           this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
           // 
           // cmdSetup
           // 
           this.cmdSetup.Location = new System.Drawing.Point(398, 42);
           this.cmdSetup.Name = "cmdSetup";
           this.cmdSetup.Size = new System.Drawing.Size(75, 23);
           this.cmdSetup.TabIndex = 4;
           this.cmdSetup.Text = "Configurar";
           this.cmdSetup.UseVisualStyleBackColor = true;
           this.cmdSetup.Click += new System.EventHandler(this.cmdSetup_Click);
           // 
           // lblDescription
           // 
           this.lblDescription.AutoSize = true;
           this.lblDescription.Location = new System.Drawing.Point(41, 18);
           this.lblDescription.Name = "lblDescription";
           this.lblDescription.Size = new System.Drawing.Size(60, 13);
           this.lblDescription.TabIndex = 2;
           this.lblDescription.Text = "Description";
           // 
           // lblName
           // 
           this.lblName.AutoSize = true;
           this.lblName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.lblName.Location = new System.Drawing.Point(41, 3);
           this.lblName.Name = "lblName";
           this.lblName.Size = new System.Drawing.Size(39, 13);
           this.lblName.TabIndex = 1;
           this.lblName.Text = "Name";
           // 
           // picIcon
           // 
           this.picIcon.Location = new System.Drawing.Point(3, 3);
           this.picIcon.Name = "picIcon";
           this.picIcon.Size = new System.Drawing.Size(32, 32);
           this.picIcon.TabIndex = 0;
           this.picIcon.TabStop = false;
           // 
           // frmSystemManager
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(591, 513);
           this.Controls.Add(this.drpSystems);
           this.Controls.Add(this.btnClose);
           this.Controls.Add(this.btnAddSystem);
           this.Controls.Add(this.pnlTitle);
           this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "frmSystemManager";
           this.ShowInTaskbar = false;
           this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
           this.Text = "OTC - Open Train Control";
           this.Load += new System.EventHandler(this.frmSystemRegister_Load);
           this.pnlTitle.ResumeLayout(false);
           this.pnlTitle.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.picWizard)).EndInit();
           this.drpSystems.ItemTemplate.ResumeLayout(false);
           this.drpSystems.ItemTemplate.PerformLayout();
           this.drpSystems.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitleTop;
        private System.Windows.Forms.PictureBox picWizard;
        private System.Windows.Forms.Button btnAddSystem;
        private System.Windows.Forms.Button btnClose;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater drpSystems;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdSetup;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnProperties;
        private System.Windows.Forms.Button btnSelect;
    }
}