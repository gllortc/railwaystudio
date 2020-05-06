using System;
using System.Drawing;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Collection.Modules
{
   public class ExplorerModuleDescriptor : IPluginModuleDescriptor
   {

      #region Constants

      internal const string MODULE_GUID = "D1117691-F1AE-42C7-BF77-620E0361D711";

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
         get { return "Collection Explorer"; }
      }

      /// <summary>
      /// Gets an image that represents the large icon for the module.
      /// </summary>
      public Image LargeIcon
      {
         get { return Properties.Resources.ICO_APP_32; }
      }

      /// <summary>
      /// Gets an image that represents the small icon for the module.
      /// </summary>
      public Image SmallIcon
      {
         get { return Properties.Resources.ICO_DATAMANAGER_16; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// return the <see cref="Type"/> corresponding to the plug-in module.
      /// </summary>
      /// <returns></returns>
      public Type GetPluginModuleType()
      {
         return typeof(ExplorerModule);
      }

      #endregion

   }
}
