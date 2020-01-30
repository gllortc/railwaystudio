using Rwm.Otc.Configuration;
using System.Windows.Forms;

namespace RailwayStudio.Common
{
   public interface IPlugin
   {

      string ID { get; }

      string Name { get; }

      string Version { get; }

      string Description { get; }

      System.Drawing.Image LargeIcon { get; }

      System.Drawing.Image SmallIcon { get; }

      bool IsConfigurable { get; }

      UserControl CreateSettingsControl(XmlSettingsManager settings);

   }
}
