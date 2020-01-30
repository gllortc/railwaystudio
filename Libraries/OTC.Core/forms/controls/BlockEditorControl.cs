using System.ComponentModel;
using System.Windows.Forms;
using otc.panels;

namespace otc.forms.controls
{
   /// <summary>
   /// Implementa un editor de propiedades para todos los tipos de bloque soportados.
   /// </summary>
   public partial class BlockEditorControl : UserControl
   {
      private OTCPanelBlock _block = null;
      private OTCPanel _panel = null;

      /// <summary>
      /// Devuelve una instancia de BlockEditor.
      /// </summary>
      public BlockEditorControl()
      {
         InitializeComponent();
      }

      #region Control Properties

      /// <summary>
      /// Devuelve o establece el bloque para el que se desea mostrar las propiedades.
      /// </summary>
      public OTCPanelBlock Block
      {
         get 
         {
            GetProperties();
            return _block; 
         }
         
         set 
         { 
            _block = value;
            SetProperties();
         }
      }

      /// <summary>
      /// Devuelve o establece el panel al que pertenece el bloque.
      /// </summary>
      public OTCPanel Panel
      {
         get { return _panel; }
         set { _panel = value; }
      }

      #endregion

      #region Control Events

      /// <summary>
      /// Dispara el evento OnInformation.
      /// </summary>
      /// <param name="e">La información a mostrar al usuario.</param>
      public delegate void BlockUpdatedEventHandler(OTCSchemaEventArgs e);

      /// <summary>
      /// Evento que se lanza cuando el control genera un mensaje de salida.
      /// </summary>
      [Category("Blocks")]
      [Description("Evento que se lanza cuando el usuario pulsa el botón de actualizar propiedades.")]
      public event BlockUpdatedEventHandler OnBlockUpdated;

      #endregion

      #region Private members

      /// <summary>
      /// Genera una lista de descodificadores en un control ImageComboBox.
      /// </summary>
      /// <param name="control">Control que se desea rellenar con la lista de descodificadores.</param>
      /// <param name="selected">Identificador del elemento seleccionado por defecto.</param>
      private void DecodersList(otc.forms.controls.ImageComboBox control, int selected)
      {
         int index = 0;

         control.Items.Clear();
         control.Items.Add(new ImageComboBoxItem("<No asociado>", 0));
         foreach (otc.panels.OTCAccessoryDecoder decoder in _panel.AccessoryDecodres)
         {
            control.Items.Add(new ImageComboBoxItem(decoder.Name + " (" + decoder.Model + ")", 
                                                    decoder.ID, 
                                                    (System.Drawing.Image)global::otc.Properties.Resources.IMG_DECODER_OBJECT));

            if (decoder.ID == selected) index = control.Items.Count - 1;
         }

         control.SelectedIndex = index;
      }

      /// <summary>
      /// Deja el control en blanco.
      /// </summary>
      private void ClearProperties()
      {
         // Oculta los paneles
         foreach (Control control in pnlProperties.Controls)
         {
            if (control.GetType() == typeof(Panel))
               ((Panel)control).Visible = false;
         }

         // Limpia las listas desplegables
         cboTurnoutStatus.Items.Clear();
         cboTurnoutInitialStatus.Items.Clear();
         cboTurnoutConnection.Items.Clear();
         cboTurnoutDecoder.Items.Clear();

         cboSignal2SStatus.Items.Clear();
         cboSignal2SInitialStatus.Items.Clear();
         cboSignal2SConnection.Items.Clear();
         cboSignal2SDecoder.Items.Clear();

         cboSwitchStatus.Items.Clear();
         cboSwitchInitialStatus.Items.Clear();
         cboSwitchConnection.Items.Clear();
         cboSwitchDecoder.Items.Clear();

         // Limpia los controles comunes
         lblType.Text = "";
         txtName.Text = "";
         lblId.Text = "";
         lblSchema.Text = "";
         lblX.Text = "";
         lblY.Text = "";
         lblRotation.Text = "";

         btnUpdate.Enabled = false;
         pnlProperties.Visible = false;
      }

