using System.Data;
using DevExpress.XtraReports.UI;
using Rwm.Otc;
using Rwm.Otc.Trains;

namespace Rwm.Studio.Plugins.Collection.Reports
{
   public partial class DigitalReport : XtraReport
   {

      #region Constructors

      public DigitalReport()
      {
         InitializeComponent();

         this.Initialize();
      }

      #endregion

      #region Properties

      internal DataSet ReportData { get; private set; }

      #endregion

      #region Event Handlers

      private void DigitalReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
      {
         this.ReportData = Train.FindAllDigitalAddresses();

         this.DataSource = ReportData;
         this.DataMember = "Trains";
      }

      #endregion

      #region Private Members

      private void Initialize()
      {
         lblProjectName.Text = OTCContext.Project.Name;

         // Data bindings
         lblTrainName.DataBindings.Add(new XRBinding("Text", null, "Trains.Name"));
         lblTrainManufacturer.DataBindings.Add(new XRBinding("Text", null, "Trains.ModelManufacturer"));
         lblDecoderModel.DataBindings.Add(new XRBinding("Text", null, "Trains.Decoder"));
         lblDecoderManufacturer.DataBindings.Add(new XRBinding("Text", null, "Trains.DecoderManufacturer"));
         lblDecoderAddress.DataBindings.Add(new XRBinding("Text", null, "Trains.Address"));
      }

      #endregion

   }
}
