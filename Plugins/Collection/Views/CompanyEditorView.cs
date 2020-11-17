using System;
using System.Windows.Forms;
using Rwm.Otc.Trains;

namespace Rwm.Studio.Plugins.Collection.Views
{
   public partial class CompanyEditorView : DevExpress.XtraEditors.XtraForm
   {
      public CompanyEditorView()
      {
         InitializeComponent();

         this.Administration = new Company();
      }

      public CompanyEditorView(Company admin)
      {
         InitializeComponent();

         this.Administration = admin;

         txtName.Text = this.Administration.Name;
         txtDescription.Text = this.Administration.Description;
         txtUrl.Text = this.Administration.URL;
         imgLogo.Image = this.Administration.LogoImage;
      }

      public Company Administration { get; private set; }

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.Close();
      }

      private void CmdAccept_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must provide a valid name for the administration.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.SelectAll();
            txtName.Focus();
            return;
         }

         this.Administration.Name = txtName.Text.Trim();
         this.Administration.Description = txtDescription.Text.Trim();
         this.Administration.URL = txtUrl.Text.Trim();
         this.Administration.LogoImage = imgLogo.Image;

         try
         {
            Company.Save(this.Administration);

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