      /// <summary>
      /// Actualiza el control con las propiedades del bloque proporcionado.
      /// </summary>
      private void SetProperties()
      {
         ClearProperties();
         if (_block == null) return;

         pnlProperties.Visible = true;
         btnUpdate.Enabled = true;

         // Propiedades comunes
         lblType.Text = _block.LibraryBlock.Name;
         txtName.Text = _block.Name;
         lblId.Text = _block.Id.ToString();
         lblSchema.Text = "";
         lblX.Text = _block.X.ToString();
         lblY.Text = _block.Y.ToString();
         lblRotation.Text = _block.Rotation.ToString();

         switch (_block.LibraryBlock.Type)
         {
            case OTCLibraryBlock.BlockTypes.Static:
               break;

            case OTCLibraryBlock.BlockTypes.Turnout:
               txtTurnoutAddress.Text = _block.DigitalAddress.ToString();
               txtTurnoutHotkey.Text = _block.AssignedKey;
               cboTurnoutStatus.Items.Add(new ImageComboBoxItem("Recto", (int)OTCBlockStatus.Red_Straight, global::otc.Properties.Resources.IMG_TURNOUT_STRAIGHT));
               cboTurnoutStatus.Items.Add(new ImageComboBoxItem("Desviado", (int)OTCBlockStatus.Green_Turned, global::otc.Properties.Resources.IMG_TURNOUT_TURNED));
               cboTurnoutStatus.SelectItem((int)_block.Status);
               cboTurnoutInitialStatus.Items.Add(new ImageComboBoxItem("Recto", (int)OTCBlockStatus.Red_Straight, global::otc.Properties.Resources.IMG_TURNOUT_STRAIGHT));
               cboTurnoutInitialStatus.Items.Add(new ImageComboBoxItem("Desviado", (int)OTCBlockStatus.Green_Turned, global::otc.Properties.Resources.IMG_TURNOUT_TURNED));
               cboTurnoutInitialStatus.Items.Add(new ImageComboBoxItem("Sin estado", (int)OTCBlockStatus.None, global::otc.Properties.Resources.IMG_TURNOUT_NONE));
               cboTurnoutInitialStatus.SelectItem((int)_block.InitialStatus);
               cboTurnoutConnection.ImageSize = new System.Drawing.Size(28, 16);
               cboTurnoutConnection.Items.Add(new ImageComboBoxItem("S1 - Recto", (int)OTCBlockConnection.S1StarightS2Turned, global::otc.Properties.Resources.IMG_CONNECTION_2S1));
               cboTurnoutConnection.Items.Add(new ImageComboBoxItem("S2 - Recto", (int)OTCBlockConnection.S2StarightS1Turned, global::otc.Properties.Resources.IMG_CONNECTION_2S2));
               cboTurnoutConnection.SelectItem((int)_block.Connection);
               DecodersList(cboTurnoutDecoder, _block.DecoderId);
               pnlTurnout.Visible = true;
               break;

            case OTCLibraryBlock.BlockTypes.Signal2S:
               txtSignal2SAddress.Text = _block.DigitalAddress.ToString();
               txtSignal2SHotkey.Text = _block.AssignedKey;
               cboSignal2SStatus.Items.Add(new ImageComboBoxItem("Rojo", (int)OTCBlockStatus.Red_Straight, global::otc.Properties.Resources.IMG_SIGNAL_RED));
               cboSignal2SStatus.Items.Add(new ImageComboBoxItem("Verde", (int)OTCBlockStatus.Green_Turned, global::otc.Properties.Resources.IMG_SIGNAL_GREEN));
               cboSignal2SStatus.SelectItem((int)_block.Status);
               cboSignal2SInitialStatus.Items.Add(new ImageComboBoxItem("Rojo", (int)OTCBlockStatus.Red_Straight, global::otc.Properties.Resources.IMG_SIGNAL_RED));
               cboSignal2SInitialStatus.Items.Add(new ImageComboBoxItem("Verde", (int)OTCBlockStatus.Green_Turned, global::otc.Properties.Resources.IMG_SIGNAL_GREEN));
               cboSignal2SInitialStatus.Items.Add(new ImageComboBoxItem("Sin estado", (int)OTCBlockStatus.None, global::otc.Properties.Resources.IMG_SIGNAL_OFF));
               cboSignal2SInitialStatus.SelectItem((int)_block.InitialStatus);
               cboSignal2SConnection.ImageSize = new System.Drawing.Size(28, 16);
               cboSignal2SConnection.Items.Add(new ImageComboBoxItem("S1 - Rojo", (int)OTCBlockConnection.S1StarightS2Turned, global::otc.Properties.Resources.IMG_CONNECTION_2S1));
               cboSignal2SConnection.Items.Add(new ImageComboBoxItem("S2 - Rojo", (int)OTCBlockConnection.S2StarightS1Turned, global::otc.Properties.Resources.IMG_CONNECTION_2S2));
               cboSignal2SConnection.SelectItem((int)_block.Connection);
               DecodersList(cboSignal2SDecoder, _block.DecoderId);
               pnlSignal2S.Visible = true;
               break;

            case OTCLibraryBlock.BlockTypes.Switch:
               txtSwitchAddress.Text = _block.DigitalAddress.ToString();
               txtSwitchHotkey.Text = _block.AssignedKey;
               cboSwitchStatus.Items.Add(new ImageComboBoxItem("Desconectado", (int)OTCBlockStatus.Red_Straight, global::otc.Properties.Resources.IMG_SWITCH_OFF));
               cboSwitchStatus.Items.Add(new ImageComboBoxItem("Conectado", (int)OTCBlockStatus.Green_Turned, global::otc.Properties.Resources.IMG_SWITCH_ON));
               cboSwitchStatus.SelectItem((int)_block.Status);
               cboSwitchInitialStatus.Items.Add(new ImageComboBoxItem("Desconectado", (int)OTCBlockStatus.Red_Straight, global::otc.Properties.Resources.IMG_SWITCH_OFF));
               cboSwitchInitialStatus.Items.Add(new ImageComboBoxItem("Conectado", (int)OTCBlockStatus.Green_Turned, global::otc.Properties.Resources.IMG_SWITCH_ON));
               cboSwitchInitialStatus.Items.Add(new ImageComboBoxItem("Sin estado", (int)OTCBlockStatus.None, global::otc.Properties.Resources.IMG_SWITCH_NONE));
               cboSwitchInitialStatus.SelectItem((int)_block.InitialStatus);
               cboSwitchConnection.ImageSize = new System.Drawing.Size(28, 16);
               cboSwitchConnection.Items.Add(new ImageComboBoxItem("S1 - Conectado", (int)OTCBlockConnection.S1StarightS2Turned, global::otc.Properties.Resources.IMG_CONNECTION_2S1));
               cboSwitchConnection.Items.Add(new ImageComboBoxItem("S2 - Conectado", (int)OTCBlockConnection.S2StarightS1Turned, global::otc.Properties.Resources.IMG_CONNECTION_2S2));
               cboSwitchConnection.SelectItem((int)_block.Connection);
               DecodersList(cboSwitchDecoder, _block.DecoderId);
               pnlSwitch.Visible = true;
               break;

            case OTCLibraryBlock.BlockTypes.RouteActivator:
               txtRouteHotKey.Text = _block.AssignedKey;
               pnlRouteSwitch.Visible = true;
               break;
         }
      }

