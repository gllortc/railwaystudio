namespace Rwm.Otc.Systems.Commands
{
   /// <summary>
   /// Implementa el comando DCC Emergency Stop. 
   /// </summary>
   public class OTCSysCmdStopLocomotive : ICommand
   {
      private int _id = -1;
      private int _address = -1;

      /// <summary>
      /// Devuelve una instancia de OTCSysCmdEmergencyStop.
      /// </summary>
      /// <param name="longAddress">Dirección de la locomotora a detener.</param>
      public OTCSysCmdStopLocomotive(int longAddress)
      {
         _address = longAddress;
      }

      /// <summary>
      /// Devuelve una instancia de OTCSysCmdEmergencyStop.
      /// </summary>
      /// <param name="lowAddress">Dirección baja.</param>
      /// <param name="highAddress">Dirección alta.</param>
      public OTCSysCmdStopLocomotive(int lowAddress, int highAddress)
      {
         _address = lowAddress + highAddress;
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
         get { return "Emergency Stop"; }
      }

      /// <summary>
      /// Devuelve o establece la dirección de la locomotora a detener.
      /// </summary>
      public int Address
      {
         get { return _address; }
         set { _address = value; }
      }
   }
}
