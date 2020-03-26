using System;
using System.Collections.Generic;
using System.Reflection;
using Rwm.Otc.Utils;

namespace RailwayStudio.Common
{
   public abstract class PluginPackageBase : IPluginPackage
   {

      #region Properties

      /// <summary>
      /// Gets a unique plugin identifier (usually a GUID code).
      /// </summary>
      public abstract string ID { get; }

      /// <summary>
      /// Gets the name of the plugin package.
      /// </summary>
      public abstract string Name { get; }

      /// <summary>
      /// Gets the version of the plugin package.
      /// </summary>
      public string Version
      {
         get { return ReflectionUtils.GetAssemblyVersion(this.GetType()); }
      }

      /// <summary>
      /// Gets the description of the plugin package.
      /// </summary>
      public virtual string Description 
      {
         get { return string.Empty; } 
      }

      /// <summary>
      /// Gets the large icon image of the plugin package (32x32).
      /// </summary>
      public virtual System.Drawing.Image LargeIcon 
      {
         get { return Properties.Resources.ICO_PLUGIN_32; } 
      }

      /// <summary>
      /// Gets the small icon image of the plugin package (16x16).
      /// </summary>
      public virtual System.Drawing.Image SmallIcon
      {
         get { return Properties.Resources.ICO_PLUGIN_16; }
      }

      /// <summary>
      /// Gets the list of package plugin instances.
      /// </summary>
      public List<IPluginModule> Modules { get; private set; } = new List<IPluginModule>();

      #endregion

      #region Methods

      /// <summary>
      /// Load all module instances in the <see cref="Modules"/> list.
      /// </summary>
      /// <param name="ownerType">Any type owned by the package.</param>
      public void LoadModules(Type ownerType)
      {
         // Get all modules
         foreach (Type type in ownerType.Assembly.GetExportedTypes())
         {
            if (typeof(IPluginModule).IsAssignableFrom(type))
            {
               IPluginModule module = Activator.CreateInstance(type) as IPluginModule;
               this.Modules.Add(module);
            }
         }
      }

      #endregion

      #region Static Members

      public static IPluginPackage LoadFromFile(string path)
      {
         Assembly lib = Assembly.LoadFile(path);
         foreach (Type type in lib.GetExportedTypes())
         {
            if (typeof(IPluginPackage).IsAssignableFrom(type))
            {
               return Activator.CreateInstance(type) as IPluginPackage;
            }
         }

         return null;
      }

      #endregion

   }
}
