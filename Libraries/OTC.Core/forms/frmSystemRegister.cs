using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using otc.systems;

namespace otc
{
   /// <summary>
   /// Formulario para registrar nuevos sistemas digitales.
   /// </summary>
   public partial class frmSystemRegister : Form
   {
      OTCSystemController controller = null;

      /// <summary>
      /// Devuelve una instancia de frmSystemRegister.
      /// </summary>
      public frmSystemRegister()
      {
         InitializeComponent();
      }

      private void frmSystemRegister_Load(object sender, EventArgs e)
      {
         this.Icon = otc.forms.OTCForms.Icon;
         this.Text = Application.ProductName;

         btnRegister.Enabled = false;
      }

      private void btnFileSelect_Click(object sender, EventArgs e)
      {
         OpenFileDialog file = new OpenFileDialog();
         file.Title = "Seleccione la librería DLL del controlador";
         file.Filter = "Librerías dinámicas DLL|*.dll";

         if (file.ShowDialog(this) == DialogResult.OK)
         {
            txtFilename.Text = file.FileName;
            ListClasses(file.FileName, cboClasses);
         }
      }

      private void cboClasses_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (String.IsNullOrEmpty(txtFilename.Text))
         {
            MessageBox.Show("Debe seleccionar la librería del controlador.");
            return;
         }
         else if (cboClasses.SelectedItem == null)
         {
            MessageBox.Show("Debe seleccionar la librería del controlador.");
            return;
         }

         try
         {
            lblInfo.Text = "";

            // Carga el controlador
            controller = new OTCSystemController(txtFilename.Text, ((otc.forms.controls.ComboBoxItem)cboClasses.SelectedItem).Value.ToString());

            // Informa del nombre/versión del controlador
            lblInfo.Tag = controller.Name;
            lblInfo.Text = controller.Name + " ver." + controller.Version;
            lblInfo.Visible = true;

            btnRegister.Enabled = true;
         }
         catch (Exception err)
         {
            MessageBox.Show(err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      private void btnRegister_Click(object sender, EventArgs e)
      {
         try
         {
            FileInfo file = new FileInfo(txtFilename.Text);
            if (!file.Exists)
               throw new Exception("No se encuentra el archivo " + file.FullName);

            OTCSystem system = new OTCSystem();
            system.Name = (string)lblInfo.Tag;
            system.Filename = file.Name;
            system.Class = cboClasses.Text;

            OTCSystems systems = new OTCSystems();

            foreach (OTCSystem regsys in systems.Systems)
            {
               if (regsys.Name.Trim().ToLower().Equals(system.Name.Trim().ToLower()) &&
                   regsys.Class.Trim().ToLower().Equals(system.Class.Trim().ToLower()))
               {
                  MessageBox.Show("El controlador seleccionado ya está registrado. Si ha actualizado la librería (archivo DLL) no hace falta volver a registrar el controlador.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
               }
            }

            systems.Systems.Add(system);
            systems.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
         }
         catch (Exception err)
         {
            MessageBox.Show(err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void ListClasses(string filename, ComboBox combobox)
      {
         int idx = -1;
         int i = 0;
         Assembly assembly;

         try
         {
            // Carga el controlador y genera la instancia de la clase
            assembly = Assembly.LoadFile(filename);

            combobox.Items.Clear();
            foreach (Type type in assembly.GetTypes())
            {
               i = combobox.Items.Add(new forms.controls.ComboBoxItem(type.FullName, type.FullName));
               if (type.FullName.ToLower().EndsWith("controller")) idx = i;
            }

            if (idx >= 0) combobox.SelectedIndex = idx;
         }
         catch (Exception err)
         {
            MessageBox.Show(err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

         assembly = null;
      }
   }
}
