using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Control.Controls
{
   public class ConnectionChangedEventArgs
   {

      public ConnectionChangedEventArgs(int connectionIndex, DeviceConnection connection)
      {
         this.ConnectionIndex = connectionIndex;
         this.Connection = connection;
      }

      public int ConnectionIndex { get; private set; }

      public DeviceConnection Connection { get; private set; }

   }
}
