using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;

namespace Rwm.Studio.Plugins.Common.Modules
{
   public partial class ReportViewerModule : DevExpress.XtraBars.Ribbon.RibbonForm, IPluginModule
   {

      #region Constructors

      public ReportViewerModule()
      {
         InitializeComponent();

         this.Description = new ReportViewerModuleDescriptor();
      }

      #endregion

      #region IPluginModule Implementation

      /// <summary>
      /// Gets the plugin module description properties.
      /// </summary>
      public IPluginModuleDescriptor Description { get; private set; }

      public string DocumentName
      {
         get { return string.Empty; }
      }

      public bool IsMultiInstance
      {
         get { return true; }
      }

      public object StartupRibbonPage
      {
         get { return rbpReports; }
      }

      public object RibbonStatusBar
      {
         get { return ribbonStatusBar; }
      }

      public bool UseProject
      {
         get { return true; }
      }

      public void Initialize(params object[] args)
      {
         if (args == null || args.Length <= 0) return;
             
         // Transform the report into a viewable document
         if (args[0] is XtraReport)
         {
            if (!(args[0] is XtraReport doc)) return;

            // Load the transformed report
            docViewer.DocumentSource = doc;
            this.Text = doc.DisplayName;
         }
         else if (args[0] is GridControl)
         {
            StudioContext.UI.PrintPreview(args[1].ToString(), docViewer, args[0] as GridControl);
            this.Text = args[1].ToString();
         }
      }

      #endregion

   }
}