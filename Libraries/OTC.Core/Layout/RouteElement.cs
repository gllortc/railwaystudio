using System;
using Rwm.Otc.Data;

namespace Rwm.Otc.Layout
{
   /// <summary>
   /// Route element.
   /// </summary>
   [ORMTable("ROUTE_ELEMENTS")]
   public class RouteElement : ORMEntity<RouteElement>, IComparable<RouteElement>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="RouteElement"/>.
      /// </summary>
      public RouteElement() { }

      /// <summary>
      /// Returns a new instance of <see cref="RouteElement"/>.
      /// </summary>
      /// <param name="route">Owner <see cref="Route"/>.</param>
      /// <param name="element">Related switchboard <see cref="Element"/>.</param>
      public RouteElement(Route route, Element element) 
      {
         this.Route = route;
         this.Element = element;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; } = 0;

      /// <summary>
      /// Gets or sets the related element.
      /// </summary>
      [ORMProperty("elementid")]
      public Element Element { get; set; } = null;

      /// <summary>
      /// Gets or sets the related route.
      /// </summary>
      [ORMProperty("routeid")]
      public Route Route { get; set; } = null;

      /// <summary>
      /// Gets or sets the status of the element.
      /// </summary>
      [ORMProperty("status")]
      public int AccessoryStatus { get; set; } = Element.STATUS_UNDEFINED;

      /// <summary>
      /// Gets or sets a value indicating if the route element must be shown activated (yellow marker).
      /// </summary>
      [ORMProperty("activated")]
      public bool Activated { get; set; } = false;

      /// <summary>
      /// Gets a value indicating if the route element is valid or invalid. Invalid element should be removed from the route.
      /// </summary>
      public bool IsValid
      {
         get { return !(this.AccessoryStatus == Element.STATUS_UNDEFINED && !this.Activated); }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Gets the next status for the specified current status.
      /// </summary>
      public void SetNextStatus()
      {
         if (this.Element == null)
            return;

         // Get new accessory status
         if (this.Element.Properties.IsAccessory)
         {
            if (this.AccessoryStatus <= Element.STATUS_UNDEFINED)
               this.AccessoryStatus = 1;
            else if (this.AccessoryStatus == this.Element.Properties.AccessoryMaxStats)
               this.AccessoryStatus = Element.STATUS_UNDEFINED;
            else
               this.AccessoryStatus = this.AccessoryStatus + 1;
         }

         // Set activated/deactivated
         if (!this.Element.Properties.IsAccessory || this.AccessoryStatus <= 1) 
            this.Activated = !this.Activated;
      }

      /// <summary>
      /// Compare two instances to allow sorting the list with accessory activation order:
      ///   1 -> Turnouts
      ///   2 -> Signals / Red
      ///   3 -> Signals / Green
      /// </summary>
      /// <param name="other">Other instance to compare with.</param>
      /// <returns>An integer indicating if the <paramref name="other"/> is less, equals or greater than current instance.</returns>
      public int CompareTo(RouteElement other)
      {
         return this.Element.Properties.ActivationOrder.CompareTo(other.Element.Properties.ActivationOrder);
      }

      #endregion

   }
}
