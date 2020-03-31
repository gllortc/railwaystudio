using System;

namespace Rwm.Otc.Layout
{
   /// <summary>
   /// Event arguments used by element events.
   /// </summary>
   public class ElementEventArgs : EventArgs
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ElementEventArgs"/>.
      /// </summary>
      /// <param name="element">Associated element.</param>
      public ElementEventArgs(Element element)
      {
          this.Element = element;
         this.NewAccessoryStatus = Element.STATUS_UNDEFINED;
      }

      /// <summary>
      /// Returns a new instance of <see cref="ElementEventArgs"/>.
      /// </summary>
      /// <param name="element">Associated element.</param>
      public ElementEventArgs(Element element, int newAccessoryStatus)
      {
         this.Element = element;
         this.NewAccessoryStatus = newAccessoryStatus;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the element affected by the event.
      /// </summary>
      public Element Element { get; private set; }

      /// <summary>
      /// Gets the new status adopted by the accessory.
      /// </summary>
      public int NewAccessoryStatus { get; private set; }

      #endregion

   }
}
