using System;
using System.ComponentModel;
using System.Xml;

namespace Rwm.Otc.Model
{

   #region Enumerations

   /// <summary>
   /// Enumera los estados posibles para los elementos de dos estados.
   /// </summary>
   public enum OTCBlockStatus : int
   {
      /// <summary>No definido.</summary>
      None = 0,
      /// <summary>Recto.</summary>
      Red_Straight = 1,
      /// <summary>Desviado.</summary>
      Green_Turned = 2,
      /// <summary>Ámbar.</summary>
      Yellow = 3
   }

   /// <summary>
   /// Enumera las posibles combinaciones de conexión.
   /// </summary>
   public enum OTCBlockConnection : int
   {
      /// <summary>Indefinido.</summary>
      Undefined = 0,
      /// <summary>La salida uno activa la posición recto/rojo.</summary>
      S1StarightS2Turned = 1,
      /// <summary>La salida uno activa la posición desviado/verde.</summary>
      S2StarightS1Turned = 2,
   }

   #endregion

   /// <summary>
   /// Implementa un bloque del panel.
   /// </summary>
   [DefaultPropertyAttribute("Nombre")]
   public class Block : BlockBase
   {
      private string _assignedkey;
      private OTCBlockStatus _state;
      private OTCBlockStatus _initialstatus;
      private OTCBlockConnection _connection;
      private OTCLibraryBlock _block;

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Block"/>.
      /// </summary>
      public Block()
      {
         Initialize();
      }

