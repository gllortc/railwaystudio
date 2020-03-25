using System;
using System.Collections.Generic;

namespace Rwm.Otc.Systems.XpressNet
{
   public class LenzBufferManager
   {

      #region Constants

      private const byte COMMAND_DELIMITER = 0x3F;

      #endregion

      #region Constructors

      static LenzBufferManager()
      {
         LenzBufferManager.RxBuffer = new List<byte>();
      }

      #endregion

      #region Properties

      internal static List<byte> RxBuffer { get; set; }

      #endregion

      #region Methods

      public static List<List<byte>> DataReceived(List<byte> receivedBytes)
      {
         // Add new bytes to the buffer
         LenzBufferManager.RxBuffer.AddRange(receivedBytes);

         // Parse command packets
         return LenzBufferManager.GetPackets();
      }

      public static void Clear()
      {
         LenzBufferManager.RxBuffer.Clear();
      }

      #endregion

      #region Private Members

      private static List<List<byte>> GetPackets()
      {
         bool discard = false;
         bool reading = false;
         int remWindowStart = -1;
         int remWindowEnd = -1;
         List<byte> currentCommand = null;
         List<List<byte>> commands = new List<List<byte>>();

         for (int i = 0; i < LenzBufferManager.RxBuffer.Count; i++)
         {
            // The buffer should always start with a package. If the first bytes of the buffer don't
            // correspond to a valid command, discard bytes until a valid command header is detected
            if ((i == 0 || i == 1) && LenzBufferManager.RxBuffer[i] != COMMAND_DELIMITER)
            {
               discard = true;
            }

            // A command header is detected
            if (!reading && i < LenzBufferManager.RxBuffer.Count - 1 && LenzBufferManager.RxBuffer[i] == COMMAND_DELIMITER && LenzBufferManager.RxBuffer[i + 1] == COMMAND_DELIMITER)
            {
               if (remWindowStart < 0) 
                  remWindowStart = i;

               discard = false;
               reading = true;
               currentCommand = new List<byte>();
               i++;
            }
            else if (!discard)
            {
               if (currentCommand != null)
               {
                  currentCommand.Add(LenzBufferManager.RxBuffer[i]);
                  if (LenzBufferManager.IsValidCommand(currentCommand) || LenzBufferManager.IsInterfaceCommand(currentCommand))
                  {
                     remWindowEnd = i;
                     commands.Add(currentCommand);
                     discard = true;
                     reading = false;
                  }
                  else if (LenzBufferManager.IsDiscardableResponse(currentCommand))
                  {
                     remWindowEnd = i;
                     discard = true;
                     reading = false;
                  }
               }
            }
         }

         // Remove readed packets
         if (remWindowEnd > 0)
            LenzBufferManager.RxBuffer.RemoveRange(remWindowStart, remWindowEnd - remWindowStart + 1);

         return commands;
      }

      /// <summary>
      /// Check if the current command is a complete command:
      /// XOR(DATABYTE[1], DATABYTE[2],...,DATABYTE[n-1]) = DATABYTE[n]
      /// </summary>
      /// <param name="rxBytes">Candidate received package.</param>
      /// <returns>A value indicating if the bytes are corresponding to a complete command.</returns>
      private static bool IsValidCommand(List<byte> rxBytes)
      {
         short value = 0;

         if (rxBytes.Count < 2) return false; // Minimum 1 data byte and xor byte -> 2 bytes

         for (int i = 0; i < rxBytes.Count - 1; i++)
         {
            value ^= rxBytes[i];
         }

         return (value == rxBytes[rxBytes.Count - 1]);
      }

      /// <summary>
      /// Check if the current command is an interface response
      /// </summary>
      /// <param name="rxBytes">Candidate received package.</param>
      /// <returns>A value indicating if the bytes are corresponding to an interface response.</returns>
      private static bool IsInterfaceCommand(List<byte> rxBytes)
      {
         if (rxBytes.Count == 3 && rxBytes[0] == 0x01)
         {
            if (rxBytes[1] == 0x01 && rxBytes[2] == 0x00)
            {
               return true;
            }
            else if (rxBytes[1] == 0x02 && rxBytes[2] == 0x03)
            {
               return true;
            }
            else if (rxBytes[1] == 0x03 && rxBytes[2] == 0x02)
            {
               return true;
            }
            else if (rxBytes[1] == 0x04 && rxBytes[2] == 0x05)
            {
               return true;
            }
            else if (rxBytes[1] == 0x05 && rxBytes[2] == 0x04)
            {
               return true;
            }
            else if (rxBytes[1] == 0x06 && rxBytes[2] == 0x07)
            {
               return true;
            }
            else if (rxBytes[1] == 0x07 && rxBytes[2] == 0x06)
            {
               return true;
            }
            else if (rxBytes[1] == 0x08 && rxBytes[2] == 0x09)
            {
               return true;
            }
            else if (rxBytes[1] == 0x09 && rxBytes[2] == 0x08)
            {
               return true;
            }
            else if (rxBytes[1] == 0x10 && rxBytes[2] == 0x11)
            {
               return true;
            }
         }

         return false;
      }

      private static bool IsDiscardableResponse(List<byte> rxBytes)
      {
         if (rxBytes.Count == 3)
         {
            if (rxBytes[0] == 0x61 && rxBytes[1] == 0x3F && rxBytes[2] == 0x3F)
            {
               return true;
            }
         }

         return false;
      }

      #endregion

   }
}
