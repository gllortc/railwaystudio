using System;

namespace Rwm.Otc.Trains
{
   /// <summary>
   /// Implementa una revisión técnica de un modelo.
   /// </summary>
   public class ModelRevision
   {
      // Declaración de variables internas
      private int _modelId;
      private int _serviceTime;
      private int _revisionTime;
      private DateTime _date;
      private string _description;
      private string _author;

      /// <summary>
      /// Devuelve una instancia de RCModelRevision.
      /// </summary>
      public ModelRevision()
      {
         this.ID = 0;
         _modelId = 0;
         _serviceTime = 0;
         _revisionTime = 0;
         _date = DateTime.Now; ;
         _description = "";
         _author = "";
      }

      /// <summary>
      /// Devuelve una instancia de RCModelRevision.
      /// </summary>
      /// <param name="modelId">Identificador del modelo que recibe la revisión</param>
      public ModelRevision(int modelId)
      {
         this.ID = 0;
         _modelId = modelId;
         _serviceTime = 0;
         _revisionTime = 0;
         _date = DateTime.Now; ;
         _description = "";
      }

      /// <summary>
      /// Gets or sets el identificador del modelo al que pertenece la revisión.
      /// </summary>
      public int ID { get; set; }

      /// <summary>
      /// Gets or sets el identificador del modelo al que pertenece la revisión.
      /// </summary>
      public int ModelId
      {
         get { return _modelId; }
         set { _modelId = value; }
      }

      /// <summary>
      /// Gets or sets el número total de horas de servicio del modelo.
      /// </summary>
      public int ServiceHours
      {
         get { return _serviceTime; }
         set { _serviceTime = value; }
      }

      /// <summary>
      /// Gets or sets el número total de horas desde la última revisión del modelo.
      /// </summary>
      public int RevisionHours
      {
         get { return _revisionTime; }
         set { _revisionTime = value; }
      }

      /// <summary>
      /// Gets or sets la fecha de la revisión.
      /// </summary>
      public DateTime Date
      {
         get { return _date; }
         set { _date = value; }
      }

      /// <summary>
      /// Gets or sets la descripción de las acciones que se han efectuado en la revisión.
      /// </summary>
      public string Description
      {
         get { return _description; }
         set { _description = value; }
      }

      /// <summary>
      /// Gets or sets el nombre de la persona o empresa que ha efectuado la revisión.
      /// </summary>
      public string Author
      {
         get { return _author; }
         set { _author = value; }
      }

      #region Methods

      ///// <summary>
      ///// Imprime la ficha de revisión en un archivo PDF.
      ///// </summary>
      ///// <param name="filename">Nombre y ruta del archivo a generar.</param>
      ///// <param name="model">Una instancia de RCModel que contiene las características del modelo.</param>
      //public void PrintToPdf(string filename, CollectionModel model)
      //{
      //   string str = "";
      //   Document document = null;

      //   // Obtiene el texto a partir del contenido RTF
      //   RichTextBox rtfctrl = new RichTextBox();
      //   rtfctrl.Visible = false;
      //   rtfctrl.Rtf = _description;
      //   str = rtfctrl.Text.Replace("\t", " ");
      //   rtfctrl.Dispose();

      //   string[] sep = { "\n" };
      //   string[] phrases = str.Split(sep, StringSplitOptions.None);

      //   try
      //   {
      //      FileInfo file = new FileInfo(filename);
      //      if (file.Exists) file.Delete();

      //      document = new Document(PageSize.A4);

      //      PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

      //      // Genera tipos de letra necesarios
      //      BaseFont bfvalue = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
      //      Font fhead = FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL);
      //      Font fheadb = FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.BOLD);

      //      BaseFont headtitle = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
      //      BaseFont text = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
      //      BaseFont fixedtext = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

      //      // Establece las propiedades del documento
      //      document.SetPageSize(PageSize.A4);
      //      document.AddAuthor(Application.ProductName);
      //      document.AddCreationDate();
      //      document.AddCreator(Application.CompanyName + " - " + Application.ProductName);
      //      document.AddTitle("Ficha de vagón de mercancías");
      //      document.AddSubject(Application.CompanyName);

