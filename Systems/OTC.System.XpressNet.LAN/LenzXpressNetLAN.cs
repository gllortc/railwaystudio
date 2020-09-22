using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Rwm.Otc.Systems.Protocol;
using Rwm.Otc.Systems.XpressNet.Views;
using Rwm.Otc.Utils;

namespace Rwm.Otc.Systems.XpressNet
{
   public class LenzXpressNetLAN : DigitalSystem
   {

      #region Constants

      private const string SETTINGS_KEY_PORT = "xpn.lan.port";
      private const string SETTINGS_KEY_HOST = "xpn.lan.host";
      private const string SETTINGS_KEY_RWTIMEOUT = "xpn.rwtimeout";
      private const string SETTINGS_KEY_KEEPALIVE_INTERVAL = "xpn.lan.keepalive.interval";
      private const string SETTINGS_KEY_DEBUG_ENABLED = "xpn.lan.debug.enabled";

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
      /// Returns a new instance of <see cref="LenzXpressNetUSB"/>.
      /// </summary>
      public LenzXpressNetLAN()
      {
         this.Initialize();
      }

      #endregion

      #region Properties

      private XmlSettingsItem SystemSettingsNode { get; set; }

      private System.Timers.Timer AcknowledgementTimer { get; set; } = null;

      public override string ID
      {
         get { return "C8C14D2E-AA15-4ED4-B5D9-71190E82791E"; }
      }

      public override string Name
      {
         get { return "Lenz XpressNet LAN"; }
      }

      public override string Description
      {
         get { return "Lenz XpressNet implementation using TCP/IP connected interface"; }
      }

      /// <summary>
      /// Gets the current implementation version.
      /// </summary>
      public override string Version
      {
         get { return ReflectionUtils.GetAssemblyVersion(this.GetType()); }
      }

      /// <summary>
      /// Gets the valid accessory address range.
      /// </summary>
      public override Range AccessoryAddressRange { get; } = new Range(1, 1024);

      /// <summary>
      /// Gets the valid feedback address range.
      /// </summary>
      public override Range FeedbackAddressRange { get; } = new Range(1, 128);

      /// <summary>
      /// Gets the number of associated outputs by sensor address.
      /// </summary>
      public override int PointAddressesByFeedbackAddress
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

      public int Port
      {
         get { return this.SystemSettingsNode.GetInteger(SETTINGS_KEY_PORT, 5550); }
         set
         {
            this.SystemSettingsNode.AddSetting(SETTINGS_KEY_PORT, value);
            OTCContext.Settings.SaveSettings();
         }
      }

      public string Host
      {
         get { return this.SystemSettingsNode.GetString(SETTINGS_KEY_HOST, "localhost"); }
         set
         {
            this.SystemSettingsNode.AddSetting(SETTINGS_KEY_HOST, value);
            OTCContext.Settings.SaveSettings();
         }
      }

      public int KeepaliveSignalInterval
      {
         get { return this.SystemSettingsNode.GetInteger(SETTINGS_KEY_KEEPALIVE_INTERVAL, 3000); }
         set
         {
            this.SystemSettingsNode.AddSetting(SETTINGS_KEY_KEEPALIVE_INTERVAL, value.ToString());
            OTCContext.Settings.SaveSettings();
         }
      }

      public int ReadWriteTimeout
      {
         get { return this.SystemSettingsNode.GetInteger(SETTINGS_KEY_RWTIMEOUT, 500); }
         set
         {
            this.SystemSettingsNode.AddSetting(SETTINGS_KEY_RWTIMEOUT, value.ToString());
            OTCContext.Settings.SaveSettings();
         }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Initialize and connect the disigtal system.
      /// </summary>
      public override bool Connect()
      {
         Logger.LogDebug(this, "[CLASS].Connect()");

         try
         {
            this.Status = SystemStatus.Connected;

            return true;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            this.OnInformationReceived(new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Error, ex.Message));

            return false;
         }
      }

      /// <summary>
      /// Disconnect the digital system and release all resources.
      /// </summary>
      public override bool Disconnect()
      {
         Logger.LogDebug(this, "[CLASS].Disconnect()");

         try
         {
            // Stop the acknowledgement signal timer
            if (this.AcknowledgementTimer != null && this.KeepaliveSignalInterval > 0)
            {
               this.AcknowledgementTimer.Stop();
               this.AcknowledgementTimer.Elapsed -= AcknowledgementTimer_Elapsed;
               this.AcknowledgementTimer.Dispose();
               this.AcknowledgementTimer = null;
            }

            // Close the serial port connection
            return true;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            return false;
         }
         finally
         {
            this.OnInformationReceived(new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Information, "System disconnected"));

            this.Status = SystemStatus.Disconnected;
         }
      }

