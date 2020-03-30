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
      public Manufacturer() : base()
      {
         Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; }

      [ORMProperty("name")]
      public string Name { get; set; }

      [ORMProperty("description")]
      public string Description { get; set; }

      [ORMProperty("address")]
      public string Address { get; set; }

      [ORMProperty("web")]
      public string URL { get; set; }

      #endregion

      #region Private Members

      /// <summary>
      /// Initializes the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ID = 0;
         this.Name = string.Empty;
         this.Description = string.Empty;
         this.Address = string.Empty;
         this.URL = string.Empty;
      }

      #endregion

   }
}
