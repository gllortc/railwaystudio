namespace Rwm.Studio.Plugins.Collection.Views
{
   partial class CategoryEditorView
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
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdAccept = new DevExpress.XtraEditors.SimpleButton();
         this.chkMaintenance = new DevExpress.XtraEditors.CheckEdit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.chkMaintenance.Properties)).BeginInit();
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
         this.txtName.Location = new System.Drawing.Point(56, 12);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(198, 20);
         this.txtName.TabIndex = 1;
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(179, 68);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 10;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // cmdAccept
         // 
         this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdAccept.Location = new System.Drawing.Point(98, 68);
         this.cmdAccept.Name = "cmdAccept";
         this.cmdAccept.Size = new System.Drawing.Size(75, 23);
         this.cmdAccept.TabIndex = 11;
         this.cmdAccept.Text = "Accept";
         this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
         // 
         // chkMaintenance
         // 
         this.chkMaintenance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.chkMaintenance.Location = new System.Drawing.Point(56, 38);
         this.chkMaintenance.Name = "chkMaintenance";
         this.chkMaintenance.Properties.Caption = "Models have maintenance";
         this.chkMaintenance.Size = new System.Drawing.Size(198, 19);
         this.chkMaintenance.TabIndex = 12;
         // 
         // FrmCategoryEditor
         // 
         this.AcceptButton = this.cmdAccept;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(266, 103);
         this.Controls.Add(this.chkMaintenance);
         this.Controls.Add(this.cmdAccept);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.txtName);
         this.Controls.Add(this.lblName);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmCategoryEditor";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Category editor";
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.chkMaintenance.Properties)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.LabelControl lblName;
      private DevExpress.XtraEditors.TextEdit txtName;
      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.SimpleButton cmdAccept;
      private DevExpress.XtraEditors.CheckEdit chkMaintenance;
   }
}