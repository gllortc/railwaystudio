using System;
using System.IO.Ports;
using System.Windows.Forms;
using Rwm.Otc;
using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Rwm.Otc.Systems;
using XpressnetLib;

namespace Rwm.OTC.Systems
{

   /// <summary>
   /// Implements the Lenz XpressNet protocol over serial port.
   /// </summary>
   public class OldLenzXpressNet : IDigitalSystem
   {

      #region Constants

      private const string SETTINGS_KEY_PORT = "xpn.port";
      private const string SETTINGS_KEY_BAUDRATE = "xpn.baud-rate";
      private const string SETTINGS_KEY_PARITY = "xpn.parity";
      private const string SETTINGS_KEY_STOPBITS = "xpn.stop-bits";
      private const string SETTINGS_KEY_DATABITS = "xpn.data-bits";
      private const string SETTINGS_KEY_HANDSHAKE = "xpn.handshake";

      private const int SENSOR_OUTPUTS_ADDRESS = 4;

      #endregion

      #region Constructors

      public OldLenzXpressNet()
      {
         this.Initialize();
      }

      #endregion

      #region Properties

      private XmlSettingsItem SystemSettingsNode { get; set; }

      private XpressnetConnectorRoco Connection { get; set; }

      private LocoInfo CurrentLoco { get; set; }

      public string ID
      {
         get { return "7C6318D3-BAFD-4B6D-835B-51FBE3F3D1FE"; }
      }

      public string Name
      {
         get { return "Lenz XpressNet DCC"; }
      }

      public string Description
      {
         get { return "Lenz XpressNet DCC"; }
      }

      /// <summary>
      /// Gets the status of the system.
      /// </summary>
      public SystemStatus Status { get; private set; } 

      public int OutputsBySensorAddress
      {
         get { return SENSOR_OUTPUTS_ADDRESS; }
      }

      public string Port
      {
         get { return this.SystemSettingsNode.GetString(SETTINGS_KEY_PORT, "COM1"); }
         set
         {
            this.SystemSettingsNode.AddSetting(SETTINGS_KEY_PORT, value);
            OTCContext.Settings.SaveSettings();
         }
      }

      public int BaudRate
      {
         get { return this.SystemSettingsNode.GetInteger(SETTINGS_KEY_BAUDRATE, 1024); }
         set
         {
            this.SystemSettingsNode.AddSetting(SETTINGS_KEY_BAUDRATE, value);
            OTCContext.Settings.SaveSettings();
         }
      }

      public Parity Parity
      {
         get { return (Parity)Enum.Parse(typeof(Parity), this.SystemSettingsNode.GetString(SETTINGS_KEY_PARITY, "None")); }
         set
         {
            this.SystemSettingsNode.AddSetting(SETTINGS_KEY_PARITY, value.ToString());
            OTCContext.Settings.SaveSettings();
         }
      }

      public StopBits StopBits
      {
         get { return (StopBits)Enum.Parse(typeof(StopBits), this.SystemSettingsNode.GetString(SETTINGS_KEY_STOPBITS, "None")); }
         set
         {
            this.SystemSettingsNode.AddSetting(SETTINGS_KEY_STOPBITS, value.ToString());
            OTCContext.Settings.SaveSettings();
         }
      }

      public int DataBits
      {
         get { return this.SystemSettingsNode.GetInteger(SETTINGS_KEY_DATABITS, 8); }
         set
         {
            this.SystemSettingsNode.AddSetting(SETTINGS_KEY_DATABITS, value);
            OTCContext.Settings.SaveSettings();
         }
      }

      public Handshake Handshake
      {
         get { return (Handshake)Enum.Parse(typeof(Handshake), this.SystemSettingsNode.GetString(SETTINGS_KEY_HANDSHAKE, "None")); }
         set
         {
            this.SystemSettingsNode.AddSetting(SETTINGS_KEY_HANDSHAKE, value.ToString());
            OTCContext.Settings.SaveSettings();
         }
      }

      #endregion

      #region Events

      /// <summary>
      /// Event raised when a sensor is activated.
      /// </summary>
      public event EventHandler<FeedbackEventArgs> SensorStatusChanged;

      /// <summary>
      /// Event raised when an accessory is changed outside OTC.
      /// </summary>
      public event EventHandler<AccessoryEventArgs> AccessoryStatusChanged;

      /// <summary>
      /// Event raised when any operation is requested or received by the digital system.
      /// </summary>
      public event EventHandler<SystemInfoEventArgs> SystemInformation;

      #endregion

      #region Methods

      /// <summary>
      /// Initialize and connect the disigtal system.
      /// </summary>
      public bool Connect()
      {
         this.Status = SystemStatus.Connecting;

         // Check if the system is already connected
         if (this.Connection != null && this.Connection.IsConnected)
         {
            return true;
         }

         try
         {
            // Create a new system instance
            this.Connection = new XpressnetConnectorRoco(this.Port);

            // Subscribe the digital system events
            this.Connection.UnrequestedMessageReceived += new XpressnetConnectorRoco.UnrequestedMessageHandler(System_UnrequestedMessageReceived);

            // Try to connect
            this.Connection.Connect();

            // Send information 
            this.SystemInformation?.Invoke(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Information, "Connected to LI-USB at {0}", this.Port));

            this.Status = SystemStatus.Connected;

            return true;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            this.Connection = null;
            this.CurrentLoco = null;

            this.Status = SystemStatus.Disconnected;

            // Send information 
            this.SystemInformation?.Invoke(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Error, "Error occurred connecting to digital system: {0}", ex.Message));

