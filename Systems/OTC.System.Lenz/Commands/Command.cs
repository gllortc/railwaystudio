using System;

namespace Rwm.OTC.Systems.Lenz.Commands
{
   public abstract class Command
   {

      #region Properties

      public bool IsResponseReceived { get; private set; }

      internal byte[] RequestData { get; set; }

      internal byte[] ResponseHeaderData { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Parse received data from the digital system.
      /// </summary>
      /// <param name="recvData">Received data.</param>
      /// <returns><c>true</c> if the data is correct, otherwise returns <c>false</c>.</returns>
      public bool ParseCommandData(byte[] recvData)
      {
         // Check received data type
         if (recvData == null)
         {
            throw new Exception("Bad data received: " + recvData.ToString());
         }

         // Remove XPressNet frame
         recvData = RemoveFrame(recvData);

         // Check data integrity 
         if (!this.CheckData(recvData))
         {
            throw new Exception("Data checksum error: " + recvData.ToString());
         }

         // Check expected header 
         if (!this.CheckHeader(recvData))
         {
            throw new Exception("Unexpected data received: " + recvData.ToString());
         }

         this.IsResponseReceived = GetCommandData(recvData);

         return IsResponseReceived;
      }

      /// <summary>
      /// Transform the received data into the Lenz command response.
      /// </summary>
      /// <param name="data">Data received (without Lenz fixed frame).</param>
      /// <returns><c>true</c> if the data is correct, otherwise returns <c>false</c>.</returns>
      public virtual bool GetCommandData(byte[] data)
      {
         return true;
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
      /// Check the header received.
      /// </summary>
      private bool CheckHeader(byte[] data)
      {
         bool ok = false;

         if (data.Length < this.ResponseHeaderData.Length)
         {
            return false;
         }

         for (int i = 0; i < this.ResponseHeaderData.Length; i++)
         {
            ok = ok & (data[i] == this.ResponseHeaderData[i]);
         }

         return ok;
      }

      ///// <summary>
      ///// Obtiene el tipo de respuesta que envia el sistema digital.
      ///// </summary>
      //private SystemResponses GetResponseType(byte[] data)
      //{
      //   switch (data[0])
      //   {
      //      // Comandos simples (un byte)
      //      case 0x02: return SystemResponses.RespLIVersion;
      //      case 0x42: return SystemResponses.RespFeedback1Addy;
      //      case 0x44: return SystemResponses.RespFeedback2Addy;
      //      case 0x46: return SystemResponses.RespFeedback3Addy;
      //      case 0x48: return SystemResponses.RespFeedback4Addy;
      //      case 0x4A: return SystemResponses.RespFeedback5Addy;
      //      case 0x4C: return SystemResponses.RespFeedback6Addy;
      //      case 0x4E: return SystemResponses.RespFeedback7Addy;
      //      case 0x83: return SystemResponses.RespLocoInfoAvailV1;
      //      case 0x84: return SystemResponses.RespLocoInfoAvailV2;
      //      case 0xA3: return SystemResponses.RespLocoTakenOverV1;
      //      case 0xA4: return SystemResponses.RespLocoTakenOverV2;
      //      case 0xE2: return SystemResponses.RespMULocoInfo2;
      //      case 0xE4: return SystemResponses.RespLocoInfo;
      //      case 0xE5: return SystemResponses.RespMULocoInfo;
      //      case 0xE6: return SystemResponses.RespDHLocoInfo;

      //      // Comandos compuestos (2 bytes)
      //      case 0x01:
      //         {
      //            switch (data[1])
      //            {
      //               case 0x01: return SystemResponses.RespLITimeoutPC;
      //               case 0x02: return SystemResponses.RespLITimeoutCMD;
      //               case 0x03: return SystemResponses.RespLIErrorUnknown;
      //               case 0x04: return SystemResponses.RespLIOK;
      //               case 0x05: return SystemResponses.RespLINotTimeSlot;
      //               case 0x06: return SystemResponses.RespLIBufferOverflow;
      //               default: return SystemResponses.Unknown;
      //            }
      //         }
      //      case 0x61:
      //         {
      //            switch (data[1])
      //            {
      //               case 0x00: return SystemResponses.RespTrackPowerOff;
      //               case 0x01: return SystemResponses.RespNormalOpResume;
      //               case 0x02: return SystemResponses.RespSMEntry;
      //               case 0x11: return SystemResponses.RespSMCMDProgReady;
      //               case 0x12: return SystemResponses.RespSMShortCircuit;
      //               case 0x13: return SystemResponses.RespSMDataByteNotFound;
      //               case 0x1F: return SystemResponses.RespSMCMDProgBusy;
      //               case 0x80: return SystemResponses.RespCMDTransferError;
      //               case 0x81: return SystemResponses.RespCMDBusy;
      //               case 0x82: return SystemResponses.RespCMDNotSupported;
      //               case 0x83: return SystemResponses.RespDHErrorLocoNoOp;
      //               case 0x84: return SystemResponses.RespDHErrorLocoBusy;
      //               case 0x85: return SystemResponses.RespDHErrorLocoInAnotherDH;
      //               case 0x86: return SystemResponses.RespDHErrorLocoMoving;
      //               default: return SystemResponses.Unknown;
      //            }
      //         }
      //      case 0x62:
      //         {
      //            switch (data[1])
      //            {
      //               case 0x21: return SystemResponses.RespSoftwareVer1_2;
      //               case 0x22: return SystemResponses.RespCMDStatus;
      //               default: return SystemResponses.Unknown;
      //            }
      //         }
      //      case 0x63:
      //         {
      //            switch (data[1])
      //            {
      //               case 0x10: return SystemResponses.RespSMRegisterPageMode;
      //               case 0x14: return SystemResponses.RespSMDirectCV;
      //               case 0x21: return SystemResponses.RespSoftwareVer3;
      //               default: return SystemResponses.Unknown;
      //            }
      //         }
      //      case 0x81:
      //         {
      //            switch (data[1])
      //            {
      //               case 0x00: return SystemResponses.RespEmergencyStop;
      //               default: return SystemResponses.Unknown;
      //            }
      //         }
      //      case 0xC5:
      //         {
      //            switch (data[1])
      //            {
      //               case 0x04: return SystemResponses.RespDHAvailableV1;
      //               case 0x05: return SystemResponses.RespDHTakenOverV1;
      //               default: return SystemResponses.Unknown;
      //            }
      //         }
      //      case 0xC6:
      //         {
      //            switch (data[1])
      //            {
      //               case 0x04: return SystemResponses.RespDHAvailableV2;
      //               case 0x05: return SystemResponses.RespDHTakenOverV2;
      //               default: return SystemResponses.Unknown;
      //            }
      //         }
      //      case 0xE1:
      //         {
      //            switch (data[1])
      //            {
      //               case 0x81: return SystemResponses.RespMUDHErrorLocoNoOp;
      //               case 0x82: return SystemResponses.RespMUDHErrorLocoBusy;
      //               case 0x83: return SystemResponses.RespMHDHErrorLocoInAnotherMUDH;
      //               case 0x84: return SystemResponses.RespMHDHErrorLocoMoving;
      //               case 0x85: return SystemResponses.RespMHDHErrorLocoNotInMU;
      //               case 0x86: return SystemResponses.RespMHDHErrorLocoAddyNotMUAddy;
      //               case 0x87: return SystemResponses.RespMHDHErrorCanNotDeleteLoco;
      //               case 0x88: return SystemResponses.RespMHDHErrorCMDStackFull;
      //               default: return SystemResponses.Unknown;
      //            }
      //         }
      //      case 0xE3:
      //         {
      //            switch (data[1])
      //            {
      //               case 0x30: return SystemResponses.RespLocoInfoNormAddy;
      //               case 0x31: return SystemResponses.RespLocoInfoDHAddy;
      //               case 0x32: return SystemResponses.RespLocoInfoMUBaseAddy;
      //               case 0x33: return SystemResponses.RespLocoInfoMUAddy;
      //               case 0x34: return SystemResponses.RespLocoInfoNoAddy;
      //               case 0x40: return SystemResponses.RespLocoTakenOverV3;
      //               case 0x50: return SystemResponses.RespFuncStatusResp;
      //               default: return SystemResponses.Unknown;
      //            }
      //         }
      //      case 0xF2:
      //         {
      //            switch (data[1])
      //            {
      //               case 0x01: return SystemResponses.RespSetLIAddy;
      //               case 0x02: return SystemResponses.RespSetLIBAUD;
      //               default: return SystemResponses.Unknown;
      //            }
      //         }

      //      default: return SystemResponses.Unknown;
      //   }
      //}

      #endregion

   }
}
