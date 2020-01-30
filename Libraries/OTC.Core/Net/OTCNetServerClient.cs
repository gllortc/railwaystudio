using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Rwm.Otc.Net
{

   /// <summary>
   /// The class that contains some methods and properties to manage the remote clients.
   /// </summary>
   public class OTCNetServerClient
   {
      private Socket _socket;
      private string _login;
      private NetworkStream _netStream;
      private BackgroundWorker _bwReceiver;
      private Semaphore _semaphor = new Semaphore(1, 1);

      /// <summary>
      /// Creates an instance of ClientManager class to comunicate with remote clients.
      /// </summary>
      /// <param name="clientSocket">The socket of ClientManager.</param>
      public OTCNetServerClient(Socket clientSocket)
      {
         _socket = clientSocket;
         _netStream = new NetworkStream(_socket);
         _bwReceiver = new BackgroundWorker();
         _bwReceiver.DoWork += new DoWorkEventHandler(StartReceive);
         _bwReceiver.RunWorkerAsync();
      }

      /// <summary>
      /// Gets the IP address of connected remote client.This is 'IPAddress.None' if the client is not connected.
      /// </summary>
      public IPAddress IP
      {
         get
         {
            if (_socket != null)
               return ((IPEndPoint)_socket.RemoteEndPoint).Address;
            else
               return IPAddress.None;
         }
      }
      /// <summary>
      /// Gets the port number of connected remote client.This is -1 if the client is not connected.
      /// </summary>
      public int Port
      {
         get
         {
            if (_socket != null)
               return ((IPEndPoint)_socket.RemoteEndPoint).Port;
            else
               return -1;
         }
      }
      /// <summary>
      /// [Gets] The value that specifies the remote client is connected to this server or not.
      /// </summary>
      public bool Connected
      {
         get
         {
            if (_socket != null)
               return _socket.Connected;
            else
               return false;
         }
      }

      /// <summary>
      /// The name of remote client.
      /// </summary>
      public string ClientLogin
      {
         get { return _login; }
         set { _login = value; }
      }

      private void StartReceive(object sender, DoWorkEventArgs e)
      {
         while (_socket.Connected)
         {
            if (_netStream.DataAvailable)
            {
               // Obtiene la longitud del mensaje
               byte[] buffer = new byte[4];
               int readBytes = _netStream.Read(buffer, 0, 4);
               if (readBytes == 0)
                  break;
               int numbytes = BitConverter.ToInt32(buffer, 0);

               // Lee los bytes del mensaje
               buffer = new byte[numbytes];
               readBytes = _netStream.Read(buffer, 0, numbytes);
               if (readBytes == 0)
                  break;

               // Convierte los datos en el mensaje
               OTCNetMessage cmd = new OTCNetMessage(buffer);
               OnCommandReceived(new CommandEventArgs(cmd));

               /*
               //Read the command's Type.
               byte[] buffer = new byte[4];
               int readBytes = _netStream.Read(buffer, 0, 4);
               if (readBytes == 0)
                  break;
               CommandType cmdType = (CommandType)(BitConverter.ToInt32(buffer, 0));

               //Read the command's target size.
               string cmdTarget = "";
               buffer = new byte[4];
               readBytes = _netStream.Read(buffer, 0, 4);
               if (readBytes == 0)
                  break;
               int ipSize = BitConverter.ToInt32(buffer, 0);

               //Read the command's target.
               buffer = new byte[ipSize];
               readBytes = _netStream.Read(buffer, 0, ipSize);
               if (readBytes == 0)
                  break;
               cmdTarget = System.Text.Encoding.ASCII.GetString(buffer);

               //Read the command's Message size.
               string cmdMetaData = "";
               buffer = new byte[4];
               readBytes = _netStream.Read(buffer, 0, 4);
               if (readBytes == 0)
                  break;
               int metaDataSize = BitConverter.ToInt32(buffer, 0);

               //Read the command's Meta data.
               buffer = new byte[metaDataSize];
               readBytes = _netStream.Read(buffer, 0, metaDataSize);
               if (readBytes == 0)
                  break;
               cmdMetaData = System.Text.Encoding.Unicode.GetString(buffer);

               OTCNetMessage cmd = new OTCNetMessage(cmdType, IPAddress.Parse(cmdTarget), cmdMetaData);
               cmd.FromIP = this.IP;
               if (cmd.Type == CommandType.ClientLoginInform)
                  cmd.From = cmd.Message.Split(new char[] { ':' })[1];
               else
                  cmd.From = this.ClientLogin;
               OnCommandReceived(new CommandEventArgs(cmd));
               */
            }
         }

         OnDisconnected(new ClientEventArgs(this._socket));
         Disconnect();
      }

      private void bwSender_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (!e.Cancelled && e.Error == null && ((bool)e.Result))
            OnCommandSent(new EventArgs());
         else
            OnCommandFailed(new EventArgs());

         ((BackgroundWorker)sender).Dispose();
         GC.Collect();
      }

      private void bwSender_DoWork(object sender, DoWorkEventArgs e)
      {
         OTCNetMessage cmd = (OTCNetMessage)e.Argument;
         e.Result = SendCommandToClient(cmd);
      }

      // This Semaphor is to protect the critical section from concurrent access of sender threads.
      private bool SendCommandToClient(OTCNetMessage cmd)
      {

         try
         {
            _semaphor.WaitOne();

            // Envia la longitud del mensaje
            byte[] buffer = new byte[4];
            buffer = BitConverter.GetBytes((int)cmd.ToByte().Length);
            _netStream.Write(buffer, 0, 4);
            _netStream.Flush();

            // Envia el mensaje
            buffer = cmd.ToByte();
            _netStream.Write(buffer, 0, buffer.Length);

            _netStream.Flush();

            /*
            // Type
            byte[] buffer = new byte[4];
            buffer = BitConverter.GetBytes((int)cmd.Type);
            _netStream.Write(buffer, 0, 4);
            _netStream.Flush();

            // Sender IP
            byte[] FromIPBuffer = Encoding.ASCII.GetBytes(cmd.FromIP.ToString());
            buffer = new byte[4];
            buffer = BitConverter.GetBytes(FromIPBuffer.Length);
            _netStream.Write(buffer, 0, 4);
            _netStream.Flush();
            _netStream.Write(FromIPBuffer, 0, FromIPBuffer.Length);
            _netStream.Flush();

            // Sender Name
            byte[] senderNameBuffer = Encoding.Unicode.GetBytes(cmd.From.ToString());
            buffer = new byte[4];
            buffer = BitConverter.GetBytes(senderNameBuffer.Length);
            _netStream.Write(buffer, 0, 4);
            _netStream.Flush();
            _netStream.Write(senderNameBuffer, 0, senderNameBuffer.Length);
            _netStream.Flush();

            // Target
            byte[] ipBuffer = Encoding.ASCII.GetBytes(cmd.ToIP.ToString());
            buffer = new byte[4];
            buffer = BitConverter.GetBytes(ipBuffer.Length);
            _netStream.Write(buffer, 0, 4);
            _netStream.Flush();
            _netStream.Write(ipBuffer, 0, ipBuffer.Length);
            _netStream.Flush();

            // Meta Data.
            if (String.IsNullOrEmpty(cmd.Message))
               cmd.Message = "\n";

            byte[] metaBuffer = Encoding.Unicode.GetBytes(cmd.Message);
            buffer = new byte[4];
            buffer = BitConverter.GetBytes(metaBuffer.Length);
            _netStream.Write(buffer, 0, 4);
            _netStream.Flush();
            _netStream.Write(metaBuffer, 0, metaBuffer.Length);
            _netStream.Flush();
            */

            _semaphor.Release();
            return true;
         }
         catch
         {
            _semaphor.Release();
            return false;
         }
      }

      /// <summary>
      /// Sends a command to the remote client if the connection is alive.
      /// </summary>
      /// <param name="cmd">The command to send.</param>
      public void SendCommand(OTCNetMessage cmd)
      {
         if (_socket != null && _socket.Connected)
         {
            BackgroundWorker bwSender = new BackgroundWorker();
            bwSender.DoWork += new DoWorkEventHandler(bwSender_DoWork);
            bwSender.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwSender_RunWorkerCompleted);
            bwSender.RunWorkerAsync(cmd);
         }
         else
            OnCommandFailed(new EventArgs());
      }

      /// <summary>
      /// Disconnect the current client manager from the remote client and returns true if the client had been disconnected from the server.
      /// </summary>
      /// <returns>True if the remote client had been disconnected from the server,otherwise false.</returns>
      public bool Disconnect()
      {
         if (_socket != null && _socket.Connected)
         {
            try
            {
               _socket.Shutdown(SocketShutdown.Both);
               _socket.Close();
               return true;
            }
            catch
            {
               return false;
            }
         }
         else
            return true;
      }

      /// <summary>
      /// Occurs when a command received from a remote client.
      /// </summary>
      public event CommandReceivedEventHandler CommandReceived;

      /// <summary>
      /// Occurs when a command received from a remote client.
      /// </summary>
      /// <param name="e">Received command.</param>
      protected virtual void OnCommandReceived(CommandEventArgs e)
      {
         if (CommandReceived != null) CommandReceived(this, e);
      }

      /// <summary>
      /// Occurs when a command had been sent to the remote client successfully.
      /// </summary>
      public event CommandSentEventHandler CommandSent;

      /// <summary>
      /// Occurs when a command had been sent to the remote client successfully.
      /// </summary>
      /// <param name="e">The sent command.</param>
      protected virtual void OnCommandSent(EventArgs e)
      {
         if (CommandSent != null) CommandSent(this, e);
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
         if (CommandFailed != null) CommandFailed(this, e);
      }

      /// <summary>
      /// Occurs when a client disconnected from this server.
      /// </summary>
      public event ClientDisconnectedEventHandler Disconnected;

      /// <summary>
      /// Occurs when a client disconnected from this server.
      /// </summary>
      /// <param name="e">Client information.</param>
      protected virtual void OnDisconnected(ClientEventArgs e)
      {
         if (Disconnected != null) Disconnected(e);
      }
   }
}
