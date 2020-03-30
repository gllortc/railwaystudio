using Rwm.Otc.Data;

namespace Rwm.Otc.Trains
{
   /// <summary>
   /// Representa una escala de modelismo ferroviario.
   /// </summary>
   [ORMTable("GAUGES")]
   public class Gauge : ORMEntity<Gauge>
   {

      #region Constructors

      public Gauge() : base() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; }

      /// <summary>
      /// Gets or sets the gauge name.
      /// </summary>
      [ORMProperty("NAME")]
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets the gauge scale notation (1:87, 1:160, etc).
      /// </summary>
      [ORMProperty("SCALE")]
      public string Notation { get; set; }

      /// <summary>
      /// Gets or sets the scale model track width (in mm).
      /// </summary>
      [ORMProperty("SCALE_TRACK_WIDTH")]
      public double TrackWidthScale { get; set; }

      /// <summary>
      /// Gets or sets the prototype track width (in mm).
      /// </summary>
      [ORMProperty("REAL_TRACK_WIDTH")]
      public double TrackWidthReal { get; set; }

      #endregion

   }

}
