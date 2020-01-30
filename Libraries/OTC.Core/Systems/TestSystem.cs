using System;
using System.Threading;
using Rwm.Otc.Layout;
using Rwm.Otc.Systems;

namespace Rwm.OTC.Systems
{
   /// <summary>
   /// Implementation of a dummy digital system.
   /// </summary>
   public class TestSystem : IDigitalSystem
   {

      #region Constants

      private const string SYSTEM_GUID = "A88107DA-C8C4-408E-98E7-CC7D30C9F15F";

      private const int SENSOR_OUTPUTS_ADDRESS = 4;

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="TestSystem"/>.
      /// </summary>
      public TestSystem()
      {
         this.Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the system unique identifier (GUID).
      /// </summary>
      public string ID
      {
         get { return TestSystem.SYSTEM_GUID; }
      }

      /// <summary>
      /// Gets the name of the system.
      /// </summary>
      public string Name
      {
         get { return "Test Digital System"; }
      }

      /// <summary>
      /// Gets a brief description of the system.
      /// </summary>
      public string Description
      {
         get { return "Dummy system to test layout without connection to real system."; }
      }

      /// <summary>
      /// Gets the status of the system.
      /// </summary>
      public SystemStatus Status { get; private set; }

      /// <summary>
      /// Gets the number of associated outputs by sensor address.
      /// </summary>
      public int OutputsBySensorAddress
      {
         get { return TestSystem.SENSOR_OUTPUTS_ADDRESS; }
      }

      /// <summary>
      /// Gets a value indicating if the emergency stop has been activated or not.
      /// </summary>
      public bool EmergencyStopEnabled { get; private set; }

      #endregion

      #region Events

      /// <summary>
      /// Event raised when a sensor is activated or deactivated.
      /// </summary>
      public event EventHandler<FeedbackEventArgs> SensorStatusChanged;

      /// <summary>
      /// Event raised when an accessory is set outside the OTC context.
      /// </summary>
      public event EventHandler<AccessoryEventArgs> AccessoryStatusChanged;

      /// <summary>
      /// Event raised when any operation is requested or received by the digital system.
      /// </summary>
      public event EventHandler<SystemInfoEventArgs> SystemInformation;

      #endregion

      #region Methods

      public void Connect()
      {
         this.Status = SystemStatus.Connecting;

         if (this.SystemInformation != null)
         {
            this.SystemInformation(this, new SystemInfoEventArgs("{0} connected", this.Name));
            this.SystemInformation(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Warning,
                                                                 "System is not connected to any physical system and must be used for testing purposes only"));
         }

         this.Status = SystemStatus.Connected;

         System.Windows.Forms.Application.DoEvents();
      }

      /// <summary>
      /// Disconnect the digital system and release all resources.
      /// </summary>
      public void Disconnect()
      {
         if (this.SystemInformation != null)
         {
            this.SystemInformation(this, new SystemInfoEventArgs("Digital system disconnected"));
         }

         this.Status = SystemStatus.Disconnected;

         System.Windows.Forms.Application.DoEvents();
      }

      /// <summary>
      /// Stop all locomotives.
      /// </summary>
      public void SetEmergencyStop(bool enabled)
      {
         this.EmergencyStopEnabled = enabled;

         if (this.SystemInformation != null)
         {
            if (enabled)
            {
               this.SystemInformation(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Warning, 
                                                                    "Emergency stop: all locomotives stopped!"));
            }
            else
            {
               this.SystemInformation(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Information,
                                                                    "Emergency stop revoqued: all locomotive decoders active again"));
            }
         }

         System.Windows.Forms.Application.DoEvents();
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
      /// Gets an accessory status information.
      /// </summary>
      /// <param name="address">Accessory address.</param>
      /// <returns>An instance of <see cref="AccessoryInformation"/> filled with the information requested, otherwise returns <c>null</c>.</returns>
      public AccessoryInformation GetAccessoryStatus(int address)
      {
         return null;
      }

      /// <summary>
      /// Set an accessory output.
      /// </summary>
      /// <param name="address">Output address.</param>
      /// <param name="status">Value to set.</param>
      public void SetAccessoryStatus(Element element)
      {
         if (element.Connections?.Count <= 0)
         {
            this.SystemInformation?.Invoke(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Warning,
                                                                         "Accessory {0} not connected: command discarded", element));
            return;
         }

         foreach (DeviceConnection connection in element.Connections)
         {
            if (connection != null)
            {
               // Wait for indicate time between activations
               Thread.Sleep(connection.SwitchTime);

               // Execute the command to set the accessory
               this.SystemInformation?.Invoke(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Information,
                                                                            "SetAccessoryStatus: {0:0000} → T:{1}",
                                                                            connection.Address,
                                                                            connection.OutputMap.GetOutput(element.AccessoryStatus)));
            }
            else if (connection.Device?.Type == Device.DeviceType.AccessoryDecoder)
            {
               this.SystemInformation?.Invoke(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Warning,
                                                                            "Accessory {0:0000} not connected: command discarded",
                                                                            element.ToString()));
            }
         }

         System.Windows.Forms.Application.DoEvents();
      }

      /// <summary>
      /// Allows set a sensor (for manual activation).
      /// </summary>
      /// <param name="element">Affected element.</param>
      /// <param name="status">Status.</param>
      public void SetSensorStatus(Element element, FeedbackStatus status)
      {
         if (element.Connections?.Count <= 0)
         {
            this.SystemInformation?.Invoke(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Warning,
                                                                         "Feedback sensor {0} not connected: command discarded", element));
            return;
         }

         foreach (DeviceConnection connection in element.Connections)
         {
            if (connection != null)
            {
               // Execute the command to set the accessory
               this.SystemInformation(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Information,
                                                                    "SetSensorStatus: {0:0000} → T:{1}",
                                                                    connection.Address,
                                                                    status));
            }
            else
            {
               this.SystemInformation(this, new SystemInfoEventArgs(SystemInfoEventArgs.MessageType.Warning,
                                                                    "Sensor {0:0000} not connected: signal discarded",
                                                                    element.ToString()));
            }
         }

         System.Windows.Forms.Application.DoEvents();
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

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.Status = SystemStatus.Disconnected;
         this.EmergencyStopEnabled = false;
      }

      #endregion

   }
}
