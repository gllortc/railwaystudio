using Rwm.Otc.Data.ORM;

namespace Rwm.Otc.TrainControl
{
   /// <summary>
   /// Representa una escala de modelismo ferroviario.
   /// </summary>
   [ORMTable("scales")]
   public class Gauge : ORMEntity<Gauge>
   {

      #region Constructors

      public Gauge() : base() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey("scid")]
      public override long ID { get; set; }

      /// <summary>
      /// Nombre de la escala (H0, N, etc).
      /// </summary>
      [ORMProperty("scname")]
      public string Name { get; set; }

      /// <summary>
      /// Notación de la escala (1:87, 1:160, etc).
      /// </summary>
      [ORMProperty("scscale")]
      public string ScaleNotation { get; set; }

      /// <summary>
      /// Ancho de via a escala (en mm). 
      /// </summary>
      [ORMProperty("sctwidth")]
      public double TrackWidthScale { get; set; }

      /// <summary>
      /// Ancho de via real (en mm).
      /// </summary>
      [ORMProperty("scrtwidth")]
      public double TrackWidthReal { get; set; }

      #endregion

   }

}
