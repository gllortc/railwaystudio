using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;

namespace Rwm.Studio.Plugins.Common.Modules
{
   public partial class ReportViewerModule
   {

      internal void OpenReport(object report, string documentName = "")
      {
         if (report == null) return;

         // Transform the report into a viewable document
         if (report is XtraReport)
         {
            // Load the transformed report
            docViewer.DocumentSource = report as XtraReport;
            this.Text = ((XtraReport)report).DisplayName;
         }
         else if (report is GridControl)
         {
            StudioContext.UI.PrintPreview(documentName, docViewer, report as GridControl);
            this.Text = documentName;
         }
      }

   }
}
