using System;

namespace Rwm.OTC.Systems.XpressNet
{
   public class XpnProtocolException : Exception
   {

      public XpnProtocolException(string message, params object[] args) 
         : base(String.Format(message, args)) { }


   }
}
