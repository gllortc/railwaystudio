using Rwm.Otc.Layout;
using Rwm.Otc.TrainControl;
using System;

namespace Rwm.Otc.Systems
{
   /// <summary>
   /// Feedback information to pass through event args.
   /// </summary>
   public class OccupationEventArgs : EventArgs
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="OccupationEventArgs"/>.
      /// </summary>
      /// <param name="status">New status adopted by the sensor.</param>
      public OccupationEventArgs(Element element, Train model)
      {
         this.Element = element;
         this.Model = model;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets a value indicating if the block is occupied.
      /// </summary>
      public bool IsOccupied
      {
         get { return (this.Model != null); }
      }

      /// <summary>
      /// Gets the feedback module address.
      /// </summary>
      public Element Element { get; private set; }

      /// <summary>
      /// Gets the output number for the specified module.
      /// </summary>
      public Train Model { get; private set; }

      #endregion

   }
}
