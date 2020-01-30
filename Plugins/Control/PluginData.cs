using Rwm.Otc.Configuration;
using Rwm.Studio.Plugins.Control.Controls;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control
{
   public class PluginData : RailwayStudio.Common.IPlugin
   {

      #region Constants

      private const string PLUGIN_GUID = "FC4A7DB6-AFA8-4FB5-9C4F-2942919B9FD1";

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
         get { return Application.ProductVersion; }
      }

      public string Description
      {
         get { return string.Empty; }
      }

      public bool IsConfigurable
      {
         get { return true; }
      }

      public UserControl CreateSettingsControl(XmlSettingsManager settings)
      {
         return new SettingsControl(settings);
      }

      #endregion

   }
}
