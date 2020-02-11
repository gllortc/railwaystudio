using System;
using System.Windows.Forms;
using DevExpress.XtraTab;
using RailwayStudio.Common;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.Systems;
using Rwm.Otc.UI;
using Rwm.Otc.UI.Controls;
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

         if (!chkSystemConnect.Checked)
         {
            OTCContext.Project.DigitalSystem?.Disconnect();
         }
         else
         {
            try
            {
               OTCContext.Project.DigitalSystem?.Connect();
            }
            catch (Exception ex)
            {
               Cursor.Current = Cursors.Default;

               MessageBox.Show("ERROR connecting to digital system:" + Environment.NewLine + Environment.NewLine + ex.Message,
                               Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }

         this.RefreshStatus();

         Cursor.Current = Cursors.Default;
      }

      /// <summary>
      /// Show the selected system settings dialogue.
      /// </summary>
      internal void SystemSettings()
      {
         OTCContext.Project.DigitalSystem.ShowConfig(OTCContext.Settings);
      }

      /// <summary>
      /// Show the selected system settings dialogue.
      /// </summary>
      internal void EmergencyStop()
      {
         OTCContext.Project.DigitalSystem.SetEmergencyStop(cmdCtrlEmergencyStop.Down);
      }

      /// <summary>
      /// Update screen information
      /// </summary>
      public void RefreshStatus()
      {
         SwitchboardCommandControl ctrl = null;

         // Show theme information
         bsiTheme.Caption = (OTCContext.Project.Theme == null ? "[No theme]" : OTCContext.Project.Theme.Name);
         bsiTheme.Glyph = (OTCContext.Project.Theme == null ? Control.Properties.Resources.ICO_THEME_UNSELECTED_16 : Control.Properties.Resources.ICO_THEME_16);

         // Show system information
         bsiSystem.Caption = (OTCContext.Project.DigitalSystem == null ? "[No system]" : OTCContext.Project.DigitalSystem.Name);
         bsiSystem.Glyph = (OTCContext.Project.DigitalSystem == null ? Control.Properties.Resources.ICO_SYSTEMS_UNSELECTED_16 : Control.Properties.Resources.ICO_SYSTEM_16);

         // Update system controls
         chkSystemConnect.Enabled = (OTCContext.Project.DigitalSystem != null);
         cmdSystemSettings.Enabled = (OTCContext.Project.DigitalSystem != null);
         rpgControl.Enabled = !(OTCContext.Project.DigitalSystem == null || OTCContext.Project.DigitalSystem.Status != SystemStatus.Connected);

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
         Rwm.Otc.TrainControl.Train train = StudioContext.Find.Train("Assign train to block");
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

      #endregion

   }
}
