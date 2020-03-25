using Rwm.Otc.Math;
using Rwm.Otc.Systems;
using System;
using System.Diagnostics;
using System.IO.Ports;

namespace com.rwm.otc.systems.lenz
{
   public class LenzComm : IDigitalSystem
   {
      const int FEEDBACK_RANGE_BASE = 64;
      const int FEEDBACK_RANGE_BEGIN = 66;
      const int FEEDBACK_RANGE_END = 78;
      const int FEEDBACK_RANGE_1 = 66;
      const int FEEDBACK_RANGE_2 = 68;
      const int FEEDBACK_RANGE_3 = 70;
      const int FEEDBACK_RANGE_4 = 72;
      const int FEEDBACK_RANGE_5 = 74;
      const int FEEDBACK_RANGE_6 = 76;
      const int FEEDBACK_RANGE_7 = 78;
      const int MAX_FEEDBACK_BYTES = 14;
      const int XNET1AND2VER = 0x62;
      const int XNET3VER = 0x63;
      const int XNETSTATUS = 0x62;
      const int MIN_BROADCAST_MESSAGE_SIZE = 3;
      const int MAX_BROADCAST_MESSAGE_SIZE = 16;

      private bool _connected = false;

      private SerialPort _port = null;
      private LenzResponse _response = null;

      private string _ifName = "";
      private string _ifHwVer = "";
      private string _ifSwVer = "";
      private string _dsName = "";
      private string _dsVer = "";

      private string _portName = "";
      private int _portSpeed = 9600;

      private int _reqTimeout = 90;

      /// <summary>
      /// Devuelve una instancia de LenzComm.
      /// </summary>
      public LenzComm()
      {
         _port = new SerialPort();
         _response = new LenzResponse(null);
      }

      /// <summary>
      /// Devuelve una instancia de LenzComm.
      /// </summary>
      /// <param name="portName">Nombre identificativo del puerto al que está conectado el sistema digital (COM1).</param>
      /// <param name="portSpeed">Velocidad a la que se comunicarán PC y sistema digital (en baudios).</param>
      /// <param name="reqTimeout">Tiempo máximo de espera después de realizar una petición al sistema digital.</param>
      public LenzComm(string portName, int portSpeed, int reqTimeout)
      {
         _port = new SerialPort();
         _response = new LenzResponse(null);

         _portName = portName;
         _portSpeed = portSpeed;
         _reqTimeout = reqTimeout;
      }

      /// <summary>
      /// Indica si la conexión al sistema digital está abierta.
      /// </summary>
      public bool Connected
      {
         get { return _connected; }
      }

      /// <summary>
      /// Establece o devuelve el nombre del puerto série/USB al que se conecta el sistema digital (por ejemplo, COM2).
      /// </summary>
      public string PortName
      {
         get { return _portName; }
         set { _portName = value; }
      }

      /// <summary>
      /// Establece o devuelve la velocidad (en baudios) al que se comunicarán el PC y el sistema digital.
      /// </summary>
      public int PortSpeed
      {
         get { return _portSpeed; }
         set { _portSpeed = value; }
      }

      /// <summary>
      /// Establece o devuelve el tiempo máximo de espera después de realizar una petición al sistema digital.
      /// </summary>
      public int RequestTimeout
      {
         get { return _reqTimeout; }
         set { _reqTimeout = value; }
      }

      /// <summary>
      /// Devuelve una descripción del sistema digital y del interface.
      /// </summary>
      public string Description
      {
         get 
         {
            string name = "";

            if (!string.IsNullOrEmpty(_dsName)) name += _dsName + " Ver " + _dsVer;
            if (!string.IsNullOrEmpty(_ifName)) name += " (" + _ifName + " Ver HW:" + _ifHwVer + " SW:" + _ifSwVer + ")";

            return name;
         }
      }

