using Rwm.Otc.LayoutControl.Blocks;

namespace Rwm.Otc.Systems.Commands
{
   /// <summary>
   /// Implementa el comando DCC Accessory Decoder Info.
   /// </summary>
   public class AccessoryDecoderOperationCommand : ICommand
   {
      /// <summary>
      /// Enumera las salidas posibles para cada dirección de accesorio.
      /// </summary>
      public enum Outputs : int
      {
         /// <summary>Salida 1.</summary>
         Output1 = 0,
         /// <summary>Salida 2.</summary>
         Output2 = 1
      }

      /// <summary>
      /// Enumera los posibles estados de una salidas.
      /// </summary>
      public enum OutputStatus : int
      {
         /// <summary>Salida activa.</summary>
         Activated = 0,
         /// <summary>Salida desactivada.</summary>
         Deactivated = 1
      }

      private int _id = -1;
      private int _address = -1;
      private Outputs _out = Outputs.Output1;
      private OutputStatus _status = OutputStatus.Deactivated;
      private BlockBase _block = null;

      /// <summary>
      /// Devuelve una instancia de <see cref="AccessoryDecoderOperationCommand"/>.
      /// </summary>
      /// <param name="block">El bloque con las propiedades que debe tomar físicamente.</param>
      public AccessoryDecoderOperationCommand(BlockBase block)
      {
         _block = block;
         _address = block.DigitalAddress;

         // Determina la salida a activar
         if (block.Connection == OTCBlockConnection.S1StarightS2Turned && block.Status == OTCBlockStatus.Red_Straight)
            _out = AccessoryDecoderOperationCommand.Outputs.Output1;
         else
            _out = AccessoryDecoderOperationCommand.Outputs.Output2;

         _status = OutputStatus.Activated;
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
      /// Dirección digital del accesorio.
      /// </summary>
      public int Address
      {
         get { return _address; }
         set { _address = value; }
      }

      /// <summary>
      /// Tiempo (en milisegundos) que tarda el accesorio en cambiar su estado.
      /// </summary>
      public int SwitchTime
      {
         get { return _block.SwitchTime; }
      }

      /// <summary>
      /// Devuelve la salida (selenoide).
      /// </summary>
      public Outputs Output
      {
         get { return _out; }
         set { _out = value; }
      }

      /// <summary>
      /// Devuelve el estado que debe tomar la salida apuntada por Output.
      /// </summary>
      public OutputStatus Status
      {
         get { return _status; }
         set { _status = value; }
      }
   }
}
