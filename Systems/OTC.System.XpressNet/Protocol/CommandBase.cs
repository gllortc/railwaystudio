using System.Collections.Generic;
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

      /// <summary>
      /// Gets the command bytes (excluding the header bytes and the xor byte).
      /// </summary>
      internal abstract byte[] RequestBytes { get; }

      /// <summary>
      /// Get the command bytes to send to digital system.
      /// </summary>
      /// <returns>An array of bytes corresponding to the command to send.</returns>
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

      public bool ResponseAvailable { get; private set; } = false;

      internal byte[] ResponseBuffer { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Set the received data afeter a request and transform it into a particular command response data.
      /// </summary>
      /// <param name="data">Received data from command station.</param>
      public abstract void SetResponseData(List<byte> data);

      #endregion

   }
}
