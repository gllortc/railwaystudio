using Rwm.Otc.Data;
using Rwm.Otc.Utils;

namespace Rwm.Otc.Layout.Elements
{
   /// <summary>
   /// Specialized collection of elements.
   /// </summary>
   public class ElementCollection : ItemCollection<ElementBase>
   {

      #region Methods

      /// <summary>
      /// Get an element by its coordinates.
      /// </summary>
      /// <param name="sb">Parent switchboard.</param>
      /// <param name="col">Coordinates to check (X).</param>
      /// <param name="row">Coordinates to check (Y).</param>
      /// <returns>The requested element or <c>null</c> if coordinates are empty.</returns>
      public ElementBase Get(Switchboard sb, int col, int row)
      {
         return this.Get(sb, new Coordinates(col, row));
      }

      /// <summary>
      /// Get an element by its coordinates.
      /// </summary>
      /// <param name="sb">Parent switchboard.</param>
      /// <param name="coords">Coordinates to check.</param>
      /// <returns>The requested element or <c>null</c> if coordinates are empty.</returns>
      public ElementBase Get(Switchboard sb, Coordinates coords)
      {
         foreach (ElementBase element in this)
         {
            if (element.Switchboard == sb && element.IsInCoordinates(coords))
            {
               return element;
            }
         }

         return null;
      }

      #endregion

   }
}
