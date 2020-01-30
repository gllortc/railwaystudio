using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

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
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      /// <summary>
      /// Sets the theme used to render the switchboard panels.
      /// </summary>
      public IDigitalSystem GetSystem()
      {
         XmlSettingsItem item = null;
         IDigitalSystem system = null;

         Logger.LogDebug(this, "[CLASS].GetSystem()");

         try
         {
            item = this.Settings.GetItem(SystemManager.SETTINGS_SYSTEMS_KEY);
            if (item != null)
            {
               Assembly assembly = Assembly.LoadFrom(item.GetString(SystemManager.SETTINGS_SYSTEM_PATH));
               Type type = assembly.GetType(item.GetString(SystemManager.SETTINGS_SYSTEM_CLASS));

               system = (IDigitalSystem)Activator.CreateInstance(type);
            }

            return system;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      /// <summary>
      /// Get all theme instances included in the application directory.
      /// </summary>
      /// <returns>A lis of all theme instances.</returns>
      public List<IDigitalSystem> GetAll()
      {
         Assembly assembly;
         IDigitalSystem system = null;
         List<IDigitalSystem> systems = new List<IDigitalSystem>();

         Logger.LogDebug(this, "[CLASS].GetAll()");

         try
         {
            foreach (string path in System.IO.Directory.GetFiles(ReflectionUtils.GetCurrentAssemblyPath(), "*.dll"))
            {
               try
               {
                  assembly = Assembly.LoadFile(path);
                  foreach (Type type in assembly.GetTypes())
                  {
                     if (typeof(IDigitalSystem).IsAssignableFrom(type) && !type.IsInterface)
                     {
                        system = (IDigitalSystem)Activator.CreateInstance(type);
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

            throw;
         }
      }

      /// <summary>
      /// Gets all themes in an instance of <see cref="DataTable"/>.
      /// </summary>
      /// <returns>The requested instance of <see cref="DataTable"/>.</returns>
      public DataTable Find()
      {
         DataTable dt;

         Logger.LogDebug(this, "[CLASS].GetAllAsDataTable()");

         try
         {
            dt = new DataTable("Systems");
            dt.Columns.Add("GUID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Type", typeof(Type));

            foreach (IDigitalSystem item in this.GetAll())
            {
               dt.Rows.Add(new object[] { item.ID,
                                          item.Name,
                                          item.Description,
                                          item.GetType() });
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

   }
}
