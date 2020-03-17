using Rwm.Otc.Systems.Protocol;

namespace Rwm.Otc.Systems.Dummy
{

   /// <summary>
   /// Contains the digital system information obtained directly using the protocol.
   /// </summary>
   public class DummySystemInformation : ISystemInformation, IResponse
   {

      public DummySystemInformation()
      {
         this.SystemName = "Dummy Digital System";
         this.SystemVersion = "1.0.0.0";
         this.IsValidResponse = true;
      }

      public string SystemName { get; set; } = "";

      public string SystemVersion { get; set; } = "";

      public string InterfaceName { get; set; } = "";

      public string InterfaceVersion { get; set; } = "";

      public bool IsValidResponse { get; private set; } = false;
   }
}
