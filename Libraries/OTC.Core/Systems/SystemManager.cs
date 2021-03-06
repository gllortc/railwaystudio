﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Utils;

namespace Rwm.Otc.Systems
{

   /// <summary>
   /// Manage the swithcboard panel blocks persistence in database.
   /// </summary>
   public class SystemManager
   {

      #region Constants

      // SQL declarations
      public static string SETTINGS_SYSTEMS_KEY = "otc.systems";

      internal static string SETTINGS_SYSTEM_CLASS = "sys.class";
      internal static string SETTINGS_SYSTEM_PATH = "sys.path";

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="SystemManager"/>.
      /// </summary>
      /// <param name="settings">The current application settings.</param>
      public SystemManager(XmlSettingsManager settings)
      {
         this.Settings = settings;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the current application settings.
      /// </summary>
      public XmlSettingsManager Settings { get; private set; }

      /// <summary>
      /// Gets a value indicating if there is a selected theme.
      /// </summary>
      public bool IsThemeSelected
      {
         get { return (this.GetSystem() != null); }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Sets the theme used to render the switchboard panels.
      /// </summary>
      public void SetSystem(DigitalSystem system)
      {
         this.SetSystem(system.GetType());
      }

      /// <summary>
      /// Sets the theme used to render the switchboard panels.
      /// </summary>
      public void SetSystem(Type type)
      {
         Logger.LogDebug(this, "[CLASS].SetSystem([{0}])", type.FullName);

         try
         {
            XmlSettingsItem item = new XmlSettingsItem(SystemManager.SETTINGS_SYSTEMS_KEY, string.Empty);
            item.AddSetting(SystemManager.SETTINGS_SYSTEM_PATH, ReflectionUtils.GetAssemblyFile(type));
            item.AddSetting(SystemManager.SETTINGS_SYSTEM_CLASS, type.FullName);

            this.Settings.AddSetting(item);
            this.Settings.SaveSettings();

            // Force ti reload the digital system according to the selection
            OTCContext.Project.LoadSystem();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      /// <summary>
      /// Sets the theme used to render the switchboard panels.
      /// </summary>
      public DigitalSystem GetSystem()
      {
         XmlSettingsItem item = null;
         DigitalSystem system = null;

         Logger.LogDebug(this, "[CLASS].GetSystem()");

         try
         {
            item = this.Settings.GetItem(SystemManager.SETTINGS_SYSTEMS_KEY);
            if (item != null)
            {
               Assembly assembly = Assembly.LoadFrom(item.GetString(SystemManager.SETTINGS_SYSTEM_PATH));
               if (assembly == null) return null;

               Type type = assembly.GetType(item.GetString(SystemManager.SETTINGS_SYSTEM_CLASS));
               if (type == null) return null;

               system = (DigitalSystem)Activator.CreateInstance(type);
            }

            return system;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      /// <summary>
      /// Get all theme instances included in the application directory.
      /// </summary>
      /// <returns>A list of all systems found.</returns>
      public List<DigitalSystem> GetAll()
      {
         Assembly assembly;
         DigitalSystem system = null;
         List<DigitalSystem> systems = new List<DigitalSystem>();

         Logger.LogDebug(this, "[CLASS].GetAll()");

         try
         {
            foreach (string path in System.IO.Directory.GetFiles(ReflectionUtils.GetCurrentAssemblyPath(), "*.dll"))
            {
               try
               {
                  assembly = Assembly.LoadFile(path);
                  Type[] types = assembly.GetTypes();
                  foreach (Type type in types)
                  {
                     if (typeof(DigitalSystem).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                     {
                        system = (DigitalSystem)Activator.CreateInstance(type);
                        if (system != null)
                        {
                           systems.Add(system);
                        }
                     }
                  }
               }
               catch (Exception ex)
               {
                  Logger.LogError(this, ex);
               }
            }
            
            return systems;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      #endregion

   }
}
