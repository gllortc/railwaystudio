using Rwm.Otc.Data;

namespace Rwm.Otc.Trains
{
   [ORMTable("TRAIN_CATEGORIES")]
   public class Category : ORMEntity<Category>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Category"/>.
      /// </summary>
      public Category() : base()
      {
         this.Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey("typeid")]
      public override long ID { get; set; }

      /// <summary>
      /// Nombre identificativo de la categoria.
      /// </summary>
      [ORMProperty("typename")]
      public string Name { get; set; }

      /// <summary>
      /// Icono correspondiente a l acategoria (no usado).
      /// </summary>
      [ORMProperty("typeicon")]
      public string Icon { get; set; }

      /// <summary>
      /// Indica si los modelos de la categoria disponen de control de mantenimiento o no.
      /// </summary>
      [ORMProperty("typemaint")]
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
