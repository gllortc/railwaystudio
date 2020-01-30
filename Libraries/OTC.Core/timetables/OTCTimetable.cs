using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace otc.timetables
{

   #region class OTCTimetable

   /// <summary>
   /// Implementa un horario de circulaciones OTC.
   /// </summary>
   public class OTCTimetable
   {
      private string _name;
      private string _filename;
      private string _version;
      private string _description;
      private string _otcversion;
      private string _otcgenerator;
      private int _timeratio;
      private List<OTCCirculation> _circulations = null;

      /// <summary>
      /// Extensión por defecto de los archivos que contienen la definición de un horario
      /// </summary>
      public const string OBJECT_FILE_EXTENSION = "ott";

      /// <summary>
      /// Devuelve una instancia de OTCTimetable.
      /// </summary>
      public OTCTimetable()
      {
         _name = "";
         _filename = "";
         _version = "";
         _description = "";
         _timeratio = 1;
         _otcversion = "1.0";
         _otcgenerator = "";
         _circulations = new List<OTCCirculation>();
      }

      /// <summary>
      /// Devuelve una instancia de OTCTimetable.
      /// </summary>
      public OTCTimetable(string filename)
      {
         _name = "";
         _filename = filename;
         _version = "";
         _description = "";
         _timeratio = 1;
         _otcversion = "1.0";
         _otcgenerator = "";
         _circulations = new List<OTCCirculation>();

         // Carga el horario
         Load();
      }

      /// <summary>
      /// Nombre del archivo que contiene el horario
      /// </summary>
      public string Filename
      {
         get { return _filename; }
         set { _filename = value; }
      }

      /// <summary>
      /// Nombre del horario
      /// </summary>
      public string Name
      {
         get { return _name; }
         set { _name = value; }
      }

      /// <summary>
      /// Descripción del horario
      /// </summary>
      public string Description
      {
         get { return _description; }
         set { _description = value; }
      }

      /// <summary>
      /// Versión del horario
      /// </summary>
      public string Version
      {
         get { return _version; }
         set { _version = value; }
      }

      /// <summary>
      /// Relación de velocidad de tiempo (1min -> X ratio)
      /// </summary>
      public int TimeRatio
      {
         get { return _timeratio; }
         set { _timeratio = value; }
      }

      /// <summary>
      /// Lista de circulaciones que contempla el horario
      /// </summary>
      public List<OTCCirculation> Circulations
      {
         get { return _circulations; }
         set { _circulations = value; }
      }

      /// <summary>
      /// Carga un archivo que contiene el horario
      /// </summary>
      public void Load()
      {
         if (_filename.Trim().Equals(""))
            throw new Exception("No se ha definido el archivo a cargar.");

         try
         {
            // Inicializaciones
            _circulations = new List<OTCCirculation>();

            // Trata el archivo
            FileInfo file = new FileInfo(_filename);

            // Carga el archivo XML
            XmlTextReader reader = new XmlTextReader(_filename);
            reader.WhitespaceHandling = WhitespaceHandling.None;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_filename);
            reader.Close();

            // Recupera el nodo raíz
            XmlNode xnod = xmlDoc.DocumentElement;
            if (!xnod.Name.ToLower().Equals("otc-timetable"))
               throw new Exception("El archivo proporcionado no corresponde a una definición de horario según el estándar OTC.");
            _otcversion = xnod.Attributes["version"].Value.ToString();
            _otcgenerator = xnod.Attributes["generator"].Value.ToString();

            foreach (XmlNode node in xnod.ChildNodes)
            {
               switch (node.Name.ToLower())
               {
                  case "name":
                     _name = node.FirstChild.Value.ToString();
                     break;
                  case "description":
                     _description = (node.FirstChild == null ? "" : node.FirstChild.Value.ToString());
                     break;
                  case "version":
                     _version = (node.FirstChild == null ? "" : node.FirstChild.Value.ToString());
                     break;
                  case "operations":
                     foreach (XmlNode operation in node.ChildNodes)
                     {
                        if (operation.Name.ToLower().Equals("operation"))
                        {
                           // Recupera la información de la circulación
                           OTCCirculation circulation = new OTCCirculation();
                           circulation.Type = (OTCCirculations.OTCCirculationTypes)int.Parse(operation.Attributes["type"].Value);
                           circulation.Number = operation.Attributes["train-number"].Value;
                           circulation.Source = operation.Attributes["from"].Value;
                           circulation.Destination = operation.Attributes["to"].Value;
                           circulation.Arrival = operation.Attributes["time-arrival"].Value.Trim().Equals("") ? DateTime.MinValue : DateTime.Parse(operation.Attributes["time-arrival"].Value);
                           circulation.Depart = operation.Attributes["time-depart"].Value.Trim().Equals("") ? DateTime.MinValue : DateTime.Parse(operation.Attributes["time-depart"].Value);
                           circulation.Platform = operation.Attributes["platform"].Value;
                           circulation.Comments = operation.Attributes["comments"].Value;

                           _circulations.Add(circulation);
                        }
                     }
                     break;
               }
            }
         }
         catch (Exception ex)
         {
            _filename = "";
            _circulations = new List<OTCCirculation>();
            throw ex;
         }
      }

      /// <summary>
      /// Guarda el horario a un archivo 
      /// </summary>
      /// <remarks>Usa como archivo la propiedad Filename</remarks>
      public void Save()
      {
         try
         {
            // Abre el documento
            XmlTextWriter writer = new XmlTextWriter(_filename, Encoding.UTF8);
            writer.WriteStartDocument();

            // Abre una cláusula OTC-TIMETABLE
            writer.WriteStartElement("otc-timetable");
            writer.WriteAttributeString("version", "1.0");
            writer.WriteAttributeString("generator", Application.ProductName);

            // Escribe las propiedades del horario
            writer.WriteElementString("name", _name);
            writer.WriteElementString("description", _description);
            writer.WriteElementString("version", _version);

            // Circulaciones
            writer.WriteStartElement("operations");
            foreach (OTCCirculation circulation in _circulations)
            {
               writer.WriteStartElement("operation");
               writer.WriteAttributeString("type", ((int)circulation.Type).ToString());
               writer.WriteAttributeString("train-number", circulation.Number);
               writer.WriteAttributeString("from", circulation.Source);
               writer.WriteAttributeString("to", circulation.Destination);
               writer.WriteAttributeString("time-arrival", circulation.Arrival == DateTime.MinValue ? "" : circulation.Arrival.ToString("hh:mm"));
               writer.WriteAttributeString("time-depart", circulation.Depart == DateTime.MinValue ? "" : circulation.Depart.ToString("hh:mm"));
               writer.WriteAttributeString("platform", circulation.Platform);
               writer.WriteAttributeString("comments", circulation.Comments);
               writer.WriteEndElement();
            }
            writer.WriteEndElement();

            // Cierra OTC-TIMETABLE
            writer.WriteEndElement();

            // Cierra el documento
            writer.WriteEndDocument();
            writer.Close();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      /// <summary>
      /// Guarda el horario a un archivo 
      /// </summary>
      /// <param name="filename">Nombre + ruta del archivo de destino</param>
      /// <remarks>
      /// Esta acción reemplaza el valor de la propiedad Filename por el parámetro filename
      /// especificado. Sirve para realizar la acción Guardar como...
      /// </remarks>
      public void Save(string filename)
      {
         _filename = filename;
         Save();
      }

      /// <summary>
      /// Rellena un control ListView con las circulaciones que contiene el horario
      /// </summary>
      /// <param name="control">Control contenedor del listado</param>
      /// <param name="imageKey">Clave (name) de la imagen a mostrar junto a las entradas de la lista.</param>
      public void ListView(ListView control, string imageKey)
      {
         control.Items.Clear();
         control.Columns.Clear();
         control.Columns.Add("Tipo", 100);
         control.Columns.Add("Número", 100);
         control.Columns.Add("Procedencia", 200);
         control.Columns.Add("Destino", 200);
         control.Columns.Add("Entrada", 80, HorizontalAlignment.Center);
         control.Columns.Add("Salida", 80, HorizontalAlignment.Center);
         control.Columns.Add("Andén", 70, HorizontalAlignment.Center);
         control.Columns.Add("Comentarios", 300);
         control.View = View.Details;

         foreach (OTCCirculation circulation in _circulations)
         {
            ListViewItem item = new ListViewItem(OTCCirculations.TypeName(circulation.Type), imageKey);
            item.SubItems.Add(circulation.Number);
            item.SubItems.Add(circulation.Source);
            item.SubItems.Add(circulation.Destination);
            item.SubItems.Add(circulation.Arrival == DateTime.MinValue ? "" : circulation.Arrival.ToString("hh:mm"));
            item.SubItems.Add(circulation.Depart == DateTime.MinValue ? "" : circulation.Depart.ToString("hh:mm"));
            item.SubItems.Add(circulation.Platform);
            item.SubItems.Add(circulation.Comments);

            item.Tag = circulation;

            control.Items.Add(item);
         }
      }
   }

   #endregion

}