      //      // Abre el nuevo documento
      //      document.Open();

      //      // Genera la plantilla del documento
      //      PdfContentByte cb = writer.DirectContent;

      //      ColumnText ct = new ColumnText(cb);
      //      ct.AdjustFirstLine = true;
      //      ct.ExtraParagraphSpace = 0;
      //      ct.FollowingIndent = 0;
      //      ct.Indent = 0;

      //      // Maxlines per page: 78
      //      int lines = 0;
      //      int page = 0;

      //      cb.BeginText();

      //      foreach (string phrase in phrases)
      //      {
      //         if (page == 0 || lines > 75)
      //         {
      //            if (page > 0)
      //            {
      //               cb.EndText();
      //               document.NewPage();
      //               lines = 0;
      //               cb.BeginText();
      //            }

      //            pdfPageTemplate(document, cb, model, (page == 0));

      //            ct.SetSimpleColumn(document.LeftMargin + 5,
      //                         document.PageSize.Height - document.TopMargin - 130 + 5,
      //                         document.PageSize.Width - document.RightMargin - 5,
      //                         document.BottomMargin + 5,
      //                         8,
      //                         Rectangle.ALIGN_JUSTIFIED);

      //            page++;
      //         }

      //         ct.AddText(new Phrase(phrase + "\n", new Font(fixedtext, 8)));
      //         ct.Go();

      //         lines += ct.LinesWritten;
      //      }

      //      cb.EndText();
      //   }
      //   catch (Exception ex)
      //   {
      //      throw ex;
      //   }
      //   finally
      //   {
      //      // Cierra y genera el documento PDF
      //      if (document != null) document.Close();
      //   }
      //}

      #endregion

      #region Private Members

      ///// <summary>
      ///// Representa el cajetín del documento.
      ///// </summary>
      //private void pdfPageTemplate(Document document, PdfContentByte cb, CollectionModel model, bool firstPage)
      //{
      //   // Accede a la configuración local de la aplicación
      //   OTCSettingsManager settings = new OTCSettingsManager(Application.ExecutablePath.ToLower().Replace(".exe", "") + ".conf");

      //   BaseFont headtitle = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
      //   BaseFont text = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

      //   cb.SetLineWidth(1);

      //   // Recuadro de la página
      //   cb.Rectangle(document.LeftMargin,
      //                document.BottomMargin,
      //                document.PageSize.Width - (document.RightMargin + document.LeftMargin),
      //                document.PageSize.Height - (document.TopMargin + document.BottomMargin));
      //   cb.Stroke();

      //   // Cajetín superior
      //   cb.Rectangle(document.LeftMargin,
      //                document.PageSize.Height - document.TopMargin - 50,
      //                document.PageSize.Width - (document.RightMargin + document.LeftMargin),
      //                50);
      //   cb.Stroke();

      //   cb.MoveTo(document.LeftMargin + 50, document.PageSize.Height - document.TopMargin - 110);
      //   cb.LineTo(document.LeftMargin + 50, document.PageSize.Height - document.TopMargin);
      //   cb.Stroke();

      //   cb.MoveTo(document.LeftMargin, document.PageSize.Height - document.TopMargin - 70);
      //   cb.LineTo(document.PageSize.Width - document.RightMargin, document.PageSize.Height - document.TopMargin - 70);
      //   cb.Stroke();

      //   cb.MoveTo(document.LeftMargin, document.PageSize.Height - document.TopMargin - 90);
      //   cb.LineTo(document.PageSize.Width - document.RightMargin, document.PageSize.Height - document.TopMargin - 90);
      //   cb.Stroke();

      //   cb.MoveTo(document.LeftMargin, document.PageSize.Height - document.TopMargin - 110);
      //   cb.LineTo(document.PageSize.Width - document.RightMargin, document.PageSize.Height - document.TopMargin - 110);
      //   cb.Stroke();

      //   cb.MoveTo((document.PageSize.Width / 2), document.PageSize.Height - document.TopMargin - 110);
      //   cb.LineTo((document.PageSize.Width / 2), document.PageSize.Height - document.TopMargin - 50);
      //   cb.Stroke();

