namespace Rwm.Studio.Plugins.Common.Views
{
   partial class PluginEditorView
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
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.lblModule = new DevExpress.XtraEditors.LabelControl();
         this.picIcon = new System.Windows.Forms.PictureBox();
         this.grdModules = new DevExpress.XtraGrid.GridControl();
         this.grdModulesView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.lblVersion = new DevExpress.XtraEditors.LabelControl();
         this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
         this.separatorControl2 = new DevExpress.XtraEditors.SeparatorControl();
         this.lblDeveloperLabel = new DevExpress.XtraEditors.LabelControl();
         this.lblDeveloper = new DevExpress.XtraEditors.LabelControl();
         this.lblCopyright = new DevExpress.XtraEditors.LabelControl();
         this.lblCopyrightLabel = new DevExpress.XtraEditors.LabelControl();
         ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdModules)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdModulesView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).BeginInit();
         this.SuspendLayout();
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(324, 364);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 0;
         this.cmdCancel.Text = "Cancelar";
         this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
         // 
         // cmdOK
         // 
         this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOK.Location = new System.Drawing.Point(243, 364);
         this.cmdOK.Name = "cmdOK";
         this.cmdOK.Size = new System.Drawing.Size(75, 23);
         this.cmdOK.TabIndex = 1;
         this.cmdOK.Text = "Install";
         this.cmdOK.Click += new System.EventHandler(this.CmdOK_Click);
         // 
         // lblName
         // 
         this.lblName.Appearance.FontSizeDelta = 2;
         this.lblName.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
         this.lblName.Appearance.Options.UseFont = true;
         this.lblName.Location = new System.Drawing.Point(53, 12);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(99, 17);
         this.lblName.TabIndex = 2;
         this.lblName.Text = "Package name";
         // 
         // lblModule
         // 
         this.lblModule.Location = new System.Drawing.Point(12, 146);
         this.lblModule.Name = "lblModule";
         this.lblModule.Size = new System.Drawing.Size(83, 13);
         this.lblModule.TabIndex = 7;
         this.lblModule.Text = "Included modules";
         // 
         // picIcon
         // 
         this.picIcon.ErrorImage = null;
         this.picIcon.InitialImage = null;
         this.picIcon.Location = new System.Drawing.Point(12, 12);
         this.picIcon.Name = "picIcon";
         this.picIcon.Size = new System.Drawing.Size(32, 32);
         this.picIcon.TabIndex = 11;
         this.picIcon.TabStop = false;
         // 
         // grdModules
         // 
         this.grdModules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grdModules.Location = new System.Drawing.Point(12, 165);
         this.grdModules.MainView = this.grdModulesView;
         this.grdModules.Name = "grdModules";
         this.grdModules.Size = new System.Drawing.Size(387, 193);
         this.grdModules.TabIndex = 10;
         this.grdModules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdModulesView});
         // 
         // grdModulesView
         // 
         this.grdModulesView.GridControl = this.grdModules;
         this.grdModulesView.Name = "grdModulesView";
         this.grdModulesView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdModulesView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdModulesView.OptionsBehavior.Editable = false;
         this.grdModulesView.OptionsBehavior.ReadOnly = true;
         this.grdModulesView.OptionsCustomization.AllowColumnMoving = false;
         this.grdModulesView.OptionsCustomization.AllowGroup = false;
         this.grdModulesView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdModulesView.OptionsView.ShowGroupPanel = false;
         this.grdModulesView.OptionsView.ShowIndicator = false;
         this.grdModulesView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.GrdModulesView_CustomDrawCell);
         // 
         // lblVersion
         // 
         this.lblVersion.Location = new System.Drawing.Point(53, 31);
         this.lblVersion.Name = "lblVersion";
         this.lblVersion.Size = new System.Drawing.Size(54, 13);
         this.lblVersion.TabIndex = 13;
         this.lblVersion.Text = "Version 1.0";
         // 
         // separatorControl1
         // 
         this.separatorControl1.Location = new System.Drawing.Point(12, 50);
         this.separatorControl1.Name = "separatorControl1";
         this.separatorControl1.Size = new System.Drawing.Size(387, 23);
         this.separatorControl1.TabIndex = 14;
         // 
         // separatorControl2
         // 
         this.separatorControl2.Location = new System.Drawing.Point(12, 117);
         this.separatorControl2.Name = "separatorControl2";
         this.separatorControl2.Size = new System.Drawing.Size(387, 23);
         this.separatorControl2.TabIndex = 15;
         // 
         // lblDeveloperLabel
         // 
         this.lblDeveloperLabel.Location = new System.Drawing.Point(12, 79);
         this.lblDeveloperLabel.Name = "lblDeveloperLabel";
         this.lblDeveloperLabel.Size = new System.Drawing.Size(49, 13);
         this.lblDeveloperLabel.TabIndex = 16;
         this.lblDeveloperLabel.Text = "Developer";
         // 
         // lblDeveloper
         // 
         this.lblDeveloper.Location = new System.Drawing.Point(78, 79);
         this.lblDeveloper.Name = "lblDeveloper";
         this.lblDeveloper.Size = new System.Drawing.Size(4, 13);
         this.lblDeveloper.TabIndex = 16;
         this.lblDeveloper.Text = "-";
         // 
         // lblCopyright
         // 
         this.lblCopyright.Location = new System.Drawing.Point(78, 98);
         this.lblCopyright.Name = "lblCopyright";
         this.lblCopyright.Size = new System.Drawing.Size(4, 13);
         this.lblCopyright.TabIndex = 17;
         this.lblCopyright.Text = "-";
         // 
         // lblCopyrightLabel
         // 
         this.lblCopyrightLabel.Location = new System.Drawing.Point(12, 98);
         this.lblCopyrightLabel.Name = "lblCopyrightLabel";
         this.lblCopyrightLabel.Size = new System.Drawing.Size(47, 13);
         this.lblCopyrightLabel.TabIndex = 18;
         this.lblCopyrightLabel.Text = "Copyright";
         // 
         // PluginEditorView
         // 
         this.AcceptButton = this.cmdOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(411, 399);
         this.Controls.Add(this.lblCopyright);
         this.Controls.Add(this.lblCopyrightLabel);
         this.Controls.Add(this.lblDeveloper);
         this.Controls.Add(this.lblDeveloperLabel);
         this.Controls.Add(this.separatorControl2);
         this.Controls.Add(this.separatorControl1);
         this.Controls.Add(this.lblVersion);
         this.Controls.Add(this.lblModule);
         this.Controls.Add(this.grdModules);
         this.Controls.Add(this.picIcon);
         this.Controls.Add(this.lblName);
         this.Controls.Add(this.cmdOK);
         this.Controls.Add(this.cmdCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PluginEditorView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Plugin properties";
         ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdModules)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdModulesView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.SimpleButton cmdOK;
      private DevExpress.XtraEditors.LabelControl lblName;
      private DevExpress.XtraEditors.LabelControl lblModule;
      private DevExpress.XtraGrid.GridControl grdModules;
      private DevExpress.XtraGrid.Views.Grid.GridView grdModulesView;
      private System.Windows.Forms.PictureBox picIcon;
        private DevExpress.XtraEditors.LabelControl lblVersion;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.SeparatorControl separatorControl2;
        private DevExpress.XtraEditors.LabelControl lblDeveloperLabel;
        private DevExpress.XtraEditors.LabelControl lblDeveloper;
        private DevExpress.XtraEditors.LabelControl lblCopyright;
        private DevExpress.XtraEditors.LabelControl lblCopyrightLabel;
    }
}