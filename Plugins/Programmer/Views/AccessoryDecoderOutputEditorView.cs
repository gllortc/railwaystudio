using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Rwm.Otc;
using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class AccessoryDecoderOutputEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public AccessoryDecoderOutputEditorView(AccessoryDecoderOutput output)
      {
         InitializeComponent();
         MapModelToView(output);
      }

      #endregion

      #region Properties

      internal AccessoryDecoderOutput Output { get; private set; }

      #endregion

      #region Event Handlers

      private void CboMode_EditValueChanged(object sender, EventArgs e)
      {
         lblParameterUnits1.Text = lblParameterUnits2.Text = lblParameterUnits3.Text = string.Empty;
         lblParameter1.Visible = spnParameter1.Visible = lblParameterUnits1.Visible = false;
         lblParameter2.Visible = spnParameter2.Visible = lblParameterUnits2.Visible = false;
         lblParameter3.Visible = spnParameter3.Visible = lblParameterUnits3.Visible = false;

         if (cboMode.SelectedItem is ImageComboBoxItem item)
         {
            switch ((AccessoryDecoderOutput.OutputMode)item.Value)
            {
               case AccessoryDecoderOutput.OutputMode.OneShot:
                  lblParameter1.Text = "Duration";
                  lblParameterUnits1.Text = "milliseconds";
                  lblParameter1.Visible = spnParameter1.Visible = lblParameterUnits1.Visible = true;
                  break;

               case AccessoryDecoderOutput.OutputMode.Continuous:
                  break;

               case AccessoryDecoderOutput.OutputMode.Flasher:
                  lblParameter1.Text = "Duration on";
                  lblParameter2.Text = "Duration off";
                  lblParameterUnits1.Text = "milliseconds";
                  lblParameterUnits2.Text = "milliseconds";
                  lblParameter1.Visible = spnParameter1.Visible = lblParameterUnits1.Visible = true;
                  lblParameter2.Visible = spnParameter2.Visible = lblParameterUnits2.Visible = true;
                  break;

               case AccessoryDecoderOutput.OutputMode.ServoControl:
                  lblParameter1.Text = "Position A";
                  lblParameter2.Text = "Position B";
                  lblParameter3.Text = "Speed";
                  lblParameter1.Visible = spnParameter1.Visible = lblParameterUnits1.Visible = true;
                  lblParameter2.Visible = spnParameter2.Visible = lblParameterUnits2.Visible = true;
                  lblParameter3.Visible = spnParameter3.Visible = lblParameterUnits3.Visible = true;
                  break;
            }
         }
      }

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      private void CmdOK_Click(object sender, EventArgs e)
      {
         if (!this.MapViewToModel()) return;

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      #endregion

      #region Private Members

      private void MapModelToView(AccessoryDecoderOutput output)
      {
         this.Output = output;

         spnParameter1.EditValue = 0;
         spnParameter1.EditValue = 0;
         spnParameter1.EditValue = 0;
         cmdDisconnect.Enabled = (this.Output.AccessoryConnection != null);
         spnAddress.Properties.Mask.EditMask = "4D";
         spnAddress.Properties.MaxValue = OTCContext.Project.DigitalSystem.AccessoryAddressRange.Maximum;

         spnAddress.EditValue = this.Output.Address;
         this.SetOutputMode(this.Output.Mode);
         spnParameter1.EditValue = this.Output.DurationA;
         spnParameter2.EditValue = this.Output.DurationB;
         spnParameter3.EditValue = this.Output.ServoSpeed;

         if (this.Output.AccessoryConnection != null)
         {
            lblConnectionElement.Text = this.Output.AccessoryConnection.Element.DisplayName;
            lblConnectionInputElement.Text = this.Output.AccessoryConnection.ElementPinIndex.ToString();
         }
      }

      private bool MapViewToModel()
      {
         if (cboMode.SelectedItem == null)
         {
            MessageBox.Show("You must select the operation mode for the current decoder output.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboMode.Focus();
            return false;
         }

         this.Output.Address = (int)spnAddress.EditValue;
         this.Output.Mode = (AccessoryDecoderOutput.OutputMode)(cboMode.SelectedItem as ImageComboBoxItem).Value;
         this.Output.DurationA = (int)spnParameter1.EditValue;
         this.Output.DurationB = (int)spnParameter2.EditValue;
         this.Output.ServoSpeed = (int)spnParameter3.EditValue;

         return true;
      }

      private void SetOutputMode(AccessoryDecoderOutput.OutputMode mode)
      {
         cboMode.Properties.Items.Clear();
         foreach (AccessoryDecoderOutput.OutputMode outmode in Enum.GetValues(typeof(AccessoryDecoderOutput.OutputMode)))
         {
            ImageComboBoxItem item = new ImageComboBoxItem();
            item.Description = outmode.ToString();
            item.Value = outmode;
            item.ImageIndex = cboMode.Properties.Items.Count;

            cboMode.Properties.Items.Add(item);

            if (outmode == mode)
               cboMode.SelectedItem = item;
         }

         // Force to detect the changes
         // CboMode_EditValueChanged(cboMode, new EventArgs());
      }

      #endregion

   }
}
