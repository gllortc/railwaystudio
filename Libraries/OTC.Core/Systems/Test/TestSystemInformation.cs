using Rwm.Otc.Systems.Protocol;

namespace Rwm.Otc.Systems.Test
{

   /// <summary>
   /// Contains the digital system information obtained directly using the protocol.
   /// </summary>
   public class TestSystemInformation : ISystemInformation
   {

      public TestSystemInformation()
      {
         Initialize();
      }

      public TestSystemInformation(string sysName)
      {
         Initialize();

         this.SystemName = sysName;
      }

      public TestSystemInformation(string sysName, string sysVersion)
      {
         Initialize();

         this.SystemName = sysName;
         this.SystemVersion = sysVersion;
      }

      public TestSystemInformation(string sysName, string sysVersion, string ifName, string ifVersion)
      {
         Initialize();

         this.SystemName = sysName;
         this.SystemVersion = sysVersion;
         this.InterfaceName = ifName;
         this.InterfaceVersion = ifVersion;
      }

      public string SystemName { get; set; }

      public string SystemVersion { get; set; }

      public string InterfaceName { get; set; }

      public string InterfaceVersion { get; set; }

      private void Initialize()
      {
         this.SystemName = string.Empty;
         this.SystemVersion = string.Empty;
         this.InterfaceName = string.Empty;
         this.InterfaceVersion = string.Empty;
      }

   }
}
