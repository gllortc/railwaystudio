using System;
using System.Collections.Generic;
using System.Data;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;

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
      /// Gets or sets the element connection index (to maintain its position).
      /// </summary>
      [ORMProperty("INDEX")]
      public int ElementPinIndex { get; set; } = 0;

      /// <summary>
      /// Gets or sets the related accessory module.
      /// </summary>
      [ORMProperty("DECODERID")]
      public AccessoryDecoder Decoder { get; set; } = null;

      /// <summary>
      /// Gets or sets the related element.
      /// </summary>
      [ORMProperty("ELEMENTID")]
      public Element Element { get; set; } = null;

      /// <summary>
      /// Gets or sets the output digital address.
      /// </summary>
      [ORMProperty("ADDRESS")]
      public int Address { get; set; } = 0;

      /// <summary>
      /// Gets or sets the device output where it is connected (starting at 1).
      /// </summary>
      [ORMProperty("DECODEROUTPUT")]
      public int DecoderOutput { get; set; } = 0;

      /// <summary>
      /// Gets or sets the time (in milliseconds) to switch.
      /// </summary>
      [ORMProperty("SWITCHTIME")]
      public int SwitchTime { get; set; } = 0;

      /// <summary>
      /// Gets or sets the time (in milliseconds) to switch.
      /// </summary>
      [ORMProperty("INVERTED")]
      public bool Inverted { get; set; } = false;

      /// <summary>
      /// Gets a value indicating if the connection is used by an element.
      /// </summary>
      public bool IsUsed
      {
         get { return (this.Element != null); }
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

      ///// <summary>
      ///// Get a <see cref="AccessoryDecoderConnection"/> by its device output.
      ///// </summary>
      ///// <param name="element">Owner connection <see cref="Element"/>.</param>
      ///// <param name="output"><see cref="AccessoryDecoderConnection"/> index.</param>
      ///// <returns>The requested <see cref="AccessoryDecoderConnection"/> or <c>null</c> if no <see cref="AccessoryDecoderConnection"/> is used by the specified <see cref="Element"/> and index.</returns>
      //public static AccessoryDecoderConnection GetByOutput(Element element, int output)
      //{
      //   foreach (AccessoryDecoderConnection connection in element?.AccessoryConnections)
      //   {
      //      if (connection.DecoderOutput == output)
      //         return connection;
      //   }

      //   return null;
      //}

      ///// <summary>
      ///// Get a <see cref="AccessoryDecoderConnection"/> by its device output.
      ///// </summary>
      ///// <param name="element">Owner connection <see cref="Element"/>.</param>
      ///// <param name="output"><see cref="AccessoryDecoderConnection"/> index.</param>
      ///// <returns>The requested <see cref="AccessoryDecoderConnection"/> or <c>null</c> if no <see cref="AccessoryDecoderConnection"/> is used by the specified <see cref="Element"/> and index.</returns>
      //public static AccessoryDecoderConnection GetByOutput(AccessoryDecoder decoder, int output)
      //{
      //   foreach (AccessoryDecoderConnection connection in decoder?.Connections)
      //   {
      //      if (connection.DecoderOutput == output)
      //         return connection;
      //   }

      //   return null;
      //}

      /// <summary>
      /// Get a <see cref="AccessoryDecoderConnection"/> by its index.
      /// </summary>
      /// <param name="element">Owner connection <see cref="Element"/>.</param>
      /// <param name="index"><see cref="AccessoryDecoderConnection"/> index.</param>
      /// <returns>The requested <see cref="AccessoryDecoderConnection"/> or <c>null</c> if no <see cref="AccessoryDecoderConnection"/> is used by the specified <see cref="Element"/> and index.</returns>
      public static AccessoryDecoderConnection GetByIndex(Element element, int index)
      {
         foreach (AccessoryDecoderConnection connection in element?.AccessoryConnections)
         {
            if (connection.ElementPinIndex == index)
               return connection;
         }

         return null;
      }

      /// <summary>
      /// Gets all connection for the specified element.
      /// </summary>
      /// <returns>The requested list of <see cref="AccessoryDecoderConnection"/> related to the specified element.</returns>
      public static IEnumerable<AccessoryDecoderConnection> GetDuplicated()
      {
         string sql = string.Empty;

         Logger.LogDebug("Rwm.Otc.Layout.AccessoryDecoderConnection.GetDuplicated()");

         try
         {
            // Get connections with repeated addresses
            sql = @"WHERE 
                        address in (SELECT address, COUNT(*) c 
                                    FROM   " + AccessoryDecoderConnection.ORMStructure.Table.TableName + @" 
                                    GROUP  BY address 
                                    HAVING c > 1) 
                    ORDER BY 
                        id";

            return AccessoryDecoderConnection.ExecuteQuery(sql);
         }
         catch (Exception ex)
         {
            Logger.LogError(ex);
            throw ex;
         }
         finally
         {
            Disconnect();
         }
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
                                          (deviceConnection.Decoder != null ? deviceConnection.Decoder?.Name : "Bad connection"),
                                          deviceConnection.DecoderOutput,
                                          deviceConnection.Address,
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
