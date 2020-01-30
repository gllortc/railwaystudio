using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwm.Otc.Systems.Responses
{
   public interface IResponse
   {

      /// <summary>
      /// Gets a value indicating if the response is received normally or not.
      /// </summary>
      bool Status { get; }

   }
}
