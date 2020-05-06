using System;
using Rwm.Otc.Data;

namespace Rwm.Otc.Layout
{
   /// <summary>
   /// Implements the connection between an accessory module output with an element.
   /// </summary>
   [ORMTable("FB_DECODER_CONNECTIONS")]
   public class FeedbackEncoderConnection : ORMEntity<FeedbackEncoderConnection>, IComparable<FeedbackEncoderConnection>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="FeedbackEncoderConnection"/>.
      /// </summary>
      public FeedbackEncoderConnection() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; } = 0;

      /// <summary>
      /// Gets or sets the related feedback connection.
      /// </summary>
      [ORMProperty("INPUTID", "FeedbackConnection")]
      public FeedbackEncoderInput EncoderInput { get; set; } = null;

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

      #endregion

      #region Methods

      /// <summary>
      /// Compare the current instance with other.
      /// </summary>
      /// <param name="other">The other instance to compare.</param>
      /// <returns>An integer indicating if the two instances are equals or not.</returns>
      public int CompareTo(FeedbackEncoderConnection other)
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
      public static FeedbackEncoderConnection GetByIndex(Element element, int index)
      {
         foreach (FeedbackEncoderConnection connection in element?.FeedbackConnections)
         {
            if (connection.ElementPinIndex == index)
               return connection;
         }

         return null;
      }

      #endregion

   }
}
