namespace Rwm.OTC.Systems.Lenz
{
   internal class LenzCommand
   {

      #region Enumerations

      public enum CommandTypes
      {
         LIVersion,                   // LI Hardware version  extra data
         Feedback1Addy,               // Feedback Data extra data
         Feedback2Addy,               // Feedback Data extra data
         Feedback3Addy,               // Feedback Data extra data
         Feedback4Addy,               // Feedback Data extra data
         Feedback5Addy,               // Feedback Data extra data
         Feedback6Addy,               // Feedback Data extra data
         Feedback7Addy,               // Feedback Data extra data
         LocoInfoAvailV1,             // Extra data ver 1
         LocoInfoAvailV2,             // Extra data ver 2
         LocoTakenOverV1,             // Extra data ver 1
         LocoTakenOverV2,             // Extra data ver 2
         MULocoInfo2,                 // Extra data
         LocoInfo,                    // Extra data
         MULocoInfo,                  // Extra data
         DHLocoInfo,                  // Extra data
         LITimeoutPC,                 // LI Broadcast
         LITimeoutCMD,                // LI Broadcast
         LIErrorUnknown,              // LI Broadcast
         LIOK,                        // LI Broadcast
         LINotTimeSlot,               // LI Broadcast
         LIBufferOverflow,            // LI Broadcast
         TrackPowerOff,               // CMD Broadcast
         NormalOpResume,              // CMD Broadcast
         SMEntry,                     // CMD Broadcast
         SMCMDProgReady,              // Service Mode Response
         SMShortCircuit,              // Service Mode Response
         SMDataByteNotFound,          // Service Mode Response
         SMCMDProgBusy,               // Service Mode Response
         CMDTransferError,            // CMD Error
         CMDBusy,                     // CMD Error
         CMDNotSupported,             // CMD Error
         DHErrorLocoNoOp,             // Dual Header Error Ver 1 & 2
         DHErrorLocoBusy,             // Dual Header Error Ver 1 & 2
         DHErrorLocoInAnotherDH,      // Dual Header Error Ver 1 & 2
         DHErrorLocoMoving,           // Dual Header Error Ver 1 & 2
         SoftwareVer1_2,              // Extra data-VER 1 & 2
         CMDStatus,                   // Service Mode Response w/extra data
         SMRegisterPageMode,          // Service Mode Response w/extra data
         SMDirectCV,                  // Extra data
         SoftwareVer3,                // Extra data
         EmergencyStop,               // CMD Broadcast
         DHAvailableV1,               // Double Header Info extra data ver 1
         DHTakenOverV1,               // Double Header Info extra data ver 1
         DHAvailableV2,               // Double Header Info extra data ver 2
         DHTakenOverV2,               // Double Header Info extra data ver 2
         MUDHErrorLocoNoOp,           // Double Header/Mulit Header Info ver 3
         MUDHErrorLocoBusy,           // Double Header/Mulit Header Info ver 3
         MHDHErrorLocoInAnotherMUDH,  // Double Header/Mulit Header Info ver 3
         MHDHErrorLocoMoving,         // Double Header/Mulit Header Info ver 3
         MHDHErrorLocoNotInMU,        // Double Header/Mulit Header Info ver 3
         MHDHErrorLocoAddyNotMUAddy,  // Double Header/Mulit Header Info ver 3
         MHDHErrorCanNotDeleteLoco,   // Double Header/Mulit Header Info ver 3
         MHDHErrorCMDStackFull,       // Double Header/Mulit Header Info ver 3
         LocoInfoNormAddy,            // Loco Info Response extra data
         LocoInfoDHAddy,              // Loco Info Response extra data
         LocoInfoMUBaseAddy,          // Loco Info Response extra data
         LocoInfoMUAddy,              // Loco Info Response extra data
         LocoInfoNoAddy,              // Loco Info Response extra data
         LocoTakenOverV3,             // Loco taken over by another xnet device.  Broadcast
         FuncStatusResp,              // Extra data
         SetLIAddy,                   // Response from setting LI100 series XPressNet Address
         SetLIBAUD,                   // Response from setting LI100 series XPressNet Address
         Unknown
      };

      #endregion

      #region Constructors

      private LenzCommand()
      {
         this.IsResponseReceived = false;
         this.IsBroadcastCommand = false;
         this.RequestData = null;
         this.ResponseData = null;
         this.CommandType = CommandTypes.Unknown;
      }

      #endregion

      #region Properties

      internal byte[] RequestData { get; private set; }

      internal byte[] ResponseData { get; private set; }

      /// <summary>
      /// Gets a value indicating if the command corresponds 
      /// to a broadcast command sent from the digital system.
      /// </summary>
      public bool IsResponseReceived { get; private set; }

      /// <summary>
      /// Gets a value indicating if the command corresponds 
      /// to a broadcast command sent from the digital system.
      /// </summary>
      public bool IsBroadcastCommand { get; private set; }

