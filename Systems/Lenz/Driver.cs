using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.Systems;
using Rwm.OTC.Systems.Lenz.Commands;
using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;

namespace Rwm.OTC.Systems.Lenz
{
   internal class Driver : IDigitalSystem
   {

      #region Constants

      private const string SYSTEM_GUID = "4F602F52-B8F8-46AF-A940-79ECEADC7400";

      private const int SYSTEM_SENSOR_ADDR_OUTPUTS = 8;

      public const string SETTING_PORT_NAME = "Port.Name";
      public const string SETTING_PORT_SPEED = "Port.Speed";
      public const string SETTING_REQUEST_TIMEOUT = "Request.Timeout";

      #endregion

      #region Constructors

      public Driver()
      {
         this.Initialize();
      }

      #endregion

      #region Properties

      public string ID
      {
         get { return Driver.SYSTEM_GUID; }
      }

      public string Name
      {
         get { return this.GetType().Assembly.GetName().Name; }
      }

      public string Description
      {
         get { return this.GetType().Assembly.GetName().Version.ToString(); }
      }

      /// <summary>
      /// Gets the status of the system.
      /// </summary>
      public SystemStatus Status { get; private set; } 

      public int OutputsBySensorAddress
      {
         get { return Driver.SYSTEM_SENSOR_ADDR_OUTPUTS; }
      }

      private SerialPort Port { get; set; }

      private Command CurrentCommand { get; set; }

      public string PortName
      {
         get { return OTCContext.Settings.GetString(Driver.SETTING_PORT_NAME, "COM1"); }
      }

      public int PortSpeed
      {
         get { return OTCContext.Settings.GetInteger(Driver.SETTING_PORT_SPEED, 9600); }
      }

      public int RequestTimeout
      {
         get { return OTCContext.Settings.GetInteger(Driver.SETTING_REQUEST_TIMEOUT, 90); }
      }

      public bool IsConnected
      {
         get
         {
            if (this.Port == null)
            {
               return false;
            }

            return this.Port.IsOpen;
         }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Abre el canal de comunicaciones con el interface Lenz.
      /// </summary>
      /// <param name="name">Nombre del puerto (por ejemplo: COM2).</param>
      /// <param name="baudRate">Velocidad de comunicación.</param>
      public void Connect()
      {
         // Asegura que el puerto se encuentre cerrado
         this.Disconnect();

         // Abre el puerto
         try
         {
            this.Port.DataBits = 8;
            this.Port.Parity = Parity.None;
            this.Port.StopBits = StopBits.One;
            this.Port.PortName = this.PortName;
            this.Port.BaudRate = this.PortSpeed;
            this.Port.Open();

            // Agrega los eventos de control de datos y errores recibidos
            this.Port.DataReceived += new SerialDataReceivedEventHandler(PortDataReceived);
         }
         catch (Exception ex)
         {
            throw new Exception("No se puede abrir el puerto " + this.PortName + ": " + ex.Message, ex);
         }
      }

      /// <summary>
      /// Cierra el puerto de comunicaciones.
      /// </summary>
      public void Disconnect()
      {
         if (this.IsConnected)
         {
            this.Port.Close();
            this.Port.Dispose();
            this.Port = null;
         }
      }

      /// <summary>
      /// Stop all locomotives.
      /// </summary>
      /// <param name="enabled">A value indicating if the status is enabled or disabled.</param>
      public void SetEmergencyStop(bool enabled)
      {
         this.SendCommand(new EmergencyStopCommand());
      }

      public DigitalSystemInfo GetSystemInformation()
      {
         DigitalSystemInfo info = new DigitalSystemInfo();

         SystemInformationCommand syscmd = new SystemInformationCommand();
         if (this.SendCommand(syscmd))
         {
            info.SystemName = syscmd.SystemName;
            info.SystemVersion = syscmd.SystemVersion;
         }

         InterfaceInformationCommand ifcmd = new InterfaceInformationCommand();
         if (this.SendCommand(ifcmd))
         {
            info.InterfaceName = ifcmd.InterfaceName;
            info.InterfaceVersion = string.Format("HW:{0} SW:{1}", 
                                                  ifcmd.HardwareVersion,
                                                  ifcmd.SoftwareVersion);
         }

         return info;
      }

      public AccessoryInformation GetAccessoryStatus(int address)
      {
         throw new NotImplementedException();
      }

      public void SetAccessoryStatus(Element element)
      {
         AccessoryDecoderOperationCommand cmd = null;

         foreach (DeviceConnection connection in element.Connections)
         {
            // Wait for indicate time between activations
            Thread.Sleep(connection.SwitchTime);

            // Execute the command to set the accessory
            cmd = new AccessoryDecoderOperationCommand(connection.Address, 
                                                       connection.OutputMap.GetOutput(element.AccessoryStatus));
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

      #region Events

      public event EventHandler<FeedbackEventArgs> SensorStatusChanged;

      public event EventHandler<AccessoryEventArgs> AccessoryStatusChanged;

      public event EventHandler<SystemInfoEventArgs> SystemInformation;

      #endregion

      #region Event Handlers

      /// <summary>
      /// Trata la recepción de datos desde el puerto.
      /// </summary>
      private void PortDataReceived(object sender, SerialDataReceivedEventArgs e)
      {
         byte[] byteResp = new byte[this.Port.ReadBufferSize];

         // Read the port information
         this.Port.Read(byteResp, 0, this.Port.ReadBufferSize);

         // Get the system response
         if (!this.CurrentCommand.ParseCommandData(byteResp))
         {
            return;
         }

         //// Generate the response
         //if (this.CurrentResponse.Type ==   !this.CurrentCommand.ParseCommandData(byteResp))
         //{
         //   this.CurrentCommand = null;
         //   // OnError(new OTCInformationEventArgs("Paquete desconocido [" + _response.ToString() + "]"), new Exception("Paquete desconocido"));
         //   return;
         //}

         //// Trata los paquetes recibidos sin petición (feedback, etc)
         //switch (this.CurrentCommand.CommandType)
         //{
         //   case SystemResponses.RespFeedback1Addy:
         //   case SystemResponses.RespFeedback2Addy:
         //   case SystemResponses.RespFeedback3Addy:
         //   case SystemResponses.RespFeedback4Addy:
         //   case SystemResponses.RespFeedback5Addy:
         //   case SystemResponses.RespFeedback6Addy:
         //   case SystemResponses.RespFeedback7Addy:
         //      {
         //         // Encolar información
         //         break;
         //      }
         //}
      }

      #endregion

      #region Private Members

      private void Initialize()
      {
         this.CurrentCommand = null;
         this.Status = SystemStatus.Disconnected;
      }

      public bool SendCommand(Command command)
      {
         Stopwatch watch = null;
         TimeSpan span;

         if (!this.IsConnected)
         {
            throw new Exception("Not connected");
         }

         watch = new Stopwatch();
         span = TimeSpan.FromSeconds(this.RequestTimeout);

         // Store current command
         this.CurrentCommand = command;

         // Send command
         this.Port.Write(command.RequestData, 0, command.RequestData.Length);

         watch.Start();

         // Wait for command response
         while (!this.CurrentCommand.IsResponseReceived)
         {
            Thread.Sleep(5);

            if (watch.Elapsed > span)
            {
               watch.Stop();
               throw new Exception("Command timeout");
            }
         }

         watch.Stop();
         watch = null;

         this.CurrentCommand = null;

         return true;
      }

      #endregion

   }
}
