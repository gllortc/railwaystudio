using System.Collections.Generic;
using Rwm.Otc.Data;

namespace Rwm.Otc.Layout
{
   /// <summary>
   /// Implements a route into the layout.
   /// </summary>
   [ORMTable("ROUTES")]
   public class Route : ORMEntity<Route>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Route"/>.
      /// </summary>
      public Route() { }

      /// <summary>
      /// Returns a new instance of <see cref="Route"/>.
      /// </summary>
      /// <param name="project">Owner <see cref="Project"/>.</param>
      /// <param name="name">Name of the route.</param>
      public Route(Project project, string name = "")
      {
         this.Project = project;
         this.Name = name;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; } = 0;

      /// <summary>
      /// Gets or sets the owner switchboard.
      /// </summary>
      [ORMProperty("PROJECTID")]
      public Project Project { get; set; } = null;

      /// <summary>
      /// Gets or sets the route name.
      /// </summary>
      [ORMProperty("NAME")]
      public string Name { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets the route description.
      /// </summary>
      [ORMProperty("DESCRIPTION")]
      public string Description { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets a value indicating the time interval between accessory activations.
      /// </summary>
      [ORMProperty("SWITCHTIME")]
      public int SwitchTime { get; set; } = 0;

      /// <summary>
      /// Gets or sets a value indicating if the route corresponds to a block.
      /// </summary>
      [ORMProperty("ISBLOCK")]
      public bool IsBlock { get; set; } = false;

      /// <summary>
      /// Gets or sets the source block element.
      /// </summary>
      [ORMProperty("FROMBLOCK")]
      public Element FromBlock { get; set; } = null;

      /// <summary>
      /// Gets or sets the destination block element.
      /// </summary>
      [ORMProperty("TOBLOCK")]
      public Element ToBlock { get; set; } = null;

      /// <summary>
      /// Gets or sets a value indicating if the route is bidirectional or only in direction from->to.
      /// </summary>
      [ORMProperty("BIDIRECTIONAL")]
      public bool IsBidirectionl { get; set; } = true;

      /// <summary>
      /// Gets or sets the route description.
      /// </summary>
      [ORMProperty("NOTES")]
      public string Notes { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets the element list.
      /// </summary>
      [ORMForeignCollection(ORMForeignCollection.OnDeleteActionTypes.DeleteInCascade)]
      public List<RouteElement> Elements { get; set; } = new List<RouteElement>();

      /// <summary>
      /// Gets a value indicating if the current route has been activated in current project.
      /// </summary>
      public bool IsActive
      {
         get { return OTCContext.Project.ActiveRoutes.ContainsKey(this.ID); }
      }

      /// <summary>
      /// Gets the associated small icon (16x16px).
      /// </summary>
      public static System.Drawing.Image SmallIcon
      {
         get { return Properties.Resources.ICO_ROUTE_16; }
      }

      /// <summary>
      /// Gets the associated large icon (32x32px).
      /// </summary>
      public static System.Drawing.Image LargeIcon
      {
         get { return Properties.Resources.ICO_ROUTE_32; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Get a route element by its associated element.
      /// </summary>
      /// <param name="item">Element.</param>
      public RouteElement GetByElement(Element item)
      {
         foreach (RouteElement re in this.Elements)
         {
            if (re.Element != null && re.Element.ID == item.ID) 
               return re;
         }

         return null;
      }

      /// <summary>
      /// Remove a route element from the current route.
      /// </summary>
      /// <param name="item">Item to remove.</param>
      public void RemoveByElement(Element item)
      {
         RouteElement toRemove = null;

         foreach (RouteElement re in this.Elements)
         {
            if (re.Element.ID == item.ID)
            {
               toRemove = re;
               break;
            }
         }

         if (toRemove != null) 
            this.Elements.Remove(toRemove);
      }

      /// <summary>
      /// Check if current <see cref="Route"/> can be activated by checking with current activated routes in project.
      /// </summary>
      /// <returns>A value indicating if the route can be activated or not.</returns>
      public bool IsActivationAllowed()
      {
         if (this.Project.ActiveRoutes.Count <= 0)
            return true;

         foreach (Route route in this.Project.ActiveRoutes.Values)
         {
            if (route.Match(this))
               return false;
         }

         return true;
      }

      /// <summary>
      /// Activate the route in current project.
      /// </summary>
      /// <returns>A value indicating if the route has been activated or not.</returns>
      public bool Activate()
      {
         if (!this.IsActivationAllowed())
            return false;

         foreach (RouteElement routeElement in this.Elements)
         {
            if (routeElement.Element != null && routeElement.Element.Properties.IsRouteable)
            {
               routeElement.Element.RouteElement = routeElement;

               // Raise image changed event to repaint element
               this.Project.ElementImageChanged(routeElement.Element);
            }
         }

         // Set the active route
         if (this.Project.ActiveRoutes.ContainsKey(this.ID))
            this.Project.ActiveRoutes[this.ID] = this;
         else
            this.Project.ActiveRoutes.Add(this.ID, this);

         return true;
      }

      /// <summary>
      /// Deactivate the current route from the current project.
      /// </summary>
      public void Deactivate()
      {
         foreach (RouteElement routeElement in this.Elements)
         {
            if (routeElement.Element != null && routeElement.Element.Properties.IsRouteable)
            {
               routeElement.Element.RouteElement = null;

               // Raise image changed event to repaint element
               this.Project.ElementImageChanged(routeElement.Element);
            }
         }

         // Deactivate current route in project
         this.Project.ActiveRoutes.Remove(this.ID);
      }

      /// <summary>
      /// Check if a <see cref="Route"/> hav one or more elements at same coordinates.
      /// </summary>
      /// <param name="route"><see cref="Route"/> to check with the current route.</param>
      /// <returns>Return a value that indicates if <paramref name="route"/> have any matching element or not.</returns>
      public bool Match(Route route)
      {
         foreach (RouteElement routeElement in this.Elements)
         {
            foreach (RouteElement exRouteElement in route.Elements)
            {
               if (routeElement.Element.Coordinates.Equals(exRouteElement.Element.Coordinates))
                  return true;
            }
         }

         return false;
      }

      /// <summary>
      /// Return a string representing the instance.
      /// </summary>
      public override string ToString()
      {
         return this.Name;
      }

      #endregion

      #region Static Members

      /// <summary>
      /// Clear all active routes from current project.
      /// </summary>
      public static void ClearAll()
      {
         if (OTCContext.Project.ActiveRoutes.Count <= 0)
            return;

         // Get all active routes IDs
         List<long> ids = new List<long>();
         ids.AddRange(OTCContext.Project.ActiveRoutes.Keys);

         // Deactivate all routes
         foreach (long id in ids)
         {
            if (OTCContext.Project.ActiveRoutes.ContainsKey(id))
            {
               Route route = OTCContext.Project.ActiveRoutes[id];
               route.Deactivate();
            }
         }
      }

      #endregion

   }
}
