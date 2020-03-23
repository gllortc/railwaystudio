using System;
using Rwm.Otc.Layout;

namespace Rwm.Otc.Systems
{

   #region Enumerations

   /// <summary>
   /// Contains all system statuses.
   /// </summary>
   public enum SystemStatus : int
   {
      Disconnected = 0,
      Connecting = 1,
      Connected = 2
   }

   /// <summary>
   /// Contains all feedback statuses.
   /// </summary>
   public enum FeedbackStatus : int
   {
      /// <summary>Accessory control module.</summary>
      Deactivated = 0,
      /// <summary>Accessory control module.</summary>
      Activated = 1
   }

   #endregion

   /// <summary>
   /// Interface implementable by all digital systems.
   /// </summary>
   public interface IDigitalSystem
   {

      #region Properties

      /// <summary>
      /// Gets the system unique identifier (GUID).
      /// </summary>
      string ID { get; }

      /// <summary>
      /// Gets the name of the system.
      /// </summary>
      string Name { get; }

      /// <summary>
      /// Gets a brief description of the system.
      /// </summary>
      string Description { get; }

      /// <summary>
      /// Gets the current implementation version.
      /// </summary>
      string Version { get; }

      /// <summary>
      /// Gets the number of associated outputs by sensor address.
      /// </summary>
      int OutputsBySensorAddress { get; }

      /// <summary>
      /// Gets the status of the system.
      /// </summary>
      SystemStatus Status { get; }

      #endregion

      #region Methods

      /// <summary>
      /// Initialize and connect the disigtal system.
      /// </summary>
      bool Connect();

      /// <summary>
      /// Disconnect the digital system and release all resources.
      /// </summary>
      bool Disconnect();

      /// <summary>
      /// Request the system information.
      /// </summary>
      void SystemInformation();

      /// <summary>
      /// Request power off the layout.
      /// </summary>
      void EmergencyOff();

      /// <summary>
      /// Request stopping all locomotives.
      /// </summary>
      void EmergencyStop();

      /// <summary>
      /// Request cancelling emergency off/stop and go to normal operation status.
      /// </summary>
      void ResumeOperations();

      /// <summary>
      /// Repuest accessory operation.
      /// </summary>
      /// <param name="address">Accessory address.</param>
      /// <param name="activatePin">Pin to activate (1/2).</param>
      void OperateAccessory(int address, int activatePin);

      /// <summary>
      /// Gets an accessory status information.
      /// </summary>
      /// <param name="address">Accessory address.</param>
      void GetAccessoryStatus(int address);

      /// <summary>
      /// Set an accessory output.
      /// </summary>
      /// <param name="element">Element.</param>
      void SetAccessoryStatus(int address, bool turned, bool activate);

      /// <summary>
      /// Allows set a sensor (for manual activation).
      /// </summary>
      /// <param name="element">Affected element.</param>
      /// <param name="status">Status.</param>
      void SetSensorStatus(Element element, FeedbackStatus status);

      /// <summary>
      /// Show the configuration dialogue of the implemented system.
      /// </summary>
      /// <rereturns>A value indicating if the user has been changed the settings or not.</rereturns>
      System.Windows.Forms.DialogResult ShowSettingsDialog();

      #endregion

      #region Events

      /// <summary>
      /// Event raised when any operation is requested or received by the digital system.
      /// </summary>
      event EventHandler<SystemConsoleEventArgs> OnInformationReceived;

      /// <summary>
      /// Event raised when any operation is requested or received by the digital system.
      /// </summary>
      event EventHandler<SystemCommandEventArgs> OnCommandReceived;

      #endregion

   }
}
