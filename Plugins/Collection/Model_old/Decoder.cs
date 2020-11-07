using System.IO;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Collection.Model
{
   public class Decoder : IIdentifiableObject
   {

      #region Constructors

      /// <summary>
      /// Devuelve una instancia de RCDecoder.
      /// </summary>
      public Decoder()
      {
         this.ID = 0;
         this.Name = string.Empty;
         this.Description = string.Empty;
         this.File = string.Empty;
         this.URL = string.Empty;
      }

      #endregion

      #region Properties

      public int ID { get; set; }

      public string Name { get; set; }

      public string Description { get; set; }

      public string File { get; set; }

      public string URL { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Devuelve la ruta completa al archivo asociado al decoder
      /// </summary>
      public string GetFilePath()
      {
         if (this.File.Equals(string.Empty)) return string.Empty;
         return Path.Combine(DecoderDAO.FilesPath, this.File);
      }

      #endregion

   }
}
