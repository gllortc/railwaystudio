using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Rwm.Otc.Configuration
{
   public class XmlSettingsManager : XmlSettingsItem
   {

      /// <summary>Default name for settings file.</summary>
      private const string FILE_NAME = "settings.xml";

      /// <summary>XML settings version used by this assembly.</summary>
      public const string SETTINGS_FORMAT_VERSION = "1.0";

      #region Properties

      /// <summary>
      /// Gets the filename and path where the settings are stored.
      /// </summary>
      public string Filename { get; private set; } = string.Empty;

      #endregion

      #region Constructors

      public XmlSettingsManager() { }

      #endregion

      #region Methods

      public void LoadSettings()
      {
         LoadSettings(Path.Combine(GetAssemblyPath(), FILE_NAME));
      }

      public void LoadSettings(string fileName)
      {
         if (!File.Exists(fileName))
         {
            return;
         }

         try
         {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            if (doc.GetElementsByTagName("OTCSettings").Count != 1)
            {
               throw new XmlSettingsParseError("A unique Settings root node is required.");
            }

            // Read all items
            foreach (XmlNode xmlItem in doc.SelectNodes("OTCSettings/Value")) // .GetElementsByTagName("Value", "OTCSettings"))
            {
               this.AddSetting(new XmlSettingsItem((XmlElement)xmlItem));
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      /// <summary>
      /// Save the settings into a XML file.
      /// </summary>
      /// <remarks>
      /// Use the default file name stored into the constant <see cref="FILE_NAME"/> and the assembly path.
      /// </remarks>
      public void SaveSettings()
      {
         this.SaveSettings(Path.Combine(GetAssemblyPath(), FILE_NAME));
      }

      /// <summary>
      /// Save the settings into a XML file.
      /// </summary>
      /// <param name="fileName">Filename and path.</param>
      public void SaveSettings(string fileName)
      {
         if (this.Items == null)
         {
            this.Items = new Dictionary<string, XmlSettingsItem>();
         }

         try
         {
            this.Filename = fileName;

            XmlWriterSettings settings = new XmlWriterSettings
            {
               Indent = true,
               IndentChars = " ",
               NewLineChars = Environment.NewLine,
               NewLineHandling = NewLineHandling.Replace
            };

            using (XmlWriter writer = XmlWriter.Create(fileName, settings))
            {
               writer.WriteStartDocument();
               writer.WriteStartElement("OTCSettings");
               writer.WriteAttributeString("version", XmlSettingsManager.SETTINGS_FORMAT_VERSION);

               foreach (IXmlSettingsItem item in this.Items.Values)
               {
                  item.WriteToXml(writer);
               }

               writer.WriteEndElement();
               writer.WriteEndDocument();
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      #endregion

      #region Private Members

      private string GetAssemblyPath()
      {
         string codeBase = Assembly.GetExecutingAssembly().CodeBase;
         UriBuilder uri = new UriBuilder(codeBase);
         string path = Uri.UnescapeDataString(uri.Path);

         return Path.GetDirectoryName(path);
      }

      #endregion

   }
}
