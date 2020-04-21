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

      /// <summary>
      /// Show the train digital address calculator.
      /// </summary>
      public void ShowDigitalAddressCalculator()
      {
         TrainAddressView form = new TrainAddressView();
         form.ShowDialog();
      }

      /// <summary>
      /// Show the train digital address calculator.
      /// </summary>
      public void ShowDigitalAddressCalculator(uint address)
      {
         TrainAddressView form = new TrainAddressView(address);
         form.ShowDialog();
      }

   }
}
