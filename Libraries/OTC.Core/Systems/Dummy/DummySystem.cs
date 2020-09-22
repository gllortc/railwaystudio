using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Rwm.Otc.Utils;

namespace Rwm.Otc.Systems.Dummy
{
   /// <summary>
   /// Implementation of a dummy digital system.
   /// </summary>
   public class DummySystem : DigitalSystem
   {

      #region Constants

      private const string SYSTEM_GUID = "A88107DA-C8C4-408E-98E7-CC7D30C9F15F";

      private const int SENSOR_OUTPUTS_ADDRESS = 4;   // Like Lenz systems

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

      #region Fields


      #endregion

      #region Properties

      /// <summary>
      /// Gets the system unique identifier (GUID).
      /// </summary>
      public override string ID
      {
         get { return DummySystem.SYSTEM_GUID; }
      }

      /// <summary>
      /// Gets the name of the system.
      /// </summary>
      public override string Name
      {
         get { return "Test Digital System"; }
      }

      /// <summary>
      /// Gets a brief description of the system.
      /// </summary>
      public override string Description
      {
         get { return "Dummy system to test layout without any connection."; }
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
         get { return DummySystem.SENSOR_OUTPUTS_ADDRESS; }
      }

      /// <summary>
      /// Gets a value indicating if the emergency stop has been activated or not.
      /// </summary>
      public bool EmergencyStopEnabled { get; private set; }

      #endregion

      #region Methods

      public override bool Connect()
      {
         Logger.LogDebug(this, "[CLASS].Connect()");

         this.Status = SystemStatus.Connecting;

         base.OnInformationReceived(new SystemConsoleEventArgs("{0} connected", this.Name));
         this.OnInformationReceived(new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Warning,
                                                               "System is not connected to any physical system and must be used for testing purposes only"));

         this.Status = SystemStatus.Connected;

         System.Windows.Forms.Application.DoEvents();

         return true;
      }

      /// <summary>
      /// Disconnect the digital system and release all resources.
      /// </summary>
      public override bool Disconnect()
      {
         Logger.LogDebug(this, "[CLASS].Disconnect()");

         this.OnInformationReceived(new SystemConsoleEventArgs("Digital system disconnected"));

         this.Status = SystemStatus.Disconnected;

         System.Windows.Forms.Application.DoEvents();

         return true;
      }

      /// <summary>
      /// Get the digital system information.
      /// </summary>
      /// <returns>A <see cref="System.String"/> containing information about the digital system.</returns>
      public override void SystemInformation()
      {
         Logger.LogDebug(this, "[CLASS].SystemInformation()");

         DummySystemInformation command = new DummySystemInformation();

         this.OnInformationReceived(new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Warning,
                                                               "{0} ver. {1}", 
                                                               command.SystemName, command.SystemVersion));

         this.OnCommandReceived(new SystemCommandEventArgs(command));

         System.Windows.Forms.Application.DoEvents();
      }

      /// <summary>
      /// Request power off the layout.
      /// </summary>
      public override void EmergencyOff()
      {
         Logger.LogDebug(this, "[CLASS].EmergencyOff()");

         this.EmergencyStopEnabled = true;

         DummyEmergencyOff command = new DummyEmergencyOff();
         this.OnCommandReceived(new SystemCommandEventArgs(command));

         System.Windows.Forms.Application.DoEvents();
      }

      /// <summary>
      /// Request stopping all locomotives.
      /// </summary>
      public override void EmergencyStop()
      {
         Logger.LogDebug(this, "[CLASS].EmergencyStop()");
         
         this.EmergencyStopEnabled = true;

         DummyEmergencyStop command = new DummyEmergencyStop();
         this.OnCommandReceived(new SystemCommandEventArgs(command));

         System.Windows.Forms.Application.DoEvents();
      }

      /// <summary>
      /// Request cancelling emergency off/stop and go to normal operation status.
      /// </summary>
      public override void ResumeOperations()
      {
         Logger.LogDebug(this, "[CLASS].ResumeOperations()");

         this.EmergencyStopEnabled = false;

         DummyResumeOperations command = new DummyResumeOperations();
         this.OnCommandReceived(new SystemCommandEventArgs(command));

         System.Windows.Forms.Application.DoEvents();
      }

      /// <summary>
      /// Repuest accessory operation.
      /// </summary>
      /// <param name="address">Accessory address.</param>
      /// <param name="activatePin">Pin to activate (1/2).</param>
      public override void OperateAccessory(int address, int activatePin)
      {
         Logger.LogDebug(this, "[CLASS].ResumeOperations(#{0:D4}, {1})", address, activatePin);

         this.EmergencyStopEnabled = false;

         DummyAccessoryOperation command = new DummyAccessoryOperation(address, activatePin);
         this.OnCommandReceived(new SystemCommandEventArgs(command));

         System.Windows.Forms.Application.DoEvents();
      }

      /// <summary>
      /// Gets an accessory status information.
      /// </summary>
      /// <param name="address">Accessory address.</param>
      /// <returns>An instance of <see cref="AccessoryInformation"/> filled with the information requested, otherwise returns <c>null</c>.</returns>
      public override void GetAccessoryStatus(int address)
      {
         
      }

      /// <summary>
      /// Set an accessory output.
      /// </summary>
      /// <param name="address">DecoderInput address.</param>
      /// <param name="status">Value to set.</param>
      public override void SetAccessoryStatus(int address, bool turned, bool activate)
      {
         Logger.LogDebug(this, "[CLASS].SetAccessoryStatus(#{0:D4}, {1}, {2})", address, turned, activate);

         DummyEmergencyStop command = new DummyEmergencyStop();
         this.OnCommandReceived(new SystemCommandEventArgs(command));

         System.Windows.Forms.Application.DoEvents();
      }

      /// <summary>
      /// Allows set a sensor (for manual activation).
      /// </summary>
      /// <param name="element">Affected element.</param>
      /// <param name="status">Status.</param>
      public override void SetSensorStatus(Element element, FeedbackStatus status)
      {
         Logger.LogDebug(this, "[CLASS].SetSensorStatus([{0}], {1})", element, status);

         if (element.AccessoryConnections?.Count <= 0)
         {
            this.OnInformationReceived(new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Warning,
                                                                  "Feedback sensor {0} not connected: command discarded", 
                                                                  element));
            return;
         }

         foreach (FeedbackEncoderConnection connection in element.FeedbackConnections)
         {
            if (connection != null)
            {
               // Execute the command to set the accessory
               this.OnInformationReceived(new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Information,
                                                                     "SetSensorStatus: {0:0000} → T:{1}",
                                                                     connection.EncoderInput.Address,
                                                                     status));
            }
            else
            {
               this.OnInformationReceived(new SystemConsoleEventArgs(SystemConsoleEventArgs.MessageType.Warning,
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
      public override System.Windows.Forms.DialogResult ShowSettingsDialog()
      {
         Logger.LogDebug(this, "[CLASS].ShowSettingsDialog()");

         System.Windows.Forms.MessageBox.Show("This digital system doesn't have any configuration.",
                                              System.Windows.Forms.Application.ProductName,
                                              System.Windows.Forms.MessageBoxButtons.OK,
                                              System.Windows.Forms.MessageBoxIcon.Information);

         return System.Windows.Forms.DialogResult.Cancel;
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
