using Rwm.Otc.Configuration;
using Rwm.Otc.Layout;
using Rwm.Otc.Layout.Elements;
using Rwm.Otc.Systems;
using System;
using System.Threading;

namespace Rwm.OTC.Systems
{
   public class TestSystem : IDigitalSystem
   {

      #region Constants

      private const string SYSTEM_GUID = "A88107DA-C8C4-408E-98E7-CC7D30C9F15F";

      private const int SENSOR_OUTPUTS_ADDRESS = 4;

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
      /// Gets the number of associated outputs by sensor address.
      /// </summary>
      public int OutputsBySensorAddress
      {
         get { return TestSystem.SENSOR_OUTPUTS_ADDRESS; }
      }

      /// <summary>
      /// Gets the current application settings.
      /// </summary>
      public XmlSettingsManager Settings { get; private set; }

      #endregion

      #region Events

      /// <summary>
      /// Event raised when a sensor is activated or deactivated.
      /// </summary>
      public event EventHandler<FeedbackEventArgs> SensorActivated;

      /// <summary>
      /// Event raised when any operation is requested or received by the digital system.
      /// </summary>
      public event EventHandler<SystemInformationEventArgs> SystemInformation;

      #endregion

      #region Methods

      public void Connect(XmlSettingsManager settings)
      {
         this.Settings = settings;

         if (this.SystemInformation != null)
         {
            this.SystemInformation(this, new SystemInformationEventArgs("Digital system connected"));
            this.SystemInformation(this, new SystemInformationEventArgs("System is not connected to any physical system!", SystemInformationEventArgs.MessageType.Warning));
         }
      }

      /// <summary>
      /// Disconnect the digital system and release all resources.
      /// </summary>
      public void Disconnect()
      {
         if (this.SystemInformation != null)
         {
            this.SystemInformation(this, new SystemInformationEventArgs("Digital system disconnected"));
         }
      }

      /// <summary>
      /// Stop all locomotives.
      /// </summary>
      public void EmergencyStop()
      {
         if (this.SystemInformation != null)
         {
            this.SystemInformation(this, new SystemInformationEventArgs("Emergency stop: all locomotives stopped!"));
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
      public void SetAccessoryStatus(Rwm.Otc.Layout.Elements.ElementBase element)
      {
         IAccessory accBlock = element as IAccessory;

         if (this.SystemInformation != null)
         {
            foreach (DeviceConnection connection in element.AccessoryConnections)
            {
               if (connection != null)
               {
                  // Wait for indicate time between activations
                  Thread.Sleep(connection.SwitchTime);

                  // Execute the command to set the accessory
                  this.SystemInformation(this, new SystemInformationEventArgs("SetAccessoryStatus: {0:0000} → T:{1}",
                                                                              SystemInformationEventArgs.MessageType.Information,
                                                                              connection.Address,
                                                                              connection.OutputMap.GetOutput(accBlock.GetAccessoryStatus())));
               }
            }
         }
      }

      #endregion

      #region Event Handlers

      #endregion

   }
}
