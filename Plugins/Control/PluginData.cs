using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Control
{
   public class PluginData : PluginPackageBase
   {

      #region Constants

      private const string PLUGIN_GUID = "45D142A0-CF2D-4FF4-B86F-6C8EC1C6C9F7";

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
         get { return "Layout controller"; }
      }

      public override string Description
      {
         get { return "Package containing all layout control tools"; }
      }

      #endregion

   }
}