      /// <summary>
      /// Abre el canal de comunicaciones con el interface Lenz.
      /// </summary>
      /// <param name="name">Nombre del puerto (por ejemplo: COM2).</param>
      /// <param name="baudRate">Velocidad de comunicación.</param>
      public void Open()
      {
         // Asegura que el puerto se encuentre cerrado
         Close();

         // Abre el puerto
         try
         {
            _port.DataBits = 8;
            _port.Parity = Parity.None;
            _port.StopBits = StopBits.One;
            _port.PortName = _portName;
            _port.BaudRate = _portSpeed;
            _port.Open();

            // Agrega los eventos de control de datos y errores recibidos
            _port.DataReceived += new SerialDataReceivedEventHandler(PortDataReceived);
         }
         catch (Exception ex)
         {
            throw new Exception("No se puede abrir el puerto " + _portName + ": " + ex.Message, ex);
         }

         try
         {
            // Obtiene información del Interface
            GetInterfaceInfo();

            // Obtiene información de la central
            GetSystemInfo();
         }
         catch (Exception ex)
         {
            // Asegura que el puerto quede cerrado
            Close();

            throw ex;
         }

         _connected = true;
      }

      /// <summary>
      /// Cierra el puerto de comunicaciones.
      /// </summary>
      public void Close()
      {
         if (_port.IsOpen) _port.Close();

         _connected = false;
      }

      /// <summary>
      /// Elimina la tensión en la via.
      /// </summary>
      public void TrackPowerOff()
      {
         // Comprueba que el puerto se encuentre abierto
         CheckPortStatus();

         // Envia los datos al interface
         try
         {
            byte[] cmdData = { 0xFF, 0xFE, 0x21, 0x80, 0xA1 };
            _port.Write(cmdData, 0, cmdData.Length);
         }
         catch (Exception ex)
         {
            throw new Exception("Write error: " + ex.Message, ex);
         }

         // Espera a la respuesta
         WaitForResponse(SystemResponses.RespTrackPowerOff);
      }

      /// <summary>
      /// Indica a la central que vuelva a poner tensión en la via y a emitir paquetes DCC (elimina cualquier Emergency Stop activo).
      /// </summary>
      public void ResumeOperations()
      {
         // Comprueba que el puerto se encuentre abierto
         CheckPortStatus();

         // Envia los datos al interface
         try
         {
            byte[] cmdData = { 0xFF, 0xFE, 0x21, 0x81, 0xA0 };
            _port.Write(cmdData, 0, cmdData.Length);
         }
         catch (Exception ex)
         {
            throw new Exception("Write error: " + ex.Message, ex);
         }

         // Espera a la respuesta
         WaitForResponse(SystemResponses.RespNormalOpResume);
      }

      /// <summary>
      /// Obtiene la información del interface.
      /// </summary>
      public void GetInterfaceInfo()
      {
         // Comprueba que el puerto se encuentre abierto
         CheckPortStatus();

         // Envia los datos al interface
         try
         {
            byte[] cmdData = { 0xFF, 0xFE, 0xF0, 0xF0 };
            _port.Write(cmdData, 0, cmdData.Length);
         }
         catch (Exception ex)
         {
            throw new Exception("Write error: " + ex.Message, ex);
         }

         // Espera a la respuesta
         LenzResponse response = WaitForResponse(SystemResponses.RespLIVersion);

         // Trata los datos recibidos
         double hwVer = (double)((response.Data[1] & 0xF0) >> 4) + ((double)(response.Data[1] & 0x0F) / 10.0);
         double swVer = response.Data[2];

         _ifName = "LI-USB";        // Fijado pues este controlador sólo soporta LI-USB
         _ifHwVer = hwVer.ToString();
         _ifSwVer = swVer.ToString();
      }