            throw new DigitalSystemException(ex.Message, ex);
         }
      }

      /// <summary>
      /// Disconnect the digital system and release all resources.
      /// </summary>
      public bool Disconnect()
      {
         try
         {
            if (this.Connection != null)
            {
               this.Connection.Disconnect();
            }

            return true;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            return false;
         }
         finally
         {
            this.Connection = null;
            this.CurrentLoco = null;

            this.Status = SystemStatus.Disconnected;
         }
      }

      /// <summary>
      /// Get the digital system information.
      /// </summary>
      /// <returns>A <see cref="System.String"/> containing information about the digital system.</returns>
      public DigitalSystemInfo GetSystemInformation()
      {
         return new DigitalSystemInfo(this.GetType().Name);
      }

      /// <summary>
      /// Stop all locomotives.
      /// </summary>
      /// <param name="enabled">A value indicating if the status is enabled or disabled.</param>
      public bool SetEmergencyStop(bool enabled)
      {
         if (this.Connection == null || !this.Connection.IsConnected)
            return false;

         try
         {
            if (enabled)
               return this.Connection.EmergencyStop();
            else
               return this.Connection.ResumeOperation();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            // Send information 
            this.SystemInformation?.Invoke(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Error, "Error enabling/resuming emergency stop: {0}", ex.Message));

            return false;
         }
      }

      /// <summary>
      /// Gets an accessory status information.
      /// </summary>
      /// <param name="address">Accessory address.</param>
      /// <returns>An instance of <see cref="AccessoryInformation"/> filled with the information requested, otherwise returns <c>null</c>.</returns>
      public AccessoryInformation GetAccessoryStatus(int address)
      {
         try
         {
            if (this.Connection != null && this.Connection.IsConnected)
            {
               AccessoryInfo ai = this.Connection.AccessoryInformation(address);

               return new AccessoryInformation(ai.Address);
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
         }

         return null;
      }

      public void SetAccessoryStatus(Element element)
      {
         AccessoryDecoderConnection connection = element.AccessoryConnections[0];
         this.SetAccessoryStatus(connection.Address, connection.ElementPinIndex, true);
      }

      /// <summary>
      /// Set an accessory output.
      /// </summary>
      /// <param name="address">Output address.</param>
      /// <param name="status">Value to set.</param>
      public void SetAccessoryStatus(int address, int output, bool activated)
      {
         try
         {
            if (this.Connection != null && this.Connection.IsConnected)
            {
               // AccessoryInfo ai = this.Connection.AccessoryOperate(address, activated, output);
               AccessoryInfo result = this.Connection.AccessoryInformation(1);
               Console.WriteLine("AccType: {0}\nGroupAddress: {1}\nNibble: {2}\nOpResult: {3}", result.AccType, result.GroupAddress, result.Nibble, result.OpResult);

               System.Threading.Thread.Sleep(200);

               result = this.Connection.AccessoryOperate(1, false, 0);
               Console.WriteLine("AccType: {0}\nGroupAddress: {1}\nNibble: {2}\nOpResult: {3}", result.AccType, result.GroupAddress, result.Nibble, result.OpResult);

               //result = this.Connection.AccessoryOperate(1, true, 1);
               //System.Threading.Thread.Sleep(200);
               //result = this.Connection.AccessoryOperate(1, false, 1);
               //result = this.Connection.AccessoryOperate(1, true, 0);
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
         }
      }

      public void SetSensorStatus(Element element, FeedbackStatus status)
      {
         throw new NotImplementedException();
      }

      /// <summary>
      /// Show the configuration dialogue of the implemented system.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      /// <rereturns>A value indicating if the user has been changed the settings or not.</rereturns>
      public DialogResult ShowSettingsDialog(XmlSettingsManager settings)
      {
         // SettingsView view = new SettingsView(this);
         return DialogResult.Cancel; // view.ShowDialog();
      }

      #endregion

      #region Event Handlers

      void System_UnrequestedMessageReceived(object sender, XpressnetArgs xa)
      {
         switch (xa.Message())
         {
            case XpressnetMessage.AnotherDevice:
               if (xa.AddressLow() == this.CurrentLoco.Address)
                  this.SystemInformation?.Invoke(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Warning, "Engine #{0} operated by another device", xa.AddressLow()));
               break;
         }
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         XmlSettingsItem systems = OTCContext.Settings.GetItem(SystemManager.SETTINGS_SYSTEMS_KEY, true);
         this.SystemSettingsNode = systems.GetItem(this.ID, true);
         this.Status = SystemStatus.Disconnected;
      }

      #endregion

   }
}
