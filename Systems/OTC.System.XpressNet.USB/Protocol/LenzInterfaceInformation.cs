using System.Collections.Generic;
using Rwm.Otc.Systems.Protocol;

namespace Rwm.Otc.Systems.XpressNet.Protocol
{
   /// <summary>
   /// Lenz XpressNet protocol command: 
   /// LI-USB Interface Information
   /// </summary>
   public class LenzInterfaceInformation : IInterfaceInformation, IResponse
   {

      #region region

      /// <summary>
      /// Returns a new instance of <see cref="LenzInterfaceInformation"/>.
      /// </summary>
      /// <param name="receivedData">Bytes received from the command station.</param>
      public LenzInterfaceInformation(byte[] receivedData)
      {
         this.SetResponseData(receivedData);
      }

      #endregion

      #region Properties

      public string HardwareVersion { get; private set; } = string.Empty;

      public string SoftwareVersion { get; private set; } = string.Empty;

      /// <summary>
      /// Gets the received bytes from the command station.
      /// </summary>
      public byte[] ResponseBytes { get; private set; }

      /// <summary>
      /// Gets a value indicating if received command is valid.
      /// </summary>
      public bool IsValidResponse { get; private set; } = false;

      #endregion

      #region Methods

      /// <summary>
      /// Process the received bytes from the command station.
      /// </summary>
      /// <param name="receivedData">Bytes received from the command station.</param>
      /// <returns>A value indicating if the received command has been processed successfully.</returns>
      public bool SetResponseData(byte[] receivedData)
      {
         this.ResponseBytes = receivedData;

         if (receivedData == null || receivedData.Length != 4)
         {
            this.IsValidResponse = false;
            return false;
         }

         this.HardwareVersion = (receivedData[1] / 10).ToString();
         this.SoftwareVersion = ((int)receivedData[2]).ToString();

         this.IsValidResponse = true;
         return true;
      }

      #endregion

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
