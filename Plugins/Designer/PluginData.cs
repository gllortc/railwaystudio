using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Designer
{
   public class PluginData : PluginPackageBase
   {

      #region Constants

      private const string PLUGIN_GUID = "D62A080C-E66B-4E71-8710-C07F7E463D7C";

      #endregion

      #region IPlugin Implementation

      public override string ID
      {
         get { return PLUGIN_GUID; }
      }

      public override System.Drawing.Image SmallIcon
      {
         get { return Otc.Trains.Train.SmallIcon; }
      }

      public override System.Drawing.Image LargeIcon
      {
         get { return Properties.Resources.ICO_APP_32; }
      }

      public override string Name
      {
         get { return "Layout designer"; }
      }

      public override string Description
      {
         get { return "Package containing all layout design tools"; }
      }

      #endregion

   }
}
