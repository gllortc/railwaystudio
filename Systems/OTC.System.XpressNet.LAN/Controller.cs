using System;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Rwm.Otc;
using Rwm.Otc.Configuration;
using Rwm.Otc.Layout;
using Rwm.Otc.Systems;

namespace Rwm.OTC.Systems.Lenz
{

   public class Controller : IDigitalSystem
   {

      #region Constants

      private const string SETTINGS_KEY_PORT = "xpn.port";
      private const string SETTINGS_KEY_BAUDRATE = "xpn.baud-rate";
      private const string SETTINGS_KEY_PARITY = "xpn.parity";
      private const string SETTINGS_KEY_STOPBITS = "xpn.stop-bits";
      private const string SETTINGS_KEY_DATABITS = "xpn.data-bits";
      private const string SETTINGS_KEY_HANDSHAKE = "xpn.handshake";
      private const string SETTINGS_KEY_CMD_TIMEOUT = "xpn.cmd.timeout";

      private const int SENSOR_OUTPUTS_ADDRESS = 4;

      #endregion

      /// <summary>
      /// Possible device end responses such as \r\nOK\r\n, \r\nERROR\r\n, etc.
      /// </summary>
      private string[] _endResponses;

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Controller"/>.
      /// </summary>
      public Controller() 
      {
         this.Initialize();
      }

      #endregion

      #region Properties

      private int CommandTimeOutDefault { get; set; } = 500;

      private SerialPort SerialPort { get; set; } = null;

      private AutoResetEvent AutoResetEvent { get; set; } = null;

      private XmlSettingsItem SystemSettingsNode { get; set; }

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

      public int CommandTimeout
      {
         get { return this.SystemSettingsNode.GetInteger(SETTINGS_KEY_CMD_TIMEOUT, 500); }
         set
         {
            this.SystemSettingsNode.AddSetting(SETTINGS_KEY_CMD_TIMEOUT, value.ToString());
            OTCContext.Settings.SaveSettings();
         }
      }

      #endregion

      #region Methods

      public bool Connect()
      {
         try
         {
            this.SerialPort = new SerialPort(this.Port, this.BaudRate);
            //this.SerialPort.Parity = Parity.None;
            //this.SerialPort.Handshake = Handshake.None;
            //this.SerialPort.DataBits = 8;
            //this.SerialPort.StopBits = StopBits.One;
            this.SerialPort.RtsEnable = true;
            this.SerialPort.DtrEnable = true;
            this.SerialPort.WriteTimeout = this.CommandTimeout;
            this.SerialPort.ReadTimeout = this.CommandTimeout;

            if (this.SerialPort != null && !this.SerialPort.IsOpen)
            {
               this.AutoResetEvent = new AutoResetEvent(false);
               this.SerialPort.Open();
               this.SerialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);

               return true;
            }
            else
            {
               return false;
            }
         }
         catch
         {
            return false;
         }
      }

      public bool Disconnect()
      {
         try
         {
            if (this.SerialPort != null && this.SerialPort.IsOpen)
            {
               this.SerialPort.Close();
               return true;
            }
            else
            {
               return false;
            }
         }
         catch
         {
            return false;
         }
      }

      public DialogResult ShowSettingsDialog(XmlSettingsManager settings)
      {
         SettingsView view = new SettingsView(this);
         return view.ShowDialog();
      }

      public bool SetEmergencyStop(bool enabled)
      {
         throw new NotImplementedException();
      }

      public DigitalSystemInfo GetSystemInformation()
      {
         throw new NotImplementedException();
      }

      public AccessoryInformation GetAccessoryStatus(int address)
      {
         throw new NotImplementedException();
      }

      public void SetAccessoryStatus(Element element)
      {
         throw new NotImplementedException();
      }

      public void SetSensorStatus(Element element, FeedbackStatus status)
      {
         throw new NotImplementedException();
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

      #region Event Handlers

      private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
      {
         try
         {
            if (e.EventType == SerialData.Chars)
            {
               this.AutoResetEvent.Set();
            }
         }
         catch (Exception ex)
         {
            throw ex;
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

      private string ExecuteCommand(string cmd)
      {
         string buffer = string.Empty;

         this.SerialPort.DiscardOutBuffer();
         this.SerialPort.DiscardInBuffer();
         this.AutoResetEvent.Reset();
         this.SerialPort.Write(cmd); // Sometimes  + "\r" is needed. Depends on the device

         try
         {
            do
            {
               if (this.AutoResetEvent.WaitOne(this.CommandTimeout, false))
               {
                  string t = this.SerialPort.ReadExisting();
                  buffer += t;
               }

            } while (!_endResponses.Any(r => buffer.EndsWith(r, StringComparison.OrdinalIgnoreCase))); // Read while end responses are not yet received
         }
         catch
         {
            buffer = string.Empty;
         }

         // this.CommandTimeout = this.CommandTimeOutDefault;

         return buffer;
      }

      

      #endregion

   }
}
