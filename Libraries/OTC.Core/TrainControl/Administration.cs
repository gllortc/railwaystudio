using System.Drawing;
using Rwm.Otc.Data.ORM;

namespace Rwm.Otc.TrainControl
{
   /// <summary>
   /// Implementa una administración o operadora ferroviaria.
   /// </summary>
   [ORMTable("admins")]
   public class Administration : ORMEntity<Administration>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Administration"/>.
      /// </summary>
      public Administration() : base()
      {
         this.Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey("adminid")]
      public override long ID { get; set; }

      /// <summary>
      /// Gets or sets el nombre.
      /// </summary>
      [ORMProperty("adminname")]
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets la descripción.
      /// </summary>
      [ORMProperty("admindesc")]
      public string Description { get; set; }

      /// <summary>
      /// Gets or sets la URL correspondiente a la página web oficial.
      /// </summary>
      [ORMProperty("adminurl")]
      public string URL { get; set; }

      /// <summary>
      /// Gets or sets el nombre de archivo (sin ruta) correspondiente al logotipo (imagen) de la administración.
      /// </summary>
      [ORMProperty("adminfile")]
      public string LogoFilename { get; set; }

      /// <summary>
      /// Gets or sets la imagen correspondiente al logotipo (imagen) de la administración.
      /// </summary>
      [ORMProperty("adminimage")]
      public Image LogoImage { get; set; }

      #endregion

      #region Private Members

      private void Initialize()
      {
         this.ID = 0;
         this.Name = string.Empty;
         this.Description = string.Empty;
         this.URL = string.Empty;
         this.LogoFilename = string.Empty;
         this.LogoImage = null;
      }

      #endregion

   }
}
