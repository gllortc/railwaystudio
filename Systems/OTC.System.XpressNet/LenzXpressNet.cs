using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using RJCP.IO.Ports;
using Rwm.Otc;
using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Rwm.Otc.Systems;
using Rwm.Otc.Utils;
using Rwm.OTC.Systems.XpressNet.Protocol;
using Rwm.OTC.Systems.XpressNet.Views;

namespace Rwm.OTC.Systems.XpressNet
{

   public class LenzXpressNet : IDigitalSystem
   {

      #region Constants

      private const string SETTINGS_KEY_PORT = "xpn.port";
      private const string SETTINGS_KEY_BAUDRATE = "xpn.baud-rate";
      private const string SETTINGS_KEY_PARITY = "xpn.parity";
      private const string SETTINGS_KEY_STOPBITS = "xpn.stop-bits";
      private const string SETTINGS_KEY_DATABITS = "xpn.data-bits";
      private const string SETTINGS_KEY_HANDSHAKE = "xpn.handshake";
      private const string SETTINGS_KEY_CMD_TIMEOUT = "xpn.cmd.timeout";
      private const string SETTINGS_KEY_DEBUG_ENABLED = "xpn.debug.enabled";

      private const int SENSOR_OUTPUTS_ADDRESS = 4;

      private const int FEEDBACK_RANGE_BASE = 64;
      private const int FEEDBACK_RANGE_BEGIN = 66;
      private const int FEEDBACK_RANGE_END = 78;
      private const int FEEDBACK_RANGE_1 = 66;
      private const int FEEDBACK_RANGE_2 = 68;
      private const int FEEDBACK_RANGE_3 = 70;
      private const int FEEDBACK_RANGE_4 = 72;
      private const int FEEDBACK_RANGE_5 = 74;
      private const int FEEDBACK_RANGE_6 = 76;
      private const int FEEDBACK_RANGE_7 = 78;
      private const int MAX_FEEDBACK_BYTES = 14;
      private const int XNET1AND2VER = 0x62;
      private const int XNET3VER = 0x63;
      private const int XNETSTATUS = 0x62;
      private const int MIN_BROADCAST_MESSAGE_SIZE = 3;
      private const int MAX_BROADCAST_MESSAGE_SIZE = 16;

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="LenzXpressNet"/>.
      /// </summary>
      public LenzXpressNet()
      {
         this.Initialize();
      }

      #endregion

      #region Properties

      private SerialPortStream SerialPort { get; set; } = null;

      private XmlSettingsItem SystemSettingsNode { get; set; }

      private static List<byte> ResponseBuffer { get; set; } = new List<byte>();

      private static bool ResponseAvailable { get; set; } = false;

      private bool TimeoutReached { get; set; } = false;

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

      public bool DebugMode
      {
         get { return this.SystemSettingsNode.GetBoolean(SETTINGS_KEY_DEBUG_ENABLED, false); }
         set
         {
            this.SystemSettingsNode.AddSetting(SETTINGS_KEY_DEBUG_ENABLED, value);
            OTCContext.Settings.SaveSettings();
         }
      }

      public string PortName
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

      private bool debugMode = false;

      #endregion

      #region Methods

      /// <summary>
      /// Initialize and connect the disigtal system.
      /// </summary>
      public bool Connect()
      {
         try
         {
            debugMode = this.DebugMode;

            this.SerialPort = new SerialPortStream(this.PortName, this.BaudRate, 8, Parity.None, StopBits.One);
            //this.SerialPort.Parity = Parity.None;
            //this.SerialPort.Handshake = Handshake.None;
            //this.SerialPort.DataBits = 8;
            //this.SerialPort.StopBits = StopBits.One;
            //this.SerialPort.RtsEnable = true;
            //this.SerialPort.DtrEnable = true;
            this.SerialPort.WriteTimeout = this.CommandTimeout;
            this.SerialPort.ReadTimeout = this.CommandTimeout;

            if (this.SerialPort != null && !this.SerialPort.IsOpen)
            {
               this.SerialPort.Open();
               this.SerialPort.DataReceived += SerialPort_DataReceived;

               // Send information 
               this.SystemInformation?.Invoke(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Information, "{0} connected", this.Name));

               DigitalSystemInfo info = this.GetSystemInformation();
               if (info != null)
                  this.SystemInformation?.Invoke(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Information, "{0} ver {1}", info.SystemName, info.SystemVersion));
               else
                  this.SystemInformation?.Invoke(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Warning, "Cannot recover system information: command timeout"));

