﻿using Rwm.Otc.Data;

namespace Rwm.Otc.Trains
{
   [ORMTable("TRAIN_CATEGORIES")]
   public class Category : ORMEntity<Category>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Category"/>.
      /// </summary>
      public Category() : base() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey("ID")]
      public override long ID { get; set; } = 0;

      /// <summary>
      /// Nombre identificativo de la categoria.
      /// </summary>
      [ORMProperty("NAME")]
      public string Name { get; set; } = string.Empty;

      /// <summary>
      /// Icono correspondiente a l acategoria (no usado).
      /// </summary>
      [ORMProperty("ICON")]
      public string Icon { get; set; } = string.Empty;

      /// <summary>
      /// Indica si los modelos de la categoria disponen de control de mantenimiento o no.
      /// </summary>
      [ORMProperty("MAINTENANCE")]
      public bool HaveMaintenance { get; set; } = false;

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

   }
}
