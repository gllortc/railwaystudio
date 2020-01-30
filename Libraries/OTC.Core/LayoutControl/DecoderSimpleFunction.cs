namespace Rwm.Otc.LayoutControl
{
   public class DecoderSimpleFunction
   {

      #region Enumerations

      public enum DecoderFunctionStatus : int
      {
         Unknown = 0,
         Output1 = 1,
         Output2 = 2
      }

      #endregion

      #region Constructors

      public DecoderSimpleFunction()
      {
         Initialize();
      }

      #endregion

      #region Properties

      public int ID { get; set; }

      public int DecoderID { get; set; }

      public int BlockID { get; set; }

      public string Name { get; set; }

      public int Address { get; set; }

      public DecoderFunctionStatus Status { get; set; }

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
         this.Status = DecoderFunctionStatus.Unknown;
      }

      #endregion

   }
}
