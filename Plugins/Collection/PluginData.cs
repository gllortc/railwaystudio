using RailwayStudio.Common;

namespace Rwm.Studio.Plugins.Collection
{
   public class PluginData : PluginPackageBase
   {

      #region Constants

      private const string PLUGIN_GUID = "094AAA89-8A8A-4FAC-A288-A8968F41AADD";

      #endregion

      #region IPlugin Implementation

      public override string ID
      {
         get { return PLUGIN_GUID; }
      }

      public override System.Drawing.Image SmallIcon
      {
         get { return Properties.Resources.ICO_APP_16; }
      }

      public override System.Drawing.Image LargeIcon
      {
         get { return Properties.Resources.ICO_APP_32; }
      }

      public override string Name
      {
         get { return "Collection"; }
      }

      public override string Description
      {
         get { return "Package containing all train collection tools"; }
      }

      #endregion

   }
}
