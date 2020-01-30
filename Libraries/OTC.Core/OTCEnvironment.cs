using System.Reflection;

namespace Rwm.OTC
{
   /// <summary>
   /// Implementa una classe para el acceso a las propiedades del ensamblado.
   /// </summary>
   /// <remarks>
   /// Esta clasepretende reemplazar la clase System.Windows.Forms.Application.
   /// </remarks>
   public static class OTCEnvironment
   {
      /// <summary>Settings key to store the systems configurations.</summary>
      public const string SETTINGS_KEY_SYSTEMS = "otc.systems";

      private const string OTC_ROOT_FOLDER = "otc";
      private const string OTC_SYSTEMS_FOLDER = "systems";
      private const string OTC_LIBRARIES_FOLDER = "panels";

      

      static System.Diagnostics.FileVersionInfo fvi;
      static System.Reflection.Assembly assembly;
      static AssemblyName an;

      #region Static Members

      

      #endregion

   }
}
