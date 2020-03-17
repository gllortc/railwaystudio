using Rwm.Otc.Layout;
using Rwm.Otc.Systems.Protocol;

namespace Rwm.Otc.Systems.Dummy
{
   public class DummyAccessoryOperation : IAccessoryOperation, IResponse
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="DummyAccessoryOperation"/>.
      /// </summary>
      public DummyAccessoryOperation(int address, int pin)
      {
         this.Address = address;
         this.Status = pin;

         this.IsValidResponse = true;
         this.IsCompleted = true;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the accessory address.
      /// </summary>
      public int Address { get; private set; } = 0;

      /// <summary>
      /// Gets the current status of the accessory after the operation.
      /// </summary>
      public int Status { get; private set; } = Element.STATUS_UNDEFINED;

      /// <summary>
      /// Gets a value indicating if received command is valid.
      /// </summary>
      public bool IsValidResponse { get; private set; } = false;

      public bool IsCompleted { get; private set; } = false;

      #endregion

   }
}
