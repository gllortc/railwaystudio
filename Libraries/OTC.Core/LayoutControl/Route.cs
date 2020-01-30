using Rwm.Otc.LayoutControl.Elements;
using System;
using System.Collections.Generic;

namespace Rwm.Otc.LayoutControl
{
   /// <summary>
   /// Implements a route into the layout.
   /// </summary>
   public class Route
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
      /// Gets or sets the route unique identifier (DB).
      /// </summary>
      public int ID { get; set; }

      /// <summary>
      /// Gets or sets the route name.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets the route name.
      /// </summary>
      public string Description { get; set; }

      /// <summary>
      /// Gets or sets the source block element unique identifier.
      /// </summary>
      internal int FromBlockID { get; set; }

      /// <summary>
      /// Gets or sets the source block element.
      /// </summary>
      public ElementBase FromBlock { get; set; }

      /// <summary>
      /// Gets or sets the destination block element unique identifier.
      /// </summary>
      internal int ToBlockID { get; set; }

      /// <summary>
      /// Gets or sets the destination block element.
      /// </summary>
      public ElementBase ToBlock { get; set; }
      
      /// <summary>
      /// Gets or sets the element list.
      /// </summary>
      public List<RouteElement> Elements { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Create all route blocks using the information in a list of witchboard blocks.
      /// </summary>
      /// <param name="elements">A list of <see cref="ElementBase"/>.</param>
      public void SetElements(List<ElementBase> elements)
      {
         this.Elements = new List<RouteElement>();

         foreach (ElementBase elem in elements)
         {
            this.Elements.Add(new RouteElement(elem));
         }
      }

      public void Add(ElementBase element)
      {
         foreach (RouteElement elem in this.Elements)
         {
            if (elem.ElementID == element.ID)
            {
               elem.AccessoryStatus = ElementBase.GetAccessoryStatus(element);
               return;
            }
         }

         this.Elements.Add(new RouteElement(element));
      }

      /// <summary>
      /// Activate the route.
      /// </summary>
      /// <param name="project">Project where the route must be activated.</param>
      public void ActivateRoute(Project project)
      {
         project.ActivateRoute(this);
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
         this.FromBlockID = 0;
         this.FromBlock = null;
         this.ToBlockID = 0;
         this.ToBlock = null;
         this.Elements = new List<RouteElement>();
      }

      #endregion

   }
}
