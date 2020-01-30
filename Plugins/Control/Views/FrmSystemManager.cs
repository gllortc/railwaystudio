using RailwayStudio.Common;
using Rwm.Otc;
using System;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class FrmSystemManager : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public FrmSystemManager()
      {
         InitializeComponent();

         this.ListSystems();
      }

      #endregion

      #region Event Handlers

      private void grdSystemsView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_SYSTEM_16, e);
      }

      #endregion

      #region Private Members

      private void ListSystems()
      {
         try
         {
            grdSystems.BeginUpdate();
            grdSystems.DataSource = OTCContext.Project.SystemManager.Find();
            grdSystemsView.Columns[0].Visible = false;
            grdSystemsView.Columns[3].Visible = false;
            grdSystems.EndUpdate();
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR loading systems:" + Environment.NewLine + Environment.NewLine + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      #endregion

   }
}