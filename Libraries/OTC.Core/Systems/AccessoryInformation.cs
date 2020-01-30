using Rwm.Otc.Layout;

namespace Rwm.Otc.Systems
{

   /// <summary>
   /// Contains the current status for an accessory.
   /// </summary>
   public class AccessoryInformation
   {

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
      public AccessoryInformation(int address, int status)
      {
         this.Address = address;
         this.Status = status;
      }

      /// <summary>
      /// Gets the address of the accessory.
      /// </summary>
      public int Address { get; private set; }

      /// <summary>
      /// Gets the current status of the accessory.
      /// </summary>
      public int Status { get; private set; }

   }
}
