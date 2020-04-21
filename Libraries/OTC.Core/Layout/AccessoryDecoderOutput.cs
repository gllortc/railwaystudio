using System;
using Rwm.Otc.Data;

namespace Rwm.Otc.Layout
{
   [ORMTable("ACC_DECODER_OUTPUTS")]
   public class AccessoryDecoderOutput : ORMEntity<AccessoryDecoderOutput>, IComparable<AccessoryDecoderOutput>
   {

      #region Enumerations

      /// <summary>
      /// Types of accessory decoders
      /// </summary>
      public enum DecoderType : int
      {
         /// <summary>Generic accessory decoder (any manufacturer/model not Railwaymania)</summary>
         Generic = 0,
         /// <summary>Railwaymania Standard Accessory Decoder</summary>
         RwmAccessoryDecoder = 1
      }

      /// <summary>
      /// Types of accessory decoders
      /// </summary>
      public enum OutputMode : int
      {
         /// <summary>Continuous output (eg. signals)</summary>
         Continuous = 1,
         /// <summary>One shot output (eg. turnouts)</summary>
         OneShot = 2,
         /// <summary>Flashing output (eg. railway crossing)</summary>
         Flasher = 3,
         /// <summary>Control a servo motor (eg. turnouts or water loader)</summary>
         ServoControl = 4
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="AccessoryDecoderOutput"/>.
      /// </summary>
      public AccessoryDecoderOutput() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; } = 0;

      /// <summary>
      /// Gets or sets the owner accessort decoder.
      /// </summary>
      [ORMProperty("DECODERID")]
      public AccessoryDecoder AccessoryDecoder { get; set; } = null;

      /// <summary>
      /// Gets or sets the output digital address.
      /// </summary>
      [ORMProperty("ADDRESS")]
      public int Address { get; set; } = 0;

      /// <summary>
      /// Gets or sets the output index (starting by 1).
      /// </summary>
      [ORMProperty("INDEX")]
      public int Index { get; set; } = 0;

      /// <summary>
      /// Gets or sets the output index (starting by 1).
      /// </summary>
      [ORMProperty("MODE")]
      public OutputMode Mode { get; set; } = 0;

      /// <summary>
      /// Gets or sets the shot duration when the output mode is set to <see cref="OutputMode.OneShot" /> in milliseconds.
      /// </summary>
      [ORMProperty("SWITCHTIME")]
      public int SwitchTime { get; set; } = 0;

      /// <summary>
      /// Gets or sets the Arduino pin where accessory is connected to (out 1).
      /// </summary>
      [ORMProperty("OUTPIN1")]
      public int ArduinoPin1 { get; set; } = 0;

      /// <summary>
      /// Gets or sets the Arduino pin where accessory is connected to (out 2).
      /// </summary>
      [ORMProperty("OUTPIN2")]
      public int ArduinoPin2 { get; set; } = 0;

      #endregion

      #region Methods

      /// <summary>
      /// Compare the current instance with other.
      /// </summary>
      /// <param name="other">The other instance to compare.</param>
      /// <returns>An integer indicating if the two instances are equals or not.</returns>
      public int CompareTo(AccessoryDecoderOutput other)
      {
         return this.Index.CompareTo(other.Index);
      }

      #endregion

   }
}
