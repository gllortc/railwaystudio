using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Rwm.Otc;
using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;

namespace RailwayStudio.Common
{
   /// <summary>
   /// Allows manage all application plugins.
   /// </summary>
   public class PluginManager
   {

      #region Constants

      public const string SETTINGS_KEY_PLUGINS = "rwm.studio.plugins";
      private const string SETTING_KEY_FILE = "assembly-file";

      public const string PLUGIN_TEXTEDITOR = Modules.Editors.TextEditorModule.MODULE_GUID;
      public const string PLUGIN_REPORTVIEWER = Modules.Reports.ReportViewerModule.MODULE_GUID;

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="PluginManager"/>.
      /// </summary>
      internal PluginManager() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the list of installed packages.
      /// </summary>
      public List<IPluginPackage> InstalledPackages { get; private set; } = new List<IPluginPackage>();

      #endregion

      #region Methods

      /// <summary>
      /// Adds a new plugin declaration into the plugins section in settings.
      /// </summary>
      /// <param name="plugin">Plugin declaration.</param>
      /// <param name="path">Path (with filename) to the assembly file containing the plugin.</param>
      public void Add(IPluginPackage plugin, string path)
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
            throw ex;
         }
      }

      public void Remove(string key)
      {
         Logger.LogDebug(this, "[CLASS].Remove('{0}')", key);

         try
         {
            XmlSettingsItem pluginSection = this.GetPluginsSection();
            pluginSection.Remove(key);
            OTCContext.Settings.SaveSettings();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      public IPluginPackage Get(string pluginId)
      {
         Logger.LogDebug(this, "[CLASS].Get('{0}')", pluginId);

         try
         {
            foreach (IPluginPackage package in this.InstalledPackages)
            {
               if (package.ID.Equals(pluginId))
               {
                  return package;
               }
            }

            return null;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      /// <summary>
      /// Load all installed packages.
      /// </summary>
      public void LoadPackages()
      {
         Logger.LogDebug(this, "[CLASS].LoadPackages()");

         try
         {
            this.InstalledPackages = new List<IPluginPackage>();

            XmlSettingsItem pluginSection = OTCContext.Settings.GetItem(PluginManager.SETTINGS_KEY_PLUGINS);
            if (pluginSection != null)
            {
               foreach (XmlSettingsItem item in pluginSection.Items.Values)
               {
                  string assemblyFile = item.GetString(PluginManager.SETTING_KEY_FILE);

                  if (File.Exists(assemblyFile))
                  {
                     // Find the package descriptor type
                     Assembly assembly = Assembly.LoadFile(item.GetString(PluginManager.SETTING_KEY_FILE));
                     foreach (Type type in assembly.GetExportedTypes())
                     {
                        if (typeof(IPluginPackage).IsAssignableFrom(type))
                        {
                           IPluginPackage package = Activator.CreateInstance(type) as IPluginPackage;
                           package.LoadModules(type);

                           this.InstalledPackages.Add(package);

                           break;
                        }
                     }
                  }
                  else
                  {
                     Logger.LogWarning(this, "Cannot load plug-in package: file not found : {0}", assemblyFile);
                  }
               }
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      public IPluginModule GetModuleByID(string moduleID)
      {
         foreach (IPluginPackage package in this.InstalledPackages)
         {
            foreach (IPluginModule module in package.Modules)
            {
               if (module.ID.Equals(moduleID))
               {
                  return module;
               }
            }
         }

         return null;
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
