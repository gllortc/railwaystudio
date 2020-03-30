using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Rwm.Otc;
using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;

namespace Rwm.Studio.Plugins.Common
{
   /// <summary>
   /// Allows manage all application plugins.
   /// </summary>
   public class PluginManager
   {

      #region Constants

      public const string SETTINGS_KEY_PLUGINS = "rwm.studio.plugins";

      public const string PLUGIN_TEXTEDITOR = Modules.TextEditorModule.MODULE_GUID;
      public const string PLUGIN_REPORTVIEWER = Modules.ReportViewerModule.MODULE_GUID;

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
      /// Install new plug-in package into current instance.
      /// </summary>
      /// <param name="package">Plug-in package to install.</param>
      /// <param name="path">Path (with filename) to the assembly file containing the plugin.</param>
      public void Add(IPluginPackage package)
      {
         Logger.LogDebug(this, "[CLASS].Add([{0}])", package);

         if (package == null)
         {
            return;
         }

         try
         {
            XmlSettingsItem xmlPlugin = new XmlSettingsItem();
            xmlPlugin.Key = package.ID;
            xmlPlugin.Value = package.GetType().Assembly.Location;

            XmlSettingsItem pluginSection = this.GetPluginsSection();
            pluginSection.AddSetting(xmlPlugin);

            OTCContext.Settings.SaveSettings();

            // Add to current instance
            this.InstalledPackages.Add(package);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      /// <summary>
      /// Remove the specified plug-in package from the settings and also unload the package from the current application instance.
      /// </summary>
      /// <param name="packageId">Plug-in package unique identifier.</param>
      public void Remove(string packageId)
      {
         Logger.LogDebug(this, "[CLASS].Remove('{0}')", packageId);

         try
         {
            // Remove from the settings
            XmlSettingsItem pluginSection = this.GetPluginsSection();
            pluginSection.Remove(packageId);
            OTCContext.Settings.SaveSettings();

            // Remove from current instance
            this.InstalledPackages.Remove(this.GetPluguinPackage(packageId));
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      /// <summary>
      /// Gets the specified plug-in package by its ID.
      /// </summary>
      /// <param name="packageId">Plug-in package unique identifier.</param>
      /// <returns>The requested <see cref="IPluginPackage"/> or <c>null</c> if the identifier doesn't exist.</returns>
      public IPluginPackage GetPluguinPackage(string packageId)
      {
         Logger.LogDebug(this, "[CLASS].Get('{0}')", packageId);

         try
         {
            foreach (IPluginPackage package in this.InstalledPackages)
            {
               if (package.ID.Equals(packageId))
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
      /// Gets the specified plug-in module by its ID.
      /// </summary>
      /// <param name="moduleID">Plug-in module unique identifier.</param>
      /// <returns>The requested <see cref="IPluginModule"/> or <c>null</c> if the identifier doesn't exist.</returns>
      public IPluginModule GetPluginModule(string moduleID)
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

      /// <summary>
      /// Load all installed packages.
      /// </summary>
      public void LoadPackages()
      {
         Logger.LogDebug(this, "[CLASS].LoadPackages()");

         try
         {
            this.InstalledPackages = new List<IPluginPackage>();

            XmlSettingsItem pluginSection = this.GetPluginsSection();
            if (pluginSection != null)
            {
               foreach (XmlSettingsItem item in pluginSection.Items.Values)
               {
                  string assemblyFile = this.FindAssemblyFile(item.Value);
                  if (assemblyFile != null)
                  {
                     // Find the package descriptor type
                     Assembly assembly = Assembly.LoadFile(assemblyFile);
                     foreach (Type type in assembly.GetExportedTypes())
                     {
                        if (typeof(IPluginPackage).IsAssignableFrom(type) && type.IsClass)
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

            // Add the RaiilwayStudio Common Tools plug-in
            foreach (Type type in this.GetType().Assembly.GetExportedTypes())
            {
               if (typeof(IPluginPackage).IsAssignableFrom(type) && type.IsClass)
               {
                  IPluginPackage package = Activator.CreateInstance(type) as IPluginPackage;
                  package.LoadModules(type);

                  this.InstalledPackages.Add(package);

                  break;
               }
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
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

      /// <summary>
      /// Find an assembly file from a path (complete or single filename).
      /// - Check if file exists. 
      ///   - If exists, return same path.
      ///   - If not exists, find the filename into the application folder.
      /// </summary>
      /// <param name="initialPath">Path stored in the settings item.</param>
      /// <returns>The path found or an <code>null</code> string if no file has been found.</returns>
      private string FindAssemblyFile(string initialPath)
      {
         if (File.Exists(initialPath))
         {
            // This trick resolve the existing single filenames (without path)
            FileInfo fi = new FileInfo(initialPath);
            return fi.FullName;
         }
         else
         {
            // Get the file name without path
            FileInfo fi = new FileInfo(initialPath);

            // Get the installation path (where setting are stored)
            FileInfo settingsfi = new FileInfo(OTCContext.Settings.Filename);

            string path = Path.Combine(settingsfi.DirectoryName, fi.Name);
            if (File.Exists(path))
            {
               return path;
            }
         }

         return null;
      }

      #endregion

   }
}
