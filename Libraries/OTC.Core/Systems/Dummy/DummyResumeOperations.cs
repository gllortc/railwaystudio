using Rwm.Otc.Systems.Protocol;

namespace Rwm.Otc.Systems.Dummy
{
   public class DummyResumeOperations : IResumeOperations, IResponse
   {
      public DummyResumeOperations()
      {
         this.IsValidResponse = true;
      }

      public bool IsValidResponse { get; private set; } = false;

      public byte[] ResponseBytes { get; private set; }

   }
}
