using Rwm.Otc.Configuration;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.LayoutControl.Elements;
using Rwm.Otc.Systems;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Rwm.Otc.LayoutControl
{
   /// <summary>
   /// Implementation of an OTC layout control project.
   /// </summary>
   public class Project : DataEntity
   {

      #region Constants

      /// <summary>Database current version.</summary>
      public const string SETTING_KEY_DB_SCHEMAVER = "collection.db.version";

      // /// <summary>Database version 3.5</summary>
      // public const string DB_VERSION_3_5 = DB_CURRENT_VERSION;

      /// <summary>Database version 1.0</summary>
      public const string DB_VERSION_1_0 = "1.0";
      /// <summary>Database version 1.1</summary>
      public const string DB_VERSION_1_1 = "1.1";

      /// <summary>Database current version.</summary>
      public const string DB_CURRENT_VERSION = DB_VERSION_1_1;

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Project"/>.
      /// </summary>
      public Project(XmlSettingsManager settings)
         : base(settings)
      {
         Initialize();
      }

      /// <summary>
      /// Returns a new instance of <see cref="Project"/>.
      /// </summary>
      /// <param name="settings">The current application settings.</param>
      /// <param name="filename">Filename (and path) to file.</param>
      public Project(XmlSettingsManager settings, string filename)
         : base(settings)
      {
         Initialize();

         this.Open(filename);
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the filename (and path) for the project file.
      /// </summary>
      public string Filename { get; set; }

      /// <summary>
      /// Gets or sets the project name.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets the project description.
      /// </summary>
      public string Description { get; set; }

      /// <summary>
      /// Gets or sets the project version.
      /// </summary>
      public string Version { get; set; }

      /// <summary>
      /// Gets or sets the switchboard panels inlcuded in the project.
      /// </summary>
      public Dictionary<int, SwitchboardPanel> Panels { get; set; }

      /// <summary>
      /// Gets or sets the accessory modules included in the project.
      /// </summary>
      public Dictionary<int, ControlModule> AccessoryModules { get; set; }

      /// <summary>
      /// Gets or sets the sensor modules included in the project.
      /// </summary>
      public Dictionary<int, ControlModule> SensorModules { get; set; }

      /// <summary>
      /// Gets or sets all blocks in the project.
      /// </summary>
      public Dictionary<int, ElementBase> Elements { get; set; }

      /// <summary>
      /// Gets or sets all routes in the project.
      /// </summary>
      public Dictionary<int, Route> Routes { get; set; }

      /// <summary>
      /// Grets the active route in the layout.
      /// </summary>
      internal Route ActiveRoute { get; private set; }

      #endregion

      #region Method

      /// <summary>
      /// Open and load the specified project.
      /// </summary>
      /// <param name="filename">Filename and path for the project file to open.</param>
      public void Open(string filename)
      {
         this.Filename = filename;
         this.Settings.AddSetting(DataEntity.SETTINGS_DB_CURRENT, filename);

         // Load the project data
         this.Name = this.GetPropertyString("prj.name", "New project");
         this.Description = this.GetPropertyString("prj.description");
         this.Version = this.GetPropertyString("prj.version", "1.0");

         try
         {
            this.CheckDatabase();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
         }
      }

      /// <summary>
      /// Save the current project data.
      /// </summary>
      public void Save()
      {
         this.SetProperty("prj.name", this.Name);
         this.SetProperty("prj.description", this.Description);
         this.SetProperty("prj.version", this.Version);
      }

      /// <summary>
      /// Create a SQLite database that contains the project data.
      /// </summary>
      /// <param name="filename">Filename and path where the project file will be created.</param>
      public void Create(string filename)
      {
         string sql = string.Empty;

         if (string.IsNullOrWhiteSpace(filename))
         {
            throw new Exception("Cannot create database: file and path not specified.");
         }
         else if (System.IO.File.Exists(filename))
         {
            throw new Exception("Cannot create database: a project with same filename yet exist.");
         }

         try
         {
            // Create database file
            SQLiteConnection.CreateFile(filename);
            this.Filename = filename;

            // Store the current database to the settings
            this.Settings.AddSetting(DataEntity.SETTINGS_DB_CURRENT, filename);

            Connect();

            // Create registry values table 
            sql = @"CREATE TABLE " + DataEntity.SQL_REGISTRY_TABLE + @" (
                        key         text primary key,
                        value       text)";

            ExecuteNonQuery(sql);

            // Ensure that the database have the latest schema
            this.CheckDatabase();

            // Save project data into the new project file
            this.Save();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Ensure that the database exists and have the latest schema.
      /// </summary>
      public void LoadLayout()
      {
         try
         {
            // Initializations
            this.UnloadLayout();

            // Load all control modules
            foreach (ControlModule module in OTCContext.Layout.ControlModuleManager.GetAll())
            {
               switch (module.Type)
               {
                  case ControlModule.ModuleType.Accessory:
                     this.AccessoryModules.Add(module.ID, module);
                     break;

                  case ControlModule.ModuleType.Sensor:
                     this.SensorModules.Add(module.ID, module);
                     break;
               }
            }

            // Load all panels
            foreach (SwitchboardPanel panel in OTCContext.Layout.SwitchboardPanelManager.GetAll())
            {
               this.Panels.Add(panel.ID, panel);
            }

            // Load all elements
            foreach (ElementBase element in OTCContext.Layout.ElementManager.GetAll())
            {
               this.Elements.Add(element.ID, element);

               if (this.Panels.ContainsKey(element.SwitchboardPanel.ID))
               {
                  element.SwitchboardPanel = this.Panels[element.SwitchboardPanel.ID];
                  element.SwitchboardPanel.Elements.Add(element);
               }
            }

            // Load elements to switchboard panels
            foreach (ElementBase element in this.Elements.Values)
            {
               // Get all element actions
               element.Actions = OTCContext.Layout.ElementActionManager.GetByElement(element.ID);

               // Get all element accessory connections
               element.AccessoryConnections = OTCContext.Layout.ControlModuleConnectionManager.GetByElement(element, ControlModule.ModuleType.Accessory);
               foreach (ControlModuleConnection connection in element.AccessoryConnections)
               {
                  if (connection != null)
                  {
                     if (this.AccessoryModules.ContainsKey(connection.DecoderID))
                     {
                        connection.Decoder = this.AccessoryModules[connection.DecoderID];
                     }
                     else
                     {
                        Logger.LogWarning(this,
                                          "Accessory control module #{0} not found for connection #{1}.",
                                          connection.DecoderID, connection.ID);
                     }
                  }
               }

               // Get all element sensor connections
               element.FeedbackConnections = OTCContext.Layout.ControlModuleConnectionManager.GetByElement(element, ControlModule.ModuleType.Sensor);
               foreach (ControlModuleConnection connection in element.FeedbackConnections)
               {
                  if (connection != null)
                  {
                     if (this.SensorModules.ContainsKey(connection.DecoderID))
                     {
                        connection.Decoder = this.SensorModules[connection.DecoderID];
                     }
                     else
                     {
                        Logger.LogWarning(this,
                                          "Sensor module #{0} not found for connection #{1}.",
                                          connection.DecoderID, connection.ID);
                     }
                  }
               }
            }

            // Load routes
            foreach (Route route in OTCContext.Layout.RouteManager.GetAll())
            {
               this.Routes.Add(route.ID, route);
            }

            // Register element events
            foreach (ElementBase element in this.Elements.Values)
            {
               if (ElementBase.IsAccessoryElement(element))
               {
                  ((IAccessory)element).AccessoryStatusChanged += OnAccessoryStatusChanged;
               }
               if (ElementBase.IsFeedbackElement(element))
               {
                  ((IFeedback)element).FeedbackStatusChanged += OnFeedbackStatusChanged;
               }
               element.ImageChanged += OnBlockImageChanged;
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      /// <summary>
      /// Unload the project layout.
      /// </summary>
      public void UnloadLayout()
      {
         // Un-register element events
         foreach (ElementBase element in this.Elements.Values)
         {
            if (ElementBase.IsAccessoryElement(element))
            {
               ((IAccessory)element).AccessoryStatusChanged -= OnAccessoryStatusChanged;
            }
            if (ElementBase.IsFeedbackElement(element))
            {
               ((IFeedback)element).FeedbackStatusChanged -= OnFeedbackStatusChanged;
            }
            element.ImageChanged -= OnBlockImageChanged;
         }

         // Initializations
         this.Panels = new Dictionary<int, SwitchboardPanel>();
         this.AccessoryModules = new Dictionary<int, ControlModule>();
         this.SensorModules = new Dictionary<int, ControlModule>();
         this.Elements = new Dictionary<int, ElementBase>();
      }

      /// <summary>
      /// Activate the specified route.
      /// </summary>
      /// <param name="route">Route to activate.</param>
      public void ActivateRoute(Route route)
      {
         // Check parameters
         if (route == null)
         {
            this.ActiveRoute = null;
            return;
         }

         // Deactivate active routes
         //if (this.ActiveRoute != null)
         //{
         //   this.ClearRoutes();
         //}

         // Set the active route
         this.ActiveRoute = route;

         foreach (SwitchboardPanel panel in this.Panels.Values)
         {
            foreach (ElementBase element in panel.Elements)
            {
               if (ElementBase.IsRoutableElement(element))
               {
                  ((IRoutable)element).SetInRoute(false);

                  foreach (RouteElement routeElem in this.ActiveRoute.Elements)
                  {
                     if (routeElem.ElementID == element.ID)
                     {
                        ((IRoutable)element).SetInRoute(true);

                        if (ElementBase.IsAccessoryElement(element))
                        {
                           ((IAccessory)element).SetAccessoryStatus(routeElem.AccessoryStatus, true);
                        }

                        break;
                     }
                  }
               }
            }
         }
      }

      /// <summary>
      /// Clear all active routes.
      /// </summary>
      public void ClearRoutes()
      {
         foreach (SwitchboardPanel panel in this.Panels.Values)
         {
            foreach (ElementBase element in panel.Elements)
            {
               if (ElementBase.IsRoutableElement(element))
               {
                  ((IRoutable)element).SetInRoute(false);
               }
            }
         }
      }

      #endregion

      #region Events

      /// <summary>
      /// Event raised when the accessory status of a element is changed.
      /// </summary>
      public event EventHandler<AccessoryEventArgs> AccessoryStatusChanged;

      /// <summary>
      /// HaNDLER FOR THE <c>AccessoryStatusChanged</c> EVENT.
      /// </summary>
      /// <param name="sender">Sender (element).</param>
      /// <param name="e">Event arguments.</param>
      protected virtual void OnAccessoryStatusChanged(object sender, AccessoryEventArgs e)
      {
         if (this.AccessoryStatusChanged != null)
         {
            this.AccessoryStatusChanged(sender, e);
         }
      }

      /// <summary>
      /// An event raised when the feedback status of a element is changed.
      /// </summary>
      public event EventHandler<FeedbackEventArgs> FeedbackStatusChanged;

      /// <summary>
      /// HaNDLER FOR THE <c>AccessoryStatusChanged</c> EVENT.
      /// </summary>
      /// <param name="sender">Sender (element).</param>
      /// <param name="e">Event arguments.</param>
      protected virtual void OnFeedbackStatusChanged(object sender, FeedbackEventArgs e)
      {
         if (this.FeedbackStatusChanged != null)
         {
            this.FeedbackStatusChanged(sender, e);
         }
      }

      /// <summary>
      /// An event raised when the element needs to change his status.
      /// </summary>
      public event EventHandler<ElementEventArgs> BlockImageChanged;

      /// <summary>
      /// Handler for the event <c>BlockImageChanged</c>.
      /// </summary>
      /// <param name="sender">Sender (element).</param>
      /// <param name="e">Event arguments.</param>
      protected virtual void OnBlockImageChanged(object sender, ElementEventArgs e)
      {
         if (this.BlockImageChanged != null)
         {
            this.BlockImageChanged(sender, e);
         }
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.Filename = string.Empty;
         this.Name = string.Empty;
         this.Description = string.Empty;
         this.Version = "1.0";
         this.ActiveRoute = null;
         this.Panels = new Dictionary<int, SwitchboardPanel>();
         this.AccessoryModules = new Dictionary<int, ControlModule>();
         this.SensorModules = new Dictionary<int, ControlModule>();
         this.Elements = new Dictionary<int, ElementBase>();
         this.Routes = new Dictionary<int, Route>();
      }

      /// <summary>
      /// Ensure that the database have the schema 1.0 applied.
      /// </summary>
      private void Update_V1_0()
      {
         string sql = string.Empty;

         sql = @"CREATE TABLE " + SwitchboardPanelManager.SQL_TABLE + @" (
                     id             integer primary key autoincrement,
                     name           text NOT NULL,
                     description    text,
                     with           integer,
                     height         integer)";

         ExecuteNonQuery(sql);

         sql = @"CREATE TABLE " + ElementManager.SQL_TABLE + @" (
                     id             integer  primary key autoincrement,
                     panelid        integer  NOT NULL,
                     name           text,
                     x              integer  NOT NULL,
                     y              integer  NOT NULL,
                     rotation       integer,
                     type           integer,
                     status         integer  DEFAULT 0)";

         ExecuteNonQuery(sql);

         sql = @"CREATE TABLE " + ControlModuleManager.SQL_TABLE + @" (
                     id             integer primary key autoincrement,
                     name           text     NOT NULL,
                     manufacturer   text,
                     model          text,
                     outputs        integer,
                     startaddress   integer,
                     type           integer,
                     description    text)";

         ExecuteNonQuery(sql);

         sql = @"CREATE TABLE " + ControlModuleConnectionManager.SQL_TABLE + @" (
                     id             integer primary key autoincrement,
                     decoderid      integer,
                     blockid        integer,
                     name           text,
                     address        integer,
                     switchtime     integer,
                     out1           integer,
                     out2           integer)";

         ExecuteNonQuery(sql);

         this.SetProperty(Project.SETTING_KEY_DB_SCHEMAVER, Project.DB_VERSION_1_0);
      }

      /// <summary>
      /// Ensure that the database have the schema 1.1 applied.
      /// </summary>
      private void Update_V1_1()
      {
         string sql = string.Empty;

         sql = @"CREATE TABLE routes (
                     id             integer primary key autoincrement,
                     panelid        integer,
                     name           text NOT NULL,
                     description    text)";

         ExecuteNonQuery(sql);

         sql = @"CREATE TABLE routeblocks (
                     id             integer primary key autoincrement,
                     routeid        integer NOT NULL,
                     blockid        integer NOT NULL,
                     status         integer NOT NULL)";

         ExecuteNonQuery(sql);

         sql = @"CREATE TABLE sensormodules (
                     id             integer primary key autoincrement,
                     name           text     NOT NULL,
                     manufacturer   text,
                     model          text,
                     outputs        integer,
                     startaddress   integer,
                     type           integer,
                     description    text)";

         ExecuteNonQuery(sql);

         sql = @"CREATE TABLE sensoroutputs (
                     id             integer primary key autoincrement,
                     moduleid       integer  NOT NULL,
                     blockid        integer  NOT NULL,
                     name           text     NOT NULL,
                     address        integer)";

         ExecuteNonQuery(sql);

         this.SetProperty(Project.SETTING_KEY_DB_SCHEMAVER, Project.DB_VERSION_1_1);

         return;
      }

      #endregion

   }
}
