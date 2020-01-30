using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors.Controls;
using Rwm.Otc.Configuration;
using Rwm.Studio.Views.Controllers;

namespace Rwm.Studio.Settings
{
   public partial class GeneralSettingsControl : DevExpress.XtraEditors.XtraUserControl
   {
      public GeneralSettingsControl(XmlSettingsManager settings)
      {
         InitializeComponent();

         this.Settings = settings;

         ListSkins();
      }

      public XmlSettingsManager Settings { get; private set; }

      private void ListSkins()
      {
         ImageComboBoxItem item;

         SkinContainerCollection skins = SkinManager.Default.Skins;
         foreach (SkinContainer skin in skins)
         {
            imlIcons.Images.Add(SkinCollectionHelper.GetSkinIcon(skin.SkinName, SkinIconsSize.Small));

            item = new ImageComboBoxItem();
            item.Description = skin.SkinName;
            item.Value = skin;
            item.ImageIndex = imlIcons.Images.Count - 1;

            cboSkin.Properties.Items.Add(item);

            if (UserLookAndFeel.DefaultSkinName.Equals(skin.SkinName))
            {
               cboSkin.SelectedItem = item;
            }
         }
      }

      private void cboSkin_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         if (this.Settings != null)
         {
            this.Settings.AddSetting(MainController.SETUP_KEY_UI_SKIN, cboSkin.Text);
            this.Settings.SaveSettings();

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = cboSkin.Text;
         }
      }
   }
}
