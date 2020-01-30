using System.IO;
using Rwm.Otc.Data.ORM;

namespace Rwm.Otc.TrainControl
{
   [ORMTable("decoders")]
   public class Decoder : ORMEntity<Decoder>
   {

      #region Constructors

      /// <summary>
      /// Devuelve una instancia de RCDecoder.
      /// </summary>
      public Decoder() : base()
      {
         this.ID = 0;
         this.Name = string.Empty;
         this.Description = string.Empty;
         this.File = null;
         this.URL = string.Empty;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey("decid")]
      public override long ID { get; set; }

      [ORMProperty("decname")]
      public string Name { get; set; }

      [ORMProperty("decdesc")]
      public string Description { get; set; }

      [ORMProperty("decfile")]
      public MemoryStream File { get; set; }

      [ORMProperty("decurl")]
      public string URL { get; set; }

      #endregion

      #region Static Members

      /// <summary>
      /// Nombre de la carpeta que contiene los manuales
      /// </summary>
      public static string FilesFolderName
      {
         get { return "manuals"; }
      }

      /// <summary>
      /// Devuelve la ruta de acceso a la carpeta de documentación de descodificadores.
      /// </summary>
      public static string FilesPath
      {
         get { return Path.Combine(System.Windows.Forms.Application.StartupPath, Decoder.FilesFolderName); }
      }

      #endregion

      //#region Methods

      ///// <summary>
      ///// Devuelve la ruta completa al archivo asociado al decoder
      ///// </summary>
      //public string GetFilePath()
      //{
      //   if (this.File.Equals(string.Empty)) return string.Empty;
      //   return Path.Combine(DecoderDAO.FilesPath, this.File);
      //}

      //#endregion

   }
}
