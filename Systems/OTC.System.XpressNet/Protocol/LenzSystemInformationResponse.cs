using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwm.Otc.Systems.Protocol
{
   public class LenzSystemInformationResponse : ILenzResponse
   {

      public LenzSystemInformationResponse(byte[] recvData)
      {
         this.SystemName = string.Empty;
         this.SystemVersion = string.Empty;
      }

      public string SystemName { get; private set; }

      public string SystemVersion { get; private set; }

   }
}
