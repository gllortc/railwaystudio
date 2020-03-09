using System;

namespace Rwm.OTC.Systems.XpressNet
{
   public class XpnInputCommandEventArgs : EventArgs
   {

      #region Constructors

      public XpnInputCommandEventArgs(byte[] data) : base()
      {
         this.InputData = data;
      }

      #endregion

      #region Properties

      public byte[] InputData { get; private set; }

      #endregion

   }
}
