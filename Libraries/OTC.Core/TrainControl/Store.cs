using Rwm.Otc.Data.ORM;

namespace Rwm.Otc.TrainControl
{
   /// <summary>
   /// Representa un comercio dónde se pueden adquirir modelos.
   /// </summary>
   [ORMTable("STORES")]
   public class Store : ORMEntity<Store>
   {

      #region Constructors

      public Store() : base() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; }

      /// <summary>
      /// Gets or sets the store name.
      /// </summary>
      [ORMProperty("NAME")]
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets the store description/notes.
      /// </summary>
      [ORMProperty("DESCRIPTION")]
      public string Description { get; set; }

      /// <summary>
      /// Gets or sets the store address.
      /// </summary>
      [ORMProperty("ADDRESS")]
      public string Address { get; set; }

      /// <summary>
      /// Gets or sets the store phone.
      /// </summary>
      [ORMProperty("PHONE")]
      public string Phone { get; set; }

      /// <summary>
      /// Gets or sets the store contact mail.
      /// </summary>
      [ORMProperty("EMAIL")]
      public string Mail { get; set; }

      /// <summary>
      /// Gets or sets the store website URL.
      /// </summary>
      [ORMProperty("WEB")]
      public string URL { get; set; }

      #endregion

   }
}
