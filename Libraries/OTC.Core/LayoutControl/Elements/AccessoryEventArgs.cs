using System;

namespace Rwm.Otc.LayoutControl.Elements
{
   public class AccessoryEventArgs : EventArgs
   {

      public AccessoryEventArgs(int newStatus)
         : base()
      {
         this.NewStatus = newStatus;
      }

      public int NewStatus { get; private set; }

   }
}
