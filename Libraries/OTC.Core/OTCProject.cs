using Rwm.Otc.Configuration;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Rwm.Otc.Layout.Actions;
using Rwm.Otc.Layout.Elements;
using Rwm.Otc.Systems;
using Rwm.Otc.Themes;
using Rwm.OTC.Systems;
using System;
using System.Collections.Generic;

namespace Rwm.Otc
{
   /// <summary>
   /// Offers a unique context for OTC framework operation.
   /// </summary>
   public static class OTCProject
   {

      #region Constants

      /// <summary>Database current version.</summary>
      public const string SETTING_KEY_DB_SCHEMAVER = "collection.db.version";

      /// <summary>Database version 1.0</summary>
      public const string DB_VERSION_1_0 = "1.0";
      /// <summary>Database version 1.1</summary>
      public const string DB_VERSION_1_1 = "1.1";

      /// <summary>Database current version.</summary>
      public const string DB_CURRENT_VERSION = DB_VERSION_1_1;

      #endregion

      #region Constructors

      /// <summary>
      /// Initialize the OTC context.
      /// </summary>
      /// <param name="filename">Filename (and path) to file.</param>
      public static void Initialize(string filename)
      {
         OTCProject.Initialize();
         OTCProject.OpenProject(filename);
      }

      /// <summary>
      /// Initialize the OTC context.
      /// </summary>
      public static void Initialize()
      {
         OTCProject.ID = 0;
         OTCProject.Filename = string.Empty;
         OTCProject.Name = string.Empty;
         OTCProject.Description = string.Empty;
         OTCProject.Version = "1.0";
         OTCProject.ActiveRoute = null;
         OTCProject.Switchboards = new ItemCollection<Switchboard>();
         OTCProject.Elements = new ElementCollection();
         OTCProject.ElementActions = new ItemCollection<ElementAction>();
         OTCProject.Devices = new ItemCollection<Device>();
         OTCProject.DeviceConnections = new ItemCollection<DeviceConnection>();
         OTCProject.Routes = new ItemCollection<Route>();
         OTCProject.RouteElements = new ItemCollection<RouteElement>();
         OTCProject.Sounds = new ItemCollection<Sound>();

         // Load settings
         OTCProject.Settings = new XmlSettingsManager();
         OTCProject.Settings.LoadSettings();

         // Load theme
         OTCProject.Theme = OTCProject.ThemeManager.GetTheme();
         if (OTCProject.Theme == null)
         {
            // Create the default theme
            // OTCContext.Theme = new Rwm.Otc.Themes.Theme();
         }

         // Load digital system
         OTCProject.DigitalSystem = OTCProject.SystemManager.GetSystem();
         if (OTCProject.DigitalSystem == null)
         {
            // Create the test system
            OTCProject.DigitalSystem = new TestSystem();
         }
      }

      #endregion

      #region Fields

      private static TrainManager pTrains = null;
      private static LayoutManager pLayout = null;
      private static SystemManager pSystems = null;
      private static ThemeManager pThemeManager = null;

      #endregion

      #region Properties

      /// <summary>
      /// Gets the current application settings.
      /// </summary>
      public static XmlSettingsManager Settings { get; private set; }

      /// <summary>
      /// Gets the current presentation theme.
      /// </summary>
      public static ITheme Theme { get; private set; }

      /// <summary>
      /// Gets the active digital system.
      /// </summary>
      public static IDigitalSystem DigitalSystem { get; private set; }

      /// <summary>
      /// Gets the manager for the layout.
      /// </summary>
      public static LayoutManager LayoutManager
      {
         get
         {
            if (OTCProject.pLayout == null)
            {
               OTCProject.pLayout = new Otc.LayoutManager(OTCProject);
            }

            return OTCProject.pLayout;
         }
      }

      /// <summary>
      /// Gets the manager for the train collection.
      /// </summary>
      public static TrainManager TrainManager
      {
         get
         {
            if (OTCProject.pTrains == null)
            {
               OTCProject.pTrains = new Otc.TrainManager();
            }

            return OTCProject.pTrains;
         }
      }

      /// <summary>
      /// Gets the manager for the themes.
      /// </summary>
      public static ThemeManager ThemeManager
      {
         get
         {
            if (OTCProject.pThemeManager == null)
            {
               OTCProject.pThemeManager = new ThemeManager(OTCProject.Settings);
            }

            return OTCProject.pThemeManager;
         }
      }

