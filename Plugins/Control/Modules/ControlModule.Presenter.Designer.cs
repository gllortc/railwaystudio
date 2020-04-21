using System;
using System.Windows.Forms;
using DevExpress.XtraTab;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.Systems;
using Rwm.Otc.Systems.Protocol;
using Rwm.Otc.Trains;
using Rwm.Otc.UI;
using Rwm.Otc.UI.Controls;
using Rwm.Studio.Plugins.Common;
using Rwm.Studio.Plugins.Control.Views;

namespace Rwm.Studio.Plugins.Control.Modules
{
   public partial class ControlModule
   {

      #region Properties

      /// <summary>
      /// Gets the current digital command system.
      /// </summary>
      public IDigitalSystem DigitalSystem { get; private set; }

      #endregion

      #region Methods

      /// <summary>
      /// Open the systems manager dialogue.
      /// </summary>
      internal void SystemsManage()
      {
         SystemManagerView form = new SystemManagerView();
         form.ShowDialog(this);
      }

      /// <summary>
      /// Connect/disconnect the digital system.
      /// </summary>
      internal void SystemConnect()
      {
         Cursor.Current = Cursors.WaitCursor;

         try
         {
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

         OTCContext.Project.DigitalSystem?.Disconnect();

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

      /// <summary>
      /// Update screen information
      /// </summary>
      public void RefreshStatus()
      {
         SwitchboardCommandControl ctrl = null;

         // Show theme information
         bbtnThemesManage.Caption = (OTCContext.Project.Theme == null ? "[No theme]" : OTCContext.Project.Theme.Name);
         bbtnThemesManage.Glyph = (OTCContext.Project.Theme == null ? Control.Properties.Resources.ICO_THEME_UNSELECTED_16 : Control.Properties.Resources.ICO_THEME_16);

         // Show system information
         bbtnSystemsManage.Caption = (OTCContext.Project.DigitalSystem == null ? "[No system]" : OTCContext.Project.DigitalSystem.Name);
         bbtnSystemsManage.Glyph = (OTCContext.Project.DigitalSystem == null ? Control.Properties.Resources.ICO_SYSTEMS_UNSELECTED_16 : Control.Properties.Resources.ICO_SYSTEM_16);

         // Update system controls
         cmdSystemSettings.Enabled = (OTCContext.Project.DigitalSystem != null);
         rpgControl.Enabled = !(OTCContext.Project.DigitalSystem == null || OTCContext.Project.DigitalSystem.Status != SystemStatus.Connected);
         cmdSystemConnect.Enabled = (OTCContext.Project.DigitalSystem != null && OTCContext.Project.DigitalSystem.Status != SystemStatus.Connected);
         cmdSystemDisconnect.Enabled = !cmdSystemConnect.Enabled;

         // Update the switchboard status

         foreach (XtraTabPage page in tabPanels.TabPages)
         {
            ctrl = page.Controls[0] as SwitchboardCommandControl;
            if (ctrl != null)
            {
               ctrl.Enabled = rpgControl.Enabled;
               page.Cursor = (ctrl.Enabled ? Cursors.Default : Cursors.No);
            }
         }
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
         else if (e.CommandReceived is IAccessoryOperation)
         {
            this.AccessoryOperationCommandReceived((IAccessoryOperation)e.CommandReceived);
         }
         else if (e.CommandReceived is IEmergencyOff)
         {
            this.EmergencyStopCommandReceived();
         }
         else if (e.CommandReceived is IEmergencyStop)
         {
            this.EmergencyStopCommandReceived();
         }
         else if (e.CommandReceived is IResumeOperations)
         {
            this.ResumeOperationsCommandReceived();
         }
         else if (e.CommandReceived is ISystemInformation)
         {
            this.SystemInformationCommandReceived((ISystemInformation)e.CommandReceived);
         }
         else if (e.CommandReceived is IInterfaceInformation)
         {
            this.InterfaceInformationCommandReceived((IInterfaceInformation)e.CommandReceived);
         }
      }

      void spcPanel_SensorManuallyActivated(object sender, CellClickEventArgs e, bool status)
      {
         SwitchboardCommandControl panel = sender as SwitchboardCommandControl;
         if (panel == null)
         {
            return;
         }

         // Force the sensor to changing its status
         panel.SetSensorStatus(e.Coordinates, status);
      }

      private void spcPanel_BlockAssignTrain(object sender, Element e)
      {
         Train train = StudioContext.Find.Train("Assign train to block");
         if (train != null) e.Train = train;
      }

      private void spcPanel_BlockUnassignTrain(object sender, Element e)
      {
         e.Train = null;
      }

      #endregion

      #region Static Members

      public static void ViewAddCommandPanel(Switchboard panel,
                                             XtraTabControl tabControl,
                                             XtraTabPage tabPage,
                                             SwitchboardCommandControl.BlockAssignTrainEventHandler blockAssignTrainEvent,
                                             SwitchboardCommandControl.BlockUnassignTrainEventHandler blockUnassignTrainEvent)
      {
         XtraTabPage tabPanel;

         tabControl.SuspendLayout();

         // Generate the grid
         SwitchboardCommandControl spcPanel = new SwitchboardCommandControl(panel);
         spcPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         spcPanel.Location = new System.Drawing.Point(5, 5);
         spcPanel.Name = "grdPanel" + panel.ID;
         spcPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

         // Subscribe required events
         spcPanel.BlockAssignTrain += blockAssignTrainEvent;
         spcPanel.BlockUnassignTrain += blockUnassignTrainEvent;
         // if (sensorManuallyActivatedEvent != null) spcPanel.SensorManuallyActivated += sensorManuallyActivatedEvent;

         // Generate the tab page
         if (tabPage == null)
         {
            tabPanel = new XtraTabPage();

            // tabPanel.Controls.Add(grdPanel);
            tabPanel.Name = "tabPanel" + panel.ID;
            tabPanel.Padding = new System.Windows.Forms.Padding(5);
            tabPanel.Text = panel.Name;
            tabPanel.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_PANEL_16;
            tabPanel.Tag = panel;
            tabPanel.Controls.Add(spcPanel);
         }
         else
         {
            // Clear all page contents
            tabPage.Controls.Clear();

            tabPanel = tabPage;
         }

         tabControl.TabPages.Add(tabPanel);

         // Select the new panel
         tabControl.SelectedTabPage = tabPanel;

         tabControl.ResumeLayout(false);
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Create and paint all panels.
      /// </summary>
      private void ShowPanels()
      {
         Cursor.Current = Cursors.WaitCursor;

         // Clear all previous panels
         tabPanels.TabPages.Clear();

         // Draw all panels
         foreach (Switchboard panel in OTCContext.Project.Switchboards)
         {
            ControlModule.ViewAddCommandPanel(panel,
                                              this.tabPanels,
                                              null,
                                              // spcPanel_SensorManuallyActivated,
                                              spcPanel_BlockAssignTrain,
                                              spcPanel_BlockUnassignTrain);
         }

         // Select the first panel
         if (tabPanels.TabPages.Count > 0)
         {
            tabPanels.SelectedTabPage = tabPanels.TabPages[0];
         }

         Cursor.Current = Cursors.Default;
      }

      private void AccessoryOperationCommandReceived(IAccessoryOperation command)
      {
         Element element = Element.GetByConnectionAddress(command.Address);
         if (element != null)
         {
            element.SetAccessoryStatus(command.Status);

            StudioContext.LogInformation("Accessory {0:D4} changed to status #{1}", command.Address, command.Status);
         }
         else
            StudioContext.LogWarning("Accessory {0:D4} changed to status #{1}: Address not used in current layout", command.Address, command.Status);
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
