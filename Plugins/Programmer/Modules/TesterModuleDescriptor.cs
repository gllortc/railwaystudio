using System;
using System.Drawing;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Designer.Modules
{
   public class TesterModuleDescriptor : IPluginModuleDescriptor
   {

      #region Constants

      internal const string MODULE_GUID = "D5FDDE64-B577-4980-A9E6-146C80BC56E8";

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
         get { return "Layout Tester"; }
      }

      /// <summary>
      /// Gets an image that represents the large icon for the module.
      /// </summary>
      public Image LargeIcon
      {
         get { return Properties.Resources.ICO_MODULE_TESTER_32; }
      }

      /// <summary>
      /// Gets an image that represents the small icon for the module.
      /// </summary>
      public Image SmallIcon
      {
         get { return Properties.Resources.ICO_MODULE_TESTER_16; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// return the <see cref="Type"/> corresponding to the plug-in module.
      /// </summary>
      /// <returns></returns>
      public Type GetPluginModuleType()
      {
         return typeof(TesterModule);
      }

      #endregion

   }
}
