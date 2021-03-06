using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using otc.net;

namespace otc.forms.controls
{

   /// <summary>
   /// Implementa un formulario para chat privado con otras estaciones de la red OTC.
   /// </summary>
   public partial class frmPrivate : Form
   {
      private OTCNetClient _client;
      private IPAddress _toIP;
      private string _login;
      private string _recvsound;
      private bool _enabled;

      /// <summary>
      /// Devuelve una instancia de frmPrivate.
      /// </summary>
      public frmPrivate(OTCNetClient cmdClient, IPAddress friendIP, string name, string initialMessage)
      {
         InitializeComponent();

         // Actualiza el caption del formualrio
         this.Text += " With " + name;

         _client = cmdClient;
         _toIP = friendIP;
         _login = name;
         _client.CommandReceived += new CommandReceivedEventHandler(private_CommandReceived);

         txtMessages.Text = this._login + ": " + initialMessage + Environment.NewLine;
      }

      /// <summary>
      /// Devuelve una instancia de frmPrivate.
      /// </summary>
      public frmPrivate(OTCNetClient cmdClient, IPAddress friendIP, string name)
      {
         InitializeComponent();

         // Actualiza el caption del formualrio
         this.Text += " With " + name;

         _client = cmdClient;
         _toIP = friendIP;
         _login = name;
         _client.CommandReceived += new CommandReceivedEventHandler(private_CommandReceived);
      }

      /// <summary>
      /// Login de la estación remota.
      /// </summary>
      public string RemoteName
      {
         get { return this._login; }
      }

      /// <summary>
      /// Devuelve o establece el nombre y ruta del archivo de sonido a reproducir cuando se recibe un mensaje.
      /// </summary>
      public string OnReceiveSoundFile
      {
         get { return _recvsound; }
         set { _recvsound = value; }
      }

      /// <summary>
      /// Procesa las teclas pulsadas en el formulario.
      /// </summary>
      protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
      {
         if (keyData == Keys.Enter)
            SendMessage();
         if (txtMessages.Focused && !OTCForms.IsValidKeyForReadOnlyFields(keyData))
            return true;
         
         return base.ProcessCmdKey(ref msg, keyData);
      }

      private void private_CommandReceived(object sender, CommandEventArgs e)
      {
         switch (e.Command.Type)
         {
            case (OTCNetMessage.CommandType.Message):
               if (!e.Command.ToIP.Equals(IPAddress.Broadcast) && e.Command.FromIP.Equals(_toIP))
               {
                  txtMessages.Text += e.Command.From + ": " + e.Command.Message + Environment.NewLine;
                  if (!_enabled) OTCForms.PlaySound(_recvsound);
               }
               break;
         }
      }

      private void btnSend_Click(object sender, EventArgs e)
      {
         this.SendMessage();
      }

      private void SendMessage()
      {
         if (_client.Connected && txtNewMessage.Text.Trim() != "")
         {
            _client.SendCommand(new OTCNetMessage(OTCNetMessage.CommandType.Message, _toIP, txtNewMessage.Text));
            txtMessages.Text += _client.Login + ": " + txtNewMessage.Text.Trim() + Environment.NewLine;
            txtNewMessage.Text = "";
            txtNewMessage.Focus();
         }
      }

      private void frmPrivate_FormClosing(object sender, FormClosingEventArgs e)
      {
         _client.CommandReceived -= new CommandReceivedEventHandler(private_CommandReceived);
      }

      private void mniExit_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void mniSave_Click(object sender, EventArgs e)
      {
         SaveFileDialog saveDlg = new SaveFileDialog();
         saveDlg.Filter = "Archivos de texto enriquecido|*.rtf";
         saveDlg.FilterIndex = 0;
         saveDlg.RestoreDirectory = true;
         saveDlg.CheckPathExists = true;
         saveDlg.OverwritePrompt = true;
         saveDlg.FileName = this.Text;
         if (saveDlg.ShowDialog() == DialogResult.OK)
            txtMessages.SaveFile(saveDlg.FileName);
      }

      private void frmPrivate_Load(object sender, EventArgs e)
      {
         this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.DesktopBounds.Height);
      }

      private void frmPrivate_Activated(object sender, EventArgs e)
      {
         _enabled = true;
      }

      private void frmPrivate_Deactivate(object sender, EventArgs e)
      {
         _enabled = false;
      }
   }

}