using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using RailwayStudio.Common.Views;

namespace RailwayStudio.Common.Controls
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

      #region Methods

      public override void Refresh()
      {
         try
         {
            grdPlugins.BeginUpdate();

            grdPluginsView.OptionsBehavior.AutoPopulateColumns = false;
            grdPluginsView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
            grdPluginsView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name" });
            grdPluginsView.Columns.Add(new GridColumn() { Caption = "Description", Visible = true, FieldName = "Description", Width = 165 });
            grdPluginsView.Columns.Add(new GridColumn() { Caption = "Version", Visible = true, FieldName = "Version", Width = 45 });
            grdPlugins.DataSource = StudioContext.PluginManager.GetAll();

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
         form.ShowDialog(this);

         if (form.DialogResult == DialogResult.Cancel)
         {
            return;
         }

         try
         {
            StudioContext.PluginManager.Add(form.Plugin, fileForm.FileName);
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
