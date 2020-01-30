using System;

namespace Rwm.Otc.Systems.Protocol
{
   public class SystemInfoCommand 
   {

      #region Constructors

      public SystemInfoCommand()
      {
         this.SystemName = string.Empty;
         this.SystemVersion = string.Empty;
      }

      #endregion

      #region Properties

      public string SystemName { get; private set; }

      public string SystemVersion { get; private set; }

      #endregion

   }
}
