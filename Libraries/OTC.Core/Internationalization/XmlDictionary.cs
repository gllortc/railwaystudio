using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using Emdep.Core.Utils;
using Emdep.Core.XML;

namespace Emdep.Core.Internationalization
{
   /// <summary>
   /// Implements a dictionary file that contains one or more languages (translations).
   /// </summary>
   public class XmlDictionary
   {

      #region Constructors

      /// <summary>
      /// Returns an instance of <see cref="XmlDictionary"/>.
      /// </summary>
      public XmlDictionary()
      {
         Initialize();
      }

      /// <summary>
      /// Returns an instance of <see cref="XmlDictionary"/>.
      /// </summary>
      public XmlDictionary(string filename)
      {
         Initialize();
         LoadDictionary(filename);
      }

      /// <summary>
      /// Returns an instance of <see cref="XmlDictionary"/>.
      /// </summary>
      public XmlDictionary(DataTable dataTable)
      {
         Initialize();
         FromDataTable(dataTable);
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the default language code.
      /// </summary>
      public string DefaultLanguageCode { get; set; }

      /// <summary>
      /// Gets or sets the assembly name.
      /// </summary>
      public string AssemblyName { get; set; }

      /// <summary>
      /// Gets the version of the dictionary format.
      /// </summary>
      public string Version { get; private set; }

      /// <summary>
      /// Gets the currently filename with path.
      /// </summary>
      public string Filename { get; private set; }

      /// <summary>
      /// Gets all the languages included in the dictionary.
      /// </summary>
      public Dictionary<string, XmlLanguage> Languages { get; internal set; }

      #endregion

      #region Methods

      /// <summary>
      /// Get a string value from settings and converts the value of objects to strings based on 
      /// the formats specified and inserts them into another string.
      /// </summary>
      /// <param name="key">Key identifier.</param>
      /// <param name="defaultValue">Default value returned when the key isn't present.</param>
      /// <returns>The string value corresponding to the key.</returns>
      public string GetString(string currentLangCode, string key, string defaultValue, params object[] list)
      {
         return string.Format(this.GetString(currentLangCode, key, defaultValue), list);
      }

      /// <summary>
      /// Get a string value from settings.
      /// </summary>
      /// <param name="key">Key identifier.</param>
      /// <param name="defaultValue">Default value returned when the key isn't present.</param>
      /// <returns>The string value corresponding to the key.</returns>
      public string GetString(string currentLangCode, string key, string defaultValue)
      {
         try
         {
            if (this.Languages.ContainsKey(currentLangCode))
            {
               if (this.Languages[currentLangCode].Text.ContainsKey(key))
               {
                  return StringUtils.ReplaceTextCodes(this.Languages[currentLangCode].Text[key]);
               }
               else
               {
                  return StringUtils.ReplaceTextCodes(defaultValue);
               }
            }
            else
            {
               return StringUtils.ReplaceTextCodes(defaultValue);
            }
         }
         catch
         {
            return StringUtils.ReplaceTextCodes(defaultValue);
         }
      }

      /// <summary>
      /// Adds or replace a language string into the dictionary.
      /// </summary>
      /// <param name="langCode">Language code. The language must exists in the dictionary.</param>
      /// <param name="key">Text key.</param>
      /// <param name="defaultValue">Text string.</param>
      public void AddString(string langCode, string key, string defaultValue)
      {
         if (!this.Languages.ContainsKey(langCode))
         {
            throw new ArgumentException(string.Format("The language with code {0} don't exist.", langCode));
         }

         if (this.Languages[langCode].Text.ContainsKey(key))
         {
            this.Languages[langCode].Text[key] = defaultValue;
         }
         else
         {
            this.Languages[langCode].Text.Add(key, defaultValue);
         }
      }

      /// <summary>
      /// Adds a new language into the dictionary.
      /// </summary>
      /// <param name="code">Language code.</param>
      /// <param name="name">Language name.</param>
      public void AddLanguage(string code, string name)
      {
         if (!this.Languages.ContainsKey(code))
         {
            this.Languages.Add(code, new XmlLanguage(code, name));
         }
         else
         {
            throw new ArgumentException(string.Format("The language with code {0} yet exist.", code));
         }
      }

      /// <summary>
      /// Load dictionary for the specified assembly.
      /// </summary>
      public void LoadDictionaryByAssembly(System.Reflection.Assembly assembly)
      {
         // Get the current assembly filename
         string file = System.Reflection.Assembly.GetCallingAssembly().Location;

         // Try to load <Application.Path>\<AssemblyFilename>.lng
         file = Path.ChangeExtension(file, ".lng");
         if (File.Exists(file))
         {
            this.LoadDictionary(file);
            return;
         }

         // Try to load <Application.Path>\<AssemblyFilename>.xml
         file = Path.ChangeExtension(file, ".xml");
         if (File.Exists(file))
         {
            this.LoadDictionary(file);
            return;
         }
      }

      /// <summary>
      /// Load internationalization information from an XML file.
      /// </summary>
      /// <param name="filename">Filename (and path) to file taht contains the data.</param>
      public void LoadDictionary(string filename)
      {
         XmlLanguage language = null;

         try
         {
            XmlDataDocument xmldoc = new XmlDataDocument();
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
               // Load the XML file
               xmldoc.Load(fs);

               // Get the information about file format and version
               if (xmldoc.GetElementsByTagName("emdep-internationalization").Count < 0)
               {
                  throw new Exception("The file does not seem to be an archive of software internationalization from EMDEP.");
               }
               else
               {
                  this.Version = xmldoc.GetElementsByTagName("emdep-internationalization")[0].Attributes["version"].Value;
                  this.DefaultLanguageCode = xmldoc.GetElementsByTagName("emdep-internationalization")[0].Attributes["default"].Value;
               }

               // Get all the SETTING elements
               this.Languages = new Dictionary<string, XmlLanguage>();
               foreach (XmlElement xmlLanguage in xmldoc.GetElementsByTagName("language"))
               {
                  language = new XmlLanguage(xmlLanguage);
                  this.Languages.Add(xmlLanguage.GetAttribute("code"), language);
               }
            }

            this.Filename = filename;
            this.AssemblyName = Path.GetFileNameWithoutExtension(filename);
         }
         catch
         {
            // Clean settings
            Initialize();

            throw;
         }
      }

