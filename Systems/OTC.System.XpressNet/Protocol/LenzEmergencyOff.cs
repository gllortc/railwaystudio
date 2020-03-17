using System.Collections.Generic;
using Rwm.Otc.Systems.Protocol;

namespace Rwm.OTC.Systems.XpressNet.Protocol
{
   public class LenzEmergencyOff : IEmergencyOff, IResponse
   {
      public LenzEmergencyOff(byte[] receivedData)
      {
         this.ResponseBytes = receivedData;
         this.IsValidResponse = (receivedData[5] == 0x00);
      }

      public bool IsValidResponse { get; private set; } = false;

      public byte[] ResponseBytes { get; private set; }

      #region Static Members

      /// <summary>
      /// Check if teh received data corresponds to a feedback status changed command.
      /// </summary>
      /// <param name="commandBytes">Received bytes (with header and xor bytes).</param>
      /// <returns>A value indicating if the received bytes corresponds to a feedback status changed command.</returns>
      public static bool IsTypeOf(List<byte> commandBytes)
      {
         return (commandBytes[0] == 0x60 && commandBytes[1] == 0x61);
      }

      #endregion

   }
}
