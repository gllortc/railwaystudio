using System;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraEditors.Controls;
using Rwm.Otc;
using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using Rwm.Studio.Plugins.Common;
using Rwm.Studio.Plugins.Common.Controls;

namespace Rwm.Studio.Views
{
   public partial class SettingsView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public SettingsView()
      {
         InitializeComponent();

         chkProjectsLoadLast.Checked = StudioContext.OpenLastProject;

         ListSkins();
         LoadPlugins();
         LoadFileLogger();
         LoadWinLogger();
      }

      #endregion

      #region Properties

      private PluginManagementControl PluginsControl { get; set; } = null;

      public bool RefreshPluginsBar { get; private set; } = false;

      #endregion

      #region Event Handlers

      private void CmdAccept_Click(object sender, EventArgs e)
      {
         if (cboSkin.SelectedItem == null)
         {
            MessageBox.Show("You must select the visual skin.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboSkin.Focus();
            return;
         }

         // Change the current skin
         SkinContainer skin = ((ImageComboBoxItem)cboSkin.SelectedItem).Value as SkinContainer;
         SkinManager.EnableFormSkins();
         DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
         DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = skin.SkinName;

         // General settings
         StudioContext.SkinName = skin.SkinName;
         StudioContext.OpenLastProject = chkProjectsLoadLast.Checked;

         // LOGs settings
         Logger.LogLevel level = this.GetLoggerLevel(cboLogFileLevel);
         if (level == Logger.LogLevel.Disabled)
         {
            Logger.ModuleManager.RemoveLibrary(typeof(FileLogger).Name);
         }
         else
         {
            XmlSettingsItem library = new XmlSettingsItem(typeof(FileLogger).Name, typeof(FileLogger).FullName);
            library.AddSetting(Logger.SETTING_LOG_LEVEL, level.ToString().ToLower());
            Logger.ModuleManager.AddLibrary(library);
         }

         level = this.GetLoggerLevel(cboLogWindowsLevel);
         if (level == Logger.LogLevel.Disabled)
         {
            Logger.ModuleManager.RemoveLibrary(typeof(WinLogger).Name);
         }
         else
         {
            XmlSettingsItem library = new XmlSettingsItem(typeof(WinLogger).Name, typeof(WinLogger).FullName);
            library.AddSetting(Logger.SETTING_LOG_LEVEL, level.ToString().ToLower());
            library.AddSetting(WinLogger.SETTING_LOG_NAME, txtLogWindowsName.Text);
            library.AddSetting(WinLogger.SETTING_LOG_SOURCE, txtLogWindowsSource.Text);
            Logger.ModuleManager.AddLibrary(library);
         }

         OTCContext.Settings.SaveSettings();

         this.RefreshPluginsBar = this.PluginsControl.PluginsChanged;

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Private Members

      private void ListSkins()
      {
         int idx = 0;
         ImageComboBoxItem selectedItem = null;

         ImageList imlSkinIcons = new ImageList();
         imlSkinIcons.ImageSize = new System.Drawing.Size(16, 16);
         imlSkinIcons.ColorDepth = ColorDepth.Depth32Bit;
         cboSkin.Properties.SmallImages = imlSkinIcons;

         SkinContainerCollection skins = SkinManager.Default.Skins;
         for (int i = 0; i < skins.Count; i++)
         {
            string skName = skins[i].SkinName;

            System.Drawing.Image img = SkinCollectionHelper.GetSkinIcon(skName, SkinIconsSize.Small);
            imlSkinIcons.Images.Add(img);

            ImageComboBoxItem item = new ImageComboBoxItem();
            item.Value = skins[i];
            item.Description = skName;
            item.ImageIndex = idx;

            if (skName.Equals(StudioContext.SkinName))
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
         this.PluginsControl = new PluginManagementControl();
         this.PluginsControl.Dock = DockStyle.Fill;

         tabSettingsPlugins.Controls.Clear();
         tabSettingsPlugins.Controls.Add(this.PluginsControl);
      }

      private Logger.LogLevel GetLoggerLevel(DevExpress.XtraEditors.ImageComboBoxEdit editor)
      {
         ImageComboBoxItem item = editor.SelectedItem as ImageComboBoxItem;
         return (Logger.LogLevel)item.Value;
      }

      private void LoadFileLogger()
      {
         ImageComboBoxItem item;
         XmlSettingsItem logger = Logger.ModuleManager.GetLibrary(typeof(FileLogger).Name);

         foreach (Logger.LogLevel level in Enum.GetValues(typeof(Logger.LogLevel)))
         {
            item = new ImageComboBoxItem();
            item.Description = level.ToString();
            item.Value = level;
            item.ImageIndex = (int)level;
            cboLogFileLevel.Properties.Items.Add(item);

            if (logger != null && level == Logger.StringToLogLevel(logger.GetString(Logger.SETTING_LOG_LEVEL)))
               cboLogFileLevel.SelectedItem = item;
         }

         if (cboLogFileLevel.SelectedItem == null)
            cboLogFileLevel.SelectedItem = cboLogFileLevel.Properties.Items[0];
      }

      private void LoadWinLogger()
      {
         ImageComboBoxItem item;
         XmlSettingsItem logger = Logger.ModuleManager.GetLibrary(typeof(WinLogger).Name);

         foreach (Logger.LogLevel level in Enum.GetValues(typeof(Logger.LogLevel)))
         {
            item = new ImageComboBoxItem();
            item.Description = level.ToString();
            item.Value = level;
            item.ImageIndex = (int)level;
            cboLogWindowsLevel.Properties.Items.Add(item);

            if (logger != null && level == Logger.StringToLogLevel(logger.GetString(Logger.SETTING_LOG_LEVEL)))
               cboLogWindowsLevel.SelectedItem = item;
         }

         if (cboLogWindowsLevel.SelectedItem == null)
            cboLogWindowsLevel.SelectedItem = cboLogWindowsLevel.Properties.Items[0];
         else
         {
            txtLogWindowsName.Text = logger.GetString(WinLogger.SETTING_LOG_NAME);
            txtLogWindowsSource.Text = logger.GetString(WinLogger.SETTING_LOG_SOURCE);
         }
      }

      #endregion

   }
}