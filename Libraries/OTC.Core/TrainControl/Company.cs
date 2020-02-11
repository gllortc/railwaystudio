using System.Drawing;
using Rwm.Otc.Data.ORM;

namespace Rwm.Otc.TrainControl
{
   /// <summary>
   /// Implementa una administración o operadora ferroviaria.
   /// </summary>
   [ORMTable("COMPANIES")]
   public class Company : ORMEntity<Company>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Company"/>.
      /// </summary>
      public Company() : base()
      {
         this.Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; }

      /// <summary>
      /// Gets or sets el nombre.
      /// </summary>
      [ORMProperty("name")]
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets la descripción.
      /// </summary>
      [ORMProperty("description")]
      public string Description { get; set; }

      /// <summary>
      /// Gets or sets la URL correspondiente a la página web oficial.
      /// </summary>
      [ORMProperty("web")]
      public string URL { get; set; }

      /// <summary>
      /// Gets or sets el nombre de archivo (sin ruta) correspondiente al logotipo (imagen) de la administración.
      /// </summary>
      [ORMProperty("logofile")]
      public string LogoFilename { get; set; }

      /// <summary>
      /// Gets or sets la imagen correspondiente al logotipo (imagen) de la administración.
      /// </summary>
      [ORMProperty("logoimage")]
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
