using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Emdep.Core.Utils;

namespace Emdep.Core.Internationalization
{
   /// <summary>
   /// Implements a translator class for application internationalization (i18n).
   /// </summary>
   public class Translator
   {
      // Internal data declarations
      private static Dictionary<string, string> _messages;
      private static string _fileLanguage;
      private static string dictionariesFolder = string.Empty;
      private static object mutex;
      private static Encoding fileEncoding = Encoding.Default;

      #region Constants

      private static string FILE_DEFAULT_LANGUAGE = "english.lng";

      private static string FOLDER_DICTIONARIES = "dictionaries";

      #endregion

      #region Methods

      /// <summary>
      /// set the encoding of the content of the dictionary
      /// </summary>
      /// <param name="encoding"></param>
      public static void SetFileEncoding(Encoding encoding)
      {
         fileEncoding = encoding;
      }

      /// <summary>
      /// set the dictionary folder
      /// </summary>
      /// <param name="folder"></param>
      public static void SetDictionariesFolder(string folder)
      {
         dictionariesFolder = folder;
      }

      /// <summary>
      /// Initializes the dictionary.
      /// </summary>
      /// <param name="language">Language code to load.</param>
      /// <returns><c>true</c> if it is load correctly or <c>false</c> in all other cases.</returns>
      public static bool IniDictionary(string language = "English")
      {
         string vtPath;

         if (dictionariesFolder == string.Empty)
         {
            vtPath = Path.Combine(Translator.AssemblyDirectory, Translator.FOLDER_DICTIONARIES);
         }
         else
         {
            vtPath = dictionariesFolder;
         }

         string dictionaryPath = Path.Combine(vtPath, language + ".lng");
         _fileLanguage = dictionaryPath;

         if (!File.Exists(dictionaryPath))
         {
            //Check if exists in the same folder
            FileInfo fi = new FileInfo(Application.ExecutablePath);
            string samefolderDic = Path.Combine(fi.Directory.FullName, Translator.FILE_DEFAULT_LANGUAGE);
            if (File.Exists(samefolderDic))
            {
               dictionaryPath = samefolderDic;
               _fileLanguage = samefolderDic;
            }
         }

         if (!File.Exists(dictionaryPath))
         {
            MessageBox.Show("Dictionary file not found: " + dictionaryPath,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            dictionaryPath = Path.Combine(vtPath, Translator.FILE_DEFAULT_LANGUAGE);
            _fileLanguage = dictionaryPath;

            if (!File.Exists(dictionaryPath))
            {
               MessageBox.Show("Default dictionary file not found: " + dictionaryPath,
                               Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
         }

         LoadMessages();

         // create the semaphor
         mutex = new object();

         return true;
      }

      /// <summary>
      /// Get a translated text according to language selected.
      /// </summary>
      /// <param name="code">Test code.</param>
      /// <param name="defaultMessage">Text returned if no dicctionary is loaded or language code is not present in dictionary.</param>
      /// <returns>An apropieted text according to language selected.</returns>
      public static string GetMessage(string code, string defaultMessage)
      {
         lock (mutex)
         {
            if (_messages == null)
            {
                return defaultMessage;
            }

            if (_messages.ContainsKey(code))
            {
               return _messages[code];
            }
            else
            {
               return defaultMessage;//"(E* " + code + ")";
            }
         }
      }

      /// <summary>
      /// Get a translated text according to language selected.
      /// </summary>
      /// <param name="code">Test code.</param>
      /// <param name="defaultMessage">Text returned if no dicctionary is loaded or language code is not present in dictionary.</param>
      /// <returns>An apropieted text according to language selected.</returns>
      public static string GetMessage(string code)
      {
         return Translator.GetMessage(code, string.Empty);
      }

      /// <summary>
      /// Get a translated text according to language selected.
      /// </summary>
      /// <param name="code">Test code.</param>
      /// <param name="defaultMessage">Text returned if no dicctionary is loaded or language code is not present in dictionary.</param>
      /// <returns>An apropieted text according to language selected.</returns>
      public static string GetMessage(string code, string defaultMessage, params object[] args)
      {
         return StringUtils.ReplaceTextCodes(Translator.GetMessage(code, defaultMessage), args);
      }

      public static List<string> GetLanguages()
      {
         string folderLanguages;
         string[] fileLanguages;
         List<string> languages = new List<string>();

         folderLanguages = Path.Combine(Translator.AssemblyDirectory, Translator.FOLDER_DICTIONARIES);
         fileLanguages = Directory.GetFiles(folderLanguages, "*.lng");

         foreach (string file in fileLanguages)
         {
            languages.Add(Path.GetFileNameWithoutExtension(file));
         }

         return languages;
      }

      #endregion

      #region Private Members

      private static bool LoadMessages()
      {
         string sLine = string.Empty;

         _messages = null;
         _messages = new Dictionary<string, string>();

         try
         {
            using (StreamReader objReader = new StreamReader(_fileLanguage, fileEncoding, true))
            {
               while (sLine != null)
               {
                  sLine = objReader.ReadLine();
                  if (sLine != null)
                  {
                     if (IsLineValid(sLine))
                     {
                        string key = GetKey(sLine);
                        string message = GetValue(sLine);

                        if (message.Length > 0)
                        {
                           if (!_messages.ContainsKey(key))
                           {
                              _messages.Add(key, message);
                           }
                        }
                     }
                  }
               }

               objReader.Close();
            }
         }
         catch (Exception)
         {
            MessageBox.Show("ERROR parsing dictionary file " + _fileLanguage, "Dictionary Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
         }

         return true;
      }

      private static string AssemblyDirectory
      {
         get
         {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);

            return Path.GetDirectoryName(path);
         }
      }

      private static bool IsLineValid(string line)
      {
         bool valid = false;

         valid = line.Contains("=") && (line.Substring(0, 2).CompareTo("//") != 0) && (line.Substring(0, 2).CompareTo("#") != 0);

         return valid;
      }

      private static string GetKey(string line)
      {
         string[] keyValue = line.Split('=');

         if (keyValue.Length > 0)
         {
            return keyValue[0].Trim();
         }
         else
         {
            return string.Empty;
         }
      }

      private static string GetValue(string line)
      {
         string[] keyValue = line.Split('=');

         if (keyValue.Length > 1)
         {
            return keyValue[1].Trim();
         }
         else
         {
            return string.Empty;
         }
      }

      #endregion

   }
}