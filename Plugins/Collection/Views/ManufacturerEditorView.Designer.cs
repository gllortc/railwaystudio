namespace Rwm.Studio.Plugins.Collection.Views
{
   partial class ManufacturerEditorView
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
         this.txtNotes = new DevExpress.XtraEditors.TextEdit();
         this.lblNotes = new DevExpress.XtraEditors.LabelControl();
         this.txtUrl = new DevExpress.XtraEditors.TextEdit();
         this.lblUrl = new DevExpress.XtraEditors.LabelControl();
         this.cmdAccept = new DevExpress.XtraEditors.SimpleButton();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.txtAddress = new DevExpress.XtraEditors.TextEdit();
         this.lblAddress = new DevExpress.XtraEditors.LabelControl();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // txtNotes
         // 
         this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtNotes.Location = new System.Drawing.Point(69, 90);
         this.txtNotes.Name = "txtNotes";
         this.txtNotes.Size = new System.Drawing.Size(342, 20);
         this.txtNotes.TabIndex = 41;
         // 
         // lblNotes
         // 
         this.lblNotes.Location = new System.Drawing.Point(12, 93);
         this.lblNotes.Name = "lblNotes";
         this.lblNotes.Size = new System.Drawing.Size(28, 13);
         this.lblNotes.TabIndex = 40;
         this.lblNotes.Text = "Notes";
         // 
         // txtUrl
         // 
         this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtUrl.Location = new System.Drawing.Point(69, 64);
         this.txtUrl.Name = "txtUrl";
         this.txtUrl.Size = new System.Drawing.Size(342, 20);
         this.txtUrl.TabIndex = 39;
         // 
         // lblUrl
         // 
         this.lblUrl.Location = new System.Drawing.Point(12, 67);
         this.lblUrl.Name = "lblUrl";
         this.lblUrl.Size = new System.Drawing.Size(19, 13);
         this.lblUrl.TabIndex = 38;
         this.lblUrl.Text = "URL";
         // 
         // cmdAccept
         // 
         this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdAccept.Location = new System.Drawing.Point(255, 126);
         this.cmdAccept.Name = "cmdAccept";
         this.cmdAccept.Size = new System.Drawing.Size(75, 23);
         this.cmdAccept.TabIndex = 37;
         this.cmdAccept.Text = "Accept";
         this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(336, 126);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 36;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // txtAddress
         // 
         this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtAddress.Location = new System.Drawing.Point(69, 38);
         this.txtAddress.Name = "txtAddress";
         this.txtAddress.Size = new System.Drawing.Size(342, 20);
         this.txtAddress.TabIndex = 31;
         // 
         // lblAddress
         // 
         this.lblAddress.Location = new System.Drawing.Point(12, 41);
         this.lblAddress.Name = "lblAddress";
         this.lblAddress.Size = new System.Drawing.Size(39, 13);
         this.lblAddress.TabIndex = 30;
         this.lblAddress.Text = "Address";
         // 
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Location = new System.Drawing.Point(69, 12);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(342, 20);
         this.txtName.TabIndex = 29;
         // 
         // lblName
         // 
         this.lblName.Location = new System.Drawing.Point(12, 15);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(27, 13);
         this.lblName.TabIndex = 28;
         this.lblName.Text = "Name";
         // 
         // FrmManufacturerEditor
         // 
         this.AcceptButton = this.cmdAccept;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(423, 161);
         this.Controls.Add(this.txtNotes);
         this.Controls.Add(this.lblNotes);
         this.Controls.Add(this.txtUrl);
         this.Controls.Add(this.lblUrl);
         this.Controls.Add(this.cmdAccept);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.txtAddress);
         this.Controls.Add(this.lblAddress);
         this.Controls.Add(this.txtName);
         this.Controls.Add(this.lblName);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmManufacturerEditor";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Manufacturer editor";
         ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.TextEdit txtNotes;
      private DevExpress.XtraEditors.LabelControl lblNotes;
      private DevExpress.XtraEditors.TextEdit txtUrl;
      private DevExpress.XtraEditors.LabelControl lblUrl;
      private DevExpress.XtraEditors.SimpleButton cmdAccept;
      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.TextEdit txtAddress;
      private DevExpress.XtraEditors.LabelControl lblAddress;
      private DevExpress.XtraEditors.TextEdit txtName;
      private DevExpress.XtraEditors.LabelControl lblName;
   }
}