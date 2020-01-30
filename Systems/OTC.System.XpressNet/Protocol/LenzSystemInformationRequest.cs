using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwm.Otc.Systems.Protocol
{
   public class LenzSystemInformationRequest : ILenzRequest
   {

      public byte[] CommandData { get; private set; }

      public void CreateSystemRequest(IRequest request)
      {
         if (typeof(SystemInformationRequest) != request.GetType())
         {
            throw new ArgumentException();
         }

         this.CommandData = new byte[] { 0xFF, 0xFE };
      }
   }
}
