using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;

namespace Rwm.Otc.Net
{

   #region OTCNetServer

   /// <summary>
   /// Implementa el servidor de comunicaciones de OTC.
   /// </summary>
   public class OTCNetServer
   {
      private List<OTCNetServerClient> _clients;
      private BackgroundWorker _bwListener;
      private Socket _listenerSocket;
      private IPAddress _serverIP = IPAddress.Parse("127.0.0.1");
      private int _serverPort = 103;

      /// <summary>
      /// Login reservado por el servidor.
      /// </summary>
      public const string SERVER_LOGIN = "Server";

      /// <summary>
      /// Returns a new instance of OTCNetServer.
      /// </summary>
      public OTCNetServer()
      {
         _serverIP = IPAddress.Parse("127.0.0.1");
         _serverPort = 103;
      }

      /// <summary>
      /// Returns a new instance of OTCNetServer.
      /// </summary>
      public OTCNetServer(IPAddress ip, int port)
      {
         _serverIP = ip;
         _serverPort = port;
      }

      /// <summary>
      /// Dirección IP del servidor.
      /// </summary>
      public IPAddress ServerIP
      {
         get { return _serverIP; }
         set { _serverIP = value; }
      }

      /// <summary>
      /// Puerto que escuchará el servidor.
      /// </summary>
      public int ServerPort
      {
         get { return _serverPort; }
         set { _serverPort = value; }
      }

      /// <summary>
      /// Start the console server.
      /// </summary>
      /// <param name="ip">Local ip address of the server.</param>
      /// <param name="port">Local port.</param>
      public void Connect(IPAddress ip, int port)
      {
         _clients = new List<OTCNetServerClient>();
         _serverPort = port;
         _serverIP = ip;

         _bwListener = new BackgroundWorker();
         _bwListener.WorkerSupportsCancellation = true;
         _bwListener.DoWork += new DoWorkEventHandler(StartToListen);
         _bwListener.RunWorkerAsync();

         Console.WriteLine("*** Listening on port {0}{1}{2} started.Press ENTER to shutdown server. ***\n", _serverIP.ToString(), ":", _serverPort.ToString());
         Console.ReadLine();

         Disconnect();
      }

      /// <summary>
      /// Start the console server.
      /// </summary>
      public void Connect()
      {
         Connect(_serverIP, _serverPort);
      }

      /// <summary>
      /// Termina la ejecución del servidor.
      /// </summary>
      public void Disconnect()
      {
         if (_clients != null)
         {
            foreach (OTCNetServerClient mngr in _clients)
            {
               mngr.Disconnect();
            }

            _bwListener.CancelAsync();
            _bwListener.Dispose();
            _listenerSocket.Close();
            GC.Collect();
         }
      }

      private void StartToListen(object sender, DoWorkEventArgs e)
      {
         _listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         _listenerSocket.Bind(new IPEndPoint(_serverIP, this._serverPort));
         _listenerSocket.Listen(200);

         while (true)
            CreateNewClientManager(this._listenerSocket.Accept());
      }

      private void CreateNewClientManager(Socket socket)
      {
         OTCNetServerClient newClientManager = new OTCNetServerClient(socket);
         newClientManager.CommandReceived += new CommandReceivedEventHandler(CommandReceived);
         newClientManager.Disconnected += new ClientDisconnectedEventHandler(ClientDisconnected);

         CheckForAbnormalDC(newClientManager);
         _clients.Add(newClientManager);

         UpdateConsole("Connected.", newClientManager.IP, newClientManager.Port);
      }

      private void CheckForAbnormalDC(OTCNetServerClient mngr)
      {
         if (RemoveClientManager(mngr.IP))
            UpdateConsole("Disconnected.", mngr.IP, mngr.Port);
      }

      void ClientDisconnected(ClientEventArgs e)
      {
         if (RemoveClientManager(e.IP))
            UpdateConsole("Disconnected.", e.IP, e.Port);
      }

