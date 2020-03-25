using Rwm.Otc.Utils;

namespace Rwm.Studio.Plugins.Collection
{
   public class PluginData : RailwayStudio.Common.IPluginPackage
   {

      #region Constants

      private const string PLUGIN_GUID = "094AAA89-8A8A-4FAC-A288-A8968F41AADD";

      #endregion

      #region IPlugin Implementation

      public string ID
      {
         get { return PLUGIN_GUID; }
      }

      public System.Drawing.Image SmallIcon
      {
         get { return Properties.Resources.ICO_APP_16; }
      }

      public System.Drawing.Image LargeIcon
      {
         get { return Properties.Resources.ICO_APP_32; }
      }

      public string Name
      {
         get { return "Collection"; }
      }

      public string Version
      {
         get { return ReflectionUtils.GetAssemblyVersion(this.GetType()); }
      }

      public string Description
      {
         get { return "Package containing all train collection tools"; }
      }

      #endregion

   }
}
