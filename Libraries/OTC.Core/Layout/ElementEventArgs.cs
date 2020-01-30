using System;

namespace Rwm.Otc.Layout
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
      public ElementEventArgs(Element element)
      {
          this.Element = element;
      }

      /// <summary>
      /// Gets the element affected by the event.
      /// </summary>
      public Element Element { get; private set; }

   }
}
