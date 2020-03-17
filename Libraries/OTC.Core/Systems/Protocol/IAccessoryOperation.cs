namespace Rwm.Otc.Systems.Protocol
{

   public interface IAccessoryOperation
   {

      /// <summary>
      /// Gets the accessory address.
      /// </summary>
      int Address { get; }

      /// <summary>
      /// Gets the current status of the accessory after the operation.
      /// </summary>
      int Status { get; }

      /// <summary>
      /// Gets a value indicating if the accessory operation was successfully completed.
      /// </summary>
      bool IsCompleted { get; }

   }
}
