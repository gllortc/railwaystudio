using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.Systems;
using Rwm.Otc.Systems.Protocol;
using Rwm.Otc.Trains;
using Rwm.Studio.Plugins.Common;
using Rwm.Studio.Plugins.Common.Views;

namespace Rwm.Studio.Plugins.Designer.Modules
{
   public partial class TesterModule
   {

      #region Properties

      /// <summary>
      /// Gets the data table containing all calculated addresses and CVs.
      /// </summary>
      internal DataTable AddressData { get; private set; } = null;

      #endregion

      #region Methods

      /// <summary>
      /// Open the systems manager dialogue.
      /// </summary>
      internal void SystemsManage()
      {
         // Unregister project events
         OTCContext.Project.DigitalSystem.InformationReceived -= DigitalSystem_OnInformationReceived;
         OTCContext.Project.DigitalSystem.CommandReceived -= DigitalSystem_OnCommandReceived;

         SystemManagerView form = new SystemManagerView();
         form.ShowDialog(this);

         // Register project events
         OTCContext.Project.DigitalSystem.InformationReceived += DigitalSystem_OnInformationReceived;
         OTCContext.Project.DigitalSystem.CommandReceived += DigitalSystem_OnCommandReceived;

         // Refresh the current digital system
         this.RefreshStatus();
      }

      /// <summary>
      /// Connect/disconnect the digital system.
      /// </summary>
      internal void SystemConnect()
      {
         Cursor.Current = Cursors.WaitCursor;

         try
         {
            // Register project events
            OTCContext.Project.DigitalSystem.InformationReceived += DigitalSystem_OnInformationReceived;
            OTCContext.Project.DigitalSystem.CommandReceived += DigitalSystem_OnCommandReceived;

            OTCContext.Project.DigitalSystem?.Connect();
         }
         catch (Exception ex)
         {
            StudioContext.LogError(ex.Message);
         }

         this.RefreshStatus();

         Cursor.Current = Cursors.Default;
      }

      /// <summary>
      /// Connect/disconnect the digital system.
      /// </summary>
      internal void SystemDisconnect()
      {
         Cursor.Current = Cursors.WaitCursor;

         OTCContext.Project.TrafficManager?.Stop();
         OTCContext.Project.DigitalSystem?.Disconnect();

         // Unregister project events
         OTCContext.Project.DigitalSystem.InformationReceived -= DigitalSystem_OnInformationReceived;
         OTCContext.Project.DigitalSystem.CommandReceived -= DigitalSystem_OnCommandReceived;

         this.RefreshStatus();

         Cursor.Current = Cursors.Default;
      }

      /// <summary>
      /// Show the selected system settings dialogue.
      /// </summary>
      internal void SystemSettings()
      {
         OTCContext.Project.DigitalSystem.ShowSettingsDialog();
      }

      /// <summary>
      /// Request an emergency stop to the command station.
      /// </summary>
      internal void EmergencyStopRequest()
      {
         OTCContext.Project.DigitalSystem.EmergencyStop();
      }

      /// <summary>
      /// Request an emergency off to the command station.
      /// </summary>
      internal void EmergencyOffRequest()
      {
         OTCContext.Project.DigitalSystem.EmergencyOff();
      }

      /// <summary>
      /// Request a resume operations to the command station.
      /// </summary>
      internal void ResumeOperationsRequest()
      {
         OTCContext.Project.DigitalSystem.ResumeOperations();
      }

