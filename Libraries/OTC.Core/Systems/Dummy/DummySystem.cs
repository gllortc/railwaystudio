using System;
using Rwm.Otc.Layout;

namespace Rwm.Otc.Systems.Dummy
{
   /// <summary>
   /// Implementation of a dummy digital system.
   /// </summary>
   public class DummySystem : IDigitalSystem
   {

      #region Constants

      private const string SYSTEM_GUID = "A88107DA-C8C4-408E-98E7-CC7D30C9F15F";

      private const int SENSOR_OUTPUTS_ADDRESS = 8;   // Like Lenz systems

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="DummySystem"/>.
      /// </summary>
      public DummySystem()
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
         get { return DummySystem.SYSTEM_GUID; }
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
         get { return "Dummy system to test layout without any connection."; }
      }

      /// <summary>
      /// Gets the current implementation version.
      /// </summary>
      public string Version
      {
         get { return Rwm.Otc.Utils.ReflectionUtils.GetAssemblyVersion(this.GetType()); }
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
         get { return DummySystem.SENSOR_OUTPUTS_ADDRESS; }
      }

      /// <summary>
      /// Gets a value indicating if the emergency stop has been activated or not.
      /// </summary>
      public bool EmergencyStopEnabled { get; private set; }

      #endregion

      #region Events

      /////// <summary>
      /////// Event raised when a sensor is activated or deactivated.
      /////// </summary>
      ////public event EventHandler<FeedbackEventArgs> SensorStatusChanged;

      /////// <summary>
      /////// Event raised when an accessory is set outside the OTC context.
      /////// </summary>
      ////public event EventHandler<AccessoryEventArgs> AccessoryStatusChanged;

      /// <summary>
      /// Event raised when any operation is requested or received by the digital system.
      /// </summary>
      public event EventHandler<SystemConsoleEventArgs> OnInformationReceived;

      /// <summary>
      /// Event raised when any operation is requested or received by the digital system.
      /// </summary>
      public event EventHandler<SystemCommandEventArgs> OnCommandReceived;

      #endregion

      #region Methods

      public bool Connect()
      {
         this.Status = SystemStatus.Connecting;

         this.OnInformationReceived?.Invoke(this, new SystemConsoleEventArgs("{0} connected", this.Name));
         this.OnInformationReceived?.Invoke(this, new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Warning,
                                                                             "System is not connected to any physical system and must be used for testing purposes only"));

         this.Status = SystemStatus.Connected;

         System.Windows.Forms.Application.DoEvents();

         return true;
      }

      /// <summary>
      /// Disconnect the digital system and release all resources.
      /// </summary>
      public bool Disconnect()
      {
         this.OnInformationReceived?.Invoke(this, new SystemConsoleEventArgs("Digital system disconnected"));

         this.Status = SystemStatus.Disconnected;

         System.Windows.Forms.Application.DoEvents();

         return true;
      }

      /// <summary>
      /// Get the digital system information.
      /// </summary>
      /// <returns>A <see cref="System.String"/> containing information about the digital system.</returns>
      public void SystemInformation()
      {
         DummySystemInformation command = new DummySystemInformation();

         this.OnInformationReceived?.Invoke(this, new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Warning,
                                                                             "{0} ver. {1}", command.SystemName, command.SystemVersion));

         this.OnCommandReceived?.Invoke(this, new SystemCommandEventArgs(command));

         System.Windows.Forms.Application.DoEvents();
      }

      /// <summary>
      /// Request power off the layout.
      /// </summary>
      public void EmergencyOff()
      {
         this.EmergencyStopEnabled = true;

         DummyEmergencyOff command = new DummyEmergencyOff();
         this.OnCommandReceived?.Invoke(this, new SystemCommandEventArgs(command));

         System.Windows.Forms.Application.DoEvents();
      }

      /// <summary>
      /// Request stopping all locomotives.
      /// </summary>
      public void EmergencyStop()
      {
         this.EmergencyStopEnabled = true;

         DummyEmergencyStop command = new DummyEmergencyStop();
         this.OnCommandReceived?.Invoke(this, new SystemCommandEventArgs(command));

         System.Windows.Forms.Application.DoEvents();
      }

      /// <summary>
      /// Request cancelling emergency off/stop and go to normal operation status.
      /// </summary>
      public void ResumeOperations()
      {
         this.EmergencyStopEnabled = false;

         DummyResumeOperations command = new DummyResumeOperations();
         this.OnCommandReceived?.Invoke(this, new SystemCommandEventArgs(command));

         System.Windows.Forms.Application.DoEvents();
      }

      /// <summary>
      /// Repuest accessory operation.
      /// </summary>
      /// <param name="address">Accessory address.</param>
      /// <param name="activatePin">Pin to activate (1/2).</param>
      public void OperateAccessory(int address, int activatePin)
      {
         this.EmergencyStopEnabled = false;

         DummyAccessoryOperation command = new DummyAccessoryOperation(address, activatePin);
         this.OnCommandReceived?.Invoke(this, new SystemCommandEventArgs(command));

         System.Windows.Forms.Application.DoEvents();
      }

      /// <summary>
      /// Gets an accessory status information.
      /// </summary>
      /// <param name="address">Accessory address.</param>
      /// <returns>An instance of <see cref="AccessoryInformation"/> filled with the information requested, otherwise returns <c>null</c>.</returns>
      public void GetAccessoryStatus(int address)
      {
         
      }

      /// <summary>
      /// Set an accessory output.
      /// </summary>
      /// <param name="address">DecoderInput address.</param>
      /// <param name="status">Value to set.</param>
      public void SetAccessoryStatus(int address, bool turned, bool activate)
      {
         DummyEmergencyStop command = new DummyEmergencyStop();
         this.OnCommandReceived?.Invoke(this, new SystemCommandEventArgs(command));

         System.Windows.Forms.Application.DoEvents();
      }

      /// <summary>
      /// Allows set a sensor (for manual activation).
      /// </summary>
      /// <param name="element">Affected element.</param>
      /// <param name="status">Status.</param>
      public void SetSensorStatus(Element element, FeedbackStatus status)
      {
         if (element.AccessoryConnections?.Count <= 0)
         {
            this.OnInformationReceived?.Invoke(this, new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Warning,
                                                                                "Feedback sensor {0} not connected: command discarded", element));
            return;
         }

         foreach (FeedbackDecoderConnection connection in element.FeedbackConnections)
         {
            if (connection != null)
            {
               // Execute the command to set the accessory
               this.OnInformationReceived?.Invoke(this, new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Information,
                                                                                   "SetSensorStatus: {0:0000} → T:{1}",
                                                                                   connection.Address,
                                                                                   status));
            }
            else
            {
               this.OnInformationReceived?.Invoke(this, new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Warning,
                                                                                   "Sensor {0:0000} not connected: signal discarded",
                                                                                   element.ToString()));
            }
         }

         System.Windows.Forms.Application.DoEvents();
      }

      /// <summary>
      /// Show the configuration dialogue of the implemented system.
      /// </summary>
      /// <rereturns>A value indicating if the user has been changed the settings or not.</rereturns>
      public System.Windows.Forms.DialogResult ShowSettingsDialog()
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
