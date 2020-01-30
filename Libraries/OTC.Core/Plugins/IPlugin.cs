using Rwm.Otc.Configuration;
namespace Rwm.Otc.Plugins
{
   public interface IPlugin
   {

      string ID { get; }

      string Name { get; }

      string Version { get; }

      string Description { get; }

      System.Drawing.Image LargeIcon { get; }

      System.Drawing.Image SmallIcon { get; }

   }
}
