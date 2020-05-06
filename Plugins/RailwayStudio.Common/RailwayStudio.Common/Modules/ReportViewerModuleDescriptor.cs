using System;
using System.Drawing;

namespace Rwm.Studio.Plugins.Common.Modules
{
   public class ReportViewerModuleDescriptor : IPluginModuleDescriptor
   {

      #region Constants

      internal const string MODULE_GUID = "BDF2AC43-7829-47F4-A3FC-BD7B4FA62A18";

      #endregion

      #region Properties

      public Image LargeIcon
      {
         get { return Properties.Resources.ICO_REPORT_32; }
      }

      public Image SmallIcon
      {
         get { return Properties.Resources.ICO_REPORT_16; }
      }

      public string ID
      {
         get { return MODULE_GUID; }
      }

      public string Caption
      {
         get { return "Report Viewer"; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// return the <see cref="Type"/> corresponding to the plug-in module.
      /// </summary>
      /// <returns></returns>
      public Type GetPluginModuleType()
      {
         return typeof(ReportViewerModule);
      }

      #endregion

   }
}