      /// <summary>
      /// Obtiene la información de la central digital.
      /// </summary>
      /// <remarks>
      /// Sólo reconoce software de la versión 3 o superior (XpressNet). No soporta X-BUS.
      /// </remarks>
      public void GetSystemInfo()
      {
         byte[] byteRespVer = new byte[MAX_BROADCAST_MESSAGE_SIZE];

         // Comprueba que el puerto se encuentre abierto
         CheckPortStatus();

         // Envia los datos al interface
         try
         {
            byte[] cmdData = { 0xFF, 0xFE, 0x21, 0x21, 0x00 };
            _port.Write(cmdData, 0, cmdData.Length);
         }
         catch (Exception ex)
         {
            throw new Exception("Write error: " + ex.Message, ex);
         }

         // Espera a la respuesta
         LenzResponse response = WaitForResponse(SystemResponses.RespSoftwareVer3);
          
         // Trata los datos recibidos
         double ver = (double)((response.Data[2] & 0xF0) >> 4) + ((double)(response.Data[2] & 0x0F) / 10.0);
         _dsVer = ver.ToString();
         switch (response.Data[3])
         {
            case 0x00: _dsName = "LZ100"; break;
            case 0x01: _dsName = "LH200"; break;
            case 0x02: _dsName = "DPC (Compact o Commander)"; break;
            default: _dsName = "Modelo desconocido (no Lenz)"; break;
         }
      }

      /// <summary>
      /// Indica a la central digital que detenga todas las locomotoras, aunque seguirán activos los accesorios y otros sistemas.
      /// </summary>
      public void StopAllLocomotives()
      {
         // Comprueba que el puerto se encuentre abierto
         CheckPortStatus();

         // Envia los datos al interface
         try
         {
            byte[] cmdData = { 0xFF, 0xFE, 0x80, 0x80 };
            _port.Write(cmdData, 0, cmdData.Length);
         }
         catch (Exception ex)
         {
            throw new Exception("Write error: " + ex.Message, ex);
         }

         // Espera a la respuesta
         WaitForResponse(SystemResponses.RespEmergencyStop);
      }

      /// <summary>
      /// Indica a la central digital que detenga una determinada locomotora, aunque seguirán activos el resto de locomotoras y sistemas.
      /// </summary>
      /// <param name="address">Dirección de la locomotora a detener.</param>
      public void StopLocomotive(int address) 
      {
         // Comprueba que el puerto se encuentre abierto
         CheckPortStatus();

         // Comprueba los parámetros
         if (!LenzAddress.IsValidAddress(address))
            throw new Exception("La dirección proporcionada no es válida.");

         // Envia los datos al interface
         try
         {
            byte[] cmdData = { 0xFF, 0xFE, 0x92, 0x00, 0x00, 0x00 };

            LenzAddress add = new LenzAddress(address);
            cmdData[3] = add.HighAddress;
            cmdData[4] = add.LowAddress;
            cmdData[5] = (byte)Rwm.Otc.Math.Binary.Xor(cmdData, 2, 3);

            _port.Write(cmdData, 0, cmdData.Length);
         }
         catch (Exception ex)
         {
            throw new Exception("Write error: " + ex.Message, ex);
         }

         // Espera a la respuesta
         WaitForResponse(SystemResponses.RespLIOK);
      }

