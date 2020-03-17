using Rwm.Otc.Systems.Protocol;

namespace Rwm.Otc.Systems.Dummy
{
   public class DummyEmergencyOff : IEmergencyOff, IResponse
   {
      public DummyEmergencyOff()
      {
         this.IsValidResponse = true;
      }

      public bool IsValidResponse { get; private set; } = false;

      public byte[] ResponseBytes { get; private set; }

   }
}