      /// <summary>
      /// Actualiza el bloque con las propiedades del control.
      /// </summary>
      private void GetProperties()
      {
         if (_block == null) return;

         // Propiedades comunes
         _block.Name = txtName.Text;

         switch (_block.LibraryBlock.Type)
         {
            case OTCLibraryBlock.BlockTypes.Static:
               break;

            case OTCLibraryBlock.BlockTypes.Turnout:
               _block.DigitalAddress = int.Parse(txtTurnoutAddress.Text);
               _block.AssignedKey = txtTurnoutHotkey.Text;
               _block.Status = (OTCBlockStatus)((ImageComboBoxItem)cboTurnoutStatus.SelectedItem).Value;
               _block.InitialStatus = (OTCBlockStatus)((ImageComboBoxItem)cboTurnoutInitialStatus.SelectedItem).Value;
               _block.Connection = (OTCBlockConnection)((ImageComboBoxItem)cboTurnoutConnection.SelectedItem).Value;
               _block.DecoderId = ((ImageComboBoxItem)cboTurnoutDecoder.SelectedItem).Value;
               break;

            case OTCLibraryBlock.BlockTypes.Signal2S:
               _block.DigitalAddress = int.Parse(txtSignal2SAddress.Text);
               _block.AssignedKey = txtSignal2SHotkey.Text;
               _block.Status = (OTCBlockStatus)((ImageComboBoxItem)cboSignal2SStatus.SelectedItem).Value;
               _block.InitialStatus = (OTCBlockStatus)((ImageComboBoxItem)cboSignal2SInitialStatus.SelectedItem).Value;
               _block.Connection = (OTCBlockConnection)((ImageComboBoxItem)cboSignal2SConnection.SelectedItem).Value;
               _block.DecoderId = ((ImageComboBoxItem)cboSignal2SDecoder.SelectedItem).Value;
               break;

            case OTCLibraryBlock.BlockTypes.Switch:
               _block.DigitalAddress = int.Parse(txtSwitchAddress.Text);
               _block.AssignedKey = txtSwitchHotkey.Text;
               _block.Status = (OTCBlockStatus)((ImageComboBoxItem)cboSwitchStatus.SelectedItem).Value;
               _block.InitialStatus = (OTCBlockStatus)((ImageComboBoxItem)cboSwitchInitialStatus.SelectedItem).Value;
               _block.Connection = (OTCBlockConnection)((ImageComboBoxItem)cboSwitchConnection.SelectedItem).Value;
               _block.DecoderId = ((ImageComboBoxItem)cboSwitchDecoder.SelectedItem).Value;
               break;

            case OTCLibraryBlock.BlockTypes.RouteActivator:
               _block.AssignedKey = txtRouteHotKey.Text;

               // Si la ruta existe, actualiza sus propiedades

               break;

            default:
               _block.DigitalAddress = 0;
               _block.AssignedKey = "";
               _block.Status = OTCBlockStatus.None;
               _block.InitialStatus = OTCBlockStatus.None;
               _block.Connection = OTCBlockConnection.Undefined;
               break;
         }
      }

      /// <summary>
      /// Lanza el evento OnBlockUpdated.
      /// </summary>
      private void btnUpdate_Click(object sender, System.EventArgs e)
      {
         GetProperties();

         if (OnBlockUpdated != null)
            OnBlockUpdated(new OTCSchemaEventArgs(_block));
      }

      #endregion

   }
}
