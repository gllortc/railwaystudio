using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTabControl;
using iTextSharp.text;
using iTextSharp.text.pdf;
using otc.panels;
using otc.systems;

namespace otc.forms.controls
{

   #region Enumerations

   /// <summary>
   /// Enumeración de las acciones del modo de diseño.
   /// </summary>
   public enum DesignActions
   {
      /// <summary>Selección de bloques (puntero).</summary>
      Pointer,
      /// <summary>Agregar nuevo bloque.</summary>
      Add,
      /// <summary>Eliminar bloque.</summary>
      Delete,
      /// <summary>Girar bloque.</summary>
      Rotate
   }

   /// <summary>
   /// Enumera los tipos de mensaje que puede mostrar la ventana de salida.
   /// </summary>
   public enum OutputMessageTypes
   {
      /// <summary>Mensaje informativo.</summary>
      Information,
      /// <summary>Mensaje de alerta.</summary>
      Warning,
      /// <summary>mensaje de error.</summary>
      Error
   }

   #endregion

   #region class ControlPanelEditor : UserControl

   /// <summary>
   /// Implementa un control para visualización y edición de paneles OTC.
   /// </summary>
   public partial class PanelEditorControl : UserControl
   {
      /// <summary>
      /// Enumera los modos de visualización de un panel.
      /// </summary>
      public enum PanelModes : int
      {
         /// <summary>Sin ningún panel cargado.</summary>
         Empty = 0,
         /// <summary>Diseño.</summary>
         Design = 1,
         /// <summary>Operación.</summary>
         Operation = 2
      }

      private bool _drawing = false;
      private bool _routeEditing = false;
      private OTCRoute _route = null;
      private string _addBlockType = "";
      private object _currentBlock = null;
      private OTCPanel _panel;
      private OTCLibrary _library;
      private PanelModes _mode = PanelModes.Empty;
      private DesignActions _currentDesignAction = DesignActions.Pointer;
      private BlockEditorControl _blockproperties = null;

      #region Constructors

      /// <summary>
      /// Devuelve una instancia de ControlPanelEditor.
      /// </summary>
      public PanelEditorControl()
      {
         InitializeComponent();

         _panel = null;
         _library = null;
         // _system = null;
         _mode = PanelModes.Empty;
      }

      /// <summary>
      /// Devuelve una instancia de ControlPanelEditor.
      /// </summary>
      public PanelEditorControl(OTCPanel Panel, OTCLibrary Library)
      {
         InitializeComponent();

         _panel = Panel;
         _library = Library;
         // _system = null;
         _mode = PanelModes.Design;

         Redraw();
      }

      /// <summary>
      /// Devuelve una instancia de ControlPanelEditor.
      /// </summary>
      public PanelEditorControl(OTCPanel Panel, OTCLibrary Library, OTCSystem System)
      {
         InitializeComponent();

         _panel = Panel;
         _library = Library;
         // _system = System;
         _mode = PanelModes.Design;

         Redraw();
      }

      /// <summary>
      /// Devuelve una instancia de ControlPanelEditor.
      /// </summary>
      public PanelEditorControl(OTCLibrary Library, OTCSystem System)
      {
         InitializeComponent();

         _panel = null;
         _library = Library;
         // _system = System;
         _mode = PanelModes.Empty;

         Redraw();
      }

      #endregion

      #region Control Properties

      /// <summary>
      /// Devuelve o establece el panel de control OTC asociado al control.
      /// </summary>
      public OTCPanel Panel
      {
         get { return _panel; }
         set 
         { 
            _panel = value;
            _mode = PanelModes.Design;

            if (_panel != null)
            {
               Redraw();

               // Informa del archivo cargado
               if (OnInformation != null) 
                  OnInformation(new OTCInformationEventArgs("Panel " + _panel.Name.ToUpper() + " cargado."));
            }
            else
            {
               Initialize();
            }
         }
      }

      /// <summary>
      /// Devuelve o establece la librería de presentación usada para representar los esquemas del panel de control.
      /// </summary>
      public OTCLibrary Library
      {
         get { return _library; }
         set 
         { 
            _library = value;
            
            if (_library != null)
            {
               // Informa al usuario de la librería usada
               if (OnInformation != null) 
                  OnInformation(new OTCInformationEventArgs("Usando la librería " + _library.Name));
            }
         }
      }

      /// <summary>
      /// Devuelve o establece el modo de visualización del panel.
      /// </summary>
      public PanelModes Mode
      {
         get { return _mode; }
         set 
         { 
            _mode = value;
            Redraw();
         }
      }

