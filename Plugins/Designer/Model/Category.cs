namespace Rwm.Studio.Plugins.Collection.Model
{
   public class Category : IIdentifiableObject
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Category"/>.
      /// </summary>
      public Category()
      {
         this.Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Identificador único de la categoria.
      /// </summary>
      public int ID { get; set; }

      /// <summary>
      /// Nombre identificativo de la categoria.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Icono correspondiente a l acategoria (no usado).
      /// </summary>
      public string Icon { get; set; }

      /// <summary>
      /// Indica si los modelos de la categoria disponen de control de mantenimiento o no.
      /// </summary>
      public bool HaveMaintenance { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Convert the instance data into a readable string.
      /// </summary>
      /// <returns>A string containing the text representing the instance data.</returns>
      public override string ToString()
      {
         return this.Name;
      }

      #endregion

      #region Private Members

      private void Initialize()
      {
         this.ID = 0;
         this.Name = string.Empty;
         this.Icon = string.Empty;
         this.HaveMaintenance = false;
      }

      #endregion

   }
}
