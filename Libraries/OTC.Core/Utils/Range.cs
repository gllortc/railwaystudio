namespace Rwm.Otc.Utils
{
   /// <summary>
   /// Implements a integer value range.
   /// </summary>
   public class Range
   {

      /// <summary>
      /// Returns a new instance of <see cref="Range"/>.
      /// </summary>
      /// <param name="minimum">Lower value.</param>
      /// <param name="maximum">Higher value.</param>
      public Range(int minimum, int maximum)
      {
         this.Minimum = minimum;
         this.Maximum = maximum;
      }

      /// <summary>
      /// Gets or sets the minimum value included in range.
      /// </summary>
      public int Minimum { get; set; }

      /// <summary>
      /// Gets or sets the maximum value included in range.
      /// </summary>
      public int Maximum { get; set; }

      /// <summary>
      /// Check if specified number is inside the range.
      /// </summary>
      /// <param name="value">Value to check.</param>
      /// <returns>A value indicating if <paramref name="value"/> is a valid range number.</returns>
      public bool IsInRange(int value)
      {
         return (value >= this.Minimum && value <= this.Maximum);
      }

   }
}
