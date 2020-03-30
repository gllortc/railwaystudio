using Rwm.Otc.Utils;

namespace Rwm.Studio.Plugins.Common
{
   public class PluginData : PluginPackageBase
   {

      #region Constants

      private const string PLUGIN_GUID = "8A5F16F6-3676-4EB0-AEC3-1ED8A6C2C142";

      #endregion

      #region Properties

      public override string ID
      {
         get { return PLUGIN_GUID; }
      }

      public override string Name
      {
         get { return ReflectionUtils.GetAssemblyInfo(this.GetType()).ProductName; }
      }

      public override string Description
      {
         get { return ReflectionUtils.GetAssemblyInfo(this.GetType()).Comments; }
      }

      #endregion

   }
}
