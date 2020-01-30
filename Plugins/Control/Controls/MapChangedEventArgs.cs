using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Control.Controls
{
   public class MapChangedEventArgs
   {

      public MapChangedEventArgs(DeviceConnection connection)
      {
         this.Connection = connection;
      }

      public DeviceConnection Connection { get; private set; }

   }
}
