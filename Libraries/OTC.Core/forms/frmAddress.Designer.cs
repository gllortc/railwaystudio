namespace otc.forms
{
   partial class frmAddress
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddress));
         this.pnlTitle = new System.Windows.Forms.Panel();
         this.lblTitleTop = new System.Windows.Forms.Label();
         this.picWizard = new System.Windows.Forms.PictureBox();
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnAccept = new System.Windows.Forms.Button();
         this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
         this.label1 = new System.Windows.Forms.Label();
         this.pnlTitle.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picWizard)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
         this.pnlTitle.Size = new System.Drawing.Size(326, 68);
         this.pnlTitle.TabIndex = 6;
         // 
         // lblTitleTop
         // 
         this.lblTitleTop.AutoSize = true;
         this.lblTitleTop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTitleTop.Location = new System.Drawing.Point(13, 13);
         this.lblTitleTop.Name = "lblTitleTop";
         this.lblTitleTop.Size = new System.Drawing.Size(137, 13);
         this.lblTitleTop.TabIndex = 1;
         this.lblTitleTop.Text = "Buscar dirección digital";
         // 
         // picWizard
         // 
         this.picWizard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.picWizard.Image = global::otc.Properties.Resources.WIZARD_SEARCH;
         this.picWizard.Location = new System.Drawing.Point(251, 0);
         this.picWizard.Name = "picWizard";
         this.picWizard.Size = new System.Drawing.Size(75, 66);
         this.picWizard.TabIndex = 0;
         this.picWizard.TabStop = false;
         // 
         // btnCancel
         // 
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(239, 206);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 7;
         this.btnCancel.Text = "Cancelar";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // btnAccept
         // 
         this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnAccept.Location = new System.Drawing.Point(158, 206);
         this.btnAccept.Name = "btnAccept";
         this.btnAccept.Size = new System.Drawing.Size(75, 23);
         this.btnAccept.TabIndex = 8;
         this.btnAccept.Text = "Aceptar";
         this.btnAccept.UseVisualStyleBackColor = true;
         // 
         // numericUpDown1
         // 
         this.numericUpDown1.Location = new System.Drawing.Point(68, 93);
         this.numericUpDown1.Name = "numericUpDown1";
         this.numericUpDown1.Size = new System.Drawing.Size(82, 21);
         this.numericUpDown1.TabIndex = 9;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 95);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(50, 13);
         this.label1.TabIndex = 10;
         this.label1.Text = "Dirección";
         // 
         // frmAddress
         // 
         this.AcceptButton = this.btnAccept;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(326, 241);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.numericUpDown1);
         this.Controls.Add(this.btnAccept);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.pnlTitle);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmAddress";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "frmAddress";
         this.pnlTitle.ResumeLayout(false);
         this.pnlTitle.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picWizard)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel pnlTitle;
      private System.Windows.Forms.Label lblTitleTop;
      private System.Windows.Forms.PictureBox picWizard;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnAccept;
      private System.Windows.Forms.NumericUpDown numericUpDown1;
      private System.Windows.Forms.Label label1;
   }
}