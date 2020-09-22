using System;
using System.Drawing;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Control.Modules
{
   public class ControlModuleDescriptor : IPluginModuleDescriptor
   {

      #region Constants

      internal const string MODULE_GUID = "DF6D5AB9-D3BF-4A8A-9B55-C8B9BB9DA035";

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
         get { return "Layout Control"; }
      }

      /// <summary>
      /// Gets an image that represents the large icon for the module.
      /// </summary>
      public Image LargeIcon
      {
         get { return Properties.Resources.ICO_MODULE_CONTROL_32; }
      }

      /// <summary>
      /// Gets an image that represents the small icon for the module.
      /// </summary>
      public Image SmallIcon
      {
         get { return Properties.Resources.ICO_APP_16; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// return the <see cref="Type"/> corresponding to the plug-in module.
      /// </summary>
      /// <returns></returns>
      public Type GetPluginModuleType()
      {
         return typeof(ControlModule);
      }

      #endregion

   }
}
