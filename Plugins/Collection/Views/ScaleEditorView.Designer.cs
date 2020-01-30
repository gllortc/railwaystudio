namespace Rwm.Studio.Plugins.Collection.Views
{
   partial class ScaleEditorView
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
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.txtRatio = new DevExpress.XtraEditors.TextEdit();
         this.lblRatio = new DevExpress.XtraEditors.LabelControl();
         this.txtTrackWidth = new DevExpress.XtraEditors.TextEdit();
         this.lblTrackWidth = new DevExpress.XtraEditors.LabelControl();
         this.txtRealTrackWidth = new DevExpress.XtraEditors.TextEdit();
         this.lblRealTrackWidth = new DevExpress.XtraEditors.LabelControl();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdAccept = new DevExpress.XtraEditors.SimpleButton();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtRatio.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtTrackWidth.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtRealTrackWidth.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // lblName
         // 
         this.lblName.Location = new System.Drawing.Point(12, 15);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(27, 13);
         this.lblName.TabIndex = 0;
         this.lblName.Text = "Name";
         // 
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Location = new System.Drawing.Point(98, 12);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(156, 20);
         this.txtName.TabIndex = 1;
         // 
         // txtRatio
         // 
         this.txtRatio.Location = new System.Drawing.Point(98, 38);
         this.txtRatio.Name = "txtRatio";
         this.txtRatio.Size = new System.Drawing.Size(156, 20);
         this.txtRatio.TabIndex = 3;
         // 
         // lblRatio
         // 
         this.lblRatio.Location = new System.Drawing.Point(12, 41);
         this.lblRatio.Name = "lblRatio";
         this.lblRatio.Size = new System.Drawing.Size(25, 13);
         this.lblRatio.TabIndex = 2;
         this.lblRatio.Text = "Ratio";
         // 
         // txtTrackWidth
         // 
         this.txtTrackWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtTrackWidth.Location = new System.Drawing.Point(98, 64);
         this.txtTrackWidth.Name = "txtTrackWidth";
         this.txtTrackWidth.Size = new System.Drawing.Size(134, 20);
         this.txtTrackWidth.TabIndex = 5;
         // 
         // lblTrackWidth
         // 
         this.lblTrackWidth.Location = new System.Drawing.Point(12, 67);
         this.lblTrackWidth.Name = "lblTrackWidth";
         this.lblTrackWidth.Size = new System.Drawing.Size(81, 13);
         this.lblTrackWidth.TabIndex = 4;
         this.lblTrackWidth.Text = "Scale track witdh";
         // 
         // txtRealTrackWidth
         // 
         this.txtRealTrackWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtRealTrackWidth.Location = new System.Drawing.Point(98, 90);
         this.txtRealTrackWidth.Name = "txtRealTrackWidth";
         this.txtRealTrackWidth.Size = new System.Drawing.Size(134, 20);
         this.txtRealTrackWidth.TabIndex = 7;
         // 
         // lblRealTrackWidth
         // 
         this.lblRealTrackWidth.Location = new System.Drawing.Point(12, 93);
         this.lblRealTrackWidth.Name = "lblRealTrackWidth";
         this.lblRealTrackWidth.Size = new System.Drawing.Size(77, 13);
         this.lblRealTrackWidth.TabIndex = 6;
         this.lblRealTrackWidth.Text = "Real track width";
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(179, 132);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 10;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // cmdAccept
         // 
         this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdAccept.Location = new System.Drawing.Point(98, 132);
         this.cmdAccept.Name = "cmdAccept";
         this.cmdAccept.Size = new System.Drawing.Size(75, 23);
         this.cmdAccept.TabIndex = 11;
         this.cmdAccept.Text = "Accept";
         this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
         // 
         // labelControl1
         // 
         this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.labelControl1.Location = new System.Drawing.Point(238, 67);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(16, 13);
         this.labelControl1.TabIndex = 12;
         this.labelControl1.Text = "mm";
         // 
         // labelControl7
         // 
         this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.labelControl7.Location = new System.Drawing.Point(238, 93);
         this.labelControl7.Name = "labelControl7";
         this.labelControl7.Size = new System.Drawing.Size(16, 13);
         this.labelControl7.TabIndex = 13;
         this.labelControl7.Text = "mm";
         // 
         // FrmScaleEditor
         // 
         this.AcceptButton = this.cmdAccept;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(266, 167);
         this.Controls.Add(this.labelControl7);
         this.Controls.Add(this.labelControl1);
         this.Controls.Add(this.cmdAccept);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.txtRealTrackWidth);
         this.Controls.Add(this.lblRealTrackWidth);
         this.Controls.Add(this.txtTrackWidth);
         this.Controls.Add(this.lblTrackWidth);
         this.Controls.Add(this.txtRatio);
         this.Controls.Add(this.lblRatio);
         this.Controls.Add(this.txtName);
         this.Controls.Add(this.lblName);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmScaleEditor";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Scale editor";
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtRatio.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtTrackWidth.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtRealTrackWidth.Properties)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.LabelControl lblName;
      private DevExpress.XtraEditors.TextEdit txtName;
      private DevExpress.XtraEditors.TextEdit txtRatio;
      private DevExpress.XtraEditors.LabelControl lblRatio;
      private DevExpress.XtraEditors.TextEdit txtTrackWidth;
      private DevExpress.XtraEditors.LabelControl lblTrackWidth;
      private DevExpress.XtraEditors.TextEdit txtRealTrackWidth;
      private DevExpress.XtraEditors.LabelControl lblRealTrackWidth;
      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.SimpleButton cmdAccept;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.LabelControl labelControl7;
   }
}