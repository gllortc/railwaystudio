namespace Rwm.Otc.Systems.Commands
{
   /// <summary>
   /// Implementa el comando para establecer la velocidad de una locomotora.
   /// </summary>
   public class SetLocomotiveSpeedCommand : ICommand
   {
      /// <summary>
      /// Enumera los pasos de velocidad soportados por XPressNet.
      /// </summary>
      public enum SpeedSteps : int
      {
         /// <summary>14 pasos de velocidad.</summary>
         SpeedSteps14 = 14,
         /// <summary>27 pasos de velocidad.</summary>
         SpeedSteps27 = 27,
         /// <summary>28 pasos de velocidad.</summary>
         SpeedSteps28 = 28,
         /// <summary>128 pasos de velocidad.</summary>
         SpeedSteps128 = 128
      }

      private bool _forward = true;
      private int _id = -1;
      private int _address = 0;
      private int _speed = 0;
      private SpeedSteps _steps = SpeedSteps.SpeedSteps28;

      /// <summary>
      /// Devuelve una instancia de OTCSysCmdSetLocomotiveSpeed.
      /// </summary>
      /// <param name="address">Dirección de la locomotora.</param>
      /// <param name="steps">Número de pasos de velocidad soportados por el descodificador.</param>
      /// <param name="speed">Velocidad a alcanzar.</param>
      /// <param name="forward">Indica si circula en dirección delante o atrás.</param>
      public SetLocomotiveSpeedCommand(int address, SpeedSteps steps, int speed, bool forward)
      {
         _address = address;
         _forward = forward;
         _speed = speed;
         _steps = steps;
      }

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
         get { return "Accessory Decoder Operation"; }
      }

      /// <summary>
      /// Devuelve la dirección digital del comando.
      /// </summary>
      public int Address
      {
         get { return _address; }
      }

      /// <summary>
      /// Devuelve el número de pasos de velocidad del descodificador de la locomotora.
      /// </summary>
      public SpeedSteps Steps
      {
         get { return _steps; }
      }

      /// <summary>
      /// Devuelve la velocidad que debe tomar la locomotora.
      /// </summary>
      public int Speed
      {
         get { return _speed; }
      }

      /// <summary>
      /// Devuelve un valor que indica si la locomotora circula hacia adelante o no.
      /// </summary>
      public bool Forward
      {
         get { return _forward; }
      }
   }
}
