using System.Collections.Generic;
using Rwm.Otc.Configuration;

namespace Rwm.Otc.Diagnostics
{
   /// <summary>
   /// Management class that implements a logger modules store using the standard <see cref="XmlSettingsManager"/>.
   /// </summary>
   public class LoggerSettingsManager
   {

      #region Constants

      /// <summary>Settings key to store the current connection timeout.</summary>
      public const string SETTING_DB_TIMEOUT = "ksk.db.timeout";
      /// <summary>Settings key to store the default host.</summary>
      public const string SETTING_DB_DEFAULT_HOST = "ksk.db.host-default";
      /// <summary>Settings key to store the default TCP port.</summary>
      public const string SETTING_DB_DEFAULT_PORT = "ksk.db.port-default";
      /// <summary>Settings key to store the library name.</summary>
      public const string SETTING_LIB_NAME = "lib.name";
      /// <summary>Settings key to store the type of library.</summary>
      public const string SETTING_LIB_TYPE = "lib.type";
      /// <summary>Settings key to store the filename and path for a KSK library.</summary>
      public const string SETTING_LIB_FILE = "lib.file";
      /// <summary>Settings key to store the class name for a KSK library.</summary>
      public const string SETTING_LIB_CLASS = "lib.class";

      /// <summary>Plugin that contains all the KSK libraries needed by an application.</summary>
      public const string PLUGIN_LOGGER_REPOSITORY = "logger.repository";

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="LoggerSettingsManager"/>.
      /// </summary>
      /// <param name="settings">The current settings for the application.</param>
      public LoggerSettingsManager() //XmlSettingsManager settings)
      {
         // this.Settings = settings;
         this.AutoStore = false;

         // Get the plugin uset to store the connections
         this.LoggerPlugin = OTCContext.Settings.GetItem(LoggerSettingsManager.PLUGIN_LOGGER_REPOSITORY);
         if (this.LoggerPlugin == null)
         {
            this.LoggerPlugin = new XmlSettingsItem(LoggerSettingsManager.PLUGIN_LOGGER_REPOSITORY, string.Empty);
            OTCContext.Settings.AddSetting(this.LoggerPlugin);
         }
      }

      #endregion

      #region Properties

      /// <summary>
      /// Internal data declarations.
      /// </summary>
      private XmlSettingsItem LoggerPlugin { get; set; }

      /// <summary>
      /// Gets a value indicating if the settings must be saved en each operation.
      /// </summary>
      /// <remarks>By default this value is setted as a <c>true</c>.</remarks>
      public bool AutoStore { get; set; }

      /// <summary>
      /// Gets a list of libraries managed by this class.
      /// </summary>
      /// <remarks>This list is read-only. Adding elements into this list don't affect the stored connections in settings.</remarks>
      public List<XmlSettingsItem> LoggerModules 
      { 
         get
         {
            List<XmlSettingsItem> conns = new List<XmlSettingsItem>();
            foreach (XmlSettingsItem module in this.LoggerPlugin.Items.Values)
            {
               conns.Add(module);
            }

            return conns;
         }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Add or update a DLL library.
      /// </summary>
      /// <param name="module">Library to store.</param>
      /// <param name="setAsDefault">If <c>true</c> if the library must set as default library.</param>
      public void AddLibrary(XmlSettingsItem module)
      {
         if (module == null)
            return;

         this.LoggerPlugin.AddSetting(module);

         if (this.AutoStore)
         {
            OTCContext.Settings.SaveSettings();
         }
      }

      /// <summary>
      /// Remove a DLL library.
      /// </summary>
      /// <param name="library">Library to remove.</param>
      public void RemoveLibrary(XmlSettingsItem library)
      {
         this.RemoveLibrary(ConvertNameToID(library.Value));
      }

      /// <summary>
      /// Remove a DLL library.
      /// </summary>
      /// <param name="libraryId">Library identifier.</param>
      public void RemoveLibrary(string libraryId)
      {
         if (this.LoggerPlugin.Items.ContainsKey(libraryId))
         {
            this.LoggerPlugin.Items.Remove(libraryId);

            if (this.AutoStore)
            {
               OTCContext.Settings.SaveSettings();
            }
         }
         else if (this.LoggerPlugin.Items.ContainsKey(LoggerSettingsManager.ConvertNameToID(libraryId)))
         {
            this.LoggerPlugin.Items.Remove(libraryId);

            if (this.AutoStore)
            {
               OTCContext.Settings.SaveSettings();
            }
         }
      }

      /// <summary>
      /// Gets the specified library.
      /// </summary>
      /// <param name="libraryId">Library unique identifier.</param>
      /// <returns></returns>
      public XmlSettingsItem GetLibrary(string libraryId)
      {
         if (this.LoggerPlugin.Items.ContainsKey(libraryId))
         {
            return this.LoggerPlugin.Items[libraryId];
         }

         return null;
      }


      #endregion

      #region Private Members

      private static string ConvertNameToID(string connectionName)
      {
         return connectionName.Replace(" ", "_");
      }

      #endregion

   }
}
