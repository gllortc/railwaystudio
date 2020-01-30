using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using otc.panels;

namespace otc.forms.controls
{
   public partial class RouteEditorControl : UserControl
   {
      private OTCSchema _schema = null;

      /// <summary>
      /// Devuelve una instancia de RouteEditorControl;
      /// </summary>
      public RouteEditorControl()
      {
         InitializeComponent();
      }

      /// <summary>
      /// Devuelve una instancia de RouteEditorControl;
      /// </summary>
      public RouteEditorControl(OTCSchema schema)
      {
         InitializeComponent();
         this.Schema = schema;
      }

      #region Properties

      /// <summary>
      /// Devuelve o establece el esquema para el que se desea editar las rutas.
      /// </summary>
      public OTCSchema Schema
      {
         get { return _schema; }
         set 
         { 
            _schema = value;
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
         lvwRoutes.Items.Clear();

         if (_schema == null) return;

         foreach (OTCRoute route in _schema.Routes)
         {
            ListViewItem item = new ListViewItem(route.Name, "ID_ROUTE");
            item.SubItems.Add(route.ElementCount.ToString());
            item.Tag = route;

            lvwRoutes.Items.Add(item);
         }
      }

      #endregion

      #region Events

      /// <summary>
      /// Dispara el evento OnInformation.
      /// </summary>
      /// <param name="e">La información a mostrar al usuario.</param>
      public delegate void OnRouteEditionStartEventHandler(OTCSchemaEventArgs e);

      /// <summary>
      /// Evento que se lanza cuando el usuario inicia la edición de una ruta.
      /// </summary>
      [Category("Routes")]
      [Description("Evento que se lanza cuando el usuario inicia la edición de una ruta.")]
      public event otc.forms.controls.BlockEditorControl.BlockUpdatedEventHandler OnRouteEditionStart;

      /// <summary>
      /// Dispara el evento OnInformation.
      /// </summary>
      /// <param name="e">La información a mostrar al usuario.</param>
      public delegate void OnRouteEditionEndEventHandler(OTCSchemaEventArgs e);

      /// <summary>
      /// Evento que se lanza cuando el usuario detiene la edición de una ruta.
      /// </summary>
      [Category("Routes")]
      [Description("Evento que se lanza cuando el usuario finaliza la edición de una ruta.")]
      public event otc.forms.controls.BlockEditorControl.BlockUpdatedEventHandler OnRouteEditionEnd;

      #endregion

      #region Event Handlers

      private void RouteEditorControl_Load(object sender, EventArgs e)
      {
         RefreshStatus();

         // Configura los controles del formulario
         lvwRoutes.View = View.Details;
         lvwRoutes.FullRowSelect = true;
         lvwRoutes.FullRowSelect = true;
         lvwRoutes.HideSelection = false;

         lvwRoutes.Items.Clear();
         lvwRoutes.Columns.Clear();
         lvwRoutes.Columns.Add("Nombre", 100);
         lvwRoutes.Columns.Add("Elementos", 70, HorizontalAlignment.Center);

         lvwRoutes.SmallImageList = new ImageList();
         lvwRoutes.SmallImageList.ImageSize = new Size(16, 16);
         lvwRoutes.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
         lvwRoutes.SmallImageList.Images.Add("ID_ROUTE", global::otc.Properties.Resources.IMG_ROUTE);
      }

      private void lvwRoutes_DoubleClick(object sender, EventArgs e)
      {
         this.btnEdit_Click(sender, e);
      }

      private void btnAdd_Click(object sender, EventArgs e)
      {
         frmRoute route = new frmRoute();
         if (route.ShowDialog(this) == DialogResult.OK)
         {
            _schema.Routes.Add(route.Route);
            RefreshList();
         }
      }

      private void btnEdit_Click(object sender, EventArgs e)
      {
         if (lvwRoutes.SelectedItems.Count <= 0)
         {
            MessageBox.Show(this, "Debe seleccionar la ruta para la que desea ver/editar las propiedades.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            lvwRoutes.Focus();
            return;
         }

         frmRoute route = new frmRoute((OTCRoute)lvwRoutes.SelectedItems[0].Tag);
         if (route.ShowDialog(this) == DialogResult.OK)
         {
            _schema.Routes.Add(route.Route);
            RefreshList();
         }
      }

      private void btnDelete_Click(object sender, EventArgs e)
      {
         if (lvwRoutes.SelectedItems.Count <= 0)
         {
            MessageBox.Show(this, "Debe seleccionar la ruta que desea eliminar.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            lvwRoutes.Focus();
            return;
         }

         if (MessageBox.Show(this, "¿Desea eliminar la ruta " + ((OTCRoute)lvwRoutes.SelectedItems[0].Tag).Name + "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.OK)
         {
            _schema.Routes.Remove((OTCRoute)lvwRoutes.SelectedItems[0].Tag);
            RefreshList();
         }
      }

      private void btnEditStart_Click(object sender, EventArgs e)
      {
         if (lvwRoutes.SelectedItems.Count <= 0)
         {
            MessageBox.Show(this, "Debe seleccionar la ruta que desea editar.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            lvwRoutes.Focus();
            return;
         }

         btnAdd.Enabled = false;
         btnEdit.Enabled = false;
         btnDelete.Enabled = false;

         btnEditStart.Checked = true;
         btnEditEnd.Checked = false;

         // Lanza el evento OnRouteEditionStart que deberá recibir el control 
         // PanelEditorControl para iniciar la grabación de la ruta
         if (OnRouteEditionStart != null)
            OnRouteEditionStart(new OTCSchemaEventArgs(null));
      }

      private void btnEditEnd_Click(object sender, EventArgs e)
      {
         btnAdd.Enabled = true;
         btnEdit.Enabled = true;
         btnDelete.Enabled = true;

         btnEditStart.Checked = false;
         btnEditEnd.Checked = true;

         // Lanza el evento OnRouteEditionEnd que deberá recibir el control 
         // PanelEditorControl para terminar la grabación de la ruta
         if (OnRouteEditionEnd != null)
            OnRouteEditionEnd(new OTCSchemaEventArgs(null));
      }

      #endregion

      #region Private Members

      private void RefreshStatus()
      {
         tbrTools.Enabled = (_schema != null);
         lvwRoutes.Enabled = (_schema != null);
      }

      #endregion
   }
}
