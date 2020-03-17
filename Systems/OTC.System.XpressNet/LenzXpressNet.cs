﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using RJCP.IO.Ports;
using Rwm.Otc;
using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Rwm.Otc.Systems;
using Rwm.Otc.Systems.Protocol;
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

      //private static List<byte> ResponseBuffer { get; set; } = new List<byte>();

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

      #endregion

      #region Methods

      /// <summary>
      /// Initialize and connect the disigtal system.
      /// </summary>
      public bool Connect()
      {
         try
         {
            XpnBufferManager.Clear();

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
               this.SerialPort.DataReceived += SerialPort_DataReceived;
               this.SerialPort.Open();

               // Send information 
               this.OnInformationReceived?.Invoke(this, new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Information, "{0} connected", this.Name));

               // Send a system information request to verify communication and to show system info as well
               this.SystemInformation();

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

            this.OnInformationReceived?.Invoke(this, new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Error, ex.Message));

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
            this.OnInformationReceived?.Invoke(this, new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Information, "System disconnected"));

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
      /// Request the system information.
      /// </summary>
      public void SystemInformation()
      {
         this.CheckPortStatus();

         try
         {
            this.Execute(new byte[] { 0x21, 0x21 });
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw new Exception("Command error: " + ex.Message, ex);
         }
      }

      /// <summary>
      /// Request power off the layout.
      /// </summary>
      public void EmergencyOff()
      {
         this.CheckPortStatus();

         try
         {
            this.Execute(new byte[] { 0x21, 0x80 });
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw new Exception("Command error: " + ex.Message, ex);
         }
      }

      /// <summary>
      /// Request stopping all locomotives.
      /// </summary>
      public void EmergencyStop()
      {
         this.CheckPortStatus();

         try
         {
            this.Execute(new byte[] { 0x80, 0x80 });
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw new Exception("Command error: " + ex.Message, ex);
         }
      }

      /// <summary>
      /// Request cancelling emergency off/stop and go to normal operation status.
      /// </summary>
      public void ResumeOperations()
      {
         this.CheckPortStatus();

         try
         {
            this.Execute(new byte[] { 0x21, 0x81, 0xA0 });
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw new Exception("Command error: " + ex.Message, ex);
         }
      }

      /// <summary>
      /// Repuest accessory operation.
      /// </summary>
      /// <param name="address">Accessory address.</param>
      /// <param name="activatePin">Pin to activate (1/2).</param>
      public void OperateAccessory(int address, int activatePin)
      {
         this.CheckPortStatus();

         try
         {
            byte addr = (byte)(address / 4);

            byte byteB = 0x00;
            byte byteD = 0x00;
            byteB = (byte)(((address % 4) & 0x01) << 1);
            byteB += (byte)(((address % 4) & 0x02) << 1);
            byteD = (byte)(true ? 0x08 : 0x00);
            byteD += (byte)((activatePin - 1) == 1 ? 0x01 : 0x00);
            byte data = (byte)(byteB + byteD + 0x80);

            this.Execute(new byte[] { 0x52, addr, 0x80 }, false);

            Thread.Sleep(500);

            this.Execute(new byte[] { 0x52, addr, 0x81 }, false);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw new Exception("Command error: " + ex.Message, ex);
         }
      }

      public AccessoryInformation AccessoryOperate(int address, bool turned, bool activate)
      {
         this.CheckPortStatus();

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
      public void GetAccessoryStatus(int address)
      {
         throw new NotImplementedException();
      }

      /// <summary>
      /// Set an accessory output.
      /// </summary>
      /// <param name="element">Element.</param>
      public void SetAccessoryStatus(int address, bool turned, bool activate)
      {
         this.CheckPortStatus();

         try
         {
            --address;

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

            this.Execute(cmdData);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw new Exception("Command error: " + ex.Message, ex);
         }
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
      /// Event raised when any operation is requested or received by the digital system.
      /// </summary>
      public event EventHandler<SystemConsoleEventArgs> OnInformationReceived;

      /// <summary>
      /// Event raised when any operation is requested or received by the digital system.
      /// </summary>
      public event EventHandler<SystemCommandEventArgs> OnCommandReceived;

      #endregion

      #region Event Handlers

      private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
      {
         IResponse response;

         SerialPortStream xpressnetSerialPort = (SerialPortStream)sender;
         if (xpressnetSerialPort.BytesToRead <= 0) return;

         List<byte> rxBytes = new List<byte>();
         rxBytes.AddRange(System.Text.Encoding.ASCII.GetBytes(xpressnetSerialPort.ReadExisting()));

         foreach (List<byte> command in XpnBufferManager.DataReceived(rxBytes))
         {
            if (this.DebugMode)
            {
               string debugMessage = "RX -> ";
               foreach (byte rxByte in command)
                  debugMessage += String.Format("0x{0:X} ", rxByte);

               // Send information to LOG console
               this.OnInformationReceived?.Invoke(this, new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Debug, debugMessage));
            }

            response = this.GetResponse(command);
            if (response != null)
               this.OnCommandReceived?.Invoke(this, new SystemCommandEventArgs(response));
         }
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         // this.ClearBuffer();
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

      /// <summary>
      /// Send a request command to the digital system.
      /// </summary>
      /// <param name="commandBytes">Command bytes (without header & xor).</param>
      /// <param name="waitForResponse">Tells if the command must wait for a response.</param>
      /// <returns></returns>
      internal byte[] Execute(byte[] commandBytes, bool addHeaders = true)
      {
         // Send the command request
         byte[] bytes = this.GetRequestBytes(commandBytes, addHeaders);
         this.SerialPort.Write(bytes, 0, bytes.Length);

         return bytes;
      }

      /// <summary>
      /// Get the command bytes to send to the digital system.
      /// </summary>
      private byte[] GetRequestBytes(byte[] commandBytes, bool addHeaders)
      {
         if (commandBytes.Length <= 0)
            return new byte[0];

         try
         {
            byte[] bytes = new byte[(addHeaders ? 2 : 0) + commandBytes.Length + 1];
            if (addHeaders) bytes[0] = 0xFF;
            if (addHeaders) bytes[1] = 0xFE;
            for (int idx = 0; idx < commandBytes.Length; idx++) bytes[(addHeaders ? 2 : 0) + idx] = commandBytes[idx];
            bytes[bytes.Length - 1] = (byte)BinaryUtils.Xor(bytes, (addHeaders ? 2 : 0), commandBytes.Length);

            return bytes;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            return new byte[0];
         }
      }

      /// <summary>
      /// Get the appropriate <see cref="IResponse"/> instance.
      /// </summary>
      private IResponse GetResponse(List<byte> commandBytes)
      {
         if (LenzAccessoryOperation.IsTypeOf(commandBytes))
         {
            return new LenzAccessoryOperation(commandBytes.ToArray());
         }
         else if (LenzFeedbackStatusChanged.IsTypeOf(commandBytes))
         {
            return new LenzFeedbackStatusChanged(commandBytes.ToArray());
         }
         else if (LenzEmergencyOff.IsTypeOf(commandBytes))
         {
            return new LenzEmergencyOff(commandBytes.ToArray());
         }
         else if (LenzEmergencyStop.IsTypeOf(commandBytes))
         {
            return new LenzEmergencyStop(commandBytes.ToArray());
         }
         else if (LenzResumeOperations.IsTypeOf(commandBytes))
         {
            return new LenzResumeOperations(commandBytes.ToArray());
         }
         else if (LenzSystemInformation.IsTypeOf(commandBytes))
         {
            return new LenzSystemInformation(commandBytes.ToArray());
         }

         return null;
      }

      #endregion

      #region Unused code

      //private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
      //{
      //   IResponse response;

      //   SerialPortStream xpressnetSerialPort = (SerialPortStream)sender;
      //   if (xpressnetSerialPort.BytesToRead <= 0) return;

      //   List<byte> rxBytes = new List<byte>();
      //   rxBytes.AddRange(System.Text.Encoding.ASCII.GetBytes(xpressnetSerialPort.ReadExisting()));

      //   foreach (List<byte> command in XpnBufferManager.DataReceived(rxBytes))
      //   {
      //      if (this.DebugMode)
      //      {
      //         string debugMessage = "RX -> ";
      //         foreach (byte rxByte in command)
      //            debugMessage += String.Format("0x{0:X} ", rxByte);

      //         // Send information to LOG console
      //         this.OnInformationReceived?.Invoke(this, new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Debug, debugMessage));
      //      }

      //      response = this.GetResponse(command);
      //      if (response != null)
      //         this.OnCommandReceived?.Invoke(this, new SystemCommandEventArgs(response));
      //   }

      //   // ORIGINAL (WORKING)
      //   //LenzXpressNet.ResponseAvailable = false;

      //   //SerialPortStream xpressnetSerialPort = (SerialPortStream)sender;
      //   //if (xpressnetSerialPort.BytesToRead <= 0) return;

      //   //if (LenzXpressNet.ResponseBuffer.Count == 0)
      //   //   LenzXpressNet.ResponseAvailable = false;

      //   //LenzXpressNet.ResponseBuffer.AddRange(System.Text.Encoding.ASCII.GetBytes(xpressnetSerialPort.ReadExisting()));
      //   //LenzXpressNet.ResponseAvailable = LenzXpressNet.IsResponseComplete();

      //   //if (LenzXpressNet.ResponseAvailable)
      //   //{
      //   //   if (debugMode)
      //   //   {
      //   //      string debugMessage = "RX -> ";
      //   //      foreach (byte rxByte in LenzXpressNet.ResponseBuffer)
      //   //         debugMessage += String.Format("0x{0:X} ", rxByte);

      //   //      // Send information to LOG console
      //   //      this.SystemInformation?.Invoke(this, new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Information, debugMessage));
      //   //   }

      //   //   // Check unrequested responses
      //   //   if (!LenzXpressNet.WaitingForRresponse)
      //   //   {
      //   //      IResponse response = this.GetResponse(LenzXpressNet.ResponseBuffer.ToArray());
      //   //      if (response != null)
      //   //      {
      //   //         this.CommandReceived?.Invoke(this, new SystemCommandEventArgs(response));
      //   //      }
      //   //   }

      //   //   this.ClearBuffer();
      //   //}
      //}

      ///// <summary>
      ///// Send a request command to the digital system.
      ///// </summary>
      ///// <param name="commandBytes">Command bytes (without header & xor).</param>
      ///// <param name="waitForResponse">Tells if the command must wait for a response.</param>
      ///// <returns></returns>
      //internal byte[] Execute(byte[] commandBytes) //, bool waitForResponse = false)
      //{
      //   // Send the command request
      //   byte[] bytes = this.GetRequestBytes(commandBytes);
      //   this.SerialPort.Write(bytes, 0, bytes.Length);

      //   //// Wait for response
      //   //if (waitForResponse)
      //   //{
      //   //   LenzXpressNet.WaitingForRresponse = true;

      //   //   bool wait = true;
      //   //   Stopwatch watch = Stopwatch.StartNew();
      //   //   do
      //   //   {
      //   //      if (LenzXpressNet.ResponseAvailable)                        // Check response available
      //   //      {
      //   //         LenzXpressNet.WaitingForRresponse = false;
      //   //         this.ClearBuffer();
      //   //         wait = false;
      //   //      }
      //   //      else if (watch.ElapsedMilliseconds > this.CommandTimeout)   // Check timeout
      //   //      {
      //   //         LenzXpressNet.WaitingForRresponse = false;
      //   //         bytes = null;
      //   //         wait = false;
      //   //      }

      //   //      Thread.Sleep(10);
      //   //   }
      //   //   while (wait);
      //   //   watch.Stop();
      //   //}

      //   return bytes;
      //}

      //private List<IResponse> GetResponseCommands(List<byte> rxBytes)
      //{
      //   if (rxBytes == null || rxBytes.Count <= 2)
      //      return null;

      //   byte[] cmdArray;
      //   List<byte> currentCmd = null;
      //   IResponse response;
      //   List<IResponse> responses = null;

      //   for (int i = 0; i < rxBytes.Count; i++)
      //   {
      //      if (i < rxBytes.Count - 1 && rxBytes[i] == 0x3F && rxBytes[i+1] == 0x3F)
      //      {
      //         // Header detected!

      //         // Finish current command
      //         if (currentCmd != null)
      //         {
      //            cmdArray = currentCmd.ToArray();
      //            if (this.IsResponseComplete(cmdArray))
      //            {
      //               response = this.GetResponse(cmdArray);
      //               if (response != null)
      //               {
      //                  if (responses == null) responses = new List<IResponse>();
      //                  responses.Add(response);
      //               }
      //            }
      //         }

      //         // Start new command
      //         currentCmd = new List<byte>();
      //         i++; // jump header remaining byte
      //      }
      //      else if (currentCmd != null)
      //      {
      //         currentCmd.Add(rxBytes[i]);
      //      }
      //   }

      //   if (currentCmd != null && currentCmd.Count > 0)
      //   {
      //      cmdArray = currentCmd.ToArray();
      //      if (this.IsResponseComplete(cmdArray))
      //      {
      //         response = this.GetResponse(cmdArray);
      //         if (response != null)
      //         {
      //            if (responses == null) responses = new List<IResponse>();
      //            responses.Add(response);
      //         }
      //      }
      //   }

      //   return responses;
      //}

      ///// <summary>
      ///// Check if the current command is a complete command:
      ///// XOR(DATABYTE[1], DATABYTE[2],...,DATABYTE[n-1]) = DATABYTE[n]
      ///// </summary>
      ///// <param name="rxBytes">Candidate received package.</param>
      ///// <returns>A value indicating if the bytes are corresponding to a complete command.</returns>
      //private bool IsResponseComplete(byte[] rxBytes)
      //{
      //   short value = 0;

      //   if (rxBytes.Length < 2) return false; // Minimum 1 data byte and xor byte -> 2 bytes

      //   for (int i = 0; i < rxBytes.Length - 1; i++)
      //   {
      //      value ^= rxBytes[i];
      //   }

      //   return (value == rxBytes[rxBytes.Length - 1]);
      //}

      ///// <summary>
      ///// Realiza la operación XOR sobre un array de bytes.
      ///// </summary>
      ///// <param name="values">Array de bytes.</param>
      ///// <param name="start">Índice del elemento inicial.</param>
      ///// <param name="length">Número de elementos para los que se desea realizar la operación empezando por el elemento apuntado por <code>start</code>.</param>
      //private static bool IsResponseComplete()
      //{
      //   short value = 0;

      //   if (LenzXpressNet.ResponseBuffer.Count <= 2) return false;

      //   for (int i = 2; i < LenzXpressNet.ResponseBuffer.Count - 1; i++)
      //   {
      //      value ^= LenzXpressNet.ResponseBuffer[i];
      //   }

      //   return (value == LenzXpressNet.ResponseBuffer[LenzXpressNet.ResponseBuffer.Count - 1]);
      //}

      #endregion

   }
}
