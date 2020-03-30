using Rwm.Otc.Data;

namespace Rwm.Otc.Layout
{
   /// <summary>
   /// Route element.
   /// </summary>
   [ORMTable("routeelements")]
   public class RouteElement : ORMEntity<RouteElement>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="RouteElement"/>.
      /// </summary>
      public RouteElement()
      {
         Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; }

      /// <summary>
      /// Gets or sets the related element.
      /// </summary>
      [ORMProperty("elementid")]
      public Element Element { get; set; }

      /// <summary>
      /// Gets or sets the related route.
      /// </summary>
      [ORMProperty("routeid")]
      public Route Route { get; set; }

      /// <summary>
      /// Gets or sets the status of the element.
      /// </summary>
      [ORMProperty("status")]
      public int AccessoryStatus { get; set; }

      #endregion

      #region Static Members

      /// <summary>
      /// Check if a regular switchboard element is activated in route.
      /// </summary>
      /// <param name="element">The <see cref="ElementBase"/> instance to check.</param>
      /// <returns><c>true</c> if the element is activated in route, otherwise return <c>false</c>.</returns>
      public static bool IsElementActivatedInRoute(Element element)
      {
         return element.IsActivatedInRoute;
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ID = 0;
         this.Element = null;
         // this.RouteID = 0;
         this.Route = null;
         this.AccessoryStatus = Element.STATUS_UNDEFINED;
      }

      #endregion

   }
}
