using System;
using System.Collections.Generic;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Rwm.Otc.Systems;
using Rwm.Otc.Themes;
using static Rwm.Otc.Data.ORMForeignCollection;

namespace Rwm.Otc
{
   /// <summary>
   /// Project containing all OTC etities included.
   /// </summary>
   [ORMTable("PROJECTS")]
   public class Project : ORMEntity<Project>
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

      // Settings keys
      private const string SETTING_KEY_ACTIONS_EXECUTE = "rwm.ctrl.actions.execute";
      private const string SETTING_KEY_SENSOR_MANUAL = "rwm.ctrl.sensors.manual-activation";

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Project"/>.
      /// </summary>
      /// <param name="filename">Filename (and path) to file.</param>
      public Project() : base()
      {
         //   // Store the current project filename
         //   this.Filename = filename;

         //   // Load main project
         //   this.LayoutManager.ProjectDAO.Get(this);

         //   // Load all entities
         // this.LoadLayout();
         //   this.LoadSystem();
         //   this.LoadTheme();
      }

      #endregion

      #region Fields

      private SystemManager pSystems = null;
      private ThemeManager pThemeManager = null;

      #endregion

      #region Properties

      /// <summary>
      /// Gets the current presentation theme.
      /// </summary>
      public ITheme Theme { get; private set; }

      /// <summary>
      /// Gets the active digital system.
      /// </summary>
      public IDigitalSystem DigitalSystem { get; private set; }

      /// <summary>
      /// Gets the manager for the themes.
      /// </summary>
      public ThemeManager ThemeManager
      {
         get
         {
            if (this.pThemeManager == null) this.pThemeManager = new ThemeManager(OTCContext.Settings);
            return this.pThemeManager;
         }
      }

      /// <summary>
      /// Gets the manager for the digital systems.
      /// </summary>
      public SystemManager SystemManager
      {
         get
         {
            if (this.pSystems == null) this.pSystems = new SystemManager(OTCContext.Settings);
            return this.pSystems;
         }
      }

      /// <summary>
      /// Gets or sets the filename (and path) for the project file.
      /// </summary>
      public string Filename { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; } = 0;

