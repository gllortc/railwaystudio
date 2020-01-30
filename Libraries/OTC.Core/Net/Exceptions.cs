using System;

namespace Rwm.Otc.Net
{

   /// <summary>
   /// Throw when the remote server not found.
   /// </summary>
   public class ServerNotFoundException : Exception
   {
      /// <summary>
      /// Creates an instance of ServerNotFoundException class.
      /// </summary>
      /// <param name="message">The message to show to the user.</param>
      public ServerNotFoundException(string message) : base(message)
      {
      }
   }

}
