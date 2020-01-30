using System;
using System.Drawing;

namespace otc.fremo
{

   /// <summary>
   /// Implementa una órden de carga para un vagón de mercancías.
   /// </summary>
   public class OTCWaybill
   {
      string _id = DateTime.Now.ToString("yyyyMMddhhmmss");
      string _from = "";
      string _to = "";
      string _fromRoute = "";
      string _toRoute = "";
      Color _fromColor = Color.White;
      Color _toColor = Color.White;
      string _load = "";
      string _notes = "";

      #region Properties

      /// <summary>
      /// Identificador del contrato de carga
      /// </summary>
      public string ID
      {
         get { return _id; }
         set { _id = value; }
      }

      /// <summary>
      /// Estación de orígen
      /// </summary>
      public string From
      {
         get { return _from; }
         set { _from = value; }
      }

      /// <summary>
      /// Estación de destino
      /// </summary>
      public string To
      {
         get { return _to; }
         set { _to = value; }
      }

      /// <summary>
      /// Ruta de orígen a detino
      /// </summary>
      public string FromRoute
      {
         get { return _fromRoute; }
         set { _fromRoute = value; }
      }

      /// <summary>
      /// Ruta de destino a orígen
      /// </summary>
      public string ToRoute
      {
         get { return _toRoute; }
         set { _toRoute = value; }
      }

      /// <summary>
      /// Color distintivo de orígen
      /// </summary>
      public Color FromColor
      {
         get { return _fromColor; }
         set { _fromColor = value; }
      }

      /// <summary>
      /// Color distintivo de destino
      /// </summary>
      public Color ToColor
      {
         get { return _toColor; }
         set { _toColor = value; }
      }

      /// <summary>
      /// Información de la carga
      /// </summary>
      public string Load
      {
         get { return _load; }
         set { _load = value; }
      }

      /// <summary>
      /// Notas de carga
      /// </summary>
      public string Notes
      {
         get { return _notes; }
         set { _notes = value; }
      }

      #endregion

   }
}
