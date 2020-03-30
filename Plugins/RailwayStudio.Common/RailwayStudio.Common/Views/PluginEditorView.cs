using System;
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;

namespace Rwm.Studio.Plugins.Common.Views
{
   public partial class PluginEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="PluginEditorView"/>.
      /// </summary>
      /// <param name="path">Filename `+ path of the file to install.</param>
      public PluginEditorView(string path)
      {
         InitializeComponent();

         this.PluginPackage = null;
         this.PluginPath = path;

         this.Text = "Install new plugin";
         this.cmdOK.Text = "Install";

         this.ListModules(this.PluginPath);
      }

      #endregion

      #region Properties

      public string PluginPath { get; private set; }

      public IPluginPackage PluginPackage { get; private set; }

      #endregion

      #region Event Handlers

      private void GrdModulesView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         if (!(grdModulesView.GetRow(e.RowHandle) is IPluginModule module))
            StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_PLUGIN_16, e);
         else
            StudioContext.UI.DrawRowIcon(module.SmallIcon, e);
      }

      private void CmdOK_Click(object sender, EventArgs e)
      {
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

      private void ListModules(string path)
      {
         try
         {
            Cursor.Current = Cursors.WaitCursor;

            this.PluginPackage = PluginPackageBase.LoadFromFile(path);
            if (this.PluginPackage != null)
            {
               lblName.Text = this.PluginPackage.Name;
               lblVersion.Text = "Version " + this.PluginPackage.Version;
               picIcon.Image = this.PluginPackage.LargeIcon;

               FileVersionInfo info = Rwm.Otc.Utils.ReflectionUtils.GetAssemblyInfo(this.PluginPackage.GetType());
               lblDeveloper.Text = info.CompanyName;
               lblCopyright.Text = info.LegalCopyright;

               // Load the package modules
               this.PluginPackage.LoadModules(this.PluginPackage.GetType());

               grdModules.BeginUpdate();
               grdModulesView.OptionsBehavior.AutoPopulateColumns = false;
               grdModulesView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
               grdModulesView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Caption" });
               grdModules.DataSource = this.PluginPackage.Modules;
               grdModules.EndUpdate();
            }
            else
            {
               MessageBox.Show("The specified file not correspond to a RailwayStudio plug-in package.", 
                               Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
         catch (Exception ex)
         {
            Cursor.Current = Cursors.Default;

            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            Cursor.Current = Cursors.Default;
         }
      }

      #endregion

   }
}