using System;
using System.Text;
using System.Windows.Forms;
using Rwm.Otc;
using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class FeedbackEncoderWizardView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="FeedbackEncoderWizardView"/>.
      /// </summary>
      public FeedbackEncoderWizardView()
      {
         InitializeComponent();

         spnOutputs.Properties.MinValue = OTCContext.Project.DigitalSystem.PointAddressesByFeedbackAddress;
         spnOutputs.Properties.MaxValue = OTCContext.Project.DigitalSystem.FeedbackAddressRange.Maximum * OTCContext.Project.DigitalSystem.PointAddressesByFeedbackAddress;
         spnOutputs.Properties.Increment = OTCContext.Project.DigitalSystem.PointAddressesByFeedbackAddress;
      }

      #endregion

      #region Properties

      private int EncoderInputs { get; set; } = 0;

      private int StartAddress { get; set; } = 0;

      internal FeedbackEncoder Encoder { get; private set; } = null;

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
            this.EncoderInputs = Convert.ToInt32(rdgOutputs.EditValue);
            if (this.EncoderInputs <= 0 && (int)spnOutputs.Value <= 0) // 0 means custom number
            {
               MessageBox.Show("Feedback encoders must have at least 1 input.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
               e.Handled = true;
            }
            else if (Convert.ToInt32(rdgOutputs.EditValue) <= 0)
            {
               this.EncoderInputs = (int)spnOutputs.Value;
            }
         }
         else if (e.Page == wzpAddress)
         {
            this.StartAddress = Convert.ToInt32(spnAddress.EditValue);
            if (this.StartAddress == 1 && (int)spnAddress.Value <= 0)
            {
               MessageBox.Show(string.Format("Encoder inputs must start at least at address {0:0000}.", OTCContext.Project.DigitalSystem.AccessoryAddressRange.Minimum),
                               Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
               e.Handled = true;
            }
            else
            {
               lblSummary.Text = this.GetFinishSummary();
            }
         }
      }

      private void WizardControl_FinishClick(object sender, System.ComponentModel.CancelEventArgs e)
      {
         int address = this.StartAddress;
         int pointAddress = 1;

         this.Encoder = new FeedbackEncoder(this.EncoderInputs);

         for (int i = 0; i < this.EncoderInputs; i++)
         {
            this.Encoder.Inputs[i].Address = address;
            this.Encoder.Inputs[i].PointAddress = pointAddress;
            this.Encoder.Inputs[i].DelayTime = (int)spnDelay.Value;

            pointAddress++;
            if (pointAddress > OTCContext.Project.DigitalSystem.PointAddressesByFeedbackAddress)
            {
               pointAddress = 1;
               address++;
            }
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

         sb.AppendLine("These are the properties of the new feedback encoder:<br>");
         sb.AppendLine("<br>");

         sb.AppendLine(string.Format("Number of inputs: <b>{0}</b>", this.EncoderInputs));
         if (this.StartAddress <= 0)
            sb.AppendLine("Start address: <b>no address will be set</b>");
         else
            sb.AppendLine(string.Format("Address: from <b>{0:0000}</b> to <b>{1:0000}</b>", this.StartAddress, this.StartAddress + ((this.EncoderInputs / 4) - 1)));
         sb.AppendLine(string.Format("Point groups: <b>{0}</b> group(s) of <b>{1}</b> input(s)", (this.EncoderInputs / 4), OTCContext.Project.DigitalSystem.PointAddressesByFeedbackAddress));

         sb.AppendLine("<br>");
         sb.AppendLine("Press <b><i>Finish</i></b> button to create the new decoder and open it in the decoder editor");

         return sb.ToString();
      }

      #endregion

   }
}