      /// <summary>
      /// Obtiene la información de estado de un descodificador de accesorios.
      /// </summary>
      /// <param name="address">Dirección del descodificador.</param>
      public OTCSysCmdAccessoryDecoderInfo GetTurnoutDecoderInfo(int address)
      {
         byte byteAddy = 0x00;
         byte byteNibble = 0x00;

         // Comprueba que el puerto se encuentre abierto
         CheckPortStatus();
         
         // Comprueba los parámetros
         if (!LenzAddress.IsValidAddress(address))
            throw new Exception("La dirección proporcionada no es válida.");

         // Envia los datos al interface
         try
         {
            byteAddy = (byte)(address / 4);
            byteNibble = (byte)(((byte)(((byte)(address % 4)) / 2) > 0) ? 0x81 : 0x80); // 0, 1 -> 0, 2, 3 -> 1

            byte[] cmdData = { 0xFF, 0xFE, 0x42, 0x00, 0x00, 0x00 };
            cmdData[3] = byteAddy;
            cmdData[4] = byteNibble;
            cmdData[5] = (byte)Binary.Xor(cmdData, 2, 3);

            _port.Write(cmdData, 0, cmdData.Length);
         }
         catch (Exception ex)
         {
            throw new Exception("Write error: " + ex.Message, ex);
         }

         // Espera a la respuesta
         LenzResponse response = WaitForResponse(SystemResponses.RespFeedback1Addy);

         // Trata los datos recibidos
         OTCSysCmdAccessoryDecoderInfo command = new OTCSysCmdAccessoryDecoderInfo(address);
         command.Nibble = byteNibble;

         byte byteHighNibble = (byte)(((byte)(response.Data[2] & 0x10) > 0) ? 0x81 : 0x80);
         if ((response.Data[1] == byteAddy) && (byteHighNibble == byteNibble)) 
         {
            command.Type = (OTCSysCmdAccessoryDecoderInfo.AccessoryTypes)((response.Data[2] & 0x60) >> 5);

            if (((byte)(address % 2)) > 0) 
            {
               // Left over means we want bits 2, 3 (second turnout)
               command.Position = (OTCSysCmdAccessoryDecoderInfo.AccessoryPosition)((response.Data[2] & 0X0C) >> 2);
            } 
            else
            {
               // No left over means we want bits 0, 1 (first turnout)
               command.Position = (OTCSysCmdAccessoryDecoderInfo.AccessoryPosition)(response.Data[2] & 0X03);                    
            }
         } 
         else 
         {
            throw new Exception("GetTurnoutDecoderInfo: Unexpected Response");
         }

         return command;
      }

      /// <summary>
      /// Cambia el estado de un accesorio.
      /// </summary>
      /// <param name="address">Dirección del accesorio.</param>
      /// <param name="turned"><code>True</code> si la aguja está desviada (o verde en semáforos).</param>
      /// <param name="activate">Indica una de las dos salidas del accesorio.</param>
      public void SetTurnoutPosition(int address, bool turned, bool activate)
      {
         // Comprueba que el puerto se encuentre abierto
         CheckPortStatus();

         // Comprueba los parámetros proporcionados
         if (!LenzAddress.IsValidAddress(address))
            throw new Exception("La dirección digital proporcionada no es válida.");

         // Envia los datos al interface
         try
         {
            byte byteAddy = 0x00;
            byte byteB = 0x00;
            byte byteD = 0x00;

            byteAddy = (byte)(address / 4);
            byteB = (byte)(((address % 4) & 0x01) << 1);
            byteB += (byte)(((address % 4) & 0x02) << 1);
            byteD = (byte)(activate ? 0x08 :0x00);
            byteD += (byte)(turned ? 0x01 : 0x00);

            byte[] cmdData = { 0xFF, 0xFE, 0x52, 0x00, 0x00, 0x00 };
            cmdData[3] = byteAddy;
            cmdData[4] = (byte)(byteB + byteD + 0x80);
            cmdData[5] = (byte)Binary.Xor(cmdData, 2, 3);

            _port.Write(cmdData, 0, cmdData.Length);
         }
         catch (Exception ex)
         {
            throw new Exception("Write error: " + ex.Message, ex);
         }

         // Espera a la respuesta
         WaitForResponse(SystemResponses.RespLIOK);
      }

      #region Comm Functions

