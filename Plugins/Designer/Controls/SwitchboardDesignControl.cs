using System;
using System.Drawing;
using System.Windows.Forms;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Common.Controls;

namespace Rwm.Studio.Plugins.Designer.Controls
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

      public static ElementType AddBlockType { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Adds a new block into the switchboard.
      /// </summary>
      /// <param name="blockType">Type of the new block.</param>
      /// <param name="col">Column index.</param>
      /// <param name="row">Row index.</param>
      public void BlockAdd(ElementType blockType, int col, int row)
      {
         this.BlockAdd(blockType, new Point(col, row));
      }

      /// <summary>
      /// Adds a new block into the switchboard.
      /// </summary>
      /// <param name="blockType">Type of the new block.</param>
      /// <param name="coords">Position coordinates.</param>
      public void BlockAdd(ElementType blockType, Point coords)
      {
         // Avoit adding blocks without predefined type
         if (blockType == null) return;

         try
         {
            Element newBlock = new Element();
            newBlock.Properties = blockType;
            newBlock.X = coords.X;
            newBlock.Y = coords.Y;
            newBlock.Switchboard = this.Switchboard;

            if (!this.IsAddBlockAllowed(newBlock, coords))
            {
               throw new ArgumentException("The element cannot be placed here. Possible causes:\n\n- Used position\n- No enough space");
            }

            if (newBlock.Properties.IsAccessory)
               newBlock.AccessoryConnections = new System.Collections.Generic.List<AccessoryDecoderConnection>();

            if (newBlock.Properties.IsFeedback)
               newBlock.FeedbackConnections = new System.Collections.Generic.List<FeedbackEncoderConnection>();

            Element.Save(newBlock);
            this.Switchboard.Elements.Add(newBlock);
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

      /// <summary>
      /// Delete the block in the specified position.
      /// </summary>
      /// <param name="col">Column index.</param>
      /// <param name="row">Row index.</param>
      public void BlockDelete(int col, int row)
      {
         this.BlockDelete(new Point(col, row));
      }

      /// <summary>
      /// Delete the block in the specified position.
      /// </summary>
      /// <param name="coords">Block coordinates.</param>
      public void BlockDelete(Point coords)
      {
         Element element = null;

         try
         {
            element = this.Switchboard.GetBlock(coords);
            if (element != null)
            {
               if (Element.Delete(element.ID) > 0)
                  this.Switchboard.Elements.Remove(element);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            this.RepaintCoordinates(element != null ? element.GetUsedCoordinates() : new Point[] { coords });
            this.SelectCell(coords);
         }
      }

      public void RotateElement(int col, int row)
      {
         this.RotateElement(new Point(col, row));
      }

      public void RotateElement(Point coords)
      {
         try
         {
            Element element = this.Switchboard.GetBlock(coords);
            if (element != null)
            {
               element.Rotate();
               Element.Save(element);
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
      public override void SelectCell(Point coords)
      {
         int elementWidth = 1;
         Element element;
         Rectangle selrect;

         // Get the real coords (origin in case of element with more than 1 element)
         coords = this.GetRealCoordinates(coords);

         using (Graphics g = this.CreateGraphics())
         {
            Point tmpCoords;

            // Remove current selection
            if (this.SelectedCell != null)
            {
               // Delete cell drawings
               element = this.Switchboard.GetBlock(this.SelectedCell);
               elementWidth = (element != null ? element.Properties.Width : 1);
               for (int blockIdx = 0; blockIdx < elementWidth; blockIdx++)
               {
                  tmpCoords = new Point(this.SelectedCell.X + blockIdx, this.SelectedCell.Y);

                  selrect = new Rectangle(this.GetElementPosition(tmpCoords),
                                          OTCContext.Project.Theme.ElementSize);

                  this.RemoveCellImage(g, selrect);
               }

               // If the cell have a element, redraw the element
               element = this.Switchboard.GetBlock(this.SelectedCell);
               if (element != null)
               {
                  this.DrawCellImage(g, this.GetElementPosition(element.Coordinates), element);
               }
            }

            // Draw a cell highlight layer
            element = this.Switchboard.GetBlock(coords);
            elementWidth = (element != null ? element.Properties.Width : 1);
            for (int blockIdx = 0; blockIdx < elementWidth; blockIdx++)
            {
               tmpCoords = new Point(coords.X + blockIdx, coords.Y);

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
         Point coords = new Point((e.X + this.HorizontalScroll.Value) / OTCContext.Project.Theme.ElementSize.Width,
                                  (e.Y + this.VerticalScroll.Value) / OTCContext.Project.Theme.ElementSize.Height);

         if (this.IsOutOfClickableArea(coords) || e.Button != System.Windows.Forms.MouseButtons.Left)
         {
            return;
         }

         this.DesignLayoutClickDispatcher(coords);

         Element element = this.Switchboard.GetBlock(coords);

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
         Point coords = new Point((e.X + this.HorizontalScroll.Value) / OTCContext.Project.Theme.ElementSize.Width,
                                  (e.Y + this.VerticalScroll.Value) / OTCContext.Project.Theme.ElementSize.Height);
         Element element = this.Switchboard.GetBlock(coords);

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
      private void DesignLayoutClickDispatcher(Point coords)
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
      private bool IsAddBlockAllowed(Element element, Point position)
      {
         if (element.Properties.Width <= 1)
         {
            return !this.Switchboard.IsOccupied(new Point(element.X, element.Y));
         }
         else
         {
            for (int x = 0; x < element.Properties.Width; x++)
            {
               if (this.Switchboard.IsOccupied(new Point(element.X + x, element.Y)))
               {
                  return false;
               }
            }
         }

         return true;
      }

      /// <summary>
      /// Check if a coordinate is out of valid switchboard area.
      /// </summary>
      private bool IsOutOfClickableArea(Point coords)
      {
         return ((coords.X > this.Switchboard.Width - 1) || (coords.Y > this.Switchboard.Height - 1));
      }

      #endregion

   }
}
