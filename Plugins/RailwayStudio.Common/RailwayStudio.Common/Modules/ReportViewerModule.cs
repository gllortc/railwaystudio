using System.Drawing;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;

namespace Rwm.Studio.Plugins.Common.Modules
{
   public partial class ReportViewerModule : DevExpress.XtraBars.Ribbon.RibbonForm, IPluginModule
   {

      #region Constants

      internal const string MODULE_GUID = "BDF2AC43-7829-47F4-A3FC-BD7B4FA62A18";

      #endregion

      #region Constructors

      public ReportViewerModule()
      {
         InitializeComponent();
      }

      #endregion

      #region IPluginModule Implementation

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

      /// <summary>
      /// Add docable panels to environment.
      /// </summary>
      public void CreatePanels() { }

      /// <summary>
      /// Remove all dockable panels created when the module was loaded.
      /// </summary>
      public void DestoryPanels() { }

      #endregion

   }
}