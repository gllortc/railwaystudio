using RailwayStudio.Common;
using Rwm.Otc.LayoutControl;
using Rwm.Otc.Themes;
using System;
using System.Data;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class FrmSoundManager : DevExpress.XtraEditors.XtraForm
   {
      public FrmSoundManager()
      {
         InitializeComponent();

         this.Manager = new SoundManager(StudioContext.Settings);

         this.RefreshData();
      }

      public SoundManager Manager { get; private set; }

      private void cmdSoundPlay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdDataView.SelectedRowsCount <= 0)
         {
            return;
         }

         try
         {
            int[] rows = grdDataView.GetSelectedRows();
            DataRowView drv = grdDataView.GetRow(rows[0]) as DataRowView;
            if (drv != null)
            {
               this.Manager.PlaySound((Int64)drv[0], StudioContext.Project);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR playing sound: " + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void cmdSoundAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         FrmSoundEditor form = new FrmSoundEditor();
         form.ShowDialog(this);

         if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
         {
            this.RefreshData();
         }
      }

      private void cmdSoundDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdDataView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("No sound selected.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            int[] rows = grdDataView.GetSelectedRows();
            DataRowView drv = grdDataView.GetRow(rows[0]) as DataRowView;
            if (drv != null)
            {
               if (MessageBox.Show("Are you sure you want to remove the sound " + drv[1].ToString() + "?",
                                   Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
               {
                  this.Manager.Delete((Int64)drv[0]);
                  this.RefreshData();
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR removing sound: " + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void RefreshData()
      {
         try
         {
            grdData.BeginUpdate();
            grdData.DataSource = this.Manager.FindAll();
            grdDataView.Columns[0].Visible = false;
            grdData.EndUpdate();
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR loading sounds:" + Environment.NewLine + Environment.NewLine + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
   }
}