using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwm.Otc.Systems.Protocol
{
   public interface ICommand
   {

      /// <summary>
      /// Parse received data from the digital system.
      /// </summary>
      bool ParseCommandData(byte[] data);

   }
}
