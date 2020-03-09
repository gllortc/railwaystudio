using System;

namespace Rwm.OTC.Systems.Lenz.Commands
{
   public class InterfaceInformationCommand : Command
   {

      #region Constructors

      public InterfaceInformationCommand()
      {
         this.RequestData = new byte[] { 0xFF, 0xFE, 0xF0, 0xF0 };
         this.ResponseHeaderData = new byte[] { 0x02 };
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
         double hardwareVersion = 0.0;
         double softwareVersion = 0.0;

         if (data.Length >= 3)
         {
            hardwareVersion = (double)((data[1] & 0xF0) >> 4) + ((double)(data[1] & 0x0F) / 10.0);
            softwareVersion = data[2];

            this.InterfaceName = "LI-USB";   // Fixed
            this.HardwareVersion = hardwareVersion.ToString();
            this.SoftwareVersion = softwareVersion.ToString();

            return true;
         }
         else
         {
            return false;
         }
      }

      #endregion

   }
}
