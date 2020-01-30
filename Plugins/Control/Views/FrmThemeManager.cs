using Rwm.Otc;
using System;
using System.Data;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class FrmThemeManager : DevExpress.XtraEditors.XtraForm
   {
      public FrmThemeManager()
      {
         InitializeComponent();

         ListThemes();
      }

      private void cmdThemeSet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdThemesView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the theme you want to set as default.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            DataRowView drv = grdThemesView.GetRow(grdThemesView.GetSelectedRows()[0]) as DataRowView;
            if (drv != null)
            {
               OTCContext.Project.ThemeManager.SetTheme((Type)drv[3]);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR setting the default theme:" + Environment.NewLine + Environment.NewLine + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void ListThemes()
      {
         try
         {
            grdThemes.BeginUpdate();
            grdThemes.DataSource = OTCContext.Project.ThemeManager.Find();
            grdThemesView.Columns[0].Visible = false;
            grdThemesView.Columns[3].Visible = false;
            grdThemes.EndUpdate();
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR loading themes:" + Environment.NewLine + Environment.NewLine + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
   }
}