      /// <summary>
      /// Load internationalization information from an XML file.
      /// </summary>
      /// <param name="filename">Filename (and path) to file taht contains the data.</param>
      public void SaveDictionary(string filename)
      {
         try
         {
            using (XmlWriter writer = XmlWriterIndent.Create(filename))
            {
               writer.WriteStartElement("emdep-internationalization");
               writer.WriteAttributeString("default", this.DefaultLanguageCode);
               writer.WriteAttributeString("version", "1.0");

               foreach (XmlLanguage language in this.Languages.Values)
               {
                  writer.WriteStartElement("language");
                  writer.WriteAttributeString("code", language.LanguageCode);
                  writer.WriteAttributeString("name", language.Name);

                  foreach (string key in language.Text.Keys)
                  {
                     // Only save the language keys with value to ensure that the 
                     // default value harcoded in coded will be shown
                     if (!string.IsNullOrEmpty(language.Text[key]))
                     {
                        writer.WriteStartElement("exp");
                        writer.WriteAttributeString("key", key);
                        writer.WriteAttributeString("value", language.Text[key]);
                        writer.WriteEndElement();
                     }
                  }

                  writer.WriteEndElement();
               }

               writer.WriteEndElement();

               writer.Close();
            }

            this.Filename = filename;
         }
         catch
         {
            throw;
         }
      }

      /// <summary>
      /// Convert the dictionary into an instance of <see cref="DataTable"/>, with each text in a row and each language into a column.
      /// </summary>
      /// <returns>The requestes data table filled with dictionary text.</returns>
      public DataTable ToDataTable()
      {
         int colIdx = 0;
         DataRow row;

         // Convert current data into a single dictionary
         Dictionary<string, Dictionary<string, string>> mdic = new Dictionary<string, Dictionary<string, string>>();

         foreach (XmlLanguage language in this.Languages.Values)
         {
            foreach (string key in language.Text.Keys)
            {
               if (!mdic.ContainsKey(key))
               {
                  mdic.Add(key, new Dictionary<string, string>());
               }
            }
         }

         foreach (XmlLanguage language in this.Languages.Values)
         {
            foreach (string key in language.Text.Keys)
            {
               if (!mdic[key].ContainsKey(language.LanguageCode))
               {
                  mdic[key].Add(language.LanguageCode, string.Empty);
               }
            }
         }

         foreach (XmlLanguage language in this.Languages.Values)
         {
            foreach (string key in language.Text.Keys)
            {
               mdic[key][language.LanguageCode] = language.Text[key];
            }
         }

         // Convert sinlge dictionary into a data table
         DataTable dt = new DataTable();

         dt.Columns.Add("Key", typeof(string));
         foreach (XmlLanguage language in this.Languages.Values)
         {
            dt.Columns.Add(language.LanguageCode + " | " + language.Name, typeof(string));
         }

         foreach (string key in mdic.Keys)
         {
            row = dt.NewRow();
            row[0] = key;

            colIdx = 1;
            foreach (string lngkey in mdic[key].Keys)
            {
               row[colIdx] = mdic[key][lngkey];
               colIdx++;
            }

            dt.Rows.Add(row);
         }

         return dt;
      }

      public void FromDataTable(DataTable dataTable)
      {
         string langKey;
         string[] values;

         this.Languages = new Dictionary<string, XmlLanguage>();

         // Create languages
         foreach (DataColumn column in dataTable.Columns)
         {
            if (column.Ordinal > 0)
            {
               values = column.ColumnName.Split('|');
               this.Languages.Add(values[0].Trim(), new XmlLanguage(values[0].Trim(), values[1].Trim()));
            }
         }

         foreach (DataRow row in dataTable.Rows)
         {
            foreach (DataColumn column in dataTable.Columns)
            {
               if (column.Ordinal > 0)
               {
                  values = column.ColumnName.Split('|');
                  langKey = values[0].Trim();

                  this.Languages[langKey].Text.Add(row[0].ToString(), row[column.Ordinal].ToString());
               }
            }
         }
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the current instance.
      /// </summary>
      private void Initialize()
      {
         this.AssemblyName = string.Empty;
         this.Version = string.Empty;
         this.Filename = string.Empty;
         this.Languages = new Dictionary<string, XmlLanguage>();
      }

      #endregion

   }
}
