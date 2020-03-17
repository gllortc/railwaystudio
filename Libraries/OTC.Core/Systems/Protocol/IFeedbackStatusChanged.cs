using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rwm.Otc.Systems.Protocol
{

   public interface IFeedbackStatusChanged
   {

      int Address { get; }

      int Output { get; }

      bool Active { get; }

   }
}
