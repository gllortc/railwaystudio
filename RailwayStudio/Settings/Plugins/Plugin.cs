using System.Collections.Generic;

namespace Rwm.Studio.Settings.Plugins
{
   public class Plugin
   {

      #region Constructors

      public Plugin()
      {
         Initialize();
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
