using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Rwm.Otc.Configuration
{
   public interface IXmlSettingsItem
   {

      string Key { get; set; }

      void WriteToXml(XmlWriter writer);

   }
}
