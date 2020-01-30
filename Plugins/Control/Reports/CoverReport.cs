namespace Rwm.Studio.Plugins.Control.Reports
{
   public partial class CoverReport : DevExpress.XtraReports.UI.XtraReport
   {

      #region Constructors

      public CoverReport(string title)
      {
         InitializeComponent();

         lblReportTitle.Text = title;
      }

      #endregion

   }
}
