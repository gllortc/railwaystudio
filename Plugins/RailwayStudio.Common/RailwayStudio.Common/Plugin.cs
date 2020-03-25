using Rwm.Otc.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace RailwayStudio.Common
{
   public class Plugin
   {

      #region Constants

      private const string SETTING_KEY_FILE = "assembly-file";

      #endregion

      #region Constructors

      /// <summary>
      /// returns a new instance of <see cref="Plugin"/>.
      /// </summary>
      public Plugin() { }

      /// <summary>
      /// returns a new instance of <see cref="Plugin"/>.
      /// </summary>
      /// <param name="node">An instance of <see cref="XmlSettingsItem"/> containing all plugin settings.</param>
      public Plugin(XmlSettingsItem node)
      {
         this.ID = node.Key;
         this.Name = node.Value;

         this.SetAssemblyFile(node.GetString(Plugin.SETTING_KEY_FILE));
      }

      #endregion

      #region Properties

      public string ID { get; set; } = string.Empty;

      public string Name { get; set; } = string.Empty;

      public string File { get; private set; } = string.Empty;

      public IPluginPackage PackageInfo { get; private set; } = null;

      public List<PluginModule> Modules { get; set; } = new List<PluginModule>();

      #endregion

      #region Methods

      public void SetAssemblyFile(string path)
      {
         this.File = path;

         Assembly lib = Assembly.LoadFile(this.File);
         foreach (Type type in lib.GetExportedTypes())
         {
            if (typeof(IPluginPackage).IsAssignableFrom(type))
            {
               this.PackageInfo = Activator.CreateInstance(type) as IPluginPackage;
               break;
            }
         }
      }

      /// <summary>
      /// Return a string that represents the instance.
      /// </summary>
      public override string ToString()
      {
         return string.Format("Plugin: {0}", this.Name);
      }

      #endregion

   }
}
