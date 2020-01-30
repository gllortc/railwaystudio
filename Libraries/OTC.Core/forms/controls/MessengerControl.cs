using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using otc.net;

namespace otc.forms.controls
{
   public partial class MessengerControl : UserControl
   {
      private bool _useAlerts = false;
      private OTCNetClient _client = null;

      public MessengerControl()
      {
         InitializeComponent();

         // Genera la instancia cliente de comunicaciones
         _client = new OTCNetClient();

         // Registra los eventos
         _client.OnMessageReceived += new OTCNetClient.MessageReceivedEventHandler(NetClient_OnMessageReceived);
      }

      private void MessengerControl_Load(object sender, EventArgs e)
      {
         // Configura las imagenes del control ListView
         lvwClients.SmallImageList = new ImageList();
         lvwClients.SmallImageList.ImageSize = new Size(16, 16);
         lvwClients.SmallImageList.Images.Add("IMG_BUDDY", global::otc.Properties.Resources.IMG_BUDDY_ON);
         lvwClients.SmallImageList.Images.Add("IMG_BUDDY_OFF", global::otc.Properties.Resources.IMG_BUDDY_OFF);
      }

      private void btnLogin_Click(object sender, EventArgs e)
      {
         if (String.IsNullOrEmpty(txtLogin.Text))
         {
            MessageBox.Show(this, "Debe proporcionar el nombre con el que se conocerá en la red (login).", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtLogin.Focus();
            return;
         }

         try
         {
            _client.Login = txtLogin.Text;
            _client.Connect();

            pnlLogin.Visible = false;
         }
         catch (Exception ex)
         {
            MessageBox.Show(this, ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void NetClient_OnMessageReceived(object message)
      {
      }

      #region Class Properties

      /// <summary>
      /// Devuelve o establece la IP (o el nombre UNC) del servidor de comunicaciones.
      /// </summary>
      public string Host
      {
         get { return _client.IP; }
         set { _client.IP = value; }
      }

      /// <summary>
      /// Devuelve o establece el puerto de comunicaciones.
      /// </summary>
      public int Port
      {
         get { return _client.Port; }
         set { _client.Port = value; }
      }

      /// <summary>
      /// Devuelve o establece el nombre de usuario con que actuará el cliente en la red.
      /// </summary>
      public string Login
      {
         get { return _client.Login; }
         set { _client.Login = value; }
      }

      /// <summary>
      /// Indica si se debe mostrar un aviso emergente de la barra de tareas de Windows al recibir mensajes de texto.
      /// </summary>
      public bool Connected
      {
         get { return _client.Connected; }
      }

      /// <summary>
      /// Indica si se debe mostrar un aviso emergente de la barra de tareas de Windows al recibir mensajes de texto.
      /// </summary>
      public bool ShowMessageAlerts
      {
         get { return _useAlerts; }
         set { _useAlerts = value; }
      }

      #endregion

      #region Class Methods

      /// <summary>
      /// Fuerza a conectar el cliente a la red.
      /// </summary>
      public void Connect()
      {
         try
         {
            _client.Connect();
         }
         catch (Exception ex)
         {
            MessageBox.Show(this, ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      /// <summary>
      /// Fuerza a conectar el cliente a la red.
      /// </summary>
      public void Disconnect()
      {
         _client.Disconnect();
      }

      #endregion
   }
}
