using System;
using System.Drawing;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Designer.Modules
{
   public class RouteModuleDescriptor : IPluginModuleDescriptor
   {

      #region Constants

      internal const string MODULE_GUID = "6269D397-85FB-45A8-8FB5-EECD59640B29";

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
         get { return "Route designer"; }
      }

      /// <summary>
      /// Gets an image that represents the large icon for the module.
      /// </summary>
      public Image LargeIcon
      {
         get { return Properties.Resources.ICO_MODULE_ROUTES_32; }
      }

      /// <summary>
      /// Gets an image that represents the small icon for the module.
      /// </summary>
      public Image SmallIcon
      {
         get { return Otc.Layout.Route.SmallIcon; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// return the <see cref="Type"/> corresponding to the plug-in module.
      /// </summary>
      /// <returns></returns>
      public Type GetPluginModuleType()
      {
         return typeof(RouteModule);
      }

      #endregion

   }
}
