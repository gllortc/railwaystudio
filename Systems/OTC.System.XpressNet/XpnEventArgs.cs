namespace Rwm.OTC.Systems.XpressNet
{
   public class XpnEventArgs
   {

      #region Enumerations

      public enum XpnMessage
      {
         AnotherDevice,
      }

      #endregion

      #region Constructors

      public XpnEventArgs(XpnMessage m, byte low, byte hi)
      {
         this.Message = m;
         this.AddressLow = low;
         this.AddressHi = hi;
      }

      public XpnEventArgs(XpnMessage m)
      {
         this.Message = m;
      }

      #endregion

      #region Properties

      public XpnMessage Message { get; private set; }

      public byte AddressLow { get; private set; }

      public byte AddressHi { get; private set; }

      #endregion

   }
}
