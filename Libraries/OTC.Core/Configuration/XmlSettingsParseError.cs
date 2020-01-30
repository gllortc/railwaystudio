using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwm.Otc.Configuration
{
   public class XmlSettingsParseError : Exception
   {

      public XmlSettingsParseError() : base() { }

      public XmlSettingsParseError(string message) : base(message) { }

      public XmlSettingsParseError(string message, Exception innerException) : base(message, innerException) { }

   }
}