      /// <summary>
      /// Show the configuration dialogue of the implemented system.
      /// </summary>
      /// <rereturns>A value indicating if the user has been accepted the settings or not.</rereturns>
      public override DialogResult ShowSettingsDialog()
      {
         SettingsView view = new SettingsView(this);
         return view.ShowDialog();
      }

      /// <summary>
      /// Request the system information.
      /// </summary>
      public override void SystemInformation()
      {
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
      /// Request the system information.
      /// </summary>
      public void InterfaceInformation()
      {
         try
         {
            this.Execute(new byte[] { 0xf0, 0xf0 }, false);
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
      public override void EmergencyOff()
      {
         try
         {
            this.SendMessageAsync("2180A1");
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
      public override void EmergencyStop()
      {
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
      public override void ResumeOperations()
      {
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
      /// <param name="activeOutput">Pin to activate (1/2).</param>
      public override void OperateAccessory(int address, int activeOutput)
      {
         try
         {
            byte addr = (byte)(address / 4);
            byte disconnect = (byte)(0x88 + (activeOutput - 1));
            byte connect = (byte)(0x80 + (activeOutput - 1));

            this.Execute(new byte[] { 0x52, addr, disconnect });

            System.Windows.Forms.Application.DoEvents();

            this.Execute(new byte[] { 0x52, addr, connect });

         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw new Exception("Command error: " + ex.Message, ex);
         }
      }

      /// <summary>
      /// Gets an accessory status information.
      /// </summary>
      /// <param name="address">Accessory address.</param>
      public override void GetAccessoryStatus(int address)
      {
         throw new NotImplementedException();
      }

      /// <summary>
      /// Set an accessory output.
      /// </summary>
      /// <param name="element">Element.</param>
      public override void SetAccessoryStatus(int address, bool turned, bool activate)
      {
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
      public override void SetSensorStatus(Element element, FeedbackStatus status)
      {
         throw new NotImplementedException();
      }

      #endregion

      #region Events

      protected override void OnInformationReceived(SystemConsoleEventArgs e)
      {
         base.OnInformationReceived(e);
      }

      protected override void OnCommandReceived(SystemCommandEventArgs e)
      {
         base.OnCommandReceived(e);
      }

      #endregion

      #region Event Handlers

      private void AcknowledgementTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
      {
         this.Execute(new byte[] { 0x21, 0x24, 0x05 });
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
      /// Send a request command to the digital system.
      /// </summary>
      /// <param name="commandBytes">Command bytes (without header & xor).</param>
      /// <returns></returns>
      internal void Execute(byte[] commandBytes, bool addXorByte = true)
      {
         // Send the command request
         byte[] bytes = this.GetRequestBytes(commandBytes, addXorByte);
         //this.SerialPort.Write(bytes, 0, bytes.Length);

         if (this.DebugMode)
         {
            this.OnInformationReceived(new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Debug,
                                                                  "TX -> {0}",
                                                                  BinaryUtils.ToString(bytes)));
         }
      }

      private async Task<string> SendMessageAsync(string command)
      {
         // String to store the response ASCII representation.
         string responseData = string.Empty;

         // Complete the command
         string cmd = "FFFE" + command + "\r\n";

         try
         {
            TcpClient client = new TcpClient();
            await client.ConnectAsync(this.Host, this.Port);

            using (client)
            {
               byte[] data = System.Text.Encoding.ASCII.GetBytes(cmd);
               NetworkStream stream = client.GetStream();

               // Send the message to the connected TcpServer.
               stream.Write(data, 0, data.Length);

               // Buffer to store the response bytes.
               data = new byte[256];

               // Read the first batch of the TcpServer response bytes.
               int bytes = stream.Read(data, 0, data.Length);
               responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
         }

         return responseData;
      }

      /// <summary>
      /// Get the command bytes to send to the digital system.
      /// </summary>
      private byte[] GetRequestBytes(byte[] commandBytes, bool addXorByte)
      {
         if (commandBytes.Length <= 0)
            return new byte[0];

         try
         {
            byte[] bytes = new byte[2 + commandBytes.Length + (addXorByte ? 1 : 0)];
            bytes[0] = 0xFF;
            bytes[1] = 0xFE;
            for (int idx = 0; idx < commandBytes.Length; idx++) bytes[2 + idx] = commandBytes[idx];
            if (addXorByte) bytes[bytes.Length - 1] = (byte)BinaryUtils.Xor(commandBytes);

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
         return null;
      }

      #endregion

   }
}
