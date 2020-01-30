using Rwm.Otc.Panels;
using Rwm.Otc.Systems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;

namespace Rwm.Otc.Configuration
{
   /// <summary>
   /// Implementa el gestor de configuración de OTC y de la aplicación que lo usa.
   /// </summary>
   public class OTCSettings
   {
      /// <summary>
      /// Nombre del archivo de configuración
      /// </summary>
      public const String FILE_NAME = "otc-settings.xml";

      /// <summary>
      /// Nombre de la carpeta que contiene la configuración de OTC.
      /// </summary>
      public const String FOLDER_NAME = "otc";

      /// <summary>
      /// Versión más reciente soportada
      /// </summary>
      public const String VERSION = "1.0";

      private const String XML_TAG_ROOT = "otc-settings";
      private const String XML_TAG_SYSTEMS = "systems";
      private const String XML_TAG_SYSTEM = "system";
      private const String XML_TAG_PARAM = "parameter";
      private const String XML_TAG_THEMES = "themes";
      private const String XML_TAG_THEME = "theme";
      private const String XML_TAG_SETTINGS = "settings";
      private const String XML_TAG_SETTING = "setting";

      private const String XML_ATTR_VER = "version";
      private const String XML_ATTR_GENERATOR = "generator";
      private const String XML_ATTR_KEY = "key";
      private const String XML_ATTR_VALUE = "value";
      private const String XML_ATTR_NAME = "name";
      private const String XML_ATTR_ACTIVE = "active";
      private const String XML_ATTR_FILE = "file";
      private const String XML_ATTR_CLASS = "class";

