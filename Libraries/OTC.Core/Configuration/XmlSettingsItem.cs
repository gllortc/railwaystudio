using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Rwm.Otc.Configuration
{
   public class XmlSettingsItem : IXmlSettingsItem
   {

      #region Constructors

      public XmlSettingsItem()
      {
         Initialize();
      }

      public XmlSettingsItem(string key, string value)
      {
         Initialize();

         this.Key = key;
         this.Value = value;
      }

      public XmlSettingsItem(XmlElement node)
      {
         XmlSettingsItem subitem;

         Initialize();

         this.Key = node.GetAttribute("key");
         this.Value = node.GetAttribute("value");

         if (node.SelectNodes("Value").Count > 0)
         {
            this.Items = new Dictionary<string, XmlSettingsItem>();
            foreach (XmlNode xnode in node.SelectNodes("Value"))
            {
               subitem = new XmlSettingsItem((XmlElement)xnode);
               this.Items.Add(subitem.Key, subitem);
            }
         }
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the unique key for the item.
      /// </summary>
      public string Key { get; set; }

      /// <summary>
      /// Gets or sets the value of the item.
      /// </summary>
      public string Value { get; set; }

      /// <summary>
      /// Gets or sets the list of subitems contained in the item.
      /// </summary>
      public Dictionary<string, XmlSettingsItem> Items { get; set; }

      #endregion

      #region Methods

      public void AddSetting(string key, string value)
      {
         AddSetting(new XmlSettingsItem(key, value));
      }

      public void AddSetting(string key, int value)
      {
         AddSetting(new XmlSettingsItem(key, value.ToString()));
      }

      public void AddSetting(string key, long value)
      {
         AddSetting(new XmlSettingsItem(key, value.ToString()));
      }

      public void AddSetting(string key, bool value)
      {
         AddSetting(new XmlSettingsItem(key, value ? "1" : "0"));
      }

      public void AddSetting(XmlSettingsItem value)
      {
         if (this.Items == null)
         {
            this.Items = new Dictionary<string, XmlSettingsItem>();
         }

         if (this.Items.ContainsKey(value.Key))
         {
            this.Items.Remove(value.Key);
         }

         this.Items.Add(value.Key, value);
      }

      public XmlSettingsItem GetItem(string key)
      {
         if (this.Items == null)
         {
            return null;
         }
         else if (!this.Items.ContainsKey(key))
         {
            return null;
         }

         return this.Items[key];
      }

      public string GetString(string key)
      {
         return GetString(key, string.Empty);
      }

      public string GetString(string key, string defaultValue)
      {
         if (this.Items == null)
         {
            return defaultValue;
         }
         else if (!this.Items.ContainsKey(key))
         {
            return defaultValue;
         }

         return this.Items[key].Value;
      }

      public bool GetBoolean(string key)
      {
         return GetBoolean(key, false);
      }

      public bool GetBoolean(string key, bool defaultValue)
      {
         string value = string.Empty;

         value = this.GetString(key, defaultValue.ToString()).Trim().ToLower();

         return (value.Equals("true") || value.Equals("t") || value.Equals("1"));
      }

      public int GetInteger(string key)
      {
         return GetInteger(key, 0);
      }

      public int GetInteger(string key, int defaultValue)
      {
         int value = 0;

         if (int.TryParse(GetString(key), out value))
         {
            return value;
         }
         else
         {
            return defaultValue;
         }
      }

      public void Remove(string key)
      {
         if (this.Items == null)
         {
            return;
         }

         if (this.Items.ContainsKey(key))
         {
            this.Items.Remove(key);
         }
      }

      public bool ContainsKey(string itemKey)
      {
         return this.Items.ContainsKey(itemKey);
      }

      public void WriteToXml(XmlWriter writer)
      {
         writer.WriteStartElement("Value");
         writer.WriteAttributeString("key", this.Key);
         writer.WriteAttributeString("value", this.Value);

         if (this.Items != null && this.Items.Values.Count > 0)
         {
            foreach (XmlSettingsItem subitem in this.Items.Values)
            {
               subitem.WriteToXml(writer);
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
         this.Key = string.Empty;
         this.Value = string.Empty;
         this.Items = new Dictionary<string, XmlSettingsItem>();
      }

      #endregion

   }
}
