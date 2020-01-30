using Rwm.Otc;
using System;
using System.Windows.Forms;

namespace RailwayStudio.Common.Views
{
   public partial class ProjectEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ProjectEditorView"/>.
      /// </summary>
      /// <param name="settings">The current application settings.</param>
      public ProjectEditorView()
      {
         InitializeComponent();

         if (OTCContext.Project != null)
         {
            txtName.Text = OTCContext.Project.Name;
            txtDescription.Text = OTCContext.Project.Description;
            txtVersion.Text = OTCContext.Project.Version;
         }
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
               if (OTCContext.Project == null)
               {
                  // Create new project file
                  OTCContext.CreateProject(form.FileName, txtName.Text, txtDescription.Text, txtVersion.Text);
               }
               else
               {
                  // Create new project file
                  OTCContext.UpdateProjectData();
               }
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