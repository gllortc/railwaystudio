using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Rwm.Otc.Net
{

   /// <summary>
   /// Implementa un mensaje base para la red de comunicaciones OTC.
   /// </summary>
   public class OTCNetMessage
   {

      #region Enumerations

      /// <summary>
      /// Enumera los tipos de mensaje soportados por OTC.
      /// </summary>
      public enum CommandType : int
      {
         /// <summary>No command</summary>
         Null = 0,
         /// <summary>Force the target to logoff from the application without prompt.Pass null or "" as command's Message.</summary>
         UserExit,
         /// <summary>Force the target to logoff from the application with prompt.Pass the timer interval of logoff action as command's Message in miliseconds.For example "20000".</summary>
         UserExitWithTimer,
         /// <summary>Force the target PC to LOCK without prompt.Pass null or "" as command's Message.</summary>
         PCLock,
         /// <summary>Force the target PC to LOCK with prompt.Pass the timer interval of LOCK action as command's Message in miliseconds.For example "20000".</summary>
         PCLockWithTimer,
         /// <summary>Force the target PC to RESTART without prompt.Pass null or "" as command's Message.</summary>
         PCRestart,
         /// <summary>Force the target PC to RESTART with prompt.Pass the timer interval of RESTART action as command's Message in miliseconds.For example "20000".</summary>
         PCRestartWithTimer,
         /// <summary>Force the target PC to LOGOFF without prompt.Pass null or "" as command's Message.</summary>
         PCLogOFF,
         /// <summary>Force the target PC to LOGOFF with prompt.Pass the timer interval of LOGOFF action as command's Message in miliseconds.For example "20000".</summary>
         PCLogOFFWithTimer,
         /// <summary>Force the target PC to SHUTDOWN without prompt.Pass null or "" as command's Message.</summary>
         PCShutDown,
         /// <summary>Force the target PC to SHUTDOWN with prompt.Pass the timer interval of SHUTDOWN action as command's Message in miliseconds.For example "20000".</summary>
         PCShutDownWithTimer,
         /// <summary>Send a text message to the server.Pass the body of text message as command's Message.</summary>
         Message,
         /// <summary>This command will sent to all clients when an specific client is had been logged in to the server.The Message of this command is in this format : "ClientIP:ClientNetworkName"</summary>
         ClientLoginInform,
         /// <summary>This command will sent to all clients when an specific client is had been logged off from the server.You can get the disconnected client information from FromIP and SenderName properties of command event args.</summary>
         ClientLogOffInform,
         /// <summary>To ask from the server pass the name that you want check it's existance as meta data of command.The server will replay to you a command with the same type and Message of 'True' or 'False' that specifies the Network name is exists on the server or not.</summary>
         IsNameExists,
         /// <summary>To get a list of current connected clients to the server,Send this type of command to it.The server will replay to you one same command for each client with the Message in this format : "ClientIP:ClientNetworkName".</summary>
         SendClientList,
         /// <summary>This is a free command that you can sent to the server.</summary>
         FreeCommand
      }

      /// <summary>
      /// Enumera los estados de respuesta de una petición.
      /// </summary>
      public enum RequestStatus : int
      {
         /// <summary>Correcto.</summary>
         Successful = 0,
         /// <summary>Fallado.</summary>
         Failed = 1
      }

      #endregion

      private string _from = string.Empty;
      private IPAddress _fromip;
      private string _to = string.Empty;
      private IPAddress _toip;
      private CommandType _type = CommandType.Null;
      private RequestStatus _status = RequestStatus.Failed;
      private string _message = string.Empty;
      private List<OTCNetMessageClient> _stations = new List<OTCNetMessageClient>();

      private const string TAG_ROOT = "otc-netmsg";
      private const string TAG_FROM = "from";
      private const string TAG_TO = "to";
      private const string TAG_TYPE = "type";
      private const string TAG_STATUS = "status";
      private const string TAG_MESSAGE = "message";
      private const string TAG_STATIONS = "stations";
      private const string TAG_STATION = "station";

      private const string PARAM_VERSION = "version";
      private const string PARAM_GENERATOR = "generator";
      private const string PARAM_NAME = "name";
      private const string PARAM_IP = "ip";
      private const string PARAM_SERVER = "server";

      /// <summary>
      /// Returns a new instance of OTCNetMessage.
      /// </summary>
      public OTCNetMessage()
      {
         _from = string.Empty;
         _fromip = IPAddress.Parse("127.0.0.1");
         _to = string.Empty;
         _toip = IPAddress.Parse("127.0.0.1");
         _type = CommandType.Null;
         _status = RequestStatus.Failed;
         _message = string.Empty;
         _stations = new List<OTCNetMessageClient>();
      }

      /// <summary>
      /// Returns a new instance of OTCNetMessage.
      /// </summary>
      public OTCNetMessage(CommandType type, IPAddress toIp, string message)
      {
         _from = string.Empty;
         _fromip = IPAddress.Parse("127.0.0.1");
         _to = string.Empty;
         _toip = toIp;
         _type = type;
         _status = RequestStatus.Failed;
         _message = message;
         _stations = new List<OTCNetMessageClient>();
      }

      /// <summary>
      /// Returns a new instance of OTCNetMessage.
      /// </summary>
      public OTCNetMessage(CommandType type, IPAddress toIp)
      {
         _from = string.Empty;
         _fromip = IPAddress.Parse("127.0.0.1");
         _to = string.Empty;
         _toip = toIp;
         _type = type;
         _status = RequestStatus.Failed;
         _message = string.Empty;
         _stations = new List<OTCNetMessageClient>();
      }

      /// <summary>
      /// Returns a new instance of OTCNetMessage.
      /// </summary>
      public OTCNetMessage(string xml)
      {
         _from = string.Empty;
         _fromip = IPAddress.Parse("127.0.0.1");
         _to = string.Empty;
         _toip = IPAddress.Parse("127.0.0.1"); ;
         _type = CommandType.Null;
         _status = RequestStatus.Failed;
         _message = string.Empty;
         _stations = new List<OTCNetMessageClient>();

         this.ConvertFromByteArray(xml);
      }

      /// <summary>
      /// Returns a new instance of OTCNetMessage.
      /// </summary>
      public OTCNetMessage(byte[] xml)
      {
         _from = string.Empty;
         _fromip = IPAddress.Parse("127.0.0.1");
         _to = string.Empty;
         _toip = IPAddress.Parse("127.0.0.1"); ;
         _type = CommandType.Null;
         _status = RequestStatus.Failed;
         _message = string.Empty;
         _stations = new List<OTCNetMessageClient>();

         this.ConvertFromByteArray(xml);
      }

      #region Properties

      /// <summary>
      /// Destinatario del mensaje.
      /// </summary>
      /// <remarks>
      /// Si este campo está vacío indica que es un mensaje Broadcast.
      /// </remarks>
      public string To
      {
         get { return _to; }
         set { _to = value; }
      }

      /// <summary>
      /// IP de destino.
      /// </summary>
      public IPAddress ToIP
      {
         get { return _toip; }
         set { _toip = value; }
      }

      /// <summary>
      /// Autor del mensaje.
      /// </summary>
      public string From
      {
         get { return _from; }
         set { _from = value; }
      }

      /// <summary>
      /// IP desde dónde se lanzó el mensaje.
      /// </summary>
      public IPAddress FromIP
      {
         get { return _fromip; }
         set { _fromip = value; }
      }

      /// <summary>
      /// Tipo de mensaje.
      /// </summary>
      public CommandType Type
      {
         get { return _type; }
         internal set { _type = value; }
      }

      /// <summary>
      /// Estado de la respuesta.
      /// </summary>
      public RequestStatus Status
      {
         get { return _status; }
         set { _status = value; }
      }

      /// <summary>
      /// Establece o devuelve el texto del mensaje.
      /// </summary>
      public string Message
      {
         get { return _message; }
         set { _message = value; }
      }

      /// <summary>
      /// Contiene la lista de estaciones registradas en la red.
      /// </summary>
      public List<OTCNetMessageClient> Stations
      {
         get { return _stations; }
         set { _stations = value; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Converts the Data structure into an array of bytes
      /// </summary>
      public byte[] ToByte()
      {
         return System.Text.Encoding.ASCII.GetBytes(ToXml());
      }

      /// <summary>
      /// Convierte el mensaje a su formato XML.
      /// </summary>
      public string ToXml()
      {
         XmlAttribute att = null;
         XmlNode node = null;
         XmlText xmltext = null;

         try
         {
            XmlDocument doc = new XmlDocument();

            XmlNode root = doc.CreateElement(TAG_ROOT);

            att = doc.CreateAttribute(PARAM_VERSION);
            att.Value = OTCContext.OTCVersion;
            root.Attributes.Append(att);

            att = doc.CreateAttribute(PARAM_GENERATOR);
            att.Value = OTCContext.ProductName;
            root.Attributes.Append(att);

            node = doc.CreateElement(TAG_FROM);

            att = doc.CreateAttribute(PARAM_NAME);
            att.Value = _from.ToLower().Trim();
            node.Attributes.Append(att);

            att = doc.CreateAttribute(PARAM_IP);
            att.Value = _fromip.ToString();
            node.Attributes.Append(att);

            root.AppendChild(node);

            node = doc.CreateElement(TAG_TO);

            att = doc.CreateAttribute(PARAM_NAME);
            att.Value = _to.ToLower().Trim();
            node.Attributes.Append(att);

            att = doc.CreateAttribute(PARAM_IP);
            att.Value = _toip.ToString();
            node.Attributes.Append(att);

            root.AppendChild(node);

            node = doc.CreateElement(TAG_TYPE);
            xmltext = doc.CreateTextNode(((int)_type).ToString());
            node.AppendChild(xmltext);
            root.AppendChild(node);

            node = doc.CreateElement(TAG_STATUS);
            xmltext = doc.CreateTextNode(((int)_status).ToString());
            node.AppendChild(xmltext);
            root.AppendChild(node);

            node = doc.CreateElement(TAG_MESSAGE);
            xmltext = doc.CreateTextNode(_message.Trim());
            node.AppendChild(xmltext);
            root.AppendChild(node);

            node = doc.CreateElement(TAG_STATIONS);

            foreach (OTCNetMessageClient station in _stations)
            {
               XmlElement stelem = doc.CreateElement(TAG_STATION);

               att = doc.CreateAttribute(PARAM_NAME);
               att.Value = station.Login;
               stelem.Attributes.Append(att);

               att = doc.CreateAttribute(PARAM_IP);
               att.Value = station.IP;
               stelem.Attributes.Append(att);

               att = doc.CreateAttribute(PARAM_SERVER);
               att.Value = (station.IsServer ? "1" : "0");
               stelem.Attributes.Append(att);

               node.AppendChild(stelem);
            }

            root.AppendChild(node);
            doc.AppendChild(root);

            return doc.OuterXml;
         }
         catch
         {
            throw;
         }
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Convierte el mensaje a su formato XML.
      /// </summary>
      private void ConvertFromByteArray(string xml)
      {
         XmlElement elem = null;

         try
         {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            elem = doc.DocumentElement;

            if (!elem.Name.ToLower().Equals(TAG_ROOT))
               throw new Exception("El mensaje no tiene un formato reconocible.");

            // TODO: Comprobar versión del mensaje

            foreach (XmlNode node in elem.ChildNodes)
            {
               if (node.Name.ToLower().Equals(TAG_FROM))
               {
                  foreach (XmlAttribute att in node.Attributes)
                  {
                     if (att.Name.ToLower().Equals(PARAM_NAME)) _from = att.Value;
                     if (att.Name.ToLower().Equals(PARAM_IP))
                     {
                        _fromip = IPAddress.Parse("127.0.0.1");
                        IPAddress.TryParse(att.Value, out _fromip);
                     }
                  }
               }
               else if (node.Name.ToLower().Equals(TAG_TO))
               {
                  foreach (XmlAttribute att in node.Attributes)
                  {
                     if (att.Name.ToLower().Equals(PARAM_NAME)) _to = att.Value;
                     if (att.Name.ToLower().Equals(PARAM_IP))
                     {
                        _toip = IPAddress.Parse("127.0.0.1");
                        IPAddress.TryParse(att.Value, out _toip);
                     }
                  }
               }
               else if (node.Name.ToLower().Equals(TAG_TYPE))
               {
                  _type = (CommandType)int.Parse(node.InnerText);
               }
               else if (node.Name.ToLower().Equals(TAG_STATUS))
               {
                  _status = (RequestStatus)int.Parse(node.InnerText);
               }
               else if (node.Name.ToLower().Equals(TAG_MESSAGE))
               {
                  _message = node.InnerText;
               }
               else if (node.Name.ToLower().Equals(TAG_STATIONS))
               {
                  foreach (XmlNode station in node.ChildNodes)
                  {
                     if (node.Name.ToLower().Equals(TAG_STATION))
                     {
                        OTCNetMessageClient client = new OTCNetMessageClient();
                        foreach (XmlAttribute att in node.Attributes)
                        {
                           if (att.Name.ToLower().Equals(PARAM_NAME)) client.Login = att.Value;
                           if (att.Name.ToLower().Equals(PARAM_IP)) client.IP = att.Value;
                           if (att.Name.ToLower().Equals(PARAM_SERVER)) client.IsServer = (att.Value.Equals("1") ? true : false);
                        }
                        _stations.Add(client);
                     }
                  }
               }
            }
         }
         catch
         {
            throw;
         }
      }

      /// <summary>
      /// Convierte el mensaje a su formato XML.
      /// </summary>
      private void ConvertFromByteArray(byte[] xml)
      {
         ConvertFromByteArray(System.Text.Encoding.ASCII.GetString(xml));
      }

      #endregion

   }
}
