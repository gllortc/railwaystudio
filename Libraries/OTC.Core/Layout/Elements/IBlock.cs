using Rwm.Otc.Systems;
using System;

namespace Rwm.Otc.Layout.Elements
{
   /// <summary>
   /// Interface implemented by all elements with occupation capabilities.
   /// </summary>
   public interface IBlock
   {

      #region Methods

      /// <summary>
      /// Identificador único del elemento.
      /// </summary>
      long ID { get; }

      /// <summary>
      /// Gets a value indicating if the block is occupied or not.
      /// </summary>
      bool IsOccupied { get; }

      /// <summary>
      /// Gets or sets the train who is occupying the block.
      /// </summary>
      TrainControl.CollectionModel Train { get; set; }

      #endregion

      #region Events

      /// <summary>
      /// Event raised when a new feedback status is adopted by the element.
      /// </summary>
      event EventHandler<OccupationEventArgs> OccupationChanged;

      #endregion

   }
}
