using DevExpress.XtraNavBar;
using System;
using System.Windows.Forms;

namespace Rwm.Studio.Settings
{
   public partial class SettingsControl : DevExpress.XtraEditors.XtraUserControl
   {
      public SettingsControl()
      {
         InitializeComponent();
         LoadSettingsSections();
      }

      private void nbcSettings_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
      {
         try
         {
            SuspendLayout();

            sccSettings.Panel2.Controls.Clear();

            Type panelType = (Type)e.Link.Item.Tag;
            UserControl panelInstance = Activator.CreateInstance(panelType) as UserControl;
            panelInstance.Dock = DockStyle.Fill;
            sccSettings.Panel2.Controls.Add(panelInstance);
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR loading settings module:" +
                            Environment.NewLine + ex.Message, 
                            Application.ProductName, 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
         }
         finally
         {
            ResumeLayout(true);
         }
      }

      private void LoadSettingsSections()
      {
         NavBarItem item;
         NavBarGroup group;

         nbcSettings.Items.Clear();
         nbcSettings.Groups.Clear();

         group = new NavBarGroup("Environment");
         group.Expanded = true;
         nbcSettings.Groups.Add(group);

         item = new NavBarItem("General");
         item.SmallImage = global::Rwm.Studio.Properties.Resources.ICO_CONFIG_16;
         item.LargeImage = global::Rwm.Studio.Properties.Resources.ICO_CONFIG_32;
         item.Tag = typeof(GeneralSettingsControl);
         group.ItemLinks.Add(item);

         item = new NavBarItem("Plugins");
         item.SmallImage = global::Rwm.Studio.Properties.Resources.ICO_PLUGIN_16;
         item.LargeImage = global::Rwm.Studio.Properties.Resources.ICO_PLUGIN_32;
         item.Tag = typeof(Rwm.Studio.Settings.Plugins.PluginsSettingsControl);
         group.ItemLinks.Add(item);

         group = new NavBarGroup("OTC");
         group.Expanded = true;
         nbcSettings.Groups.Add(group);

         item = new NavBarItem("Digital systems");
         item.SmallImage = global::Rwm.Studio.Properties.Resources.ICO_SYSTEM_16;
         item.LargeImage = global::Rwm.Studio.Properties.Resources.ICO_SYSTEM_32;
         item.Tag = typeof(string);
         group.ItemLinks.Add(item);

         item = new NavBarItem("Themes");
         item.SmallImage = global::Rwm.Studio.Properties.Resources.ICO_THEME_16;
         item.LargeImage = global::Rwm.Studio.Properties.Resources.ICO_THEME_32;
         item.Tag = typeof(string);
         group.ItemLinks.Add(item);
      }

      private void nbcSettings_CustomDrawGroupClientBackground(object sender, DevExpress.XtraNavBar.ViewInfo.CustomDrawObjectEventArgs e)
      {
         e.Appearance.BackColor = System.Drawing.Color.Transparent;
         e.Appearance.BackColor2 = System.Drawing.Color.Transparent;
         e.Appearance.Options.UseBackColor = true;
      }

      private void nbcSettings_CustomDrawBackground(object sender, DevExpress.XtraNavBar.ViewInfo.CustomDrawObjectEventArgs e)
      {
         e.Appearance.BackColor = System.Drawing.Color.Transparent;
         e.Appearance.BackColor2 = System.Drawing.Color.Transparent;
         e.Appearance.Options.UseBackColor = true;
      }
   }
}
