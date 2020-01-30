namespace Rwm.Studio.Plugins.Collection.Views
{
   partial class DecoderEditorView
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
         this.cmdAccept = new DevExpress.XtraEditors.SimpleButton();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.lblManual = new DevExpress.XtraEditors.LabelControl();
         this.txtUrl = new DevExpress.XtraEditors.TextEdit();
         this.lblURL = new DevExpress.XtraEditors.LabelControl();
         this.txtDescription = new DevExpress.XtraEditors.TextEdit();
         this.lblDescription = new DevExpress.XtraEditors.LabelControl();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.txtManual = new DevExpress.XtraEditors.ButtonEdit();
         ((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtManual.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // cmdAccept
         // 
         this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdAccept.Location = new System.Drawing.Point(183, 127);
         this.cmdAccept.Name = "cmdAccept";
         this.cmdAccept.Size = new System.Drawing.Size(75, 23);
         this.cmdAccept.TabIndex = 23;
         this.cmdAccept.Text = "Accept";
         this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(264, 127);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 22;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // lblManual
         // 
         this.lblManual.Location = new System.Drawing.Point(12, 93);
         this.lblManual.Name = "lblManual";
         this.lblManual.Size = new System.Drawing.Size(34, 13);
         this.lblManual.TabIndex = 20;
         this.lblManual.Text = "Manual";
         // 
         // txtUrl
         // 
         this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtUrl.Location = new System.Drawing.Point(81, 64);
         this.txtUrl.Name = "txtUrl";
         this.txtUrl.Size = new System.Drawing.Size(258, 20);
         this.txtUrl.TabIndex = 19;
         // 
         // lblURL
         // 
         this.lblURL.Location = new System.Drawing.Point(12, 67);
         this.lblURL.Name = "lblURL";
         this.lblURL.Size = new System.Drawing.Size(19, 13);
         this.lblURL.TabIndex = 18;
         this.lblURL.Text = "URL";
         // 
         // txtDescription
         // 
         this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtDescription.Location = new System.Drawing.Point(81, 38);
         this.txtDescription.Name = "txtDescription";
         this.txtDescription.Size = new System.Drawing.Size(258, 20);
         this.txtDescription.TabIndex = 17;
         // 
         // lblDescription
         // 
         this.lblDescription.Location = new System.Drawing.Point(12, 41);
         this.lblDescription.Name = "lblDescription";
         this.lblDescription.Size = new System.Drawing.Size(53, 13);
         this.lblDescription.TabIndex = 16;
         this.lblDescription.Text = "Description";
         // 
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Location = new System.Drawing.Point(81, 12);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(258, 20);
         this.txtName.TabIndex = 15;
         // 
         // lblName
         // 
         this.lblName.Location = new System.Drawing.Point(12, 15);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(27, 13);
         this.lblName.TabIndex = 14;
         this.lblName.Text = "Name";
         // 
         // txtManual
         // 
         this.txtManual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtManual.Location = new System.Drawing.Point(81, 90);
         this.txtManual.Name = "txtManual";
         this.txtManual.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
         this.txtManual.Size = new System.Drawing.Size(258, 20);
         this.txtManual.TabIndex = 24;
         // 
         // FrmDecoderEditor
         // 
         this.AcceptButton = this.cmdAccept;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(351, 162);
         this.Controls.Add(this.txtManual);
         this.Controls.Add(this.cmdAccept);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.lblManual);
         this.Controls.Add(this.txtUrl);
         this.Controls.Add(this.lblURL);
         this.Controls.Add(this.txtDescription);
         this.Controls.Add(this.lblDescription);
         this.Controls.Add(this.txtName);
         this.Controls.Add(this.lblName);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmDecoderEditor";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Decoder editor";
         ((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtManual.Properties)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.SimpleButton cmdAccept;
      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.LabelControl lblManual;
      private DevExpress.XtraEditors.TextEdit txtUrl;
      private DevExpress.XtraEditors.LabelControl lblURL;
      private DevExpress.XtraEditors.TextEdit txtDescription;
      private DevExpress.XtraEditors.LabelControl lblDescription;
      private DevExpress.XtraEditors.TextEdit txtName;
      private DevExpress.XtraEditors.LabelControl lblName;
      private DevExpress.XtraEditors.ButtonEdit txtManual;
   }
}