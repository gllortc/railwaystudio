using System;
using System.Drawing;

namespace Rwm.Studio.Plugins.Common.Modules
{
   public class TextEditorModuleDescriptor : IPluginModuleDescriptor
   {

      #region Constants

      internal const string MODULE_GUID = "4812D1D5-C1B0-492C-8908-251E5E8922E3";

      #endregion

      #region Properties

      public string ID
      {
         get { return MODULE_GUID; }
      }

      public Image LargeIcon
      {
         get { return Properties.Resources.ICO_TEXTEDITOR_32; }
      }

      public Image SmallIcon
      {
         get { return Properties.Resources.ICO_TEXTEDITOR_16; }
      }

      public string Caption
      {
         get { return "Text editor"; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// return the <see cref="Type"/> corresponding to the plug-in module.
      /// </summary>
      /// <returns></returns>
      public Type GetPluginModuleType()
      {
         return typeof(TextEditorModule);
      }

      #endregion

   }
}
