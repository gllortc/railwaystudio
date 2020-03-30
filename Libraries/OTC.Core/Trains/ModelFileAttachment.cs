using System.IO;

namespace Rwm.Otc.Trains
{
   /// <summary>
   /// Implementa un archivo adjunto a un modelo.
   /// </summary>
   public class ModelFileAttachment
   {

      #region Constructors

      /// <summary>
      /// Devuelve una instancia de <see cref="ModelFileAttachment"/>.
      /// </summary>
      public ModelFileAttachment() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets el identificador único del archivo.
      /// </summary>
      public int ID { get; set; }

      /// <summary>
      /// Gets or sets el identificador del modelo al que pertenece.
      /// </summary>
      public int ModelID { get; set; }

      /// <summary>
      /// Gets or sets el nombre del documento.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets el nombre del archivo (sin path).
      /// </summary>
      public string Filename { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Devuelve el nombre completo (con path) del archivo relacionado.
      /// </summary>
      /// <returns></returns>
      public string GetFullFilename()
      {
         return Path.Combine(Path.Combine(TrainDecoder.FilesPath, this.Filename));
      }

      #endregion

   }
}
