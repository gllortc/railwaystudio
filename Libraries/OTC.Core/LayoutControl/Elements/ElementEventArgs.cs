using System;

namespace Rwm.Otc.LayoutControl.Elements
{
   /// <summary>
   /// Event arguments used by element events.
   /// </summary>
   public class ElementEventArgs : EventArgs
   {

      /// <summary>
      /// Returns a new instance of <see cref="ElementEventArgs"/>.
      /// </summary>
      /// <param name="element">Associated element.</param>
      public ElementEventArgs(ElementBase element)
      {
          this.Element = element;
      }

      /// <summary>
      /// Gets the element affected by the event.
      /// </summary>
      public ElementBase Element { get; private set; }

   }
}
