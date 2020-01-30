using Rwm.Otc.Configuration;
using Rwm.Otc.Systems;
using System;
using System.IO.Ports;

namespace Rwm.OTC.Systems
{
   internal class SystemSettings
   {

      #region Constants

      private const string SETTINGS_KEY_PORT = "xpn.port";
      private const string SETTINGS_KEY_BAUDRATE = "xpn.baud-rate";
      private const string SETTINGS_KEY_PARITY = "xpn.parity";
      private const string SETTINGS_KEY_STOPBITS = "xpn.stop-bits";
      private const string SETTINGS_KEY_DATABITS = "xpn.data-bits";
      private const string SETTINGS_KEY_HANDSHAKE = "xpn.handshake";

      #endregion

      #region Constructors

      public SystemSettings(XmlSettingsManager settings, IDigitalSystem system)
      {
         XmlSettingsItem systems = settings.GetItem(SystemManager.SETTINGS_SYSTEMS_KEY);
         XmlSettingsItem dsys = systems.GetItem(system.ID);

         this.Port = dsys.GetString(SETTINGS_KEY_PORT, "COM1");
         this.BaudRate = dsys.GetInteger(SETTINGS_KEY_BAUDRATE, 1024);
         this.Parity = (Parity)Enum.Parse(typeof(Parity), dsys.GetString(SETTINGS_KEY_PARITY, "None"));
         this.StopBits = (StopBits)Enum.Parse(typeof(StopBits), dsys.GetString(SETTINGS_KEY_STOPBITS, "None"));
         this.DataBits = dsys.GetInteger(SETTINGS_KEY_DATABITS, 8);
         this.Handshake = (Handshake)Enum.Parse(typeof(Handshake), dsys.GetString(SETTINGS_KEY_HANDSHAKE, "None"));
      }

      #endregion

      public string Port { get; set; }

      public int BaudRate { get; set; }

      public Parity Parity { get; set; }

      public StopBits StopBits { get; set; }

      public int DataBits { get; set; }

      public Handshake Handshake { get; set; }
   }
}
