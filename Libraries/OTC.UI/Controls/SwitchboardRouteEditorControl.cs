using System;
using System.Drawing;
using System.Windows.Forms;
using Rwm.Otc.Layout;

namespace Rwm.Otc.UI.Controls
{
   /// <summary>
   /// Control to edit routes in a switchboard.
   /// </summary>
   public partial class SwitchboardRouteEditorControl : SwitchboardControlBase
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="SwitchboardRouteEditorControl"/>.
      /// </summary>
      /// <param name="switchboard">Switchboard to paint.</param>
      /// <param name="route">Route to edit in control.</param>
      public SwitchboardRouteEditorControl(Switchboard switchboard, Route route = null)
         : base(switchboard, false)
      {
         this.Route = route;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the route that is shown in the control.
      /// </summary>
      public Route Route { get; private set; } = null;

      #endregion

      #region Events

      // A delegate type for hooking up change notifications.
      public delegate void CellClickedEventHandler(object sender, CellClickEventArgs e);

      // An event that clients can use to be notified whenever the elements of the list change.
      public event CellClickedEventHandler CellClick;

      // A delegate type for hooking up change notifications.
      public delegate void BlockClickedEventHandler(object sender, CellClickEventArgs e);

      // An event that clients can use to be notified whenever the elements of the list change.
      public event BlockClickedEventHandler ElementClick;

      // A delegate type for hooking up change notifications.
      public delegate void BlockDoubleClickedEventHandler(object sender, CellClickEventArgs e);

      // An event that clients can use to be notified whenever the elements of the list change.
      public event BlockDoubleClickedEventHandler ElementDoubleClick;

      #endregion

      #region Event Handlers

      protected override void OnMouseClick(MouseEventArgs e)
      {
         if (this.Switchboard == null)
         {
            return;
         }

         Point coords = new Point((e.X + this.HorizontalScroll.Value) / OTCContext.Project.Theme.ElementSize.Width,
                                  (e.Y + this.VerticalScroll.Value) / OTCContext.Project.Theme.ElementSize.Height);
         Element element = this.Switchboard.GetBlock(coords);

         this.DesignRouteClickDispatcher(element);

         if (this.CellClick != null)
         {
            this.CellClick(this, new CellClickEventArgs(this, coords, element));
         }

         if (this.ElementClick != null && element != null)
         {
            this.ElementClick(this, new CellClickEventArgs(this, coords, element));
         }
      }

      protected override void OnMouseDoubleClick(MouseEventArgs e)
      {
         if (this.Switchboard == null)
         {
            return;
         }

         Point coords = new Point((e.X + this.HorizontalScroll.Value) / OTCContext.Project.Theme.ElementSize.Width,
                                  (e.Y + this.VerticalScroll.Value) / OTCContext.Project.Theme.ElementSize.Height);
         Element element = this.Switchboard.GetBlock(coords);

         if (this.ElementDoubleClick != null && element != null)
         {
            this.ElementDoubleClick(this, new CellClickEventArgs(this, coords, element));
         }
      }

      protected void OnRouteElementRemovedChanged(object sender, EventArgs e)
      {
         ElementEventArgs args = null;
         if (sender is ToolStripMenuItem item) args = item.Tag as ElementEventArgs;

         if (args != null && args.Element.RouteElement != null)
         {
            this.Route.RemoveByElement(args.Element);
            args.Element.RouteElement = null;

            this.RepaintCoordinates(args.Element.Coordinates);
         }
      }

      protected void OnAccessoryStatusChanged(object sender, EventArgs e)
      {
         ElementEventArgs args = null;
         if (sender is ToolStripMenuItem item) args = item.Tag as ElementEventArgs;

         if (args != null)
         {
            if (args.Element.RouteElement == null)
            {
               args.Element.RouteElement = new RouteElement(this.Route, args.Element);
               this.Route.Elements.Add(args.Element.RouteElement);
            }

            args.Element.RouteElement.AccessoryStatus = args.NewAccessoryStatus;

            this.RepaintCoordinates(args.Element.Coordinates);
         }
      }

      protected void OnElementActivatedChanged(object sender, EventArgs e)
      {
         ElementEventArgs args = null;
         if (sender is ToolStripMenuItem item) args = item.Tag as ElementEventArgs;

         if (args != null && args.Element.RouteElement != null)
         {
            args.Element.RouteElement.Activated = !args.Element.RouteElement.Activated;

            this.RepaintCoordinates(args.Element.Coordinates);
         }
      }

      #endregion

      #region Private Members

      public override void BeforePaint()
      {
         if (this.Route != null)
         {
            this.Route.Activate();
         }
      }

      private void DesignRouteClickDispatcher(Element element)
      {
         // Avoid add no routebale elements to the route
         if (element == null || !element.Properties.IsRouteable) 
            return;

         if (element.Properties.IsAccessory)
         {
            this.ShowAccessoryMenu(element);
         }
         else
         {
            // Get the corresponding route element
            RouteElement routeElement = this.Route.GetByElement(element);
            if (routeElement == null)
            {
               routeElement = new RouteElement(this.Route, element);
               this.Route.Elements.Add(routeElement);
               element.RouteElement = routeElement;
               // RouteElement.Save(routeElement);
            }

            routeElement.SetNextStatus();

            if (!routeElement.IsValid)
            {
               this.Route.RemoveByElement(element);
               // RouteElement.Delete(routeElement);
               element.RouteElement = null;
            }

            this.RepaintCoordinates(element.Coordinates);
         }
      }

      private void ShowAccessoryMenu(Element element)
      {
         if (element == null) return;

         ToolStripMenuItem item;
         ContextMenuStrip menu = new ContextMenuStrip();

         item = new ToolStripMenuItem("Remove from route", 
                        Properties.Resources.ICO_REMOVE_16,
                        new EventHandler(OnRouteElementRemovedChanged));
         item.Enabled = (element.RouteElement != null);
         item.Tag = new ElementEventArgs(element);
         menu.Items.Add(item);

         menu.Items.Add("-");

         foreach (int status in element.GetAllAccessoryStatusValues())
         {
            item = new ToolStripMenuItem(element.Properties.GetStatusDescription(status), 
                                         element.GetImage(OTCContext.Project.Theme, false),
                                         new EventHandler(OnAccessoryStatusChanged));
            item.Tag = new ElementEventArgs(element, status);
            item.CheckOnClick = true;
            item.Checked = (element.RouteElement == null ? false : (element.RouteElement.AccessoryStatus == status));

            menu.Items.Add(item);
         }

         menu.Items.Add("-");

         item = new ToolStripMenuItem("Show activated in route", null, new EventHandler(OnElementActivatedChanged));
         item.Tag = new ElementEventArgs(element);
         item.CheckOnClick = true;
         item.Checked = (element.RouteElement != null ? element.RouteElement.Activated : false);
         item.Enabled = (element.RouteElement != null);
         menu.Items.Add(item);

         menu.Show(Cursor.Position);
      }

      #endregion

   }
}
