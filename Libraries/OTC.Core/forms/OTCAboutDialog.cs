using System.Windows.Forms;

namespace otc.forms
{

   #region class OTCAboutDialog

   /// <summary>
   /// Implementa un formulario Acerca de... estandarizado.
   /// </summary>
   public class OTCAboutDialog
   {
      /// <summary>
      /// Muestra el formulario.
      /// </summary>
      /// <param name="name">Nombre del producto.</param>
      /// <param name="version">Versión del producto.</param>
      /// <param name="copyright">Derechos legales.</param>
      public static void ShowDialog(string name, string version, string copyright)
      {
         frmAbout about = new frmAbout(name, version, copyright);
         about.ShowDialog();
      }

      /// <summary>
      /// Muestra el formulario.
      /// </summary>
      /// <param name="owner">Instáncia del formualrio propietario.</param>
      /// <param name="name">Nombre del producto.</param>
      /// <param name="version">Versión del producto.</param>
      /// <param name="copyright">Derechos legales.</param>
      public static void ShowDialog(IWin32Window owner, string name, string version, string copyright)
      {
         frmAbout about = new frmAbout(name, version, copyright);
         about.ShowDialog(owner);
      }
   }

   #endregion

}
