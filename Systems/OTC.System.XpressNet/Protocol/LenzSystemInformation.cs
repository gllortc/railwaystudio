namespace Rwm.Otc.Systems.Protocol
{
   public class LenzSystemInformation : ISystemInformation, IResponse
   {

      public LenzSystemInformation(byte[] receivedData)
      {
         this.SetResponseData(receivedData);
      }

      public string SystemName { get; set; } = "";

      public string SystemVersion { get; set; } = "";

      public string InterfaceName { get; set; } = "";

      public string InterfaceVersion { get; set; } = "";

      public bool IsValidResponse { get; private set; } = false;

      public bool SetResponseData(byte[] receivedData)
      {
         if (receivedData == null || receivedData.Length != 7)
         {
            this.IsValidResponse = false;
            return false;
         }


         double ver = (double)((receivedData[4] & 0xF0) >> 4) + ((double)(receivedData[4] & 0x0F) / 10.0);
         this.SystemVersion = ver.ToString().Replace(',', '.');
         switch (receivedData[5])
         {
            case 0x00: this.SystemName = "LZ100"; break;
            case 0x01: this.SystemName = "LH200"; break;
            case 0x02: this.SystemName = "DPC (Compact o Commander)"; break;
            default: this.SystemName = "Unknown model"; break;
         }

         this.IsValidResponse = true;
         return true;
      }
   }
}
