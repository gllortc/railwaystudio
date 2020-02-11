using System;
using Rwm.Otc.Data.ORM;

namespace Rwm.Otc.Layout
{
   /// <summary>
   /// Implements the connection between an accessory module output with an element.
   /// </summary>
   [ORMTable("FB_DECODER_CONNECTIONS")]
   public class FeedbackDecoderConnection : ORMEntity<FeedbackDecoderConnection>, IComparable<FeedbackDecoderConnection>
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
      public FeedbackDecoderConnection()
      {
         Initialize();
      }

      /// <summary>
      /// Returns a new instance of <see cref="AccessoryDecoderConnection"/>.
      /// </summary>
      /// <param name="name">Name of the connection.</param>
      /// <param name="device">Control module associated.</param>
      public FeedbackDecoderConnection(string name, FeedbackDecoder device)
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
      public FeedbackDecoderConnection(string name, FeedbackDecoder device, int address, int output)
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
      [ORMProperty("index")]
      public int Index { get; set; }

      /// <summary>
      /// Gets or sets the related feedback decoder.
      /// </summary>
      [ORMProperty("DECODERID")]
      public FeedbackDecoder Device { get; set; }

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
      [ORMProperty("OUTPUT")]
      public int DecoderOutput { get; set; }

      /// <summary>
      /// Gets or sets the time (in milliseconds) to switch.
      /// </summary>
      [ORMProperty("DELAYTIME")]
      public int DelayTime { get; set; }

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
      public int CompareTo(FeedbackDecoderConnection other)
      {
         return this.Name.CompareTo(other.Name);
      }

      #endregion

      #region Static Members

      /// <summary>
      /// Get a <see cref="FeedbackDecoderConnection"/> by its device output.
      /// </summary>
      /// <param name="element">Owner connection <see cref="Element"/>.</param>
      /// <param name="output"><see cref="FeedbackDecoderConnection"/> index.</param>
      /// <returns>The requested <see cref="FeedbackDecoderConnection"/> or <c>null</c> if no <see cref="FeedbackDecoderConnection"/> is used by the specified <see cref="Element"/> and index.</returns>
      public static FeedbackDecoderConnection GetByOutput(Element element, int output)
      {
         foreach (FeedbackDecoderConnection connection in element?.FeedbackConnections)
         {
            if (connection.DecoderOutput == output)
               return connection;
         }

         return null;
      }

      /// <summary>
      /// Get a <see cref="FeedbackDecoderConnection"/> by its index.
      /// </summary>
      /// <param name="element">Owner connection <see cref="Element"/>.</param>
      /// <param name="index"><see cref="FeedbackDecoderConnection"/> index.</param>
      /// <returns>The requested <see cref="AccessoryDecoderConnection"/> or <c>null</c> if no <see cref="FeedbackDecoderConnection"/> is used by the specified <see cref="Element"/> and index.</returns>
      public static FeedbackDecoderConnection GetByIndex(Element element, int index)
      {
         foreach (FeedbackDecoderConnection connection in element?.FeedbackConnections)
         {
            if (connection.Index == index)
               return connection;
         }

         return null;
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ID = 0;
         this.Index = 0;
         this.Device = null;
         this.Element = null;
         this.Name = string.Empty;
         this.Address = 0;
         this.DecoderOutput = 0;
         this.DelayTime = 0;
      }

      #endregion

   }
}
