using System;
using System.Collections.Generic;
using Rwm.Otc.Data.ORM;
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
      public AccessoryDecoderConnection()
      {
         Initialize();
      }

      /// <summary>
      /// Returns a new instance of <see cref="AccessoryDecoderConnection"/>.
      /// </summary>
      /// <param name="name">Name of the connection.</param>
      /// <param name="device">Control module associated.</param>
      public AccessoryDecoderConnection(string name, AccessoryDecoder device)
      {
         Initialize();

         this.Name = name.Trim();
         this.Device = device;
      }

      /// <summary>
      /// Returns a new instance of <see cref="AccessoryDecoderConnection"/>.
      /// </summary>
      /// <param name="name">Conetion name.</param>
      /// <param name="device">Control module associated.</param>
      /// <param name="address">Digital address.</param>
      /// <param name="output">DecoderOutput index (starting by 1).</param>
      public AccessoryDecoderConnection(string name, AccessoryDecoder device, int address, int output)
      {
         Initialize();

         this.Name = name.Trim();
         this.Device = device;
         this.Address = address;
         this.DecoderOutput = output;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; }

      /// <summary>
      /// Gets or sets the element connection index (to maintain its position).
      /// </summary>
      [ORMProperty("INDEX")]
      public int ElementPinIndex { get; set; }

      /// <summary>
      /// Gets or sets the related accessory module.
      /// </summary>
      [ORMProperty("DECODERID")]
      public AccessoryDecoder Device { get; set; }

      /// <summary>
      /// Gets or sets the related element.
      /// </summary>
      [ORMProperty("ELEMENTID")]
      public Element Element { get; set; }

      /// <summary>
      /// Gets or sets the output name.
      /// </summary>
      [ORMProperty("NAME")]
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets the output digital address.
      /// </summary>
      [ORMProperty("ADDRESS")]
      public int Address { get; set; }

      /// <summary>
      /// Gets or sets the device output where it is connected (starting at 1).
      /// </summary>
      [ORMProperty("DECODEROUTPUT")]
      public int DecoderOutput { get; set; }

      /// <summary>
      /// Gets or sets the time (in milliseconds) to switch.
      /// </summary>
      [ORMProperty("SWITCHTIME")]
      public int SwitchTime { get; set; }

      public DeviceConnectionMap OutputMap { get; set; }

      public DecoderFunctionOutputStatus Output2 { get; set; }

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
         return this.Name.CompareTo(other.Name);
      }

      #endregion

      #region Static Members

      /// <summary>
      /// Get a <see cref="AccessoryDecoderConnection"/> by its device output.
      /// </summary>
      /// <param name="element">Owner connection <see cref="Element"/>.</param>
      /// <param name="output"><see cref="AccessoryDecoderConnection"/> index.</param>
      /// <returns>The requested <see cref="AccessoryDecoderConnection"/> or <c>null</c> if no <see cref="AccessoryDecoderConnection"/> is used by the specified <see cref="Element"/> and index.</returns>
      public static AccessoryDecoderConnection GetByOutput(Element element, int output)
      {
         foreach (AccessoryDecoderConnection connection in element?.AccessoryConnections)
         {
            if (connection.DecoderOutput == output)
               return connection;
         }

         return null;
      }

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

         Logger.LogDebug("Rwm.Otc.Layout.DeviceConnection.GetDuplicated()");

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

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ID = 0;
         this.ElementPinIndex = 0;
         this.Device = null;
         this.Element = null;
         this.Name = string.Empty;
         this.Address = 0;
         this.DecoderOutput = 0;
         this.OutputMap = new DeviceConnectionMap();
         this.Output2 = DecoderFunctionOutputStatus.Unknown;
         this.SwitchTime = 0;
      }

      #endregion

   }
}