      /// <summary>
      /// Gets or sets the project name.
      /// </summary>
      [ORMProperty("NAME")]
      public string Name { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets the project description.
      /// </summary>
      [ORMProperty("DESCRIPTION")]
      public string Description { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets the project version.
      /// </summary>
      [ORMProperty("VERSION")]
      public string Version { get; set; } = "1.0";

      /// <summary>
      /// Gets the switchboard list inlcuded in the project.
      /// </summary>
      [ORMForeignCollection(OnDeleteActionTypes.NoAction)]
      public List<Switchboard> Switchboards { get; private set; } = null;

      /// <summary>
      /// Gets the accessory decoders used in the project.
      /// </summary>
      [ORMForeignCollection(OnDeleteActionTypes.DeleteInCascade)]
      public List<AccessoryDecoder> AccessoryDecoders { get; private set; } = null;

      /// <summary>
      /// Gets the feedback decoders used in the project.
      /// </summary>
      [ORMForeignCollection(OnDeleteActionTypes.DeleteInCascade)]
      public List<FeedbackEncoder> FeedbackEncoders { get; private set; } = null;

      /// <summary>
      /// Gets all routes in the project.
      /// </summary>
      [ORMForeignCollection(OnDeleteActionTypes.DeleteInCascade)]
      public List<Route> Routes { get; private set; } = null;

      /// <summary>
      /// Gets all sounds in the project.
      /// </summary>
      [ORMForeignCollection(OnDeleteActionTypes.DeleteInCascade)]
      public List<Sound> Sounds { get; private set; } = null;

      /// <summary>
      /// Gets the layout sections list.
      /// </summary>
      [ORMForeignCollection(OnDeleteActionTypes.NoAction)]
      public List<Section> Sections { get; private set; } = null;

      /// <summary>
      /// Gets a value indicating if layout areas are in use in the current project.
      /// </summary>
      public bool IsUsingSections
      {
         get
         {
            if (this.Sections.Count > 0)
            {
               foreach (AccessoryDecoder decoder in this.AccessoryDecoders)
                  if (decoder.Section != null)
                     return true;

               foreach (FeedbackEncoder encoder in this.FeedbackEncoders)
                  if (encoder.Section != null)
                     return true;
            }

            return false;
         }
      }

      /// <summary>
      /// Gets the active routes in current project.
      /// </summary>
      public Dictionary<long, Route> ActiveRoutes { get; private set; } = new Dictionary<long, Route>();

      /// <summary>
      /// Gets or sets a value indicating if the actions must be disabled or not.
      /// </summary>
      public bool ExecuteBlockActions
      {
         get { return OTCContext.Settings.GetBoolean(Project.SETTING_KEY_ACTIONS_EXECUTE, true); }
         set { OTCContext.Settings.AddSetting(Project.SETTING_KEY_ACTIONS_EXECUTE, value); }
      }

      /// <summary>
      /// Gets or sets a value indicating if sensors could be manually activated or not.
      /// </summary>
      public bool AllowManualSensorActivation
      {
         get { return OTCContext.Settings.GetBoolean(Project.SETTING_KEY_SENSOR_MANUAL, true); }
         set { OTCContext.Settings.AddSetting(Project.SETTING_KEY_SENSOR_MANUAL, value); }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Load the digital system to use.
      /// </summary>
      internal void LoadSystem()
      {
         Logger.LogDebug(this, "[CLASS].LoadSystem()");

         try
         {
            this.DigitalSystem = this.SystemManager.GetSystem();

            // If no system is configured, load the test system
            if (this.DigitalSystem == null)
            {
               this.DigitalSystem = new Systems.Dummy.DummySystem();
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      /// <summary>
      /// Load the digital system to use.
      /// </summary>
      internal void LoadTheme()
      {
         Logger.LogDebug(this, "[CLASS].LoadTheme()");

         try
         {
            this.Theme = this.ThemeManager.GetTheme();

            // If no system is configured, load the test system
            if (this.Theme == null)
            {
               // this.DigitalSystem = new Rwm.OTC.Systems.TestSystem();
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      /// <summary>
      /// Get all destination blocks from the specified block.
      /// </summary>
      /// <param name="fromElement">Source block element.</param>
      /// <returns>The requested list of destination block elements.</returns>
      public List<Route> GetDestinations(Element fromElement)
      {
         Logger.LogDebug(this, "[CLASS].GetDestinations([{0}])", fromElement);

         List<Route> routes = new List<Route>();

         foreach (Route route in this.Routes)
         {
            if (route.FromBlock != null && route.FromBlock.ID == fromElement.ID)
            {
               routes.Add(route);
            }
            else if (route.IsBidirectionl && (route.ToBlock != null && route.ToBlock.ID == fromElement.ID))
            {
               routes.Add(route);
            }
         }

         return routes;
      }

      /// <summary>
      /// Force to raise the event <c>OnElementImageChanged</c>. Used by <see cref="Element"/> instances.
      /// </summary>
      /// <param name="element"><see cref="Element"/> that should be repainted.</param>
      public void ElementImageChanged(Element element)
      {
         this.OnElementImageChanged?.Invoke(element, new ElementEventArgs(element));
      }

      ///// <summary>
      ///// Force to raise the event <c>OnAccessoryStatusChanged</c>. Used by <see cref="Element"/> instances.
      ///// </summary>
      ///// <param name="element"><see cref="Element"/> that have been changed.</param>
      //public void AccessoryStatusChanged(Element element)
      //{
      //   this.OnAccessoryStatusChanged?.Invoke(element, new AccessoryEventArgs(element.AccessoryStatus));
      //}

      ///// <summary>
      ///// Force to raise the event <see cref="Project.OnFeedbackStatusChanged"/>. Used by <see cref="Element"/> instances.
      ///// </summary>
      //public void FeedbackStatusChanged(Element element)
      //{
      //   this.OnFeedbackStatusChanged?.Invoke(element, new FeedbackEventArgs(element.FeedbackStatus));
      //}

      ///// <summary>
      ///// Handler for the <c>AccessoryStatusChanged</c> event.
      ///// </summary>
      //void DigitalSystemInfo(MessageType type, string message, params object[] args)
      //{
      //   this.OnDigitalSystemInfo?.Invoke(OTCContext.Project.DigitalSystem, new SystemConsoleEventArgs(type, message, args));
      //}

      #endregion

      #region Events

      /// <summary>
      /// Event raised when an <see cref="Element"/> should be repainted.
      /// </summary>
      public event OnElementImageChangedEventHandler OnElementImageChanged;

      /// <summary>
      /// Delegate for the event <see cref="OnElementImageChanged"/>.
      /// </summary>
      public delegate void OnElementImageChangedEventHandler(object sender, ElementEventArgs e);

      ///// <summary>
      ///// Event raised when an <see cref="Element"/> should be repainted.
      ///// </summary>
      //public event OnAccessoryStatusChangedEventHandler OnAccessoryStatusChanged;

      ///// <summary>
      ///// Delegate for the event <see cref="OnAccessoryStatusChanged"/>.
      ///// </summary>
      //public delegate void OnAccessoryStatusChangedEventHandler(object sender, AccessoryEventArgs e);

      ///// <summary>
      ///// Event raised when an <see cref="Element"/> should be repainted.
      ///// </summary>
      //public event OnFeedbackStatusChangedEventHandler OnFeedbackStatusChanged;

      ///// <summary>
      ///// Delegate for the event <see cref="OnFeedbackStatusChanged"/>.
      ///// </summary>
      //public delegate void OnFeedbackStatusChangedEventHandler(object sender, FeedbackEventArgs e);

      ///// <summary>
      ///// Event raised when an <see cref="Element"/> should be repainted.
      ///// </summary>
      //public event EventHandler<SystemConsoleEventArgs> OnDigitalSystemInfo;

      #endregion

      #region Event Handlers

      ///// <summary>
      ///// Handle all feedback events received from the digital system.
      ///// </summary>
      //private void DigitalSystem_SensorStatusChanged(object sender, FeedbackEventArgs e)
      //{
      //   Element element = Element.GetByConnectionAddress(e.Address);

      //   // Check element
      //   if (element == null)
      //   {
      //      this.DigitalSystemInfo(MessageType.Warning, 
      //                             "Received feedback signal for address {0} output {1} (status: {2}) but is not assigned in current project. Signal discarded!",
      //                             e.Address, e.Output, e.NewStatus);
      //      return;
      //   }
      //   else if (!element.Properties.IsFeedback)
      //   {
      //      this.DigitalSystemInfo(MessageType.Warning,
      //                             "Received feedback signal for address {0} output {1} (status: {2}) but associated element not accepting feedback. Signal discarded!",
      //                             e.Address, e.Output, e.NewStatus);
      //      return;
      //   }

      //   // Change the feedback status
      //   element.SetFeedbackStatus(e.NewStatus);
      //}

      /// <summary>
      /// Handler for the event <c>OccupationChanged</c>.
      /// </summary>
      void Layout_OccupationChanged(object sender, OccupationEventArgs e)
      {
         if (e.IsOccupied)
         {
            e.Element.Train = e.Model;
            Element.Save(e.Element);
         }
         else
         {
            e.Element.Train = null;
            Element.Save(e.Element);
         }
      }

      #endregion

   }
}
