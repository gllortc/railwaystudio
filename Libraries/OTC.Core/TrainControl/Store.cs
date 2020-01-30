using Rwm.Otc.Data.ORM;

namespace Rwm.Otc.TrainControl
{
   /// <summary>
   /// Representa un comercio dónde se pueden adquirir modelos.
   /// </summary>
   [ORMTable("stores")]
   public class Store : ORMEntity<Store>
   {

      #region Constructors

      public Store() : base() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey("storeid")]
      public override long ID { get; set; }

      [ORMProperty("storename")]
      public string Name { get; set; }

      [ORMProperty("storedesc")]
      public string Description { get; set; }

      [ORMProperty("storeaddress")]
      public string Address { get; set; }

      [ORMProperty("storephone")]
      public string Phone { get; set; }

      [ORMProperty("storemail")]
      public string Mail { get; set; }

      [ORMProperty("storeurl")]
      public string URL { get; set; }

      #endregion

   }
}
