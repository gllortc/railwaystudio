using Rwm.Otc.Layout;
using Rwm.Otc.Utils;
using System.Drawing;
using System.Windows.Forms;

namespace Rwm.Otc.UI.Controls
{
   /// <summary>
   /// Control to edit routes in a switchboard.
   /// </summary>
   public partial class SwitchboardRouteEditorControl : SwitchboardControlBase
   {

      #region Constants

      private static Color COLOR_SELECTED = Color.LightSkyBlue;

      private static Color COLOR_PANEL = Color.LightGray;

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="SwitchboardRouteEditorControl"/>.
      /// </summary>
      public SwitchboardRouteEditorControl() : base(false) { }

      /// <summary>
      /// Returns a new instance of <see cref="SwitchboardRouteEditorControl"/>.
      /// </summary>
      /// <param name="switchboard">Switchboard to paint.</param>
      /// <param name="route">Route to edit in control.</param>
      public SwitchboardRouteEditorControl(Switchboard switchboard, Route route)
         : base(switchboard, false)
      {
         this.Initialize(route);
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the route that is shown in the control.
      /// </summary>
      public Route Route { get; private set; }

      ///// <summary>
      ///// Gets the panel shown in the control.
      ///// </summary>
      //public Switchboard Switchboard { get; private set; }

      //public Color SelectedCellColor { get; set; }

      //public Color SwitchboardPanelBackgroundColor { get; set; }

      ///// <summary>
      ///// Gets the coordinates of the current selected cell.
      ///// </summary>
      //public Coordinates SelectedCell { get; private set; }

      #endregion

      #region Methods

      //public void Draw()
      //{
      //   this.SwitchboardPanelControl_Paint(this, new PaintEventArgs(this.CreateGraphics(), new Rectangle()));
      //}

      //public void RepaintElement(Coordinates coords)
      //{
      //   ElementBase element;
      //   Rectangle rect = new Rectangle(this.GetElementPosition(coords), OTCContext.Project.Theme.ElementSize);

      //   using (Graphics g = this.CreateGraphics())
      //   {
      //      // Delete cell drawings
      //      this.RemoveCellImage(g, rect);

      //      // If the cell have a element, redraw the element
      //      element = OTCContext.Project.Elements.Get(this.Switchboard, coords);
      //      if (element != null)
      //      {
      //         this.DrawCellImage(g, rect.Location, element);
      //      }

      //      // Draw a cell highlight layer
      //      if (this.SelectedCell != null)
      //      {
      //         if (this.SelectedCell.Equals(coords))
      //         {
      //            this.DrawCellHighlight(g, rect);
      //         }
      //      }
      //   }
      //}

      //public void SelectCell(int col, int row)
      //{
      //   this.SelectCell(new Coordinates(col, row));
      //}

      //public void SelectCell(Coordinates coords)
      //{
      //   ElementBase element;
      //   Rectangle rect = new Rectangle(this.GetElementPosition(coords), OTCContext.Project.Theme.ElementSize);

      //   using (Graphics g = this.CreateGraphics())
      //   {
      //      if (this.SelectedCell != null)
      //      {
      //         Rectangle selrect = new Rectangle(GetElementPosition(this.SelectedCell), OTCContext.Project.Theme.ElementSize);

      //         // Delete cell drawings
      //         this.RemoveCellImage(g, selrect);

      //         // If the cell have a element, redraw the element
      //         element = OTCContext.Project.Elements.Get(this.Switchboard, this.SelectedCell);
      //         if (element != null)
      //         {
      //            this.DrawCellImage(g, selrect.Location, element);
      //         }
      //      }

      //      // Draw a cell highlight layer
      //      this.DrawCellHighlight(g, rect);
      //   }

      //   // Save the current selected cell position
      //   this.SelectedCell = coords;
      //}

      //public void UnselectCell(Coordinates coords)
      //{
      //   ElementBase element;
      //   Rectangle rect = new Rectangle(GetElementPosition(coords), OTCContext.Project.Theme.ElementSize);

      //   using (Graphics g = this.CreateGraphics())
      //   {
      //      // Delete cell drawings
      //      this.RemoveCellImage(g, rect);

      //      // If the cell have a element, redraw the element
      //      element = OTCContext.Project.Elements.Get(this.Switchboard, coords);
      //      if (element != null)
      //      {
      //         this.DrawCellImage(g, rect.Location, element);
      //      }
      //   }

      //   this.SelectedCell = null;
      //}

      //public void UnselectCell()
      //{
      //   if (this.SelectedCell != null)
      //   {
      //      this.UnselectCell(this.SelectedCell);
      //   }
      //}

      public void SetRouteCell(Coordinates coords)
      {
         Element element;
         Rectangle rect = new Rectangle(this.GetElementPosition(coords), OTCContext.Project.Theme.ElementSize);

         using (Graphics g = this.CreateGraphics())
         {
            if (this.SelectedCell != null)
            {
               Rectangle selrect = new Rectangle(this.GetElementPosition(this.SelectedCell), OTCContext.Project.Theme.ElementSize);

               // Delete cell drawings
               this.RemoveCellImage(g, selrect);

               // If the cell have a element, redraw the element
               element = this.Switchboard.GetBlock(this.SelectedCell);
               if (element != null)
               {
                  this.DrawCellImage(g, selrect.Location, element);
               }
            }

            // Draw a cell highlight layer
            this.DrawCellHighlight(g, rect);
         }

         // Save the current selected cell position
         this.SelectedCell = coords;
      }

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

         Coordinates coords = new Coordinates((e.X + this.HorizontalScroll.Value) / OTCContext.Project.Theme.ElementSize.Width,
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

         Coordinates coords = new Coordinates((e.X + this.HorizontalScroll.Value) / OTCContext.Project.Theme.ElementSize.Width,
                                              (e.Y + this.VerticalScroll.Value) / OTCContext.Project.Theme.ElementSize.Height);
         Element element = this.Switchboard.GetBlock(coords);

         if (this.ElementDoubleClick != null && element != null)
         {
            this.ElementDoubleClick(this, new CellClickEventArgs(this, coords, element));
         }
      }

      #endregion

      #region Private Members

      private void Initialize(Route route)
      {
         this.Route = route;
      }

      internal override void BeforePaint()
      {
         if (this.Route != null)
         {
            this.Route.Activate();
         }
      }

      private void DesignRouteClickDispatcher(Element element)
      {
         RouteElement re = null;

         // Avoid add no routebale elements to the route
         if (element == null) return;

         // Set next route status
         element.SetRouteNextStatus();

         if (!element.IsActivatedInRoute)
         {
            this.Route.RemoveByElement(element);
         }
         else
         {
            re = this.Route.GetByElement(element);
            if (re == null)
            {
               re = new RouteElement();
               re.ID = element.ID;
               re.Element = element;
               re.Route = this.Route;
            }
            re.AccessoryStatus = element.AccessoryStatus;

            this.Route.Add(re);
         }

         this.RepaintCoordinates(element.Coordinates);
      }

      private void ClearRoute()
      {
         //this.CurrentRoute = new List<BlockBase>();
      }

      #endregion

   }
}