      private bool RemoveClientManager(IPAddress ip)
      {
         lock (this)
         {
            int index = IndexOfClient(ip);
            if (index != -1)
            {
               string name = _clients[index].ClientLogin;
               _clients.RemoveAt(index);

               //Inform all clients that a client had been disconnected.
               OTCNetMessage cmd = new OTCNetMessage(OTCNetMessage.CommandType.ClientLogOffInform, IPAddress.Broadcast);
               cmd.From = name;
               cmd.FromIP = ip;
               BroadCastCommand(cmd);
               return true;
            }
            return false;
         }
      }

      private void CommandReceived(object sender, CommandEventArgs e)
      {
         // When a client connects to the server sends a 'ClientLoginInform' command with a Message in this format :
         // "RemoteClientIP:RemoteClientName". With this information we should set the name of ClientManager and then
         // Send the command to all other remote clients.
         if (e.Command.Type == OTCNetMessage.CommandType.ClientLoginInform)
            SetManagerName(e.Command.FromIP, e.Command.Message);

         //If the client asked for existance of a name,answer to it's question.
         if (e.Command.Type == OTCNetMessage.CommandType.IsNameExists)
         {
            bool isExixsts = IsNameExists(e.Command.FromIP, e.Command.Message);
            SendExistanceCommand(e.Command.FromIP, isExixsts);
            return;
         }
         //If the client asked for list of a logged in clients,replay to it's request.
         else if (e.Command.Type == OTCNetMessage.CommandType.SendClientList)
         {
            SendClientListToNewClient(e.Command.FromIP);
            return;
         }

         if (e.Command.ToIP.Equals(IPAddress.Broadcast))
            BroadCastCommand(e.Command);
         else
            SendCommandToTarget(e.Command);

      }

      private void SendExistanceCommand(IPAddress ToIP, bool isExists)
      {
         OTCNetMessage cmdExistance = new OTCNetMessage(OTCNetMessage.CommandType.IsNameExists, ToIP, isExists.ToString());
         cmdExistance.FromIP = _serverIP;
         cmdExistance.From = SERVER_LOGIN;
         SendCommandToTarget(cmdExistance);
      }

      private void SendClientListToNewClient(IPAddress newClientIP)
      {
         foreach (OTCNetServerClient mngr in _clients)
         {
            if (mngr.Connected && !mngr.IP.Equals(newClientIP))
            {
               OTCNetMessage cmd = new OTCNetMessage(OTCNetMessage.CommandType.SendClientList, newClientIP);
               cmd.Message = mngr.IP.ToString() + ":" + mngr.ClientLogin;
               cmd.FromIP = _serverIP;
               cmd.From = SERVER_LOGIN;
               SendCommandToTarget(cmd);
            }
         }
      }

      private string SetManagerName(IPAddress remoteClientIP, string nameString)
      {
         int index = IndexOfClient(remoteClientIP);
         if (index != -1)
         {
            string name = nameString.Split(new char[] { ':' })[1];
            _clients[index].ClientLogin = name;
            return name;
         }
         return string.Empty;
      }

      private bool IsNameExists(IPAddress remoteClientIP, string nameToFind)
      {
         foreach (OTCNetServerClient mngr in _clients)
            if (mngr.ClientLogin == nameToFind && !mngr.IP.Equals(remoteClientIP))
               return true;

         return false;
      }

      private void BroadCastCommand(OTCNetMessage cmd)
      {
         foreach (OTCNetServerClient mngr in _clients)
         {
            if (!mngr.IP.Equals(cmd.FromIP))
               mngr.SendCommand(cmd);
         }
      }

      private void SendCommandToTarget(OTCNetMessage cmd)
      {
         foreach (OTCNetServerClient mngr in _clients)
         {
            if (mngr.IP.Equals(cmd.ToIP))
            {
               mngr.SendCommand(cmd);
               return;
            }
         }
      }

      private void UpdateConsole(string status, IPAddress IP, int port)
      {
         Console.WriteLine("Client {0}{1}{2} has been {3} ( {4}|{5} )",
                           IP.ToString(),
                           ":",
                           port.ToString(),
                           status,
                           DateTime.Now.ToShortDateString(),
                           DateTime.Now.ToLongTimeString());
      }

      private int IndexOfClient(IPAddress ip)
      {
         int index = -1;
         foreach (OTCNetServerClient cMngr in _clients)
         {
            index++;
            if (cMngr.IP.Equals(ip))
               return index;
         }
         return -1;
      }
   }

   #endregion

}
