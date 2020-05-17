using System;
using System.Collections.Generic;
using System.Linq;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Systems;

namespace Rwm.Otc.Layout.Traffic
{
   /// <summary>
   /// Layout traffic manager.
   /// </summary>
   public class TrafficManager
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="TrafficManager"/>.
      /// </summary>
      public TrafficManager()
      {
         this.LoadItineraries();
      }

      #endregion

      #region Properties

      public static List<Itinerary> ActiveItineraries { get; private set; } = new List<Itinerary>();

      #endregion

      #region Events

      /// <summary>
      /// Event raised when traffic suffer a change.
      /// </summary>
      public event EventHandler TrafficStatusChanged;

      #endregion

      #region Methods

      /// <summary>
      /// Reset all planned or running traffic.
      /// </summary>
      public void Reset()
      {
         Route.ClearAll();
         TrafficManager.ActiveItineraries.Clear();
      }

      /// <summary>
      /// Inform the traffic manager of any feedback received from the layout.
      /// </summary>
      /// <param name="status">Feedback status received.</param>
      /// <param name="element">Affected element.</param>
      public void FeedbackReceived(FeedbackPointAddressStatus status, Element element)
      {
         Logger.LogDebug(this, "[CLASS].FeedbackReceived([{0}], [{1}])", status, element);

         foreach (Itinerary itinerary in TrafficManager.ActiveItineraries)
         {
            if (itinerary.FeedbackReceived(status, element))
               break;
         }
      }

      /// <summary>
      /// Get all blocks that can be reached from the specified block.
      /// </summary>
      /// <param name="block">Current block.</param>
      public List<Element> GetDestinationsFromBlock(Element block)
      {
         List<Element> elements = new List<Element>();

         Logger.LogDebug(this, "[CLASS].GetDestinationsFromBlock([{0}])", block);

         // Check provided data
         if (!block.Properties.IsBlock)
            throw new Exception("Provided element is not a block.");

         foreach (Switchboard switchboard in OTCContext.Project.Switchboards)
         {
            foreach (Element element in switchboard.Elements)
            {
               if (element.Properties.IsDestination && block != element)
               {
                  elements.Add(element);
               }
            }
         }

         return elements.OrderBy(o => o.DisplayName).ToList();
      }

      /// <summary>
      /// Find a route sequence to reach the destination block from the specified block.
      /// </summary>
      /// <param name="itinerary">Planned itinerary.</param>
      /// <returns>A value indicating if the itinerary can be completed (a valid route could be found).</returns>
      /// <remarks>The instance of <see cref="Itinerary"/> will be updated with all routes to follow to complete the itinerary.</remarks>
      public bool FindItinerary(Itinerary itinerary)
      {
         Logger.LogDebug(this, "[CLASS].FindItinerary([{0}])", itinerary);

         itinerary.PendingRoutes = this.FindItineraryRoutes(itinerary.FromBlock, itinerary.ToBlock);
         if (itinerary.PendingRoutes != null && itinerary.PendingRoutes.Count > 0)
         {
            itinerary.PendingRoutes.Reverse();
            return true;
         }
         else
            return false;
      }

      /// <summary>
      /// Add a new <see cref="Itinerary"/> to be managed by traffic manager.
      /// </summary>
      /// <param name="itinerary">Planned itinerary.</param>
      /// <param name="automaticRun">A value indicating if the <paramref name="itinerary"/> will be activated automatically after adding the new itinerary.</param>
      /// <remarks>The instance of <see cref="Itinerary"/> will be updated with all routes to follow to complete the itinerary.</remarks>
      public void AddItinerary(Itinerary itinerary, bool automaticRun = true)
      {
         Logger.LogDebug(this, "[CLASS].AddItinerary([{0}])", itinerary);

         // Initialize the itinerary
         itinerary.SetItinerary(this.FindItineraryRoutes(itinerary.FromBlock, itinerary.ToBlock));

         // Add the itinerary to the traffic manager
         TrafficManager.ActiveItineraries.Add(itinerary);

         // Run the itinerary
         if (automaticRun)
            this.RunItinerary(itinerary);

         this.TrafficStatusChanged?.Invoke(this, new EventArgs());
      }

      /// <summary>
      /// Stop and remove the specified itinerary from the traffic manager.
      /// </summary>
      /// <param name="itinerary">Itinerary to remove.</param>
      public void RemoveItinerary(Itinerary itinerary)
      {
         Logger.LogDebug(this, "[CLASS].RemoveItinerary([{0}])", itinerary);

         if (TrafficManager.ActiveItineraries.Contains(itinerary))
         {
            // Deactivate all routes uded 
            if (itinerary.Enabled)
            {
               foreach (Route route in itinerary.PendingRoutes)
               {
                  if (route.IsActive) route.Deactivate();
               }
            }

            // Remove the itinerary from the current itineraries queue
            TrafficManager.ActiveItineraries.Remove(itinerary);
            this.TrafficStatusChanged?.Invoke(this, new EventArgs());
         }
      }

      public void RunItinerary(Itinerary itinerary)
      {
         itinerary.PendingRoutes[0].Activate();
      }

      #endregion

      #region Event Handlers

      #endregion

      #region Private Members

      /// <summary>
      /// Loads all routes between blocks in memory.
      /// </summary>
      private void LoadItineraries()
      {
         foreach (Element element in Element.FindAll())
         {
            if (element.Properties.IsBlock)
            {
               foreach (Route route in OTCContext.Project.Routes)
               {
                  if (route.IsBlock)
                  {
                     if (element == route.FromBlock)
                     {
                        if (element.RoutesFromHere == null)
                           element.RoutesFromHere = new List<Route>();

                        element.RoutesFromHere.Add(route);
                     }
                     else if (element == route.ToBlock)
                     {
                        if (element.RoutesToHere == null)
                           element.RoutesToHere = new List<Route>();

                        element.RoutesToHere.Add(route);
                     }
                  }
               }
            }
         }
      }

      /// <summary>
      /// Find a route sequence to reach the destination block from the specified block.
      /// </summary>
      /// <param name="fromBlock">Origin block.</param>
      /// <param name="toBlock">Destination block.</param>
      /// <returns>A list of <see cref="Route"/> that should be followed to reach the desired destination block.</returns>
      private List<Route> FindItineraryRoutes(Element fromBlock, Element toBlock)
      {
         List<Route> routes;

         Logger.LogDebug(this, "[CLASS].FindItineraryRoutes([{0}], [{1}])", fromBlock, toBlock);

         // Check provided data
         if (!fromBlock.Properties.IsBlock || !toBlock.Properties.IsBlock)
            throw new Exception("FROM and TO should be a block elements.");
         if (!toBlock.Properties.IsDestination)
            throw new Exception("TO should be a destination block elements.");

         if (fromBlock.RoutesFromHere == null)
            return null;

         foreach (Route route in fromBlock.RoutesFromHere)
         {
            routes = new List<Route>();

            if (route.ToBlock == toBlock)
            {
               routes.Add(route);
               return routes;
            }
            else
            {
               routes = this.FindItineraryRoutes(route.ToBlock, toBlock);
               if (routes != null && routes.Count > 0)
               {
                  routes.Add(route);
                  return routes;
               }
            }
         }

         return null;
      }

      #endregion

   }
}
