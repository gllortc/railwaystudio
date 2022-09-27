namespace Rwm.Studio.Plugins.Collection.Model
{
   /// <summary>
   /// Representa una escala de modelismo ferroviario.
   /// </summary>
   public class Scale : IIdentifiableObject
   {
      // Declaración de variables inbternas
      private int pID;
      private string pName;
      private string pScale;
      private double pTrackWidthScale;
      private double pTrackWidthReal;

      #region Properties

      /// <summary>
      /// Identificador de la escala.
      /// </summary>
      public int ID
      {
         get { return pID; }
         set { pID = value; }
      }

      /// <summary>
      /// Nombre de la escala (H0, N, etc).
      /// </summary>
      public string Name
      {
         get { return pName; }
         set { pName = value; }
      }

      /// <summary>
      /// Notación de la escala (1:87, 1:160, etc).
      /// </summary>
      public string ScaleNotation
      {
         get { return pScale; }
         set { pScale = value; }
      }

      /// <summary>
      /// Ancho de via a escala (en mm). 
      /// </summary>
      public double TrackWidthScale
      {
         get { return pTrackWidthScale; }
         set { pTrackWidthScale = value; }
      }

      /// <summary>
      /// Ancho de via real (en mm).
      /// </summary>
      public double TrackWidthReal
      {
         get { return pTrackWidthReal; }
         set { pTrackWidthReal = value; }
      }

      #endregion

   }

}
