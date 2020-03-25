using System;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraEditors.Controls;
using RailwayStudio.Common;
using RailwayStudio.Common.Controls;
using Rwm.Otc.Diagnostics;

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
         LoadLoggers();
      }

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

         StudioContext.SkinName = skin.SkinName;
         StudioContext.OpenLastProject = chkProjectsLoadLast.Checked;
         StudioContext.SaveSettings();

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
         PluginManagementControl ctrl = new PluginManagementControl();
         ctrl.Dock = DockStyle.Fill;

         tabSettingsPlugins.Controls.Clear();
         tabSettingsPlugins.Controls.Add(ctrl);
      }

      private void LoadLoggers()
      {
         ImageComboBoxItem item = new ImageComboBoxItem();
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

      #endregion

   }
}