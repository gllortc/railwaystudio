using System.Xml;

namespace Rwm.Otc.LayoutControl
{

   /// <summary>
   /// Implements an accessory decoder.
   /// </summary>
   public class ControlModule
   {

      #region Enumerations

      /// <summary>
      /// Enumera los tipos de descodificadores de accesorios.
      /// </summary>
      public enum ModuleType : int
      {
         /// <summary>Accessory control module.</summary>
         Undefined = 0,
         /// <summary>Accessory control module.</summary>
         Accessory = 1,
         /// <summary>Sensor module.</summary>
         Sensor = 2
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="ControlModule"/>.
      /// </summary>
      public ControlModule() 
      {
         Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      public int ID { get; set; }

      /// <summary>
      /// Gets or sets the decoder name.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets the decoder's manufacturer name.
      /// </summary>
      public string Manufacturer { get; set; }

      /// <summary>
      /// Gets or sets the decoder's model name or number.
      /// </summary>
      public string Model { get; set; }

      /// <summary>
      /// Gets or sets the number of outputs of the decoder.
      /// </summary>
      public int Outputs { get; set; }

      /// <summary>
      /// Establece o devuelve la dirección inicial del descodificador.
      /// </summary>
      public int StartAddress { get; set; }

      /// <summary>
      /// Establece o devuelve el tipo de descodificador.
      /// </summary>
      public ModuleType Type { get; set; }

      /// <summary>
      /// Gets or sets las notas y comentarios al elemento.
      /// </summary>
      public string Notes { get; set; }

      #endregion

      #region Methods

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ID = 0;
         this.Name = string.Empty;
         this.Manufacturer = string.Empty;
         this.Model = string.Empty;
         this.Outputs = 0;
         this.StartAddress = 0;
         this.Type = ModuleType.Accessory;
         this.Notes = string.Empty;
      }

      #endregion

   }
}
