using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwm.Otc.Systems.Protocol
{
   public class SystemInformationResponse
   {

      public SystemInformationResponse(string name, string version)
      {
         this.SystemName = name;
         this.SystemVersion = version;
      }

      public string SystemName { get; private set; }

      public string SystemVersion { get; private set; }

   }
}
