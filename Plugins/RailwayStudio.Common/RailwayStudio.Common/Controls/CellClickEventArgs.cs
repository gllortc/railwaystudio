﻿using System.Drawing;
using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Common.Controls
{
   /// <summary>
   /// Class to pass information in the events involving a switchboard cell click..
   /// </summary>
   public class CellClickEventArgs
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="CellClickEventArgs"/>.
      /// </summary>
      /// <param name="x">X position for the clicked cell.</param>
      /// <param name="y">Y position for the clicked cell.</param>
      public CellClickEventArgs(SwitchboardControlBase control, int x, int y)
      {
         this.Coordinates = new Point(x, y);
         this.Element = null;
      }

      /// <summary>
      /// Returns a new instance of <see cref="CellClickEventArgs"/>.
      /// </summary>
      /// <param name="coords">Coordinates for the clicked cell.</param>
      public CellClickEventArgs(SwitchboardControlBase control, Point coords)
      {
         this.Coordinates = coords;
         this.Element = null;
      }

      /// <summary>
      /// Returns a new instance of <see cref="CellClickEventArgs"/>.
      /// </summary>
      /// <param name="x">X position for the clicked cell.</param>
      /// <param name="y">Y position for the clicked cell.</param>
      /// <param name="element">Element contained in the clicked cell.</param>
      public CellClickEventArgs(SwitchboardControlBase control, int x, int y, Element element)
      {
         this.Coordinates = new Point(x, y);
         this.Element = element;
      }

      /// <summary>
      /// Returns a new instance of <see cref="CellClickEventArgs"/>.
      /// </summary>
      /// <param name="coords">Coordinates for the clicked cell.</param>
      /// <param name="element">Element contained in the clicked cell.</param>
      public CellClickEventArgs(SwitchboardControlBase control, Point coords, Element element)
      {
         this.Coordinates = coords;
         this.Element = element;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the control bringing the arguments.
      /// </summary>
      public SwitchboardControlBase Control { get; private set; }

      /// <summary>
      /// Gets the Y position for the clicked cell.
      /// </summary>
      public int Y
      {
         get { return this.Coordinates.Y; }
      }

      /// <summary>
      /// Gets the X position for the clicked cell.
      /// </summary>
      public int X
      {
         get { return this.Coordinates.X; }
      }

      /// <summary>
      /// Gets the element contained in the clicked cell.
      /// </summary>
      public Element Element { get; private set; }

      /// <summary>
      /// Gets the coordinates for the clicked cell.
      /// </summary>
      public Point Coordinates { get; private set; }

      #endregion

   }
}