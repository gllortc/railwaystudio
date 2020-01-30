using System;
using System.Drawing;
using System.Windows.Forms;
using otc.systems;
using otc.forms.controls;

namespace otc
{
   /// <summary>
   /// Formulario de gestión de los sistemas digitales.
   /// </summary>
   public partial class frmSystemManager : Form
   {
      private OTCSystems _systems = null;

      /// <summary>
      /// Devuelve una instancia de frmSystemManager.
      /// </summary>
      public frmSystemManager()
      {
         InitializeComponent();
      }

      private void frmSystemRegister_Load(object sender, EventArgs e)
      {
         this.Icon = otc.forms.OTCForms.Icon;
         this.Text = Application.ProductName;

         _systems = new OTCSystems();

         ListSystems();
      }

      private void cmdSetup_Click(object sender, EventArgs e)
      {
         if (drpSystems.CurrentItem == null)
         {
            MessageBox.Show("Debe seleccionar un controlador.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            OTCSystemController controller = ((OTCSystem)drpSystems.CurrentItem.Tag).GetController();
            controller.Setup();
            controller.Dispose();
         }
         catch (Exception err)
         {
            MessageBox.Show(err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void cmdDelete_Click(object sender, EventArgs e)
      {
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

            ListSystems();
         }
         catch (Exception err)
         {
            Cursor.Current = Cursors.Default;
            MessageBox.Show(err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

         Cursor.Current = Cursors.Default;
      }

      private void btnProperties_Click(object sender, EventArgs e)
      {
         otc.forms.frmSystemProperties properties = new otc.forms.frmSystemProperties((OTCSystem)drpSystems.CurrentItem.Tag);
         properties.ShowDialog(this);
      }

      private void btnAddSystem_Click(object sender, EventArgs e)
      {
         frmSystemRegister register = new frmSystemRegister();
         register.ShowDialog(this);

         // Recarga el gestor de sistemas digitales
         _systems = new OTCSystems();

         ListSystems();
      }

      private void btnSelect_Click(object sender, EventArgs e)
      {
         if (drpSystems.CurrentItem == null)
         {
            MessageBox.Show("Debe seleccionar un controlador.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         _systems.Select(drpSystems.CurrentItem.Controls["lblName"].Text);
         _systems.Save();

         ListSystems();
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void ListSystems()
      {
         // Elimina todos los elementos
         while (drpSystems.ItemCount > 0)
         {
            drpSystems.RemoveAt(drpSystems.ItemCount - 1);
         }

         drpSystems.VirtualMode = true;
         foreach (OTCSystem system in _systems.Systems)
         {
            try
            {
               OTCSystemController controller = system.GetController();

               drpSystems.AddNew();
               ((PictureBox)drpSystems.CurrentItem.Controls["picIcon"]).Image = controller.Icon;
               drpSystems.CurrentItem.Controls["lblName"].Text = controller.Name;
               drpSystems.CurrentItem.Controls["lblDescription"].Text = controller.Description;
               drpSystems.CurrentItem.Controls["lblVersion"].Text = controller.Version;
               drpSystems.CurrentItem.Tag = system;

               if (system.IsActive)
               {
                  // drpSystems.CurrentItem.BackColor = Color.LightGray;
                  drpSystems.CurrentItem.BackColor = Color.FromArgb(0x55, 0xAA, 0xFF);
                  drpSystems.CurrentItem.ForeColor = Color.White;
               }

               controller.Dispose();
            }
            catch (Exception e)
            {
               drpSystems.AddNew();
               ((PictureBox)drpSystems.CurrentItem.Controls["picIcon"]).Image = global::otc.Properties.Resources.IMG_DISABLED;
               drpSystems.CurrentItem.Controls["lblName"].Text = system.Name;
               drpSystems.CurrentItem.Controls["lblDescription"].Text = e.Message;
               drpSystems.CurrentItem.Controls["lblVersion"].Text = "";
               drpSystems.CurrentItem.Controls["btnSelect"].Enabled = false;
               drpSystems.CurrentItem.Controls["btnProperties"].Enabled = false;
               drpSystems.CurrentItem.Controls["cmdSetup"].Enabled = false;
               drpSystems.CurrentItem.Tag = system;
            }
         }
      }
   }
}
