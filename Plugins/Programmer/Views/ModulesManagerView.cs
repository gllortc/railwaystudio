using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.BandedGrid;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class ModulesManagerView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public ModulesManagerView()
      {
         InitializeComponent();

         this.ListObjects();
      }

      #endregion

      #region Event Handlers

      private void GrdAreasView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(Module.SmallIcon, e);
      }

      private void GrdAreasView_DoubleClick(object sender, EventArgs e)
      {
         this.EditObject();
      }

      private void CmdAreaAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         ModuleEditorView form = new ModuleEditorView();
         if (form.ShowDialog(this) == DialogResult.OK)
         {
            this.ListObjects();
         }
      }

      private void CmdAreaEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.EditObject();
      }

      private void CmdAreaDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdAreasView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("No layout area has been selected from list.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            int[] selRows = grdAreasView.GetSelectedRows();
            Module section = grdAreasView.GetRow(selRows[0]) as Module;

            if (section != null)
            {
               if (MessageBox.Show("Are you sure you want to remove the selected layout area?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
               {
                  Module.Delete(section);
                  this.ListObjects();
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void CmdClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      #endregion

      #region Private Members

      private void EditObject()
      {
         if (grdAreasView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("No layout area has been selected from list.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            int[] selRows = grdAreasView.GetSelectedRows();
            Module section = grdAreasView.GetRow(selRows[0]) as Module;

            ModuleEditorView form = new ModuleEditorView(section);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               this.ListObjects();
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void ListObjects()
      {
         try
         {
            grdAreas.BeginUpdate();
            grdAreasView.OptionsBehavior.AutoPopulateColumns = false;

            grdAreasView.Columns.Clear();
            grdAreasView.Bands.Clear();

            GridBand mainBand = new GridBand();
            mainBand.Caption = "General";

            BandedGridColumn mainIDColumn = new BandedGridColumn();
            mainIDColumn.Caption = "ID";
            mainIDColumn.Visible = false;
            mainIDColumn.FieldName = "ID";
            mainBand.Columns.Add(mainIDColumn);

            BandedGridColumn mainNameColumn = new BandedGridColumn();
            mainNameColumn.Caption = "Name";
            mainNameColumn.Visible = true;
            mainNameColumn.FieldName = "Name";
            mainNameColumn.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            mainBand.Columns.Add(mainNameColumn);

            GridBand accBand = new GridBand();
            accBand.Caption = "Accessories";

            BandedGridColumn accStartColumn = new BandedGridColumn();
            accStartColumn.Caption = "Start";
            accStartColumn.Visible = true;
            accStartColumn.FieldName = "AccessoryStartAddress";
            accStartColumn.Width = 30;
            accBand.Columns.Add(accStartColumn);

            BandedGridColumn accEndColumn = new BandedGridColumn();
            accEndColumn.Caption = "End";
            accEndColumn.Visible = true;
            accEndColumn.FieldName = "AccessoryEndAddress";
            accEndColumn.Width = 30;
            accBand.Columns.Add(accEndColumn);

            GridBand fbBand = new GridBand();
            fbBand.Caption = "Feedback";

            BandedGridColumn fbStartColumn = new BandedGridColumn();
            fbStartColumn.Caption = "Start";
            fbStartColumn.Visible = true;
            fbStartColumn.FieldName = "FeedbackStartAddress";
            fbStartColumn.Width = 30;
            fbBand.Columns.Add(fbStartColumn);

            BandedGridColumn fbEndColumn = new BandedGridColumn();
            fbEndColumn.Caption = "End";
            fbEndColumn.Visible = true;
            fbEndColumn.FieldName = "FeedbackEndAddress";
            fbEndColumn.Width = 30;
            fbBand.Columns.Add(fbEndColumn);

            GridBand connBand = new GridBand();
            connBand.Caption = "Connections";

            BandedGridColumn connPwrBusColumn = new BandedGridColumn();
            connPwrBusColumn.Caption = "Power";
            connPwrBusColumn.Visible = true;
            connPwrBusColumn.FieldName = "ConnectedToPowerBus";
            connPwrBusColumn.Width = 30;
            connBand.Columns.Add(connPwrBusColumn);

            BandedGridColumn connCtrlBusColumn = new BandedGridColumn();
            connCtrlBusColumn.Caption = "System";
            connCtrlBusColumn.Visible = true;
            connCtrlBusColumn.FieldName = "ConnectedToControlBus";
            connCtrlBusColumn.Width = 30;
            connBand.Columns.Add(connCtrlBusColumn);

            BandedGridColumn connCmdBusColumn = new BandedGridColumn();
            connCmdBusColumn.Caption = "Command";
            connCmdBusColumn.Visible = true;
            connCmdBusColumn.FieldName = "ConnectedToCommandBus";
            connCmdBusColumn.Width = 30;
            connBand.Columns.Add(connCmdBusColumn);

            grdAreasView.Bands.AddRange(new GridBand[] { mainBand, accBand, fbBand, connBand });
            grdAreasView.Columns.AddRange(new BandedGridColumn[] { mainIDColumn, mainNameColumn, accStartColumn, accEndColumn, fbStartColumn, fbEndColumn, connPwrBusColumn, connCtrlBusColumn, connCmdBusColumn });

            grdAreas.DataSource = Module.FindAll();

            grdAreas.EndUpdate();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      #endregion

   }
}