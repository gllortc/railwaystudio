using System;

namespace otc.timetables
{

   #region class OTCCirculation

   /// <summary>
   /// Implementa una circulación ferroviaria para una tabla de horarios OTC.
   /// </summary>
   public class OTCCirculation
   {
      private OTCCirculations.OTCCirculationTypes _type;
      private string _number;
      private string _from;
      private string _to;
      private DateTime _arrival;
      private DateTime _departure;
      private string _platform;
      private string _comments;

      /// <summary>
      /// Constructor de la clase
      /// </summary>
      public OTCCirculation()
      {
         _type = OTCCirculations.OTCCirculationTypes.None;
         _number = "";
         _from = "";
         _to = "";
         _arrival = DateTime.Parse("00:00");
         _departure = DateTime.Parse("00:00");
         _platform = "";
         _comments = "";
      }

      /// <summary>
      /// Tipo de circulación
      /// </summary>
      public OTCCirculations.OTCCirculationTypes Type
      {
         get { return _type; }
         set { _type = value; }
      }

      /// <summary>
      /// Número/código de la circulación
      /// </summary>
      public string Number
      {
         get { return _number; }
         set { _number = value; }
      }

      /// <summary>
      /// Orígen de la circulación
      /// </summary>
      public string Source
      {
         get { return _from; }
         set { _from = value; }
      }

      /// <summary>
      /// Destino de la circulación
      /// </summary>
      public string Destination
      {
         get { return _to; }
         set { _to = value; }
      }

      /// <summary>
      /// Hora de llegada
      /// </summary>
      public DateTime Arrival
      {
         get { return _arrival; }
         set { _arrival = value; }
      }

      /// <summary>
      /// Hora de salida
      /// </summary>
      public DateTime Depart
      {
         get { return _departure; }
         set { _departure = value; }
      }

      /// <summary>
      /// Andén
      /// </summary>
      public string Platform
      {
         get { return _platform; }
         set { _platform = value; }
      }

      /// <summary>
      /// Comentarios que deben informarse a los viajeros
      /// </summary>
      public string Comments
      {
         get { return _comments; }
         set { _comments = value; }
      }
   }

   #endregion

}
