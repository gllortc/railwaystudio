using Rwm.Otc.Data;

namespace Rwm.Otc.Layout
{
   [ORMTable("ACC_STATUS")]
   public class AccessoryStatus : ORMEntity<AccessoryStatus>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="AccessoryStatus"/>.
      /// </summary>
      public AccessoryStatus() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; }

      [ORMProperty("elementtypeid")]
      public ElementType ElementType { get; set; }

      [ORMProperty("value")]
      public int Status { get; set; }

      [ORMProperty("name")]
      public string Name { get; set; }

      #endregion

   }
}
