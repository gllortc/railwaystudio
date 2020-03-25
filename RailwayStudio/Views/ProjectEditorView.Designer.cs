namespace Rwm.Studio.Views
{
   partial class ProjectEditorView
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
         this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
         this.lblFilenameLabel = new DevExpress.XtraEditors.LabelControl();
         this.lblFilename = new DevExpress.XtraEditors.LabelControl();
         this.lblPath = new DevExpress.XtraEditors.LabelControl();
         this.lblPathLabel = new DevExpress.XtraEditors.LabelControl();
         this.lblSize = new DevExpress.XtraEditors.LabelControl();
         this.lblSizeLabel = new DevExpress.XtraEditors.LabelControl();
         this.separatorControl2 = new DevExpress.XtraEditors.SeparatorControl();
         this.lblLastAccess = new DevExpress.XtraEditors.LabelControl();
         this.lblLastAccessLabel = new DevExpress.XtraEditors.LabelControl();
         this.lblCreated = new DevExpress.XtraEditors.LabelControl();
         this.lblCreatedLabel = new DevExpress.XtraEditors.LabelControl();
         ((System.ComponentModel.ISupportInitialize)(this.tabPlugin)).BeginInit();
         this.tabPlugin.SuspendLayout();
         this.tabPluginGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtVersion.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).BeginInit();
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
         this.tabPlugin.Size = new System.Drawing.Size(403, 405);
         this.tabPlugin.TabIndex = 5;
         this.tabPlugin.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPluginGeneral});
         // 
         // tabPluginGeneral
         // 
         this.tabPluginGeneral.Controls.Add(this.lblLastAccess);
         this.tabPluginGeneral.Controls.Add(this.lblLastAccessLabel);
         this.tabPluginGeneral.Controls.Add(this.lblCreated);
         this.tabPluginGeneral.Controls.Add(this.lblCreatedLabel);
         this.tabPluginGeneral.Controls.Add(this.separatorControl2);
         this.tabPluginGeneral.Controls.Add(this.lblSize);
         this.tabPluginGeneral.Controls.Add(this.lblSizeLabel);
         this.tabPluginGeneral.Controls.Add(this.lblPath);
         this.tabPluginGeneral.Controls.Add(this.lblPathLabel);
         this.tabPluginGeneral.Controls.Add(this.lblFilename);
         this.tabPluginGeneral.Controls.Add(this.lblFilenameLabel);
         this.tabPluginGeneral.Controls.Add(this.separatorControl1);
         this.tabPluginGeneral.Controls.Add(this.lblDescription);
         this.tabPluginGeneral.Controls.Add(this.txtDescription);
         this.tabPluginGeneral.Controls.Add(this.lblVersion);
         this.tabPluginGeneral.Controls.Add(this.txtVersion);
         this.tabPluginGeneral.Controls.Add(this.lblName);
         this.tabPluginGeneral.Controls.Add(this.txtName);
         this.tabPluginGeneral.Image = global::Rwm.Studio.Properties.Resources.ICO_PROJECT_16;
         this.tabPluginGeneral.Name = "tabPluginGeneral";
         this.tabPluginGeneral.Padding = new System.Windows.Forms.Padding(15);
         this.tabPluginGeneral.Size = new System.Drawing.Size(397, 374);
         this.tabPluginGeneral.Text = "General";
         // 
         // lblDescription
         // 
         this.lblDescription.Location = new System.Drawing.Point(18, 72);
         this.lblDescription.Name = "lblDescription";
         this.lblDescription.Size = new System.Drawing.Size(53, 13);
         this.lblDescription.TabIndex = 4;
         this.lblDescription.Text = "Description";
         // 
         // txtDescription
         // 
         this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtDescription.Location = new System.Drawing.Point(86, 70);
         this.txtDescription.Name = "txtDescription";
         this.txtDescription.Size = new System.Drawing.Size(293, 136);
         this.txtDescription.TabIndex = 5;
         // 
         // lblVersion
         // 
         this.lblVersion.Location = new System.Drawing.Point(18, 47);
         this.lblVersion.Name = "lblVersion";
         this.lblVersion.Size = new System.Drawing.Size(35, 13);
         this.lblVersion.TabIndex = 2;
         this.lblVersion.Text = "Version";
         // 
         // txtVersion
         // 
         this.txtVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtVersion.Location = new System.Drawing.Point(86, 44);
         this.txtVersion.Name = "txtVersion";
         this.txtVersion.Size = new System.Drawing.Size(293, 20);
         this.txtVersion.TabIndex = 3;
         // 
         // lblName
         // 
         this.lblName.Location = new System.Drawing.Point(18, 21);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(27, 13);
         this.lblName.TabIndex = 0;
         this.lblName.Text = "Name";
         // 
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Location = new System.Drawing.Point(86, 18);
         this.txtName.Name = "txtName";
         this.txtName.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
         this.txtName.Properties.Appearance.Options.UseFont = true;
         this.txtName.Size = new System.Drawing.Size(293, 20);
         this.txtName.TabIndex = 1;
         // 
         // cmdAccept
         // 
         this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdAccept.Location = new System.Drawing.Point(259, 423);
         this.cmdAccept.Name = "cmdAccept";
         this.cmdAccept.Size = new System.Drawing.Size(75, 23);
         this.cmdAccept.TabIndex = 100;
         this.cmdAccept.Text = "Accept";
         this.cmdAccept.Click += new System.EventHandler(this.CmdAccept_Click);
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(340, 423);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 200;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
         // 
         // separatorControl1
         // 
         this.separatorControl1.Location = new System.Drawing.Point(18, 212);
         this.separatorControl1.Name = "separatorControl1";
         this.separatorControl1.Size = new System.Drawing.Size(361, 23);
         this.separatorControl1.TabIndex = 6;
         // 
         // lblFilenameLabel
         // 
         this.lblFilenameLabel.Location = new System.Drawing.Point(18, 241);
         this.lblFilenameLabel.Name = "lblFilenameLabel";
         this.lblFilenameLabel.Size = new System.Drawing.Size(16, 13);
         this.lblFilenameLabel.TabIndex = 7;
         this.lblFilenameLabel.Text = "File";
         // 
         // lblFilename
         // 
         this.lblFilename.Location = new System.Drawing.Point(86, 241);
         this.lblFilename.Name = "lblFilename";
         this.lblFilename.Size = new System.Drawing.Size(49, 13);
         this.lblFilename.TabIndex = 8;
         this.lblFilename.Text = "layout.orc";
         // 
         // lblPath
         // 
         this.lblPath.Location = new System.Drawing.Point(86, 260);
         this.lblPath.Name = "lblPath";
         this.lblPath.Size = new System.Drawing.Size(53, 13);
         this.lblPath.TabIndex = 10;
         this.lblPath.Text = "c:\\layouts\\";
         // 
         // lblPathLabel
         // 
         this.lblPathLabel.Location = new System.Drawing.Point(18, 260);
         this.lblPathLabel.Name = "lblPathLabel";
         this.lblPathLabel.Size = new System.Drawing.Size(40, 13);
         this.lblPathLabel.TabIndex = 9;
         this.lblPathLabel.Text = "Location";
         // 
         // lblSize
         // 
         this.lblSize.Location = new System.Drawing.Point(86, 279);
         this.lblSize.Name = "lblSize";
         this.lblSize.Size = new System.Drawing.Size(33, 13);
         this.lblSize.TabIndex = 12;
         this.lblSize.Text = "2.3 MB";
         // 
         // lblSizeLabel
         // 
         this.lblSizeLabel.Location = new System.Drawing.Point(18, 279);
         this.lblSizeLabel.Name = "lblSizeLabel";
         this.lblSizeLabel.Size = new System.Drawing.Size(19, 13);
         this.lblSizeLabel.TabIndex = 11;
         this.lblSizeLabel.Text = "Size";
         // 
         // separatorControl2
         // 
         this.separatorControl2.Location = new System.Drawing.Point(18, 298);
         this.separatorControl2.Name = "separatorControl2";
         this.separatorControl2.Size = new System.Drawing.Size(361, 23);
         this.separatorControl2.TabIndex = 13;
         // 
         // lblLastAccess
         // 
         this.lblLastAccess.Location = new System.Drawing.Point(86, 346);
         this.lblLastAccess.Name = "lblLastAccess";
         this.lblLastAccess.Size = new System.Drawing.Size(56, 13);
         this.lblLastAccess.TabIndex = 17;
         this.lblLastAccess.Text = "10/10/2000";
         // 
         // lblLastAccessLabel
         // 
         this.lblLastAccessLabel.Location = new System.Drawing.Point(18, 346);
         this.lblLastAccessLabel.Name = "lblLastAccessLabel";
         this.lblLastAccessLabel.Size = new System.Drawing.Size(55, 13);
         this.lblLastAccessLabel.TabIndex = 16;
         this.lblLastAccessLabel.Text = "Last access";
         // 
         // lblCreated
         // 
         this.lblCreated.Location = new System.Drawing.Point(86, 327);
         this.lblCreated.Name = "lblCreated";
         this.lblCreated.Size = new System.Drawing.Size(56, 13);
         this.lblCreated.TabIndex = 15;
         this.lblCreated.Text = "10/10/2000";
         // 
         // lblCreatedLabel
         // 
         this.lblCreatedLabel.Location = new System.Drawing.Point(18, 327);
         this.lblCreatedLabel.Name = "lblCreatedLabel";
         this.lblCreatedLabel.Size = new System.Drawing.Size(39, 13);
         this.lblCreatedLabel.TabIndex = 14;
         this.lblCreatedLabel.Text = "Created";
         // 
         // ProjectEditorView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(427, 458);
         this.Controls.Add(this.tabPlugin);
         this.Controls.Add(this.cmdAccept);
         this.Controls.Add(this.cmdCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ProjectEditorView";
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
         ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl lblSize;
        private DevExpress.XtraEditors.LabelControl lblSizeLabel;
        private DevExpress.XtraEditors.LabelControl lblPath;
        private DevExpress.XtraEditors.LabelControl lblPathLabel;
        private DevExpress.XtraEditors.LabelControl lblFilename;
        private DevExpress.XtraEditors.LabelControl lblFilenameLabel;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.LabelControl lblLastAccess;
        private DevExpress.XtraEditors.LabelControl lblLastAccessLabel;
        private DevExpress.XtraEditors.LabelControl lblCreated;
        private DevExpress.XtraEditors.LabelControl lblCreatedLabel;
        private DevExpress.XtraEditors.SeparatorControl separatorControl2;
    }
}