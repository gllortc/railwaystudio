using System;
using System.Drawing;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Designer.Modules
{
   public class DecoderManagerModuleDescriptor : IPluginModuleDescriptor
   {

      #region Constants

      internal const string MODULE_GUID = "88C317BD-5F4C-432D-9480-ACEEA15616F2";

      #endregion

      #region Properties

      /// <summary>
      /// Gets the unique identifier for the plugin module.
      /// </summary>
      public string ID
      {
         get { return MODULE_GUID; }
      }

      /// <summary>
      /// Gets the name of the module.
      /// </summary>
      public string Caption
      {
         get { return "Digital device manager"; }
      }

      /// <summary>
      /// Gets an image that represents the large icon for the module.
      /// </summary>
      public Image LargeIcon
      {
         get { return Properties.Resources.ICO_MODULE_DEVICE_MANAGER_32; }
      }

      /// <summary>
      /// Gets an image that represents the small icon for the module.
      /// </summary>
      public Image SmallIcon
      {
         get { return Properties.Resources.ICO_DEVICE_FOLDER_16; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// return the <see cref="Type"/> corresponding to the plug-in module.
      /// </summary>
      /// <returns></returns>
      public Type GetPluginModuleType()
      {
         return typeof(DecoderManagerModule);
      }

      #endregion

   }
}
