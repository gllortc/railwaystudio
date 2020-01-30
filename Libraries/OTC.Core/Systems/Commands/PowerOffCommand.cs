namespace Rwm.Otc.Systems.Commands
{
   /// <summary>
   /// Implementa el comando DCC Power Off. 
   /// </summary>
   public class PowerOffCommand : ICommand
   {
      private int _id = -1;

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
         get { return "Power Off"; }
      }
   }
}
