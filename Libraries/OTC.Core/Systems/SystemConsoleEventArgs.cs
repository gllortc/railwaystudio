﻿using System;

namespace Rwm.Otc.Systems
{
   /// <summary>
   /// Class to store the information emitted from the disigtal system to bring to console.
   /// </summary>
   public class SystemConsoleEventArgs : EventArgs
   {
      
      #region Enumerations

      public enum MessageType
      {
         Information,
         Warning,
         Error,
         Debug
      }

      #endregion

      #region Constructors

      public SystemConsoleEventArgs(string message)
      {
         this.Message = message;
         this.Type = MessageType.Information;
      }

      public SystemConsoleEventArgs(string message, params object[] args)
      {
         this.Message = string.Format(message, args);
         this.Type = MessageType.Information;
      }

      public SystemConsoleEventArgs(MessageType type, string message)
      {
         this.Message = message;
         this.Type = type;
      }

      public SystemConsoleEventArgs(MessageType type, string message, params object[] args)
      {
         this.Message = string.Format(message, args);
         this.Type = type;
      }

      #endregion

      #region Properties

      public string Message { get; private set; }

      public MessageType Type { get; private set; }

      #endregion

   }
}
