using Rwm.Otc.Configuration;
using System;

namespace Rwm.Studio.Plugins.Control.Controls
{
   public partial class SettingsControl : DevExpress.XtraEditors.XtraUserControl
   {
      public SettingsControl(XmlSettingsManager settings)
      {
         InitializeComponent();

         this.Settings = settings;

         chkControlAllowManualSensors.Checked = this.Settings.GetBoolean(PluginData.SETTINGS_KEY_SENSORS_MANUALACTIVATION);
      }

      public XmlSettingsManager Settings { get; private set; }

      private void chkControlAllowManualSensors_CheckedChanged(object sender, EventArgs e)
      {
         this.Settings.AddSetting(PluginData.SETTINGS_KEY_SENSORS_MANUALACTIVATION, chkControlAllowManualSensors.Checked);
      }
   }
}
