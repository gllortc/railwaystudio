using System.Collections.Generic;
using Rwm.Otc.Systems.Protocol;

namespace Rwm.Otc.Systems.XpressNet.Protocol
{
   public class LenzFeedbackStatusChanged : IFeedbackStatusChanged, IResponse
   {

      #region Constructors

      public LenzFeedbackStatusChanged(byte[] receivedData)
      {
         this.SetResponseData(receivedData);
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the address of the changed feedback sensor.
      /// </summary>
      public int Address { get; private set; } = 0;

      /// <summary>
      /// Gets a value indicating if received command is valid.
      /// </summary>
      public bool IsValidResponse { get; private set; } = false;

      /// <summary>
      /// Gets the received bytes from the command station.
      /// </summary>
      public byte[] ResponseBytes { get; private set; }

      public int Output => throw new System.NotImplementedException();

      public bool Active => throw new System.NotImplementedException();

      #endregion

      #region Methods

      /// <summary>
      /// Extract the data from the received command.
      /// </summary>
      /// <param name="receivedData">Received bytes.</param>
      /// <returns>Return a value indicating if the data is valid or not.</returns>
      private bool SetResponseData(byte[] receivedData)
      {
         this.ResponseBytes = receivedData;

         if (receivedData == null || receivedData.Length != 4)
         {
            this.IsValidResponse = false;
            return false;
         }

         this.Address = receivedData[1] * 4;


         double ver = (double)((receivedData[2] & 0xF0) >> 4) + ((double)(receivedData[2] & 0x0F) / 10.0);
         //this.SystemVersion = ver.ToString().Replace(',', '.');
         //switch (receivedData[3])
         //{
         //   case 0x00: this.SystemName = "LZ100"; break;
         //   case 0x01: this.SystemName = "LH200"; break;
         //   case 0x02: this.SystemName = "DPC (Compact o Commander)"; break;
         //   default: this.SystemName = "Unknown model"; break;
         //}

         this.IsValidResponse = true;
         return true;
      }

      #endregion

      #region Static Members

      /// <summary>
      /// Check if teh received data corresponds to a feedback status changed command.
      /// </summary>
      /// <param name="commandBytes">Received bytes (with header and xor bytes).</param>
      /// <returns>A value indicating if the received bytes corresponds to a feedback status changed command.</returns>
      public static bool IsTypeOf(List<byte> commandBytes)
      {
         if (commandBytes[0] == 0x42)
         {
            int data = commandBytes[2] & 0b0110_0000;
            return (data == 0x40);
         }
         return false;
      }

      #endregion

   }
}
