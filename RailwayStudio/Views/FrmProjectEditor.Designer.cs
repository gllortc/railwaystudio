namespace Rwm.Studio.Views
{
   partial class FrmProjectEditor
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
         this.tabPlugin = new DevExpress.XtraTab.XtraTabControl();
         this.tabPluginGeneral = new DevExpress.XtraTab.XtraTabPage();
         this.lblDescription = new DevExpress.XtraEditors.LabelControl();
         this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
         this.lblVersion = new DevExpress.XtraEditors.LabelControl();
         this.txtVersion = new DevExpress.XtraEditors.TextEdit();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.cmdAccept = new DevExpress.XtraEditors.SimpleButton();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         ((System.ComponentModel.ISupportInitialize)(this.tabPlugin)).BeginInit();
         this.tabPlugin.SuspendLayout();
         this.tabPluginGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtVersion.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // tabPlugin
         // 
         this.tabPlugin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabPlugin.Location = new System.Drawing.Point(12, 12);
         this.tabPlugin.Name = "tabPlugin";
         this.tabPlugin.SelectedTabPage = this.tabPluginGeneral;
         this.tabPlugin.Size = new System.Drawing.Size(403, 297);
         this.tabPlugin.TabIndex = 5;
         this.tabPlugin.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPluginGeneral});
         // 
         // tabPluginGeneral
         // 
         this.tabPluginGeneral.Controls.Add(this.lblDescription);
         this.tabPluginGeneral.Controls.Add(this.txtDescription);
         this.tabPluginGeneral.Controls.Add(this.lblVersion);
         this.tabPluginGeneral.Controls.Add(this.txtVersion);
         this.tabPluginGeneral.Controls.Add(this.lblName);
         this.tabPluginGeneral.Controls.Add(this.txtName);
         this.tabPluginGeneral.Name = "tabPluginGeneral";
         this.tabPluginGeneral.Padding = new System.Windows.Forms.Padding(15);
         this.tabPluginGeneral.Size = new System.Drawing.Size(397, 269);
         this.tabPluginGeneral.Text = "General";
         // 
         // lblDescription
         // 
         this.lblDescription.Location = new System.Drawing.Point(18, 82);
         this.lblDescription.Name = "lblDescription";
         this.lblDescription.Size = new System.Drawing.Size(53, 13);
         this.lblDescription.TabIndex = 4;
         this.lblDescription.Text = "Description";
         // 
         // txtDescription
         // 
         this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtDescription.Location = new System.Drawing.Point(77, 80);
         this.txtDescription.Name = "txtDescription";
         this.txtDescription.Size = new System.Drawing.Size(302, 171);
         this.txtDescription.TabIndex = 5;
         // 
         // lblVersion
         // 
         this.lblVersion.Location = new System.Drawing.Point(18, 57);
         this.lblVersion.Name = "lblVersion";
         this.lblVersion.Size = new System.Drawing.Size(35, 13);
         this.lblVersion.TabIndex = 2;
         this.lblVersion.Text = "Version";
         // 
         // txtVersion
         // 
         this.txtVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtVersion.Location = new System.Drawing.Point(77, 54);
         this.txtVersion.Name = "txtVersion";
         this.txtVersion.Size = new System.Drawing.Size(302, 20);
         this.txtVersion.TabIndex = 3;
         // 
         // lblName
         // 
         this.lblName.Location = new System.Drawing.Point(18, 31);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(27, 13);
         this.lblName.TabIndex = 0;
         this.lblName.Text = "Name";
         // 
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Location = new System.Drawing.Point(77, 28);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(302, 20);
         this.txtName.TabIndex = 1;
         // 
         // cmdAccept
         // 
         this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdAccept.Location = new System.Drawing.Point(259, 315);
         this.cmdAccept.Name = "cmdAccept";
         this.cmdAccept.Size = new System.Drawing.Size(75, 23);
         this.cmdAccept.TabIndex = 100;
         this.cmdAccept.Text = "Accept";
         this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(340, 315);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 200;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // FrmProjectEditor
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(427, 350);
         this.Controls.Add(this.tabPlugin);
         this.Controls.Add(this.cmdAccept);
         this.Controls.Add(this.cmdCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmProjectEditor";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Project editor";
         this.Activated += new System.EventHandler(this.FrmProjectEditor_Activated);
         ((System.ComponentModel.ISupportInitialize)(this.tabPlugin)).EndInit();
         this.tabPlugin.ResumeLayout(false);
         this.tabPluginGeneral.ResumeLayout(false);
         this.tabPluginGeneral.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtVersion.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraTab.XtraTabControl tabPlugin;
      private DevExpress.XtraTab.XtraTabPage tabPluginGeneral;
      private DevExpress.XtraEditors.LabelControl lblName;
      private DevExpress.XtraEditors.TextEdit txtName;
      private DevExpress.XtraEditors.SimpleButton cmdAccept;
      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.LabelControl lblVersion;
      private DevExpress.XtraEditors.TextEdit txtVersion;
      private DevExpress.XtraEditors.LabelControl lblDescription;
      private DevExpress.XtraEditors.MemoEdit txtDescription;
   }
}