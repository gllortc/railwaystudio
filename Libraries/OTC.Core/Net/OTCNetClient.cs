using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Rwm.Otc.Net
{

   /// <summary>
   /// The command client command class.
   /// </summary>
   public class OTCNetClient
   {
      private Socket _clientSocket;
      private NetworkStream _networkStream;
      private BackgroundWorker _bwReceiver;
      private IPEndPoint _serverEP;
      private string _login;

      /// <summary>
      /// Cretaes a command client instance.
      /// </summary>
      /// <param name="server">The remote server to connect.</param>
      /// <param name="netName">The string that will send to the server and then to other clients, to identify this client to all clients.</param>
      public OTCNetClient(IPEndPoint server, string netName)
      {
         _serverEP = server;
         _login = netName;

         System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged += new System.Net.NetworkInformation.NetworkAvailabilityChangedEventHandler(NetworkChange_NetworkAvailabilityChanged);
      }

      /// <summary>
      /// Cretaes a command client instance.
      /// </summary>
      ///<param name="serverIP">The IP of remote server.</param>
      ///<param name="port">The port of remote server.</param>
      /// <param name="netName">The string that will send to the server and then to other clients, to identify this client to all clients.</param>
      public OTCNetClient(IPAddress serverIP, int port, string netName)
      {
         _serverEP = new IPEndPoint(serverIP, port);
         _login = netName;

         System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged += new System.Net.NetworkInformation.NetworkAvailabilityChangedEventHandler(NetworkChange_NetworkAvailabilityChanged);
      }

      #region Properties

      /// <summary>
      /// [Gets] The value that specifies the current client is connected or not.
      /// </summary>
      public bool Connected
      {
         get
         {
            if (_clientSocket != null)
               return _clientSocket.Connected;
            else
               return false;
         }
      }

      /// <summary>
      /// [Gets] The IP address of the remote server.If this client is disconnected,this property returns IPAddress.None.
      /// </summary>
      public IPAddress ServerIP
      {
         get
         {
            if (Connected)
               return _serverEP.Address;
            else
               return IPAddress.None;
         }
      }

      /// <summary>
      /// [Gets] The comunication port of the remote server.If this client is disconnected,this property returns -1.
      /// </summary>
      public int ServerPort
      {
         get
         {
            if (Connected)
               return _serverEP.Port;
            else
               return -1;
         }
      }

      /// <summary>
      /// [Gets] The IP address of this client.If this client is disconnected,this property returns IPAddress.None.
      /// </summary>
      public IPAddress IP
      {
         get
         {
            if (Connected)
               return ((IPEndPoint)_clientSocket.LocalEndPoint).Address;
            else
               return IPAddress.None;
         }
      }

      /// <summary>
      /// [Gets] The comunication port of this client.If this client is disconnected,this property returns -1.
      /// </summary>
      public int Port
      {
         get
         {
            if (Connected)
               return ((IPEndPoint)_clientSocket.LocalEndPoint).Port;
            else
               return -1;
         }
      }

      /// <summary>
      /// [Gets/Sets] The string that will sent to the server and then to other clients, to identify this client to them.
      /// </summary>
      public string Login
      {
         get { return _login; }
         set { _login = value; }
      }

      #endregion

      #region Method

      /// <summary>
      /// Connect the current instance of command client to the server.
      /// This method throws ServerNotFoundException on failur.
      /// Run this method and handle the 'ConnectingSuccessed' and 'ConnectingFailed' to get the connection state.
      /// </summary>
      public void ConnectToServer()
      {
         BackgroundWorker bwConnector = new BackgroundWorker();

         bwConnector.DoWork += new DoWorkEventHandler(bwConnector_DoWork);
         bwConnector.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwConnector_RunWorkerCompleted);

         bwConnector.RunWorkerAsync();
      }

      /// <summary>
      /// Sends a command to the server if the connection is alive.
      /// </summary>
      /// <param name="cmd">The command to send.</param>
      public void SendCommand(OTCNetMessage cmd)
      {
         if (_clientSocket != null && _clientSocket.Connected)
         {
            BackgroundWorker bwSender = new BackgroundWorker();
            bwSender.DoWork += new DoWorkEventHandler(bwSender_DoWork);
            bwSender.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwSender_RunWorkerCompleted);
            bwSender.WorkerSupportsCancellation = true;
            bwSender.RunWorkerAsync(cmd);
         }
         else
         {
            OnCommandFailed(new EventArgs());
         }
      }

      /// <summary>
      /// Disconnect the client from the server and returns true if the client had been disconnected from the server.
      /// </summary>
      /// <returns>True if the client had been disconnected from the server,otherwise false.</returns>
      public bool Disconnect()
      {
         if (_clientSocket != null && _clientSocket.Connected)
         {
            try
            {
               _clientSocket.Shutdown(SocketShutdown.Both);
               _clientSocket.Close();
               _bwReceiver.CancelAsync();
               OnDisconnectedFromServer(new EventArgs());
               return true;
            }
            catch
            {
               return false;
            }
         }
         else
         {
            return true;
         }
      }

      #endregion

      #region Events

      /// <summary>
      /// Occurs when a command received from a remote client.
      /// </summary>
      public event CommandReceivedEventHandler CommandReceived;

      /// <summary>
      /// Occurs when a command received from a remote client.
      /// </summary>
      /// <param name="e">The received command.</param>
      protected virtual void OnCommandReceived(CommandEventArgs e)
      {
         if (CommandReceived != null)
         {
            Control target = CommandReceived.Target as Control;
            if (target != null && target.InvokeRequired)
            {
               target.Invoke(CommandReceived, new object[] { this, e });
            }
            else
            {
               CommandReceived(this, e);
            }
         }
      }

      /// <summary>
      /// Occurs when a command had been sent to the the remote server Successfully.
      /// </summary>
      public event CommandSentEventHandler CommandSent;

      /// <summary>
      /// Occurs when a command had been sent to the the remote server Successfully.
      /// </summary>
      /// <param name="e">The sent command.</param>
      protected virtual void OnCommandSent(EventArgs e)
      {
         if (CommandSent != null)
         {
            Control target = CommandSent.Target as Control;
            if (target != null && target.InvokeRequired)
            {
               target.Invoke(CommandSent, new object[] { this, e });
            }
            else
            {
               CommandSent(this, e);
            }
         }
      }

      /// <summary>
      /// Occurs when a command sending action had been failed.This is because disconnection or sending exception.
      /// </summary>
      public event CommandSendingFailedEventHandler CommandFailed;

      /// <summary>
      /// Occurs when a command sending action had been failed.This is because disconnection or sending exception.
      /// </summary>
      /// <param name="e">The sent command.</param>
      protected virtual void OnCommandFailed(EventArgs e)
      {
         if (CommandFailed != null)
         {
            Control target = CommandFailed.Target as Control;
            if (target != null && target.InvokeRequired)
            {
               target.Invoke(CommandFailed, new object[] { this, e });
            }
            else
            {
               CommandFailed(this, e);
            }
         }
      }

      /// <summary>
      /// Occurs when the client disconnected.
      /// </summary>
      public event ServerDisconnectedEventHandler ServerDisconnected;

      /// <summary>
      /// Occurs when the server disconnected.
      /// </summary>
      /// <param name="e">Server information.</param>
      protected virtual void OnServerDisconnected(ServerEventArgs e)
      {
         if (ServerDisconnected != null)
         {
            Control target = ServerDisconnected.Target as Control;
            if (target != null && target.InvokeRequired)
            {
               target.Invoke(ServerDisconnected, new object[] { this, e });
            }
            else
            {
               ServerDisconnected(this, e);
            }
         }
      }

      /// <summary>
      /// Occurs when this client disconnected from the remote server.
      /// </summary>
      public event DisconnectedEventHandler DisconnectedFromServer;

      /// <summary>
      /// Occurs when this client disconnected from the remote server.
      /// </summary>
      /// <param name="e">EventArgs.</param>
      protected virtual void OnDisconnectedFromServer(EventArgs e)
      {
         if (DisconnectedFromServer != null)
         {
            Control target = DisconnectedFromServer.Target as Control;
            if (target != null && target.InvokeRequired)
            {
               target.Invoke(DisconnectedFromServer, new object[] { this, e });
            }
            else
            {
               DisconnectedFromServer(this, e);
            }
         }
      }

      /// <summary>
      /// Occurs when this client connected to the remote server Successfully.
      /// </summary>
      public event ConnectingSuccessedEventHandler ConnectingSuccessed;

      /// <summary>
      /// Occurs when this client connected to the remote server Successfully.
      /// </summary>
      /// <param name="e">EventArgs.</param>
      protected virtual void OnConnectingSuccessed(EventArgs e)
      {
         if (ConnectingSuccessed != null)
         {
            Control target = ConnectingSuccessed.Target as Control;
            if (target != null && target.InvokeRequired)
            {
               target.Invoke(ConnectingSuccessed, new object[] { this, e });
            }
            else
            {
               ConnectingSuccessed(this, e);
            }
         }
      }

      /// <summary>
      /// Occurs when this client failed on connecting to server.
      /// </summary>
      public event ConnectingFailedEventHandler ConnectingFailed;

      /// <summary>
      /// Occurs when this client failed on connecting to server.
      /// </summary>
      /// <param name="e">EventArgs.</param>
      protected virtual void OnConnectingFailed(EventArgs e)
      {
         if (ConnectingFailed != null)
         {
            Control target = ConnectingFailed.Target as Control;
            if (target != null && target.InvokeRequired)
            {
               target.Invoke(ConnectingFailed, new object[] { this, e });
            }
            else
            {
               ConnectingFailed(this, e);
            }
         }
      }

      /// <summary>
      /// Occurs when the network had been failed.
      /// </summary>
      public event NetworkDeadEventHandler NetworkDead;

      /// <summary>
      /// Occurs when the network had been failed.
      /// </summary>
      /// <param name="e">EventArgs.</param>
      protected virtual void OnNetworkDead(EventArgs e)
      {
         if (NetworkDead != null)
         {
            Control target = NetworkDead.Target as Control;
            if (target != null && target.InvokeRequired)
            {
               target.Invoke(NetworkDead, new object[] { this, e });
            }
            else
            {
               NetworkDead(this, e);
            }
         }
      }

      /// <summary>
      /// Occurs when the network had been started to work.
      /// </summary>
      public event NetworkAlivedEventHandler NetworkAlived;

      /// <summary>
      /// Occurs when the network had been started to work.
      /// </summary>
      /// <param name="e">EventArgs.</param>
      protected virtual void OnNetworkAlived(EventArgs e)
      {
         if (NetworkAlived != null)
         {
            Control target = NetworkAlived.Target as Control;
            if (target != null && target.InvokeRequired)
            {
               target.Invoke(NetworkAlived, new object[] { this, e });
            }
            else
            {
               NetworkAlived(this, e);
            }
         }
      }

      #endregion

      #region Private Members

      private void NetworkChange_NetworkAvailabilityChanged(object sender, System.Net.NetworkInformation.NetworkAvailabilityEventArgs e)
      {
         if (!e.IsAvailable)
         {
            OnNetworkDead(new EventArgs());
            OnDisconnectedFromServer(new EventArgs());
         }
         else
         {
            OnNetworkAlived(new EventArgs());
         }
      }

      private void StartReceive(object sender, DoWorkEventArgs e)
      {
         while (_clientSocket.Connected)
         {
            if (_networkStream.DataAvailable)
            {
               // Obtiene la longitud del mensaje
               byte[] buffer = new byte[4];
               int readBytes = _networkStream.Read(buffer, 0, 4);
               if (readBytes == 0)
               {
                  break;
               }

               int numbytes = BitConverter.ToInt32(buffer, 0);

               // Lee los bytes del mensaje
               buffer = new byte[numbytes];
               readBytes = _networkStream.Read(buffer, 0, numbytes);
               if (readBytes == 0)
               {
                  break;
               }

               // Convierte los datos en el mensaje
               OTCNetMessage cmd = new OTCNetMessage(buffer);
               OnCommandReceived(new CommandEventArgs(cmd));
            }
         }

         OnServerDisconnected(new ServerEventArgs(_clientSocket));
         Disconnect();
      }

      private void bwSender_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (!e.Cancelled && e.Error == null && ((bool)e.Result))
         {
            OnCommandSent(new EventArgs());
         }
         else
         {
            OnCommandFailed(new EventArgs());
         }

         ((BackgroundWorker)sender).Dispose();
         GC.Collect();
      }

      private void bwSender_DoWork(object sender, DoWorkEventArgs e)
      {
         OTCNetMessage cmd = (OTCNetMessage)e.Argument;
         e.Result = SendCommandToServer(cmd);
      }

      // This Semaphor is to protect the critical section from concurrent access of sender threads.
      System.Threading.Semaphore semaphor = new System.Threading.Semaphore(1, 1);
      private bool SendCommandToServer(OTCNetMessage cmd)
      {
         try
         {
            semaphor.WaitOne();

            // Formatea los datos necesarios del mensaje
            if (String.IsNullOrEmpty(cmd.Message))
            {
               SetMetaDataIfIsNull(cmd);
            }

            // Envia la longitud del mensaje
            byte[] buffer = new byte[4];
            buffer = BitConverter.GetBytes((int)cmd.ToByte().Length);
            _networkStream.Write(buffer, 0, 4);
            _networkStream.Flush();

            // Envia el mensaje
            buffer = cmd.ToByte();
            _networkStream.Write(buffer, 0, buffer.Length);

            _networkStream.Flush();

            semaphor.Release();
            return true;
         }
         catch
         {
            semaphor.Release();
            return false;
         }
      }

      private void SetMetaDataIfIsNull(OTCNetMessage cmd)
      {
         switch (cmd.Type)
         {
            case (OTCNetMessage.CommandType.ClientLoginInform):
               cmd.Message = IP.ToString() + ":" + _login;
               break;

            case (OTCNetMessage.CommandType.PCLockWithTimer):
            case (OTCNetMessage.CommandType.PCLogOFFWithTimer):
            case (OTCNetMessage.CommandType.PCRestartWithTimer):
            case (OTCNetMessage.CommandType.PCShutDownWithTimer):
            case (OTCNetMessage.CommandType.UserExitWithTimer):
               cmd.Message = "60000";
               break;

            default:
               cmd.Message = "\n";
               break;
         }
      }

      private void bwConnector_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (!((bool)e.Result))
         {
            OnConnectingFailed(new EventArgs());
         }
         else
         {
            OnConnectingSuccessed(new EventArgs());
         }

         ((BackgroundWorker)sender).Dispose();
      }

      private void bwConnector_DoWork(object sender, DoWorkEventArgs e)
      {
         try
         {
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _clientSocket.Connect(_serverEP);
            e.Result = true;
            _networkStream = new NetworkStream(this._clientSocket);
            _bwReceiver = new BackgroundWorker();
            _bwReceiver.WorkerSupportsCancellation = true;
            _bwReceiver.DoWork += new DoWorkEventHandler(StartReceive);
            _bwReceiver.RunWorkerAsync();

            // Inform to all clients that this client is now online.
            OTCNetMessage informToAllCMD = new OTCNetMessage(OTCNetMessage.CommandType.ClientLoginInform, IPAddress.Broadcast, IP.ToString() + ":" + _login);
            SendCommand(informToAllCMD);
         }
         catch
         {
            e.Result = false;
         }
      }

      #endregion

   }
}
