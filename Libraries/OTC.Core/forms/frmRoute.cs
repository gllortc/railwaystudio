using System.Windows.Forms;
using otc.panels;

namespace otc.forms
{
   public partial class frmRoute : Form
   {
      OTCRoute _route = null;

      /// <summary>
      /// Devuelve una instancia de frmRoute.
      /// </summary>
      public frmRoute()
      {
         InitializeComponent();

         this.Text = Application.ProductName;
      }

      /// <summary>
      /// Devuelve una instancia de frmRoute.
      /// </summary>
      public frmRoute(otc.panels.OTCRoute route)
      {
         InitializeComponent();

         this.Text = Application.ProductName;
         _route = route;

         txtName.Text = _route.Name;
      }

      private void frmRoute_Load(object sender, System.EventArgs e)
      {
         this.Text = Application.ProductName;
         
         txtName.Focus();
      }

      /// <summary>
      /// Devuelve la instancia editada en el formualrio.
      /// </summary>
      public OTCRoute Route
      {
         get { return _route; }
         // set { _route = value; }
      }

      /// <summary>
      /// Responde a la pulsación del botón Cancelar.
      /// </summary>
      private void btnCancel_Click(object sender, System.EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      /// <summary>
      /// Responde a la pulsación del botón Aceptar.
      /// </summary>
      private void btnAccept_Click(object sender, System.EventArgs e)
      {
         if (_route == null) _route = new OTCRoute();

         if (string.IsNullOrEmpty(txtName.Text))
         {
            MessageBox.Show(this, "Debe p`roporcionar un nombre para la ruta.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tabRoute.SelectedTab = tabRouteGeneral;
            txtName.Focus();
            return;
         }

         _route.Name = txtName.Text;

         this.DialogResult = DialogResult.OK;
         this.Close();
      }
   }
}
