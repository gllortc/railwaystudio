namespace Rwm.Otc.Systems.Commands
{
   /// <summary>
   /// Implementa el comando DCC Command Station Info.
   /// </summary>
   public class SystemInformationCommand : ICommand
   {
      private int _id = -1;
      private string _softVer = "";
      private string _hardVer = "";
      private string _model = "";
      private string _manufacturer = "";

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
         get { return "Command Station Info"; }
      }

      /// <summary>
      /// Contiene la versión del software de la central digital.
      /// </summary>
      public string SoftwareVersion
      {
         get { return _softVer; }
         set { _softVer = value; }
      }

      /// <summary>
      /// Contiene la versión del hardware de la central digital.
      /// </summary>
      public string HardwareVersion
      {
         get { return _hardVer; }
         set { _hardVer = value; }
      }

      /// <summary>
      /// Contiene el modelo/referencia del equipo.
      /// </summary>
      public string HardwareModel
      {
         get { return _model; }
         set { _model = value; }
      }

      /// <summary>
      /// Contiene el nombre del fabricante del equipo.
      /// </summary>
      public string Manufacturer
      {
         get { return _manufacturer; }
         set { _manufacturer = value; }
      }
   }
}
