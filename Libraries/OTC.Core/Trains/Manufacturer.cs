using Rwm.Otc.Data;

namespace Rwm.Otc.Trains
{
   /// <summary>
   /// Represents a model manufacturer.
   /// </summary>
   [ORMTable("MANUFACTURERS")]
   public class Manufacturer : ORMEntity<Manufacturer>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Manufacturer"/>.
      /// </summary>
      public Manufacturer() : base() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; } = 0;

      [ORMProperty("NAME")]
      public string Name { get; set; } = string.Empty;

      [ORMProperty("DESCRIPTION")]
      public string Description { get; set; } = string.Empty;

      [ORMProperty("ADDRESS")]
      public string Address { get; set; } = string.Empty;

      [ORMProperty("WEB")]
      public string URL { get; set; } = string.Empty;

      #endregion

   }
}
