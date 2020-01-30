using DevExpress.Skins;
using DevExpress.XtraEditors.Controls;
using RailwayStudio.Common.Controls;
using Rwm.Otc;
using Rwm.Otc.Diagnostics;
using System;
using System.Windows.Forms;

namespace Rwm.Studio.Views
{
   public partial class SettingsView : DevExpress.XtraEditors.XtraForm
   {
      public SettingsView()
      {
         InitializeComponent();


         chkProjectsLoadLast.Checked = OTCContext.Settings.GetBoolean(Program.SETUP_KEY_PROJECT_LASTLOAD);

         ListSkins();
         LoadPlugins();
         LoadLoggers();
      }

      private void cmdAccept_Click(object sender, EventArgs e)
      {
         if (cboSkin.SelectedItem == null)
         {
            MessageBox.Show("You must select the visual skin.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboSkin.Focus();
            return;
         }

         SkinContainer skin = ((ImageComboBoxItem)cboSkin.SelectedItem).Value as SkinContainer;
         OTCContext.Settings.AddSetting(Program.SETUP_KEY_UI_SKIN, skin.SkinName);
         OTCContext.Settings.AddSetting(Program.SETUP_KEY_PROJECT_LASTLOAD, chkProjectsLoadLast.Checked);

         // Enable application visual styles
         DevExpress.Skins.SkinManager.EnableFormSkins();
         DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
         DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = OTCContext.Settings.GetString(Program.SETUP_KEY_UI_SKIN, "DevExpress Style");

         OTCContext.Settings.SaveSettings();

         this.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.Close();
      }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.Close();
      }

      private void ListSkins()
      {
         int idx = 0;
         string skName = string.Empty;
         System.Drawing.Image img = null;
         ImageComboBoxItem item = null;
         ImageComboBoxItem selectedItem = null;

         ImageList imlSkinIcons = new ImageList();
         imlSkinIcons.ImageSize = new System.Drawing.Size(16, 16);
         imlSkinIcons.ColorDepth = ColorDepth.Depth32Bit;
         cboSkin.Properties.SmallImages = imlSkinIcons;

         SkinContainerCollection skins = SkinManager.Default.Skins;
         for (int i = 0; i < skins.Count; i++)
         {
            skName = skins[i].SkinName;

            img = SkinCollectionHelper.GetSkinIcon(skName, SkinIconsSize.Small);
            imlSkinIcons.Images.Add(img);

            item = new ImageComboBoxItem();
            item.Value = skins[i];
            item.Description = skName;
            item.ImageIndex = idx;

            if (skName == OTCContext.Settings.GetString(Program.SETUP_KEY_UI_SKIN))
            {
               selectedItem = item;
            }

            cboSkin.Properties.Items.Add(item);

            idx++;
         }

         // Set current style in combo
         if (selectedItem != null)
         {
            cboSkin.SelectedItem = selectedItem;
         }
      }

      private void LoadPlugins()
      {
         PluginManagementControl ctrl = new PluginManagementControl();
         ctrl.Dock = DockStyle.Fill;

         tabSettingsPlugins.Controls.Clear();
         tabSettingsPlugins.Controls.Add(ctrl);
      }

      private void LoadLoggers()
      {
         ImageComboBoxItem item = null;

         item = new ImageComboBoxItem();
         item.Description = "Disabled";
         item.Value = null;
         item.ImageIndex = 6;

         cboLogFileLevel.Properties.Items.Add(item);
         cboLogWindowsLevel.Properties.Items.Add(item);

         item = new ImageComboBoxItem();
         item.Description = Logger.LogLevel.Error.ToString();
         item.Value = Logger.LogLevel.Error;
         item.ImageIndex = 5;

         cboLogFileLevel.Properties.Items.Add(item);
         cboLogWindowsLevel.Properties.Items.Add(item);

         item = new ImageComboBoxItem();
         item.Description = Logger.LogLevel.Warn.ToString();
         item.Value = Logger.LogLevel.Warn;
         item.ImageIndex = 4;

         cboLogFileLevel.Properties.Items.Add(item);
         cboLogWindowsLevel.Properties.Items.Add(item);

         item = new ImageComboBoxItem();
         item.Description = Logger.LogLevel.Info.ToString();
         item.Value = Logger.LogLevel.Info;
         item.ImageIndex = 3;

         cboLogFileLevel.Properties.Items.Add(item);
         cboLogWindowsLevel.Properties.Items.Add(item);

         item = new ImageComboBoxItem();
         item.Description = Logger.LogLevel.Debug.ToString();
         item.Value = Logger.LogLevel.Debug;
         item.ImageIndex = 2;

         cboLogFileLevel.Properties.Items.Add(item);
         cboLogWindowsLevel.Properties.Items.Add(item);
      }
   }
}