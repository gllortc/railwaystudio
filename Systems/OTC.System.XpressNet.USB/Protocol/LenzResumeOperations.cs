using System.Collections.Generic;
using Rwm.Otc.Systems.Protocol;

namespace Rwm.Otc.Systems.XpressNet.Protocol
{
   public class LenzResumeOperations : IResumeOperations, IResponse
   {
      public LenzResumeOperations(byte[] receivedData)
      {
         this.ResponseBytes = receivedData;
         this.IsValidResponse = (receivedData[0] == 0x61 && receivedData[1] == 0x01);
      }

      public bool IsValidResponse { get; private set; } = false;

      public byte[] ResponseBytes { get; private set; }

      #region Static Members

      /// <summary>
      /// Check if the received data corresponds to a resume operations command.
      /// </summary>
      /// <param name="commandBytes">Received bytes (with header and xor bytes).</param>
      /// <returns>A value indicating if the received bytes corresponds to a resume operations command.</returns>
      public static bool IsTypeOf(List<byte> commandBytes)
      {
         return (commandBytes[0] == 0x61 && commandBytes[1] == 0x01);
      }

      #endregion

   }
}
