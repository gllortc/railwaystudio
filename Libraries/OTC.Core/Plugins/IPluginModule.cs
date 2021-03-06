﻿namespace Rwm.Otc.Plugins
{
   public interface IPluginModule
   {

      /// <summary>
      /// Gets an image that represents the large icon for the module.
      /// </summary>
      System.Drawing.Image LargeIcon { get; }

      /// <summary>
      /// Gets an image that represents the small icon for the module.
      /// </summary>
      System.Drawing.Image SmallIcon { get; }

      /// <summary>
      /// Gets the unique identifier for the plugin module.
      /// </summary>
      string ModuleID { get; }

      /// <summary>
      /// Gets the current application settings.
      /// </summary>
      Rwm.Otc.Configuration.XmlSettingsManager Settings { get; }

      /// <summary>
      /// Gets the name of the module.
      /// </summary>
      string ModuleName { get; }

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

      /// <summary>
      /// Initialize the contents of the module.
      /// </summary>
      /// <param name="context">The application container context.</param>
      void Initialize(IPluginContainer context);

      /// <summary>
      /// Add dockable panels to environment.
      /// </summary>
      void CreatePanels();

      /// <summary>
      /// Remove all dockable panels created when the module was loaded.
      /// </summary>
      void DestoryPanels();

   }
}
