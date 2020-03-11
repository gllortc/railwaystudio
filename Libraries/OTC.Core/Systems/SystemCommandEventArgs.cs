using System;
using Rwm.Otc.Systems.Protocol;

namespace Rwm.Otc.Systems
{
   /// <summary>
   /// Class to store the information emitted from the disigtal system to bring to console.
   /// </summary>
   public class SystemCommandEventArgs : EventArgs
   {
      
      #region Constructors

      public SystemCommandEventArgs(IResponse commandReceived)
      {
         this.CommandReceived = commandReceived;
      }

      #endregion

      #region Properties

      public IResponse CommandReceived { get; private set; }

      #endregion

   }
}
