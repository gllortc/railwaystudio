using System.IO.Ports;

namespace Rwm.OTC.Systems.XpressNet
{
   internal class XpnSerialPort : SerialPort
   {

      #region Constructors

      public XpnSerialPort() { }

      public XpnSerialPort(string port) : base(port) { }

      public XpnSerialPort(string port, int baudRate, LenzXpressNet xnet) : base(port)
      {
         this.XpressnetConnector = xnet;
         this.BaudRate = baudRate;
         this.Parity = Parity.None;
         this.DataBits = 8;
         this.StopBits = StopBits.One;
      }

      #endregion

      #region Properties

      public LenzXpressNet XpressnetConnector { get; set; } = null;

      public bool DebugModeEnabled { get; set; } = false;

      #endregion

      #region Methods

      public void ProcessUnrequestedMessage(XpnEventArgs msg)
      {
         if (this.XpressnetConnector == null)
            return;

         this.XpressnetConnector.FireUnrequestedMessageEvent(msg);
      }

      #endregion

   }
}
