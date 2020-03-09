using RailwayStudio.Common.Views;

namespace RailwayStudio.Common
{
   public class Utils
   {

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
