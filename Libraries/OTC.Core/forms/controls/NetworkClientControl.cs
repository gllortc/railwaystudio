using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using otc.net;

namespace otc.forms.controls
{
   /// <summary>
   /// Implementa un cliente de red de OTC.
   /// </summary>
   public partial class NetworkClientControl : UserControl
   {
      private bool _showMsgAlerts = false;
      private IPAddress _srvIp;
      private int _srvPort;
      private string _soundRecv;
      private OTCNetClient _client;
      private List<frmPrivate> _privateWindowsList;

      /// <summary>
      /// Devuelve una instancia de NetworkClientControl.
      /// </summary>
      public NetworkClientControl()
      {
         InitializeComponent();

         uebContainer.Dock = DockStyle.Fill;
         pnlLogin.Dock = DockStyle.Fill;

         // Configura el control ListView
         lstViwUsers.View = View.Details;
         lstViwUsers.Items.Clear();
         lstViwUsers.Columns.Clear();
         lstViwUsers.Columns.Add("Nombre", 180);
         lstViwUsers.Columns.Add("IP", 90);
         lstViwUsers.HeaderStyle = ColumnHeaderStyle.None;
         lstViwUsers.SmallImageList = new ImageList();
         lstViwUsers.SmallImageList.ImageSize = new System.Drawing.Size(16, 16);
         lstViwUsers.SmallImageList.Images.Add("IMG_NETWORK_USER", global::otc.Properties.Resources.IMG_NETWORK_USER);
         lstViwUsers.GridLines = false;

         _privateWindowsList = new List<frmPrivate>();
         _client = new OTCNetClient(IPAddress.Parse("127.0.0.1"), 103, "None");

         _client.CommandReceived += new CommandReceivedEventHandler(ClientCommandReceived);
         _client.ConnectingSuccessed += new ConnectingSuccessedEventHandler(ClientConnectingSuccessed);
         _client.ConnectingFailed += new ConnectingFailedEventHandler(ClientConnectingFailed);
      }

      /// <summary>
      /// Dirección IP del servidor.
      /// </summary>
      public IPAddress ServerIP
      {
         get { return _srvIp; }
         set { _srvIp = value; }
      }

      /// <summary>
      /// Puerto de comunicaciones usado para las conexiones con el servidor.
      /// </summary>
      public int ServerPort
      {
         get { return _srvPort; }
         set { _srvPort = value; }
      }

      /// <summary>
      /// Indica si el cliente está o no conectado.
      /// </summary>
      public bool Connected
      {
         get { return _client.Connected; }
      }

      /// <summary>
      /// Indica si se deben mostrar los mensajes recibidos en una ventana emergente.
      /// </summary>
      public bool ShowMessageAlerts
      {
         get { return _showMsgAlerts; }
         set { _showMsgAlerts = value; }
      }

      /// <summary>
      /// Devuelve o establece el archivo de sonido a reproducir cuando se recibe un mensaje.
      /// </summary>
      public string OnReceiveSoundFile
      {
         get { return _soundRecv; }
         set { _soundRecv = value; }
      }

      /// <summary>
      /// Guarda el contenido del cuadro de mensajes a un archivo RTF.
      /// </summary>
      public void Save()
      {
         SaveFileDialog saveDlg = new SaveFileDialog();
         saveDlg.Filter = "Texto enriquecido|*.rtf";
         saveDlg.FilterIndex = 0;
         saveDlg.RestoreDirectory = true;
         saveDlg.CheckPathExists = true;
         saveDlg.OverwritePrompt = true;
         saveDlg.FileName = this.Text;

         if (saveDlg.ShowDialog() == DialogResult.OK)
            txtMessages.SaveFile(saveDlg.FileName);
      }

      /// <summary>
      /// Procesa la pulsación de teclas en el control.
      /// </summary>
      protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
      {
         if (keyData == Keys.Enter)
            SendMessage();
         
         if (txtMessages.Focused && !OTCForms.IsValidKeyForReadOnlyFields(keyData))
            return true;

         return base.ProcessCmdKey(ref msg, keyData);
      }

