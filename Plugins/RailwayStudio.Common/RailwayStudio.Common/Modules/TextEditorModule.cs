using System.Drawing;

namespace Rwm.Studio.Plugins.Common.Modules
{
   public partial class TextEditorModule : DevExpress.XtraBars.Ribbon.RibbonForm, IPluginModule
   {

      //#region Constants

      //internal const string MODULE_GUID = "4812D1D5-C1B0-492C-8908-251E5E8922E3";

      //#endregion

      #region Constructors

      public TextEditorModule()
      {
         InitializeComponent();

         this.Description = new TextEditorModuleDescriptor();
      }

      #endregion

      #region IPluginModule Implementation

      /// <summary>
      /// Gets the plugin module description properties.
      /// </summary>
      public IPluginModuleDescriptor Description { get; private set; }

      //public string ID
      //{
      //   get { return TextEditorModule.MODULE_GUID; }
      //}

      //public Image LargeIcon
      //{
      //   get { return Properties.Resources.ICO_TEXTEDITOR_32; }
      //}

      //public Image SmallIcon
      //{
      //   get { return Properties.Resources.ICO_TEXTEDITOR_16; }
      //}

      //public string Caption
      //{
      //   get { return "Text editor"; }
      //}

      /// <summary>
      /// Gets a value indicating if the module use a project or it is an independent utility.
      /// </summary>
      public bool UseProject
      {
         get { return false; }
      }

      public string DocumentName
      {
         get { return string.Empty; }
      }

      /// <summary>
      /// Gets a value indicating if the module can be loaded multiple times.
      /// </summary>
      public bool IsMultiInstance
      {
         get { return true; }
      }

      /// <summary>
      /// Gets an instance of the startup ribbon page that must be shown when the plugin is active in studio
      /// or <c>null</c> if the default page must be shown.
      /// </summary>
      public object StartupRibbonPage
      {
         get { return homeRibbonPage1; }
      }

      public object RibbonStatusBar
      {
         get { return null; }
      }

      /// <summary>
      /// Initialize the contents of the module.
      /// </summary>
      public void Initialize(params object[] args)
      {

      }

      /// <summary>
      /// Add docable panels to environment.
      /// </summary>
      public void CreatePanels()
      {
         // Nothing to do here
      }

      /// <summary>
      /// Remove all dockable panels created when the module was loaded.
      /// </summary>
      public void DestoryPanels()
      {
         // Nothing to do
      }

      #endregion

   }
}