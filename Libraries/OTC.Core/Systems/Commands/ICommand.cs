namespace Rwm.Otc.Systems.Commands
{
   /// <summary>
   /// Interface para los comandos de los sistemas OTC.
   /// </summary>
   public interface ICommand
   {
      /// <summary>
      /// Devuelve o establece el identificador del comando.
      /// </summary>
      int ID { get; set; }

      /// <summary>
      /// Devuelve el nombre del comando para su lectura.
      /// </summary>
      string Name { get; }
   }
}
