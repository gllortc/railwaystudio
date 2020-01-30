using Rwm.Otc;
using Rwm.Otc.TrainControl;
using System;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Collection.Views
{
   public partial class StoreEditorView : DevExpress.XtraEditors.XtraForm
   {
      public StoreEditorView()
      {
         InitializeComponent();

         this.Store = new Store();
      }

      public StoreEditorView(Store store)
      {
         InitializeComponent();

         this.Store = store;

         txtName.Text = this.Store.Name;
         txtAddress.Text = this.Store.Address;
         txtPhone.Text = this.Store.Phone;
         txtMail.Text = this.Store.Mail;
         txtUrl.Text = this.Store.URL;
         txtNotes.Text = this.Store.Description;
      }

      public Store Store { get; private set; }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.Close();
      }

      private void cmdAccept_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must provide a valid name for the store.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.SelectAll();
            txtName.Focus();
            return;
         }

         this.Store.Name = txtName.Text.Trim();
         this.Store.Address = txtAddress.Text.Trim();
         this.Store.Phone = txtPhone.Text.Trim();
         this.Store.Mail = txtMail.Text.Trim();
         this.Store.URL = txtUrl.Text.Trim();
         this.Store.Description = txtNotes.Text.Trim();

         try
         {
            Store.Save(this.Store);
            // OTCContext.Project.TrainManager.StoreDAO.Save(this.Store);

            //if (this.Store.ID <= 0)
            //{
            //   OTCContext.Project.TrainManager.StoreDAO.Add(this.Store);
            //}
            //else
            //{
            //   OTCContext.Project.TrainManager.StoreDAO.Update(this.Store);
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