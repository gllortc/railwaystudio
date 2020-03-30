using System;
using System.Windows.Forms;
using Rwm.Otc.Trains;

namespace Rwm.Studio.Plugins.Collection.Views
{
   public partial class CategoryEditorView : DevExpress.XtraEditors.XtraForm
   {
      public CategoryEditorView()
      {
         InitializeComponent();

         this.Category = new Category();
      }

      public CategoryEditorView(Category category)
      {
         InitializeComponent();

         this.Category = category;

         txtName.Text = this.Category.Name;
         chkMaintenance.Checked = this.Category.HaveMaintenance;
      }

      public Category Category { get; private set; }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.Close();
      }

      private void cmdAccept_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must provide a valid name for the scale.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.SelectAll();
            txtName.Focus();
            return;
         }

         this.Category.Name = txtName.Text.Trim();
         this.Category.HaveMaintenance = chkMaintenance.Checked;

         try
         {
            Category.Save(this.Category);

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