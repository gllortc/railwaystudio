namespace Rwm.Otc.Layout.Elements
{

   /// <summary>
   /// Interface implemented by all routable element (blocks that can be included in a route).
   /// </summary>
   public interface IRoutable
   {

      /// <summary>
      /// Gets or sets a value indicating if the element is activated in a route.
      /// </summary>
      bool ActivatedInRoute { get; }

      /// <summary>
      /// Set next status for the element in the current route.
      /// </summary>
      void SetRouteNextStatus();

      /// <summary>
      /// Activate/deactivate the element in a route). 
      /// </summary>
      /// <param name="activated">A value indicating if the element will be activated or deactivated.</param>
      void SetInRoute(bool activated);

   }
}
