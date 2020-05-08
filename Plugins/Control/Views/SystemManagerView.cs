using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Rwm.Otc;
using Rwm.Otc.Systems;
using Rwm.Studio.Plugins.Common;

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
         if (!(grdSystemsView.GetRow(e.RowHandle) is IDigitalSystem system) || !system.ID.Equals(OTCContext.Project.DigitalSystem.ID))
         {
            StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_SYSTEM_16, e);
         }
         else
         {
            StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_SYSTEM_SELECTED_16, e);
         }
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
            int[] selRows = grdSystemsView.GetSelectedRows();
            IDigitalSystem system = grdSystemsView.GetRow(selRows[0]) as IDigitalSystem;

            OTCContext.Project.SystemManager.SetSystem(system);

            this.ListSystems();
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error configuring the selected digital system: " + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void CmdSystemSetup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdSystemsView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("No digital system has been selected from list.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            int[] selRows = grdSystemsView.GetSelectedRows();
            IDigitalSystem system = grdSystemsView.GetRow(selRows[0]) as IDigitalSystem;

            system.ShowSettingsDialog();
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error accessing system settings: " + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void CmdRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.ListSystems();
      }

      private void CmdClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      #endregion

      #region Private Members

      private void ListSystems()
      {
         try
         {
            grdSystems.BeginUpdate();

            if (grdSystemsView.Columns.Count <= 0)
            {
               grdSystemsView.OptionsBehavior.AutoPopulateColumns = false;
               grdSystemsView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
               grdSystemsView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name" });
               grdSystemsView.Columns.Add(new GridColumn() { Caption = "Description", Visible = true, FieldName = "Description", Width = 165 });
               grdSystemsView.Columns.Add(new GridColumn() { Caption = "Version", Visible = true, FieldName = "Version", Width = 45 });
            }

            grdSystems.DataSource = OTCContext.Project.SystemManager.GetAll();

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