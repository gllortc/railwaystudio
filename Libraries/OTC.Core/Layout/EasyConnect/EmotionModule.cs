using Rwm.Otc.Data;

namespace Rwm.Otc.Layout.EasyConnect
{

   /// <summary>
   /// Implements a control device (accessory decoder, sensor encoder, etc).
   /// </summary>
   [ORMTable("EC_EMOTION_MODULES")]
   public class EmotionModule : ORMEntity<EmotionModule>
   {

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="EmotionModule"/>.
      /// </summary>
      public EmotionModule() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; } = 0;

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMProperty("PROJECTID")]
      public Project Project { get; set; } = null;

      /// <summary>
      /// Gets or sets the owner layout module where the decoder is installed.
      /// </summary>
      [ORMProperty("MODULEID")]
      public Module Module { get; set; } = null;

      /// <summary>
      /// Gets or sets the decoder name.
      /// </summary>
      [ORMProperty("NAME")]
      public string Name { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets the decoder's model name or number.
      /// </summary>
      [ORMProperty("MODEL")]
      public string Model { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets las notas y comentarios al elemento.
      /// </summary>
      [ORMProperty("DESCRIPTION")]
      public string Notes { get; set; } = string.Empty;

      /// <summary>
      /// Gets a string describing the manufacturer and model of the current accessory decoder.
      /// </summary>
      public string ModelDescription
      {
         get
         {
            if (string.IsNullOrWhiteSpace(this.Model))
               return "-";
            else
               return ("Railwaymania " + this.Model).Trim();
         }
      }

      /// <summary>
      /// Gets the associated small icon (16x16px).
      /// </summary>
      public static System.Drawing.Image SmallIcon
      {
         get { return Properties.Resources.ICO_ACCESSORY_DECODER_16; }
      }

      /// <summary>
      /// Gets the associated large icon (32x32px).
      /// </summary>
      public static System.Drawing.Image LargeIcon
      {
         get { return Properties.Resources.ICO_ACCESSORY_DECODER_32; }
      }

      #endregion

      #region Methods

      #endregion

      #region Private Members

      #endregion

   }
}
