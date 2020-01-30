using Rwm.Otc;
using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Rwm.Otc.Systems;
using System;
using System.IO.Ports;
using XpressnetLib;

namespace Rwm.OTC.Systems
{

   /// <summary>
   /// Implements the Lenz XpressNet protocol over serial port.
   /// </summary>
   public class XpressNet : IDigitalSystem
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

      public XpressNet()
      {
         this.Initialize();
      }

      #endregion

      #region Properties

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
         get { return XpressNet.SENSOR_OUTPUTS_ADDRESS; }
      }

      public string Port { get; set; }

      public int BaudRate { get; set; }

      public Parity Parity { get; set; }

      public StopBits StopBits { get; set; }

      public int DataBits { get; set; }

      public Handshake Handshake { get; set; }

      private XpressnetConnectorRoco Connection { get; set; }

      private LocoInfo currentLoco { get; set; }

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
      public void Connect()
      {
         this.Status = SystemStatus.Connecting;

         // Check if the system is already connected
         if (this.Connection != null && this.Connection.IsConnected)
         {
            return;
         }

         try
         {
            // Get the digital system settings
            XmlSettingsItem systems = OTCContext.Settings.GetItem(SystemManager.SETTINGS_SYSTEMS_KEY);
            if (systems != null)
            {
               XmlSettingsItem dsys = systems.GetItem(this.ID);
               if (dsys != null)
               {
                  this.Port = dsys.GetString(SETTINGS_KEY_PORT, "COM1");
                  this.BaudRate = dsys.GetInteger(SETTINGS_KEY_BAUDRATE, 1024);
                  this.Parity = (Parity)Enum.Parse(typeof(Parity), dsys.GetString(SETTINGS_KEY_PARITY, "None"));
                  this.StopBits = (StopBits)Enum.Parse(typeof(StopBits), dsys.GetString(SETTINGS_KEY_STOPBITS, "None"));
                  this.DataBits = dsys.GetInteger(SETTINGS_KEY_DATABITS, 8);
                  this.Handshake = (Handshake)Enum.Parse(typeof(Handshake), dsys.GetString(SETTINGS_KEY_HANDSHAKE, "None"));
               }
               else
               {
                  throw new DigitalSystemException("The system {0} has not been configurated.", this.Name);
               }
            }
            else
            {
               throw new DigitalSystemException("The system {0} has not been configurated.", this.Name);
            }

            // Create a new system instance
            this.Connection = new XpressnetConnectorRoco(this.Port);

            // Subscribe the digital system events
            this.Connection.UnrequestedMessageReceived += new XpressnetConnectorRoco.UnrequestedMessageHandler(System_UnrequestedMessageReceived);

            // Try to connect
            this.Connection.Connect();

            this.Status = SystemStatus.Connected;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            this.Connection = null;
            this.currentLoco = null;

            this.Status = SystemStatus.Disconnected;

            throw new DigitalSystemException(ex.Message, ex);
         }
      }

      /// <summary>
      /// Disconnect the digital system and release all resources.
      /// </summary>
      public void Disconnect()
      {
         try
         {
            if (this.Connection != null)
            {
               this.Connection.Disconnect();
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
         }
         finally
         {
            this.Connection = null;
            this.currentLoco = null;

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
      public void SetEmergencyStop(bool enabled)
      {
         try
         {
            if (this.Connection != null)
            {
               bool resp = this.Connection.EmergencyStop();
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
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
            if (this.Connection != null)
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
            if (this.Connection != null)
            {
               AccessoryInfo ai = this.Connection.AccessoryOperate(address, activated, output);
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
      public System.Windows.Forms.DialogResult ShowConfig(Rwm.Otc.Configuration.XmlSettingsManager settings)
      {
         System.Windows.Forms.MessageBox.Show("This digital system doesn't have any configuration.",
                                              System.Windows.Forms.Application.ProductName,
                                              System.Windows.Forms.MessageBoxButtons.OK,
                                              System.Windows.Forms.MessageBoxIcon.Information);

         return System.Windows.Forms.DialogResult.Cancel;
      }

      #endregion

      #region Event Handlers

      void System_UnrequestedMessageReceived(object sender, XpressnetArgs xa)
      {
         XpressnetMessage xpm = XpressnetMessage.AnotherDevice;

         //if (xa.
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.Port = "COM1";
         this.BaudRate = 1024;
         this.Parity = Parity.None;
         this.StopBits = StopBits.None;
         this.DataBits = 8;
         this.Handshake = Handshake.None;
         this.Status = SystemStatus.Disconnected;
      }

      #endregion

   }
}
