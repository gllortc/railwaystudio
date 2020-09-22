using System;
using System.Collections.Generic;
using System.Data;
using Rwm.Otc.Data;

namespace Rwm.Otc.Layout
{
   /// <summary>
   /// Implements the connection between an accessory module output with an element.
   /// </summary>
   [ORMTable("ACC_DECODER_CONNECTIONS")]
   public class AccessoryDecoderConnection : ORMEntity<AccessoryDecoderConnection>, IComparable<AccessoryDecoderConnection>
   {

      #region Enumerations

      /// <summary>
      /// Control device output statuses.
      /// </summary>
      public enum DecoderFunctionOutputStatus : int
      {
         /// <summary>Unknown status / not defined</summary>
         Unknown = 99,
         /// <summary>Disabled</summary>
         Off = 0,
         /// <summary>Enabled</summary>
         On = 1
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="AccessoryDecoderConnection"/>.
      /// </summary>
      public AccessoryDecoderConnection() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; } = 0;

      /// <summary>
      /// Gets or sets the related accessory module.
      /// </summary>
      [ORMProperty("OUTPUTID", "AccessoryConnection")]
      public AccessoryDecoderOutput DecoderOutput { get; set; } = null;

      /// <summary>
      /// Gets or sets the related element.
      /// </summary>
      [ORMProperty("ELEMENTID")]
      public Element Element { get; set; } = null;

      /// <summary>
      /// Gets or sets the element connection index (to maintain its position).
      /// </summary>
      [ORMProperty("INDEX")]
      public int ElementPinIndex { get; set; } = 0;

      /// <summary>
      /// Gets or sets the time (in milliseconds) to switch.
      /// </summary>
      [ORMProperty("INVERTED")]
      public bool Inverted { get; set; } = false;

      ///// <summary>
      ///// Gets a value indicating if the connection is used by an element.
      ///// </summary>
      //public bool IsUsed
      //{
      //   get { return (this.Element != null); }
      //}

      /// <summary>
      /// Gets the associated small icon (16x16px).
      /// </summary>
      public static System.Drawing.Image SmallIcon
      {
         get { return Properties.Resources.ICO_CONNECTION_16; }
      }

      /// <summary>
      /// Gets the associated large icon (32x32px).
      /// </summary>
      public static System.Drawing.Image LargeIcon
      {
         get { return Properties.Resources.ICO_CONNECTION_32; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Compare the current instance with other.
      /// </summary>
      /// <param name="other">The other instance to compare.</param>
      /// <returns>An integer indicating if the two instances are equals or not.</returns>
      public int CompareTo(AccessoryDecoderConnection other)
      {
         return this.ElementPinIndex.CompareTo(other.ElementPinIndex);
      }

      #endregion

      #region Static Members

      /// <summary>
      /// Get a <see cref="AccessoryDecoderConnection"/> by its index.
      /// </summary>
      /// <param name="element">Owner connection <see cref="Element"/>.</param>
      /// <param name="index"><see cref="AccessoryDecoderConnection"/> index.</param>
      /// <returns>The requested <see cref="AccessoryDecoderConnection"/> or <c>null</c> if no <see cref="AccessoryDecoderConnection"/> is used by the specified <see cref="Element"/> and index.</returns>
      public static AccessoryDecoderConnection GetByIndex(Element element, int index)
      {
         if (element.AccessoryConnections == null)
            return null;

         foreach (AccessoryDecoderConnection connection in element.AccessoryConnections)
         {
            if (connection.ElementPinIndex == index)
               return connection;
         }

         return null;
      }

      /// <summary>
      /// returns a list of route involved connections.
      /// </summary>
      /// <param name="route">The instance of the <see cref="Route"/>.</param>
      /// <returns>The requested <see cref="DataTable"/> instance.</returns>
      public static DataTable List(Route route)
      {
         // Clone and sort the route elements list
         List<RouteElement> elements = new List<RouteElement>();
         elements.AddRange(route.Elements);
         elements.Sort(delegate (RouteElement x, RouteElement y)
         {
            return (x.Element.Name.CompareTo(y.Element.Name));
         });

         // Configure the DataTable object
         DataTable connections = new DataTable("Connections");
         connections.Columns.Add("ID", typeof(long));
         connections.Columns.Add("IsValid", typeof(bool));
         connections.Columns.Add("Name", typeof(string));
         connections.Columns.Add("Decoder", typeof(string));
         connections.Columns.Add("Output", typeof(int));
         connections.Columns.Add("Address", typeof(int));
         connections.Columns.Add("Status", typeof(string));

         // Create the connections list
         foreach (RouteElement routeElement in elements)
         {
            if (routeElement.Element != null && routeElement.Element.Properties.NumberOfAccessoryConnections > 0)
            {
               for (int i = 1; i <= routeElement.Element.Properties.NumberOfAccessoryConnections; i++)
               {
                  AccessoryDecoderConnection deviceConnection = AccessoryDecoderConnection.GetByIndex(routeElement.Element, i);
                  if (deviceConnection != null)
                  {
                     connections.Rows.Add(deviceConnection.ID,
                                          true,
                                          (deviceConnection.Element != null ? deviceConnection.Element?.ToString() : "Bad connection"),
                                          (deviceConnection.DecoderOutput.AccessoryDecoder != null ? deviceConnection.DecoderOutput.AccessoryDecoder?.Name : "Bad connection"),
                                          deviceConnection.DecoderOutput,
                                          deviceConnection.DecoderOutput.Address,
                                          routeElement.Element.Properties.GetStatusDescription(routeElement.AccessoryStatus));
                  }
                  else
                  {
                     connections.Rows.Add(0,
                                          false,
                                          routeElement.Element.ToString(),
                                          "-",
                                          null,
                                          null,
                                          routeElement.Element.Properties.GetStatusDescription(routeElement.AccessoryStatus));
                  }
               }
            }
         }

         return connections;
      }

      #endregion

   }
}
