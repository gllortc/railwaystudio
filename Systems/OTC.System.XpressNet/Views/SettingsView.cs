using System;
using System.IO.Ports;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
//using RJCP.IO.Ports;

namespace Rwm.OTC.Systems.XpressNet.Views
{
   public partial class SettingsView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public SettingsView(LenzXpressNet system)
      {
         InitializeComponent();

         this.DigitalSystem = system;

         this.InitializeControls();
         this.InitializeData();
      }

      #endregion

      #region Properties

      public LenzXpressNet DigitalSystem { get; private set; }

      #endregion

      #region Event Handlers

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      private void CmdOK_Click(object sender, EventArgs e)
      {
         this.DigitalSystem.PortName = (string)cboPort.EditValue;
         this.DigitalSystem.BaudRate = (int)cboBaudRate.EditValue;
         this.DigitalSystem.Parity = (Parity)cboParity.EditValue;
         this.DigitalSystem.StopBits = (StopBits)cboStopBits.EditValue;
         this.DigitalSystem.DataBits = (int)(decimal)spnDataBits.EditValue;
         this.DigitalSystem.Handshake = (Handshake)cboHandshake.EditValue;
         this.DigitalSystem.ReadWriteTimeout = (int)(decimal)spnRWTimeout.EditValue;
         this.DigitalSystem.KeepaliveSignalInterval = (int)(decimal)spnKeepaliveInterval.EditValue;
         this.DigitalSystem.DebugMode = chkDebugMode.Checked;

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      #endregion

      #region Private Members

      private void InitializeControls()
      {
         ImageComboBoxItem portItem;

         // Fill available port list
         cboPort.Properties.Items.Clear();
         for (int i = 1; i < 256; i++)
         {
            portItem = new ImageComboBoxItem();
            portItem.Description = "COM" + i;
            portItem.Value = "COM" + i;
            portItem.ImageIndex = 0;
            cboPort.Properties.Items.Add(portItem);
         }

         // Fill speed list
         cboBaudRate.Properties.Items.Clear();
         cboBaudRate.Properties.Items.Add(9600);
         cboBaudRate.Properties.Items.Add(38400);
         cboBaudRate.Properties.Items.Add(19200);
         cboBaudRate.Properties.Items.Add(57600);
         cboBaudRate.Properties.Items.Add(115200);

         cboParity.Properties.Items.Clear();
         foreach (var parity in Enum.GetValues(typeof(Parity)))
         {
            cboParity.Properties.Items.Add(parity);
         }

         cboStopBits.Properties.Items.Clear();
         foreach (var sb in Enum.GetValues(typeof(StopBits)))
         {
            cboStopBits.Properties.Items.Add(sb);
         }

         cboHandshake.Properties.Items.Clear();
         foreach (var sb in Enum.GetValues(typeof(Handshake)))
         {
            cboHandshake.Properties.Items.Add(sb);
         }
      }

      private void InitializeData()
      {
         cboPort.EditValue = this.DigitalSystem.PortName;
         cboBaudRate.EditValue = this.DigitalSystem.BaudRate;
         cboParity.EditValue = this.DigitalSystem.Parity;
         cboStopBits.EditValue = this.DigitalSystem.StopBits;
         spnDataBits.EditValue = this.DigitalSystem.DataBits;
         cboHandshake.EditValue = this.DigitalSystem.Handshake;
         spnRWTimeout.EditValue = this.DigitalSystem.ReadWriteTimeout;
         spnKeepaliveInterval.EditValue = this.DigitalSystem.KeepaliveSignalInterval;
         chkDebugMode.Checked = this.DigitalSystem.DebugMode;
      }

      #endregion

   }
}
