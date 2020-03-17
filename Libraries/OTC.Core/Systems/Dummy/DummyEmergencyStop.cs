using Rwm.Otc.Systems.Protocol;

namespace Rwm.Otc.Systems.Dummy
{
   public class DummyEmergencyStop : IEmergencyOff, IResponse
   {
      public DummyEmergencyStop()
      {
         this.IsValidResponse = true;
      }

      public bool IsValidResponse { get; private set; } = false;

   }
}
