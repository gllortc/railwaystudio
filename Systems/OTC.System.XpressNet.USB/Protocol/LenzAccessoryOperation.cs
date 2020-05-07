using System.Collections.Generic;
using Rwm.Otc.Layout;
using Rwm.Otc.Systems.Protocol;

namespace Rwm.Otc.Systems.XpressNet.Protocol
{
   /// <summary>
   /// Lenz XpressNet protocol command: 
   /// Accessory operation
   /// </summary>
   public class LenzAccessoryOperation : IAccessoryOperation, IResponse
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="LenzAccessoryOperation"/>.
      /// </summary>
      /// <param name="receivedData">Received bytes from command station.</param>
      public LenzAccessoryOperation(byte[] receivedData)
      {
         this.SetResponseData(receivedData);
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the accessory address.
      /// </summary>
      public int Address { get; private set; } = 0;

      /// <summary>
      /// Gets the current status of the accessory after the operation.
      /// </summary>
      public int Status { get; private set; } = Element.STATUS_UNDEFINED;

      /// <summary>
      /// Gets a value indicating if the accessory operation was successfully completed.
      /// </summary>
      public bool IsCompleted { get; private set; } = false;

      /// <summary>
      /// Gets a value indicating if received command is valid.
      /// </summary>
      public bool IsValidResponse { get; private set; } = false;

      /// <summary>
      /// Gets the received bytes from the command station.
      /// </summary>
      public byte[] ResponseBytes { get; private set; }

      #endregion

      #region Methods

      /// <summary>
      /// Extract the data from the received command.
      /// </summary>
      /// <param name="receivedData">Received bytes from command station.</param>
      /// <returns>Return a value indicating if the data is valid or not.</returns>
      private bool SetResponseData(byte[] receivedData)
      {
         this.ResponseBytes = receivedData;

         if (receivedData == null || receivedData.Length != 4)
         {
            this.IsValidResponse = false;
            return false;
         }

         this.Address = (receivedData[1] * 4);

         int nibble = receivedData[2] & 0b0001_0000;
         int acc0 = receivedData[2] & 0b0000_0011;
         int acc1 = receivedData[2] & 0b0000_1100;

         if (acc0 == 1 || acc0 == 2)
         {
            this.Address = this.Address + (nibble * 2);
            this.Status = acc0;
         }
         else if (acc1 == 1 || acc1 == 2)
         {
            this.Address = this.Address + (nibble * 2) + 1;
            this.Status = acc1;
         }

         this.Address++;
         this.IsCompleted = ((receivedData[2] & 0b1000_0000) == 0x00);

         this.IsValidResponse = true;
         return true;
      }

      #endregion

      #region Static Members

      /// <summary>
      /// Check if teh received data corresponds to an accessory operation command.
      /// </summary>
      /// <param name="commandBytes">Received bytes (with header and xor bytes).</param>
      /// <returns>A value indicating if the received bytes corresponds to an accessory operation command.</returns>
      public static bool IsTypeOf(List<byte> commandBytes)
      {
         if (commandBytes[0] == 0x42)
         {
            int data = commandBytes[2] & 0b0110_0000;
            return (data == 0x00 || data == 0x20);
         }
         return false;
      }

      #endregion

   }
}
