using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Rwm.Otc;
using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Common.Controls
{
   /// <summary>
   /// Base class to develop specialized classes to represent switchboards.
   /// </summary>
   public abstract class SwitchboardControlBase : DevExpress.XtraEditors.XtraPanel
   {

      #region Constants

      internal static Color COLOR_SELECTED = Color.LightSkyBlue;

      internal static Color COLOR_PANEL = Color.LightGray;

      #endregion

      #region Constructors

      public SwitchboardControlBase(bool designMode)
      {
         InitializeComponent();

         this.DesignModeEnabled = designMode;
      }

      public SwitchboardControlBase(Switchboard sb, bool designMode)
      {
         InitializeComponent();

         this.Switchboard = sb;
         this.DesignModeEnabled = designMode;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the panel shown in the control.
      /// </summary>
      public Switchboard Switchboard { get; internal set; }

      /// <summary>
      /// Gets or sets the switchboards selected cells color.
      /// </summary>
      public Color SelectedCellColor { get; set; } = SwitchboardControlBase.COLOR_SELECTED;

      /// <summary>
      /// Gets or sets the switchboards background color.
      /// </summary>
      public Color SwitchboardPanelBackgroundColor { get; set; } = SwitchboardControlBase.COLOR_PANEL;

      /// <summary>
      /// Gets or sets the active route in the layout.
      /// </summary>
      public Route ActiveRoute { get; set; } = null;

      /// <summary>
      /// Gets the coordinates of the current selected cell.
      /// </summary>
      public Point SelectedCell { get; set; }

      /// <summary>
      /// Gets a value indicating if the switchboard is in design mode.
      /// </summary>
      public bool DesignModeEnabled { get; set; } = false;

      #endregion

      #region Methods

      public void RepaintCoordinates(IEnumerable<Point> coords)
      {
         foreach (Point c in coords) this.RepaintCoordinates(c);
      }

      public void RepaintCoordinates(Point coords)
      {
         int widthInBlocks;
         Element element;
         RouteElement routeElement = null;
         Rectangle rect = new Rectangle(0, 0, 0, 0);
         Point paintCoords;

         // Get involved elements
         element = this.Switchboard.GetBlock(coords);
         if (this.ActiveRoute != null && element != null) routeElement = this.ActiveRoute.GetByElement(element);

         // Get the element placed in coordinates
         widthInBlocks = element != null ? element.Properties.Width : 1;
         paintCoords = element != null ? element.Coordinates : coords;

         using (Graphics g = this.CreateGraphics())
         {
            for (int i = 1; i < widthInBlocks + 1; i++)
            {
               // Get the cell rectabgle
               rect = new Rectangle(this.GetElementPosition(this.GetRealCoordinates(paintCoords)), OTCContext.Project.Theme.ElementSize);

               // Delete cell previous drawing
               this.RemoveCellImage(g, rect);

               // Paint the element (if exists in that position)
               if (element != null) this.DrawCellImage(g, rect.Location, element, routeElement);

               paintCoords.X++;
            }

            // Draw a cell highlight layer
            if (rect != null && this.SelectedCell != null && (this.SelectedCell.Equals(coords)))
            {
               this.DrawCellHighlight(g, rect);
            }
         }
      }

      /// <summary>
      /// Select the specified switchboard cell.
      /// </summary>
      /// <param name="col">Cell column.</param>
      /// <param name="row">Cell row.</param>
      public void SelectCell(int col, int row)
      {
         this.SelectCell(new Point(col, row));
      }

      /// <summary>
      /// Select the specified switchboard cell.
      /// </summary>
      /// <param name="coords">Cell <see cref="Coordinates"/>.</param>
      public virtual void SelectCell(Point coords)
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

      /// <summary>
      /// Unselect the specified cell.
      /// </summary>
      /// <param name="coords">Cell <see cref="Coordinates"/>.</param>
      public void UnselectCell(Point coords)
      {
         Element element;
         Rectangle rect = new Rectangle(GetElementPosition(coords), OTCContext.Project.Theme.ElementSize);

         using (Graphics g = this.CreateGraphics())
         {
            // Delete cell drawings
            this.RemoveCellImage(g, rect);

            // If the cell have a element, redraw the element
            element = this.Switchboard.GetBlock(coords);
            if (element != null)
            {
               this.DrawCellImage(g, rect.Location, element);
            }
         }

         this.SelectedCell = default;
      }

      /// <summary>
      /// Unselect all selected cells.
      /// </summary>
      public void UnselectCell()
      {
         if (this.SelectedCell != null)
         {
            this.UnselectCell(this.SelectedCell);
         }
      }

      /// <summary>
      /// Remove all cell drawings.
      /// </summary>
      public void RemoveCellImage(Graphics g, Rectangle rect)
      {
         using (Brush brush = new SolidBrush(SystemColors.Control))
         {
            g.FillRectangle(brush, rect);
         }

         using (Pen pencil = new Pen(SwitchboardControlBase.COLOR_PANEL, 1f))
         {
            g.DrawRectangle(pencil, rect);
         }
      }

      /// <summary>
      /// Draw a cell overlay (with alpha blend) to hihlight the cell.
      /// </summary>
      public void DrawCellHighlight(Graphics g, Rectangle rect)
      {
         Color color = this.SelectedCellColor;

         // Select new cell
         using (Brush brush = new SolidBrush(Color.FromArgb(75, color)))
         {
            g.FillRectangle(brush, rect);
         }

         using (Pen pencil = new Pen(color, 1f))
         {
            g.DrawRectangle(pencil, rect);
         }
      }

      /// <summary>
      /// Draw the element image on the cell.
      /// </summary>
      public void DrawCellImage(Graphics g, Point point, Element element, RouteElement routeElement = null)
      {
         g.DrawImage(element.GetImage(OTCContext.Project.Theme, this.DesignModeEnabled), point);
      }

      public Point GetElementPosition(Point coords)
      {
         return new Point(coords.X * OTCContext.Project.Theme.ElementSize.Width,
                          coords.Y * OTCContext.Project.Theme.ElementSize.Height);
      }

      public virtual void BeforePaint() { }

      internal virtual void OnPaint(object sender, PaintEventArgs e)
      {
         Point startP = new Point();
         Point endP = new Point();

         // Avoid trying painting null switchboards
         if (this.Switchboard == null) return;

         // Call virtual method to override in case 
         // to need to make some tasks before to paint
         this.BeforePaint();

         this.SuspendLayout();

         using (e.Graphics)
         {
            try
            {
               e.Graphics.Clear(SystemColors.Control);
            }
            catch
            {
               return;
            }

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen pencil = new Pen(Color.LightGray, 1f);

            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size((this.Switchboard.Width * OTCContext.Project.Theme.ElementSize.Width) + 1,
                                              (this.Switchboard.Height * OTCContext.Project.Theme.ElementSize.Height) + 1);

            e.Graphics.TranslateTransform(this.AutoScrollPosition.X,
                                          this.AutoScrollPosition.Y);

            // Draw horizontal lines
            Point origin = new Point(0, 0);
            startP.X = origin.X;
            endP.X = origin.X + this.Switchboard.Width * OTCContext.Project.Theme.ElementSize.Width;
            for (int i = 0; i <= this.Switchboard.Height; i++)
            {
               startP.Y = origin.Y + i * OTCContext.Project.Theme.ElementSize.Height;
               endP.Y = startP.Y;
               e.Graphics.DrawLine(pencil, startP, endP);
            }

            // Draw vertical lines
            startP.Y = origin.Y;
            endP.Y = origin.Y + this.Switchboard.Height * OTCContext.Project.Theme.ElementSize.Height;
            for (int i = 0; i <= this.Switchboard.Width; i++)
            {
               startP.X = origin.X + i * OTCContext.Project.Theme.ElementSize.Width;
               endP.X = startP.X;
               e.Graphics.DrawLine(pencil, startP, endP);
            }

            // Paint blocks
            foreach (Element element in this.Switchboard.Elements)
            {
               this.DrawCellImage(e.Graphics, this.GetElementPosition(element.Coordinates), element);
            }

            e.Graphics.Dispose();
         }

         this.ResumeLayout();
      }

      /// <summary>
      /// Get the real coordinates (origina) for any coordinates.
      /// </summary>
      /// <param name="coords">Selected coordinates.</param>
      /// <returns>The real origina coordinates.</returns>
      public Point GetRealCoordinates(Point coords)
      {
         Element element = this.Switchboard.GetBlock(coords);
         if (element == null)
         {
            return coords;
         }
         else if (element.Properties.Width == 1)
         {
            return coords;
         }
         else
         {
            return element.Coordinates;
         }
      }

      #endregion

      #region Event Handlers

      internal void SwitchboardControlBase_Paint(object sender, PaintEventArgs e)
      {
         this.OnPaint(this, e);
      }

      #endregion

      #region Private Members

      private void InitializeComponent()
      {
         this.SuspendLayout();
         // 
         // SwitchboardControlBase
         // 
         this.Paint += new PaintEventHandler(this.SwitchboardControlBase_Paint);
         this.ResumeLayout(false);
      }

      #endregion

   }
}
