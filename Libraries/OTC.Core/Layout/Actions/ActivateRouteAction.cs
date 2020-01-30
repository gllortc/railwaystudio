using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using System;
using System.Drawing;

namespace Rwm.Otc.Layout.Actions
{
   /// <summary>
   /// Action to activate a route.
   /// </summary>
   public class ActivateRouteAction : ElementAction
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ActivateRouteAction"/>.
      /// </summary>
      public ActivateRouteAction() : base() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the icon assigned to the action.
      /// </summary>
      public override Image Icon
      {
         get { return Otc.Properties.Resources.ICO_ROUTE_16; }
      }

      /// <summary>
      /// Gets or sets the route that shoulf be activated.
      /// </summary>
      public long RouteID
      {
         get { return this.IntegerParameter1; }
         set { this.IntegerParameter1 = (int)value; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Execute the action.
      /// </summary>
      /// <param name="element">Parameter to remove!</param>
      /// <param name="project">Project where the action must be executed.</param>
      /// <param name="system">System used to execute the digital commands.</param>
      public override void Execute(Element element, Project project)
      {
         try
         {
            Route route = Route.Get(this.RouteID);
            route.Activate();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      #endregion

   }
}
