using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Rwm.Otc.Help
{
   /// <summary>
   /// Implementa un elemento de índice del sistema de ayuda según OTC.
   /// </summary>
   public class OTCHelpIndex
   {
      private string _id = string.Empty;
      private string _title = string.Empty;
      private string _description = string.Empty;
      private string _version = string.Empty;
      private string _author = string.Empty;
      private string _href = string.Empty;
      private List<OTCHelpIndex> _items;

      /// <summary>Extensión de los archivos índice de la ayuda de OTC.</summary>
      public static string FILE_EXTENSION = "oth";

      /// <summary>Extensión de los archivos índice de la ayuda de OTC.</summary>
      public static string FILE_FILTER = "Archivos de ayuda|*.oth";

      /// <summary>
      /// Returns a new instance of <see cref="OTCHelpIndex"/>.
      /// </summary>
      public OTCHelpIndex()
      {
         _id = string.Empty;
         _title = string.Empty;
         _description = string.Empty;
         _version = string.Empty;
         _author = string.Empty;
         _href = string.Empty;
         _items = new List<OTCHelpIndex>();
      }

      /// <summary>
      /// Returns a new instance of <see cref="OTCHelpIndex"/>
      /// </summary>
      /// <param name="filename">Nombre del archivo que contiene el índice a cargar.</param>
      public OTCHelpIndex(string filename)
      {
         _id = string.Empty;
         _title = string.Empty;
         _description = string.Empty;
         _version = string.Empty;
         _author = string.Empty;
         _href = string.Empty;
         _items = new List<OTCHelpIndex>();

         Load(filename);
      }

      #region Properties

      /// <summary>
      /// Identificador del elemento.
      /// </summary>
      public string Id
      {
         get { return _id; }
         set { _id = value; }
      }

      /// <summary>
      /// Título del elemento.
      /// </summary>
      public string Title
      {
         get { return _title; }
         set { _title = value; }
      }

      /// <summary>
      /// Descripción del elemento.
      /// </summary>
      public string Description
      {
         get { return _description; }
         set { _description = value; }
      }

      /// <summary>
      /// Versión del elemento.
      /// </summary>
      public string Version
      {
         get { return _version; }
         set { _version = value; }
      }

      /// <summary>
      /// Autor del elemento.
      /// </summary>
      public string Author
      {
         get { return _author; }
         set { _author = value; }
      }

      /// <summary>
      /// Dirección URL del elemento.
      /// </summary>
      public string Href
      {
         get { return _href; }
         set { _href = value; }
      }

      /// <summary>
      /// Lista de elementos que lo componen.
      /// </summary>
      public List<OTCHelpIndex> Items
      {
         get { return _items; }
         set { _items = value; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Carga un índice de ayuda de OTC.
      /// </summary>
      /// <param name="filename">Nombre y ruta del archivo que contiene el índice a cargar.</param>
      public void Load(string filename)
      {
         FileInfo file = new FileInfo(filename);

         // Carga el archivo XML
         XmlTextReader reader = new XmlTextReader(file.FullName);
         reader.WhitespaceHandling = WhitespaceHandling.None;
         XmlDocument xmlDoc = new XmlDocument();
         xmlDoc.Load(file.FullName);

         // Recupera el nodo raíz
         XmlNode xnod = xmlDoc.DocumentElement;
         if (!xnod.Name.ToLower().Equals("otc-help"))
            throw new Exception("El archivo proporcionado no corresponde a un índice de ayuda según el estándar OTC.");

         // Recupera la información del índice de ayuda
         foreach (XmlNode node in xnod.ChildNodes)
         {
            switch (node.Name.ToLower())
            {
               case "title": _title = node.InnerText; break;
               case "description": _description = node.InnerText; break;
               case "version": _version = node.InnerText; break;
               case "author": _author = node.InnerText; break;
            }
         }

         // Recupera y devuelve el árbol de temas
         LoadTopic(xnod, this, file);
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Carga el índice de la ayuda en un control TreeView.
      /// </summary>
      /// <param name="parent">Nodo superior.</param>
      /// <param name="index">Índice de ayuda actual.</param>
      /// <param name="file">Archivo de índice actual.</param>
      private OTCHelpIndex LoadTopic(XmlNode parent, OTCHelpIndex index, FileInfo file)
      {
         try
         {
            foreach (XmlNode thema in parent.ChildNodes)
            {
               if (thema.Name.ToLower() == "thema")
               {
                  OTCHelpIndex item = new OTCHelpIndex();
                  foreach (XmlAttribute attr in thema.Attributes)
                  {
                     switch (attr.Name)
                     {
                        case "title":
                           item.Title = attr.Value;
                           break;
                        case "href":
                           if (attr.Value.ToLower().StartsWith("http"))
                              item.Href = attr.Value;
                           else if (!attr.Value.Equals(""))
                              item.Href = Path.Combine(file.Directory.FullName, attr.Value);
                           else
                              item.Href = "about:blank";
                           break;
                        case "id":
                           item.Id = attr.Value;
                           break;
                     }
                  }

                  index.Items.Add(LoadTopic(thema, item, file));
               }
            }
         }
         catch (Exception e)
         {
            throw e;
         }

         return index;
      }

      #endregion
   }
}
