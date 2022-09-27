using System.Drawing;

namespace Rwm.Studio.Plugins.Collection.Model
{
   /// <summary>
   /// Implementa una administración o operadora ferroviaria.
   /// </summary>
   public class Administration : IIdentifiableObject
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Administration"/>.
      /// </summary>
      public Administration()
      {
         Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets el identificador único del objeto.
      /// </summary>
      public int ID { get; set; }

      /// <summary>
      /// Gets or sets el nombre.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets la descripción.
      /// </summary>
      public string Description { get; set; }

      /// <summary>
      /// Gets or sets la URL correspondiente a la página web oficial.
      /// </summary>
      public string URL { get; set; }

      /// <summary>
      /// Gets or sets el nombre de archivo (sin ruta) correspondiente al logotipo (imagen) de la administración.
      /// </summary>
      public string LogoFilename { get; set; }

      /// <summary>
      /// Gets or sets la imagen correspondiente al logotipo (imagen) de la administración.
      /// </summary>
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
