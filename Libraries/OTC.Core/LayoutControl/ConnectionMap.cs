using System;

namespace Rwm.Otc.LayoutControl
{
   /// <summary>
   /// Manage a element connection map.
   /// </summary>
   public class ConnectionMap
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ConnectionMap"/>.
      /// </summary>
      public ConnectionMap()
      {
         this.Map = 0;
      }

      /// <summary>
      /// Returns a new instance of <see cref="ConnectionMap"/>.
      /// </summary>
      /// <param name="map">The mapping value.</param>
      public ConnectionMap(int map)
      {
         this.Map = map;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the value of the connection map (to store in DB).
      /// </summary>
      public int Map { get; private set; }

      #endregion

      #region Methods

      /// <summary>
      /// Set an output activation for the specified element status value.
      /// </summary>
      /// <param name="elementStatus">Element status.</param>
      /// <param name="activeTerminal">Activated terminal (1 or 2).</param>
      public void SetOutput(int elementStatus, int activeTerminal)
      {
         int mask = 0;

         if (activeTerminal != 1 && activeTerminal != 2)
         {
            throw new Exception("Not supported active terminal (" + activeTerminal + ").");
         }

         mask = 3;                                    // 00000000011
         mask = mask << ((elementStatus - 1) * 2);    // 00000110000
         mask = ~mask;                                // 11111001111
                                                      // 00000008421

         this.Map = this.Map & mask;               // Reset the two bits of the status
         this.Map = this.Map | (activeTerminal << ((elementStatus - 1) * 2));
      }

      /// <summary>
      /// Get the activated terminal for the specified element status.
      /// </summary>
      /// <param name="elementStatus">Element status.</param>
      /// <returns>The activated terminal (1 or 2) for the specified status.</returns>
      public int GetOutput(int elementStatus)
      {
         int mask = 0;
         int output = 0;

         mask = 3;                                    // 00000000011
         mask = mask << ((elementStatus - 1) * 2);    // 00000110000

         output = this.Map & mask;                 // Remove all data except the masked data (selected output)
         output = output >> ((elementStatus - 1) * 2);

         return output;
      }

      #endregion

   }
}
