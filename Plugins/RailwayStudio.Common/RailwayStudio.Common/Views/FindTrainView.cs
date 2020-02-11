using System;
using System.Data;
using System.Windows.Forms;
using Rwm.Otc.Layout;
using Rwm.Otc.TrainControl;

namespace RailwayStudio.Common.Views
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
            if (drv[1] is System.DBNull)
            {
               e.Appearance.BackColor = System.Drawing.Color.LightGreen; // System.Drawing.Color.FromArgb(192, 255, 192);
               e.Appearance.BackColor2 = System.Drawing.Color.LightGreen; // System.Drawing.Color.FromArgb(192, 255, 192);
            }
         }
      }

      private void chkShowAll_CheckedChanged(object sender, EventArgs e)
      {
         this.ListTrains();
      }

      private void cmdAccept_Click(object sender, EventArgs e)
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

         this.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.Close();
      }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Private Members

      private void ListTrains()
      {
         try
         {
            string sql = @"SELECT 
                             m.modid, 
                             em.elementid,  
                             m.modpicture    As ""Icon"", 
                             m.modname       As ""Name"", 
                             m.moddigitaladd As ""Address"",
                             Case 
                                 When (e.Name IS null) Or (e.Name='') Then 'X:' || e.x || ';Y:' || e.y
                                 Else e.Name 
                             End             As ""Block""
                          FROM 
                             " + Train.TableName + @" m 
                             Left Join " + "ElementModel" + @" em On (em.modelid = m.modid) 
                             Left Join " + Element.TableName + @"      e  On (e.id = em.elementid)
                          WHERE 
                             m.moddigitaladd > 0 
                          ORDER BY 
                             m.modname ASC";

            grdTrainView.BeginUpdate();
            grdTrain.DataSource = null;
            grdTrain.DataSource = Train.ExecuteDataTable(sql);
            grdTrainView.Columns[0].Visible = false;
            grdTrainView.Columns[1].Visible = false;

            grdTrainView.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdTrainView.Columns[4].AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
            grdTrainView.Columns[4].AppearanceCell.FontSizeDelta = 2;

            grdTrainView.EndUpdate();
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR loading data: " + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      #endregion

   }
}