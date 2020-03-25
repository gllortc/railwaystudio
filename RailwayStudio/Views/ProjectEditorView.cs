using System;
using System.IO;
using System.Windows.Forms;
using Rwm.Otc;

namespace Rwm.Studio.Views
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

         this.Project = new Project();

         this.MapInstanceToView();
      }

      /// <summary>
      /// Returns a new instance of <see cref="ProjectEditorView"/>.
      /// </summary>
      /// <param name="settings">The current application settings.</param>
      public ProjectEditorView(Project project)
      {
         InitializeComponent();

         this.Project = project;

         this.MapInstanceToView();
      }

      #endregion

      #region Properties

      internal Project Project { get; private set; }

      #endregion

      #region Event Handlers

      private void FrmProjectEditor_Activated(object sender, EventArgs e)
      {
         txtName.SelectAll();
         txtName.Focus();
      }

      private void CmdAccept_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must provide a valid name for the project.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return;
         }

         try
         {
            this.MapViewToInstance();

            if (!this.Project.IsNew)
            {
               Project.Save(this.Project);

               this.DialogResult = DialogResult.OK;
               this.Close();
            }
            else
            {
               SaveFileDialog form = new SaveFileDialog();
               form.Filter = "OTC projects|*.otc|All files|*.*";
               if (form.ShowDialog(this) == DialogResult.OK)
               {
                  OTCContext.CreateProject(form.FileName, this.Project);

                  this.DialogResult = DialogResult.OK;
                  this.Close();
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Private Members

      private void MapInstanceToView()
      {
         txtName.Text = this.Project.Name;
         txtDescription.Text = this.Project.Description;
         txtVersion.Text = this.Project.Version;

         if (!this.Project.IsNew)
         {
            FileInfo fileInfo = new FileInfo(this.Project.Filename);
            lblFilename.Text = fileInfo.Name;
            lblPath.Text = fileInfo.DirectoryName;
            lblSize.Text = fileInfo.Length + " bytes";
            lblCreated.Text = fileInfo.CreationTime.ToString("dd/MM/yyyy HH:mm:ss");
            lblLastAccess.Text = fileInfo.LastAccessTime.ToString("dd/MM/yyyy HH:mm:ss");
         }
         else
         {
            lblFilename.Text = "-";
            lblPath.Text = "-";
            lblSize.Text = "-";
            lblCreated.Text = "-";
            lblLastAccess.Text = "-";
         }
      }

      private void MapViewToInstance()
      {
         this.Project.Name = txtName.Text.Trim();
         this.Project.Description = txtDescription.Text.Trim();
         this.Project.Version = txtVersion.Text.Trim();
      }

      #endregion

   }
}