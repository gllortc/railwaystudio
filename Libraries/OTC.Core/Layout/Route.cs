using System.Collections.Generic;
using Rwm.Otc.Data.ORM;

namespace Rwm.Otc.Layout
{
   /// <summary>
   /// Implements a route into the layout.
   /// </summary>
   [ORMTable("routes")]
   public class Route : ORMEntity<Route>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Route"/>.
      /// </summary>
      public Route()
      {
         Initialize();
      }

      /// <summary>
      /// Returns a new instance of <see cref="Route"/>.
      /// </summary>
      /// <param name="name">Name of the route.</param>
      public Route(string name)
      {
         Initialize();

         this.Name = name;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; }

      /// <summary>
      /// Gets or sets the owner switchboard.
      /// </summary>
      [ORMProperty("projectid")]
      public Project Project { get; set; }

      /// <summary>
      /// Gets or sets the route name.
      /// </summary>
      [ORMProperty("name")]
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets the route description.
      /// </summary>
      [ORMProperty("description")]
      public string Description { get; set; }

      /// <summary>
      /// Gets or sets the source block element.
      /// </summary>
      [ORMProperty("fromBlock")]
      public Element FromBlock { get; set; }

      /// <summary>
      /// Gets or sets the destination block element.
      /// </summary>
      [ORMProperty("toBlock")]
      public Element ToBlock { get; set; }

      /// <summary>
      /// Gets or sets a value indicating if the route is bidirectional or only in direction from->to.
      /// </summary>
      [ORMProperty("bidirectional")]
      public bool IsBidirectionl { get; set; }

      /// <summary>
      /// Gets or sets the element list.
      /// </summary>
      // [ORMProperty(PropertyType.ForeignCollection, OnDeleteAction.DeleteInCascade)]
      public List<RouteElement> Elements { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Manually adds a new <see cref="RouteElement"/> into the route controlled elements.<br />
      /// The added item won't be stored in project database: To store the element into database, use <c>Project.Add()</c> method.
      /// </summary>
      /// <param name="item">Item to add.</param>
      public void Add(RouteElement item)
      {
         this.Elements.Add(item);
      }

      /// <summary>
      /// Get a route element by its associated element.
      /// </summary>
      /// <param name="item">Element.</param>
      public RouteElement GetByElement(Element item)
      {
         foreach (RouteElement re in this.Elements)
         {
            if (re.Element != null && re.Element.ID == item.ID) return re;
         }

         return null;
      }

      /// <summary>
      /// Remove a route element from the current route.
      /// </summary>
      /// <param name="item">Item to remove.</param>
      public void Remove(RouteElement item)
      {
         this.Elements.Remove(item);
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

         if (toRemove != null) this.Remove(toRemove);
      }

      /// <summary>
      /// Return a string representing the instance.
      /// </summary>
      public override string ToString()
      {
         return this.Name;
      }

      /// <summary>
      /// Activate the route in current project.
      /// </summary>
      public void Activate()
      {
         // Set the active route
         this.Project.ActiveRoute = this;

         foreach (Switchboard panel in this.Project.Switchboards)
         {
            foreach (Element element in panel.Elements)
            {
               if (element.Properties.IsRouteable)
               {
                  element.SetInRoute(false);

                  foreach (RouteElement routeElem in this.Project.ActiveRoute.Elements)
                  {
                     if (routeElem.Element == element)
                     {
                        element.SetInRoute(true);

                        if (element.Properties.IsAccessory)
                        {
                           element.SetAccessoryStatus(routeElem.AccessoryStatus);
                        }

                        break;
                     }
                  }
               }
            }
         }
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ID = 0;
         this.Name = string.Empty;
         this.Description = string.Empty;
         this.FromBlock = null;
         this.ToBlock = null;
         this.IsBidirectionl = false;
         this.Elements = new List<RouteElement>();
      }

      #endregion

   }
}
