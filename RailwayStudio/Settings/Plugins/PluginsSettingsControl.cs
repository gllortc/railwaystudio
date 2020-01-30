using DevExpress.XtraBars.Ribbon;
using Rwm.Otc.Configuration;
using Rwm.Studio.Views;
using System.Data;
using System.Windows.Forms;

namespace Rwm.Studio.Settings.Plugins
{
   public partial class PluginsSettingsControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      public PluginsSettingsControl()
      {
         InitializeComponent();
      }

      public PluginsSettingsControl(XmlSettingsManager settings)
      {
         InitializeComponent();

         this.Settings = settings;
         this.PluginManager = new PluginManager(settings);

         ListPlugins();
      }

      #endregion

      #region Properties

      public XmlSettingsManager Settings { get; private set; }

      public PluginManager PluginManager { get; private set; }

      #endregion

      #region Methods

      public void Initialize(XmlSettingsManager settings)
      {
         this.Settings = settings;
         this.PluginManager = new PluginManager(settings);

         ListPlugins();
      }

      #endregion

      #region Event Handlers

      private void gcPlugins_Gallery_ContextButtonClick(object sender, DevExpress.Utils.ContextItemClickEventArgs e)
      {
         Application.DoEvents();

         switch (e.Item.Name)
         {
            case "cbEdit":
               EditPlugin(((GalleryItem)e.DataItem).Value as Plugin);
               break;
            case "cbDelete":
               DeletePlugin(((GalleryItem)e.DataItem).Value as Plugin);
               break;
         }
      }

      private void cmdPluginAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         FrmPluginEditor form = new FrmPluginEditor(this.Settings);
         form.ShowDialog(this);

         if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
         {
            this.PluginManager.Add(form.Plugin);
            this.PluginManager.Settings.SaveSettings();

            // Refresh the list
            ListPlugins();
         }
      }

      #endregion

      #region Private Members

      private void ListPlugins()
      {
         GalleryItem item;

         gcPlugins.Gallery.Groups.Clear();
         gcPlugins.Gallery.Groups.Add(new GalleryItemGroup());

         foreach (Plugin plugin in this.PluginManager.GetAll())
         {
            item = new GalleryItem();
            item.Caption = plugin.Name;
            item.Description = string.Empty;
            item.Image = global::Rwm.Studio.Properties.Resources.ICO_PLUGIN_32;
            item.Value = plugin;

            gcPlugins.Gallery.Groups[0].Items.Add(item);
         }
      }

      private void EditPlugin(Plugin plugin)
      {
         if (plugin == null)
         {
            return;
         }

         FrmPluginEditor form = new FrmPluginEditor(this.Settings, plugin);
         form.ShowDialog(this);

         if (form.DialogResult == DialogResult.OK)
         {
            this.PluginManager.Add(form.Plugin);
            this.PluginManager.Settings.SaveSettings();

            // Refresh the list
            ListPlugins();
         }
      }

      private void DeletePlugin(Plugin plugin)
      {
         if (plugin == null)
         {
            return;
         }

         if (MessageBox.Show("Are you sure you want to delete the selected plugin " + plugin.Name + "?",
                             Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
         {
            this.PluginManager.Remove(plugin.ID);

            // Refresh the list
            ListPlugins();
         }
      }

      #endregion

   }
}
