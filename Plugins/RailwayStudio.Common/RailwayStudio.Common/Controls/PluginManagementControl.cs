using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Rwm.Studio.Plugins.Common.Views;

namespace Rwm.Studio.Plugins.Common.Controls
{
   /// <summary>
   /// Control that allows to manage the installed plugins.
   /// </summary>
   public partial class PluginManagementControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="PluginManagementControl"/>.
      /// </summary>
      /// <param name="settings">The current application settings.</param>
      public PluginManagementControl()
      {
         InitializeComponent();

         this.Refresh();
      }

      #endregion

      #region Properties

      public bool PluginsChanged { get; private set; } = false;

      #endregion

      #region Methods

      public override void Refresh()
      {
         try
         {
            grdPlugins.BeginUpdate();

            grdPluginsView.OptionsBehavior.AutoPopulateColumns = false;
            grdPluginsView.Columns.Clear();
            grdPluginsView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
            grdPluginsView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name" });
            grdPluginsView.Columns.Add(new GridColumn() { Caption = "Description", Visible = true, FieldName = "Description", Width = 165 });
            grdPluginsView.Columns.Add(new GridColumn() { Caption = "Version", Visible = true, FieldName = "Version", Width = 45 });
            grdPlugins.DataSource = StudioContext.PluginManager.InstalledPackages;

            grdPlugins.EndUpdate();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

         base.Refresh();
      }

      #endregion

      #region Event Handlers

      private void GrdPluginsView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         if (grdPluginsView.GetRow(e.RowHandle) is IPluginPackage package)
         {
            StudioContext.UI.DrawRowIcon(package.SmallIcon, e);
         }
      }

      private void CmdPluginAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         OpenFileDialog fileForm = new OpenFileDialog();
         fileForm.Title = "Select package file to install";
         fileForm.Filter = "DLL libraries|*.dll|EXE files|*.exe|All files|*.*";
         if (fileForm.ShowDialog() == DialogResult.Cancel)
         {
            return;
         }

         PluginEditorView form = new PluginEditorView(fileForm.FileName);
         if (form.ShowDialog(this) == DialogResult.Cancel)
         {
            return;
         }

         try
         {
            StudioContext.PluginManager.Add(form.PluginPackage);
            this.PluginsChanged = true;
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

         this.Refresh();
      }

      private void CmdPluginRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdPluginsView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the plug-in you want to uninstall.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         // Get the package to remove
         int[] rows = grdPluginsView.GetSelectedRows();
         if (!(grdPluginsView.GetRow(rows[0]) is IPluginPackage package))
         {
            return;
         }

         DialogResult result = MessageBox.Show("Are you sure you want to uninstall the plug-in " + package.Name + "?", 
                                               Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
         if (result == DialogResult.Cancel)
         {
            return;
         }

         try
         {
            StudioContext.PluginManager.Remove(package.ID);
            this.PluginsChanged = true;
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

         this.Refresh();
      }

      #endregion

   }
}
