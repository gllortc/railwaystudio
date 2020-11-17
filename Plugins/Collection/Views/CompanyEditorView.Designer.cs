namespace Rwm.Studio.Plugins.Collection.Views
{
   partial class CompanyEditorView
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
         this.lblDescription = new DevExpress.XtraEditors.LabelControl();
         this.lblUrl = new DevExpress.XtraEditors.LabelControl();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdAccept = new DevExpress.XtraEditors.SimpleButton();
         this.txtUrl = new DevExpress.XtraEditors.HyperLinkEdit();
         this.imgLogo = new DevExpress.XtraEditors.PictureEdit();
         this.lblLogo = new DevExpress.XtraEditors.LabelControl();
         this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.imgLogo.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
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
         this.txtName.Location = new System.Drawing.Point(58, 12);
         this.txtName.Name = "txtName";
         this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.txtName.Properties.Appearance.Options.UseFont = true;
         this.txtName.Size = new System.Drawing.Size(478, 20);
         this.txtName.TabIndex = 1;
         // 
         // lblDescription
         // 
         this.lblDescription.Location = new System.Drawing.Point(12, 237);
         this.lblDescription.Name = "lblDescription";
         this.lblDescription.Size = new System.Drawing.Size(28, 13);
         this.lblDescription.TabIndex = 6;
         this.lblDescription.Text = "Notes";
         // 
         // lblUrl
         // 
         this.lblUrl.Location = new System.Drawing.Point(12, 41);
         this.lblUrl.Name = "lblUrl";
         this.lblUrl.Size = new System.Drawing.Size(19, 13);
         this.lblUrl.TabIndex = 2;
         this.lblUrl.Text = "URL";
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(461, 377);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 200;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
         // 
         // cmdAccept
         // 
         this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdAccept.Location = new System.Drawing.Point(380, 377);
         this.cmdAccept.Name = "cmdAccept";
         this.cmdAccept.Size = new System.Drawing.Size(75, 23);
         this.cmdAccept.TabIndex = 100;
         this.cmdAccept.Text = "Accept";
         this.cmdAccept.Click += new System.EventHandler(this.CmdAccept_Click);
         // 
         // txtUrl
         // 
         this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtUrl.Location = new System.Drawing.Point(58, 38);
         this.txtUrl.Name = "txtUrl";
         this.txtUrl.Properties.SingleClick = false;
         this.txtUrl.Properties.StartLinkOnClickingEmptySpace = false;
         this.txtUrl.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
         this.txtUrl.Size = new System.Drawing.Size(478, 20);
         this.txtUrl.TabIndex = 3;
         // 
         // imgLogo
         // 
         this.imgLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.imgLogo.Cursor = System.Windows.Forms.Cursors.Default;
         this.imgLogo.Location = new System.Drawing.Point(58, 64);
         this.imgLogo.Name = "imgLogo";
         this.imgLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
         this.imgLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
         this.imgLogo.Properties.ZoomAccelerationFactor = 1D;
         this.imgLogo.Size = new System.Drawing.Size(478, 164);
         this.imgLogo.TabIndex = 5;
         // 
         // lblLogo
         // 
         this.lblLogo.Location = new System.Drawing.Point(12, 66);
         this.lblLogo.Name = "lblLogo";
         this.lblLogo.Size = new System.Drawing.Size(23, 13);
         this.lblLogo.TabIndex = 4;
         this.lblLogo.Text = "Logo";
         // 
         // txtDescription
         // 
         this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtDescription.Location = new System.Drawing.Point(58, 234);
         this.txtDescription.Name = "txtDescription";
         this.txtDescription.Size = new System.Drawing.Size(478, 137);
         this.txtDescription.TabIndex = 7;
         // 
         // CompanyEditorView
         // 
         this.AcceptButton = this.cmdAccept;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(548, 412);
         this.Controls.Add(this.lblLogo);
         this.Controls.Add(this.imgLogo);
         this.Controls.Add(this.txtUrl);
         this.Controls.Add(this.cmdAccept);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.lblUrl);
         this.Controls.Add(this.lblDescription);
         this.Controls.Add(this.txtName);
         this.Controls.Add(this.lblName);
         this.Controls.Add(this.txtDescription);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CompanyEditorView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Company editor";
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.imgLogo.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.LabelControl lblName;
      private DevExpress.XtraEditors.TextEdit txtName;
      private DevExpress.XtraEditors.LabelControl lblDescription;
      private DevExpress.XtraEditors.LabelControl lblUrl;
      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.SimpleButton cmdAccept;
      private DevExpress.XtraEditors.HyperLinkEdit txtUrl;
      private DevExpress.XtraEditors.PictureEdit imgLogo;
      private DevExpress.XtraEditors.LabelControl lblLogo;
      private DevExpress.XtraEditors.MemoEdit txtDescription;
   }
}