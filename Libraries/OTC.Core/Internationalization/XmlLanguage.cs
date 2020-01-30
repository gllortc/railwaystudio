using System.Collections.Generic;
using System.Xml;

namespace Emdep.Core.Internationalization
{
   public class XmlLanguage
   {

      public XmlLanguage(XmlElement languageNode)
      {
         Load(languageNode);
      }

      public XmlLanguage(string code, string name)
      {
         this.Text = new Dictionary<string, string>();
         this.LanguageCode = code;
         this.Name = name;
      }

      public string LanguageCode { get; set; }

      public string Name { get; set; }

      public Dictionary<string, string> Text { get; private set; }

      private void Load(XmlElement languageNode)
      {
         this.Text = new Dictionary<string, string>();

         this.LanguageCode = languageNode.Attributes["code"].Value;
         this.Name = languageNode.Attributes["name"].Value;

         foreach (XmlElement exp in languageNode.GetElementsByTagName("exp"))
         {
            if (!this.Text.ContainsKey(exp.GetAttribute("key")))
            {
               this.Text.Add(exp.GetAttribute("key"), exp.GetAttribute("value"));
            }
            else
            {
               this.Text[exp.GetAttribute("key")] = exp.GetAttribute("value");
            }
         }
      }

   }
}
