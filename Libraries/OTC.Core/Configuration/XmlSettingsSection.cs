using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Rwm.Otc.Configuration
{
   public class XmlSettingsSection : IXmlSettingsItem
   {

      #region Constructors

      public XmlSettingsSection()
      {
         Initialize();
      }

      public XmlSettingsSection(XmlElement node)
      {
         Initialize();

         // Read section atributes
         this.Key = node.GetAttribute("key");
         this.Value = node.GetAttribute("value");

         // Read all items
         foreach (XmlNode xmlItem in node.SelectNodes("Value"))
         {
            AddSetting(new XmlSettingsItem((XmlElement)xmlItem));
         }

         // Read all sections
         foreach (XmlNode xmlSection in node.SelectNodes("Section"))
         {
            AddSetting(new XmlSettingsSection((XmlElement)xmlSection));
         }
      }

      #endregion

      #region Properties

      public string Key { get; set; }

      public string Value { get; set; }

      public  Dictionary<string, IXmlSettingsItem> Values { get; internal set; }

      /// <summary>
      /// Gets the number of settings values, including sections.
      /// </summary>
      public int Count
      {
         get
         {
            if (this.Values == null)
            {
               return 0;
            }

            return this.Values.Count;
         }
      }

      #endregion

      #region Merhods

      public void AddSetting(IXmlSettingsItem value)
      {
         if (this.Values == null)
         {
            this.Values = new Dictionary<string, IXmlSettingsItem>();
         }

         if (this.Values.ContainsKey(value.Key))
         {
            this.Values.Remove(value.Key);
         }

         this.Values.Add(value.Key, value);
      }

      public void AddSetting(XmlSettingsSection section)
      {
         if (this.Values == null)
         {
            this.Values = new Dictionary<string, IXmlSettingsItem>();
         }

         if (this.Values.ContainsKey(section.Key))
         {
            this.Values.Remove(section.Key);
         }

         this.Values.Add(section.Key, (IXmlSettingsItem)section);
      }

      public void AddSetting(string key, string value)
      {
         XmlSettingsItem item = new XmlSettingsItem(key, value);
         AddSetting(item);
      }

      public void AddSetting(string key, int value)
      {
         XmlSettingsItem item = new XmlSettingsItem(key, value.ToString());
         AddSetting(item);
      }

      public void AddSetting(string key, long value)
      {
         XmlSettingsItem item = new XmlSettingsItem(key, value.ToString());
         AddSetting(item);
      }

      public void AddSetting(string key, bool value)
      {
         XmlSettingsItem item = new XmlSettingsItem(key, value ? "1" : "0");
         AddSetting(item);
      }

      public XmlSettingsSection GetSection(string key)
      {
         if (this.Values == null)
         {
            return null;
         }
         else if (!this.Values.ContainsKey(key))
         {
            return null;
         }

         return this.Values[key] as XmlSettingsSection;
      }

      public string GetString(string key)
      {
         return GetString(key, string.Empty);
      }

      public string GetString(string key, string defaultValue)
      {
         if (this.Values == null)
         {
            return defaultValue;
         }
         else if (!this.Values.ContainsKey(key))
         {
            return defaultValue;
         }

         XmlSettingsItem item = this.Values[key] as XmlSettingsItem;

         return (item != null ? item.Value : defaultValue);
      }

      public void WriteToXml(XmlWriter writer)
      {
         writer.WriteStartElement("Section");
         writer.WriteAttributeString("key", this.Key);
         writer.WriteAttributeString("Value", this.Value);

         if (this.Values != null)
         {
            foreach (IXmlSettingsItem item in this.Values.Values)
            {
               item.WriteToXml(writer);
            }
         }

         writer.WriteEndElement();
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initializes the instance data.
      /// </summary>
      private void Initialize()
      {
         this.Values = null;
      }

      #endregion

   }
}