      /// <summary>
      /// Espera una determinada respuesta.
      /// </summary>
      /// <param name="responseType">Tipo de respuesta esperada.</param>
      /// <returns>Un valor que indica si se ha obtenido la respuesta esperada dentro del timeout.</returns>
      private LenzResponse WaitForResponse(SystemResponses responseType)
      {
         Stopwatch watch = new Stopwatch();
         TimeSpan span = TimeSpan.FromSeconds(_reqTimeout);

         // Inicia la medida de tiempo para controlar el Timeout
         watch.Start();

         // Espera la respuesta apropiada
         while ((_response != null) && (_response.Type != responseType))
         {
            System.Windows.Forms.Application.DoEvents();

            // Si se supera el timeout se devuelve False
            if (watch.Elapsed > span)
            {
               watch.Stop();
               throw new Exception("System response timeout: expecting " + responseType.ToString() + " exceed timeout");
            }
         }

         // Detiene el reloj
         watch.Stop();

         return _response;
      }

      /// <summary>
      /// Comprueba si el puerto está abierto. Si está cerrado, lanza una excepción.
      /// </summary>
      private void CheckPortStatus()
      {
         if (!_port.IsOpen)
            throw new Exception("La conexión al puerto se encuentra cerrada. No es posible enviar o recibir datos del interface Lenz.");
      }

      /// <summary>
      /// Trata la recepción de datos desde el puerto.
      /// </summary>
      private void PortDataReceived(object sender, SerialDataReceivedEventArgs e)
      {
         byte[] byteResp = new byte[_port.ReadBufferSize];

         // Lee el contenido del buffer de entrada
         _port.Read(byteResp, 0, _port.ReadBufferSize);

         // Genera la respuesta normalizada
         _response = new LenzResponse(byteResp);

         // Si existe información perdida, lanza un mensaje de error informativo
         if (!_response.IsDataOk)
         {
            _response = null;
            // OnError(new OTCInformationEventArgs("Paquete desconocido [" + _response.ToString() + "]"), new Exception("Paquete desconocido"));
            return;
         }

         // Trata los paquetes recibidos sin petición (feedback, etc)
         switch (_response.Type)
         {
            case SystemResponses.RespFeedback1Addy:
            case SystemResponses.RespFeedback2Addy:
            case SystemResponses.RespFeedback3Addy:
            case SystemResponses.RespFeedback4Addy:
            case SystemResponses.RespFeedback5Addy:
            case SystemResponses.RespFeedback6Addy:
            case SystemResponses.RespFeedback7Addy:
            {
               // Encolar información
               break;
            }
         }
      }

      #endregion

      #region Events

      /*

      public delegate void ResponseEventHandler(OTCSystemResponseEventArgs e);
      public event ResponseEventHandler OnResponse;

      public delegate void InfoEventHandler(OTCInformationEventArgs e);
      public event InfoEventHandler OnInformation;

      public delegate void ErrorEventHandler(OTCInformationEventArgs e, Exception error);
      public event ErrorEventHandler OnError;

      /// <summary>
      /// Método interno para lanzar el evento OnError.
      /// </summary>
      private void Object_OnError(OTCInformationEventArgs e, Exception error)
      {
         if (OnError != null) OnError(e, error);
      }

      /// <summary>
      /// Método interno para lanzar el evento OnInformation.
      /// </summary>
      private void Object_OnInformation(OTCInformationEventArgs e)
      {
         if (OnInformation != null) OnInformation(e);
      }

      */
 
      #endregion

      #region Helper Functions

      bool ConvertLongAddyToCV17_18(int _iLocoAddy, byte _byteCV17, byte _byteCV18)
      {
          bool bSuccess = false;
          
          if ((_iLocoAddy > 0) && (_iLocoAddy <= 9999)) 
          {
              int wAddy = _iLocoAddy + 0xC000;
              
              _byteCV17 = (byte)(wAddy / 0x0100);
              _byteCV18 = (byte)(wAddy % 0x0100);
              bSuccess =  true;
          }

          return bSuccess;
      }

      int ConvertCV17_18ToLongAddy(byte _byteAddy17, byte _byteAddy18)
      {
          return ((_byteAddy17 * 0x0100) + _byteAddy18) - 0xC000;
      }

      #endregion
   }
}
