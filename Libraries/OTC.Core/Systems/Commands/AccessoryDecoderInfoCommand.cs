namespace Rwm.Otc.Systems.Commands
{
   /// <summary>
   /// Implementa el comando DCC Accessory Decoder Info.
   /// </summary>
   public class AccessoryDecoderInfoCommand : ICommand
   {
      /// <summary>
      /// Enumera los tipos de descodificador de accesorios
      /// </summary>
      public enum AccessoryTypes : byte
      {
         /// <summary>Descodificador sin feedback.</summary>
         DecoderWithoutFeedback = 0,
         /// <summary>Descodificador con feedback.</summary>
         DecoderWidthFeedback = 1,
         /// <summary>Módulo de feedback.</summary>
         FeedbackModule = 2,
         /// <summary>Reservado para usos futuros.</summary>
         Unknown = 4
      }

      /// <summary>
      /// Enumera las posiciones (estados) de las salidas de un descodificador de accesorios
      /// </summary>
      public enum AccessoryPosition : byte
      {
         /// <summary>Posición no usada.</summary>
         TurnoutPosNotUsed = 0,
         /// <summary>Posición desviada.</summary>
         TurnoutPosTurned = 1,
         /// <summary>Posición recta.</summary>
         TurnoutPosStraight = 2,
         /// <summary>Posición inválida.</summary>
         TurnoutPosInvalid = 3
      }

      private int _id = -1;
      private int _address = -1;
      private bool _completed = true;
      private AccessoryPosition _position = AccessoryPosition.TurnoutPosInvalid;
      private AccessoryTypes _type = AccessoryTypes.Unknown;
      private int _nibble = -1;

      /// <summary>
      /// Devuelve una instancia de OTCSysCmdAccessoryDecoderInfo.
      /// </summary>
      /// <param name="address">Dirección digital del grupo de accesorios.</param>
      public AccessoryDecoderInfoCommand(int address)
      {
         _address = address;
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
         get { return "Accessory Decoder Info"; }
      }

      /// <summary>
      /// Dirección digital del accesorio.
      /// </summary>
      public int Address
      {
         get { return _address; }
         set { _address = value; }
      }

      /// <summary>
      /// Indica si la última órden de cambio tuvo éxito o terminó sin completar el cambio.
      /// </summary>
      public bool IsSwitchCompleted
      {
         get { return _completed; }
         set { _completed = value; }
      }

      /// <summary>
      /// Indica la posición de la salida del descodificador.
      /// </summary>
      public AccessoryPosition Position
      {
         get { return _position; }
         set { _position = value; }
      }

      /// <summary>
      /// Indica el tipo de descodificador detectado.
      /// </summary>
      public AccessoryTypes Type
      {
         get { return _type; }
         set { _type = value; }
      }

      /// <summary>
      /// ???.
      /// </summary>
      public int Nibble
      {
         get { return _nibble; }
         set { _nibble = value; }
      }
   }
}
