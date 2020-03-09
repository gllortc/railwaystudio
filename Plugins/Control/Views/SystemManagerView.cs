using System;
using System.Data;
using System.Windows.Forms;
using RailwayStudio.Common;
using Rwm.Otc;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class SystemManagerView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public SystemManagerView()
      {
         InitializeComponent();

         this.ListSystems();
      }

      #endregion

      #region Event Handlers

      private void GrdSystemsView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_SYSTEM_16, e);
      }

      private void CmdSystemSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdSystemsView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("No digital system has been selected from list.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            if (!(grdSystemsView.GetRow(grdSystemsView.GetSelectedRows()[0]) is DataRowView drv)) return;

            OTCContext.Project.SystemManager.SetSystem(drv["Type"] as Type);
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error configuring the selected digital system: " + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
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