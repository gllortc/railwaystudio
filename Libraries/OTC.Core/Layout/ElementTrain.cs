using System;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Trains;

namespace Rwm.Otc.Layout
{
   /// <summary>
   /// Implements the relation between element and train.
   /// It is used to know where is a train in the layout.
   /// </summary>
   [ORMTable("ELEMENT_TRAINS")]
   public class ElementTrain : ORMEntity<ElementTrain>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ElementTrain"/>.
      /// </summary>
      public ElementTrain() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; } = 0;

      /// <summary>
      /// Gets or sets the related accessory module.
      /// </summary>
      [ORMProperty("elementid", "Train")]
      public Element Element { get; set; } = null;

      /// <summary>
      /// Gets or sets the related element.
      /// </summary>
      [ORMProperty("trainid")]
      public Train Train { get; set; } = null;

      #endregion

      #region Methods

      

      #endregion

   }
}
