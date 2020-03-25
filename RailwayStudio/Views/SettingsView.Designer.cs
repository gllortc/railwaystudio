namespace Rwm.Studio.Views
{
   partial class SettingsView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsView));
         this.tabSettings = new DevExpress.XtraTab.XtraTabControl();
         this.tabSettingsGeneral = new DevExpress.XtraTab.XtraTabPage();
         this.grpProjects = new DevExpress.XtraEditors.GroupControl();
         this.chkProjectsLoadLast = new DevExpress.XtraEditors.CheckEdit();
         this.grpInterface = new DevExpress.XtraEditors.GroupControl();
         this.lblSkin = new DevExpress.XtraEditors.LabelControl();
         this.cboSkin = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.tabSettingsPlugins = new DevExpress.XtraTab.XtraTabPage();
         this.tabSettingsLogs = new DevExpress.XtraTab.XtraTabPage();
         this.grpLogWindowsProperties = new DevExpress.XtraEditors.GroupControl();
         this.txtLogWindowsSource = new DevExpress.XtraEditors.TextEdit();
         this.lblLogWindowsSource = new DevExpress.XtraEditors.LabelControl();
         this.txtLogWindowsName = new DevExpress.XtraEditors.TextEdit();
         this.lblLogWindowsName = new DevExpress.XtraEditors.LabelControl();
         this.cboLogWindowsLevel = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         this.lblLogWindowsLevel = new DevExpress.XtraEditors.LabelControl();
         this.grpLogFileProperties = new DevExpress.XtraEditors.GroupControl();
         this.cboLogFileLevel = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.lblLogFileLevel = new DevExpress.XtraEditors.LabelControl();
         this.cmdAccept = new DevExpress.XtraEditors.SimpleButton();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         ((System.ComponentModel.ISupportInitialize)(this.tabSettings)).BeginInit();
         this.tabSettings.SuspendLayout();
         this.tabSettingsGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grpProjects)).BeginInit();
         this.grpProjects.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chkProjectsLoadLast.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpInterface)).BeginInit();
         this.grpInterface.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboSkin.Properties)).BeginInit();
         this.tabSettingsLogs.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grpLogWindowsProperties)).BeginInit();
         this.grpLogWindowsProperties.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtLogWindowsSource.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtLogWindowsName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboLogWindowsLevel.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpLogFileProperties)).BeginInit();
         this.grpLogFileProperties.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboLogFileLevel.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // tabSettings
         // 
         this.tabSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabSettings.Location = new System.Drawing.Point(12, 12);
         this.tabSettings.Name = "tabSettings";
         this.tabSettings.SelectedTabPage = this.tabSettingsGeneral;
         this.tabSettings.Size = new System.Drawing.Size(613, 364);
         this.tabSettings.TabIndex = 0;
         this.tabSettings.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabSettingsGeneral,
            this.tabSettingsPlugins,
            this.tabSettingsLogs});
         // 
         // tabSettingsGeneral
         // 
         this.tabSettingsGeneral.Controls.Add(this.grpProjects);
         this.tabSettingsGeneral.Controls.Add(this.grpInterface);
         this.tabSettingsGeneral.Name = "tabSettingsGeneral";
         this.tabSettingsGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.tabSettingsGeneral.Size = new System.Drawing.Size(607, 336);
         this.tabSettingsGeneral.Text = "General";
         // 
         // grpProjects
         // 
         this.grpProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpProjects.Controls.Add(this.chkProjectsLoadLast);
         this.grpProjects.Location = new System.Drawing.Point(13, 92);
         this.grpProjects.Name = "grpProjects";
         this.grpProjects.Padding = new System.Windows.Forms.Padding(10);
         this.grpProjects.Size = new System.Drawing.Size(581, 73);
         this.grpProjects.TabIndex = 1;
         this.grpProjects.Text = "Projects";
         // 
         // chkProjectsLoadLast
         // 
         this.chkProjectsLoadLast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.chkProjectsLoadLast.Location = new System.Drawing.Point(15, 33);
         this.chkProjectsLoadLast.Name = "chkProjectsLoadLast";
         this.chkProjectsLoadLast.Properties.Caption = "Load last opened project at startup";
         this.chkProjectsLoadLast.Size = new System.Drawing.Size(551, 19);
         this.chkProjectsLoadLast.TabIndex = 0;
         // 
         // grpInterface
         // 
         this.grpInterface.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpInterface.Controls.Add(this.lblSkin);
         this.grpInterface.Controls.Add(this.cboSkin);
         this.grpInterface.Location = new System.Drawing.Point(13, 13);
         this.grpInterface.Name = "grpInterface";
         this.grpInterface.Padding = new System.Windows.Forms.Padding(10);
         this.grpInterface.Size = new System.Drawing.Size(581, 73);
         this.grpInterface.TabIndex = 0;
         this.grpInterface.Text = "Interface";
         // 
         // lblSkin
         // 
         this.lblSkin.Location = new System.Drawing.Point(15, 36);
         this.lblSkin.Name = "lblSkin";
         this.lblSkin.Size = new System.Drawing.Size(81, 13);
         this.lblSkin.TabIndex = 1;
         this.lblSkin.Text = "Apparence (skin)";
         // 
         // cboSkin
         // 
         this.cboSkin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboSkin.Location = new System.Drawing.Point(123, 33);
         this.cboSkin.Name = "cboSkin";
         this.cboSkin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboSkin.Size = new System.Drawing.Size(443, 20);
         this.cboSkin.TabIndex = 0;
         // 
         // tabSettingsPlugins
         // 
         this.tabSettingsPlugins.Name = "tabSettingsPlugins";
         this.tabSettingsPlugins.Padding = new System.Windows.Forms.Padding(5);
         this.tabSettingsPlugins.Size = new System.Drawing.Size(607, 336);
         this.tabSettingsPlugins.Text = "Plugins";
         // 
         // tabSettingsLogs
         // 
         this.tabSettingsLogs.Controls.Add(this.grpLogWindowsProperties);
         this.tabSettingsLogs.Controls.Add(this.grpLogFileProperties);
         this.tabSettingsLogs.Name = "tabSettingsLogs";
         this.tabSettingsLogs.Padding = new System.Windows.Forms.Padding(10);
         this.tabSettingsLogs.Size = new System.Drawing.Size(607, 336);
         this.tabSettingsLogs.Text = "Logging";
         // 
         // grpLogWindowsProperties
         // 
         this.grpLogWindowsProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpLogWindowsProperties.CaptionImage = global::Rwm.Studio.Properties.Resources.ICO_WINDOWS_16;
         this.grpLogWindowsProperties.Controls.Add(this.txtLogWindowsSource);
         this.grpLogWindowsProperties.Controls.Add(this.lblLogWindowsSource);
         this.grpLogWindowsProperties.Controls.Add(this.txtLogWindowsName);
         this.grpLogWindowsProperties.Controls.Add(this.lblLogWindowsName);
         this.grpLogWindowsProperties.Controls.Add(this.cboLogWindowsLevel);
         this.grpLogWindowsProperties.Controls.Add(this.lblLogWindowsLevel);
         this.grpLogWindowsProperties.Location = new System.Drawing.Point(13, 87);
         this.grpLogWindowsProperties.Name = "grpLogWindowsProperties";
         this.grpLogWindowsProperties.Padding = new System.Windows.Forms.Padding(10);
         this.grpLogWindowsProperties.Size = new System.Drawing.Size(581, 123);
         this.grpLogWindowsProperties.TabIndex = 1;
         this.grpLogWindowsProperties.Text = "Windows";
         // 
         // txtLogWindowsSource
         // 
         this.txtLogWindowsSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtLogWindowsSource.Location = new System.Drawing.Point(83, 85);
         this.txtLogWindowsSource.Name = "txtLogWindowsSource";
         this.txtLogWindowsSource.Size = new System.Drawing.Size(483, 20);
         this.txtLogWindowsSource.TabIndex = 5;
         // 
         // lblLogWindowsSource
         // 
         this.lblLogWindowsSource.Location = new System.Drawing.Point(15, 88);
         this.lblLogWindowsSource.Name = "lblLogWindowsSource";
         this.lblLogWindowsSource.Size = new System.Drawing.Size(33, 13);
         this.lblLogWindowsSource.TabIndex = 4;
         this.lblLogWindowsSource.Text = "Source";
         // 
         // txtLogWindowsName
         // 
         this.txtLogWindowsName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtLogWindowsName.Location = new System.Drawing.Point(83, 59);
         this.txtLogWindowsName.Name = "txtLogWindowsName";
         this.txtLogWindowsName.Size = new System.Drawing.Size(483, 20);
         this.txtLogWindowsName.TabIndex = 3;
         // 
         // lblLogWindowsName
         // 
         this.lblLogWindowsName.Location = new System.Drawing.Point(15, 62);
         this.lblLogWindowsName.Name = "lblLogWindowsName";
         this.lblLogWindowsName.Size = new System.Drawing.Size(27, 13);
         this.lblLogWindowsName.TabIndex = 2;
         this.lblLogWindowsName.Text = "Name";
         // 
         // cboLogWindowsLevel
         // 
         this.cboLogWindowsLevel.Location = new System.Drawing.Point(83, 33);
         this.cboLogWindowsLevel.Name = "cboLogWindowsLevel";
         this.cboLogWindowsLevel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboLogWindowsLevel.Properties.SmallImages = this.imageList;
         this.cboLogWindowsLevel.Size = new System.Drawing.Size(168, 20);
         this.cboLogWindowsLevel.TabIndex = 1;
         // 
         // imageList
         // 
         this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
         this.imageList.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList.Images.SetKeyName(0, "brick_16.png");
         this.imageList.Images.SetKeyName(1, "brick_error.png");
         this.imageList.Images.SetKeyName(2, "ICO_LOG_DEBUG");
         this.imageList.Images.SetKeyName(3, "ICO_LOG_INFO");
         this.imageList.Images.SetKeyName(4, "ICO_LOG_WARN");
         this.imageList.Images.SetKeyName(5, "ICO_LOG_ERR");
         this.imageList.Images.SetKeyName(6, "ICO_LOG_DISABLED");
         // 
         // lblLogWindowsLevel
         // 
         this.lblLogWindowsLevel.Location = new System.Drawing.Point(15, 36);
         this.lblLogWindowsLevel.Name = "lblLogWindowsLevel";
         this.lblLogWindowsLevel.Size = new System.Drawing.Size(25, 13);
         this.lblLogWindowsLevel.TabIndex = 0;
         this.lblLogWindowsLevel.Text = "Level";
         // 
         // grpLogFileProperties
         // 
         this.grpLogFileProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpLogFileProperties.CaptionImage = global::Rwm.Studio.Properties.Resources.ICO_FOLDER_16;
         this.grpLogFileProperties.Controls.Add(this.cboLogFileLevel);
         this.grpLogFileProperties.Controls.Add(this.lblLogFileLevel);
         this.grpLogFileProperties.Location = new System.Drawing.Point(13, 13);
         this.grpLogFileProperties.Name = "grpLogFileProperties";
         this.grpLogFileProperties.Padding = new System.Windows.Forms.Padding(10);
         this.grpLogFileProperties.Size = new System.Drawing.Size(581, 68);
         this.grpLogFileProperties.TabIndex = 0;
         this.grpLogFileProperties.Text = "File";
         // 
         // cboLogFileLevel
         // 
         this.cboLogFileLevel.Location = new System.Drawing.Point(83, 33);
         this.cboLogFileLevel.Name = "cboLogFileLevel";
         this.cboLogFileLevel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboLogFileLevel.Properties.SmallImages = this.imageList;
         this.cboLogFileLevel.Size = new System.Drawing.Size(168, 20);
         this.cboLogFileLevel.TabIndex = 1;
         // 
         // lblLogFileLevel
         // 
         this.lblLogFileLevel.Location = new System.Drawing.Point(15, 36);
         this.lblLogFileLevel.Name = "lblLogFileLevel";
         this.lblLogFileLevel.Size = new System.Drawing.Size(25, 13);
         this.lblLogFileLevel.TabIndex = 0;
         this.lblLogFileLevel.Text = "Level";
         // 
         // cmdAccept
         // 
         this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdAccept.Location = new System.Drawing.Point(469, 382);
         this.cmdAccept.Name = "cmdAccept";
         this.cmdAccept.Size = new System.Drawing.Size(75, 23);
         this.cmdAccept.TabIndex = 1;
         this.cmdAccept.Text = "Accept";
         this.cmdAccept.Click += new System.EventHandler(this.CmdAccept_Click);
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(550, 382);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 2;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
         // 
         // FrmSettings
         // 
         this.AcceptButton = this.cmdAccept;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(637, 417);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.cmdAccept);
         this.Controls.Add(this.tabSettings);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmSettings";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Settings";
         ((System.ComponentModel.ISupportInitialize)(this.tabSettings)).EndInit();
         this.tabSettings.ResumeLayout(false);
         this.tabSettingsGeneral.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grpProjects)).EndInit();
         this.grpProjects.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.chkProjectsLoadLast.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpInterface)).EndInit();
         this.grpInterface.ResumeLayout(false);
         this.grpInterface.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboSkin.Properties)).EndInit();
         this.tabSettingsLogs.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grpLogWindowsProperties)).EndInit();
         this.grpLogWindowsProperties.ResumeLayout(false);
         this.grpLogWindowsProperties.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtLogWindowsSource.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtLogWindowsName.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboLogWindowsLevel.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpLogFileProperties)).EndInit();
         this.grpLogFileProperties.ResumeLayout(false);
         this.grpLogFileProperties.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboLogFileLevel.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraTab.XtraTabControl tabSettings;
      private DevExpress.XtraTab.XtraTabPage tabSettingsGeneral;
      private DevExpress.XtraTab.XtraTabPage tabSettingsPlugins;
      private DevExpress.XtraEditors.SimpleButton cmdAccept;
      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private System.Windows.Forms.ImageList imageList;
      private DevExpress.XtraEditors.GroupControl grpInterface;
      private DevExpress.XtraEditors.LabelControl lblSkin;
      private DevExpress.XtraEditors.ImageComboBoxEdit cboSkin;
      private DevExpress.XtraEditors.GroupControl grpProjects;
      private DevExpress.XtraEditors.CheckEdit chkProjectsLoadLast;
      private DevExpress.XtraTab.XtraTabPage tabSettingsLogs;
      private DevExpress.XtraEditors.GroupControl grpLogFileProperties;
      private DevExpress.XtraEditors.ImageComboBoxEdit cboLogFileLevel;
      private DevExpress.XtraEditors.LabelControl lblLogFileLevel;
      private DevExpress.XtraEditors.GroupControl grpLogWindowsProperties;
      private DevExpress.XtraEditors.ImageComboBoxEdit cboLogWindowsLevel;
      private DevExpress.XtraEditors.LabelControl lblLogWindowsLevel;
      private DevExpress.XtraEditors.TextEdit txtLogWindowsSource;
      private DevExpress.XtraEditors.LabelControl lblLogWindowsSource;
      private DevExpress.XtraEditors.TextEdit txtLogWindowsName;
      private DevExpress.XtraEditors.LabelControl lblLogWindowsName;
   }
}