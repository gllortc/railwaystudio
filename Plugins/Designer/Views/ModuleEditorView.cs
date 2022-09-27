using Rwm.Otc;
using Rwm.Otc.Layout;
using System;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class ModuleEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public ModuleEditorView()
      {
         InitializeComponent();

         this.MapModelToView(new Module(OTCContext.Project));
      }

      public ModuleEditorView(Module section)
      {
         InitializeComponent();

         this.MapModelToView(section);
      }

      #endregion

      #region Properties

      internal Module Module { get; private set; }

      #endregion

      #region Event Handlers

      private void FrmPanelEditor_Activated(object sender, EventArgs e)
      {
         txtName.SelectionStart = 0;
         txtName.SelectionLength = txtName.Text.Length;
         txtName.Focus();
      }

      private void CmdOk_Click(object sender, EventArgs e)
      {
         try
         {
            if (!this.MapViewToModel()) return;

            Cursor.Current = Cursors.WaitCursor;

            Module.Save(this.Module);

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

      private void MapModelToView(Module section)
      {
         this.Module = section;

         txtName.Text = this.Module.Name;
         txtDescription.Text = this.Module.Description;
         txtAccStartAddr.Value = this.Module.AccessoryStartAddress;
         txtAccEndAddr.Value = this.Module.AccessoryEndAddress;
         txtFbStartAddr.Value = this.Module.FeedbackStartAddress;
         txtFbEndAddr.Value = this.Module.FeedbackEndAddress;
         chkConnectionPowerBus.Checked = this.Module.ConnectedToPowerBus;
         chkConnectionControlBus.Checked = this.Module.ConnectedToControlBus;
         chkConnectionHandRegler.Checked = this.Module.ConnectedToCommandBus;
         picSchema.Image = this.Module.Picture;
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

         this.Module.Name = txtName.Text;
         this.Module.Description = txtDescription.Text;
         this.Module.AccessoryStartAddress = (int)txtAccStartAddr.Value;
         this.Module.AccessoryEndAddress = (int)txtAccEndAddr.Value;
         this.Module.FeedbackStartAddress = (int)txtFbStartAddr.Value;
         this.Module.FeedbackEndAddress = (int)txtFbEndAddr.Value;
         this.Module.ConnectedToPowerBus = chkConnectionPowerBus.Checked;
         this.Module.ConnectedToControlBus = chkConnectionControlBus.Checked;
         this.Module.ConnectedToCommandBus = chkConnectionHandRegler.Checked;
         this.Module.Picture = picSchema.Image;

         return true;
      }

      #endregion

   }
}