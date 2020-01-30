using Rwm.Otc;
using System;
using System.Windows.Forms;

namespace Rwm.Studio.Views
{
   public partial class FrmProjectEditor : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="FrmProjectEditor"/>.
      /// </summary>
      /// <param name="settings">The current application settings.</param>
      public FrmProjectEditor()
      {
         InitializeComponent();
      }

      #endregion

      #region Event Handlers

      private void FrmProjectEditor_Activated(object sender, EventArgs e)
      {
         txtName.SelectAll();
         txtName.Focus();
      }

      private void cmdAccept_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must provide a valid name for the new project.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return;
         }

         try
         {
            SaveFileDialog form = new SaveFileDialog();
            form.Filter = "OTC projects|*.otc|All files|*.*";

            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
               OTCContext.CreateProject(form.FileName,
                                        txtName.Text.Trim(),
                                        txtDescription.Text.Trim(),
                                        txtVersion.Text.Trim());
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR creating new project:" + Environment.NewLine + Environment.NewLine + ex.Message, 
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.Close();
      }

      #endregion

   }
}