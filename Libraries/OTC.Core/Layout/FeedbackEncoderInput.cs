﻿using System;
using Rwm.Otc.Data;

namespace Rwm.Otc.Layout
{
   /// <summary>
   /// Implements the connection between an accessory module output with an element.
   /// </summary>
   [ORMTable("FB_DECODER_INPUTS")]
   public class FeedbackEncoderInput : ORMEntity<FeedbackEncoderInput>, IComparable<FeedbackEncoderInput>
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
      /// Returns a new instance of <see cref="FeedbackEncoderInput"/>.
      /// </summary>
      public FeedbackEncoderInput() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; } = 0;

      /// <summary>
      /// Gets or sets the connection to the element.
      /// </summary>
      public FeedbackEncoderConnection FeedbackConnection { get; set; } = null;

      /// <summary>
      /// Gets or sets the output digital address.
      /// </summary>
      [ORMProperty("ADDRESS")]
      public int Address { get; set; } = 0;

      /// <summary>
      /// Gets or sets the element connection index (number of device output, 1 based).
      /// </summary>
      [ORMProperty("INDEX")]
      public int Index { get; set; } = 0;

      /// <summary>
      /// Gets or sets the related feedback decoder.
      /// </summary>
      [ORMProperty("DECODERID")]
      public FeedbackEncoder FeedbackEncoder { get; set; } = null;

      /// <summary>
      /// Gets or sets the decoder point address (each address have 1 or more ponit addresses).
      /// </summary>
      [ORMProperty("POINT")]
      public int PointAddress { get; set; } = 0;

      /// <summary>
      /// Gets or sets the time (in milliseconds) to switch.
      /// </summary>
      [ORMProperty("DELAYTIME")]
      public int DelayTime { get; set; } = 0;

      #endregion

      #region Methods

      /// <summary>
      /// Compare the current instance with other.
      /// </summary>
      /// <param name="other">The other instance to compare.</param>
      /// <returns>An integer indicating if the two instances are equals or not.</returns>
      public int CompareTo(FeedbackEncoderInput other)
      {
         return this.Index.CompareTo(other.Index);
      }

      #endregion

      #region Static Members

      ///// <summary>
      ///// Get a <see cref="FeedbackEncoderInput"/> by its device output.
      ///// </summary>
      ///// <param name="element">Owner connection <see cref="Element"/>.</param>
      ///// <param name="output"><see cref="FeedbackEncoderInput"/> index.</param>
      ///// <returns>The requested <see cref="FeedbackEncoderInput"/> or <c>null</c> if no <see cref="FeedbackEncoderInput"/> is used by the specified <see cref="Element"/> and index.</returns>
      //public static FeedbackEncoderInput GetByInput(Element element, int output)
      //{
      //   foreach (FeedbackEncoderInput connection in element?.FeedbackConnections)
      //   {
      //      if (connection.DecoderInput == output)
      //         return connection;
      //   }

      //   return null;
      //}

      ///// <summary>
      ///// Get a <see cref="FeedbackEncoderInput"/> by its index.
      ///// </summary>
      ///// <param name="element">Owner connection <see cref="Element"/>.</param>
      ///// <param name="index"><see cref="FeedbackEncoderInput"/> index.</param>
      ///// <returns>The requested <see cref="AccessoryDecoderConnection"/> or <c>null</c> if no <see cref="FeedbackEncoderInput"/> is used by the specified <see cref="Element"/> and index.</returns>
      //public static FeedbackEncoderInput GetByIndex(Element element, int index)
      //{
      //   foreach (FeedbackEncoderInput connection in element?.FeedbackConnections)
      //   {
      //      if (connection.ElementPinIndex == index)
      //         return connection;
      //   }

      //   return null;
      //}

      #endregion

   }
}