      private void btnSend_Click(object sender, EventArgs e)
      {
         SendMessage();
      }

      void privateWindow_FormClosed(object sender, FormClosedEventArgs e)
      {
         _privateWindowsList.Remove((frmPrivate)sender);
      }

      private void btnPrivate_Click(object sender, EventArgs e)
      {
         StartPrivateChat();
      }

      private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
      {
         _client.Disconnect();
      }

      private void btnEnter_Click(object sender, EventArgs e)
      {
         SetEnablity(false);
         LoginToServer();
      }

      private void mniCopy_Click(object sender, EventArgs e)
      {
         txtNewMessage.Copy();
      }

      private void mniPaste_Click(object sender, EventArgs e)
      {
         txtNewMessage.Paste();
      }

      private void mniCopyText_Click(object sender, EventArgs e)
      {
         txtMessages.Copy();
      }

      private void mniPrivate_Click(object sender, EventArgs e)
      {
         StartPrivateChat();
      }

      #region Event handlers

      void ClientConnectingSuccessed(object sender, EventArgs e)
      {
         _client.SendCommand(new OTCNetMessage(OTCNetMessage.CommandType.IsNameExists, _client.IP, _client.Login));
      }

      void ClientCommandReceived(object sender, CommandEventArgs e)
      {
         switch (e.Command.Type)
         {
            case OTCNetMessage.CommandType.IsNameExists:
               if (e.Command.Message.ToLower() == "true")
               {
                  MessageBox.Show(this, "The Username is already exists!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  // _client.Disconnect();
                  SetEnablity(true);
               }
               else
               {
                  pnlLogin.Visible = false;
               }
               break;

            case OTCNetMessage.CommandType.Message:
               if (e.Command.ToIP.Equals(IPAddress.Broadcast))
               {
                  ShowMessage(e.Command.From, e.Command.Message);
               }
               else if (!IsPrivateWindowOpened(e.Command.From))
               {
                  OpenPrivateWindow(e.Command.FromIP, e.Command.From, e.Command.Message);
                  OTCForms.PlaySound(_soundRecv);
               }
               break;

            case OTCNetMessage.CommandType.FreeCommand:
               string[] newInfo = e.Command.Message.Split(new char[] { ':' });
               AddToList(newInfo[0], newInfo[1]);
               OTCForms.PlaySound(_soundRecv);
               break;

            case OTCNetMessage.CommandType.SendClientList:
               string[] clientInfo = e.Command.Message.Split(new char[] { ':' });
               AddToList(clientInfo[0], clientInfo[1]);
               break;

            case OTCNetMessage.CommandType.ClientLogOffInform:
               RemoveFromList(e.Command.From);
               break;
         }
      }

      private void OpenPrivateWindow(IPAddress remoteClientIP, string clientName, string initialMessage)
      {
         if (_client.Connected)
         {
            frmPrivate privateWindow = new frmPrivate(_client, remoteClientIP, clientName, initialMessage);
            _privateWindowsList.Add(privateWindow);
            privateWindow.FormClosed += new FormClosedEventHandler(privateWindow_FormClosed);
            privateWindow.Show(this);
         }
      }

      private void ClientConnectingFailed(object sender, EventArgs e)
      {
         MessageBox.Show(this, "Server Is Not Accessible!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         SetEnablity(true);
      }

      #endregion

      #region Private members

      private void SetEnablity(bool enable)
      {
         btnEnter.Enabled = enable;
         txtUsetName.Enabled = enable;
      }

      private void LoginToServer()
      {
         if (String.IsNullOrEmpty(txtUsetName.Text))
         {
            MessageBox.Show(this, "Debe proporcionar el nombre de la estación (login).", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            SetEnablity(true);
         }
         else
         {
            _client.Login = txtUsetName.Text.Trim();
            _client.ConnectToServer();

            _client.SendCommand(new OTCNetMessage(OTCNetMessage.CommandType.FreeCommand, IPAddress.Broadcast, _client.IP + ":" + _client.Login));
            _client.SendCommand(new OTCNetMessage(OTCNetMessage.CommandType.SendClientList, _client.ServerIP));
            AddToList(_client.IP.ToString(), this._client.Login);
         }
      }

      private void SendMessage()
      {
         if (_client.Connected && !String.IsNullOrEmpty(txtNewMessage.Text))
         {
            _client.SendCommand(new OTCNetMessage(OTCNetMessage.CommandType.Message, IPAddress.Broadcast, txtNewMessage.Text));

            ShowMessage(_client.Login, txtNewMessage.Text.Trim());

            txtNewMessage.Text = "";
            txtNewMessage.Focus();
         }
      }

      private void AddToList(string ip, string login)
      {
         ListViewItem newItem = lstViwUsers.Items.Add(login);
         newItem.ImageKey = "IMG_NETWORK_USER";
         newItem.SubItems.Add(ip);
      }

      private void RemoveFromList(string name)
      {
         ListViewItem item = lstViwUsers.FindItemWithText(name);
         if (item.Text != _client.IP.ToString())
         {
            lstViwUsers.Items.Remove(item);
            // ShareUtils.PlaySound(ShareUtils.SoundType.ClientExit);
         }

         frmPrivate target = FindPrivateWindow(name);
         if (target != null)
            target.Close();
      }

      private void OpenPrivateWindow(IPAddress remoteClientIP, string clientName)
      {
         if (_client.Connected)
         {
            if (!IsPrivateWindowOpened(clientName))
            {
               frmPrivate privateWindow = new frmPrivate(_client, remoteClientIP, clientName);
               _privateWindowsList.Add(privateWindow);
               privateWindow.FormClosed += new FormClosedEventHandler(privateWindow_FormClosed);
               privateWindow.StartPosition = FormStartPosition.CenterParent;
               privateWindow.Show(this);
            }
         }
      }

      private void StartPrivateChat()
      {
         if (lstViwUsers.SelectedItems.Count != 0)
            OpenPrivateWindow(IPAddress.Parse(lstViwUsers.SelectedItems[0].Text), lstViwUsers.SelectedItems[0].SubItems[1].Text);
      }

      private bool IsPrivateWindowOpened(string remoteName)
      {
         foreach (frmPrivate privateWindow in _privateWindowsList)
            if (privateWindow.RemoteName == remoteName)
               return true;

         return false;
      }

      private frmPrivate FindPrivateWindow(string remoteName)
      {
         foreach (frmPrivate privateWindow in _privateWindowsList)
            if (privateWindow.RemoteName == remoteName)
               return privateWindow;

         return null;
      }

      private void ShowMessage(string login, string message)
      {
         // Muestra el mensaje de texto
         txtMessages.SelectionStart = txtMessages.Text.Length;
         txtMessages.SelectionLength = 0;
         txtMessages.SelectionColor = System.Drawing.Color.Gray;
         txtMessages.SelectedText = login + Environment.NewLine;

         txtMessages.SelectionStart = txtMessages.Text.Length;
         txtMessages.SelectionLength = 0;
         txtMessages.SelectionColor = System.Drawing.Color.Black;
         txtMessages.SelectionBullet = true;
         txtMessages.SelectedText = message.Trim() + Environment.NewLine;

         txtMessages.SelectionStart = txtMessages.Text.Length;
         txtMessages.SelectionLength = 0;
         txtMessages.SelectionBullet = false;

         txtMessages.ScrollToCaret();

         // Muestra la notificación
         if (_showMsgAlerts)
         {
            Infragistics.Win.Misc.UltraDesktopAlertShowWindowInfo info = new Infragistics.Win.Misc.UltraDesktopAlertShowWindowInfo();
            info.Caption = login + " dice:";
            info.Text = message;
            info.PinButtonVisible = false;
            info.Image = global::otc.Properties.Resources.IMG_NETWORK_MESSAGE;
            udaNotifications.Show(info); 
         }
      }

      #endregion
   }
}
