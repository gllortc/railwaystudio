using System;
using System.Windows.Forms;
using Rwm.Otc;
using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class RouteEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public RouteEditorView()
      {
         this.SetData(new Route(OTCContext.Project));
      }

      public RouteEditorView(Route route)
      {
         this.SetData(route);
      }

      #endregion

      #region Properties

      public Route Route { get; private set; }

      #endregion

      #region Event Handlers

      private void RouteEditorView_Shown(object sender, EventArgs e)
      {
         txtName.SelectAll();
         txtName.Focus();
      }

      private void chkIsBlock_CheckedChanged(object sender, EventArgs e)
      {
         grpBlockConnections.Enabled = chkIsBlock.Checked;
         grpBlockBehaviour.Enabled = chkIsBlock.Checked;
      }

      private void CmdOk_Click(object sender, EventArgs e)
      {
         if (!this.GetData()) return;

         this.DialogResult = DialogResult.OK;
         return;
      }

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         return;
      }

      #endregion

      #region Methods

      private void SetData(Route route)
      {
         this.InitializeComponent();

         this.Route = route;

         txtName.Text = this.Route.Name;
         txtNotes.Text = this.Route.Description;
         spnSwitchTime.EditValue = this.Route.SwitchTime;
         chkIsBlock.Checked = this.Route.IsBlock;
         chkBidirectional.Checked = this.Route.IsBidirectionl;

      }

      private bool GetData()
      {
         if (string.IsNullOrEmpty(txtName.Text.Trim()))
         {
            MessageBox.Show("You must provide a valid name for the route.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return false;
         }

         this.Route.Name = txtName.Text;
         this.Route.Description = txtNotes.Text;
         this.Route.SwitchTime = (int)(decimal)spnSwitchTime.EditValue;
         this.Route.IsBlock = chkIsBlock.Checked;
         this.Route.IsBidirectionl = chkBidirectional.Checked;

         return true;
      }


      #endregion

   }
}
