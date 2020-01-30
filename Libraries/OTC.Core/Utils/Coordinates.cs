using System;

namespace Rwm.Otc.Utils
{
   public class Coordinates : IComparable<Coordinates>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Coordinates"/>.
      /// </summary>
      /// <param name="x">Coordinate X (column).</param>
      /// <param name="y">Coordinate Y (row).</param>
      public Coordinates(int x, int y)
      {
         this.X = x;
         this.Y = y;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the X coordinate (column).
      /// </summary>
      public int X { get; set; }

      /// <summary>
      /// Gets the Y coordinate (row).
      /// </summary>
      public int Y { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Check if the current instance is equals to another.
      /// </summary>
      /// <param name="coords">Coordinates to compare.</param>
      /// <returns><c>true</c> if the two coordinates are equals, otherwise returns <c>false</c>.</returns>
      public bool Equals(Coordinates coords)
      {
         return ((this.X == coords.X) && (this.Y == coords.Y));
      }

      /// <summary>
      /// Check if the current instance is equals to another.
      /// </summary>
      /// <param name="x">The X coordinate (column).</param>
      /// <param name="y">The Y coordinate (row).</param>
      /// <returns><c>true</c> if the two coordinates are equals, otherwise returns <c>false</c>.</returns>
      public bool Equals(int x, int y)
      {
         return ((this.X == x) && (this.Y == y));
      }

      /// <summary>
      /// Compare two coordinates.
      /// </summary>
      /// <param name="other">Coordinates to comparte to the current instance.</param>
      /// <returns>A value resulting the comparation of two coordinates.</returns>
      public int CompareTo(Coordinates other)
      {
         int compResult = 0;

         compResult = this.X.CompareTo(other.X);
         if (compResult == 0)
         {
            return this.Y.CompareTo(other.Y);
         }

         return compResult;
      }

      public Coordinates Clone()
      {
         return new Coordinates(this.X, this.Y);
      }

      public override string ToString()
      {
         return string.Format("X:{0};Y:{1}", this.X, this.Y);
      }

      #endregion

   }
}