      /// <summary>
      /// Returns a new instance of <see cref="Block"/>.
      /// </summary>
      public Block(int id, int column, int row)
      {
         Initialize();

         this.ID = id;
         this.X = column;
         this.Y = row;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Identificador único del elemento.
      /// </summary>
      [CategoryAttribute("Identificación")]
      [DescriptionAttribute("Identificador único del elemento.")]
      [ReadOnlyAttribute(true)]
      public int ID { get; internal set; }

      /// <summary>
      /// Columna en la que se sitúa el bloque (X).
      /// </summary>
      [CategoryAttribute("Posición")]
      [DescriptionAttribute("Columna en la que se sitúa el bloque (X).")]
      [ReadOnlyAttribute(true)]
      public int X { get; set; }

      /// <summary>
      /// Fila en la que se sitúa el bloque (Y).
      /// </summary>
      [CategoryAttribute("Posición")]
      [DescriptionAttribute("Fila en la que se sitúa el bloque (Y).")]
      [ReadOnlyAttribute(true)]
      public int Y { get; set; }

      /// <summary>
      /// Rotación del elemento.
      /// </summary>
      [CategoryAttribute("Posición")]
      [DescriptionAttribute("Rotación del elemento.")]
      [ReadOnlyAttribute(true)]
      public int Rotation { get; set; }

      /// <summary>
      /// Nombre descriptivo del bloque.
      /// </summary>
      [CategoryAttribute("Identificación")]
      [DescriptionAttribute("Nombre descriptivo del bloque.")]
      public string Name { get; set; }

      /// <summary>
      /// Dirección digital del bloque.
      /// </summary>
      [CategoryAttribute("Digital")]
      [DescriptionAttribute("Dirección digital del bloque.")]
      public int DigitalAddress { get; set; }

      /// <summary>
      /// Dirección digital del bloque.
      /// </summary>
      [CategoryAttribute("Digital")]
      [DescriptionAttribute("Tiempo (en milisegundos) que tarda el accesorio en efectuar el cambio de estado.")]
      public int SwitchTime { get; set; }

      /// <summary>
      /// Identificador del descodificador al que está conectado y lo controla.
      /// </summary>
      [CategoryAttribute("Digital")]
      [DescriptionAttribute("Identificador del descodificador al que está conectado y lo controla.")]
      public int DecoderID { get; set; }

      /// <summary>
      /// Identificador de la ruta a activa si el bloque es un activador de rutas.
      /// </summary>
      [CategoryAttribute("Operación")]
      [DescriptionAttribute("Identificador de la ruta a activa si el bloque es un activador de rutas.")]
      public int RouteID { get; set; }

      /// <summary>
      /// Número de la entrada de un módulo de detección (feedback module).
      /// </summary>
      [CategoryAttribute("Operación")]
      [DescriptionAttribute("Número de la entrada de un módulo de detección (feedback module).")]
      public int FeedbackInput { get; set; }

      /// <summary>
      /// Estado actual del elemento.
      /// </summary>
      [CategoryAttribute("Estado")]
      [DescriptionAttribute("Estado actual del elemento.")]
      public OTCBlockStatus Status
      {
         get { return _state; }
         set
         {
            switch (_block.Type)
            {
               case OTCLibraryBlock.BlockTypes.Turnout:
               case OTCLibraryBlock.BlockTypes.Signal2S:
               case OTCLibraryBlock.BlockTypes.Switch:
                  if (value == OTCBlockStatus.None || value == OTCBlockStatus.Green_Turned || value == OTCBlockStatus.Red_Straight)
                     _state = value;
                  else
                     throw new Exception("No se puede asignar este estado a un bloque de dos estados.");
                  break;
               case OTCLibraryBlock.BlockTypes.Signal3S:
                  _state = value;
                  break;
               default:
                  _state = OTCBlockStatus.None;
                  break;
            }
         }
      }

      /// <summary>
      /// Estado inicial del bloque que tomará al resetear el panel de control.
      /// </summary>
      [CategoryAttribute("Estado")]
      [DescriptionAttribute("Estado inicial del bloque que tomará al resetear el panel de control.")]
      public OTCBlockStatus InitialStatus
      {
         get { return _initialstatus; }
         set
         {
            switch (_block.Type)
            {
               case OTCLibraryBlock.BlockTypes.Turnout:
               case OTCLibraryBlock.BlockTypes.Signal2S:
               case OTCLibraryBlock.BlockTypes.Switch:
                  if (value == OTCBlockStatus.None || value == OTCBlockStatus.Green_Turned || value == OTCBlockStatus.Red_Straight)
                     _initialstatus = value;
                  else
                     throw new Exception("No se puede asignar este estado a un bloque de dos estados.");
                  break;
               case OTCLibraryBlock.BlockTypes.Signal3S:
                  _initialstatus = value;
                  break;
               default:
                  _initialstatus = OTCBlockStatus.None;
                  break;
            }
         }
      }

      /// <summary>
      /// Estado inicial del bloque que tomará al resetear el panel de control.
      /// </summary>
      [CategoryAttribute("Conexión")]
      [DescriptionAttribute("Mapeo de conexión del elemento a las salidas del descodificador.")]
      public OTCBlockConnection Connection
      {
         get { return _connection; }
         set
         {
            switch (_block.Type)
            {
               case OTCLibraryBlock.BlockTypes.Turnout:
               case OTCLibraryBlock.BlockTypes.Signal2S:
               case OTCLibraryBlock.BlockTypes.Switch:
                  if (value == OTCBlockConnection.S1StarightS2Turned || value == OTCBlockConnection.S2StarightS1Turned)
                     _connection = value;
                  else
                     // Establece el estado por defecto
                     _connection = OTCBlockConnection.S1StarightS2Turned;
                  break;
               case OTCLibraryBlock.BlockTypes.Signal3S:
                  _connection = OTCBlockConnection.Undefined;
                  break;
               default:
                  _connection = OTCBlockConnection.Undefined;
                  break;
            }
         }
      }

      /// <summary>
      /// Instancia del bloque de libreria.
      /// </summary>
      [BrowsableAttribute(false)]
      [DefaultValueAttribute(false)]
      public OTCLibraryBlock LibraryBlock
      {
         get { return _block; }
         set { _block = value; }
      }

      /// <summary>
      /// Carácter de asignación rápido del elemento.
      /// </summary>
      [CategoryAttribute("Identificación")]
      [DescriptionAttribute("Carácter de asignación rápido del elemento.")]
      public string AssignedKey
      {
         get { return _assignedkey; }
         set
         {
            if (value.Trim().Length > 1)
               _assignedkey = value.Trim().Substring(0, 1).ToUpper();
            else
               _assignedkey = value.ToUpper();
         }
      }

      /// <summary>
      /// Indica si el bloque ha sufrido algún cambio en su estado o diseño. Esto es usado por el método
      /// OTCPanel.Draw() para refrescar el panel.
      /// </summary>
      [BrowsableAttribute(false)]
      [DefaultValueAttribute(false)]
      public bool Changed { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Devuelve el siguiente estado posible de un bloque.
      /// </summary>
      /// <param name="status">Estado actual del bloque.</param>
      /// <param name="includeNoneStatus">Si se establece a <code>True</code> la secuencia incluirá el estado None.</param>
      /// <returns>El siguiente estado posible.</returns>
      public OTCBlockStatus GetNextStatus(OTCBlockStatus status, bool includeNoneStatus)
      {
         switch (_block.Type)
         {
            case OTCLibraryBlock.BlockTypes.Signal3S:
               if (status == OTCBlockStatus.Red_Straight)
               {
                  if (includeNoneStatus)
                     return OTCBlockStatus.None;
                  else
                     return OTCBlockStatus.Green_Turned;
               }
               if (status == OTCBlockStatus.Green_Turned) return OTCBlockStatus.Yellow;
               if (status == OTCBlockStatus.Yellow) return OTCBlockStatus.Red_Straight;
               break;

            case OTCLibraryBlock.BlockTypes.Switch:
            case OTCLibraryBlock.BlockTypes.Turnout:
            case OTCLibraryBlock.BlockTypes.Signal2S:
               if (status == OTCBlockStatus.None) return OTCBlockStatus.Red_Straight;
               if (status == OTCBlockStatus.Red_Straight) return OTCBlockStatus.Green_Turned;
               if (status == OTCBlockStatus.Green_Turned)
               {
                  if (includeNoneStatus)
                     return OTCBlockStatus.None;
                  else
                     return OTCBlockStatus.Red_Straight;
               }
               break;

            default:
               return OTCBlockStatus.None;
         }

         return OTCBlockStatus.None;
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ID = 0;
         this.X = 0;
         this.Y = 0;
         this.Rotation = 0;
         this.Name = string.Empty;
         this.DigitalAddress = 0;
         this.SwitchTime = 0;
         _assignedkey = string.Empty;
         _block = null;
         this.Changed = false;
         _state = OTCBlockStatus.Red_Straight;
         _initialstatus = OTCBlockStatus.None;
         _connection = OTCBlockConnection.S1StarightS2Turned;
         this.DecoderID = 0;
         this.RouteID = 0;
         this.FeedbackInput = 0;
      }

      #endregion

      #region Static Members

      /// <summary>
      /// Devuelve un nombre para el estado de un bloque.
      /// </summary>
      /// <param name="status">Estado del bloque.</param>
      /// <param name="type">Tipo de bloque.</param>
      /// <returns>Una cadena de texto que representa el nombre del estado.</returns>
      public static string GetStatusName(OTCBlockStatus status, OTCLibraryBlock.BlockTypes type)
      {
         switch (type)
         {
            case OTCLibraryBlock.BlockTypes.Turnout:
               {
                  switch (status)
                  {
                     case OTCBlockStatus.Green_Turned:
                        return "Desviado";
                     case OTCBlockStatus.Red_Straight:
                        return "Recto";
                     default:
                        return "Desconocido";
                  }
               }

            case OTCLibraryBlock.BlockTypes.Signal2S:
            case OTCLibraryBlock.BlockTypes.Signal3S:
               {
                  switch (status)
                  {
                     case OTCBlockStatus.Green_Turned:
                        return "Verde";
                     case OTCBlockStatus.Red_Straight:
                        return "Rojo";
                     case OTCBlockStatus.Yellow:
                        return "Ámbar";
                     default:
                        return "Desconocido";
                  }
               }
         }

         return "Desconocido";
      }

      #endregion

   }
}
