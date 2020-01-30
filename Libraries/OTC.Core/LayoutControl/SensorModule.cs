using System.Xml;

namespace Rwm.Otc.LayoutControl
{

   /// <summary>
   /// Implements a sensor module.
   /// </summary>
   public class SensorModule
   {

      #region Enumerations

      /// <summary>
      /// Enumera los tipos de descodificadores de accesorios.
      /// </summary>
      public enum AccessoryDecoderType : int
      {
         /// <summary>Pulse outputs (K83).</summary>
         PulseOutput = 1,
         /// <summary>Bistate outputs (K84).</summary>
         FixedOutput = 2,
         /// <summary>Servo control outputs.</summary>
         ServoOutput = 3,
         /// <summary>Programmable output mode.</summary>
         Programmable = 4,
         /// <summary>Unknown output type.</summary>
         Unknown = 0
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="SensorModule"/>.
      /// </summary>
      public SensorModule() 
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
      /// Gets or sets the module name.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets the module manufacturer name.
      /// </summary>
      public string Manufacturer { get; set; }

      /// <summary>
      /// Gets or sets the module model name or number.
      /// </summary>
      public string Model { get; set; }

      /// <summary>
      /// Gets or sets the number of inputs of the module.
      /// </summary>
      public int Inputs { get; set; }

      /// <summary>
      /// Gets or sets the start address of the first module input.
      /// </summary>
      public int StartAddress { get; set; }

      /// <summary>
      /// Establece o devuelve el tipo de descodificador.
      /// </summary>
      public AccessoryDecoderType Type { get; set; }

      /// <summary>
      /// Gets or sets a brief description.
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
         this.Inputs = 0;
         this.StartAddress = 0;
         this.Type = AccessoryDecoderType.Unknown;
         this.Notes = string.Empty;
      }

      #endregion

      #region Static Members

      /// <summary>
      /// Devuelve el nombre de un tipo de descodificador de accesorios.
      /// </summary>
      /// <param name="type">Tipo para el que se desea obtener el nombre.</param>
      public static string GetTypeName(AccessoryDecoderType type)
      {
         switch (type)
         {
            case AccessoryDecoderType.PulseOutput: 
               return "Descodificador de impulsos (K83)";

            case AccessoryDecoderType.FixedOutput: 
               return "Descodificador de salida fija (K84)";

            case AccessoryDecoderType.Programmable: 
               return "Descodificador de salidas programables";

            case AccessoryDecoderType.ServoOutput: 
               return "Descodificador para servos";

            default: 
               return "No especifocado";
         }
      }

      #endregion

   }
}
