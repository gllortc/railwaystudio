using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;

namespace Rwm.Otc.Internationalization
{
   /// <summary>
   /// Clase que sirve para la internacionalización idiomática de una aplicación OTC.
   /// </summary>
   public static class OTCLanguage
   {

      #region Constants

      private const string XML_NODE_ROOT = "otc-language";
      private const string XML_NODE_LANGUAGE = "language";
      private const string XML_NODE_TEXT = "text";

      private const string XML_ATTR_KEY = "key";
      private const string XML_ATTR_VALUE = "value";
      private const string XML_ATTR_CODE = "code";
      private const string XML_ATTR_NAME = "name";

      /// <summary>
      /// Extensión (sin punto) de los archivos de internacionalización idiomática de las aplicaciones OTC.
      /// </summary>
      public const string FILE_EXTENSION = "otclng";

      #endregion

      #region Fields

      private static Hashtable DictionaryText { get; set; }

      private static string FileName { get; set; }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets el nombre del idioma implementado.
      /// </summary>
      public static string LanguageName { get; set; }

      /// <summary>
      /// Gets or sets el código internacional del idioma implementado.
      /// </summary>
      public static string LanguageCode { get; set; }

      #endregion

      #region Methods

      public static void Initialize(Type type, string languageCode)
      {
         OTCLanguage.DictionaryText = new Hashtable();

         try
         {
            // Get the filename to load
            string codeBase = type.Assembly.CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            OTCLanguage.FileName = Path.Combine(Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path)),
                                                string.Format("{0}.{1}", type.Name.Trim(), OTCLanguage.FILE_EXTENSION));

            // Load the languages file (XML)
            XmlTextReader reader = new XmlTextReader(OTCLanguage.FileName);
            reader.WhitespaceHandling = WhitespaceHandling.None;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(OTCLanguage.FileName);
            reader.Close();

            // Check if the file is a OTCLanguage file
            XmlNode xnod = xmlDoc.DocumentElement;
            if (!xnod.Name.ToLower().Equals(XML_NODE_ROOT))
            {
               OTCLanguage.FileName = string.Empty;
               OTCLanguage.DictionaryText.Clear();

               throw new Exception("Incorrect language file format.");
            }

            // Load the language keys by code
            foreach (XmlNode node in xnod.ChildNodes)
            {
               switch (node.Name.ToLower())
               {
                  case XML_NODE_LANGUAGE:
                     OTCLanguage.LanguageCode = node.Attributes[XML_ATTR_CODE].Value;
                     OTCLanguage.LanguageName = node.Attributes[XML_ATTR_NAME].Value;
                     break;

                  case XML_NODE_TEXT:
                     OTCLanguage.DictionaryText.Add(node.Attributes[XML_ATTR_KEY].Value.ToLower(),
                                                    node.Attributes[XML_ATTR_VALUE].Value);
                     break;
               }
            }
         }
         catch
         {
            OTCLanguage.FileName = string.Empty;
            OTCLanguage.DictionaryText.Clear();

            throw;
         }
      }

      /// <summary>
      /// Obtiene el texto asociado a una clave.
      /// </summary>
      /// <param name="key">Clave del texto.</param>
      /// <param name="defaultValue">Texto por defecto a mostrar si no se encuentra la clave.</param>
      /// <returns>El texto asociado a la clave.</returns>
      public static string GetString(string key, string defaultValue)
      {
         if (string.IsNullOrEmpty(OTCLanguage.FileName))
         {
            return defaultValue;
         }

         string val = OTCLanguage.DictionaryText[key.Trim().ToLower()].ToString();
         return (!string.IsNullOrEmpty(val) ? val : defaultValue);
      }

      /// <summary>
      /// Obtiene el texto asociado a una clave.
      /// </summary>
      /// <param name="key">Clave del texto.</param>
      /// <returns>El texto asociado a la clave.</returns>
      public static string GetString(string key)
      {
         return OTCLanguage.GetString(key, string.Empty);
      }

      /// <summary>
      ///  Obtiene el texto asociado a una clave.
      /// </summary>
      /// <param name="key">Clave del texto.</param>
      /// <param name="defaultValue">Texto por defecto a mostrar si no se encuentra la clave.</param>
      /// <param name="parameters">Parámetros a insertar en el texto (notación {n}).</param>
      /// <returns>El texto asociado a la clave.</returns>
      public static string GetString(string key, string defaultValue, params string[] parameters)
      {
         if (string.IsNullOrEmpty(OTCLanguage.FileName))
         {
            return defaultValue;
         }

         StringBuilder sb = new StringBuilder();
         sb.AppendFormat(!string.IsNullOrEmpty(OTCLanguage.DictionaryText[key.Trim().ToLower()].ToString()) ? OTCLanguage.DictionaryText[key.Trim().ToLower()].ToString() : defaultValue, parameters);

         return sb.ToString();
      }

      /// <summary>
      ///  Obtiene el texto asociado a una clave.
      /// </summary>
      /// <param name="key">Clave del texto.</param>
      /// <param name="parameters">Parámetros a insertar en el texto (notación {n}).</param>
      /// <returns>El texto asociado a la clave.</returns>
      public static string GetString(string key, params string[] parameters)
      {
         return OTCLanguage.GetString(key, string.Empty, parameters);
      }

      #endregion

   }
}
