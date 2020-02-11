using RailwayStudio.Common.Views;
using Rwm.Otc.TrainControl;
using System.Windows.Forms;

namespace RailwayStudio.Common
{
   public class Find
   {
      /// <summary>
      /// Allows find a train in the OTC collection.
      /// </summary>
      /// <param name="owner">Owner window.</param>
      /// <param name="title">Finder dialogue title.</param>
      /// <returns>The selected train or <c>null</c> if user cancel the search.</returns>
      public Train Train(string title)
      {
         FindTrainView form = new FindTrainView();
         if (form.ShowDialog() == DialogResult.Cancel)
         {
            return null;
         }

         return form.SelectedTrain;
      }

      /// <summary>
      /// Allows find a train in the OTC collection.
      /// </summary>
      /// <param name="owner">Owner window.</param>
      /// <param name="title">Finder dialogue title.</param>
      /// <returns>The selected train or <c>null</c> if user cancel the search.</returns>
      public Train Train(IWin32Window owner, string title)
      {
         FindTrainView form = new FindTrainView();
         if (form.ShowDialog(owner) == DialogResult.Cancel)
         {
            return null;
         }

         return form.SelectedTrain;
      }
   }
}
