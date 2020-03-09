using System;

namespace Rwm.Otc.Systems
{
   /// <summary>
   /// Feedback information to pass through event args.
   /// </summary>
   public class FeedbackEventArgs : EventArgs
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="FeedbackEventArgs"/>.
      /// </summary>
      /// <param name="status">New status adopted by the sensor.</param>
      public FeedbackEventArgs(bool status)
      {
         this.Address = 0;
         this.Output = 0;
         this.NewStatus = status;
         this.ManualActivation = false;
      }

      /// <summary>
      /// Returns a new instance of <see cref="FeedbackEventArgs"/>.
      /// </summary>
      /// <param name="status">New status adopted by the sensor.</param>
      public FeedbackEventArgs(bool manualActivation, bool status)
      {
         this.Address = 0;
         this.Output = 0;
         this.NewStatus = status;
         this.ManualActivation = manualActivation;
      }

      /// <summary>
      /// Returns a new instance of <see cref="FeedbackEventArgs"/>.
      /// </summary>
      /// <param name="address">Feedback module address.</param>
      /// <param name="output">DecoderInput number.</param>
      /// <param name="status">New status adopted by the sensor.</param>
      public FeedbackEventArgs(int address, int output, bool status)
      {
         this.Address = address;
         this.Output = output;
         this.NewStatus = status;
         this.ManualActivation = false;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the feedback module address.
      /// </summary>
      public int Address { get; private set; }

      /// <summary>
      /// Gets a value indicating if the sensoar has been manually activated.
      /// </summary>
      public bool ManualActivation { get; private set; }

      /// <summary>
      /// Gets the output number for the specified module.
      /// </summary>
      public int Output { get; private set; }

      /// <summary>
      /// Gets the new status adopted by the feedback sensor.
      /// </summary>
      public bool NewStatus { get; private set; }

      #endregion

   }
}
