using Rwm.Otc.Layout;

namespace Rwm.Otc.Systems
{

   /// <summary>
   /// Contains the current status for an accessory.
   /// </summary>
   public class AccessoryInformation
   {

      public enum OperationResult : int
      {
         NotOperated,
         Side,
         Straight,
         Invalid,
      }

      public enum AccessoryType
      {
         DecoderNoFeedback,
         DecoderFeedback,
         FeedbackModule,
         Future,
      }

      /// <summary>
      /// Returns the current status of an accessory.
      /// </summary>
      /// <param name="address">Accessory address.</param>
      public AccessoryInformation(int address)
      {
         this.Address = address;
         this.Status = Element.STATUS_UNDEFINED;
      }

      /// <summary>
      /// Returns the current status of an accessory.
      /// </summary>
      /// <param name="address">Accessory address.</param>
      /// <param name="status">Current accessory status.</param>
      public AccessoryInformation(int address, int status, bool finished, AccessoryType type, OperationResult result)
      {
         this.Address = address;
         this.Status = status;
         this.Finished = finished;
         this.Type = type;
         this.Result = result;
      }

      /// <summary>
      /// Gets the type of the accessory.
      /// </summary>
      public AccessoryType Type { get; private set; } = AccessoryType.Future;

      /// <summary>
      /// Gets the address of the accessory.
      /// </summary>
      public int Address { get; private set; }

      /// <summary>
      /// Gets the current status of the accessory.
      /// </summary>
      public int Status { get; private set; }

      /// <summary>
      /// Gets the current status of the accessory.
      /// </summary>
      public OperationResult Result { get; private set; } = OperationResult.NotOperated;

      /// <summary>
      /// Gets the current status of the accessory.
      /// </summary>
      public bool Finished { get; private set; } = true;

   }
}
