namespace Rwm.Otc.Systems.Protocol
{
   public interface ILenzRequest
   {

      byte[] CommandData { get; }

      void CreateSystemRequest(IRequest request);

   }
}
