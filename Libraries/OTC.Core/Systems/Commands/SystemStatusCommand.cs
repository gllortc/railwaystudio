namespace Rwm.Otc.Systems.Commands
{
   /// <summary>
   /// Implementa el comando DCC Command Station Status.
   /// </summary>
   public class SystemStatusCommand : ICommand
   {
      /// <summary>
      /// Modos de inicio de la central digital
      /// </summary>
      public enum StartModes : int
      {
         /// <summary>Al iniciar el sistema todas las locomotoras arrancan a velocidad 0.</summary>
         Manual = 0,
         /// <summary>Al iniciar el sistema todas las locomotoras arrancan a la velocidad que tenian al apagar el sistema.</summary>
         Automatic = 1
      }

      private int _id = -1;
      private bool _emergencyOff = false;
      private bool _emergencyStop = false;
      private StartModes _start = StartModes.Manual;
      private bool _serviceMode = false;
      private bool _powerUp = false;
      private bool _ramError = false;

      /// <summary>
      /// Devuelve o establece el identificador del comando.
      /// </summary>
      public int ID
      {
         get { return _id; }
         set { _id = value; }
      }

      /// <summary>
      /// Devuelve el nombre del comando para su lectura.
      /// </summary>
      public string Name
      {
         get { return "Command Station Status"; }
      }

      /// <summary>
      /// Indica si la central se encuentra en apagada de emergencia.
      /// </summary>
      public bool IsInEmergencyOff
      {
         get { return _emergencyOff; }
         set { _emergencyOff = value; }
      }

      /// <summary>
      /// Indica si la central se encuentra en paro de emergencia.
      /// </summary>
      public bool IsInEmergencyStop
      {
         get { return _emergencyStop; }
         set { _emergencyStop = value; }
      }

      /// <summary>
      /// Contiene el modo de inicio configurado en la central.
      /// </summary>
      public StartModes StartMode
      {
         get { return _start; }
         set { _start = value; }
      }

      /// <summary>
      /// Indica si la central se encuentra en modo servicio.
      /// </summary>
      public bool IsInServiceMode
      {
         get { return _serviceMode; }
         set { _serviceMode = value; }
      }

      /// <summary>
      /// Indica si la central está arrancando.
      /// </summary>
      public bool IsPerformingPoerUp
      {
         get { return _powerUp; }
         set { _powerUp = value; }
      }

      /// <summary>
      /// Indica si se han hallado errores en la memoria de la central.
      /// </summary>
      public bool HaveRAMError
      {
         get { return _ramError; }
         set { _ramError = value; }
      }
   }
}
