using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Control.Controls
{
   public class MapChangedEventArgs
   {

      public MapChangedEventArgs(AccessoryDecoderConnection connection)
      {
         this.Connection = connection;
      }

      public AccessoryDecoderConnection Connection { get; private set; }

   }
}
