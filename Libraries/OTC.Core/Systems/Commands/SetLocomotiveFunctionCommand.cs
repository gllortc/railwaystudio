namespace Rwm.Otc.Systems.Commands
{
   /// <summary>
   /// Implementa el comando para establecer el estado de una determinada función de una locomotora.
   /// </summary>
   public class SetLocomotiveFunctionCommand : ICommand
   {
      private bool _active = true;
      private int _id = -1;
      private int _address = 0;
      private int _function = 0;

      /// <summary>
      /// Devuelve una instancia de OTCSysCmdSetLocomotiveFunction.
      /// </summary>
      /// <param name="address">Dirección de la locomotora.</param>
      /// <param name="function">Número de pasos de velocidad soportados por el descodificador.</param>
      /// <param name="active">Velocidad a alcanzar.</param>
      public SetLocomotiveFunctionCommand(int address, int function, bool active)
      {
         _address = address;
         _function = function;
         _active = active;
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
         get { return "Locomotive Function Set"; }
      }

      /// <summary>
      /// Devuelve la dirección digital del comando.
      /// </summary>
      public int Address
      {
         get { return _address; }
      }

      /// <summary>
      /// Devuelve el número de función a activar/desactivar.
      /// </summary>
      public int Function
      {
         get { return _function; }
      }

      /// <summary>
      /// Devuelve un valor que indica si la función se debe activar o desactivar.
      /// </summary>
      public bool Active
      {
         get { return _active; }
      }
   }
}
