using Rwm.Otc.Utils;
using System;

namespace Rwm.OTC.Systems.Lenz.Commands
{
   public class AccessoryDecoderOperationCommand : Command
   {

      #region Constructors

      public AccessoryDecoderOperationCommand(int address, int activeTerminal)
      {
         bool turned = (activeTerminal == 1 ? false : true);

         this.RequestData = new byte[] { 0xFF, 0xFE, 0x52, 0x00, 0x00, 0x00 };
         this.ResponseHeaderData = new byte[] { 0x01, 0x04 };

         // Check the address
         if (!LenzAddress.IsValidAddress(address))
         {
            throw new Exception("Invalid address");
         }

         try
         {
            byte byteAddy = 0x00;
            byte byteB = 0x00;
            byte byteD = 0x00;

            byteAddy = (byte)(address / 4);
            byteB = (byte)(((address % 4) & 0x01) << 1);
            byteB += (byte)(((address % 4) & 0x02) << 1);
            byteD = (byte)(true ? 0x08 : 0x00);
            byteD += (byte)(turned ? 0x01 : 0x00);

            this.RequestData[3] = byteAddy;
            this.RequestData[4] = (byte)(0x80 + byteB + byteD);
            this.RequestData[5] = (byte)BinaryUtils.Xor(this.RequestData, 2, 3);
         }
         catch (Exception ex)
         {
            throw new Exception("Write error: " + ex.Message, ex);
         }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Transform the received data into the Lenz command response.
      /// </summary>
      /// <param name="data">Data received (without Lenz fixed frame).</param>
      /// <returns><c>true</c> if the data is correct, otherwise returns <c>false</c>.</returns>
      public override bool GetCommandData(byte[] data)
      {
         return true;
      }

      #endregion

   }
}