               this.Status = SystemStatus.Connected;

               return true;
            }
            else
            {
               return false;
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            this.SystemInformation?.Invoke(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Error, ex.Message));

            this.SerialPort.Dispose();

            return false;
         }
      }

      /// <summary>
      /// Disconnect the digital system and release all resources.
      /// </summary>
      public bool Disconnect()
      {
         try
         {
            if (this.SerialPort != null && this.SerialPort.IsOpen)
            {
               this.SerialPort.DataReceived -= SerialPort_DataReceived;

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
         finally
         {
            this.Status = SystemStatus.Disconnected;
         }
      }

      /// <summary>
      /// Show the configuration dialogue of the implemented system.
      /// </summary>
      /// <param name="settings">Settings item containing the digital system settings.</param>
      /// <rereturns>A value indicating if the user has been accepted the settings or not.</rereturns>
      public DialogResult ShowSettingsDialog(XmlSettingsManager settings)
      {
         SettingsView view = new SettingsView(this);
         return view.ShowDialog();
      }

      /// <summary>
      /// Stop all locomotives.
      /// </summary>
      /// <param name="enabled">A value indicating if the status is enabled or disabled.</param>
      public bool SetEmergencyStop(bool enabled)
      {
         throw new NotImplementedException();
      }

      /// <summary>
      /// Get the digital system information.
      /// </summary>
      /// <returns>An instance of <see cref="DigitalSystemInfo"/> containing information about the digital system.</returns>
      public DigitalSystemInfo GetSystemInformation()
      {

         // Comprueba que el puerto se encuentre abierto
         this.CheckPortStatus();

         // Envia los datos al interface
         try
         {
            SystemInformationCommand command = this.Execute(new SystemInformationCommand()) as SystemInformationCommand;

            if (command.ResponseAvailable)
            {
               DigitalSystemInfo info = new DigitalSystemInfo();
               return new DigitalSystemInfo(command.CommandStation, command.Version);
            }

            return null;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw new Exception("Write error: " + ex.Message, ex);
         }
      }

      public bool EmergencyStop()
      {
         this.CheckPortStatus();
         this.ClearBuffer();

         this.SerialPort.Write(new byte[2] { (byte)128, (byte)128 }, 0, 2);

         DateTime now = DateTime.Now;
         TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, this.CommandTimeout);
         DateTime dateTime = now.Add(timeSpan);

         while (LenzXpressNet.ResponseAvailable || !this.TimeoutReached)
         {
            if (dateTime >= now)
               this.TimeoutReached = true;
            now = DateTime.Now;
         }

         if (LenzXpressNet.ResponseAvailable)
         {
            if (LenzXpressNet.ResponseBuffer[0] == (byte)129 && LenzXpressNet.ResponseBuffer[1] == (byte)0 && LenzXpressNet.ResponseBuffer[2] == (byte)129)
            {
               this.ClearBuffer();
               return true;
            }

            this.ClearBuffer();
            return false;
         }

         this.ClearBuffer();
         return false;
      }

      public bool ResumeOperation()
      {
         this.CheckPortStatus();
         this.ClearBuffer();

         this.SerialPort.Write(new byte[3] { (byte)33, (byte)129, (byte)160 }, 0, 3);

         DateTime now = DateTime.Now;
         TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, this.CommandTimeout);
         DateTime dateTime = now.Add(timeSpan);

         while (!LenzXpressNet.ResponseAvailable || !this.TimeoutReached)
         {
            if (dateTime >= now)
               this.TimeoutReached = true;
            now = DateTime.Now;
         }

         if (LenzXpressNet.ResponseAvailable)
         {
            if (LenzXpressNet.ResponseBuffer[0] == (byte)97 && LenzXpressNet.ResponseBuffer[1] == (byte)1 && LenzXpressNet.ResponseBuffer[2] == (byte)96)
            {
               this.ClearBuffer();
               return true;
            }

            this.ClearBuffer();
            return false;
         }

         this.ClearBuffer();
         return false;
      }

      public AccessoryInformation AccessoryOperate(int address, bool turned, bool activate)
      {
         string str;

         this.CheckPortStatus();
         this.ClearBuffer();

         --address;

         //int addr = address / 4;
         //string str = Convert.ToString(address % 4, 2).PadLeft(8, '0').Substring(6, 2);
         //byte num2 = Convert.ToByte("1000" + (object)Convert.ToByte(action) + str + (object)(output - 1), 2);
         //int xor = 82 ^ addr ^ (int)num2;
         //this.SerialPort.Write(new byte[4] { (byte)82, (byte)addr, num2, (byte)xor }, 0, 4);

         byte byteAddy = 0x00;
         byte byteB = 0x00;
         byte byteD = 0x00;

         byteAddy = (byte)(address / 4);
         byteB = (byte)(((address % 4) & 0x01) << 1);
         byteB += (byte)(((address % 4) & 0x02) << 1);
         byteD = (byte)(activate ? 0x08 : 0x00);
         byteD += (byte)(turned ? 0x01 : 0x00);

         byte[] cmdData = { 0x52, 0x00, 0x00, 0x00 };
         cmdData[1] = byteAddy;
         cmdData[2] = (byte)(byteB + byteD + 0x80);
         cmdData[3] = (byte)BinaryUtils.Xor(cmdData, 2, 3);

         byte[] cmdData2 = { 0xFF, 0xFD, 0x42, 0x00, 0x02, 0x40 };
         this.SerialPort.Write(cmdData2, 0, cmdData2.Length);
         Thread.Sleep(1000);
         byte[] cmdData3 = { 0xFF, 0xFD, 0x42, 0x00, 0x01, 0x43 };
         this.SerialPort.Write(cmdData3, 0, cmdData3.Length);


         //DateTime now = DateTime.Now;
         //TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, this.CommandTimeout);
         //DateTime dateTime = now.Add(timeSpan);

         //while (!LenzXpressNet.HasResponse || !this.TimeoutReached)
         //{
         //   if (dateTime >= now)
         //      this.TimeoutReached = true;
         //   now = DateTime.Now;
         //}

         //if (LenzXpressNet.HasResponse)
         //{
         //   if (LenzXpressNet.ResponseBuffer[0] == (byte)66)
         //   {
         //      bool finished = false;
         //      int num = (int)LenzXpressNet.ResponseBuffer[1];
         //      str = Convert.ToString(LenzXpressNet.ResponseBuffer[2], 2).PadLeft(8, '0');
         //      if (str[0] == '1') finished = true;
         //      AccessoryType int16_1 = (AccessoryType)Convert.ToInt16(str.Substring(1, 2), 2);
         //      int nibble = (int)Convert.ToInt16(str.Substring(3, 1));
         //      OperationResult result = address % 2 != 0 ? (OperationResult)Convert.ToInt16(str.Substring(4, 2), 2) : (OperationResult)Convert.ToInt16(str.Substring(6, 2), 2);

         //      AccessoryInformation accessoryInfo = new AccessoryInformation(address + 1, nibble, finished, int16_1, result);

         //      return accessoryInfo;
         //   }
         //   else
         //      throw new XpnProtocolException("Unexpected response: expected 0x42 (d:66) and received 0x{0:X} (d:{0})", LenzXpressNet.ResponseBuffer[0]);
         //}

         return (AccessoryInformation)null;
      }

      /// <summary>
      /// Gets an accessory status information.
      /// </summary>
      /// <param name="address">Accessory address.</param>
      /// <returns>An instance of <see cref="AccessoryInformation"/> filled with the information requested, otherwise returns <c>null</c>.</returns>
      public AccessoryInformation GetAccessoryStatus(int address)
      {
         throw new NotImplementedException();
      }

      /// <summary>
      /// Set an accessory output.
      /// </summary>
      /// <param name="element">Element.</param>
      public void SetAccessoryStatus(Element element)
      {
         throw new NotImplementedException();
      }

      /// <summary>
      /// Allows set a sensor (for manual activation).
      /// </summary>
      /// <param name="element">Affected element.</param>
      /// <param name="status">Status.</param>
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

      public event UnrequestedMessageHandler UnrequestedMessageReceived;

      public delegate void UnrequestedMessageHandler(object sender, XpnEventArgs xa);

      #endregion

      #region Event Handlers

      private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
      {
         LenzXpressNet.ResponseAvailable = false;

         SerialPortStream xpressnetSerialPort = (SerialPortStream)sender;
         if (xpressnetSerialPort.BytesToRead <= 0) return;

         if (LenzXpressNet.ResponseBuffer.Count == 0)
            LenzXpressNet.ResponseAvailable = false;

         LenzXpressNet.ResponseBuffer.AddRange(System.Text.Encoding.ASCII.GetBytes(xpressnetSerialPort.ReadExisting()));
         LenzXpressNet.ResponseAvailable = LenzXpressNet.IsResponseComplete();

         if (LenzXpressNet.ResponseAvailable && debugMode)
         {
            string debugMessage = "RX -> ";
            foreach (byte rxByte in LenzXpressNet.ResponseBuffer)
               debugMessage += String.Format("0x{0:X} ", rxByte);

            // Send information to LOG console
            this.SystemInformation?.Invoke(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Information, debugMessage));
         }
      }

      private void InputCommandReceived(object sender, XpnInputCommandEventArgs args)
      {

      }

      public void FireUnrequestedMessageEvent(XpnEventArgs msg)
      {
         if (this.UnrequestedMessageReceived == null)
            return;

         this.UnrequestedMessageReceived((object)this, msg);
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ClearBuffer();
         XmlSettingsItem systems = OTCContext.Settings.GetItem(SystemManager.SETTINGS_SYSTEMS_KEY, true);
         this.SystemSettingsNode = systems.GetItem(this.ID, true);
         this.Status = SystemStatus.Disconnected;
      }

      /// <summary>
      /// Check if serial port is in correct status to TX/RX.
      /// </summary>
      private void CheckPortStatus()
      {
         if (!this.SerialPort.IsOpen)
            throw new Exception("La conexión al puerto se encuentra cerrada. No es posible enviar o recibir datos del interface Lenz.");
      }

      private void ClearBuffer()
      {
         this.SerialPort?.DiscardOutBuffer();
         this.SerialPort?.DiscardInBuffer();

         LenzXpressNet.ResponseBuffer.Clear();
         LenzXpressNet.ResponseAvailable = false;

         this.TimeoutReached = false;
      }

      internal CommandBase Execute(CommandBase command)
      {
         this.ClearBuffer();

         command.SendCommand(this.SerialPort);

         // Wait for response
         if (command.WaitForResponse)
         {
            bool wait = true;
            Stopwatch watch = Stopwatch.StartNew();
            do
            {
               if (LenzXpressNet.ResponseAvailable)                        // Check response available
               {
                  command.SetResponseData(LenzXpressNet.ResponseBuffer);
                  wait = false;
               }
               else if (watch.ElapsedMilliseconds > this.CommandTimeout)   // Check timeout
               {
                  command.ErrorMessage = "Command timeout";
                  wait = false;
               }

               Thread.Sleep(10);
            }
            while (wait);
            watch.Stop();
         }

         return command;
      }

      /// <summary>
      /// Realiza la operación XOR sobre un array de bytes.
      /// </summary>
      /// <param name="values">Array de bytes.</param>
      /// <param name="start">Índice del elemento inicial.</param>
      /// <param name="length">Número de elementos para los que se desea realizar la operación empezando por el elemento apuntado por <code>start</code>.</param>
      public static bool IsResponseComplete()
      {
         short value = 0;

         if (LenzXpressNet.ResponseBuffer.Count <= 2) return false;

         for (int i = 2; i < LenzXpressNet.ResponseBuffer.Count - 1; i++)
         {
            value ^= LenzXpressNet.ResponseBuffer[i];
         }

         return (value == LenzXpressNet.ResponseBuffer[LenzXpressNet.ResponseBuffer.Count - 1]);
      }

      #endregion

   }
}
