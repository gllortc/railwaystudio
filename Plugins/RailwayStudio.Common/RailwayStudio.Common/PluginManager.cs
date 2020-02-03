﻿using Rwm.Otc;
using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data;

namespace RailwayStudio.Common
{
   /// <summary>
   /// Allows manage all application plugins.
   /// </summary>
   public class PluginManager
   {

      #region Constants

      public const string SETTINGS_KEY_PLUGINS = "rwm.studio.plugins";

      public const string PLUGIN_TEXTEDITOR = RailwayStudio.Common.Modules.Editors.TextEditorModule.MODULE_GUID;
      public const string PLUGIN_REPORTVIEWER = RailwayStudio.Common.Modules.Reports.ReportViewerModule.MODULE_GUID;

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="PluginManager"/>.
      /// </summary>
      public PluginManager() { }

      #endregion

      #region Methods

      /// <summary>
      /// Adds a new plugin declaration into the plugins section in settings.
      /// </summary>
      /// <param name="plugin">Plugin declaration.</param>
      /// <param name="path">Path (with filename) to the assembly file containing the plugin.</param>
      public void Add(IPlugin plugin, string path)
      {
         Logger.LogDebug(this, "[CLASS].Add([{0}])", plugin);

         if (plugin == null)
         {
            return;
         }

         try
         {
            XmlSettingsItem xmlPlugin = new XmlSettingsItem();
            xmlPlugin.Key = plugin.ID;
            xmlPlugin.Value = plugin.Name;
            xmlPlugin.AddSetting("assembly-file", path);

            XmlSettingsItem pluginSection = this.GetPluginsSection();
            pluginSection.AddSetting(xmlPlugin);

            OTCContext.Settings.AddSetting(pluginSection);
            OTCContext.Settings.SaveSettings();
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
            XmlSettingsItem pluginSection = OTCContext.Settings.GetItem(PluginManager.SETTINGS_KEY_PLUGINS);
            if (pluginSection != null)
            {
               pluginSection.Remove(key);
               OTCContext.Settings.SaveSettings();
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
            XmlSettingsItem pluginSection = OTCContext.Settings.GetItem(PluginManager.SETTINGS_KEY_PLUGINS);
            if (pluginSection != null)
            {
               return new Plugin(pluginSection.GetItem(pluginId));
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
         Plugin plugin = null;
         List<Plugin> plugins = new List<Plugin>();

         Logger.LogDebug(this, "[CLASS].GetAll()");

         try
         {
            XmlSettingsItem pluginSection = OTCContext.Settings.GetItem(PluginManager.SETTINGS_KEY_PLUGINS);
            if (pluginSection != null)
            {
               foreach (XmlSettingsItem item in pluginSection.Items.Values)
               {
                  plugin = new Plugin(pluginSection.GetItem(item.Key));
                  if (plugin != null) plugins.Add(plugin);
               }
            }

            // Add buil-in common plug-ins 
            plugin = new Plugin();
            plugin.ID = "RailwayStudio.Common";
            plugin.Name = "Utilities";
            plugin.File = this.GetType().Assembly.Location.ToString();

            plugins.Add(plugin);

            return plugins;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      public DataTable Find()
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

            XmlSettingsItem pluginSection = OTCContext.Settings.GetItem(PluginManager.SETTINGS_KEY_PLUGINS);
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
         XmlSettingsItem section = OTCContext.Settings.GetItem(PluginManager.SETTINGS_KEY_PLUGINS);

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