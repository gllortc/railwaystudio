using System;
using System.Windows.Forms;
using otc.systems;

namespace otc.forms
{
   /// <summary>
   /// Implementa un formulario para mostrar las propiedades de un controlador de sistema digital.
   /// </summary>
   public partial class frmSystemProperties : Form
   {
      private OTCSystem _sys = null;
      private OTCSystemController _ctrl = null;

      /// <summary>
      /// Devuelve una instancia de frmSystemProperties.
      /// </summary>
      public frmSystemProperties(OTCSystem system)
      {
         InitializeComponent();

         _sys = system;
         _ctrl = system.GetController();

         picIcon.Image = _ctrl.Icon;
         lblName.Text = _ctrl.Name;
         lblDescription.Text = _ctrl.Description;
         lblVersion.Text = _ctrl.Version;
         lblFile.Text = _sys.Filename;
         lblClass.Text = _sys.Class;

         ListParams();
      }

      private void btnSetup_Click(object sender, EventArgs e)
      {
         if (_ctrl.Setup() == DialogResult.OK)
            ListParams();
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void ListParams()
      {
         lvwParameters.Items.Clear();
         lvwParameters.View = View.Details;
         lvwParameters.Columns.Clear();
         lvwParameters.Columns.Add("Parámetro");
         lvwParameters.Columns.Add("Valor");
         foreach (OTCSystemParameter param in _sys.Parameters)
         {
            ListViewItem item = new ListViewItem(param.Key);
            item.SubItems.Add(param.Value);

            lvwParameters.Items.Add(item);
         }
      }

      private void frmSystemProperties_Load(object sender, EventArgs e)
      {

      }
   }
}
