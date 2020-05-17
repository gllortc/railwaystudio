namespace Rwm.Otc.Layout.Traffic
{
   public class ItineraryFeedbackPoint
   {

      #region Enumerations

      public enum FeedbackAction
      {
         Skip,
         CompleteRoute,
         Brake,
         Stop
      }

      #endregion

      #region Constructors

      public ItineraryFeedbackPoint(FeedbackEncoderConnection connection, Route route)
      {
         this.FeedbackEncoderConnection = connection;
         this.Route = route;
      }

      #endregion

      #region Properties

      public FeedbackAction Action { get; set; } = FeedbackAction.CompleteRoute;

      public FeedbackEncoderConnection FeedbackEncoderConnection { get; private set; }

      public Route Route { get; private set; }

      #endregion

   }
}
