namespace Rwm.Studio.Settings
{
   partial class SettingsControl
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.nbcSettings = new DevExpress.XtraNavBar.NavBarControl();
         this.nbgEnvironment = new DevExpress.XtraNavBar.NavBarGroup();
         this.nbiGeneral = new DevExpress.XtraNavBar.NavBarItem();
         this.nbiPlugins = new DevExpress.XtraNavBar.NavBarItem();
         this.nbgOTC = new DevExpress.XtraNavBar.NavBarGroup();
         this.nbiOtcSystems = new DevExpress.XtraNavBar.NavBarItem();
         this.nbiOtcGui = new DevExpress.XtraNavBar.NavBarItem();
         this.sccSettings = new DevExpress.XtraEditors.SplitContainerControl();
         this.lblTitle = new DevExpress.XtraEditors.LabelControl();
         ((System.ComponentModel.ISupportInitialize)(this.nbcSettings)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.sccSettings)).BeginInit();
         this.sccSettings.SuspendLayout();
         this.SuspendLayout();
         // 
         // nbcSettings
         // 
         this.nbcSettings.ActiveGroup = this.nbgEnvironment;
         this.nbcSettings.Appearance.Background.BackColor = System.Drawing.Color.Transparent;
         this.nbcSettings.Appearance.Background.BackColor2 = System.Drawing.Color.Transparent;
         this.nbcSettings.Appearance.Background.Options.UseBackColor = true;
         this.nbcSettings.Dock = System.Windows.Forms.DockStyle.Fill;
         this.nbcSettings.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbgEnvironment,
            this.nbgOTC});
         this.nbcSettings.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbiGeneral,
            this.nbiPlugins,
            this.nbiOtcSystems,
            this.nbiOtcGui});
         this.nbcSettings.LinkSelectionMode = DevExpress.XtraNavBar.LinkSelectionModeType.OneInControl;
         this.nbcSettings.Location = new System.Drawing.Point(0, 0);
         this.nbcSettings.Name = "nbcSettings";
         this.nbcSettings.OptionsNavPane.ExpandedWidth = 183;
         this.nbcSettings.Size = new System.Drawing.Size(183, 528);
         this.nbcSettings.TabIndex = 0;
         this.nbcSettings.Text = "navBarControl1";
         this.nbcSettings.CustomDrawGroupClientBackground += new DevExpress.XtraNavBar.ViewInfo.CustomDrawObjectEventHandler(this.nbcSettings_CustomDrawGroupClientBackground);
         this.nbcSettings.CustomDrawBackground += new DevExpress.XtraNavBar.ViewInfo.CustomDrawObjectEventHandler(this.nbcSettings_CustomDrawBackground);
         this.nbcSettings.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbcSettings_LinkClicked);
         // 
         // nbgEnvironment
         // 
         this.nbgEnvironment.Caption = "Environment";
         this.nbgEnvironment.Expanded = true;
         this.nbgEnvironment.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiGeneral),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiPlugins)});
         this.nbgEnvironment.Name = "nbgEnvironment";
         // 
         // nbiGeneral
         // 
         this.nbiGeneral.Caption = "General";
         this.nbiGeneral.LargeImage = global::Rwm.Studio.Properties.Resources.ICO_CONFIG_32;
         this.nbiGeneral.Name = "nbiGeneral";
         this.nbiGeneral.SmallImage = global::Rwm.Studio.Properties.Resources.ICO_CONFIG_16;
         // 
         // nbiPlugins
         // 
         this.nbiPlugins.Caption = "Plugins";
         this.nbiPlugins.LargeImage = global::Rwm.Studio.Properties.Resources.ICO_PLUGIN_32;
         this.nbiPlugins.Name = "nbiPlugins";
         this.nbiPlugins.SmallImage = global::Rwm.Studio.Properties.Resources.ICO_PLUGIN_16;
         // 
         // nbgOTC
         // 
         this.nbgOTC.Caption = "OTC";
         this.nbgOTC.Expanded = true;
         this.nbgOTC.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiOtcSystems),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiOtcGui)});
         this.nbgOTC.Name = "nbgOTC";
         // 
         // nbiOtcSystems
         // 
         this.nbiOtcSystems.Caption = "Digital systems";
         this.nbiOtcSystems.LargeImage = global::Rwm.Studio.Properties.Resources.ICO_SYSTEM_32;
         this.nbiOtcSystems.Name = "nbiOtcSystems";
         this.nbiOtcSystems.SmallImage = global::Rwm.Studio.Properties.Resources.ICO_SYSTEM_16;
         // 
         // nbiOtcGui
         // 
         this.nbiOtcGui.Caption = "Themes";
         this.nbiOtcGui.LargeImage = global::Rwm.Studio.Properties.Resources.ICO_THEME_32;
         this.nbiOtcGui.Name = "nbiOtcGui";
         this.nbiOtcGui.SmallImage = global::Rwm.Studio.Properties.Resources.ICO_THEME_16;
         // 
         // sccSettings
         // 
         this.sccSettings.Dock = System.Windows.Forms.DockStyle.Fill;
         this.sccSettings.Location = new System.Drawing.Point(0, 54);
         this.sccSettings.Name = "sccSettings";
         this.sccSettings.Panel1.Controls.Add(this.nbcSettings);
         this.sccSettings.Panel1.Text = "Panel1";
         this.sccSettings.Panel2.Text = "Panel2";
         this.sccSettings.Size = new System.Drawing.Size(662, 528);
         this.sccSettings.SplitterPosition = 183;
         this.sccSettings.TabIndex = 1;
         this.sccSettings.Text = "splitContainerControl1";
         // 
         // lblTitle
         // 
         this.lblTitle.Appearance.FontSizeDelta = 10;
         this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
         this.lblTitle.Location = new System.Drawing.Point(0, 0);
         this.lblTitle.Name = "lblTitle";
         this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 25);
         this.lblTitle.Size = new System.Drawing.Size(84, 54);
         this.lblTitle.TabIndex = 2;
         this.lblTitle.Text = "Settings";
         // 
         // SettingsControl
         // 
         this.Appearance.BackColor = System.Drawing.Color.Transparent;
         this.Appearance.Options.UseBackColor = true;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.sccSettings);
         this.Controls.Add(this.lblTitle);
         this.Name = "SettingsControl";
         this.Size = new System.Drawing.Size(662, 582);
         ((System.ComponentModel.ISupportInitialize)(this.nbcSettings)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.sccSettings)).EndInit();
         this.sccSettings.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraNavBar.NavBarControl nbcSettings;
      private DevExpress.XtraEditors.SplitContainerControl sccSettings;
      private DevExpress.XtraNavBar.NavBarItem nbiGeneral;
      private DevExpress.XtraNavBar.NavBarGroup nbgEnvironment;
      private DevExpress.XtraNavBar.NavBarItem nbiPlugins;
      private DevExpress.XtraNavBar.NavBarGroup nbgOTC;
      private DevExpress.XtraNavBar.NavBarItem nbiOtcSystems;
      private DevExpress.XtraNavBar.NavBarItem nbiOtcGui;
      private DevExpress.XtraEditors.LabelControl lblTitle;
   }
}
