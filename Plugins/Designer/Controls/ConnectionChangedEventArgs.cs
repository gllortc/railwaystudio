using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Designer.Controls
{
   public class ConnectionChangedEventArgs
   {

      public ConnectionChangedEventArgs(int connectionIndex, AccessoryDecoderConnection connection)
      {
         this.ConnectionIndex = connectionIndex;
         this.Connection = connection;
      }

      public int ConnectionIndex { get; private set; }

      public AccessoryDecoderConnection Connection { get; private set; }

   }
}
