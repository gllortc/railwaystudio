namespace Rwm.Otc.Systems
{

   /// <summary>
   /// Feedback point address status.
   /// </summary>
   public class FeedbackPointAddressStatus
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="FeedbackStatus"/>.
      /// </summary>
      /// <param name="address">Feedback address.</param>
      /// <param name="point">Point address of feedback sensor inside the address.</param>
      /// <param name="active">New status adopted by the feedback sensor.</param>
      public FeedbackPointAddressStatus(int address, int point, bool active)
      {
         this.Address = address;
         this.PointAddress = point;
         this.Active = active;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the feedback address.
      /// </summary>
      public int Address { get; }

      /// <summary>
      /// Gets the point address changed.
      /// </summary>
      public int PointAddress { get; }

      /// <summary>
      /// Gets the new status adopted by the feedback sensor (false -> low, true true -> high)
      /// </summary>
      public bool Active { get; }

      #endregion

      #region Methods

      public override string ToString()
      {
         return string.Format("{0:D4}:{1}-{2}", this.Address, this.PointAddress, this.Active);
      }

      #endregion

   }
}