      private String _otcFileVer;
      private String _otcFileGenerator;
      private List<OTCSystem> _systems;
      private List<OTCLibrary> _themes;
      private Hashtable _settings;

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="OTCSettings"/>.
      /// </summary>
      public OTCSettings()
      {
         initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets la lista de controladores de sistemas digitales.
      /// </summary>
      public List<OTCSystem> Systems
      {
         get { return _systems; }
         set { _systems = value;  }
      }

      /// <summary>
      /// Gets or sets la lista de temas para los paneles de control.
      /// </summary>
      public List<OTCLibrary> Themes
      {
         get { return _themes; }
         set { _themes = value; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Recupera un valor booleano de la configuración.
      /// </summary>
      /// <param name="key">Clave del valor de configuración.</param>
      /// <param name="defaultValue">Valor por defecto que se devuelve si no se encuentra la clave.</param>
      public string GetString(string key, string defaultValue)
      {
         try
         {
            return _settings[key].ToString();
         }
         catch
         {
            return defaultValue;
         }
      }

      /// <summary>
      /// Guarda un valor de texto.
      /// </summary>
      /// <param name="key">Nombre de la clave.</param>
      /// <param name="value">Valor de la clave.</param>
      public void SetString(string key, string value)
      {
         try
         {
            _settings[key] = value;
         }
         catch
         {
            _settings.Add(key, value);
         }
      }

      /// <summary>
      /// Recupera un valor de tipo COlor de la configuración.
      /// </summary>
      /// <param name="key">Clave del valor de configuración.</param>
      /// <param name="defaultValue">Valor por defecto que se devuelve si no se encuentra la clave.</param>
      public Color GetColor(string key, Color defaultValue)
      {
         if (_settings[key] == null)
         {
            return defaultValue;
         }

         try
         {
            string[] rgb = ((String) _settings[key]).Split(',');
            return Color.FromArgb(int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2]));
         }
         catch
         {
            return defaultValue;
         }
      }

      /// <summary>
      /// Agrega o actualiza un valor de tipo Color en la configuración.
      /// </summary>
      /// <param name="key">Nombre de la clave.</param>
      /// <param name="value">Valor a almacenar.</param>
      public void SetColor(string key, Color value)
      {
         try
         {
            // Si ya existe, actualiza el valor
            _settings[key] = (value.R + "," + value.G + "," + value.B).ToUpper();
         }
         catch
         {
            // Si no existe, agrega el valor
            _settings.Add(key, (value.R + "," + value.G + "," + value.B).ToUpper());
         }
      }

      /// <summary>
      /// Recupera un valor booleano de la configuración.
      /// </summary>
      /// <param name="key">Clave del valor de configuración.</param>
      /// <param name="defaultValue">Valor por defecto que se devuelve si no se encuentra la clave.</param>
      public bool GetBoolean(string key, bool defaultValue)
      {
         bool value = false;

         if (_settings[key] == null)
         {
            return defaultValue;
         }

         if (!bool.TryParse((String) _settings[key], out value))
         {
            value = defaultValue;
         }

         return value;
      }

      /// <summary>
      /// Agrega/actualiza un valor booleano.
      /// </summary>
      /// <param name="key">Nombre de la clave.</param>
      /// <param name="value">Valor a almacenar.</param>
      public void SetBoolean(string key, bool value)
      {
         try
         {
            // Si ya existe, actualiza el valor
            _settings[key] = value.ToString().ToLower();
         }
         catch
         {
            // Si no existe, agrega el valor
            _settings.Add(key, value.ToString().ToLower());
         }
      }

      /// <summary>
      /// Recupera un valor booleano de la configuración.
      /// </summary>
      /// <param name="key">Clave del valor de configuración.</param>
      /// <param name="defaultValue">Valor por defecto que se devuelve si no se encuentra la clave.</param>
      public int GetInteger(string key, int defaultValue)
      {
         int value = 0;

         if (_settings[key] == null)
         {
            return defaultValue;
         }

         if (!int.TryParse((String) _settings[key], out value))
         {
            value = defaultValue;
         }

         return value;
      }

      /// <summary>
      /// Agrega/actualiza un valor booleano.
      /// </summary>
      /// <param name="key">Nombre de la clave.</param>
      /// <param name="value">Valor a almacenar.</param>
      public void SetInteger(string key, int value)
      {
         try
         {
            // Si ya existe, actualiza el valor
            _settings[key] = value.ToString().ToLower();
         }
         catch
         {
            // Si no existe, agrega el valor
            _settings.Add(key, value.ToString().ToLower());
         }
      }

      /// <summary>
      /// Carga la configuración desde un determinado archivo
      /// </summary>
      public void Load()
      {
         String _filename = GetFilename();

         try
         {
            // Carga el archivo XML
            XmlTextReader reader = new XmlTextReader(_filename);
            reader.WhitespaceHandling = WhitespaceHandling.None;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_filename);
            reader.Close();

            // Recupera el nodo raíz
            XmlNode xnod = xmlDoc.DocumentElement;
            if (!xnod.Name.ToLower().Equals(XML_TAG_ROOT))
            {
               throw new Exception("El archivo " + _filename + " no contiene una configuración válida (según el estándar OTC).");
            }

            // Obtiene los atributos del archivo
            _otcFileVer = xnod.Attributes[XML_ATTR_VER].Value;
            _otcFileGenerator = xnod.Attributes[XML_ATTR_GENERATOR].Value.ToString();

            // Carga los sistemas registrados
            loadSystems(xmlDoc);

            // Carga los temas para los paneles de control
            loadThemes(xmlDoc);

            // Carga los valores de configuración para las aplicaciones
            loadSettings(xmlDoc);
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      /// <summary>
      /// Guarda la configuración.
      /// </summary>
      public void Save()
      {
         try
         {
            // Abre el documento
            XmlTextWriter writer = new XmlTextWriter(GetFilename(), Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();

            writer.WriteStartElement(XML_TAG_ROOT);
            writer.WriteAttributeString(XML_ATTR_VER, OTCEnvironment.OTCVersion);
            writer.WriteAttributeString(XML_ATTR_GENERATOR, OTCEnvironment.ProductName);

               // Escribe la configuración de sistemas
               writer.WriteStartElement(XML_TAG_SYSTEMS);
               foreach (OTCSystem system in _systems)
               {
                  writer.WriteStartElement(XML_TAG_SYSTEM);
                  writer.WriteAttributeString(XML_ATTR_NAME, system.Name);
                  writer.WriteAttributeString(XML_ATTR_FILE, system.Filename);
                  writer.WriteAttributeString(XML_ATTR_CLASS, system.Class);
                  writer.WriteAttributeString(XML_ATTR_ACTIVE, (system.IsActive ? "1" : "0"));

                  foreach (OTCSystemParameter param in system.Parameters)
                  {
                     writer.WriteStartAttribute(XML_TAG_PARAM);
                     writer.WriteAttributeString(XML_ATTR_KEY, param.Key);
                     writer.WriteAttributeString(XML_ATTR_VALUE, param.Value);
                     writer.WriteEndElement();
                  }

                  writer.WriteEndElement();
               }
               writer.WriteEndElement();

               // Escribe la configuración de temas
               writer.WriteStartElement(XML_TAG_THEMES);
               foreach (OTCLibrary theme in _themes)
               {
                  writer.WriteStartElement(XML_TAG_THEME);
                  writer.WriteAttributeString(XML_ATTR_NAME, theme.Name);
                  writer.WriteAttributeString(XML_ATTR_ACTIVE, (theme.IsActive ? "1" : "0"));
                  writer.WriteEndElement();
               }
               writer.WriteEndElement();

               // Escribe la configuración de propiedades de la aplicación
               writer.WriteStartElement(XML_TAG_SETTINGS);
               foreach (String key in _settings.Keys)
               {
                  writer.WriteStartElement(XML_TAG_SETTING);
                  writer.WriteAttributeString(XML_ATTR_KEY, key);
                  writer.WriteAttributeString(XML_ATTR_VALUE, _settings[key].ToString());
                  writer.WriteEndElement();
               }
               writer.WriteEndElement();

            writer.WriteEndElement();

            writer.WriteEndDocument();
            writer.Close();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      /// <summary>
      /// Devuelve el tema activo.
      /// </summary>
      /// <returns></returns>
      public OTCLibrary GetActiveTheme()
      {
         foreach (OTCLibrary theme in _themes)
         {
            if (theme.IsActive)
            {
               return theme;
            }
         }

         return null;
      }

      /// <summary>
      /// Devuelve el controlador de sistema activo.
      /// </summary>
      /// <returns></returns>
      public OTCSystem GetActiveSystem()
      {
         foreach (OTCSystem system in _systems)
         {
            if (system.IsActive)
            {
               return system;
            }
         }

         return null;
      }

      /// <summary>
      /// Establece el controlador digital activo.
      /// </summary>
      /// <param name="system">Una instancia de <see cref="OTCSystem"/> que representa el sistema activo.</param>
      public void SetActiveSystem(OTCSystem system)
      {
         foreach (OTCSystem sys in _systems)
         {
            sys.IsActive = sys.Equals(system);
         }
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Inicializa la instáncia.
      /// </summary>
      private void initialize()
      {
         this._otcFileGenerator = String.Empty;
         this._otcFileVer = String.Empty;
         this._systems = new List<OTCSystem>();
         this._themes = new List<OTCLibrary>();
         this._settings = new Hashtable();
      }

      private String GetFilename()
      {
         try
         {
            String _filename = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return Path.Combine(_filename, OTCSettings.FILE_NAME);
         }
         catch
         {
            return OTCSettings.FILE_NAME;
         }

      }

      /// <summary>
      /// Lee los sistemas desde un fichero de configuración.
      /// </summary>
      /// <param name="xmlDoc">
      /// Una instancia de <see cref="XmlDocument"/> que representa el documento XML que contiene la configuración.
      /// </param>
      private void loadSystems(XmlDocument xmlDoc)
      {
         XmlNodeList systems = xmlDoc.GetElementsByTagName(XML_TAG_SYSTEM);

         foreach (XmlNode sysNode in systems)
         {
            OTCSystem system = new OTCSystem();
            foreach (XmlAttribute attribute in sysNode.Attributes)
            {
               switch (attribute.Name.ToLower())
               {
                  case XML_ATTR_NAME: system.Name = attribute.Value; break;
                  case XML_ATTR_FILE: system.Filename = attribute.Value; break;
                  case XML_ATTR_CLASS: system.Class = attribute.Value; break;
                  case XML_ATTR_ACTIVE: system.IsActive = (attribute.Value.Equals("1") ? true : false); break;
               }
            }

            // Obtiene los parámetros de configuración del sistema
            foreach (XmlNode parameter in sysNode.ChildNodes)
            {
               if (parameter.Name.ToLower().Equals(XML_TAG_PARAM))
               {
                  OTCSystemParameter param = new OTCSystemParameter();
                  foreach (XmlAttribute attribute in parameter.Attributes)
                  {
                     switch (attribute.Name.ToLower())
                     {
                        case XML_ATTR_KEY: param.Key = attribute.Value; break;
                        case XML_ATTR_VALUE: param.Value = attribute.Value; break;
                     }
                  }
                  system.Parameters.Add(param);
               }
            }

            this._systems.Add(system);
         }
      }

      /// <summary>
      /// Lee los sistemas desde un fichero de configuración.
      /// </summary>
      /// <param name="xmlDoc">
      /// Una instancia de <see cref="XmlDocument"/> que representa el documento XML que contiene la configuración.
      /// </param>
      private void loadThemes(XmlDocument xmlDoc)
      {
         string path;
         XmlNodeList systems = xmlDoc.GetElementsByTagName(XML_TAG_THEME);

         foreach (XmlNode thNode in systems)
         {
            OTCLibrary theme = new OTCLibrary();
            foreach (XmlAttribute attribute in thNode.Attributes)
            {
               switch (attribute.Name.ToLower())
               {
                  case "name": theme.Name = attribute.Value; break;
                  case "active": theme.IsActive = (attribute.Value.Equals("1") ? true : false); break;
               }
            }

            try
            {
               // Carga la libreria
               path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
               path = Path.Combine(path, OTCSettings.FOLDER_NAME);
               path = Path.Combine(path, OTCLibrary.LIBRARY_FOLDER_NAME);
               path = Path.Combine(path, theme.Name);
               path = Path.Combine(path, OTCLibrary.LIBRARY_FILE_NAME);
               theme.Load(path);

               this._themes.Add(theme);
            }
            catch
            {
               // Descarta la excepción
               // TODO: Agregar la libreria "marcada" como errónea
            }
         }
      }

      /// <summary>
      /// Lee los parametros de configuración para las aplicaciones que usan OTC.
      /// </summary>
      /// <param name="xmlDoc">
      /// Una instancia de <see cref="XmlDocument"/> que representa el documento XML que contiene la configuración.
      /// </param>
      private void loadSettings(XmlDocument xmlDoc)
      {
         XmlNodeList systems = xmlDoc.GetElementsByTagName(XML_TAG_SETTING);

         foreach (XmlNode thNode in systems)
         {
            try
            {
               _settings.Add(thNode.Attributes[XML_ATTR_KEY].Value,
                             thNode.Attributes[XML_ATTR_VALUE].Value);
            }
            catch
            {
               // Desestima la excepción y no carga el valor
            }
         }
      }

      #endregion
      
   }
}
