using System;
using System.Windows.Forms;
using Rwm.Otc.Trains;

namespace Rwm.Studio.Plugins.Collection.Views
{
   public partial class ManufacturerEditorView : DevExpress.XtraEditors.XtraForm
   {
      public ManufacturerEditorView()
      {
         InitializeComponent();

         this.Manufacturer = new Manufacturer();
      }

      public ManufacturerEditorView(Manufacturer manufacturer)
      {
         InitializeComponent();

         this.Manufacturer = manufacturer;

         txtName.Text = this.Manufacturer.Name;
         txtAddress.Text = this.Manufacturer.Address;
         txtUrl.Text = this.Manufacturer.URL;
         txtNotes.Text = this.Manufacturer.Description;
      }

      public Manufacturer Manufacturer { get; private set; }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.Close();
      }

      private void cmdAccept_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must provide a valid name for the manufacturer.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.SelectAll();
            txtName.Focus();
            return;
         }

         this.Manufacturer.Name = txtName.Text.Trim();
         this.Manufacturer.Address = txtAddress.Text.Trim();
         this.Manufacturer.URL = txtUrl.Text.Trim();
         this.Manufacturer.Description = txtNotes.Text.Trim();

         try
         {
            Manufacturer.Save(this.Manufacturer);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR storing data:" + Environment.NewLine + Environment.NewLine + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
   }
}