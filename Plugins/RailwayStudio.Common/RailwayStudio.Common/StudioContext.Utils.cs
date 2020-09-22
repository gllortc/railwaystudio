using Rwm.Studio.Plugins.Common.Views;

namespace Rwm.Studio.Plugins.Common
{
   public class Utils
   {

      public void ShowThemeManager()
      {
         this.ShowThemeManager(null);
      }

      public void ShowThemeManager(System.Windows.Forms.IWin32Window owner)
      {
         ThemeManagerView form = new ThemeManagerView();
         form.ShowDialog(owner);
      }

   }
}
