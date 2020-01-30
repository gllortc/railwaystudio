namespace Rwm.Otc.Systems
{

   /// <summary>
   /// Contains the digital system information obtained directly using the protocol.
   /// </summary>
   public class DigitalSystemInfo
   {

      public DigitalSystemInfo()
      {
         Initialize();
      }

      public DigitalSystemInfo(string sysName)
      {
         Initialize();

         this.SystemName = sysName;
      }

      public DigitalSystemInfo(string sysName, string sysVersion)
      {
         Initialize();

         this.SystemName = sysName;
         this.SystemVersion = sysVersion;
      }

      public DigitalSystemInfo(string sysName, string sysVersion, string ifName, string ifVersion)
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