      /// <summary>
      /// Gets the type of received response.
      /// </summary>
      public CommandTypes CommandType { get; private set; }

      #endregion

      #region Methods

      public void SetRequestData(CommandTypes commandType, byte[] data)
      {
         this.IsBroadcastCommand = false;
         this.RequestData = data;
         this.ResponseData = null;
         this.CommandType = commandType;
      }

      /// <summary>
      /// Devuelve una instancia de LenzResponse.
      /// </summary>
      /// <param name="type">Tipo de respuesta recibida.</param>
      /// <param name="data">Información /bytes) recibida.</param>
      public bool SetResponseData(byte[] data)
      {
         // Controla el caso de no tener datos
         if (data == null)
         {
            this.CommandType = CommandTypes.Unknown;
            return false;
         }

         // Comprueba que los dos bytes corresponden a los frames LI-USB
         if (data[0] == 0xFF && (data[1] == 0xFD || data[1] == 0xFE))
         {
            // Copia los datos quitando los dos bytes (frame)
            this.ResponseData = this.RemoveFrame(data);

            // Check if response if of the same wanted type
            if (this.CommandType != this.GetResponseType(this.ResponseData))
            {
               return false;
            }

            // Check the integrity of the data received
            this.IsResponseReceived = this.CheckData(this.ResponseData);

            return this.IsResponseReceived;
         }
         else
         {
            this.CommandType = CommandTypes.Unknown;
            return false;
         }
      }

      /// <summary>
      /// Devuelve una cadena de texto que representa los bytes recibidos.
      /// </summary>
      public override string ToString()
      {
         string resp = string.Empty;

         for (int i = 0; i < this.ResponseData.Length - 1; i++)
         {
            resp += string.Format("{0:x2} ", this.ResponseData[i]);
         }

         return resp.Trim();
      }

      #endregion

      #region Static Members

