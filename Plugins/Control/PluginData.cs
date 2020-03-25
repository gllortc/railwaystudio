using System.Windows.Forms;
using Rwm.Otc.Utils;

namespace Rwm.Studio.Plugins.Control
{
   public class PluginData : RailwayStudio.Common.IPluginPackage
   {

      #region Constants

      private const string PLUGIN_GUID = "45D142A0-CF2D-4FF4-B86F-6C8EC1C6C9F7";

      internal static string SETTINGS_KEY_SENSORS_MANUALACTIVATION = "control.sensors.manual-activation";

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
         get { return "Control"; }
      }

      public string Version
      {
         get { return ReflectionUtils.GetAssemblyVersion(this.GetType()); }
      }

      public string Description
      {
         get { return "Package containing all layout control tools"; }
      }

      #endregion

   }
}
