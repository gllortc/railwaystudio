using System;
using System.Collections.Generic;

namespace Rwm.OTC.Systems.XpressNet
{
   public class XpnBufferManager
   {

      #region Constants

      private const byte COMMAND_DELIMITER = 0x3F;

      #endregion

      #region Constructors

      static XpnBufferManager()
      {
         XpnBufferManager.RxBuffer = new List<byte>();
      }

      #endregion

      #region Properties

      private static List<byte> RxBuffer { get; set; }

      #endregion

      #region Methods

      public static List<List<byte>> DataReceived(List<byte> receivedBytes)
      {
         // Add new bytes to the buffer
         XpnBufferManager.RxBuffer.AddRange(receivedBytes);

         // Parse command packets
         return XpnBufferManager.GetPackets();
      }

      public static void Clear()
      {
         XpnBufferManager.RxBuffer.Clear();
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

         for (int i = 0; i < XpnBufferManager.RxBuffer.Count; i++)
         {
            // The buffer should always start with a package. If the first bytes of the buffer don't
            // correspond to a valid command, discard bytes until a valid command header is detected
            if ((i == 0 || i == 1) && XpnBufferManager.RxBuffer[i] != COMMAND_DELIMITER)
            {
               discard = true;
            }

            // A command header is detected
            if (!reading && i < XpnBufferManager.RxBuffer.Count - 1 && XpnBufferManager.RxBuffer[i] == COMMAND_DELIMITER && XpnBufferManager.RxBuffer[i + 1] == COMMAND_DELIMITER)
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
                  currentCommand.Add(XpnBufferManager.RxBuffer[i]);
                  if (IsValidCommand(currentCommand))
                  {
                     remWindowEnd = i;
                     commands.Add(currentCommand);
                     discard = true;
                     reading = false;
                  }
               }
            }
         }

         // Remove readed packets
         if (remWindowEnd > 0)
            XpnBufferManager.RxBuffer.RemoveRange(remWindowStart, remWindowEnd - remWindowStart + 1);

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

      #endregion

   }
}
