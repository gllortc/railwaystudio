using System.Windows.Forms;
using otc.forms.controls;

namespace otc
{
   /// <summary>
   /// Implementa un control para seleccionar el tipo de conexión para los accesorios de dos estados.
   /// </summary>
   public partial class ctlEditConection2S : UserControl
   {
      /// <summary>
      /// Devuelve una instancia de ctlEditConection2S.
      /// </summary>
      public ctlEditConection2S()
      {
         InitializeComponent();

         lstOptions.Items.Add(new ImageComboBoxItem("Conexión 1", 0, imlIcons.Images[0]));
         lstOptions.Items.Add(new ImageComboBoxItem("Conexión 2", 1, imlIcons.Images[1]));
      }
   }
}
