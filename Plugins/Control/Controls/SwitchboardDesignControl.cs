using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.Layout.Elements;
using Rwm.Otc.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Controls
{
   /// <summary>
   /// Control to edit a switchboard.
   /// </summary>
   public partial class SwitchboardDesignControl : SwitchboardControlBase
   {

      #region Enumerations

      /// <summary>
      /// Tools that can be used in design mode.
      /// </summary>
      public enum DesignTools
      {
         /// <summary>Layout design mode.</summary>
         Pointer,
         /// <summary>Control design mode.</summary>
         Add,
         /// <summary>Control design mode.</summary>
         Rotate,
         /// <summary>Control design mode.</summary>
         Delete
      }

      #endregion

      #region Constants

      private static Color COLOR_SELECTED = Color.LightSkyBlue;

      private static Color COLOR_ROUTE_SELECTED = Color.Salmon;

      private static Color COLOR_PANEL = Color.LightGray;

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="SwitchboardDesignControl"/>.
      /// </summary>
      public SwitchboardDesignControl() : base(true) { }

      /// <summary>
      /// Returns a new instance of <see cref="SwitchboardDesignControl"/>.
      /// </summary>
      /// <param name="switchboard">Switchboard to paint.</param>
      public SwitchboardDesignControl(Switchboard switchboard)
         : base(switchboard, true)
      {
         InitializeComponent();

         this.Initialize();
      }

      #endregion

      #region Properties

      public DesignTools SelectedDesignTool { get; set; }

      public static Type AddBlockType { get; set; }

      #endregion

      #region Methods

      public void BlockAdd(Type blockType, int col, int row)
      {
         this.BlockAdd(blockType, new Coordinates(col, row));
      }

      public void BlockAdd(Type blockType, Coordinates coords)
      {
         // Avoit adding blocks without predefined type
         if (blockType == null) return;

         try
         {
            ElementBase newBlock = (ElementBase)Activator.CreateInstance(blockType);
            newBlock.X = coords.X;
            newBlock.Y = coords.Y;
            newBlock.Switchboard = this.Switchboard;

            if (!this.IsAddBlockAllowed(newBlock, coords))
            {
               throw new ArgumentException("The element cannot be placed here: no enough space");
            }

            OTCContext.Project.Add(newBlock);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            this.RepaintCoordinates(coords);
            // this.SelectCell(coords);
         }
      }

      public void BlockDelete(int col, int row)
      {
         this.BlockDelete(new Coordinates(col, row));
      }

      public void BlockDelete(Coordinates coords)
      {
         ElementBase element = null;

         try
         {
            element = OTCContext.Project.Elements.Get(this.Switchboard, coords);
            if (element != null)
            {
               OTCContext.Project.Remove(element);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            this.RepaintCoordinates(element != null ? element.GetUsedCoordinates() : new Coordinates[] { coords });
            this.SelectCell(coords);
         }
      }

      public void RotateElement(int col, int row)
      {
         this.RotateElement(new Coordinates(col, row));
      }

      public void RotateElement(Coordinates coords)
      {
         try
         {
            ElementBase element = OTCContext.Project.Elements.Get(this.Switchboard, coords);
            if (element != null)
            {
               element.Rotate();
               OTCContext.Project.Update(element);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            this.RepaintCoordinates(coords);
            this.SelectCell(coords);
         }
      }

      /// <summary>
      /// Select a element cell.
      /// </summary>
      /// <param name="coords">Cell coordinates.</param>
      public override void SelectCell(Coordinates coords)
      {
         int elementWidth = 1;
         Coordinates tmpCoords = null;
         ElementBase element;
         Rectangle selrect;

         // Get the real coords (origin in case of element with more than 1 element)
         coords = this.GetRealCoordinates(coords);

         using (Graphics g = this.CreateGraphics())
         {
            // Remove current selection
            if (this.SelectedCell != null)
            {
               // Delete cell drawings
               element = OTCContext.Project.Elements.Get(this.Switchboard, this.SelectedCell);
               elementWidth = (element != null ? element.Width : 1);
               for (int blockIdx = 0; blockIdx < elementWidth; blockIdx++)
               {
                  tmpCoords = new Coordinates(this.SelectedCell.X + blockIdx,
                                              this.SelectedCell.Y);

                  selrect = new Rectangle(this.GetElementPosition(tmpCoords),
                                          OTCContext.Project.Theme.ElementSize);

                  this.RemoveCellImage(g, selrect);
               }

               // If the cell have a element, redraw the element
               element = OTCContext.Project.Elements.Get(this.Switchboard, this.SelectedCell);
               if (element != null)
               {
                  this.DrawCellImage(g, this.GetElementPosition(element.Coordinates), element);
               }
            }

            // Draw a cell highlight layer
            element = OTCContext.Project.Elements.Get(this.Switchboard, coords);
            elementWidth = (element != null ? element.Width : 1);
            for (int blockIdx = 0; blockIdx < elementWidth; blockIdx++)
            {
               tmpCoords = new Coordinates(coords.X + blockIdx, coords.Y);

               this.DrawCellHighlight(g, new Rectangle(this.GetElementPosition(tmpCoords),
                                                       OTCContext.Project.Theme.ElementSize));
            }
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
      public event BlockDoubleClickedEventHandler BlockDoubleClick;

      #endregion

      #region Event Handlers

      protected override void OnMouseClick(MouseEventArgs e)
      {
         Coordinates coords = new Coordinates((e.X + this.HorizontalScroll.Value) / OTCContext.Project.Theme.ElementSize.Width,
                                              (e.Y + this.VerticalScroll.Value) / OTCContext.Project.Theme.ElementSize.Height);

         if (this.IsOutOfClickableArea(coords) || e.Button != System.Windows.Forms.MouseButtons.Left)
         {
            return;
         }

         this.DesignLayoutClickDispatcher(coords);

         ElementBase element = OTCContext.Project.Elements.Get(this.Switchboard, coords);

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
         Coordinates coords = new Coordinates((e.X + this.HorizontalScroll.Value) / OTCContext.Project.Theme.ElementSize.Width,
                                              (e.Y + this.VerticalScroll.Value) / OTCContext.Project.Theme.ElementSize.Height);
         ElementBase element = OTCContext.Project.Elements.Get(this.Switchboard, coords);

         if (this.BlockDoubleClick != null && element != null)
         {
            this.BlockDoubleClick(this, new CellClickEventArgs(this, coords, element));
         }
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.SelectedDesignTool = DesignTools.Pointer;

         SwitchboardDesignControl.AddBlockType = null;
      }

      /// <summary>
      /// Manage the clik in blocks.
      /// </summary>
      private void DesignLayoutClickDispatcher(Coordinates coords)
      {
         switch (this.SelectedDesignTool)
         {
            case DesignTools.Add:
               this.BlockAdd(SwitchboardDesignControl.AddBlockType, coords);
               break;

            case DesignTools.Delete:
               this.BlockDelete(coords);
               break;

            case DesignTools.Rotate:
               this.RotateElement(coords);
               break;

            default:
               break;
         }

         this.SelectCell(coords);
      }

      /// <summary>
      /// Check if the current element can be fitted in the desired coordinates.
      /// </summary>
      private bool IsAddBlockAllowed(ElementBase element, Coordinates position)
      {
         if (element.Width <= 1)
         {
            return true;
         }
         else
         {
            for (int x = 0; x < element.Width; x++)
            {
               if (this.Switchboard.IsOccupied(new Coordinates(element.X + x, element.Y)))
               {
                  return false;
               }
            }
         }

         return true;
      }

      ///// <summary>
      ///// Get the real coordinates (origina) for any coordinates.
      ///// </summary>
      ///// <param name="coords">Selected coordinates.</param>
      ///// <returns>The real origina coordinates.</returns>
      //private Coordinates GetRealCoordinates(Coordinates coords)
      //{
      //   ElementBase element = OTCContext.Project.Elements.Get(this.Switchboard, coords);
      //   if (element == null)
      //   {
      //      return coords;
      //   }
      //   else if (element.Width == 1)
      //   {
      //      return coords;
      //   }
      //   else
      //   {
      //      return element.Coordinates;
      //   }
      //}

      /// <summary>
      /// Check if a coordinate is out of valid switchboard area.
      /// </summary>
      private bool IsOutOfClickableArea(Coordinates coords)
      {
         return ((coords.X > this.Switchboard.Width - 1) || (coords.Y > this.Switchboard.Height - 1));
      }

      #endregion

   }
}
