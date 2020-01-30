namespace Rwm.Studio.Settings.Plugins
{
   public class PluginModule
   {

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="PluginModule"/>.
      /// </summary>
      public PluginModule() { }

      /// <summary>
      /// Gets a new instance of <see cref="PluginModule"/>.
      /// </summary>
      /// <param name="id"></param>
      /// <param name="name"></param>
      /// <param name="className"></param>
      public PluginModule(string id, string name, string className)
      {
         this.ID = id;
         this.Name = name;
         this.Class = className;
      }

      #endregion

      #region Properties

      public string ID { get; set; }

      public string Name { get; set; }

      public string Filename { get; set; }

      public string Class { get; set; }

      #endregion

   }
}
