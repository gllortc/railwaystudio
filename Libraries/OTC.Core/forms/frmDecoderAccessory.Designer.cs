namespace otc.forms
{
   partial class frmDecoderAccessory
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDecoderAccessory));
         this.pnlTitle = new System.Windows.Forms.Panel();
         this.lblTitleTop = new System.Windows.Forms.Label();
         this.picWizard = new System.Windows.Forms.PictureBox();
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnAccept = new System.Windows.Forms.Button();
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabDecoGeneral = new System.Windows.Forms.TabPage();
         this.label1 = new System.Windows.Forms.Label();
         this.txtName = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.cboManufacturer = new System.Windows.Forms.ComboBox();
         this.txtModel = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.txtOutputs = new System.Windows.Forms.NumericUpDown();
         this.txtStartAddress = new System.Windows.Forms.NumericUpDown();
         this.label5 = new System.Windows.Forms.Label();
         this.tabDecoNotes = new System.Windows.Forms.TabPage();
         this.txtNotes = new System.Windows.Forms.TextBox();
         this.cboType = new System.Windows.Forms.ComboBox();
         this.label6 = new System.Windows.Forms.Label();
         this.pnlTitle.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picWizard)).BeginInit();
         this.tabControl1.SuspendLayout();
         this.tabDecoGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtOutputs)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtStartAddress)).BeginInit();
         this.tabDecoNotes.SuspendLayout();
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
         this.pnlTitle.Size = new System.Drawing.Size(386, 68);
         this.pnlTitle.TabIndex = 14;
         // 
         // lblTitleTop
         // 
         this.lblTitleTop.AutoSize = true;
         this.lblTitleTop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTitleTop.Location = new System.Drawing.Point(13, 13);
         this.lblTitleTop.Name = "lblTitleTop";
         this.lblTitleTop.Size = new System.Drawing.Size(262, 13);
         this.lblTitleTop.TabIndex = 1;
         this.lblTitleTop.Text = "Propiedades del descodificador de accesorios";
         // 
         // picWizard
         // 
         this.picWizard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.picWizard.Image = global::otc.Properties.Resources.WIZARD_DECODER;
         this.picWizard.Location = new System.Drawing.Point(311, 0);
         this.picWizard.Name = "picWizard";
         this.picWizard.Size = new System.Drawing.Size(75, 66);
         this.picWizard.TabIndex = 0;
         this.picWizard.TabStop = false;
         // 
         // btnCancel
         // 
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(299, 289);
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
         this.btnAccept.Location = new System.Drawing.Point(218, 289);
         this.btnAccept.Name = "btnAccept";
         this.btnAccept.Size = new System.Drawing.Size(75, 23);
         this.btnAccept.TabIndex = 15;
         this.btnAccept.Text = "Aceptar";
         this.btnAccept.UseVisualStyleBackColor = true;
         this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
         // 
         // tabControl1
         // 
         this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.tabControl1.Controls.Add(this.tabDecoGeneral);
         this.tabControl1.Controls.Add(this.tabDecoNotes);
         this.tabControl1.Location = new System.Drawing.Point(12, 74);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(362, 209);
         this.tabControl1.TabIndex = 17;
         // 
         // tabDecoGeneral
         // 
         this.tabDecoGeneral.Controls.Add(this.cboType);
         this.tabDecoGeneral.Controls.Add(this.label6);
         this.tabDecoGeneral.Controls.Add(this.txtStartAddress);
         this.tabDecoGeneral.Controls.Add(this.label5);
         this.tabDecoGeneral.Controls.Add(this.txtOutputs);
         this.tabDecoGeneral.Controls.Add(this.label4);
         this.tabDecoGeneral.Controls.Add(this.txtModel);
         this.tabDecoGeneral.Controls.Add(this.label3);
         this.tabDecoGeneral.Controls.Add(this.cboManufacturer);
         this.tabDecoGeneral.Controls.Add(this.label2);
         this.tabDecoGeneral.Controls.Add(this.txtName);
         this.tabDecoGeneral.Controls.Add(this.label1);
         this.tabDecoGeneral.Location = new System.Drawing.Point(4, 22);
         this.tabDecoGeneral.Name = "tabDecoGeneral";
         this.tabDecoGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.tabDecoGeneral.Size = new System.Drawing.Size(354, 183);
         this.tabDecoGeneral.TabIndex = 0;
         this.tabDecoGeneral.Text = "General";
         this.tabDecoGeneral.UseVisualStyleBackColor = true;
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
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Location = new System.Drawing.Point(113, 13);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(228, 21);
         this.txtName.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(13, 70);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(58, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Fabricante";
         // 
         // cboManufacturer
         // 
         this.cboManufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.cboManufacturer.FormattingEnabled = true;
         this.cboManufacturer.Location = new System.Drawing.Point(113, 67);
         this.cboManufacturer.Name = "cboManufacturer";
         this.cboManufacturer.Size = new System.Drawing.Size(228, 21);
         this.cboManufacturer.TabIndex = 3;
         // 
         // txtModel
         // 
         this.txtModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.txtModel.Location = new System.Drawing.Point(113, 94);
         this.txtModel.Name = "txtModel";
         this.txtModel.Size = new System.Drawing.Size(228, 21);
         this.txtModel.TabIndex = 5;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(13, 97);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(41, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Modelo";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(13, 123);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(94, 13);
         this.label4.TabIndex = 6;
         this.label4.Text = "Número de salidas";
         // 
         // txtOutputs
         // 
         this.txtOutputs.Location = new System.Drawing.Point(113, 121);
         this.txtOutputs.Name = "txtOutputs";
         this.txtOutputs.Size = new System.Drawing.Size(55, 21);
         this.txtOutputs.TabIndex = 7;
         this.txtOutputs.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
         // 
         // txtStartAddress
         // 
         this.txtStartAddress.Location = new System.Drawing.Point(113, 148);
         this.txtStartAddress.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
         this.txtStartAddress.Name = "txtStartAddress";
         this.txtStartAddress.Size = new System.Drawing.Size(55, 21);
         this.txtStartAddress.TabIndex = 9;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(13, 150);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(78, 13);
         this.label5.TabIndex = 8;
         this.label5.Text = "Dirección inicial";
         // 
         // tabDecoNotes
         // 
         this.tabDecoNotes.Controls.Add(this.txtNotes);
         this.tabDecoNotes.Location = new System.Drawing.Point(4, 22);
         this.tabDecoNotes.Name = "tabDecoNotes";
         this.tabDecoNotes.Padding = new System.Windows.Forms.Padding(3);
         this.tabDecoNotes.Size = new System.Drawing.Size(354, 183);
         this.tabDecoNotes.TabIndex = 1;
         this.tabDecoNotes.Text = "Notas";
         this.tabDecoNotes.UseVisualStyleBackColor = true;
         // 
         // txtNotes
         // 
         this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
         this.txtNotes.Location = new System.Drawing.Point(3, 3);
         this.txtNotes.Multiline = true;
         this.txtNotes.Name = "txtNotes";
         this.txtNotes.Size = new System.Drawing.Size(348, 177);
         this.txtNotes.TabIndex = 0;
         // 
         // cboType
         // 
         this.cboType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cboType.FormattingEnabled = true;
         this.cboType.Location = new System.Drawing.Point(113, 40);
         this.cboType.Name = "cboType";
         this.cboType.Size = new System.Drawing.Size(228, 21);
         this.cboType.TabIndex = 11;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(13, 43);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(27, 13);
         this.label6.TabIndex = 10;
         this.label6.Text = "Tipo";
         // 
         // frmDecoderAccessory
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(386, 324);
         this.Controls.Add(this.tabControl1);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnAccept);
         this.Controls.Add(this.pnlTitle);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmDecoderAccessory";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "frmDecoderAccessory";
         this.Load += new System.EventHandler(this.frmDecoderAccessory_Load);
         this.pnlTitle.ResumeLayout(false);
         this.pnlTitle.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picWizard)).EndInit();
         this.tabControl1.ResumeLayout(false);
         this.tabDecoGeneral.ResumeLayout(false);
         this.tabDecoGeneral.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtOutputs)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtStartAddress)).EndInit();
         this.tabDecoNotes.ResumeLayout(false);
         this.tabDecoNotes.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel pnlTitle;
      private System.Windows.Forms.Label lblTitleTop;
      private System.Windows.Forms.PictureBox picWizard;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnAccept;
      private System.Windows.Forms.TabControl tabControl1;
      private System.Windows.Forms.TabPage tabDecoGeneral;
      private System.Windows.Forms.TextBox txtName;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtModel;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox cboManufacturer;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.NumericUpDown txtOutputs;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.NumericUpDown txtStartAddress;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TabPage tabDecoNotes;
      private System.Windows.Forms.TextBox txtNotes;
      private System.Windows.Forms.ComboBox cboType;
      private System.Windows.Forms.Label label6;
   }
}