      internal void AddressCalculate()
      {
         if (this.AddressData == null)
         {
            this.AddressData = new DataTable("Addresses");
            this.AddressData.Columns.Add("Address", typeof(int));
            this.AddressData.Columns.Add("CV1", typeof(int));
            this.AddressData.Columns.Add("CV17", typeof(int));
            this.AddressData.Columns.Add("CV18", typeof(int));
         }

         grdAddressView.BeginUpdate();

         if (grdAddressView.Columns.Count <= 0)
         {
            grdAddressView.Columns.Add(new GridColumn() { FieldName = "Address", Caption = "Address", Visible = true, Width = 120 });
            grdAddressView.Columns.Add(new GridColumn() { FieldName = "CV1", Caption = "CV1", Visible = true, Width = 120 });
            grdAddressView.Columns.Add(new GridColumn() { FieldName = "CV17", Caption = "CV17", Visible = true, Width = 120 });
            grdAddressView.Columns.Add(new GridColumn() { FieldName = "CV18", Caption = "CV18", Visible = true, Width = 120 });

            grdAddressView.Columns["Address"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdAddressView.Columns["Address"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdAddressView.Columns["Address"].AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
            grdAddressView.Columns["Address"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdAddressView.Columns["Address"].DisplayFormat.FormatString = "D4";

            grdAddressView.Columns["CV1"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdAddressView.Columns["CV1"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            grdAddressView.Columns["CV17"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdAddressView.Columns["CV17"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            grdAddressView.Columns["CV18"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdAddressView.Columns["CV18"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            grdAddress.DataSource = this.AddressData;
         }

         TrainDigitalAddress address = new TrainDigitalAddress((uint)Decimal.ToInt32((decimal)txtAddress.EditValue));
         this.AddressData.Rows.Add(new object[] { (int)txtAddress.Value, address.CV1, address.CV17, address.CV18 });

         grdAddressView.EndUpdate();
      }

      /// <summary>
      /// Update screen information
      /// </summary>
      public void RefreshStatus()
      {
         // Show theme information
         bbtnThemesManage.Caption = (OTCContext.Project.Theme == null ? "[No theme]" : OTCContext.Project.Theme.Name);
         bbtnThemesManage.Glyph = (OTCContext.Project.Theme == null ? Properties.Resources.ICO_THEME_UNSELECTED_16 : Otc.Utils.Icons.Theme16);

         // Show system information
         bbtnSystemsManage.Caption = (OTCContext.Project.DigitalSystem == null ? "[No system]" : OTCContext.Project.DigitalSystem.Name);
         bbtnSystemsManage.Glyph = (OTCContext.Project.DigitalSystem == null ? Properties.Resources.ICO_SYSTEM_DISCONNECT_16 : Otc.Systems.DigitalSystem.SmallIcon);

         // Update system controls
         cmdSystemSettings.Enabled = (OTCContext.Project.DigitalSystem != null);
         rpgControl.Enabled = !(OTCContext.Project.DigitalSystem == null || OTCContext.Project.DigitalSystem.Status != SystemStatus.Connected);
         cmdSystemConnect.Enabled = (OTCContext.Project.DigitalSystem != null && OTCContext.Project.DigitalSystem.Status != SystemStatus.Connected);
         cmdSystemDisconnect.Enabled = !cmdSystemConnect.Enabled;
      }

      #endregion

      #region Event Handlers

      private void DigitalSystem_OnInformationReceived(object sender, Otc.Systems.SystemConsoleEventArgs e)
      {
         switch (e.Type)
         {
            case SystemConsoleEventArgs.MessageType.Error:
               StudioContext.LogError(e.Message);
               break;

            case SystemConsoleEventArgs.MessageType.Warning:
               StudioContext.LogWarning(e.Message);
               break;

            case SystemConsoleEventArgs.MessageType.Debug:
               StudioContext.LogDebug(e.Message);
               break;

            default:
               StudioContext.LogInformation(e.Message);
               break;
         }
      }

      private void DigitalSystem_OnCommandReceived(object sender, Otc.Systems.SystemCommandEventArgs e)
      {
         if (e.CommandReceived == null)
         {
            return;
         }
         else if (e.CommandReceived is IFeedbackStatusChanged)
         {
            IFeedbackStatusChanged reportedStatuses = e.CommandReceived as IFeedbackStatusChanged;
            if (reportedStatuses != null)
               feedbackTesterControl.FeedbackReceived(reportedStatuses.ReportedStatuses);
         }
      }

      #endregion

      #region Private Members

      private void AccessoryOperationCommandReceived(IAccessoryOperation command)
      {
         Element element = Element.GetByAccessoryAddress(command.Address);
         if (element != null)
         {
            element.SetAccessoryStatus(command.Status);

            StudioContext.LogInformation("Accessory {0:D4} changed to status #{1}", command.Address, command.Status);
         }
         else
            StudioContext.LogWarning("Accessory {0:D4} changed to status #{1}: Address not used in current layout", command.Address, command.Status);
      }

      private void FeedbackStatusReceived(IFeedbackStatusChanged command)
      {
         Element element;

         foreach (FeedbackPointAddressStatus status in command.ReportedStatuses)
         {
            element = Element.GetByFeedbackAddress(command.Address, status.PointAddress);
            if (element != null)
            {
               if (element.FeedbackStatus != status.Active)
               {
                  element.SetFeedbackStatus(status.Active);
                  StudioContext.LogInformation("Accessory {0:D4}:{1} changed to status {2}", command.Address, status.PointAddress, (status.Active ? "HIGH" : "LOW"));
               }
            }
         }
      }

      private void SystemInformationCommandReceived(ISystemInformation command)
      {
         StudioContext.LogInformation("Command station {0} ver {1}", command.SystemName, command.SystemVersion);
      }

      private void InterfaceInformationCommandReceived(IInterfaceInformation command)
      {
         StudioContext.LogInformation("USB Interface v{0}.0 (software ver {1}.0)", command.HardwareVersion, command.SoftwareVersion);
      }

      private void EmergencyStopCommandReceived()
      {
         cmdCtrlEmergencyStop.Down = true;
         cmdCtrlEmergencyStop.Enabled = false;
         cmdCtrlResumeOps.Enabled = true;

         StudioContext.LogWarning("EMERGENCY stop all locomotoves activated");
      }

      private void ResumeOperationsCommandReceived()
      {
         cmdCtrlEmergencyStop.Down = false;
         cmdCtrlEmergencyStop.Enabled = true;
         cmdCtrlResumeOps.Enabled = false;

         StudioContext.LogWarning("RESUME OPERATIONS: normal operation stablished");
      }

      #endregion

   }
}
