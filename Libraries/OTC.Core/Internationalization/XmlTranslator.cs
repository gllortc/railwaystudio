using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Emdep.Core.Utils;

namespace Emdep.Core.Internationalization
{
   /// <summary>
   /// Class for manage language internationalization using XML files.
   /// </summary>
   /// <remarks>
   /// The purpouse of this class is make possible the text internationalization for assemblies.<br />
   /// Each language file must follow this schema:
   /// <code>
   /// <emdep-internationalization default="en" version="1.0">
   ///   <language code="es" name="Spanish">
   ///      <exp key="app1.sample.ke1" value="Hola" />
   ///      <exp key="app1.sample.ke2" value="Adios" />
   ///      <exp key="app1.sample.ke3" value="Pulse botón" />
   ///   </language>
   ///   <language code="en" name="English">
   ///      <exp key="app1.sample.ke1" value="Hello" />
   ///      <exp key="app1.sample.ke2" value="Good bye" />
   ///      <exp key="app1.sample.ke3" value="Press button" />
   ///   </language>
   /// </emdep-internationalization>
   /// </code>
   /// The name of each file must be the same as the assembly changing the extension to <code>.lng</code> and these files must be placed at 
   /// same folder of the assembly (EXE or DLL).
   /// </remarks>
   public class XmlTranslator
   {
      // Internal data declarations
      private static volatile XmlTranslator singletonInstance;
      private static object syncRoot = new Object();
      private static string currentLangCode;
      private static string fileVersion;
      private static string lastFileName;
      private static Dictionary<string, XmlDictionary> dictionaries;

      #region Constructors

      /// <summary>
      /// Return an instance of <see cref="XmlSettingsManager"/>.
      /// </summary>
      static XmlTranslator()
      {
         Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Returns the instance of translator to use.
      /// </summary>
      public static XmlTranslator Instance
      {
         get
         {
            if (singletonInstance == null)
            {
               lock (syncRoot)
               {
                  if (singletonInstance == null)
                  {
                     singletonInstance = new XmlTranslator();
                  }
               }
            }

            return singletonInstance;
         }
      }

      /// <summary>
      /// Gets or sets the language code used to work with the instance.
      /// </summary>
      public static string CurrentLanguageCode
      {
         get { return currentLangCode; }
         set { currentLangCode = value; }
      }

      /// <summary>
      /// Gets or sets the version of the internationalization currently loaded file.
      /// </summary>
      public static string FileVersion
      {
         get { return fileVersion; }
         set { fileVersion = value; }
      }

      /// <summary>
      /// Gets or sets the name and path of setting file currently loaded.
      /// </summary>
      public static string LoadedFilename
      {
         get { return lastFileName; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Set a string property with the requested translated text corresponding to a key.
      /// </summary>
      /// <param name="stringProperty">A string corresponding to a property to set.</param>
      /// <param name="key">Key identifier.</param>
      /// <remarks>
      /// This method is designed to easily set a control text property with translated text. 
      /// If key doesn't exists, the original property text is used. For example:<br /><br />
      /// <c>XmlTranslator.SetStringProperty(lblName.Text, "key-to-translate");</c>
      /// </remarks>
      [Obsolete()]
      public static void SetStringProperty(Control control, string key)
      {
         if (control is Button)
         {
            ((Button)control).Text = GetString(key, ((Button)control).Text);
         }
         else if (control is Label)
         {
            ((Label)control).Text = GetString(key, ((Label)control).Text);
         }
      }

      /// <summary>
      /// Get a string value from settings.
      /// </summary>
      /// <param name="key">Key identifier.</param>
      /// <returns>The string value corresponding to the key or 0 if the key isn't present.</returns>
      public static string GetString(string key)
      {
         try
         {
            // Get the dictionary key
            string dictionaryKey = Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetCallingAssembly().Location);

            return XmlTranslator.GetTranslatedString(dictionaryKey, key, string.Empty);
         }
         catch
         {
            return string.Empty;
         }
      }

      /// <summary>
      /// Get a string value from settings.
      /// </summary>
      /// <param name="key">Key identifier.</param>
      /// <param name="defaultValue">Default value returned when the key isn't present.</param>
      /// <returns>The string value corresponding to the key.</returns>
      public static string GetString(string key, string defaultValue)
      {
         try
         {
            // Get the dictionary key
            string dictionaryKey = Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetCallingAssembly().Location);

            return XmlTranslator.GetTranslatedString(dictionaryKey, key, defaultValue);
         }
         catch
         {
            return StringUtils.ReplaceTextCodes(defaultValue);
         }
      }

      /// <summary>
      /// Get a string value from settings and converts the value of objects to strings based on 
      /// the formats specified and inserts them into another string.
      /// </summary>
      /// <param name="key">Key identifier.</param>
      /// <param name="defaultValue">Default value returned when the key isn't present.</param>
      /// <returns>The string value corresponding to the key.</returns>
      public static string GetString(string key, string defaultValue, params object[] list)
      {
         try
         {
            // Get the dictionary key
            string dictionaryKey = Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetCallingAssembly().Location);

            return string.Format(XmlTranslator.GetTranslatedString(dictionaryKey, key, defaultValue), list);
         }
         catch
         {
            return StringUtils.ReplaceTextCodes(defaultValue);
         }
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the current instance.
      /// </summary>
      private static void Initialize()
      {
         fileVersion = string.Empty;
         currentLangCode = "en";
         lastFileName = string.Empty;
         dictionaries = new Dictionary<string,XmlDictionary>();
      }

      private static string GetTranslatedString(string dictionayKey, string key, string defaultValue)
      {
         try
         {
            // Check if dictionary is previously loaded
            if (!dictionaries.ContainsKey(dictionayKey))
            {
               string filename = Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location);
               filename = Path.Combine(filename, dictionayKey + ".lng");

               XmlDictionary newDic = new XmlDictionary(filename);
               dictionaries.Add(newDic.AssemblyName, newDic);
            }

            return dictionaries[dictionayKey].GetString(currentLangCode, key, defaultValue);
         }
         catch
         {
            return StringUtils.ReplaceTextCodes(defaultValue);
         }
      }

      #endregion

   }
}
