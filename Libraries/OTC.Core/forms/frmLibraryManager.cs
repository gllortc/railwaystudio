using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using otc.configuration;
using otc.panels;

namespace otc
{
   /// <summary>
   /// Formulario de gestión de los sistemas digitales.
   /// </summary>
   public partial class frmLibraryManager : Form
   {
      private string _settingskey = "";
      private DirectoryInfo _path = null;
      private OTCSettingsManager _settings = null;

      /// <summary>
      /// Devuelve una instancia de frmSystemManager.
      /// </summary>
      /// <param name="settings">Una instancia de la configuración de la aplicación.</param>
      /// <param name="settingsKey">Clave del parámetro que almacena el nombre de la librería seleccionada actualmente.</param>
      public frmLibraryManager(OTCSettingsManager settings, string settingsKey)
      {
         InitializeComponent();

         _settings = settings;
         _settingskey = settingsKey;

         // Obtiene la ruta de la aplicación que ejecuta actualmente la librería OTC.
         _path = new DirectoryInfo(Path.Combine(Application.StartupPath, "Library\\Panels"));
      }

      /// <summary>
      /// Devuelve una instancia de frmSystemManager.
      /// </summary>
      /// <param name="path">Ruta dónde se encuentran instaladas las librerías de presentación.</param>
      /// <param name="settings">Una instancia de la configuración de la aplicación.</param>
      /// <param name="settingsKey">Clave del parámetro que almacena el nombre de la librería seleccionada actualmente.</param>
      public frmLibraryManager(string path, OTCSettingsManager settings, string settingsKey)
      {
         InitializeComponent();

         _settings = settings;
         _settingskey = settingsKey;

         // Obtiene la ruta proporcionada por parámetro.
         _path = new DirectoryInfo(path);
      }

      private void frmSystemRegister_Load(object sender, EventArgs e)
      {
         this.Icon = otc.forms.OTCForms.Icon;
         this.Text = Application.ProductName;

         ListLibraries();
      }

      private void cmdDelete_Click(object sender, EventArgs e)
      {
         /*
         if (drpSystems.CurrentItem == null)
         {
            MessageBox.Show("Debe seleccionar un controlador.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         else if (MessageBox.Show("¿Está ud. seguro que desea eliminar este controlador?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
         {
            return;
         }

         Cursor.Current = Cursors.WaitCursor;

         try
         {
            _systems.Systems.Remove((OTCSystem)drpSystems.CurrentItem.Tag);
            _systems.Save();

            ListLibraries();
         }
         catch (Exception err)
         {
            Cursor.Current = Cursors.Default;
            MessageBox.Show(err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

         Cursor.Current = Cursors.Default;
         */
      }

      private void btnProperties_Click(object sender, EventArgs e)
      {
         OTCLibrary lib = new OTCLibrary(Path.Combine(Path.Combine(_path.FullName, (string)drpSystems.CurrentItem.Tag), OTCLibrary.LIBRARY_FILE_NAME));

         otc.forms.frmLibraryProperties properties = new otc.forms.frmLibraryProperties(lib);
         properties.ShowDialog(this);
      }

      private void btnAddSystem_Click(object sender, EventArgs e)
      {
         /*
         frmSystemRegister register = new frmSystemRegister();
         register.ShowDialog(this);

         // Recarga el gestor de sistemas digitales
         _systems = new OTCSystems();

         ListLibraries();
         */
      }

      private void btnSelect_Click(object sender, EventArgs e)
      {
         if (drpSystems.CurrentItem == null)
         {
            MessageBox.Show("Debe seleccionar una librería.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         _settings.SetString(_settingskey, (string)drpSystems.CurrentItem.Tag);
         _settings.Save();

         ListLibraries();
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void ListLibraries()
      {
         // Elimina todos los elementos
         while (drpSystems.ItemCount > 0)
         {
            drpSystems.RemoveAt(drpSystems.ItemCount - 1);
         }

         string activelib = _settings.GetSetting(_settingskey, "").ToLower();

         // Rellena la lista
         drpSystems.VirtualMode = true;
         foreach (DirectoryInfo subdir in _path.GetDirectories())
         {
            OTCLibrary lib = new OTCLibrary(Path.Combine(subdir.FullName, OTCLibrary.LIBRARY_FILE_NAME));

            drpSystems.AddNew();
            ((PictureBox)drpSystems.CurrentItem.Controls["picIcon"]).Image = global::otc.Properties.Resources.IMG_LIBRARY;
            drpSystems.CurrentItem.Controls["lblName"].Text = lib.Name;
            drpSystems.CurrentItem.Controls["lblDescription"].Text = lib.Description;
            drpSystems.CurrentItem.Controls["lblVersion"].Text = lib.Version;
            drpSystems.CurrentItem.Tag = subdir.Name;

            if (subdir.Name.ToLower().Equals(activelib))
            {
               drpSystems.CurrentItem.BackColor = Color.FromArgb(0x55, 0xAA, 0xFF);
               drpSystems.CurrentItem.ForeColor = Color.White;
            }
         }
      }
   }
}
