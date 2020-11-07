using System.Data;
using DevExpress.XtraReports.UI;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.Utils;

namespace Rwm.Studio.Plugins.Designer.Reports
{
   public partial class DigitalReportBySections : XtraReport
   {

      #region Constructors

      public DigitalReportBySections()
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
         // this.ReportData = AccessoryDecoder.FindByConnection();

         this.DataSource = Section.FindAll();
         // this.DataMember = Section.TableName;
      }

      private void ImgSwitchboardImage_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
      {
         // Get the switchboard to obtain the image
         Section sb = Section.Get(NumericUtils.ToInteger(lblShemaId.Text));
         if (sb == null) return;

         // Paint section schema
         imgSchemaImage.Image = sb.Picture;
      }

      private void DigitalConnectionsReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
      {
         int i = NumericUtils.ToInteger(lblShemaId.Text);
         DigitalConnectionsReport.DataSource = AccessoryDecoder.FindBy("Section", i);
         // DigitalConnectionsReport.DataMember = AccessoryDecoder.TableName;
      }

      #endregion

      #region Private Members

      private void Initialize()
      {
         // Data bindings
         lblShemaId.DataBindings.Add(new XRBinding("Text", null, "ID"));
         lblSectionTitle.DataBindings.Add(new XRBinding("Text", null, "Name"));
         lblAddRangeStart.DataBindings.Add(new XRBinding("Text", null, "AccessoryStartAddress"));
         lblAddRangeEnd.DataBindings.Add(new XRBinding("Text", null, "AccessoryEndAddress"));
         lblFbRangeStart.DataBindings.Add(new XRBinding("Text", null, "FeedbackStartAddress"));
         lblFbRangeEnd.DataBindings.Add(new XRBinding("Text", null, "FeedbackEndAddress"));

         lblDecoderName.DataBindings.Add(new XRBinding("Text", null, "AccessoryConnections.Name"));
         lblDecoderModel.DataBindings.Add(new XRBinding("Text", null, "AccessoryConnections.Decoder"));
         lblDecoderOutput.DataBindings.Add(new XRBinding("Text", null, "AccessoryConnections.DecoderInput"));
         lblDecoderAddress.DataBindings.Add(new XRBinding("Text", null, "AccessoryConnections.Address"));
         lblConnectedTo.DataBindings.Add(new XRBinding("Text", null, "AccessoryConnections.ConnectTo"));
      }

      #endregion

   }
}
