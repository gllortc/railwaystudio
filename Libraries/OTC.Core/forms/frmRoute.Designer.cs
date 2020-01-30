namespace otc.forms
{
   partial class frmRoute
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoute));
         this.pnlTitle = new System.Windows.Forms.Panel();
         this.lblTitleTop = new System.Windows.Forms.Label();
         this.picWizard = new System.Windows.Forms.PictureBox();
         this.tabRoute = new System.Windows.Forms.TabControl();
         this.tabRouteGeneral = new System.Windows.Forms.TabPage();
         this.txtName = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.tabRouteElements = new System.Windows.Forms.TabPage();
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnAccept = new System.Windows.Forms.Button();
         this.pnlTitle.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picWizard)).BeginInit();
         this.tabRoute.SuspendLayout();
         this.tabRouteGeneral.SuspendLayout();
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
         this.pnlTitle.Size = new System.Drawing.Size(344, 68);
         this.pnlTitle.TabIndex = 14;
         // 
         // lblTitleTop
         // 
         this.lblTitleTop.AutoSize = true;
         this.lblTitleTop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTitleTop.Location = new System.Drawing.Point(13, 13);
         this.lblTitleTop.Name = "lblTitleTop";
         this.lblTitleTop.Size = new System.Drawing.Size(134, 13);
         this.lblTitleTop.TabIndex = 1;
         this.lblTitleTop.Text = "Propiedades de la ruta";
         // 
         // picWizard
         // 
         this.picWizard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.picWizard.Image = global::otc.Properties.Resources.WIZARD_OTC;
         this.picWizard.Location = new System.Drawing.Point(269, 0);
         this.picWizard.Name = "picWizard";
         this.picWizard.Size = new System.Drawing.Size(75, 66);
         this.picWizard.TabIndex = 0;
         this.picWizard.TabStop = false;
         // 
         // tabRoute
         // 
         this.tabRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.tabRoute.Controls.Add(this.tabRouteGeneral);
         this.tabRoute.Controls.Add(this.tabRouteElements);
         this.tabRoute.Location = new System.Drawing.Point(12, 74);
         this.tabRoute.Name = "tabRoute";
         this.tabRoute.SelectedIndex = 0;
         this.tabRoute.Size = new System.Drawing.Size(320, 217);
         this.tabRoute.TabIndex = 15;
         // 
         // tabRouteGeneral
         // 
         this.tabRouteGeneral.Controls.Add(this.txtName);
         this.tabRouteGeneral.Controls.Add(this.label1);
         this.tabRouteGeneral.Location = new System.Drawing.Point(4, 22);
         this.tabRouteGeneral.Name = "tabRouteGeneral";
         this.tabRouteGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.tabRouteGeneral.Size = new System.Drawing.Size(312, 191);
         this.tabRouteGeneral.TabIndex = 0;
         this.tabRouteGeneral.Text = "General";
         this.tabRouteGeneral.UseVisualStyleBackColor = true;
         // 
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Location = new System.Drawing.Point(83, 13);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(216, 21);
         this.txtName.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(44, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Nombre";
         // 
         // tabRouteElements
         // 
         this.tabRouteElements.Location = new System.Drawing.Point(4, 22);
         this.tabRouteElements.Name = "tabRouteElements";
         this.tabRouteElements.Padding = new System.Windows.Forms.Padding(3);
         this.tabRouteElements.Size = new System.Drawing.Size(312, 191);
         this.tabRouteElements.TabIndex = 1;
         this.tabRouteElements.Text = "Elementos";
         this.tabRouteElements.UseVisualStyleBackColor = true;
         // 
         // btnCancel
         // 
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(257, 297);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 16;
         this.btnCancel.Text = "Cancelar";
         this.btnCancel.UseVisualStyleBackColor = true;
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnAccept
         // 
         this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnAccept.Location = new System.Drawing.Point(176, 297);
         this.btnAccept.Name = "btnAccept";
         this.btnAccept.Size = new System.Drawing.Size(75, 23);
         this.btnAccept.TabIndex = 17;
         this.btnAccept.Text = "Aceptar";
         this.btnAccept.UseVisualStyleBackColor = true;
         this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
         // 
         // frmRoute
         // 
         this.AcceptButton = this.btnAccept;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(344, 332);
         this.Controls.Add(this.btnAccept);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.tabRoute);
         this.Controls.Add(this.pnlTitle);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmRoute";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "frmObjectExplorer";
         this.Load += new System.EventHandler(this.frmRoute_Load);
         this.pnlTitle.ResumeLayout(false);
         this.pnlTitle.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picWizard)).EndInit();
         this.tabRoute.ResumeLayout(false);
         this.tabRouteGeneral.ResumeLayout(false);
         this.tabRouteGeneral.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel pnlTitle;
      private System.Windows.Forms.Label lblTitleTop;
      private System.Windows.Forms.PictureBox picWizard;
      private System.Windows.Forms.TabControl tabRoute;
      private System.Windows.Forms.TabPage tabRouteGeneral;
      private System.Windows.Forms.TabPage tabRouteElements;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnAccept;
      private System.Windows.Forms.TextBox txtName;
      private System.Windows.Forms.Label label1;

   }
}