using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwm.OTC.Systems.Lenz
{
   public enum SystemResponses
   {
      RespLIVersion,                   // LI Hardware version  extra data
      RespFeedback1Addy,               // Feedback Data extra data
      RespFeedback2Addy,               // Feedback Data extra data
      RespFeedback3Addy,               // Feedback Data extra data
      RespFeedback4Addy,               // Feedback Data extra data
      RespFeedback5Addy,               // Feedback Data extra data
      RespFeedback6Addy,               // Feedback Data extra data
      RespFeedback7Addy,               // Feedback Data extra data
      RespLocoInfoAvailV1,             // Extra data ver 1
      RespLocoInfoAvailV2,             // Extra data ver 2
      RespLocoTakenOverV1,             // Extra data ver 1
      RespLocoTakenOverV2,             // Extra data ver 2
      RespMULocoInfo2,                 // Extra data
      RespLocoInfo,                    // Extra data
      RespMULocoInfo,                  // Extra data
      RespDHLocoInfo,                  // Extra data
      RespLITimeoutPC,                 // LI Broadcast
      RespLITimeoutCMD,                // LI Broadcast
      RespLIErrorUnknown,              // LI Broadcast
      RespLIOK,                        // LI Broadcast
      RespLINotTimeSlot,               // LI Broadcast
      RespLIBufferOverflow,            // LI Broadcast
      RespTrackPowerOff,               // CMD Broadcast
      RespNormalOpResume,              // CMD Broadcast
      RespSMEntry,                     // CMD Broadcast
      RespSMCMDProgReady,              // Service Mode Response
      RespSMShortCircuit,              // Service Mode Response
      RespSMDataByteNotFound,          // Service Mode Response
      RespSMCMDProgBusy,               // Service Mode Response
      RespCMDTransferError,            // CMD Error
      RespCMDBusy,                     // CMD Error
      RespCMDNotSupported,             // CMD Error
      RespDHErrorLocoNoOp,             // Dual Header Error Ver 1 & 2
      RespDHErrorLocoBusy,             // Dual Header Error Ver 1 & 2
      RespDHErrorLocoInAnotherDH,      // Dual Header Error Ver 1 & 2
      RespDHErrorLocoMoving,           // Dual Header Error Ver 1 & 2
      RespSoftwareVer1_2,              // Extra data-VER 1 & 2
      RespCMDStatus,                   // Service Mode Response w/extra data
      RespSMRegisterPageMode,          // Service Mode Response w/extra data
      RespSMDirectCV,                  // Extra data
      RespSoftwareVer3,                // Extra data
      RespEmergencyStop,               // CMD Broadcast
      RespDHAvailableV1,               // Double Header Info extra data ver 1
      RespDHTakenOverV1,               // Double Header Info extra data ver 1
      RespDHAvailableV2,               // Double Header Info extra data ver 2
      RespDHTakenOverV2,               // Double Header Info extra data ver 2
      RespMUDHErrorLocoNoOp,           // Double Header/Mulit Header Info ver 3
      RespMUDHErrorLocoBusy,           // Double Header/Mulit Header Info ver 3
      RespMHDHErrorLocoInAnotherMUDH,  // Double Header/Mulit Header Info ver 3
      RespMHDHErrorLocoMoving,         // Double Header/Mulit Header Info ver 3
      RespMHDHErrorLocoNotInMU,        // Double Header/Mulit Header Info ver 3
      RespMHDHErrorLocoAddyNotMUAddy,  // Double Header/Mulit Header Info ver 3
      RespMHDHErrorCanNotDeleteLoco,   // Double Header/Mulit Header Info ver 3
      RespMHDHErrorCMDStackFull,       // Double Header/Mulit Header Info ver 3
      RespLocoInfoNormAddy,            // Loco Info Response extra data
      RespLocoInfoDHAddy,              // Loco Info Response extra data
      RespLocoInfoMUBaseAddy,          // Loco Info Response extra data
      RespLocoInfoMUAddy,              // Loco Info Response extra data
      RespLocoInfoNoAddy,              // Loco Info Response extra data
      RespLocoTakenOverV3,             // Loco taken over by another xnet device.  Broadcast
      RespFuncStatusResp,              // Extra data
      RespSetLIAddy,                   // Response from setting LI100 series XPressNet Address
      RespSetLIBAUD,                   // Response from setting LI100 series XPressNet Address
      Unknown
   };

   /// <summary>
   /// Implementa una respuesta del sistema digital.
   /// </summary>
   public class LenzResponse
   {
      private bool _dataOk;
      private byte[] _data;
      private SystemResponses _type;

      /// <summary>
      /// Devuelve una instancia de LenzResponse.
      /// </summary>
      /// <param name="type">Tipo de respuesta recibida.</param>
      /// <param name="data">Información /bytes) recibida.</param>
      public LenzResponse(byte[] data)
      {
         // Controla el caso de no tener datos
         if (data == null)
         {
            _type = SystemResponses.Unknown;
            _dataOk = false;
            return;
         }

         // Comprueba que los dos bytes corresponden a los frames LI-USB
         if (data[0] == 0xFF && (data[1] == 0xFD || data[1] == 0xFE))
         {
            // Copia los datos quitando los dos bytes (frame)
            _data = RemoveFrame(data);

            // Obtiene el tipo 
            _type = GetResponseType();

            // Determina si los datos son válidos
            _dataOk = CheckData();
         }
         else
         {
            _type = SystemResponses.Unknown;
            _dataOk = false;

            // throw new Exception("Los datos recibidos son incorrectos.");
         }
      }

      /// <summary>
      /// Devuelve el array de bytes recibidos del sistema digital.
      /// </summary>
      public byte[] Data
      {
         get { return _data; }
      }

      /// <summary>
      /// Indica si los datos son correctos.
      /// </summary>
      public bool IsDataOk
      {
         get { return _dataOk; }
      }

      /// <summary>
      /// Tipo de respuesta detectada.
      /// </summary>
      public SystemResponses Type
      {
         get { return _type; }
      }

      /// <summary>
      /// Devuelve una cadena de texto que representa los bytes recibidos.
      /// </summary>
      public new string ToString()
      {
         string resp = "";

         for (int i = 0; i < _data.Length - 1; i++)
            resp += string.Format("{0:x2} ", _data[i]);

         return resp.Trim();
      }

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
            dataOk[i - 2] = data[i];

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
      private bool CheckData()
      {
         int xor = 0;

         for (int i = 0; i < _data.Length - 1; i++)
            xor ^= _data[i];

         return (xor == _data[_data.Length - 1]);
      }

      /// <summary>
      /// Obtiene el tipo de respuesta que envia el sistema digital.
      /// </summary>
      private SystemResponses GetResponseType()
      {
         switch (_data[0])
         {
            // Comandos simples (un byte)
            case 0x02: return SystemResponses.RespLIVersion;
            case 0x42: return SystemResponses.RespFeedback1Addy;
            case 0x44: return SystemResponses.RespFeedback2Addy;
            case 0x46: return SystemResponses.RespFeedback3Addy;
            case 0x48: return SystemResponses.RespFeedback4Addy;
            case 0x4A: return SystemResponses.RespFeedback5Addy;
            case 0x4C: return SystemResponses.RespFeedback6Addy;
            case 0x4E: return SystemResponses.RespFeedback7Addy;
            case 0x83: return SystemResponses.RespLocoInfoAvailV1;
            case 0x84: return SystemResponses.RespLocoInfoAvailV2;
            case 0xA3: return SystemResponses.RespLocoTakenOverV1;
            case 0xA4: return SystemResponses.RespLocoTakenOverV2;
            case 0xE2: return SystemResponses.RespMULocoInfo2;
            case 0xE4: return SystemResponses.RespLocoInfo;
            case 0xE5: return SystemResponses.RespMULocoInfo;
            case 0xE6: return SystemResponses.RespDHLocoInfo;

            // Comandos compuestos (2 bytes)
            case 0x01:
               {
                  switch (_data[1])
                  {
                     case 0x01: return SystemResponses.RespLITimeoutPC;
                     case 0x02: return SystemResponses.RespLITimeoutCMD;
                     case 0x03: return SystemResponses.RespLIErrorUnknown;
                     case 0x04: return SystemResponses.RespLIOK;
                     case 0x05: return SystemResponses.RespLINotTimeSlot;
                     case 0x06: return SystemResponses.RespLIBufferOverflow;
                     default: return SystemResponses.Unknown;
                  }
               }
            case 0x61:
               {
                  switch (_data[1])
                  {
                     case 0x00: return SystemResponses.RespTrackPowerOff;
                     case 0x01: return SystemResponses.RespNormalOpResume;
                     case 0x02: return SystemResponses.RespSMEntry;
                     case 0x11: return SystemResponses.RespSMCMDProgReady;
                     case 0x12: return SystemResponses.RespSMShortCircuit;
                     case 0x13: return SystemResponses.RespSMDataByteNotFound;
                     case 0x1F: return SystemResponses.RespSMCMDProgBusy;
                     case 0x80: return SystemResponses.RespCMDTransferError;
                     case 0x81: return SystemResponses.RespCMDBusy;
                     case 0x82: return SystemResponses.RespCMDNotSupported;
                     case 0x83: return SystemResponses.RespDHErrorLocoNoOp;
                     case 0x84: return SystemResponses.RespDHErrorLocoBusy;
                     case 0x85: return SystemResponses.RespDHErrorLocoInAnotherDH;
                     case 0x86: return SystemResponses.RespDHErrorLocoMoving;
                     default: return SystemResponses.Unknown;
                  }
               }
            case 0x62:
               {
                  switch (_data[1])
                  {
                     case 0x21: return SystemResponses.RespSoftwareVer1_2;
                     case 0x22: return SystemResponses.RespCMDStatus;
                     default: return SystemResponses.Unknown;
                  }
               }
            case 0x63:
               {
                  switch (_data[1])
                  {
                     case 0x10: return SystemResponses.RespSMRegisterPageMode;
                     case 0x14: return SystemResponses.RespSMDirectCV;
                     case 0x21: return SystemResponses.RespSoftwareVer3;
                     default: return SystemResponses.Unknown;
                  }
               }
            case 0x81:
               {
                  switch (_data[1])
                  {
                     case 0x00: return SystemResponses.RespEmergencyStop;
                     default: return SystemResponses.Unknown;
                  }
               }
            case 0xC5:
               {
                  switch (_data[1])
                  {
                     case 0x04: return SystemResponses.RespDHAvailableV1;
                     case 0x05: return SystemResponses.RespDHTakenOverV1;
                     default: return SystemResponses.Unknown;
                  }
               }
            case 0xC6:
               {
                  switch (_data[1])
                  {
                     case 0x04: return SystemResponses.RespDHAvailableV2;
                     case 0x05: return SystemResponses.RespDHTakenOverV2;
                     default: return SystemResponses.Unknown;
                  }
               }
            case 0xE1:
               {
                  switch (_data[1])
                  {
                     case 0x81: return SystemResponses.RespMUDHErrorLocoNoOp;
                     case 0x82: return SystemResponses.RespMUDHErrorLocoBusy;
                     case 0x83: return SystemResponses.RespMHDHErrorLocoInAnotherMUDH;
                     case 0x84: return SystemResponses.RespMHDHErrorLocoMoving;
                     case 0x85: return SystemResponses.RespMHDHErrorLocoNotInMU;
                     case 0x86: return SystemResponses.RespMHDHErrorLocoAddyNotMUAddy;
                     case 0x87: return SystemResponses.RespMHDHErrorCanNotDeleteLoco;
                     case 0x88: return SystemResponses.RespMHDHErrorCMDStackFull;
                     default: return SystemResponses.Unknown;
                  }
               }
            case 0xE3:
               {
                  switch (_data[1])
                  {
                     case 0x30: return SystemResponses.RespLocoInfoNormAddy;
                     case 0x31: return SystemResponses.RespLocoInfoDHAddy;
                     case 0x32: return SystemResponses.RespLocoInfoMUBaseAddy;
                     case 0x33: return SystemResponses.RespLocoInfoMUAddy;
                     case 0x34: return SystemResponses.RespLocoInfoNoAddy;
                     case 0x40: return SystemResponses.RespLocoTakenOverV3;
                     case 0x50: return SystemResponses.RespFuncStatusResp;
                     default: return SystemResponses.Unknown;
                  }
               }
            case 0xF2:
               {
                  switch (_data[1])
                  {
                     case 0x01: return SystemResponses.RespSetLIAddy;
                     case 0x02: return SystemResponses.RespSetLIBAUD;
                     default: return SystemResponses.Unknown;
                  }
               }

            default: return SystemResponses.Unknown;
         }
      }
   }
}
