using System;

namespace Rwm.Otc.Systems
{
   /// <summary>
   /// Accessory information to pass through event args.
   /// </summary>
   public class AccessoryEventArgs : EventArgs
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="FeedbackEventArgs"/>.
      /// </summary>
      /// <param name="status">New status adopted by the sensor.</param>
      public AccessoryEventArgs(int status)
      {
         this.Address = 0;
         this.NewStatus = status;
      }

      /// <summary>
      /// Returns a new instance of <see cref="FeedbackEventArgs"/>.
      /// </summary>
      /// <param name="address">Feedback module address.</param>
      /// <param name="output">Output number.</param>
      /// <param name="status">New status adopted by the sensor.</param>
      public AccessoryEventArgs(int address, int status)
      {
         this.Address = address;
         this.NewStatus = status;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the feedback module address.
      /// </summary>
      public int Address { get; private set; }

      /// <summary>
      /// Gets the new status adopted by the feedback sensor.
      /// </summary>
      public int NewStatus { get; private set; }

      #endregion

   }
}
