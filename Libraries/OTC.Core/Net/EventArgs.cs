using System;
using System.Net;
using System.Net.Sockets;

namespace Rwm.Otc.Net
{

   /// <summary>
   /// Occurs when a command received from the server.
   /// </summary>
   /// <param name="sender">Sender.</param>
   /// <param name="e">The information about the received command.</param>
   public delegate void CommandReceivedEventHandler(object sender, CommandEventArgs e);

   /// <summary>
   /// Occurs when a command had been sent to the the remote server Successfully.
   /// </summary>
   /// <param name="sender">Sender.</param>
   /// <param name="e">EventArgs.</param>
   public delegate void CommandSentEventHandler(object sender, EventArgs e);

   /// <summary>
   /// Occurs when a command sending action had been failed.This is because disconnection or sending exception.
   /// </summary>
   /// <param name="sender">Sender.</param>
   /// <param name="e">EventArgs.</param>
   public delegate void CommandSendingFailedEventHandler(object sender, EventArgs e);

   /// <summary>
   /// The class that contains information about a command.
   /// </summary>
   public class CommandEventArgs : EventArgs
   {
      private OTCNetMessage _cmd;

      /// <summary>
      /// The received command.
      /// </summary>
      public OTCNetMessage Command
      {
         get { return _cmd; }
      }

      /// <summary>
      /// Creates an instance of CommandEventArgs class.
      /// </summary>
      /// <param name="cmd">The received command.</param>
      public CommandEventArgs(OTCNetMessage cmd)
      {
         _cmd = cmd;
      }
   }

   /// <summary>
   /// Occurs when the server had been disconnected from this client.
   /// </summary>
   /// <param name="sender">Sender.</param>
   /// <param name="e">The server information.</param>
   public delegate void ServerDisconnectedEventHandler(object sender, ServerEventArgs e);

   /// <summary>
   /// The class that contains information about the server.
   /// </summary>
   public class ServerEventArgs : EventArgs
   {
      private Socket _socket;

      /// <summary>
      /// The IP address of server.
      /// </summary>
      public IPAddress IP
      {
         get { return ((IPEndPoint)_socket.RemoteEndPoint).Address; }
      }

      /// <summary>
      /// The port of server.
      /// </summary>
      public int Port
      {
         get { return ((IPEndPoint)_socket.RemoteEndPoint).Port; }
      }

      /// <summary>
      /// Creates an instance of ServerEventArgs class.
      /// </summary>
      /// <param name="clientSocket">The client socket of current CommandClient instance.</param>
      public ServerEventArgs(Socket clientSocket)
      {
         _socket = clientSocket;
      }
   }

   /// <summary>
   /// Client event args.
   /// </summary>
   public class ClientEventArgs : EventArgs
   {
      private Socket _socket;

      /// <summary>
      /// The ip address of remote client.
      /// </summary>
      public IPAddress IP
      {
         get { return ((IPEndPoint)_socket.RemoteEndPoint).Address; }
      }

      /// <summary>
      /// The port of remote client.
      /// </summary>
      public int Port
      {
         get { return ((IPEndPoint)_socket.RemoteEndPoint).Port; }
      }

      /// <summary>
      /// Creates an instance of ClientEventArgs class.
      /// </summary>
      /// <param name="clientManagerSocket">The socket of server side socket that comunicates with the remote client.</param>
      public ClientEventArgs(Socket clientManagerSocket)
      {
         _socket = clientManagerSocket;
      }
   }

   /// <summary>
   /// Occurs when this client disconnected from the server.
   /// </summary>
   /// <param name="sender">Sender.</param>
   /// <param name="e">EventArgs.</param>
   public delegate void DisconnectedEventHandler(object sender, EventArgs e);

   /// <summary>
   /// Occurs when this client disconnected from the server.
   /// </summary>
   /// <param name="e">EventArgs.</param>
   public delegate void ClientDisconnectedEventHandler(ClientEventArgs e);

   /// <summary>
   /// Occurs when this client connected to the remote server Successfully.
   /// </summary>
   /// <param name="sender">Sender.</param>
   /// <param name="e">EventArgs.</param>
   public delegate void ConnectingSuccessedEventHandler(object sender, EventArgs e);

   /// <summary>
   /// Occurs when this client failed on connecting to server.
   /// </summary>
   /// <param name="sender">Sender.</param>
   /// <param name="e">EventArgs.</param>
   public delegate void ConnectingFailedEventHandler(object sender, EventArgs e);

   /// <summary>
   /// Occurs when the network had been failed.
   /// </summary>
   /// <param name="sender">Sender.</param>
   /// <param name="e">EventArgs.</param>
   public delegate void NetworkDeadEventHandler(object sender, EventArgs e);

   /// <summary>
   /// Occurs when the network had been started to work.
   /// </summary>
   /// <param name="sender">Sender.</param>
   /// <param name="e">EventArgs.</param>
   public delegate void NetworkAlivedEventHandler(object sender, EventArgs e);

}
