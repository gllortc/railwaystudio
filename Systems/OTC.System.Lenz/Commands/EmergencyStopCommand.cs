using System;

namespace Rwm.OTC.Systems.Lenz.Commands
{
   public class EmergencyStopCommand : Command
   {

      #region Constructors

      public EmergencyStopCommand()
      {
         this.RequestData = new byte[] { 0xFF, 0xFE, 0x21, 0x80, 0xA1 };
         this.ResponseHeaderData = new byte[] { };
      }

      #endregion

      #region Properties

      public string InterfaceName { get; private set; }

      public string HardwareVersion { get; private set; }

      public string SoftwareVersion { get; private set; }

      #endregion

      #region Methods

      /// <summary>
      /// Transform the received data into the Lenz command response.
      /// </summary>
      /// <param name="data">Data received (without Lenz fixed frame).</param>
      /// <returns><c>true</c> if the data is correct, otherwise returns <c>false</c>.</returns>
      public override bool GetCommandData(byte[] data)
      {
         return false;
      }

      #endregion

   }
}
