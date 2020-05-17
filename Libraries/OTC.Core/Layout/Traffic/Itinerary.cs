using System.Collections.Generic;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Systems;
using Rwm.Otc.Trains;

namespace Rwm.Otc.Layout.Traffic
{
   /// <summary>
   /// Implements an itinerary between two block elements.
   /// </summary>
   public class Itinerary
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Itinerary"/>.
      /// </summary>
      /// <param name="train">Train to move to the destination block.</param>
      /// <param name="fromBlock">Departure block.</param>
      /// <param name="toBlock">Destination block.</param>
      public Itinerary(Train train, Element fromBlock, Element toBlock) 
      {
         this.Train = train;
         this.FromBlock = fromBlock;
         this.ToBlock = toBlock;
         this.PendingRoutes = new List<Route>();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets a value indicating if the train is now travelling to the destination block.
      /// </summary>
      public bool Enabled { get; private set; } = false;

      /// <summary>
      /// Gets a value indicating if the train is now travelling to the destination block.
      /// </summary>
      public bool Completed { get; set; } = false;

      /// <summary>
      /// Gets the train.
      /// </summary>
      public Train Train { get; private set; } = null;

      /// <summary>
      /// Gets the departure block.
      /// </summary>
      public Element FromBlock { get; private set; } = null;

      /// <summary>
      /// Gets the destination block.
      /// </summary>
      public Element ToBlock { get; private set; } = null;

      /// <summary>
      /// Gets the list of routes that the train should follow to achieve the traffic assignation.
      /// </summary>
      public List<Route> PendingRoutes { get; set; } = null;

      /// <summary>
      /// Gets the list of completed partial routes.
      /// </summary>
      public List<Route> CompletedRoutes { get; set; } = new List<Route>();

      /// <summary>
      /// Gets the list of completed partial routes.
      /// </summary>
      public List<ItineraryFeedbackPoint> FeedbackSequence { get; private set; } = null;

      #endregion

      #region Methods

      public void SetItinerary(List<Route> routes)
      {
         Logger.LogDebug(this, "[CLASS].SetItinerary([{0}])", routes);

         if (routes == null || routes.Count <= 0)
            throw new System.Exception(string.Format("Cannot trace a valid itinerary: {0}", this));

         this.PendingRoutes = routes;
         this.PendingRoutes.Reverse();

         // Configure the feedback sequence
         this.FeedbackSequence = new List<ItineraryFeedbackPoint>();
         foreach (Route route in this.PendingRoutes)
         {
            foreach (FeedbackEncoderConnection connection in route.ToBlock.FeedbackConnections)
            {
               this.FeedbackSequence.Add(new ItineraryFeedbackPoint(connection, route));
            }
         }

         // TODO: Make it configurable!
         // Configure the feedback to brake and stop in last block
         if (this.PendingRoutes[this.PendingRoutes.Count - 1].ToBlock.FeedbackConnections.Count >= 2)
         {
            this.FeedbackSequence[this.FeedbackSequence.Count - 2].Action = ItineraryFeedbackPoint.FeedbackAction.Brake;
            this.FeedbackSequence[this.FeedbackSequence.Count - 1].Action = ItineraryFeedbackPoint.FeedbackAction.Stop;
         }
      }

      /// <summary>
      /// Informs to the itinerary that an active feedback have been received to check it.
      /// </summary>
      /// <param name="status">Feedback status information received from command station.</param>
      /// <param name="element">Involved element.</param>
      /// <returns>
      /// A value indicating if the feedback signal has been processed by the current itinerary (<c>true</c>) 
      /// or the signal is not related to the current itinerary (<c>false</c>).
      /// </returns>
      public bool FeedbackReceived(FeedbackPointAddressStatus status, Element element)
      {
         Logger.LogDebug(this, "[CLASS].FeedbackReceived([{0}], [{1}])", status, element);

         // Check if itinerary have pending feedback responses
         if (this.FeedbackSequence.Count <= 0)
            return false;

         // Check if feedback corresponds to the current itinerary
         if (!this.FeedbackSequence[0].FeedbackEncoderConnection.EncoderInput.MatchStatus(status) || !status.Active)
         {
            return false;
         }

         ItineraryFeedbackPoint fp = this.FeedbackSequence[0];
         this.FeedbackSequence.Remove(fp);

         switch (fp.Action)
         {
            case ItineraryFeedbackPoint.FeedbackAction.CompleteRoute:
               this.RouteCompleted(fp.Route);
               break;

            case ItineraryFeedbackPoint.FeedbackAction.Brake:
               // Start braking to 20% of current speed
               break;

            case ItineraryFeedbackPoint.FeedbackAction.Stop:
               // Stop train
               this.RouteCompleted(fp.Route);
               break;

            case ItineraryFeedbackPoint.FeedbackAction.Skip:
            default:
               break;
         }

         return true;
      }

      /// <summary>
      /// Starts the train route.
      /// </summary>
      public void Run()
      {
         this.Enabled = true;
      }

      public override string ToString()
      {
         return string.Format("Train {0} from {1} to {2}", this.Train, this.FromBlock, this.ToBlock);
      }

      #endregion

      #region Private Members

      private void RouteCompleted(Route route)
      {
         // Deactivate current route
         route.Deactivate();
         this.PendingRoutes.Remove(route);

         // Activate next route (if exist)
         this.CompletedRoutes.Add(route);
         if (this.PendingRoutes.Count > 0) this.PendingRoutes[0].Activate();

         // Move train into new block
         Element.AssignTrain(this.Train, route.ToBlock);

         // Update the itinerary status
         this.Completed = (this.PendingRoutes.Count <= 0);
         this.Enabled = (this.PendingRoutes.Count > 0);
      }

      #endregion

   }
}
