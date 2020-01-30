using Rwm.Otc.LayoutControl.Elements;

namespace Rwm.Otc.LayoutControl
{
   /// <summary>
   /// Route element.
   /// </summary>
   public class RouteElement
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="RouteElement"/>.
      /// </summary>
      public RouteElement()
      {
         Initialize();
      }

      /// <summary>
      /// Returns a new instance of <see cref="RouteElement"/>.
      /// </summary>
      /// <param name="element">Element that contains the information to initialize the route element.</param>
      public RouteElement(ElementBase element)
      {
         Initialize();

         this.ElementID = element.ID;

         IAccessory accElement = element as IAccessory;
         if (accElement != null)
         {
            this.AccessoryStatus = accElement.GetAccessoryStatus();
         }
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the route unique identifier (DB).
      /// </summary>
      public int ID { get; set; }

      /// <summary>
      /// Gets or sets the related panel unique identifier.
      /// </summary>
      public int ElementID { get; set; }

      /// <summary>
      /// Gets or sets the related route unique identifier.
      /// </summary>
      public int RouteID { get; set; }

      /// <summary>
      /// Gets or sets the status of the element.
      /// </summary>
      public int AccessoryStatus { get; set; }

      #endregion

      #region Methods
      #endregion

      #region Static Members

      /// <summary>
      /// Check if a regular switchboard element is activated in route.
      /// </summary>
      /// <param name="element">The <see cref="ElementBase"/> instance to check.</param>
      /// <returns><c>true</c> if the element is activated in route, otherwise return <c>false</c>.</returns>
      public static bool IsElementActivatedInRoute(ElementBase element)
      {
         if (ElementBase.IsRoutableElement(element))
         {
            return ((IRoutable)element).ActivatedInRoute;
         }

         return false;
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ID = 0;
         this.ElementID = 0;
         this.AccessoryStatus = ElementBase.STATUS_UNDEFINED;
      }

      #endregion

   }
}
