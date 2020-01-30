using System;
using Rwm.Otc.Configuration;
using Rwm.Otc.Data;
using Rwm.Otc.Data.ORM;
using Rwm.Otc.Diagnostics;

namespace Rwm.Otc
{
   public static class OTCContext
   {

      #region Constants

      /// <summary>OTC library product name.</summary>
      private const string OTC_PN = "Open Train Control (OTC)";
      /// <summary>OTC library version.</summary>
      private const string OTC_VERSION = "1.0";

      #endregion

      #region Fields
      #endregion

      #region Properties

      /// <summary>
      /// Gets the library version.
      /// </summary>
      public static string OTCVersion
      {
         get { return OTCContext.OTC_VERSION; }
      }

      /// <summary>
      /// Devuelve el nombre de producto de la aplicación.
      /// </summary>
      public static string ProductName
      {
         get { return OTCContext.OTC_PN; }
      }

      /// <summary>
      /// Gets the current application settings.
      /// </summary>
      public static XmlSettingsManager Settings { get; private set; }

      /// <summary>
      /// Gets the current application settings.
      /// </summary>
      public static Project Project { get; private set; }

      #endregion

      #region Methods

      /// <summary>
      /// Initialize the OTC context.
      /// </summary>
      public static void Initialize()
      {
         // Load settings
         OTCContext.Settings = new XmlSettingsManager();
         OTCContext.Settings.LoadSettings();

         // Load theme
         OTCContext.Project = null;
      }

      /// <summary>
      /// Create new OTC layout project.
      /// </summary>
      /// <param name="path">Filename (and path) for the new project file.</param>
      /// <param name="project">Initialized project (only with basic data).</param>
      public static void CreateProject(string path, string name, string description, string version)
      {
         if (string.IsNullOrWhiteSpace(path))
         {
            throw new Exception("Cannot create database: file and path not specified.");
         }
         else if (System.IO.File.Exists(path))
         {
            throw new Exception("Cannot create database: a project with same filename yet exist.");
         }

         try
         {
            // Create database file
            System.Data.SQLite.SQLiteConnection.CreateFile(path);

            // Store the current database to the settings
            OTCContext.Settings.AddSetting(ORMSqliteDriver.SETTINGS_DB_CURRENT, path);

            // Ensure that the database have the latest schema
            ControlDataEntity cde = new ControlDataEntity();
            cde.CheckDatabase();

            // Create new project instance
            OTCContext.Project = new Otc.Project();
            OTCContext.Project.Name = name.Trim();
            OTCContext.Project.Description = description.Trim();
            OTCContext.Project.Version = version.Trim();

            // Store the project into the database
            Project.Save(OTCContext.Project);
         }
         catch (Exception ex)
         {
            Logger.LogError(ex);

            throw;
         }
      }

      /// <summary>
      /// Open an existing project.
      /// </summary>
      /// <param name="path">Filename and path to the project to open.</param>
      /// <param name="systemInformationEventHandler">Event handler to receive notification from digital system.</param>
      public static void OpenProject(string path)
      {
         if (string.IsNullOrWhiteSpace(path))
         {
            throw new Exception("Cannot open project: file and path not specified.");
         }
         else if (!System.IO.File.Exists(path))
         {
            throw new Exception("Cannot open project: provided file doesn't exists.");
         }

         try
         {
            // Store the current database to the settings
            OTCContext.Settings.AddSetting(ORMSqliteDriver.SETTINGS_DB_CURRENT, path);

            // Load the project data
            OTCContext.Project = Project.Get(1);
            if (OTCContext.Project == null) 
               throw new Exception("Bad project file.");

            OTCContext.Project.Filename = path;
            OTCContext.Project.LoadSystem();
            OTCContext.Project.LoadTheme();

            // Initialize the digital system
            OTCContext.Project.SystemManager.GetSystem();
         }
         catch (Exception ex)
         {
            Logger.LogError(ex);

            throw;
         }
      }

      /// <summary>
      /// Create new OTC layout project.
      /// </summary>
      public static void UpdateProjectData()
      {
         try
         {
            // Store the project into the database
            Project.Save(OTCContext.Project);
         }
         catch (Exception ex)
         {
            Logger.LogError(ex);

            throw;
         }
      }

      #endregion

   }
}
