using Rwm.Otc;
using Rwm.Otc.Layout;
using System;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class AreaEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public AreaEditorView()
      {
         InitializeComponent();

         this.MapModelToView(new Section(OTCContext.Project));
      }

      public AreaEditorView(Section section)
      {
         InitializeComponent();

         this.MapModelToView(section);
      }

      #endregion

      #region Properties

      internal Section Section { get; private set; }

      #endregion

      #region Event Handlers

      private void FrmPanelEditor_Activated(object sender, EventArgs e)
      {
         txtName.SelectAll();
         txtName.Focus();
      }

      private void CmdOk_Click(object sender, EventArgs e)
      {
         try
         {
            if (!this.MapViewToModel()) return;

            Cursor.Current = Cursors.WaitCursor;

            Section.Save(this.Section);

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

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Private Members

      private void MapModelToView(Section section)
      {
         this.Section = section;

         txtName.Text = this.Section.Name;
         txtDescription.Text = this.Section.Description;
         txtAccStartAddr.Value = this.Section.AccessoryStartAddress;
         txtAccEndAddr.Value = this.Section.AccessoryEndAddress;
         txtFbStartAddr.Value = this.Section.FeedbackStartAddress;
         txtFbEndAddr.Value = this.Section.FeedbackEndAddress;
         picSchema.Image = this.Section.Picture;
      }

      private bool MapViewToModel()
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            tabArea.SelectedTabPage = tabAreaGeneral;
            txtName.SelectAll();
            txtName.Focus();

            MessageBox.Show("You must provide a valid name for the layout area.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
         }
         else if ((int)txtAccStartAddr.Value > 0 && (int)txtAccStartAddr.Value > (int)txtAccEndAddr.Value)
         {
            tabArea.SelectedTabPage = tabAreaDigital;
            txtAccStartAddr.SelectAll();
            txtAccStartAddr.Focus();

            MessageBox.Show("The allowed accessory address range is not correctly specified.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
         }
         else if ((int)txtFbStartAddr.Value > 0 && (int)txtFbStartAddr.Value > (int)txtFbEndAddr.Value)
         {
            tabArea.SelectedTabPage = tabAreaDigital;
            txtFbStartAddr.SelectAll();
            txtFbStartAddr.Focus();

            MessageBox.Show("The allowed feedback address range is not correctly specified.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
         }

         this.Section.Name = txtName.Text;
         this.Section.Description = txtDescription.Text;
         this.Section.AccessoryStartAddress = (int)txtAccStartAddr.Value;
         this.Section.AccessoryEndAddress = (int)txtAccEndAddr.Value;
         this.Section.FeedbackStartAddress = (int)txtFbStartAddr.Value;
         this.Section.FeedbackEndAddress = (int)txtFbEndAddr.Value;
         this.Section.Picture = picSchema.Image;

         return true;
      }

      #endregion

   }
}