      /// <summary>
      /// Devuelve la instancia del bloque seleccionado actualmente.
      /// </summary>
      public object SelectedBlock
      {
         get { return _currentBlock; }
         internal set { _currentBlock = value; }
      }

      /// <summary>
      /// Devuelve o establece la acción de diseño activa.
      /// </summary>
      public DesignActions DesignAction
      {
         get { return _currentDesignAction; }
         set { _currentDesignAction = value; }
      }

      /// <summary>
      /// Devuelve o establece el tipo de bloque a agregar en caso que estemos en modo diseño y herramienta agregar.
      /// </summary>
      /// <remarks>
      /// Usualmente esta propiedad se establecerá cuando el usuario seleccione el tipo de bloque en alguna caja de herramientas.
      /// El tipo admitido será cualquier ID de bloque de la librería.
      /// </remarks>
      public string AddBlockType
      {
         get { return _addBlockType; }
         set { _addBlockType = value; }
      }

      /// <summary>
      /// Devuelve o establece el control PropertyGrid que se usará para editar las propiedades de los bloques de los esquemas.
      /// </summary>
      public BlockEditorControl BlockEditor
      {
         get { return _blockproperties; }
         set 
         { 
            _blockproperties = value;

            if (_blockproperties != null)
               _blockproperties.OnBlockUpdated += new BlockEditorControl.BlockUpdatedEventHandler(BlockEditor_OnBlockUpdated);
         }
      }

      /// <summary>
      /// Devuelve el control DataGridView mostrado actualmente.
      /// </summary>
      public DataGridView SelectedGrid
      {
         get { return (DataGridView)tabSchemas.SelectedTab.TabPage.Controls[0]; }
      }

      /// <summary>
      /// Devuelve el esquema mostrado actualmente.
      /// </summary>
      public OTCSchema SelectedSchema
      {
         get { return _panel.Schemas[tabSchemas.SelectedTab.Index]; }
      }

      /// <summary>
      /// Devuelve el índice del esquema mostrado actualmente.
      /// </summary>
      public int SelectedIndex
      {
         get { return tabSchemas.SelectedTab.Index; }
      }

      #endregion

      #region Control Methods

      /// <summary>
      /// Representa los esquemas en el control.
      /// </summary>
      public void Redraw()
      {
         int current = -1;
         int idx = 0;
         UltraTab tab = null;

         _drawing = true;

         // Memoriza el TAB seleccionado actualmente
         if (_panel != null)
            if (_panel.Schemas.Count > 1)
               if (tabSchemas.Tabs.Count > 0)
                  current = tabSchemas.SelectedTab.Index;

         // Resetea el control
         Initialize();
         if (_panel == null) return;

         tabSchemas.SuspendLayout();

         // General las pestañas correspondientes a los esquemas que contiene el panel
         foreach (OTCSchema schema in _panel.Schemas)
         {
            // Crea una nueva pestaña
            tab = tabSchemas.Tabs.Add(schema.Name, schema.Name);

            // Genera un nuevo control DataGridView
            DataGridView grid = new DataGridView();
            grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Dock = System.Windows.Forms.DockStyle.Fill;
            grid.Location = new System.Drawing.Point(0, 0);
            grid.Name = "dgvSchema" + idx;
            grid.Size = new System.Drawing.Size(533, 474);
            grid.TabIndex = 0;

            // Asocia el grid a la pestaña
            tab.TabPage.Controls.Add(grid);

            // Representa el esquema
            PaintSchema(grid, schema);

            // Patch: Elimina los eventos registros anteriormente para evitar que cada llamada agregue una nueva llamada a los eventos
            schema.OnBlockChange -= new OTCSchema.BlockChangeEventHandler(schema_OnBlockChange);
            schema.OnBlockStatusChange -= new OTCSchema.BlockStatusChangeEventHandler(schema_OnBlockStatusChange);

            // Registra los eventos para el esquema
            schema.OnBlockChange += new OTCSchema.BlockChangeEventHandler(schema_OnBlockChange);
            schema.OnBlockStatusChange += new OTCSchema.BlockStatusChangeEventHandler(schema_OnBlockStatusChange);

            // Registra los eventos necesarios del grid
            grid.CellContentClick += new DataGridViewCellEventHandler(grid_CellContentClick);
            grid.CellMouseEnter += new DataGridViewCellEventHandler(grid_CellMouseEnter);
            grid.CellMouseLeave += new DataGridViewCellEventHandler(grid_CellMouseLeave);

            idx++;
         }

         // Preselecciona el esquema adecuado
         if (current == -1)
            tabSchemas.SelectedTab = tabSchemas.Tabs[0];
         else
            tabSchemas.SelectedTab = tabSchemas.Tabs[current];

         tabSchemas.PerformLayout();

         _drawing = false;
      }

