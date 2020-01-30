using Rwm.Otc.Configuration;
using System.Collections.Generic;

namespace RailwayStudio.Common
{
   public class Plugin
   {

      #region Constructors

      private const string SETTING_KEY_FILE = "assembly-file";

      #endregion

      #region Constructors

      /// <summary>
      /// returns a new instance of <see cref="Plugin"/>.
      /// </summary>
      public Plugin()
      {
         this.Initialize();
      }

      /// <summary>
      /// returns a new instance of <see cref="Plugin"/>.
      /// </summary>
      /// <param name="node">An instance of <see cref="XmlSettingsItem"/> containing all plugin settings.</param>
      public Plugin(XmlSettingsItem node)
      {
         this.Initialize();

         this.ID = node.Key;
         this.Name = node.Value;
         this.File = node.GetString(Plugin.SETTING_KEY_FILE);
      }

      #endregion

      #region Properties

      public string ID { get; set; }

      public string Name { get; set; }

      public string File { get; set; }

      public List<PluginModule> Modules { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Return a string that represents the instance.
      /// </summary>
      public override string ToString()
      {
         return string.Format("Plugin: {0}", this.Name);
      }

      #endregion

      #region Private Members

      private void Initialize()
      {
         this.ID = string.Empty;
         this.Name = string.Empty;
         this.File = string.Empty;
         this.Modules = new List<PluginModule>();
      }

      #endregion

   }
}
