using Rwm.Otc.Layout;
using System;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class SwitchboardEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public SwitchboardEditorView()
      {
         InitializeComponent();

         this.Switchboard = new Switchboard();
      }

      public SwitchboardEditorView(Switchboard panel)
      {
         InitializeComponent();

         this.Switchboard = panel;

         if (panel != null)
         {
            txtName.Text = this.Switchboard.Name;
            txtNotes.Text = this.Switchboard.Description;
            txtWidth.Value = this.Switchboard.Width;
            txtHeight.Value = this.Switchboard.Height;
         }
      }

      #endregion

      #region Properties

      internal Switchboard Switchboard { get; private set; }

      #endregion

      #region Event Handlers

      private void FrmPanelEditor_Activated(object sender, EventArgs e)
      {
         txtName.SelectAll();
         txtName.Focus();
      }

      private void cmdOk_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must provide a valid name for the switchboard panel.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         else if ((int)txtWidth.Value <= 0)
         {
            MessageBox.Show("The number of columns for the switchboard panel must be 1 or greater.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         else if ((int)txtHeight.Value <= 0)
         {
            MessageBox.Show("The number of rows for the switchboard panel must be 1 or greater.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            Cursor.Current = Cursors.WaitCursor;

            this.Switchboard.Name = txtName.Text;
            this.Switchboard.Description = txtNotes.Text;
            this.Switchboard.Width = (int)txtWidth.Value;
            this.Switchboard.Height = (int)txtHeight.Value;

            Switchboard.Save(this.Switchboard);

            this.DialogResult = DialogResult.OK;
            this.Close();
         }
         catch (Exception ex)
         {
            Cursor.Current = Cursors.Default;

            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            Cursor.Current = Cursors.Default;
         }
      }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      #endregion

   }
}