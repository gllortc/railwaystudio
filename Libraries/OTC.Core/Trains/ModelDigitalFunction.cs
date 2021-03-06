﻿using Rwm.Otc.Data;

namespace Rwm.Otc.Trains
{
   [ORMTable("TRAIN_DECODER_FUNCTIONS")]
   public class ModelDigitalFunction : ORMEntity<ModelDigitalFunction>
   {

      #region Constructors

      /// <summary>
      /// Devuelve una instancia de RCModelDigitalFunction.
      /// </summary>
      public ModelDigitalFunction() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; }

      /// <summary>
      /// Gets or sets el identificador del modelo al que está asociado.
      /// </summary>
      [ORMProperty("TRAINID")]
      public Train Model { get; set; }

      /// <summary>
      /// Gets or sets el número de la función.
      /// </summary>
      [ORMProperty("NUM")]
      public int Number { get; set; }

      /// <summary>
      /// Gets or sets la descripción de la función.
      /// </summary>
      [ORMProperty("NAME")]
      public string Name { get; set; }

      #endregion

   }
}
