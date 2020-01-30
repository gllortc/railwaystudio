using System;
using System.Drawing;
using System.Windows.Forms;
using otc.panels;

namespace otc.forms.controls
{
   public partial class DecodersEditorControl : UserControl
   {
      private OTCPanel _panel = null;

      public DecodersEditorControl()
      {
         InitializeComponent();
      }

      /// <summary>
      /// Devuelve una instancia de RouteEditorControl;
      /// </summary>
      public DecodersEditorControl(OTCPanel panel)
      {
         InitializeComponent();
         this.Panel = panel;
      }

      #region Properties

      /// <summary>
      /// Devuelve o establece el panel para el que se desea editar las rutas.
      /// </summary>
      public OTCPanel Panel
      {
         get { return _panel; }
         set 
         { 
            _panel = value;
            RefreshList();
            RefreshStatus();
         }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Obliga al control a actualizar la lista de rutas del control.
      /// </summary>
      public void RefreshList()
      {
         lvwDecoders.Items.Clear();

         if (_panel == null) return;

         foreach (OTCAccessoryDecoder decoder in _panel.AccessoryDecodres)
         {
            ListViewItem item = new ListViewItem(decoder.Name, "ID_ACCDEC");
            item.SubItems.Add((decoder.Manufacturer + " " + decoder.Model).Trim());
            item.Tag = decoder;

            lvwDecoders.Items.Add(item);
         }
      }

      #endregion

      #region Event Handlers

      private void DecodersEditorControl_Load(object sender, EventArgs e)
      {
         RefreshStatus();

         // Configura los controles del formulario
         lvwDecoders.View = View.Details;
         lvwDecoders.FullRowSelect = true;
         lvwDecoders.FullRowSelect = true;
         lvwDecoders.HideSelection = false;

         lvwDecoders.Items.Clear();
         lvwDecoders.Columns.Clear();
         lvwDecoders.Columns.Add("Nombre", 100);
         lvwDecoders.Columns.Add("Tipo", 120);

         lvwDecoders.SmallImageList = new ImageList();
         lvwDecoders.SmallImageList.ImageSize = new Size(16, 16);
         lvwDecoders.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
         lvwDecoders.SmallImageList.Images.Add("ID_ACCDEC", global::otc.Properties.Resources.IMG_DECODER_OBJECT);
      }

      private void btnAdd_Click(object sender, EventArgs e)
      {
         frmDecoderAccessory decoder = new frmDecoderAccessory();
         
         if (decoder.ShowDialog(this) == DialogResult.OK)
         {
            _panel.AccessoryDecodres.Add(decoder.Decoder);
            RefreshList();
         }
      }

      private void btnEdit_Click(object sender, EventArgs e)
      {
         if (lvwDecoders.SelectedItems.Count <= 0)
         {
            MessageBox.Show(this, "Debe seleccionar el elemento de control para la que desea ver/editar las propiedades.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            lvwDecoders.Focus();
            return;
         }

         frmDecoderAccessory decoder = new frmDecoderAccessory((OTCAccessoryDecoder)lvwDecoders.SelectedItems[0].Tag);
         if (decoder.ShowDialog(this) == DialogResult.OK)
         {
            _panel.AccessoryDecodres.Add(decoder.Decoder);
            RefreshList();
         }
      }

      private void btnDelete_Click(object sender, EventArgs e)
      {
         if (lvwDecoders.SelectedItems.Count <= 0)
         {
            MessageBox.Show(this, "Debe seleccionar la ruta que desea eliminar.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            lvwDecoders.Focus();
            return;
         }

         if (MessageBox.Show(this, "¿Desea eliminar el elemento " + ((OTCAccessoryDecoder)lvwDecoders.SelectedItems[0].Tag).Name + "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.OK)
         {
            _panel.AccessoryDecodres.Delete((OTCAccessoryDecoder)lvwDecoders.SelectedItems[0].Tag);
            RefreshList();
         }
      }

      private void lvwDecoders_DoubleClick(object sender, EventArgs e)
      {
         this.btnEdit_Click(sender, e);
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Establece el estado del control.
      /// </summary>
      private void RefreshStatus()
      {
         tbrTools.Enabled = (_panel != null);
         lvwDecoders.Enabled = (_panel != null);
      }

      #endregion
   }
}
