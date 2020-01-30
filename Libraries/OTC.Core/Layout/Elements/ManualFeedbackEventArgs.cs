using System;

namespace Rwm.Otc.LayoutControl.Blocks
{
   public class ManualFeedbackEventArgs : EventArgs
   {

      public ManualFeedbackEventArgs(int newStatus)
         : base()
      {
         this.NewStatus = newStatus;
      }

      public int NewStatus { get; private set; }

   }
}
