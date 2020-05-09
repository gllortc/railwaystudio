using System;
using System.Data;
using System.Windows.Forms;
using Rwm.Otc.Layout;
using Rwm.Otc.Trains;

namespace Rwm.Studio.Plugins.Common.Views
{
   public partial class FindTrainView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public FindTrainView()
      {
         InitializeComponent();

         this.ListTrains();
      }

      #endregion

      #region Properties

      public Train SelectedTrain { get; private set; }

      #endregion

      #region Event Handlers

      private void FindTrainView_Load(object sender, EventArgs e)
      {
         grdTrainView.ShowFindPanel();
         grdTrainView.Focus();
      }

      private void grdTrainView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
      {
         if (grdTrainView.GetRow(e.RowHandle) is DataRowView drv)
         {
            if (!(drv[1] is System.DBNull))
            {
               e.Appearance.BackColor = System.Drawing.Color.LightSalmon;
               e.Appearance.BackColor2 = System.Drawing.Color.LightSalmon;
            }
         }
      }

      private void ChkShowAll_CheckedChanged(object sender, EventArgs e)
      {
         this.ListTrains();
      }

      private void CmdAccept_Click(object sender, EventArgs e)
      {

         if (grdTrainView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("No train selection.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         DataRowView drv = grdTrainView.GetRow(grdTrainView.GetSelectedRows()[0]) as DataRowView;
         if (drv != null)
         {
            this.SelectedTrain = Train.Get((Int64)drv[0]);
         }

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Private Members

      private void ListTrains()
      {
         grdTrainView.BeginUpdate();
         grdTrain.DataSource = null;
         grdTrain.DataSource = ElementTrain.ListTrains();
         grdTrainView.Columns[0].Visible = false;
         grdTrainView.Columns[1].Visible = false;

         grdTrainView.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdTrainView.Columns[4].AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
         grdTrainView.Columns[4].AppearanceCell.FontSizeDelta = 2;

         grdTrainView.EndUpdate();
      }

      #endregion

   }
}