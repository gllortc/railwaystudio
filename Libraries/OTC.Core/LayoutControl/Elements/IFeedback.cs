using Rwm.Otc.Systems;
using System;
using System.Collections.Generic;

namespace Rwm.Otc.LayoutControl.Elements
{
   /// <summary>
   /// Interface implemented by all blocks with feedback.
   /// </summary>
   public interface IFeedback
   {

      /// <summary>
      /// Get the current status value.
      /// </summary>
      int GetFeedbackStatus();

      /// <summary>
      /// Set feedback status for the element.
      /// </summary>
      /// <param name="status">New feedback status to be adopted by the element.</param>
      void SetFeedbackStatus(int status);

      /// <summary>
      /// Get a list of available feedback status for the element.
      /// </summary>
      /// <returns>A <c>KeyValuePair</c> filled with the description and the integer value.</returns>
      List<KeyValuePair<String, int>> GetAllFeedbackStatusValues();

      /// <summary>
      /// Event raised when a new feedback status is adopted by the element.
      /// </summary>
      event EventHandler<FeedbackEventArgs> FeedbackStatusChanged;

   }
}
