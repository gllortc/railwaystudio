namespace Rwm.Otc.Systems.Protocol
{
   public interface IResponse
   {

      /// <summary>
      /// Gets a value indicating if the data received has valid data.
      /// </summary>
      bool IsValidResponse { get; }

   }
}
