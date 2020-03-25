using System.Collections.Generic;
using Rwm.Otc.Systems.Protocol;

namespace Rwm.Otc.Systems.XpressNet.Protocol
{
   public class LenzInterfaceInformation : IInterfaceInformation, IResponse
   {

      public LenzInterfaceInformation(byte[] receivedData)
      {
         this.SetResponseData(receivedData);
      }

      public string HardwareVersion { get; set; } = string.Empty;

      public string SoftwareVersion { get; set; } = string.Empty;

      public byte[] ResponseBytes { get; private set; }

      public bool IsValidResponse { get; private set; } = false;

      public bool SetResponseData(byte[] receivedData)
      {
         this.ResponseBytes = receivedData;

         if (receivedData == null || receivedData.Length != 4)
         {
            this.IsValidResponse = false;
            return false;
         }

         this.HardwareVersion = ((int)receivedData[1] / 10).ToString();
         this.SoftwareVersion = ((int)receivedData[2]).ToString();

         this.IsValidResponse = true;
         return true;
      }

      #region Static Members

      /// <summary>
      /// Check if the received data corresponds to a interface information command.
      /// </summary>
      /// <param name="commandBytes">Received bytes (with header and xor bytes).</param>
      /// <returns>A value indicating if the received bytes corresponds to a interface information command.</returns>
      public static bool IsTypeOf(List<byte> commandBytes)
      {
         return (commandBytes[0] == 0x02);
      }

      #endregion

   }
}