      /// <summary>
      /// Gets the manager for the digital systems.
      /// </summary>
      public static SystemManager SystemManager
      {
         get
         {
            if (OTCProject.pSystems == null)
            {
               OTCProject.pSystems = new SystemManager(OTCProject.Settings);
            }

            return OTCProject.pSystems;
         }
      }

      /// <summary>
      /// Gets or sets the project unique identifier (DB).
      /// </summary>
      public long ID { get; set; }

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
      /// Gets the switchboard list inlcuded in the project.
      /// </summary>
      public ItemCollection<Switchboard> Switchboards { get; private set; }

      /// <summary>
      /// Gets the elements list inlcuded in the project.
      /// </summary>
      public ElementCollection Elements { get; private set; }

      /// <summary>
      /// Gets the element actions list inlcuded in the project.
      /// </summary>
      public ItemCollection<ElementAction> ElementActions { get; private set; }

      /// <summary>
      /// Gets the control modules included in the project.
      /// </summary>
      public ItemCollection<Device> Devices { get; private set; }

      /// <summary>
      /// Gets the device connections included in the project.
      /// </summary>
      public ItemCollection<DeviceConnection> DeviceConnections { get; private set; }

      /// <summary>
      /// Gets all routes in the project.
      /// </summary>
      public ItemCollection<Route> Routes { get; private set; }

      /// <summary>
      /// Gets all routes in the project.
      /// </summary>
      public ItemCollection<RouteElement> RouteElements { get; private set; }

      /// <summary>
      /// Gets all sounds in the project.
      /// </summary>
      public ItemCollection<Sound> Sounds { get; private set; }

      /// <summary>
      /// Grets the active route in the layout.
      /// </summary>
      internal Route ActiveRoute { get; private set; }

      #endregion

      #region Methods

      /// <summary>
      /// Create new OTC layout project.
      /// </summary>
      /// <param name="path">Filename (and path) for the new project file.</param>
      /// <param name="project">Initialized project (only with basic data).</param>
      public static void CreateProject(string path, Project project)
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
            // Create new project file
            OTCProject.Project = project;
            OTCProject.Filename = path;

            // Create database file
            System.Data.SQLite.SQLiteConnection.CreateFile(path);

            // Store the current database to the settings
            OTCProject.Settings.AddSetting(DataEntity.SETTINGS_DB_CURRENT, path);

            // Ensure that the database have the latest schema
            ControlDataEntity cde = new ControlDataEntity();
            cde.CheckDatabase();

            // Store the project into the database
            OTCProject.LayoutManager.ProjectDAO.Add(OTCProject.Project);
            OTCProject.Project.Filename = path;

            // Load the layout
            OTCProject.Project.LoadLayout();
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
            OTCProject.Settings.AddSetting(DataEntity.SETTINGS_DB_CURRENT, path);

            // Load the project data
            OTCProject.Project = OTCProject.LayoutManager.ProjectDAO.Get();
            if (OTCProject.Project == null) throw new Exception("Bad project file.");

            OTCProject.Project.Filename = path;

