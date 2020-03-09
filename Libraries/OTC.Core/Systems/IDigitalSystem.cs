using Rwm.Otc.Configuration;
using Rwm.Otc.Layout;
using System;

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
      /// Stop all locomotives.
      /// </summary>
      /// <param name="enabled">A value indicating if the status is enabled or disabled.</param>
      bool SetEmergencyStop(bool enabled);

      /// <summary>
      /// Get the digital system information.
      /// </summary>
      /// <returns>A <see cref="System.String"/> containing information about the digital system.</returns>
      DigitalSystemInfo GetSystemInformation();

      /// <summary>
      /// Gets an accessory status information.
      /// </summary>
      /// <param name="address">Accessory address.</param>
      /// <returns>An instance of <see cref="AccessoryInformation"/> filled with the information requested, otherwise returns <c>null</c>.</returns>
      AccessoryInformation GetAccessoryStatus(int address);

      /// <summary>
      /// Set an accessory output.
      /// </summary>
      /// <param name="element">Element.</param>
      void SetAccessoryStatus(Element element);

      /// <summary>
      /// Allows set a sensor (for manual activation).
      /// </summary>
      /// <param name="element">Affected element.</param>
      /// <param name="status">Status.</param>
      void SetSensorStatus(Element element, FeedbackStatus status);

      /// <summary>
      /// Show the configuration dialogue of the implemented system.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      /// <rereturns>A value indicating if the user has been changed the settings or not.</rereturns>
      System.Windows.Forms.DialogResult ShowSettingsDialog(XmlSettingsManager settings);

      #endregion

      #region Events

      /// <summary>
      /// Event raised when a sensor is activated.
      /// </summary>
      event EventHandler<FeedbackEventArgs> SensorStatusChanged;

      /// <summary>
      /// Event raised when a sensor is activated.
      /// </summary>
      event EventHandler<AccessoryEventArgs> AccessoryStatusChanged;

      /// <summary>
      /// Event raised when any operation is requested or received by the digital system.
      /// </summary>
      event EventHandler<SystemInfoEventArgs> SystemInformation;

      #endregion

   }
}
