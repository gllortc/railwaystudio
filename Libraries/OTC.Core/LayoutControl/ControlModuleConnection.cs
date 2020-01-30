using Rwm.Otc.LayoutControl.Elements;
using System;

namespace Rwm.Otc.LayoutControl
{
   /// <summary>
   /// Implements the connection between an accessory module output with an element.
   /// </summary>
   public class ControlModuleConnection : IComparable<ControlModuleConnection>
   {

      #region Enumerations

      public enum DecoderFunctionOutputStatus : int
      {
         Unknown = 99,
         Off = 0,
         On = 1
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ControlModuleConnection"/>.
      /// </summary>
      public ControlModuleConnection()
      {
         Initialize();
      }

      /// <summary>
      /// Returns a new instance of <see cref="ControlModuleConnection"/>.
      /// </summary>
      /// <param name="element">Associated element of the output.</param>
      public ControlModuleConnection(ElementBase element)
      {
         Initialize();

         this.ElementID = element.ID;
      }

      /// <summary>
      /// Returns a new instance of <see cref="ControlModuleConnection"/>.
      /// </summary>
      /// <param name="name">Name of the connection.</param>
      /// <param name="module">Control module associated.</param>
      public ControlModuleConnection(string name, ControlModule module)
      {
         Initialize();

         this.Name = name.Trim();
         this.DecoderID = module.ID;
      }

      /// <summary>
      /// Returns a new instance of <see cref="ControlModuleConnection"/>.
      /// </summary>
      /// <param name="name">Conetion name.</param>
      /// <param name="module">Control module associated.</param>
      /// <param name="address">Digital address.</param>
      /// <param name="output">Output index (starting by 1).</param>
      public ControlModuleConnection(string name, ControlModule module, int address, int output)
      {
         Initialize();

         this.Name = name.Trim();
         this.DecoderID = module.ID;
         this.Address = address;
         this.Output = output;
      }

      /// <summary>
      /// Returns a new instance of <see cref="ControlModuleConnection"/>.
      /// </summary>
      /// <param name="module">Control module associated.</param>
      /// <param name="element">Associated element of the output.</param>
      public ControlModuleConnection(ControlModule module, ElementBase element)
      {
         Initialize();

         this.DecoderID = module.ID;
         this.ElementID = element.ID;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the accessory module output unique identifier (DB).
      /// </summary>
      public int ID { get; set; }

      /// <summary>
      /// Gets or sets the connection index inside a element (to maintain its position).
      /// </summary>
      public int Index { get; set; }

      /// <summary>
      /// Gets or sets the related accessory module unique identifier.
      /// </summary>
      public int DecoderID { get; set; }

      /// <summary>
      /// Gets or sets the related accessory module.
      /// </summary>
      public ControlModule Decoder { get; set; }

      /// <summary>
      /// Gets or sets the related clock unique identifier.
      /// </summary>
      public int ElementID { get; set; }

      /// <summary>
      /// Gets or sets the output name.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets the output digital address.
      /// </summary>
      public int Address { get; set; }

      /// <summary>
      /// Gets or sets the output index (starting at 1) for sensor modules.
      /// </summary>
      public int Output { get; set; }

      /// <summary>
      /// Gets or sets the time (in milliseconds) to switch.
      /// </summary>
      public int SwitchTime { get; set; }

      public ConnectionMap OutputMap { get; set; }

      public DecoderFunctionOutputStatus Output2 { get; set; }

      #endregion

      #region Methods

      public int CompareTo(ControlModuleConnection other)
      {
         return this.Name.CompareTo(other.Name);
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ID = 0;
         this.Index = 0;
         this.DecoderID = 0;
         this.ElementID = 0;
         this.Decoder = null;
         this.Name = string.Empty;
         this.Address = 0;
         this.Output = 0;
         this.OutputMap = new ConnectionMap();
         this.Output2 = DecoderFunctionOutputStatus.Unknown;
         this.SwitchTime = 0;
      }

      #endregion

   }
}