            // Load the layout
            OTCProject.Project.LoadLayout();
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
            OTCProject.LayoutManager.ProjectDAO.Update(OTCProject.Project);
         }
         catch (Exception ex)
         {
            Logger.LogError(ex);

            throw;
         }
      }

      /// <summary>
      /// Ensure that the database exists and have the latest schema.
      /// </summary>
      internal void LoadLayout()
      {
         try
         {
            // Initializations
            this.UnloadLayout();

            // Load all database objects
            this.Sounds.Add(OTCProject.LayoutManager.SoundDAO.GetAll());
            this.Devices.Add(OTCProject.LayoutManager.DeviceDAO.GetAll());
            this.DeviceConnections.Add(OTCProject.LayoutManager.DeviceConnectionDAO.GetAll());
            this.Switchboards.Add(OTCProject.LayoutManager.SwitchboardDAO.GetAll());
            this.Elements.Add(OTCProject.LayoutManager.ElementDAO.GetAll());
            this.ElementActions.Add(OTCProject.LayoutManager.ElementActionDAO.GetAll());
            this.Routes.Add(OTCProject.LayoutManager.RouteDAO.GetAll());

            // Load elements to switchboards
            foreach (ElementBase element in this.Elements)
            {
               element.Switchboard = this.Switchboards.Get(element.SwitchboardID);
               element.Switchboard.Project = this;
               element.Switchboard.Elements.Add(element);
            }

            // Load actions to elements
            foreach (ElementAction action in this.ElementActions)
            {
               action.Element = this.Elements.Get(action.ElementID);
               action.Element.Actions.Add(action);
            }

            // Load connections to accessory devices
            foreach (DeviceConnection conn in this.DeviceConnections)
            {
               conn.Decoder = this.Devices.Get(conn.DecoderID);
               conn.Element = this.Elements.Get(conn.ElementID);
               conn.Decoder.Connections.Add(conn);
            }

            // Load elements to routes
            foreach (RouteElement re in this.RouteElements)
            {
               re.Element = this.Elements.Get(re.ElementID);
               re.Route = this.Routes.Get(re.RouteID);
            }

            // Register element events
            foreach (ElementBase element in this.Elements)
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
         foreach (ElementBase element in this.Elements)
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
         //this.Panels = new Dictionary<int, Switchboard>();
         //this.AccessoryModules = new Dictionary<int, Device>();
         //this.SensorModules = new Dictionary<int, Device>();
         //this.Elements = new Dictionary<int, ElementBase>();
      }

      /// <summary>
      /// Adds a new item into the project.
      /// </summary>
      /// <param name="item">Item to add.</param>
      public void Add(Switchboard item)
      {
         try
         {
            // Create the new element into the DB
            OTCProject.LayoutManager.SwitchboardDAO.Add(item);

            // Add the new element into the in-memory project
            item.Project = this;
            this.Switchboards.Add(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Update an item into the project.
      /// </summary>
      /// <param name="item">Item to update.</param>
      public void Update(Switchboard item)
      {
         try
         {
            // Create the new element into the DB
            OTCProject.LayoutManager.SwitchboardDAO.Update(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Delete the specified item from the project.
      /// </summary>
      /// <param name="item">Item to remove.</param>
      public void Remove(Switchboard item)
      {
         try
         {
            // Create the new element into the DB
            OTCProject.LayoutManager.SwitchboardDAO.Delete(item.ID);

            // Add the new element into the in-memory project
            this.Switchboards.Remove(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Adds a new item into the project.
      /// </summary>
      /// <param name="item">Item to add.</param>
      public void Add(ElementBase item)
      {
         try
         {
            // Create the new element into the DB
            OTCProject.LayoutManager.ElementDAO.Add(item);

            // Add the new element into the in-memory project
            item.Switchboard = this.Switchboards.Get(item.Switchboard.ID);
            item.Switchboard.Project = this;
            item.Switchboard.Elements.Add(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Update an item into the project.
      /// </summary>
      /// <param name="item">Item to update.</param>
      public void Update(ElementBase item)
      {
         try
         {
            // Create the new element into the DB
            OTCProject.LayoutManager.ElementDAO.Update(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Delete the specified item from the project.
      /// </summary>
      /// <param name="item">Item to remove.</param>
      public void Remove(ElementBase item)
      {
         try
         {
            // Create the new element into the DB
            OTCProject.LayoutManager.ElementDAO.Delete(item.ID);

            // Add the new element into the in-memory project
            this.Elements.Remove(item);
            item.Switchboard.Elements.Remove(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Adds a new item into the project.
      /// </summary>
      /// <param name="item">Item to add.</param>
      public void Add(ElementAction item)
      {
         try
         {
            // Create the new element into the DB
            OTCProject.LayoutManager.ElementActionDAO.Add(item);

            // Add the new element into the in-memory project
            item.Element.Actions.Add(item);
            this.ElementActions.Add(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Update an item into the project.
      /// </summary>
      /// <param name="item">Item to update.</param>
      public void Update(ElementAction item)
      {
         try
         {
            // Create the new element into the DB
            OTCProject.LayoutManager.ElementActionDAO.Update(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Delete the specified item from the project.
      /// </summary>
      /// <param name="item">Item to remove.</param>
      public void Remove(ElementAction item)
      {
         try
         {
            // Create the new element into the DB
            OTCProject.LayoutManager.ElementActionDAO.Delete(item.ID);

            // Add the new element into the in-memory project
            item.Element.Actions.Remove(item);
            this.ElementActions.Add(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Adds a new item into the project.
      /// </summary>
      /// <param name="item">Item to add.</param>
      public void Add(Device item)
      {
         try
         {
            // Create the new item into the DB
            OTCProject.LayoutManager.DeviceDAO.Add(item);

            // Add the new item into the in-memory project
            this.Devices.Add(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Update an item into the project.
      /// </summary>
      /// <param name="item">Item to update.</param>
      public void Update(Device item)
      {
         try
         {
            // Create the new item into the DB
            OTCProject.LayoutManager.DeviceDAO.Update(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Delete the specified item from the project.
      /// </summary>
      /// <param name="item">Item to remove.</param>
      public void Remove(Device item)
      {
         try
         {
            // Create the new element into the DB
            OTCProject.LayoutManager.DeviceDAO.Delete(item.ID);

            // Add the new element into the in-memory project
            this.Devices.Remove(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Adds a new item into the project.
      /// </summary>
      /// <param name="item">Item to add.</param>
      public void Add(Route item)
      {
         try
         {
            // Create the new item into the DB
            OTCProject.LayoutManager.RouteDAO.Add(item);

            // Add the new item into the in-memory project
            this.Routes.Add(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Update an item into the project.
      /// </summary>
      /// <param name="item">Item to update.</param>
      public void Update(Route item)
      {
         try
         {
            // Create the new item into the DB
            OTCProject.LayoutManager.RouteDAO.Update(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Delete the specified item from the project.
      /// </summary>
      /// <param name="item">Item to remove.</param>
      public void Remove(Route item)
      {
         try
         {
            // Create the new element into the DB
            OTCProject.LayoutManager.RouteDAO.Delete(item.ID);

            // Add the new element into the in-memory project
            this.Routes.Remove(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Adds a new item into the project.
      /// </summary>
      /// <param name="item">Item to add.</param>
      public void Add(RouteElement item)
      {
         try
         {
            // Create the new item into the DB
            OTCProject.LayoutManager.RouteElementDAO.Add(item);

            // Add the new item into the in-memory project
            this.RouteElements.Add(item);
            item.Route.Elements.Add(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Delete the specified item from the project.
      /// </summary>
      /// <param name="item">Item to remove.</param>
      public void Remove(RouteElement item)
      {
         try
         {
            // Create the new element into the DB
            OTCProject.LayoutManager.RouteElementDAO.Delete(item.ID);

            // Remove the element from the in-memory project
            item.Route.Elements.Remove(item);
            this.RouteElements.Remove(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Adds a new item into the project.
      /// </summary>
      /// <param name="item">Item to add.</param>
      public void Add(Sound item)
      {
         try
         {
            // Create the new item into the DB
            OTCProject.LayoutManager.SoundDAO.Add(item);

            // Add the new item into the in-memory project
            this.Sounds.Add(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Update an item into the project.
      /// </summary>
      /// <param name="item">Item to update.</param>
      public void Update(Sound item)
      {
         try
         {
            // Create the new item into the DB
            OTCProject.LayoutManager.SoundDAO.Update(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      /// <summary>
      /// Delete the specified item from the project.
      /// </summary>
      /// <param name="item">Item to remove.</param>
      public void Remove(Sound item)
      {
         try
         {
            // Create the new element into the DB
            OTCProject.LayoutManager.SoundDAO.Delete(item.ID);

            // Add the new element into the in-memory project
            this.Sounds.Remove(item);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
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

         foreach (Switchboard panel in this.Switchboards)
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
         foreach (Switchboard panel in this.Switchboards)
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

      /// <summary>
      /// Gets all connections using the same digital address.
      /// </summary>
      /// <param name="address">Digital address.</param>
      /// <returns>The requested list of <see cref="DeviceConnection"/> related to the specified address.</returns>
      public List<DeviceConnection> GetDuplicatedDeviceConnections(int address)
      {
         return OTCProject.LayoutManager.DeviceConnectionDAO.GetDuplicated();
      }

      /// <summary>
      /// Update the specified connection.
      /// </summary>
      /// <param name="connection">Device connection.</param>
      /// <param name="connectionIndex">Index of the connection in the control.</param>
      /// <param name="element">Element unique identifier (DB).</param>
      public void AssignDeviceConnection(DeviceConnection connection, int connectionIndex, IAccessory element)
      {
         OTCProject.LayoutManager.DeviceConnectionDAO.Assign(connection.ID, connectionIndex, element);
      }

      /// <summary>
      /// Update the specified connection.
      /// </summary>
      /// <param name="connection">Device connection.</param>
      public void UnassignDeviceConnection(DeviceConnection connection)
      {
         OTCProject.LayoutManager.DeviceConnectionDAO.Unassign(connection.ID);
      }

      /// <summary>
      /// Get all control devices.
      /// </summary>
      /// <returns>An instance of <see cref="System.Data.DataTable"/> filled with all data.</returns>
      public System.Data.DataTable FindDevices()
      {
         return OTCProject.LayoutManager.DeviceDAO.Find();
      }

      /// <summary>
      /// Get all routes.
      /// </summary>
      /// <returns>The requested <see cref="System.Data.DataTable"/> filled with information.</returns>
      public System.Data.DataTable FindRoutes()
      {
         return OTCProject.LayoutManager.RouteDAO.Find();
      }

      /// <summary>
      /// Gets all sounds.
      /// </summary>
      /// <returns>The requested instance of <see cref="System.Data.DataTable"/>.</returns>
      public System.Data.DataTable FindSounds()
      {
         return OTCProject.LayoutManager.SoundDAO.Find();
      }

      /// <summary>
      /// Gets all actions related to an element.
      /// </summary>
      /// <param name="element">Element.</param>
      /// <returns>The requested list in a <see cref="System.Data.DataTable"/>.</returns>
      public System.Data.DataTable FindElementConnections(ElementBase element)
      {
         return OTCProject.LayoutManager.ElementActionDAO.FindByElement(element.ID);
      }

      /// <summary>
      /// Get all connections of the specified module.
      /// </summary>
      /// <param name="device">Control device.</param>
      /// <returns>A <see cref="System.Data.DataTable"/> filled with the requested information.</returns>
      public System.Data.DataTable FindDeviceConnections(Device device)
      {
         return OTCProject.LayoutManager.DeviceConnectionDAO.FindByDevice(device);
      }

      /// <summary>
      /// Get a list of all decoder manufacturers.
      /// </summary>
      /// <returns>A list of <see cref="String"/> filled with the requested data.</returns>
      public List<string> GetDeviceManufacturers()
      {
         return OTCProject.LayoutManager.DeviceDAO.GetAllManufacturers();
      }

      /// <summary>
      /// Get a list of all decoder models.
      /// </summary>
      /// <returns>A list of <see cref="String"/> filled with the requested data.</returns>
      public List<string> GetDeviceModels()
      {
         return OTCProject.LayoutManager.DeviceDAO.GetAllModels();
      }

      ///// <summary>
      ///// Gets a device.
      ///// </summary>
      ///// <param name="deviceId">Device unique identifier.</param>
      ///// <returns>The requested instance of <see cref="Device"/>.</returns>
      //public Device GetDevice(int deviceId)
      //{
      //   Device device = null;

      //   device = this.AccessoryDevices.Get(deviceId);
      //   if (device != null) return device;
      //   return this.SensorModules.Get(deviceId);
      //}

      /// <summary>
      /// Gets all connections for the specified element.
      /// </summary>
      /// <param name="element">Element.</param>
      /// <returns>The requested list of <see cref="DeviceConnection"/> related to the specified element.</returns>
      public DeviceConnection[] GetDeviceConnections(ElementBase element)
      {
         return this.GetDeviceConnections(element, Device.DeviceType.Undefined);
      }

      /// <summary>
      /// Gets connections of the specified type for the specified element.
      /// </summary>
      /// <param name="element">Element.</param>
      /// <param name="type">Type of element.</param>
      /// <returns>The requested list of <see cref="DeviceConnection"/> related to the specified element.</returns>
      public DeviceConnection[] GetDeviceConnections(ElementBase element, Device.DeviceType type)
      {
         return OTCProject.LayoutManager.DeviceConnectionDAO.GetByElement(element, type);
      }

      /// <summary>
      /// Gets all connection in a device.
      /// </summary>
      /// <param name="device">Device.</param>
      /// <returns>The requested list of <see cref="DeviceConnection"/>.</returns>
      public List<DeviceConnection> GetDeviceConnections(Device device)
      {
         return OTCProject.LayoutManager.DeviceConnectionDAO.GetByDevice(device.ID);
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

   }
}
