namespace Rwm.Otc.LayoutControl
{
   /// <summary>
   /// Implements the connection between an accessory module output with a block.
   /// </summary>
   public class SensorInput
   {

      #region Enumerations

      public enum DecoderFunctionOutputStatus : int
      {
         Unknown = 99,
         Off = 0,
         On = 1
      }

      #endregion

      #region Constructors

      public SensorInput()
      {
         Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the accessory module output unique identifier (DB).
      /// </summary>
      public int ID { get; set; }

      /// <summary>
      /// Gets or sets the related accessory module unique identifier.
      /// </summary>
      public int DecoderID { get; set; }

      /// <summary>
      /// Gets or sets the related clock unique identifier.
      /// </summary>
      public int BlockID { get; set; }

      /// <summary>
      /// Gets or sets the output name.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets the output digital address.
      /// </summary>
      public int Address { get; set; }

      /// <summary>
      /// Gets or sets the time (in milliseconds) to switch.
      /// </summary>
      public int SwitchTime { get; set; }

      public DecoderFunctionOutputStatus Output1 { get; set; }

      public DecoderFunctionOutputStatus Output2 { get; set; }

      #endregion

      #region Methods
      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ID = 0;
         this.DecoderID = 0;
         this.BlockID = 0;
         this.Name = string.Empty;
         this.Address = 0;
         this.Output1 = DecoderFunctionOutputStatus.Unknown;
         this.Output2 = DecoderFunctionOutputStatus.Unknown;
         this.SwitchTime = 0;
      }

      #endregion

   }
}
