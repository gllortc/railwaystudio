using Rwm.Otc.Systems;
using System;

namespace Rwm.Otc.Layout.Elements
{
   /// <summary>
   /// Interface implemented by all blocks with feedback.
   /// </summary>
   public interface IFeedback
   {

      #region Methods

      /// <summary>
      /// Get the current status value.
      /// </summary>
      int GetFeedbackStatus();

      /// <summary>
      /// Set feedback status for the element.
      /// </summary>
      /// <param name="status">New feedback status to be adopted by the element.</param>
      void SetFeedbackStatus(FeedbackStatus status);

      #endregion

      #region Events

      /// <summary>
      /// Event raised when a new feedback status is adopted by the element.
      /// </summary>
      event EventHandler<FeedbackEventArgs> FeedbackStatusChanged;

      #endregion

   }
}
