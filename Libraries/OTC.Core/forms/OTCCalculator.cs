using System.Windows.Forms;

namespace otc.forms
{

   #region class OTCCalculator

   /// <summary>
   /// Implementa una calculadora de escalas.
   /// </summary>
   public class OTCCalculator
   {
      /// <summary>
      /// Muestra la calculadora en un formulario modal.
      /// </summary>
      /// <param name="owner">Instáncia del formualrio propietario.</param>
      public static void ShowCalculator(IWin32Window owner)
      {
         frmCalculator calc = new frmCalculator();
         calc.ShowDialog(owner);
      }

      /// <summary>
      /// Muestra la calculadora.
      /// </summary>
      public static void ShowCalculator()
      {
         frmCalculator calc = new frmCalculator();
         calc.Show();
      }
   }

   #endregion

}
