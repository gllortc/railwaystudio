namespace RailwayStudio.Common
{
   public interface IPluginPackage
   {

      /// <summary>
      /// Gets a unique plugin identifier (usually a GUID code).
      /// </summary>
      string ID { get; }

      /// <summary>
      /// Gets the name of the plugin package.
      /// </summary>
      string Name { get; }

      /// <summary>
      /// Gets the version of the plugin package.
      /// </summary>
      string Version { get; }

      /// <summary>
      /// Gets the description of the plugin package.
      /// </summary>
      string Description { get; }

      /// <summary>
      /// Gets the large icon image of the plugin package (32x32).
      /// </summary>
      System.Drawing.Image LargeIcon { get; }

      /// <summary>
      /// Gets the small icon image of the plugin package (16x16).
      /// </summary>
      System.Drawing.Image SmallIcon { get; }

   }
}
