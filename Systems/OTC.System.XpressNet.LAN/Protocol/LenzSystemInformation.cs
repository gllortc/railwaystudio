using System.Collections.Generic;
using Rwm.Otc.Systems.Protocol;

namespace Rwm.Otc.Systems.XpressNet.Protocol
{
   public class LenzSystemInformation : ISystemInformation, IResponse
   {

      public LenzSystemInformation(byte[] receivedData)
      {
         this.SetResponseData(receivedData);
      }

      public string SystemName { get; set; } = string.Empty;

      public string SystemVersion { get; set; } = string.Empty;

      public string InterfaceName { get; set; } = string.Empty;

      public string InterfaceVersion { get; set; } = string.Empty;

      public byte[] ResponseBytes { get; private set; }

      public bool IsValidResponse { get; private set; } = false;

      public bool SetResponseData(byte[] receivedData)
      {
         this.ResponseBytes = receivedData;

         if (receivedData == null || receivedData.Length != 5)
         {
            this.IsValidResponse = false;
            return false;
         }

         double ver = (double)((receivedData[2] & 0xF0) >> 4) + ((double)(receivedData[2] & 0x0F) / 10.0);
         this.SystemVersion = ver.ToString().Replace(',', '.');
         switch (receivedData[3])
         {
            case 0x00: this.SystemName = "LZ100"; break;
            case 0x01: this.SystemName = "LH200"; break;
            case 0x02: this.SystemName = "DPC (Compact o Commander)"; break;
            default: this.SystemName = "Unknown model"; break;
         }

         this.IsValidResponse = true;
         return true;
      }

      #region Static Members

      /// <summary>
      /// Check if the received data corresponds to a system information command.
      /// </summary>
      /// <param name="commandBytes">Received bytes (with header and xor bytes).</param>
      /// <returns>A value indicating if the received bytes corresponds to a system information command.</returns>
      public static bool IsTypeOf(List<byte> commandBytes)
      {
         return (commandBytes[0] == 0x63 && commandBytes[1] == 0x21);
      }

      #endregion

   }
}