      /// <summary>
      /// Redibuja sólo el panel indicado.
      /// </summary>
      /// <param name="index">Índice del esquema a redibujar (dentro de OTCPanel.Schemas)</param>
      public void Redraw(int index)
      {
         PaintSchema((DataGridView)tabSchemas.Tabs[index].TabPage.Controls[0], _panel.Schemas[index]);
      }

      /// <summary>
      /// Selecciona un esquema concreto del panel de control.
      /// </summary>
      /// <param name="index">Índice del esquema (0 based).</param>
      public void SelectSchema(int index)
      {
         if (index < 0 || index > (_panel.Schemas.Count - 1))
            throw new Exception("El índice no corresponde a ningún esquema del panel de control.");

         tabSchemas.SelectedTab = tabSchemas.Tabs[index];
      }

      /// <summary>
      /// Procesa un comando asociado a una tecla del teclado
      /// </summary>
      /// <param name="key">Tecla pulsada por el usuario.</param>
      public void ProcessKeyCommand(char key)
      {
         if (_panel == null) return;

         // Envia la pulsación de la tecla a todos los esquemas por si un mismo elemento
         // se encuentra en varios esquemas.
         foreach (OTCSchema schema in _panel.Schemas)
         {
            try
            {
               schema.SetBlockStatus(key);
            }
            catch (OTCBlockNotFoundException)
            {
               // No hace nada si la tecla pulsada no está asociada con un bloque.
            }
            catch (Exception ex)
            {
               // Si se produce cualquier otro error lanza el evento
               if (OnError != null) OnError(new OTCInformationEventArgs(ex.Message), ex);
            }
         }
      }

      /// <summary>
      /// Inicia el modo de edición de rutas.
      /// </summary>
      public void BeginRouteEditor(OTCPanelBlock block)
      {
         if (_mode != PanelModes.Design)
            throw new Exception("No se puede iniciar la edición de una ruta si el panel no se encuentra el modo diseño.");

         // Obtiene la ruta a editar
         _route = this.SelectedSchema.GetRoute(block.Id);
         _routeEditing = true;
      }

      /// <summary>
      /// Termina el modo de edición de rutas.
      /// </summary>
      public void EndRouteEditor()
      {
         // Devuelve el modo de edición a Diseño.
         _routeEditing = false;
      }

      /// <summary>
      /// Cancela la ruta en edición (se pierden los cambios efectuados).
      /// </summary>
      public void CancelRouteEditor()
      {
         // Devuelve el modo de edición a Diseño.
         _routeEditing = false;
      }

