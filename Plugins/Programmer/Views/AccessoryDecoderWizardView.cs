using System;
using System.Text;
using System.Windows.Forms;
using Rwm.Otc;
using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Designer.Views
{
   /// <summary>
   /// Wizard to helps creating and configuring a new instance to edit in the editor.
   /// </summary>
   public partial class AccessoryDecoderWizardView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="AccessoryDecoderWizardView"/>.
      /// </summary>
      public AccessoryDecoderWizardView()
      {
         InitializeComponent();
      }

      #endregion

      #region Properties

      private int DecoderOutputs { get; set; } = 0;

      private int StartAddress { get; set; } = 0;

      private AccessoryDecoderOutput.OutputMode OutputMode { get; set; } = AccessoryDecoderOutput.OutputMode.OneShot;

      internal AccessoryDecoder Decoder { get; private set; } = null;

      #endregion

      #region Event Handlers

      private void SpnOutputs_EditValueChanged(object sender, EventArgs e)
      {
         rdgOutputs.EditValue = 0;
      }

      private void RdgAddress_EditValueChanged(object sender, EventArgs e)
      {
         rdgAddress.EditValue = 1;
      }

      private void WizardControl_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
      {
         if (e.Page == wzpOutputs)
         {
            this.DecoderOutputs = Convert.ToInt32(rdgOutputs.EditValue);
            if (this.DecoderOutputs <= 0 && (int)spnOutputs.Value <= 0) // 0 means custom number
            {
               MessageBox.Show("Accessory decoders must have at least 1 output.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
               e.Handled = true;
            }
            else if (Convert.ToInt32(rdgOutputs.EditValue) <= 0)
            {
               this.DecoderOutputs = (int)spnOutputs.Value;
            }
         }
         else if (e.Page == wzpAddress)
         {
            this.StartAddress = Convert.ToInt32(spnAddress.EditValue);
            if (this.StartAddress == 1 && (int)spnAddress.Value <= 0)
            {
               MessageBox.Show(string.Format("Decoder outputs must start at least at address {0:0000}.", OTCContext.Project.DigitalSystem.AccessoryAddressRange.Minimum),
                               Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
               e.Handled = true;
            }
         }
         else if (e.Page == wzpMode)
         {
            if (rdoModeContinuous.Checked)
               this.OutputMode = AccessoryDecoderOutput.OutputMode.Continuous;
            else if (rdoModeOneShot.Checked)
               this.OutputMode = AccessoryDecoderOutput.OutputMode.OneShot;
            else if (rdoModeFlasher.Checked)
               this.OutputMode = AccessoryDecoderOutput.OutputMode.Flasher;
            else if (rdoModeServo.Checked)
               this.OutputMode = AccessoryDecoderOutput.OutputMode.ServoControl;

            lblSummary.Text = this.GetFinishSummary();
         }
      }

      private void WizardControl_FinishClick(object sender, System.ComponentModel.CancelEventArgs e)
      {
         this.Decoder = new AccessoryDecoder(this.DecoderOutputs);

         for (int i = 0; i < this.DecoderOutputs; i++)
         {
            if (this.StartAddress > 0)
               this.Decoder.Outputs[i].Address = this.StartAddress + i;
            else
               this.Decoder.Outputs[i].Address = 0;

            this.Decoder.Outputs[i].Mode = this.OutputMode;
            this.Decoder.Outputs[i].DurationB = 500;
         }

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void WizardControl_CancelClick(object sender, System.ComponentModel.CancelEventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Private Members

      private string GetFinishSummary()
      {
         StringBuilder sb = new StringBuilder();

         sb.AppendLine("These are the properties of the new accessory decoder:<br><br>");
         sb.AppendLine(string.Format("Number of outputs: <b>{0}</b>", this.DecoderOutputs));

         if (this.StartAddress <= 0)
            sb.AppendLine("Start address: <b>no address will be set</b>");
         else
            sb.AppendLine(string.Format("Address: from <b>{0:0000}</b> to <b>{1:0000}</b>", this.StartAddress, this.StartAddress + this.DecoderOutputs));

         sb.AppendLine(string.Format("Outputs mode: <b>{0}</b><br><br>", this.OutputMode.ToString()));

         sb.AppendLine("Press <b><i>Finish</i></b> button to create the new decoder and open it in the decoder editor");

         return sb.ToString();
      }

      #endregion

   }
}