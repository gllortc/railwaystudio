using System.Collections.Generic;

namespace Rwm.Otc.Systems.Protocol
{
   /// <summary>
   /// Interface that should be implemented by all feedback responses from the digital systems.
   /// </summary>
   public interface IFeedbackStatusChanged
   {

      #region Properties

      /// <summary>
      /// Gets the feedback address.
      /// </summary>
      int Address { get; }

      /// <summary>
      /// Gets the list of reported statuses from the feedback sensors.
      /// </summary>
      List<FeedbackPointAddressStatus> ReportedStatuses { get; }

      #endregion

   }
}
