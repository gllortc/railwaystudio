using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data;

namespace Rwm.Studio.Settings.Plugins
{
   public class PluginManager
   {

      public const string SETTINGS_KEY_PLUGINS = "rwm.studio.plugins";

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="PluginManager"/>.
      /// </summary>
      /// <param name="settings">The current settings for the application.</param>
      public PluginManager(XmlSettingsManager settings)
      {
         this.Settings = settings;
      }

      #endregion

      #region Properties

      public XmlSettingsManager Settings { get; private set; }

      #endregion

      #region Methods

      public void Add(Plugin plugin)
      {
         Logger.LogDebug(this, "[CLASS].Add([{0}])", plugin);

         try
         {
            XmlSettingsItem xmlPlugin = new XmlSettingsItem();
            xmlPlugin.Key = plugin.ID;
            xmlPlugin.Value = plugin.Name;
            xmlPlugin.AddSetting("assembly-file", plugin.File);

            XmlSettingsItem pluginSection = GetPluginsSection();
            pluginSection.AddSetting(xmlPlugin);

            this.Settings.AddSetting(pluginSection);
            this.Settings.SaveSettings();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      public void Remove(string key)
      {
         Logger.LogDebug(this, "[CLASS].Remove('{0}')", key);

         try
         {
            XmlSettingsItem pluginSection = this.Settings.GetItem(PluginManager.SETTINGS_KEY_PLUGINS);
            if (pluginSection != null)
            {
               pluginSection.Remove(key);
               this.Settings.SaveSettings();
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      public Plugin Get(string pluginId)
      {
         Logger.LogDebug(this, "[CLASS].Get('{0}')", pluginId);

         try
         {
            XmlSettingsItem pluginSection = this.Settings.GetItem(PluginManager.SETTINGS_KEY_PLUGINS);
            if (pluginSection != null)
            {
               XmlSettingsItem xmlPlugin = pluginSection.GetItem(pluginId);
               Plugin plugin = new Plugin();
               plugin.ID = xmlPlugin.Key;
               plugin.Name = xmlPlugin.Value;
               plugin.File = xmlPlugin.GetString("assembly-file");

               return plugin;
            }

            return null;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      public List<Plugin> GetAll()
      {
         List<Plugin> plugins = new List<Plugin>();

         Logger.LogDebug(this, "[CLASS].GetAll()");

         try
         {
            XmlSettingsItem pluginSection = this.Settings.GetItem(PluginManager.SETTINGS_KEY_PLUGINS);
            if (pluginSection != null)
            {
               foreach (XmlSettingsItem item in pluginSection.Items.Values)
               {
                  XmlSettingsItem xmlPlugin = pluginSection.GetItem(item.Key);
                  Plugin plugin = new Plugin();
                  plugin.ID = xmlPlugin.Key;
                  plugin.Name = xmlPlugin.Value;
                  plugin.File = xmlPlugin.GetString("assembly-file");

                  plugins.Add(plugin);
               }

               return plugins;
            }

            return null;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      public DataTable GetAllAsDataTable()
      {
         Logger.LogDebug(this, "[CLASS].GetAllAsDataTable()");

         try
         {
            DataRow row;

            DataTable dt = new DataTable();
            dt.TableName = "Plugins";
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("File", typeof(string));
            dt.Columns.Add("Driver", typeof(string));

            XmlSettingsItem pluginSection = this.Settings.GetItem(PluginManager.SETTINGS_KEY_PLUGINS);
            if (pluginSection != null)
            {
               foreach (XmlSettingsItem xmlPlugin in pluginSection.Items.Values)
               {
                  row = dt.NewRow();
                  row["ID"] = xmlPlugin.Key;
                  row["Name"] = xmlPlugin.Value;
                  row["File"] = xmlPlugin.GetString("assembly-file");
                  row["Driver"] = xmlPlugin.GetString("class");
                  dt.Rows.Add(row);
               }
            }

            return dt;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      #endregion

      #region Private Members

      private XmlSettingsItem GetPluginsSection()
      {
         XmlSettingsItem section = this.Settings.GetItem(PluginManager.SETTINGS_KEY_PLUGINS);

         if (section == null)
         {
            section = new XmlSettingsItem();
            section.Key = PluginManager.SETTINGS_KEY_PLUGINS;
         }

         return section;
      }

      #endregion

   }
}
