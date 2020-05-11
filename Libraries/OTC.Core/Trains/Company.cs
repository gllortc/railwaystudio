using System.Drawing;
using Rwm.Otc.Data;

namespace Rwm.Otc.Trains
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
      public Company() : base() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; } = 0;

      /// <summary>
      /// Gets or sets el nombre.
      /// </summary>
      [ORMProperty("NAME")]
      public string Name { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets la descripción.
      /// </summary>
      [ORMProperty("DESCRIPTION")]
      public string Description { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets la URL correspondiente a la página web oficial.
      /// </summary>
      [ORMProperty("WEB")]
      public string URL { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets el nombre de archivo (sin ruta) correspondiente al logotipo (imagen) de la administración.
      /// </summary>
      [ORMProperty("LOGOFILE")]
      public string LogoFilename { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets la imagen correspondiente al logotipo (imagen) de la administración.
      /// </summary>
      [ORMProperty("LOGOIMAGE")]
      public Image LogoImage { get; set; } = null;

      #endregion

   }
}
