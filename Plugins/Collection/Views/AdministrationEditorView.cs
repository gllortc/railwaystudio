using Rwm.Otc.TrainControl;
using System;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Collection.Views
{
   public partial class AdministrationEditorView : DevExpress.XtraEditors.XtraForm
   {
      public AdministrationEditorView()
      {
         InitializeComponent();

         this.Administration = new Administration();
      }

      public AdministrationEditorView(Administration admin)
      {
         InitializeComponent();

         this.Administration = admin;

         txtName.Text = this.Administration.Name;
         txtDescription.Text = this.Administration.Description;
         txtUrl.Text = this.Administration.URL;
      }

      public Administration Administration { get; private set; }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.Close();
      }

      private void cmdAccept_Click(object sender, EventArgs e)
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
            Administration.Save(this.Administration);

            //if (this.Administration.ID <= 0)
            //{
            //   OTCContext.Project.TrainManager.AdministrationDAO.Add(this.Administration);
            //}
            //else
            //{
            //   OTCContext.Project.TrainManager.AdministrationDAO.Update(this.Administration);
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