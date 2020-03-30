using System;
using System.Windows.Forms;
using Rwm.Otc.Trains;

namespace Rwm.Studio.Plugins.Collection.Views
{
   public partial class AdministrationEditorView : DevExpress.XtraEditors.XtraForm
   {
      public AdministrationEditorView()
      {
         InitializeComponent();

         this.Administration = new Company();
      }

      public AdministrationEditorView(Company admin)
      {
         InitializeComponent();

         this.Administration = admin;

         txtName.Text = this.Administration.Name;
         txtDescription.Text = this.Administration.Description;
         txtUrl.Text = this.Administration.URL;
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

         try
         {
            Company.Save(this.Administration);

            //if (this.Company.ID <= 0)
            //{
            //   OTCContext.Project.TrainManager.AdministrationDAO.Add(this.Company);
            //}
            //else
            //{
            //   OTCContext.Project.TrainManager.AdministrationDAO.Update(this.Company);
            //}

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