using System.Configuration;
using System.Drawing;

namespace Rwm.Otc.Configuration
{

   /// <summary>
   /// Implementa una clase para acceder a la configuración de una aplicación
   /// </summary>
   public class OTCSettingsManager
   {
      private ExeConfigurationFileMap fileMap = null;
      private System.Configuration.Configuration conf = null;
      private string _filename = string.Empty;

      /// <summary>
      /// Gets a new instance of <see cref="OTCSettingsManager"/>.
      /// </summary>
      /// <param name="filename">Nombre del archivo de configuración.</param>
      public OTCSettingsManager(string filename)
      {
         _filename = filename;

         try
         {
            // Abre el archivo
            fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = filename;
            conf = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
         }
         catch
         {
            throw;
         }
      }

      #region Properties

      /// <summary>
      /// Gets or sets el nombre del archivo de configuración.
      /// </summary>
      public string Filename
      {
         get { return _filename; }
         set { _filename = value; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Guarda los valores en el archivo XML.
      /// </summary>
      public void Save()
      {
         try
         {
            // Guarda los valores
            conf.Save(ConfigurationSaveMode.Full);
         }
         catch
         {
            // SI no se puede guardar se omite el error para evitar errores de cierre si alguna aplicación lo ha modificado externamente
            // throw;
         }
      }

      /// <summary>
      /// Agrega/actualiza un valor general.
      /// </summary>
      /// <param name="key">Nombre de la clave.</param>
      /// <param name="value">Valor de la clave.</param>
      public void SaveSetting(string key, string value)
      {
         try
         {
            conf.AppSettings.Settings[key].Value = value;
         }
         catch
         {
            conf.AppSettings.Settings.Add(key, value);
         }
      }

      /// <summary>
      /// Agrega/actualiza un valor específico de una aplicación.
      /// </summary>
      /// <param name="appname">Nombre de la aplicación propietaria.</param>
      /// <param name="key">Nombre de la clave.</param>
      /// <param name="value">Valor de la clave.</param>
      public void SaveSetting(string appname, string key, string value)
      {
         try
         {
            //conf.Sections.Add(appname, conf.AppSettings);
            //conf.Sections[appname]. .Settings.Add(key, value);
         }
         catch
         {
         }
      }

      /// <summary>
      /// Elimina una clave de configuración del registro local.
      /// </summary>
      /// <param name="key">Nombre de la clave.</param>
      public void RemoveSetting(string key)
      {
         try
         {
            conf.AppSettings.Settings.Remove(key);
         }
         catch
         {
         }
      }

      /// <summary>
      /// Obtiene un valor de la configuración local.
      /// </summary>
      /// <param name="key">Nombre de la clave.</param>
      /// <param name="defaultvalue">Valor por defecto cuando el valor no está establecido.</param>
      public string GetSetting(string key, string defaultvalue)
      {
         try
         {
            return conf.AppSettings.Settings[key].Value;
         }
         catch
         {
            return defaultvalue;
         }
      }

      /// <summary>
      /// Obtiene un valor de la configuración local. Si no existe, devuelve una cadena vacía.
      /// </summary>
      /// <param name="key">Nombre de la clave.</param>
      public string GetSetting(string key)
      {
         try
         {
            return conf.AppSettings.Settings[key].Value;
         }
         catch
         {
            return string.Empty;
         }
      }

      /// <summary>
      /// Recupera un valor booleano de la configuración.
      /// </summary>
      /// <param name="key">Clave del valor de configuración.</param>
      /// <param name="defaultValue">Valor por defecto que se devuelve si no se encuentra la clave.</param>
      public string GetString(string key, string defaultValue)
      {
         try
         {
            return conf.AppSettings.Settings[key].Value;
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
            conf.AppSettings.Settings[key].Value = value;
         }
         catch
         {
            conf.AppSettings.Settings.Add(key, value);
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
            conf.AppSettings.Settings[key].Value = (value.R + "," + value.G + "," + value.B).ToUpper();
         }
         catch
         {
            // Si no existe, agrega el valor
            conf.AppSettings.Settings.Add(key, (value.R + "," + value.G + "," + value.B).ToUpper());
         }
      }

      /// <summary>
      /// Recupera un valor de tipo COlor de la configuración.
      /// </summary>
      /// <param name="key">Clave del valor de configuración.</param>
      /// <param name="defaultValue">Valor por defecto que se devuelve si no se encuentra la clave.</param>
      public Color GetColor(string key, Color defaultValue)
      {
         if (conf.AppSettings.Settings[key] == null)
         {
            return defaultValue;
         }

         try
         {
            string[] rgb = conf.AppSettings.Settings[key].Value.Split(',');
            return Color.FromArgb(int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2]));
         }
         catch
         {
            return defaultValue;
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

         if (conf.AppSettings.Settings[key] == null)
         {
            return defaultValue;
         }

         if (!bool.TryParse(conf.AppSettings.Settings[key].Value, out value))
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
            conf.AppSettings.Settings[key].Value = value.ToString().ToLower();
         }
         catch
         {
            // Si no existe, agrega el valor
            conf.AppSettings.Settings.Add(key, value.ToString().ToLower());
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

         if (conf.AppSettings.Settings[key] == null)
         { 
            return defaultValue;
         }

         if (!int.TryParse(conf.AppSettings.Settings[key].Value, out value))
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
            conf.AppSettings.Settings[key].Value = value.ToString().ToLower();
         }
         catch
         {
            // Si no existe, agrega el valor
            conf.AppSettings.Settings.Add(key, value.ToString().ToLower());
         }
      }

      /// <summary>
      /// Recarga la configuración desde el archivo.
      /// </summary>
      /// <remarks>
      /// Este método es práctico cuando varios procesos actualizan un mismo archivo de configuración.
      /// </remarks>
      public void Reload()
      {
         if (string.IsNullOrWhiteSpace(Filename)) return;

         // Abre el archivo
         fileMap = new ExeConfigurationFileMap();
         fileMap.ExeConfigFilename = Filename;
         conf = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
      }

      #endregion

   }
}
