using System;
using Rwm.Otc.Layout;
using Rwm.Otc.Utils;

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
   public abstract class DigitalSystem
   {

      #region Properties

      /// <summary>
      /// Gets the system unique identifier (GUID).
      /// </summary>
      public abstract string ID { get; }

      /// <summary>
      /// Gets the name of the system.
      /// </summary>
      public abstract string Name { get; }

      /// <summary>
      /// Gets a brief description of the system.
      /// </summary>
      public virtual string Description 
      {
         get { return string.Empty; }
      }

      /// <summary>
      /// Gets the current implementation version.
      /// </summary>
      public virtual string Version
      {
         get { return "0.0"; }
      }

      /// <summary>
      /// Gets the valid accessory address range.
      /// </summary>
      public abstract Range AccessoryAddressRange { get; }

      /// <summary>
      /// Gets the valid feedback address range.
      /// </summary>
      public abstract Range FeedbackAddressRange { get; }

      /// <summary>
      /// Gets the number of associated outputs by sensor address.
      /// </summary>
      public abstract int PointAddressesByFeedbackAddress { get; }

      /// <summary>
      /// Gets the status of the system.
      /// </summary>
      public SystemStatus Status { get; set; } = SystemStatus.Disconnected;

      /// <summary>
      /// Gets the associated small icon (16x16px).
      /// </summary>
      public static System.Drawing.Image SmallIcon
      {
         get { return Properties.Resources.ICO_SYSTEM_16; }
      }

      /// <summary>
      /// Gets the associated large icon (32x32px).
      /// </summary>
      public static System.Drawing.Image LargeIcon
      {
         get { return Properties.Resources.ICO_SYSTEM_32; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Initialize and connect the disigtal system.
      /// </summary>
      public abstract bool Connect();

      /// <summary>
      /// Disconnect the digital system and release all resources.
      /// </summary>
      public virtual bool Disconnect()
      {
         this.Status = SystemStatus.Disconnected;
         return true;
      }

      /// <summary>
      /// Request the system information.
      /// </summary>
      public abstract void SystemInformation();

      /// <summary>
      /// Request power off the layout.
      /// </summary>
      public abstract void EmergencyOff();

      /// <summary>
      /// Request stopping all locomotives.
      /// </summary>
      public abstract void EmergencyStop();

      /// <summary>
      /// Request cancelling emergency off/stop and go to normal operation status.
      /// </summary>
      public abstract void ResumeOperations();

      /// <summary>
      /// Repuest accessory operation.
      /// </summary>
      /// <param name="address">Accessory address.</param>
      /// <param name="activatePin">Pin to activate (1/2).</param>
      public abstract void OperateAccessory(int address, int activatePin);

      /// <summary>
      /// Gets an accessory status information.
      /// </summary>
      /// <param name="address">Accessory address.</param>
      public abstract void GetAccessoryStatus(int address);

      /// <summary>
      /// Set an accessory output.
      /// </summary>
      /// <param name="element">Element.</param>
      public abstract void SetAccessoryStatus(int address, bool turned, bool activate);

      /// <summary>
      /// Allows set a sensor (for manual activation).
      /// </summary>
      /// <param name="element">Affected element.</param>
      /// <param name="status">Status.</param>
      public abstract void SetSensorStatus(Element element, FeedbackStatus status);

      /// <summary>
      /// Show the configuration dialogue of the implemented system.
      /// </summary>
      /// <rereturns>A value indicating if the user has been changed the settings or not.</rereturns>
      public virtual System.Windows.Forms.DialogResult ShowSettingsDialog()
      {
         System.Windows.Forms.MessageBox.Show("This digital system doesn't have any configuration.",
                                              System.Windows.Forms.Application.ProductName,
                                              System.Windows.Forms.MessageBoxButtons.OK,
                                              System.Windows.Forms.MessageBoxIcon.Information);

         return System.Windows.Forms.DialogResult.Cancel;
      }

      #endregion

      #region Events

      /// <summary>
      /// Event raised when any operation is requested or received by the digital system.
      /// </summary>
      public event EventHandler<SystemConsoleEventArgs> InformationReceived;

      protected virtual void OnInformationReceived(SystemConsoleEventArgs e)
      {
         this.InformationReceived?.Invoke(this, e);
      }

      /// <summary>
      /// Event raised when any operation is requested or received by the digital system.
      /// </summary>
      public event EventHandler<SystemCommandEventArgs> CommandReceived;

      protected virtual void OnCommandReceived(SystemCommandEventArgs e)
      {
         this.CommandReceived?.Invoke(this, e);
      }

      #endregion

   }
}