      //   cb.MoveTo((document.PageSize.Width / 2) + 50, document.PageSize.Height - document.TopMargin - 110);
      //   cb.LineTo((document.PageSize.Width / 2) + 50, document.PageSize.Height - document.TopMargin - 50);
      //   cb.Stroke();

      //   string filename = settings.GetString(RCApplication.SETTING_PRINT_ADMINLOGO, "");
      //   if (!string.IsNullOrEmpty(filename))
      //   {
      //      FileInfo file = new FileInfo(filename);
      //      if (file.Exists)
      //      {
      //         Image image = Image.GetInstance(filename);
      //         image.ScaleAbsolute(40, 40);
      //         image.SetAbsolutePosition(document.LeftMargin + 5, document.PageSize.Height - document.TopMargin - 50 + 5);
      //         cb.AddImage(image);
      //         cb.Stroke();
      //      }
      //   }

      //   // cb.BeginText();

      //   cb.SetFontAndSize(headtitle, 12);
      //   cb.SetTextMatrix(document.LeftMargin + 50 + 5, document.PageSize.Height - document.TopMargin - 50 + 35);
      //   cb.ShowText(settings.GetSetting(RCApplication.SETTING_PRINT_ADMINNAME));

      //   cb.SetFontAndSize(headtitle, 14);
      //   cb.SetTextMatrix(document.LeftMargin + 50 + 5, document.PageSize.Height - document.TopMargin - 50 + 5);
      //   cb.ShowText("REVISIÓN TÉCNICA DE MODELO");

      //   cb.SetFontAndSize(text, 8);
      //   cb.SetTextMatrix(document.LeftMargin + 5, document.PageSize.Height - document.TopMargin - 70 + 5);
      //   cb.ShowText("Modelo");

      //   cb.SetFontAndSize(text, 10);
      //   cb.SetTextMatrix(document.LeftMargin + 55, document.PageSize.Height - document.TopMargin - 70 + 5);
      //   cb.ShowText(model.Name);

      //   cb.SetFontAndSize(text, 8);
      //   cb.SetTextMatrix((document.PageSize.Width / 2) + 5, document.PageSize.Height - document.TopMargin - 70 + 5);
      //   cb.ShowText("Matricula");

      //   cb.SetFontAndSize(text, 10);
      //   cb.SetTextMatrix((document.PageSize.Width / 2) + 55, document.PageSize.Height - document.TopMargin - 70 + 5);
      //   cb.ShowText(model.RegistrationNumber);

      //   cb.SetFontAndSize(text, 8);
      //   cb.SetTextMatrix(document.LeftMargin + 5, document.PageSize.Height - document.TopMargin - 90 + 5);
      //   cb.ShowText("Fecha");

      //   cb.SetFontAndSize(text, 10);
      //   cb.SetTextMatrix(document.LeftMargin + 55, document.PageSize.Height - document.TopMargin - 90 + 5);
      //   cb.ShowText(_date == DateTime.MinValue ? "-" : _date.ToString("dd / MM / yyyy"));

      //   cb.SetFontAndSize(text, 8);
      //   cb.SetTextMatrix(document.LeftMargin + 5, document.PageSize.Height - document.TopMargin - 110 + 5);
      //   cb.ShowText("Técnico");

      //   cb.SetFontAndSize(text, 10);
      //   cb.SetTextMatrix(document.LeftMargin + 55, document.PageSize.Height - document.TopMargin - 110 + 5);
      //   cb.ShowText(string.IsNullOrEmpty(_author.Trim()) ? "-" : _author.Trim());

      //   if (!settings.GetBoolean(RCApplication.SETTING_PRINT_HIDEWATERMARK, false))
      //   {
      //      cb.SetFontAndSize(text, 6);
      //      cb.SetTextMatrix(document.LeftMargin, document.BottomMargin - 8);
      //      cb.ShowText("Generado con RailwayCollection - Railwaymania.com");
      //   }

      //   // cb.EndText();
      //}

      #endregion

   }
}
