using System;
using System.Collections.Generic;
using RJCP.IO.Ports;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Utils;

namespace Rwm.OTC.Systems.XpressNet.Protocol
{
   public abstract class CommandBase
   {

      #region Properties

      public abstract int ResponseBytes { get; }

      public virtual bool WaitForResponse 
      {
         get { return false; }
      }

      public bool ResponseAvailable { get; internal set; } = false;

      /// <summary>
      /// Gets the command bytes (excluding the header bytes and the xor byte).
      /// </summary>
      internal abstract byte[] RequestBytes { get; }

      
      public virtual byte[] GetCommandBytes()
      {
         if (this.RequestBytes.Length <= 0)
            return new byte[0];

         byte[] bytes = new byte[2 + this.RequestBytes.Length + 1];
         bytes[0] = 0xFF;
         bytes[1] = 0xFE;
         for (int idx = 0; idx < this.RequestBytes.Length; idx++) bytes[2 + idx] = this.RequestBytes[idx];
         bytes[bytes.Length - 1] = (byte)BinaryUtils.Xor(bytes, 2, this.RequestBytes.Length);
         return bytes;
      }

      internal byte[] ResponseBuffer { get; set; }

      public string ErrorMessage { get; internal set; }

      #endregion

      #region Methods

      /// <summary>
      /// Set the received data afeter a request and transform it into a particular command response data.
      /// </summary>
      /// <param name="data">Received data from command station.</param>
      public abstract void SetResponseData(List<byte> data);

      /// <summary>
      /// Get the command bytes and send them to the digital system.
      /// </summary>
      /// <returns>A value indicating if the command has been sent to the digital system or not.</returns>
      public bool SendCommand(SerialPortStream port)
      {
         if (this.RequestBytes.Length <= 0)
            return false;

         try
         {
            byte[] bytes = new byte[2 + this.RequestBytes.Length + 1];
            bytes[0] = 0xFF;
            bytes[1] = 0xFE;
            for (int idx = 0; idx < this.RequestBytes.Length; idx++) bytes[2 + idx] = this.RequestBytes[idx];
            bytes[bytes.Length - 1] = (byte)BinaryUtils.Xor(bytes, 2, this.RequestBytes.Length);

            port.Write(bytes, 0, bytes.Length);

            return true;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            return false;
         }
      }

      #endregion

   }
}
