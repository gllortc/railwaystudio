namespace Rwm.Studio.Plugins.Common.Reports
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
