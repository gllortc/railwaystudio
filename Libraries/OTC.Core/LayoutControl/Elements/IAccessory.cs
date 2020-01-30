using System;
using System.Collections.Generic;

namespace Rwm.Otc.LayoutControl.Elements
{

   /// <summary>
   /// Interface implemented by all blocks controlled as an accessory.
   /// </summary>
   public interface IAccessory
   {

      /// <summary>
      /// Get the element unique identifier (DB).
      /// </summary>
      int ID { get; }

      /// <summary>
      /// Get the current status value.
      /// </summary>
      int GetAccessoryStatus();

      /// <summary>
      /// Set status for the element.
      /// </summary>
      /// <param name="status">New status to be adopted by the element.</param>
      /// <param name="sendToSystem">A value indicating if the new status must be sent to digital system.</param>
      void SetAccessoryStatus(int status, bool sendToSystem);

      /// <summary>
      /// Set next status for the element.
      /// </summary>
      /// <param name="sendToSystem">A value indicating if the new status must be sent to digital system.</param>
      /// <returns>The new status adopted by the element.</returns>
      int SetAccessoryNextStatus(bool sendToSystem);

      /// <summary>
      /// Returns the description of the current status.
      /// </summary>
      /// <returns>A string containing the current status description.</returns>
      string GetCurrentAccessoryStatusDescription();

      /// <summary>
      /// Returns the default connection map for the specified connection index.
      /// </summary>
      /// <returns>An instance of <see cref="ConnectionMap"/> with default settings.</returns>
      ConnectionMap GetDefaultConnectionMap(int connectionIndex);

      /// <summary>
      /// Get a list of available status for the element.
      /// </summary>
      /// <returns>A <c>KeyValuePair</c> filled with the description and the integer value.</returns>
      List<KeyValuePair<String, int>> GetAllAccessoryStatusValues();

      /// <summary>
      /// Event raised when a new status is adopted by the element.
      /// </summary>
      event EventHandler<AccessoryEventArgs> AccessoryStatusChanged; 

   }
}