      public static LenzCommand CreateCommand(CommandTypes commandType, byte[] data)
      {
         LenzCommand cmd = new LenzCommand();
         cmd.SetRequestData(commandType, data);

         return cmd;
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Copia los datos recibidos a un nuevo array descartando los dos bytes iniciales (frame)
      /// </summary>
      /// <param name="data">Array original recibido desde el sistema digital.</param>
      /// <returns>Un array de bytes que contiene los datos de la respuesta sin los dos bytes iniciales (frame).</returns>
      private byte[] RemoveFrame(byte[] data)
      {
         // Genera el nuevo array
         byte[] dataOk = new byte[data.Length - 2];

         for (int i = 2; i < dataOk.Length; i++)
         {
            dataOk[i - 2] = data[i];
         }

         return dataOk;
      }

      /// <summary>
      /// Devuelve un valor que indica si los datos recibidos son correctos.
      /// </summary>
      /// <remarks>
      /// Un paquete de datos tiene el siguiente formato:
      /// 
      /// [tipo] [dato1] [dato2] ... [datoN] [XOr]
      /// 
      /// Para determinar si los datos son correctos se debe realizar la operación XOr entre todos los datos (incluiendo
      /// el byte [tipo]) y el resultado debe concidir con [XOr]. Veamos un ejemplo:
      /// 
      /// EL PC manda el comando 0xF0 0xF0 (información del sistema)
      /// EL sistema devuelve: 0x02 0x30 0x01 0x33
      /// 
      /// El cálculse será: ((0x02 xor 0x30) xor 0x01) = 0x33
      /// </remarks>
      private bool CheckData(byte[] data)
      {
         int xor = 0;

         for (int i = 0; i < data.Length - 1; i++)
         {
            xor ^= data[i];
         }

         return (xor == data[data.Length - 1]);
      }

      /// <summary>
      /// Obtiene el tipo de respuesta que envia el sistema digital.
      /// </summary>
      private CommandTypes GetResponseType(byte[] data)
      {
         switch (data[0])
         {
            // Comandos simples (un byte)
            case 0x02: return CommandTypes.LIVersion;
            case 0x42: return CommandTypes.Feedback1Addy;
            case 0x44: return CommandTypes.Feedback2Addy;
            case 0x46: return CommandTypes.Feedback3Addy;
            case 0x48: return CommandTypes.Feedback4Addy;
            case 0x4A: return CommandTypes.Feedback5Addy;
            case 0x4C: return CommandTypes.Feedback6Addy;
            case 0x4E: return CommandTypes.Feedback7Addy;
            case 0x83: return CommandTypes.LocoInfoAvailV1;
            case 0x84: return CommandTypes.LocoInfoAvailV2;
            case 0xA3: return CommandTypes.LocoTakenOverV1;
            case 0xA4: return CommandTypes.LocoTakenOverV2;
            case 0xE2: return CommandTypes.MULocoInfo2;
            case 0xE4: return CommandTypes.LocoInfo;
            case 0xE5: return CommandTypes.MULocoInfo;
            case 0xE6: return CommandTypes.DHLocoInfo;

            // Comandos compuestos (2 bytes)
            case 0x01:
               {
                  switch (data[1])
                  {
                     case 0x01: return CommandTypes.LITimeoutPC;
                     case 0x02: return CommandTypes.LITimeoutCMD;
                     case 0x03: return CommandTypes.LIErrorUnknown;
                     case 0x04: return CommandTypes.LIOK;
                     case 0x05: return CommandTypes.LINotTimeSlot;
                     case 0x06: return CommandTypes.LIBufferOverflow;
                     default: return CommandTypes.Unknown;
                  }
               }
            case 0x61:
               {
                  switch (data[1])
                  {
                     case 0x00: return CommandTypes.TrackPowerOff;
                     case 0x01: return CommandTypes.NormalOpResume;
                     case 0x02: return CommandTypes.SMEntry;
                     case 0x11: return CommandTypes.SMCMDProgReady;
                     case 0x12: return CommandTypes.SMShortCircuit;
                     case 0x13: return CommandTypes.SMDataByteNotFound;
                     case 0x1F: return CommandTypes.SMCMDProgBusy;
                     case 0x80: return CommandTypes.CMDTransferError;
                     case 0x81: return CommandTypes.CMDBusy;
                     case 0x82: return CommandTypes.CMDNotSupported;
                     case 0x83: return CommandTypes.DHErrorLocoNoOp;
                     case 0x84: return CommandTypes.DHErrorLocoBusy;
                     case 0x85: return CommandTypes.DHErrorLocoInAnotherDH;
                     case 0x86: return CommandTypes.DHErrorLocoMoving;
                     default: return CommandTypes.Unknown;
                  }
               }
            case 0x62:
               {
                  switch (data[1])
                  {
                     case 0x21: return CommandTypes.SoftwareVer1_2;
                     case 0x22: return CommandTypes.CMDStatus;
                     default: return CommandTypes.Unknown;
                  }
               }
            case 0x63:
               {
                  switch (data[1])
                  {
                     case 0x10: return CommandTypes.SMRegisterPageMode;
                     case 0x14: return CommandTypes.SMDirectCV;
                     case 0x21: return CommandTypes.SoftwareVer3;
                     default: return CommandTypes.Unknown;
                  }
               }
            case 0x81:
               {
                  switch (data[1])
                  {
                     case 0x00: return CommandTypes.EmergencyStop;
                     default: return CommandTypes.Unknown;
                  }
               }
            case 0xC5:
               {
                  switch (data[1])
                  {
                     case 0x04: return CommandTypes.DHAvailableV1;
                     case 0x05: return CommandTypes.DHTakenOverV1;
                     default: return CommandTypes.Unknown;
                  }
               }
            case 0xC6:
               {
                  switch (data[1])
                  {
                     case 0x04: return CommandTypes.DHAvailableV2;
                     case 0x05: return CommandTypes.DHTakenOverV2;
                     default: return CommandTypes.Unknown;
                  }
               }
            case 0xE1:
               {
                  switch (data[1])
                  {
                     case 0x81: return CommandTypes.MUDHErrorLocoNoOp;
                     case 0x82: return CommandTypes.MUDHErrorLocoBusy;
                     case 0x83: return CommandTypes.MHDHErrorLocoInAnotherMUDH;
                     case 0x84: return CommandTypes.MHDHErrorLocoMoving;
                     case 0x85: return CommandTypes.MHDHErrorLocoNotInMU;
                     case 0x86: return CommandTypes.MHDHErrorLocoAddyNotMUAddy;
                     case 0x87: return CommandTypes.MHDHErrorCanNotDeleteLoco;
                     case 0x88: return CommandTypes.MHDHErrorCMDStackFull;
                     default: return CommandTypes.Unknown;
                  }
               }
            case 0xE3:
               {
                  switch (data[1])
                  {
                     case 0x30: return CommandTypes.LocoInfoNormAddy;
                     case 0x31: return CommandTypes.LocoInfoDHAddy;
                     case 0x32: return CommandTypes.LocoInfoMUBaseAddy;
                     case 0x33: return CommandTypes.LocoInfoMUAddy;
                     case 0x34: return CommandTypes.LocoInfoNoAddy;
                     case 0x40: return CommandTypes.LocoTakenOverV3;
                     case 0x50: return CommandTypes.FuncStatusResp;
                     default: return CommandTypes.Unknown;
                  }
               }
            case 0xF2:
               {
                  switch (data[1])
                  {
                     case 0x01: return CommandTypes.SetLIAddy;
                     case 0x02: return CommandTypes.SetLIBAUD;
                     default: return CommandTypes.Unknown;
                  }
               }

            default: return CommandTypes.Unknown;
         }
      }

      #endregion

   }
}
