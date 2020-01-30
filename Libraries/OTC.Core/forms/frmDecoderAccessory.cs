using System;
using System.Windows.Forms;
using otc.panels;

namespace otc.forms
{
   public partial class frmDecoderAccessory : Form
   {
      OTCAccessoryDecoder _decoder = null;

      public frmDecoderAccessory()
      {
         InitializeComponent();
      }

      public frmDecoderAccessory(OTCAccessoryDecoder decoder)
      {
         InitializeComponent();
         _decoder = decoder;
      }

      public OTCAccessoryDecoder Decoder
      {
         get { return _decoder; }
         set { _decoder = value; }
      }

      private void frmDecoderAccessory_Load(object sender, EventArgs e)
      {
         this.Text = Application.ProductName;

         cboType.Items.Clear();
         cboType.Items.Add(new otc.forms.controls.ComboBoxItem(OTCAccessoryDecoder.GetTypeName(AccessoryDecoderType.Unknown), (int)AccessoryDecoderType.Unknown));
         cboType.Items.Add(new otc.forms.controls.ComboBoxItem(OTCAccessoryDecoder.GetTypeName(AccessoryDecoderType.ImpulseOutput), (int)AccessoryDecoderType.ImpulseOutput));
         cboType.Items.Add(new otc.forms.controls.ComboBoxItem(OTCAccessoryDecoder.GetTypeName(AccessoryDecoderType.FixedOutput), (int)AccessoryDecoderType.FixedOutput));
         cboType.Items.Add(new otc.forms.controls.ComboBoxItem(OTCAccessoryDecoder.GetTypeName(AccessoryDecoderType.Mixed), (int)AccessoryDecoderType.Mixed));
         cboType.Items.Add(new otc.forms.controls.ComboBoxItem(OTCAccessoryDecoder.GetTypeName(AccessoryDecoderType.ServoOutput), (int)AccessoryDecoderType.ServoOutput));
         cboType.SelectedIndex = 0;

         if (_decoder != null)
         {
            txtName.Text = _decoder.Name;
            cboManufacturer.Text = _decoder.Manufacturer;
            txtModel.Text = _decoder.Model;
            txtOutputs.Value = _decoder.Outputs;
            txtStartAddress.Value = _decoder.StartAddress;
            txtNotes.Text = _decoder.Notes;
            otc.forms.controls.ComboBoxItem.SetComboItem(cboType, (int)_decoder.Type);
         }
      }

      private void btnAccept_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(txtName.Text.Trim()))
         {
            MessageBox.Show(this, "Debe proporcionar un nombre único para el descodificador.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            txtName.Focus();
            return;
         }
         else if (cboType.SelectedItem == null)
         {
            MessageBox.Show(this, "Debe seleccionar el tipo de descodificador.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            cboType.Focus();
            return;
         }

         if (_decoder == null) _decoder = new OTCAccessoryDecoder();

         // Recupera los datos
         _decoder.Name = txtName.Text.Trim();
         _decoder.Type = (AccessoryDecoderType)((otc.forms.controls.ComboBoxItem)cboType.SelectedItem).Value;
         _decoder.Manufacturer = cboManufacturer.Text;
         _decoder.Model = txtModel.Text;
         _decoder.Outputs = (int)txtOutputs.Value;
         _decoder.StartAddress = (int)txtStartAddress.Value;
         _decoder.Notes = txtNotes.Text;

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }
   }
}
