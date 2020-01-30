using System;
using System.Threading;

namespace otc.timetables
{

   #region class OTCTimetableProcessor

   /// <summary>
   /// Implementa una clase para el procesado y ejecución del horario de circulaciones OTC.
   /// </summary>
   public class OTCTimetableProcessor
   {
      private Thread _thread = null;
      private DateTime _time;
      private OTCTimetable _timetable = null;

      /// <summary>
      /// Devuelve una instancia de OTCTimetableProcessor.
      /// </summary>
      public OTCTimetableProcessor(OTCTimetable timetable)
      {
         _time = DateTime.Parse("00:00");
         _timetable = timetable;
         _thread = new Thread(new ThreadStart(RunTimetable));
      }

      /// <summary>
      /// Hora interna del proceso.
      /// </summary>
      public DateTime Time
      {
         get { return _time; }
         set { _time = value; }
      }

      /// <summary>
      /// Inicia el horario.
      /// </summary>
      public void Run()
      {
         _thread.Start();
      }

      /// <summary>
      /// pausa el horario (sin detenerlo).
      /// </summary>
      public void Pause()
      {
         _thread.Join();
      }

      /// <summary>
      /// Detiene el proceso.
      /// </summary>
      public void Stop()
      {
         _thread.Abort();
      }

      //===============================================
      // Callbacks
      //===============================================

      /// <summary>
      /// Test method.
      /// </summary>
      public static void RunTimetable()
      {
         while (true)
         {
            System.Console.WriteLine(" Hey!, My Thread Function Running");
         }
      }
   }

   #endregion

}
