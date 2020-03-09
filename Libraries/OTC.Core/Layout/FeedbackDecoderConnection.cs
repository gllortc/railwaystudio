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
      /// Gets or sets the output digital address.
      /// </summary>
      [ORMProperty("ADDRESS")]
      public int Address { get; set; }

      /// <summary>
      /// Gets or sets the decoder input where it is connected (starting at 1).
      /// </summary>
      [ORMProperty("INPUT")]
      public int DecoderInput { get; set; }

      /// <summary>
      /// Gets or sets the time (in milliseconds) to switch.
      /// </summary>
      [ORMProperty("DELAYTIME")]
      public int DelayTime { get; set; }

      /// <summary>
      /// Gets the sensor address (reported by digital system).
      /// </summary>
      public int SensorAddress
      {
         get { return ((this.Address - 1) * this.Device.Inputs) + this.DecoderInput; }
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
         return this.ElementPinIndex.CompareTo(other.ElementPinIndex);
      }

      #endregion

      #region Static Members

      /// <summary>
      /// Get a <see cref="FeedbackDecoderConnection"/> by its device output.
      /// </summary>
      /// <param name="element">Owner connection <see cref="Element"/>.</param>
      /// <param name="output"><see cref="FeedbackDecoderConnection"/> index.</param>
      /// <returns>The requested <see cref="FeedbackDecoderConnection"/> or <c>null</c> if no <see cref="FeedbackDecoderConnection"/> is used by the specified <see cref="Element"/> and index.</returns>
      public static FeedbackDecoderConnection GetByInput(Element element, int output)
      {
         foreach (FeedbackDecoderConnection connection in element?.FeedbackConnections)
         {
            if (connection.DecoderInput == output)
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
            if (connection.ElementPinIndex == index)
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
         this.ElementPinIndex = 0;
         this.Device = null;
         this.Element = null;
         this.Address = 0;
         this.DecoderInput = 0;
         this.DelayTime = 0;
      }

      #endregion

   }
}
