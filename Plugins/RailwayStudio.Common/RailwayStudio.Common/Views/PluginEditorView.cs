using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace RailwayStudio.Common.Views
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

         this.Plugin = null;
         this.PluginPath = path;

         this.Text = "Install new plugin";
         this.cmdOK.Text = "Install";

         this.ListClasses(this.PluginPath);
      }

      #endregion

      #region Properties

      public string PluginPath { get; private set; }

      public IPluginPackage Plugin { get; private set; }

      #endregion

      #region Event Handlers

      private void grdModulesView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         // calculate the indentation of the icon based on the grid cell size
         Image image = global::RailwayStudio.Common.Properties.Resources.ICO_PLUGIN_16;
         int iconYIndent = (e.Bounds.Height - image.Height) / 2;
         e.Graphics.DrawImageUnscaled(image, e.Bounds.X + 1, e.Bounds.Y + iconYIndent);


         // always indent the text even if no icon for this cell - so all columns are aligned
         Rectangle bounds = e.Bounds;
         bounds.Width -= 20;
         bounds.X += 20;

         // TODO: this doesn't handle long text values getting truncated - should show '...' at the end
         e.Appearance.DrawString(e.Cache, e.DisplayText, bounds);
         e.Handled = true;
      }

      private void CmdOK_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Private Members

      private void ListClasses(string file)
      {
         PluginModule plugin;
         List<PluginModule> plugins = new List<PluginModule>();
         IPluginModule instance;
         IPluginPackage pInstance;

         try
         {
            Cursor.Current = Cursors.WaitCursor;

            ImageList imlIcons = new ImageList();
            imlIcons.ImageSize = new Size(16, 16);
            imlIcons.Images.Add("ICO_PLIGIN", Properties.Resources.ICO_PLUGIN_16);

            Assembly lib = Assembly.LoadFile(file);
            foreach (Type type in lib.GetExportedTypes())
            {
               if (typeof(IPluginPackage).IsAssignableFrom(type))
               {
                  pInstance = Activator.CreateInstance(type) as IPluginPackage;
                  this.Plugin = pInstance as IPluginPackage;

                  lblName.Text = pInstance.Name;
                  picIcon.Image = pInstance.LargeIcon;
               }
               else if (typeof(IPluginModule).IsAssignableFrom(type))
               {
                  instance = Activator.CreateInstance(type) as IPluginModule;
                  if (instance != null)
                  {
                     plugin = new PluginModule();
                     plugin.ID = instance.ModuleID;
                     plugin.Name = instance.ModuleName;
                     plugin.Filename = file;
                     plugin.Class = type.FullName;

                     plugins.Add(plugin);
                  }
               }
            }

            grdModules.DataSource = plugins;

            grdModulesView.Columns["ID"].Visible = false;
            grdModulesView.Columns["Filename"].Visible = false;
            grdModulesView.Columns["Class"].Visible = false;
         }
         catch (Exception ex)
         {
            Cursor.Current = Cursors.Default;

            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            instance = null;

            Cursor.Current = Cursors.Default;
         }
      }

      #endregion

   }
}