using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.Layout.Elements;
using Rwm.Otc.Utils;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Controls
{
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

         this.Initialize();
         this.DesignMode = designMode;
      }

      public SwitchboardControlBase(Switchboard sb, bool designMode)
      {
         InitializeComponent();

         this.Initialize();

         this.Switchboard = sb;
         this.DesignMode = designMode;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the panel shown in the control.
      /// </summary>
      public Switchboard Switchboard { get; internal set; }

      public Color SelectedCellColor { get; set; }

      public Color SwitchboardPanelBackgroundColor { get; set; }

      /// <summary>
      /// Gets the coordinates of the current selected cell.
      /// </summary>
      public Coordinates SelectedCell { get; internal set; }

      /// <summary>
      /// Gets a value indicating if the switchboard is in design mode.
      /// </summary>
      public bool DesignMode { get; private set; }

      #endregion

      #region Methods

      public virtual void Draw()
      {
         this.SwitchboardControlBase_Paint(this, new PaintEventArgs(this.CreateGraphics(), new Rectangle()));
      }

      public void RepaintCoordinates(IEnumerable<Coordinates> coords)
      {
         foreach (Coordinates c in coords) this.RepaintCoordinates(c);
      }

      public void RepaintCoordinates(Coordinates coords)
      {
         int widthInBlocks = 1;
         Coordinates paintCoords = null;
         ElementBase element;
         Rectangle rect = new Rectangle(0, 0, 0, 0);

         // Get the element placed in coordinates
         element = OTCContext.Project.Elements.Get(this.Switchboard, coords);
         widthInBlocks = (element != null ? element.Width : 1);
         paintCoords = (element != null ? element.Coordinates : coords);

         using (Graphics g = this.CreateGraphics())
         {
            for (int i = 1; i < widthInBlocks + 1; i++)
            {
               // Get the cell rectabgle
               rect = new Rectangle(this.GetElementPosition(this.GetRealCoordinates( paintCoords)), OTCContext.Project.Theme.ElementSize);

               // Delete cell previous drawing
               this.RemoveCellImage(g, rect);

               // Paint the element (if exists in that position)
               if (element != null) this.DrawCellImage(g, rect.Location, element);

               paintCoords.X++;
            }

            // Draw a cell highlight layer
            if (rect != null && this.SelectedCell != null && (this.SelectedCell.Equals(coords)))
            {
               this.DrawCellHighlight(g, rect);
            }
         }
      }

      public void SelectCell(int col, int row)
      {
         this.SelectCell(new Coordinates(col, row));
      }

      public virtual void SelectCell(Coordinates coords)
      {
         ElementBase element;
         Rectangle rect = new Rectangle(this.GetElementPosition(coords), OTCContext.Project.Theme.ElementSize);

         using (Graphics g = this.CreateGraphics())
         {
            if (this.SelectedCell != null)
            {
               Rectangle selrect = new Rectangle(this.GetElementPosition(this.SelectedCell), OTCContext.Project.Theme.ElementSize);

               // Delete cell drawings
               this.RemoveCellImage(g, selrect);

               // If the cell have a element, redraw the element
               element = OTCContext.Project.Elements.Get(this.Switchboard, this.SelectedCell);
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

      public void UnselectCell(Coordinates coords)
      {
         ElementBase element;
         Rectangle rect = new Rectangle(GetElementPosition(coords), OTCContext.Project.Theme.ElementSize);

         using (Graphics g = this.CreateGraphics())
         {
            // Delete cell drawings
            this.RemoveCellImage(g, rect);

            // If the cell have a element, redraw the element
            element = OTCContext.Project.Elements.Get(this.Switchboard, coords);
            if (element != null)
            {
               this.DrawCellImage(g, rect.Location, element);
            }
         }

         this.SelectedCell = null;
      }

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
      internal void RemoveCellImage(Graphics g, Rectangle rect)
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
      internal void DrawCellHighlight(Graphics g, Rectangle rect)
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
      internal void DrawCellImage(Graphics g, Point point, ElementBase element)
      {
         g.DrawImage(element.GetImage(OTCContext.Project.Theme, this.DesignMode), point);
      }

      internal Point GetElementPosition(Coordinates coords)
      {
         return new Point(coords.X * OTCContext.Project.Theme.ElementSize.Width,
                          coords.Y * OTCContext.Project.Theme.ElementSize.Height);
      }

      internal virtual void BeforePaint() { }

      internal virtual void OnPaint(object sender, PaintEventArgs e)
      {
         Point startP = new Point();
         Point endP = new Point();

         // Avoid trying painting null switchboards
         if (this.Switchboard == null) return;

         // Call virtual method to override in case 
         // to need to make some tasks before to paint
         this.BeforePaint();

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
            foreach (ElementBase element in this.Switchboard.Elements)
            {
               this.DrawCellImage(e.Graphics, this.GetElementPosition(element.Coordinates), element);
            }

            e.Graphics.Dispose();
         }
      }

      /// <summary>
      /// Get the real coordinates (origina) for any coordinates.
      /// </summary>
      /// <param name="coords">Selected coordinates.</param>
      /// <returns>The real origina coordinates.</returns>
      internal Coordinates GetRealCoordinates(Coordinates coords)
      {
         ElementBase element = OTCContext.Project.Elements.Get(this.Switchboard, coords);
         if (element == null)
         {
            return coords;
         }
         else if (element.Width == 1)
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
         this.Paint += new System.Windows.Forms.PaintEventHandler(this.SwitchboardControlBase_Paint);
         this.ResumeLayout(false);
      }

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.Switchboard = null;
         this.SelectedCell = null;

         this.SelectedCellColor = SwitchboardCommandControl.COLOR_SELECTED;
         this.SwitchboardPanelBackgroundColor = SwitchboardCommandControl.COLOR_PANEL;
      }

      #endregion

   }
}