      /// <summary>
      /// Genera un archivo PDF que contiene el esquema como gráfico.
      /// </summary>
      /// <param name="filename">Nombre y path del archivo a generar.</param>
      /// <param name="ShowBlockInfo">Indica si el esquema debe mostrar información en los accesorios.</param>
      /// <param name="landscape">Indica si se debe generar el documento usando páginas apaisadas.</param>
      /// <remarks>
      /// Usa iTextSharp para generar el PDF: http://itextsharp.sourceforge.net/
      /// </remarks>
      public void PrintToPDF(string filename, bool ShowBlockInfo, bool landscape)
      {
         try
         {
            // Genera un nuevo documento apaisado
            Document document = new Document(PageSize.A4);

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

            // Genera tipos de letra necesarios
            BaseFont bfvalue = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fhead = FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font fheadb = FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.BOLD);

            // Establece las propiedades del documento
            if (landscape) document.SetPageSize(PageSize.A4.Rotate());
            document.AddAuthor(Application.ProductName);
            document.AddCreationDate();
            document.AddCreator(Application.CompanyName + " - " + Application.ProductName);
            document.AddTitle(SelectedSchema.Name);
            document.AddSubject(Application.CompanyName);

            // Abre el nuevo documento
            document.Open();

            // Genera la plantilla del documento
            PdfContentByte cb = writer.DirectContent;
            cb.SetLineWidth(01f);

            cb.Rectangle(document.LeftMargin,
                         document.BottomMargin,
                         document.PageSize.Width - (document.RightMargin + document.LeftMargin),
                         document.PageSize.Height - (document.TopMargin + document.BottomMargin));
            cb.Stroke();

            cb.Rectangle(document.PageSize.Width - 250 - document.RightMargin,
                         document.BottomMargin,
                         250,
                         50);
            cb.Stroke();

            cb.MoveTo(document.PageSize.Width - 250 - document.RightMargin, document.BottomMargin + 25);
            cb.LineTo(document.PageSize.Width - document.RightMargin, document.BottomMargin + 25);
            cb.Stroke();

            cb.MoveTo(document.PageSize.Width - 125 - document.RightMargin, document.BottomMargin);
            cb.LineTo(document.PageSize.Width - 125 - document.RightMargin, document.BottomMargin + 25);
            cb.Stroke();

            cb.SetLineWidth(0.2f);

            cb.MoveTo(document.PageSize.Width - 250 - document.RightMargin, document.BottomMargin + (25 / 2));
            cb.LineTo(document.PageSize.Width - 125 - document.RightMargin, document.BottomMargin + (25 / 2));
            cb.Stroke();

            cb.MoveTo(document.PageSize.Width - 221 - document.RightMargin, document.BottomMargin);
            cb.LineTo(document.PageSize.Width - 221 - document.RightMargin, document.BottomMargin + 25);
            cb.Stroke();

            cb.MoveTo(document.PageSize.Width - 30 - document.RightMargin, document.BottomMargin + 50);
            cb.LineTo(document.PageSize.Width - 30 - document.RightMargin, document.BottomMargin + 25);
            cb.Stroke();

            cb.MoveTo(document.PageSize.Width - 30 - document.RightMargin, document.BottomMargin + 25 + (25 / 2));
            cb.LineTo(document.PageSize.Width - document.RightMargin, document.BottomMargin + 25 + (25 / 2));
            cb.Stroke();

            BaseFont bflabel = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            cb.BeginText();

            cb.SetFontAndSize(bflabel, 7);  
            cb.SetTextMatrix(document.PageSize.Width - 250 - document.RightMargin + 3, document.BottomMargin + 50 - 8);
            cb.ShowText(_panel.Name);

            cb.SetFontAndSize(bfvalue, 12); 
            cb.SetTextMatrix(document.PageSize.Width - 250 - document.RightMargin + 3, document.BottomMargin + 50 - 20);
            cb.ShowText(SelectedSchema.Name);

            cb.SetFontAndSize(bflabel, 6);
            cb.SetTextMatrix(document.PageSize.Width - 250 - document.RightMargin + 3, document.BottomMargin + 25 - 9);
            cb.ShowText("Fecha");

            cb.SetFontAndSize(bflabel, 7);
            cb.SetTextMatrix(document.PageSize.Width - 221 - document.RightMargin + 3, document.BottomMargin + 25 - 9);
            cb.ShowText(DateTime.Now.ToString("dd/MM/yyyy"));

            cb.SetFontAndSize(bflabel, 6);
            cb.SetTextMatrix(document.PageSize.Width - 250 - document.RightMargin + 3, document.BottomMargin + 25 - 21);
            cb.ShowText("Autor");

            cb.SetFontAndSize(bflabel, 7);
            cb.SetTextMatrix(document.PageSize.Width - 221 - document.RightMargin + 3, document.BottomMargin + 25 - 21);
            cb.ShowText(_panel.Author);

            cb.SetFontAndSize(bflabel, 6);
            cb.SetTextMatrix(document.PageSize.Width - 30 - document.RightMargin + 3, document.BottomMargin + 50 - 9);
            cb.ShowText("Versión");

            cb.SetFontAndSize(bflabel, 7);
            cb.SetTextMatrix(document.PageSize.Width - 30 - document.RightMargin + 3, document.BottomMargin + 50 - 21);
            cb.ShowText(_panel.Version);

            cb.SetFontAndSize(bflabel, 6);
            cb.SetTextMatrix(document.PageSize.Width - 125 - document.RightMargin + 3, document.BottomMargin + 25 - 14);
            cb.ShowText(Application.ProductName);

            cb.SetFontAndSize(bflabel, 6);
            cb.SetTextMatrix(document.PageSize.Width - 125 - document.RightMargin + 3, document.BottomMargin + 25 - 21);
            cb.ShowText(Application.CompanyName);

            cb.EndText();

            // Agrega una pequeña separación en el inicio del documento
            Phrase sep = new Phrase(" ");
            sep.Font = new iTextSharp.text.Font(bflabel, 4);
            document.Add(sep);

            // Genera la tabla que debe contener el panel de control
            PdfPTable table = new iTextSharp.text.pdf.PdfPTable(SelectedSchema.Columns);
            table.FooterRows = 0;
            table.HeaderRows = 0;
            table.WidthPercentage = 98;
            table.DefaultCell.Padding = 0;
            table.DefaultCell.UseBorderPadding = false;

            // Genera una imagen para usar en las celdas en blanco
            Bitmap blankbmp = new Bitmap(_library.BlockWidth, _library.BlockHeight);
            for (int i = 0; i < _library.BlockWidth; i++)
               for (int j = 0; j < _library.BlockHeight; j++)
                  blankbmp.SetPixel(i, j, _library.BgColor);

            for (int y = 0; y < SelectedSchema.Rows; y++)
            {
               for (int x = 0; x < SelectedSchema.Columns; x++)
               {
                  try
                  {
                     // Obtiene el bloque de la celda actual
                     OTCPanelBlock block = SelectedSchema.GetBlock(x, y);

                     // Obtiene la imagen asociada
                     Bitmap bmp = _library.GetBlockImage(block.LibraryBlock.Id, OTCLibrary.ImageTypes.Bitmap, block.Rotation, OTCBlockStatus.None);

                     // Si es un bloque con dirección, la representa
                     if (ShowBlockInfo && block.LibraryBlock.Type != OTCLibraryBlock.BlockTypes.Static)
                     {
                        string text = "";

                        if (String.IsNullOrEmpty(block.Name))
                           text = "ND";
                        else
                           text = block.Name;

                        if (block.DigitalAddress > 0)
                           text += " (" + block.DigitalAddress.ToString() + ")";

                        Bitmap ibmp = new Bitmap(bmp.Width, bmp.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                        Graphics ig = Graphics.FromImage(ibmp);
                        ig.DrawImage((System.Drawing.Image)bmp, new Point(0, 0));

                        bmp.Dispose();

                        StringFormat strFormat = new StringFormat();
                        strFormat.Alignment = StringAlignment.Center;
                        strFormat.LineAlignment = StringAlignment.Center;

                        ig.FillRectangle(Brushes.White, 2, ibmp.Height / 4, ibmp.Width - 4, ibmp.Height / 2);

                        ig.DrawString(text,
                                      new System.Drawing.Font("Tahoma", 8),
                                      Brushes.Black,
                                      new RectangleF(0, 0, ibmp.Width, ibmp.Height),
                                      strFormat);

                        bmp = ibmp;
                     }

                     // Agrega la celda
                     table.AddCell(iTextSharp.text.Image.GetInstance((System.Drawing.Image)bmp, iTextSharp.text.Color.WHITE));
                  }
                  catch (OTCBlockNotFoundException)
                  {
                     // Deja la celda vacía
                     table.AddCell(iTextSharp.text.Image.GetInstance((System.Drawing.Image)blankbmp, iTextSharp.text.Color.WHITE));
                  }
               }
            }
            document.Add(table);

            // Cierra y genera el documento PDF
            document.Close();
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      #endregion

      #region Control Events

      /// <summary>
      /// Dispara el evento OnInformation.
      /// </summary>
      /// <param name="e">La información a mostrar al usuario.</param>
      public delegate void InfoEventHandler(OTCInformationEventArgs e);

      /// <summary>
      /// Evento que se lanza cuando el control genera un mensaje de salida.
      /// </summary>
      [Category("Control Panel")]
      [Description("Evento que se lanza cuando el control genera un mensaje de salida.")]
      public event InfoEventHandler OnInformation;

      /// <summary>
      /// Dispara el evento OnError.
      /// </summary>
      /// <param name="e">La información a mostrar al usuario.</param>
      /// <param name="error">Los detalles de la excepción capturada.</param>
      public delegate void ErrorEventHandler(OTCInformationEventArgs e, Exception error);

      /// <summary>
      /// Evento que se lanza cuando se produce un error (excepción).
      /// </summary>
      [Category("Control Panel")]
      [Description("Evento que se lanza cuando se produce un error excepción dentro del control.")]
      public event ErrorEventHandler OnError;

      /// <summary>
      /// Dispara el evento OnOperationRequest.
      /// </summary>
      /// <param name="sender">La instancia del objeto que lanza el evento (publisher).</param>
      /// <param name="e">La información del comando que desea ejecutar.</param>
      public delegate void BlockStatusChangeEventHandler(object sender, OTCSchemaEventArgs e);

      /// <summary>
      /// Evento que se lanza cuando el control ordena al sistema digital que ejecute un comando.
      /// </summary>
      [Category("Control Panel")]
      [Description("Evento que se lanza cuando el control ordena al sistema digital que ejecute un comando.")]
      public event BlockStatusChangeEventHandler OnBlockStatusChange;

      /// <summary>
      /// Dispara el evento OnOperationRequest.
      /// </summary>
      /// <param name="sender">La instancia del objeto que lanza el evento (publisher).</param>
      /// <param name="e">La información del comando que desea ejecutar.</param>
      public delegate void SelectedSchemaChangedEventHandler(object sender, OTCPanelEventArgs e);

      /// <summary>
      /// Evento que se lanza cuando el control ordena al sistema digital que ejecute un comando.
      /// </summary>
      [Category("Control Panel")]
      [Description("Evento que se lanza cuando el usuario cambia el esquema seleccionado.")]
      public event SelectedSchemaChangedEventHandler OnSelectedSchemaChanged;

      #endregion

      #region Event Handlers

      /// <summary>
      /// Usado como función de callback para generar imagenes miniatura.
      /// </summary>
      private bool ThumbnailCallback()
      {
         return false;
      }

      /// <summary>
      /// Lanza el evento OnInformation cuando se recive el evento desde el controlador.
      /// </summary>
      private void SystemController_OnInformation(OTCInformationEventArgs args)
      {
         if (OnInformation != null) OnInformation(args);
      }

      /// <summary>
      /// Lanza el evento OnError cuando se recive el evento desde el controlador.
      /// </summary>
      private void SystemController_OnError(OTCInformationEventArgs args, Exception ex)
      {
         if (OnError != null) OnError(args, ex);
      }

      /// <summary>
      /// Responde al cambio en un bloque del esquema.
      /// </summary>
      protected virtual void schema_OnBlockChange(OTCSchemaEventArgs args)
      {
         // Si no existe grid seleccionado, omite el evento
         if (SelectedGrid == null) return;

         // Actualiza la celda correspondiente al bloque que ha cambiado o se ha eliminado
         if (args.Deleted)
         {
            SelectedGrid.Rows[args.Block.Y].Cells[args.Block.X].Value = _library.GetBlockImage();
         }
         else
         {
            if (_mode == PanelModes.Design)
            {
               Bitmap blockimg = _library.GetBlockImage(args.Block.LibraryBlock.Id, OTCLibrary.ImageTypes.Bitmap, args.Block.Rotation, OTCBlockStatus.None);
               blockimg.MakeTransparent(_library.BgColor);
               SelectedGrid.Rows[args.Block.Y].Cells[args.Block.X].Value = blockimg;
            }
            else
            {
               SelectedGrid.Rows[args.Block.Y].Cells[args.Block.X].Value = _library.GetBlockImage(args.Block.LibraryBlock.Id, OTCLibrary.ImageTypes.Bitmap, args.Block.Rotation, args.Block.Status);
            }

            // Almacena el identificador del bloque
            SelectedGrid.Rows[args.Block.Y].Cells[args.Block.X].Tag = args.Block.Id;
         }
      }

      /// <summary>
      /// Responde al cambio de estado en un bloque del esquema.
      /// </summary>
      protected virtual void schema_OnBlockStatusChange(object sender, OTCSchemaEventArgs e)
      {
         // En modos distintos a Operation no se lanzan los eventos.
         if (_mode != PanelModes.Operation) return;
         
         // Evita lanzar eventos sin argumentos
         if (e == null || e.Block == null) return;

         // Lanza el evento para que lo consuma el software que incluye el control
         if (OnBlockStatusChange != null) OnBlockStatusChange(sender, e);
      }

      /// <summary>
      /// Realiza la acción oportuna cuando el usuario hace un clic sobre el grid.
      /// </summary>
      private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
      {
         // Evita lanzar eventos durante la representación del panel
         if (_drawing) return;

         if (_mode == PanelModes.Design)
         {
            if (!_routeEditing)
            {

               switch (_currentDesignAction)
               {
                  case DesignActions.Add:

                     if (String.IsNullOrEmpty(_addBlockType))
                     {
                        MessageBox.Show(this, "No se ha seleccionado el tipo de bloque a agregar.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                     }

                     // Agrega un elemento al panel
                     int x = SelectedGrid.SelectedCells[0].ColumnIndex;
                     int y = SelectedGrid.SelectedCells[0].RowIndex;
                     SelectedSchema.AddBlock(x, y, _addBlockType);
                     break;

                  case DesignActions.Delete:

                     // Elimina un elemento del panel
                     if ((SelectedGrid.SelectedCells[0].Tag == null) || (SelectedGrid.SelectedCells[0].Tag.ToString().Equals("")))
                     {
                        _currentBlock = null;
                        return;
                     }
                     SelectedSchema.DeleteBlock(int.Parse(SelectedGrid.SelectedCells[0].Tag.ToString()), SelectedGrid);
                     break;

                  case DesignActions.Rotate:

                     // Gira un elemento del panel
                     if ((SelectedGrid.SelectedCells[0].Tag == null) || (SelectedGrid.SelectedCells[0].Tag.ToString().Equals("")))
                     {
                        _currentBlock = null;
                        return;
                     }
                     SelectedSchema.SetBlockRotation(int.Parse(SelectedGrid.SelectedCells[0].Tag.ToString()));
                     break;

                  case DesignActions.Pointer:

                     if (SelectedGrid.SelectedCells.Count == 0) return;
                     if (_blockproperties == null) return;

                     // Selecciona y muestra las propiedades de un elemento del panel
                     if ((SelectedGrid.SelectedCells[0].Tag == null) || (SelectedGrid.SelectedCells[0].Tag.ToString().Equals("")))
                     {
                        _blockproperties.Panel = null;
                        _blockproperties.Block = null;
                        return;
                     }

                     // Obtiene el bloque seleccionado
                     _blockproperties.Panel = _panel;
                     _blockproperties.Block = SelectedSchema.GetBlock(int.Parse(SelectedGrid.SelectedCells[0].Tag.ToString()));

                     break;
               }
            }
            else
            {
               // Edición de rutas activada

               if (SelectedGrid.SelectedCells.Count == 0) return;
               if (_blockproperties == null) return;

               if ((SelectedGrid.SelectedCells[0].Tag == null) || (SelectedGrid.SelectedCells[0].Tag.ToString().Equals("")))
               {
                  // Obtiene las direcciones posibles del elemento
                  // int directions = _panel.Library
                  MessageBox.Show("");

                  // Busca en la ruta que se está editando si existe el bloque seleccionado

                  // Si no existe, lo añade con el estado inicial

                  // Si existe, cambia el estado del elemento

                  // Muestra el bloque

                  return;
               }
            }
         }
         else if (_mode == PanelModes.Operation)
         {
            // Cambia el estado de un elemento del panel
            if ((SelectedGrid.SelectedCells[0].Tag == null) || (SelectedGrid.SelectedCells[0].Tag.ToString().Equals("")))
            {
               _currentBlock = null;
               return;
            }

            // Obtiene el bloque
            OTCPanelBlock block = SelectedSchema.GetBlock(int.Parse(SelectedGrid.SelectedCells[0].Tag.ToString()));

            try
            {
               // Establece el estado en el panel
               SelectedSchema.SetBlockStatus(block.Id);
            }
            catch (Exception ex)
            {
               OnError(new OTCInformationEventArgs(ex.Message), ex);
            }
         }
      }

      /// <summary>
      /// Evento que se lanza al entrar el puntero del mouse en una celda del grid
      /// </summary>
      private void grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
      {
         // Evita lanzar eventos durante la representación del panel
         if (_drawing) return;

         if (_mode == PanelModes.Operation)
         {

            try
            {
               if (SelectedSchema.IsUsedCell(e.ColumnIndex, e.RowIndex))
               {
                  OTCPanelBlock block = SelectedSchema.GetBlock(e.ColumnIndex, e.RowIndex);
                  if (block.LibraryBlock.Type != OTCLibraryBlock.BlockTypes.Static)
                     SelectedGrid.Cursor = Cursors.Hand;
               }
            }
            catch
            {
               // Descarta cualquier error
            }
         }
         else if (_mode == PanelModes.Design && _currentDesignAction == DesignActions.Add)
         {
            try
            {
               System.IO.MemoryStream ms = new System.IO.MemoryStream(global::otc.Properties.Resources.CUR_ADD);
               SelectedGrid.Cursor = new Cursor(ms);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
         }
      }

      /// <summary>
      /// Evento que se lanza al entrar el puntero del mouse en una celda del grid
      /// </summary>
      private void grid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
      {
         // Evita lanzar eventos durante la representación del panel
         if (_drawing) return;

         if (_mode == PanelModes.Operation)
         {
            SelectedGrid.Cursor = Cursors.Default;
         }
         else if (_mode == PanelModes.Design && _currentDesignAction == DesignActions.Add)
         {
            SelectedGrid.Cursor = Cursors.Default;
         }
      }

      /// <summary>
      /// Evento que se produce al seleccionar una pestaña. Esta acción memoriza el grid activo y el esquema asociado.
      /// </summary>
      private void tabSchemas_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
      {
         // Evita lanzar eventos durante la representación del panel
         if (_drawing) return;

         // Limpia el objeto en el control propertyGrid asociado
         if (_blockproperties != null) _blockproperties.Block = null;

         // Lanza el evento 
         if (OnSelectedSchemaChanged != null)
            OnSelectedSchemaChanged(sender, new OTCPanelEventArgs(this.SelectedSchema));
      }

      /// <summary>
      /// Se produce cuando el usuario actualiza las propiedades de un bloque.
      /// </summary>
      private void BlockEditor_OnBlockUpdated(OTCSchemaEventArgs args)
      {
         SelectedSchema.Blocks[SelectedSchema.GetBlockIndex(args.Block.Id)] = args.Block;
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Representa el panel de control en un control DataGridView.
      /// </summary>
      private void PaintSchema(DataGridView grid, OTCSchema schema)
      {
         try
         {
            // Genera una imágen transparente para las celdas que no contienen ningún bloque
            Bitmap nullimage = new Bitmap(_library.BlockWidth, _library.BlockHeight);
            nullimage.MakeTransparent();

            // Inicializa el _grid
            grid.MultiSelect = false;
            grid.ColumnHeadersVisible = false;
            grid.RowHeadersVisible = false;
            grid.Columns.Clear();
            grid.BackgroundColor = _library.BgColor;
            grid.DefaultCellStyle.BackColor = _library.BgColor;
            grid.AllowDrop = false;
            grid.AllowUserToOrderColumns = false;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;

            // Añade las celdas del grid
            for (int i = 0; i < schema.Columns; i++)
            {
               DataGridViewImageColumn col = new DataGridViewImageColumn();
               col.Width = _library.BlockWidth;
               col.ImageLayout = DataGridViewImageCellLayout.Normal;
               col.Image = nullimage;
               grid.Columns.Add(col);
            }
            grid.RowCount = schema.Rows;
            for (int i = 0; i < grid.Rows.Count; i++)
               grid.Rows[i].Height = _library.BlockHeight;

            // Carga las imágenes
            foreach (OTCPanelBlock block in schema.Blocks)
            {
               if (_mode == PanelModes.Design)
               {
                  // Representa los bloques con el color de fondo transparente 
                  // para que sea visible el bloque seleccionado
                  Bitmap blockimg = _library.GetBlockImage(block.LibraryBlock.Id, OTCLibrary.ImageTypes.Bitmap, block.Rotation, OTCBlockStatus.None);
                  blockimg.MakeTransparent(_library.BgColor);
                  grid.Rows[block.Y].Cells[block.X].Value = blockimg;
               }
               else
               {
                  grid.Rows[block.Y].Cells[block.X].Value = _library.GetBlockImage(block.LibraryBlock.Id, OTCLibrary.ImageTypes.Bitmap, block.Rotation, block.Status);
               }
               grid.Rows[block.Y].Cells[block.X].Tag = block.Id;
            }
         }
         catch
         {
            throw;
         }
      }

      /// <summary>
      /// Inicializa el control.
      /// </summary>
      private void Initialize()
      {
         // Elimina los esquemas de un panel.
         tabSchemas.Tabs.Clear();

         // Limpia el contenido de la ventana de salida.
         // Output.Clear();
      }

      /// <summary>
      /// Reduce unas medidas para que quepan en las proporcionadas.
      /// </summary>
      private Size ScaleSize(decimal width, decimal height, decimal fitwidth, decimal fitheight)
      {
         decimal _width = 0;
         decimal _height = 0;

         // Prueba de adaptar la imagen a partir del ancho
         decimal factor = fitwidth / width;
         _width = width * factor;
         _height = height * factor;
         if (fitwidth >= _width && fitheight >= _height)
            return new Size((int)_width, (int)_height);

         // Prueba de adaptar la imagen a partir de la altura
         factor = fitheight / height;
         _width = width * factor;
         _height = height * factor;

         return new Size((int)_width, (int)_height);
      }

      #endregion
      
   }

   #endregion

}
