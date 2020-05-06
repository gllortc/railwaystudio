using System;

namespace Rwm.Studio.Plugins.Common
{
   public interface IPluginModuleDescriptor
   {

      #region Properties

      /// <summary>
      /// Gets the unique identifier for the plugin module.
      /// </summary>
      string ID { get; }

      /// <summary>
      /// Gets the name of the module.
      /// </summary>
      string Caption { get; }

      /// <summary>
      /// Gets an image that represents the large icon for the module.
      /// </summary>
      System.Drawing.Image LargeIcon { get; }

      /// <summary>
      /// Gets an image that represents the small icon for the module.
      /// </summary>
      System.Drawing.Image SmallIcon { get; }

      #endregion

      #region Methods

      /// <summary>
      /// return the <see cref="Type"/> corresponding to the plug-in module.
      /// </summary>
      /// <returns></returns>
      Type GetPluginModuleType();

      #endregion

   }
}
