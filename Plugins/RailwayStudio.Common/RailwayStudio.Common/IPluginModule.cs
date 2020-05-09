namespace Rwm.Studio.Plugins.Common
{
   public interface IPluginModule // : IPluginModuleDescriptor
   {

      #region Properties

      ///// <summary>
      ///// Gets an image that represents the large icon for the module.
      ///// </summary>
      //System.Drawing.Image LargeIcon { get; }

      ///// <summary>
      ///// Gets an image that represents the small icon for the module.
      ///// </summary>
      //System.Drawing.Image SmallIcon { get; }

      ///// <summary>
      ///// Gets the unique identifier for the plugin module.
      ///// </summary>
      //string ID { get; }

      ///// <summary>
      ///// Gets the name of the module.
      ///// </summary>
      //string Caption { get; }

      /// <summary>
      /// Gets the plugin module description properties.
      /// </summary>
      IPluginModuleDescriptor Description { get; }

      /// <summary>
      /// Gets the name of the loaded document.
      /// </summary>
      string DocumentName { get; }

      /// <summary>
      /// Gets a value indicating if the module can be loaded multiple times.
      /// </summary>
      bool IsMultiInstance { get; }

      /// <summary>
      /// Gets a value indicating if the module use a project or it is an independent utility.
      /// </summary>
      bool UseProject { get; }

      /// <summary>
      /// Gets an instance of the startup ribbon page that must be shown when the plugin is active in studio
      /// or <c>null</c> if the default page must be shown.
      /// </summary>
      object StartupRibbonPage { get; }

      /// <summary>
      /// Gets an instance of the startup ribbon page that must be shown when the plugin is active in studio
      /// or <c>null</c> if the default page must be shown.
      /// </summary>
      object RibbonStatusBar { get; }

      #endregion

      #region Methods

      /// <summary>
      /// Initialize the contents of the module.
      /// </summary>
      /// <param name="context">The application container context.</param>
      void Initialize(params object[] args);

      #endregion

   }
}
