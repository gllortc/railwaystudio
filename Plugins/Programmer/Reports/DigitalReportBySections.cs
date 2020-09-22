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
         //// Get the switchboard to obtain the image
         //Switchboard sb = Switchboard.Get(NumericUtils.ToInteger(lblSectionId.Text));
         //if (sb == null) return;

         //// Paint group switchboard
         //imgSwitchboardImage.Image = sb.GetImage();
      }

      private void DigitalConnectionsReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
      {
         int i = NumericUtils.ToInteger(lblSectionId.Text);
         DigitalConnectionsReport.DataSource = AccessoryDecoder.FindBy("SECTIONID", i);
         // DigitalConnectionsReport.DataMember = AccessoryDecoder.TableName;
      }

      #endregion

      #region Private Members

      private void Initialize()
      {
         lblProjectName.Text = OTCContext.Project.Name;

         // Data bindings
         lblSectionId.DataBindings.Add(new XRBinding("Text", null, "ID"));
         lblSectionTitle.DataBindings.Add(new XRBinding("Text", null, "Name"));

         lblDecoderName.DataBindings.Add(new XRBinding("Text", null, "AccessoryConnections.Name"));
         lblDecoderModel.DataBindings.Add(new XRBinding("Text", null, "AccessoryConnections.Decoder"));
         lblDecoderOutput.DataBindings.Add(new XRBinding("Text", null, "AccessoryConnections.DecoderInput"));
         lblDecoderAddress.DataBindings.Add(new XRBinding("Text", null, "AccessoryConnections.Address"));
         lblConnectedTo.DataBindings.Add(new XRBinding("Text", null, "AccessoryConnections.ConnectTo"));
      }

      #endregion

   }
}
