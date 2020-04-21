using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Rwm.Otc;
using Rwm.Otc.Themes;

namespace Rwm.Studio.Plugins.Common.Views
{
   public partial class ThemeManagerView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public ThemeManagerView()
      {
         InitializeComponent();

         ListThemes();
      }

      #endregion

      #region Event Handlers

      private void GrdThemesView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         ITheme theme = grdThemesView.GetRow(e.RowHandle) as ITheme;

         if (theme == null || !theme.ID.Equals(OTCContext.Project.Theme.ID))
            StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_THEME_16, e);
         else
            StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_THEME_SELECT_16, e);
      }

      private void CmdThemeSet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdThemesView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the theme you want to set as default.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            int[] selRows = grdThemesView.GetSelectedRows();
            if (grdThemesView.GetRow(selRows[0]) is ITheme theme)
            {
               OTCContext.Project.ThemeManager.SetTheme(theme);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR setting the default theme:" + Environment.NewLine + Environment.NewLine + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void CmdClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      #endregion

      #region Private Members

      private void ListThemes()
      {
         try
         {
            grdThemes.BeginUpdate();

            grdThemesView.OptionsBehavior.AutoPopulateColumns = false;
            grdThemesView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
            grdThemesView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name" });
            grdThemesView.Columns.Add(new GridColumn() { Caption = "Description", Visible = true, FieldName = "Description", Width = 120 });
            grdThemesView.Columns.Add(new GridColumn() { Caption = "Version", Visible = true, FieldName = "Version", Width = 45 });
            grdThemes.DataSource = OTCContext.Project.ThemeManager.GetAll();

            grdThemes.EndUpdate();
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR loading themes:" + Environment.NewLine + Environment.NewLine + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      #endregion

   }
}