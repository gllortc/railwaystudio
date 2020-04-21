using System.IO;

namespace Rwm.Studio.Plugins.Collection.Model
{
   /// <summary>
   /// Implementa un archivo adjunto a un modelo.
   /// </summary>
   public class ModelFileAttachment
   {
      // Declaración de variables internas
      private int _id;
      private int _modelId;
      private string _name;
      private string _filename;

      /// <summary>
      /// Devuelve una instancia de <see cref="ModelFileAttachment"/>.
      /// </summary>
      public ModelFileAttachment()
      {
      }

      #region Properties

      /// <summary>
      /// Gets or sets el identificador único del archivo.
      /// </summary>
      public int ID
      {
         get { return _id; }
         set { _id = value; }
      }

      /// <summary>
      /// Gets or sets el identificador del modelo al que pertenece.
      /// </summary>
      public int ModelID
      {
         get { return _modelId; }
         set { _modelId = value; }
      }

      /// <summary>
      /// Gets or sets el nombre del documento.
      /// </summary>
      public string Name
      {
         get { return _name; }
         set { _name = value; }
      }

      /// <summary>
      /// Gets or sets el nombre del archivo (sin path).
      /// </summary>
      public string Filename
      {
         get { return _filename; }
         set { _filename = value; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Devuelve el nombre completo (con path) del archivo relacionado.
      /// </summary>
      /// <returns></returns>
      public string GetFullFilename()
      {
         return Path.Combine(Path.Combine(DecoderDAO.FilesPath, this.Filename));
      }

      #endregion

   }
}
