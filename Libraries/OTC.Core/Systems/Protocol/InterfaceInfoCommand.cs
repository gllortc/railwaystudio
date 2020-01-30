using System;

namespace Rwm.Otc.Systems.Protocol
{
   public class InterfaceInfoCommand 
   {

      #region Constructors

      public InterfaceInfoCommand()
      {
         this.InterfaceName = string.Empty;
         this.HardwareVersion = string.Empty;
         this.SoftwareVersion = string.Empty;
      }

      #endregion

      #region Properties

      public string InterfaceName { get; private set; }

      public string HardwareVersion { get; private set; }

      public string SoftwareVersion { get; private set; }

      #endregion

   }
}
