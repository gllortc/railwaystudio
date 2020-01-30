using RailwayStudio.Common.Views;
using System;
using System.Data;
using System.Windows.Forms;

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

         this.PluginManager = new PluginManager();

         this.Refresh();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the manager used to manage the installed plugins.
      /// </summary>
      public PluginManager PluginManager { get; private set; }

      #endregion

      #region Methods

      public override void Refresh()
      {
         DataTable dt = new DataTable();
         dt.Columns.Add("ID", typeof(string));
         dt.Columns.Add("Name", typeof(string));

         foreach (Plugin plugin in this.PluginManager.GetAll())
         {
            dt.Rows.Add(plugin.ID, plugin.Name);
         }

         grdPlugins.BeginUpdate();
         grdPlugins.DataSource = dt;
         grdPlugins.EndUpdate();

         base.Refresh();
      }

      #endregion

      #region Event Handlers

      private void cmdPluginAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            this.PluginManager.Add(form.Plugin, fileForm.FileName);
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR installing plugin: " + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

         this.Refresh();
      }

      #endregion

   }
}
