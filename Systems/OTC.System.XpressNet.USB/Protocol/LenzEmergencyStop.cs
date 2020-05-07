using System.Collections.Generic;
using Rwm.Otc.Systems.Protocol;

namespace Rwm.Otc.Systems.XpressNet.Protocol
{
   /// <summary>
   /// Lenz XpressNet protocol command: 
   /// Emergency Stop
   /// </summary>
   public class LenzEmergencyStop : IEmergencyOff, IResponse
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="LenzEmergencyStop"/>.
      /// </summary>
      /// <param name="receivedData">Data received from the command station.</param>
      public LenzEmergencyStop(byte[] receivedData)
      {
         this.ResponseBytes = receivedData;
         this.IsValidResponse = (receivedData[0] == 0x3F && receivedData[1] == 0x00);
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets a value indicating if the data received has valid data.
      /// </summary>
      public bool IsValidResponse { get; private set; } = false;

      /// <summary>
      /// Gets the received bytes from command station.
      /// </summary>
      public byte[] ResponseBytes { get; private set; }

      #endregion

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
