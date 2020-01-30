namespace otc.forms
{
   partial class frmCalculator
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalculator));
         this.imlIcons = new System.Windows.Forms.ImageList(this.components);
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.lblRealMeasure = new System.Windows.Forms.Label();
         this.lblMeasureResult = new System.Windows.Forms.Label();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label7 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.txtSourceMeasure = new System.Windows.Forms.MaskedTextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.btnMeasureCalc = new System.Windows.Forms.Button();
         this.cboSourceScale = new otc.forms.controls.ImageComboBox();
         this.cboDestScale = new otc.forms.controls.ImageComboBox();
         this.groupBox3.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // imlIcons
         // 
         this.imlIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlIcons.ImageStream")));
         this.imlIcons.TransparentColor = System.Drawing.Color.Transparent;
         this.imlIcons.Images.SetKeyName(0, "IMG_MATH");
         // 
         // groupBox3
         // 
         this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox3.Controls.Add(this.lblRealMeasure);
         this.groupBox3.Controls.Add(this.lblMeasureResult);
         this.groupBox3.Location = new System.Drawing.Point(12, 187);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
         this.groupBox3.Size = new System.Drawing.Size(222, 78);
         this.groupBox3.TabIndex = 18;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Resultado";
         // 
         // lblRealMeasure
         // 
         this.lblRealMeasure.AutoSize = true;
         this.lblRealMeasure.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblRealMeasure.Location = new System.Drawing.Point(13, 49);
         this.lblRealMeasure.Name = "lblRealMeasure";
         this.lblRealMeasure.Size = new System.Drawing.Size(98, 16);
         this.lblRealMeasure.TabIndex = 11;
         this.lblRealMeasure.Text = "<result> mm.";
         // 
         // lblMeasureResult
         // 
         this.lblMeasureResult.AutoSize = true;
         this.lblMeasureResult.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblMeasureResult.Location = new System.Drawing.Point(13, 24);
         this.lblMeasureResult.Name = "lblMeasureResult";
         this.lblMeasureResult.Size = new System.Drawing.Size(98, 16);
         this.lblMeasureResult.TabIndex = 10;
         this.lblMeasureResult.Text = "<result> mm.";
         // 
         // groupBox2
         // 
         this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox2.Controls.Add(this.cboDestScale);
         this.groupBox2.Controls.Add(this.label1);
         this.groupBox2.Location = new System.Drawing.Point(12, 111);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
         this.groupBox2.Size = new System.Drawing.Size(222, 70);
         this.groupBox2.TabIndex = 17;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Convertir a";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 30);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(37, 13);
         this.label1.TabIndex = 5;
         this.label1.Text = "Escala";
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.cboSourceScale);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this.txtSourceMeasure);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
         this.groupBox1.Size = new System.Drawing.Size(222, 93);
         this.groupBox1.TabIndex = 16;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Medida original";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(13, 57);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(37, 13);
         this.label7.TabIndex = 3;
         this.label7.Text = "Escala";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(191, 30);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(23, 13);
         this.label5.TabIndex = 2;
         this.label5.Text = "mm";
         // 
         // txtSourceMeasure
         // 
         this.txtSourceMeasure.Location = new System.Drawing.Point(60, 27);
         this.txtSourceMeasure.Name = "txtSourceMeasure";
         this.txtSourceMeasure.Size = new System.Drawing.Size(125, 21);
         this.txtSourceMeasure.TabIndex = 1;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(13, 30);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(41, 13);
         this.label3.TabIndex = 0;
         this.label3.Text = "Medida";
         // 
         // btnMeasureCalc
         // 
         this.btnMeasureCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnMeasureCalc.Location = new System.Drawing.Point(159, 271);
         this.btnMeasureCalc.Name = "btnMeasureCalc";
         this.btnMeasureCalc.Size = new System.Drawing.Size(75, 23);
         this.btnMeasureCalc.TabIndex = 19;
         this.btnMeasureCalc.Text = "Calcular";
         this.btnMeasureCalc.UseVisualStyleBackColor = true;
         this.btnMeasureCalc.Click += new System.EventHandler(this.btnMeasureCalc_Click);
         // 
         // cboSourceScale
         // 
         this.cboSourceScale.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
         this.cboSourceScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cboSourceScale.FormattingEnabled = true;
         this.cboSourceScale.Location = new System.Drawing.Point(60, 54);
         this.cboSourceScale.Name = "cboSourceScale";
         this.cboSourceScale.Size = new System.Drawing.Size(125, 22);
         this.cboSourceScale.TabIndex = 6;
         // 
         // cboDestScale
         // 
         this.cboDestScale.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
         this.cboDestScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cboDestScale.FormattingEnabled = true;
         this.cboDestScale.Location = new System.Drawing.Point(60, 27);
         this.cboDestScale.Name = "cboDestScale";
         this.cboDestScale.Size = new System.Drawing.Size(125, 22);
         this.cboDestScale.TabIndex = 8;
         // 
         // frmCalculator
         // 
         this.AcceptButton = this.btnMeasureCalc;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(246, 306);
         this.Controls.Add(this.btnMeasureCalc);
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmCalculator";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = " Escalímetro";
         this.TopMost = true;
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ImageList imlIcons;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.Label lblRealMeasure;
      private System.Windows.Forms.Label lblMeasureResult;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.MaskedTextBox txtSourceMeasure;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Button btnMeasureCalc;
      private otc.forms.controls.ImageComboBox cboSourceScale;
      private otc.forms.controls.ImageComboBox cboDestScale;

   }
}