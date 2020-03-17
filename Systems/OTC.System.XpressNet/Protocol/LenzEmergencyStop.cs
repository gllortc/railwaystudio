using System.Collections.Generic;
using Rwm.Otc.Systems.Protocol;

namespace Rwm.OTC.Systems.XpressNet.Protocol
{
   public class LenzEmergencyStop : IEmergencyOff, IResponse
   {
      public LenzEmergencyStop(byte[] receivedData)
      {
         this.ResponseBytes = receivedData;
         this.IsValidResponse = (receivedData[0] == 0x3F && receivedData[1] == 0x00);
      }

      public bool IsValidResponse { get; private set; } = false;

      public byte[] ResponseBytes { get; private set; }

      #region Static Members

      /// <summary>
      /// Check if teh received data corresponds to an emergency stop.
      /// </summary>
      /// <param name="commandBytes">Received bytes (with header and xor bytes).</param>
      /// <returns>A value indicating if the received bytes corresponds to an emergency stop.</returns>
      public static bool IsTypeOf(List<byte> commandBytes)
      {
         return (commandBytes[0] == 0x3F && commandBytes[1] == 0x00);
      }

      #endregion

   }
}
