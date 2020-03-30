using System.Data;
using DevExpress.XtraReports.UI;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.Utils;

namespace Rwm.Studio.Plugins.Control.Reports
{
   public partial class DigitalReport : DevExpress.XtraReports.UI.XtraReport
   {
      public DigitalReport()
      {
         InitializeComponent();

         this.Initialize();
      }

      #region Properties

      internal DataSet ReportData { get; private set; }

      #endregion

      #region Event Handlers

      private void DigitalReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
      {
         this.ReportData = AccessoryDecoder.FindByConnection();

         this.DataSource = ReportData;
         this.DataMember = "Switchboards";
      }

      private void imgSwitchboardImage_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
      {
         // Get the switchboard to obtain the image
         Switchboard sb = Switchboard.Get(NumericUtils.ToInteger(lblSwitchboardId.Text));
         if (sb == null) return;

         // Paint group switchboard
         imgSwitchboardImage.Image = sb.GetImage();
      }

      private void DigitalConnectionsReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
      {
         int i = NumericUtils.ToInteger(lblSwitchboardId.Text);

         // DigitalConnectionsGroup.GroupFields.Add(new GroupField("Name"));

         DigitalConnectionsReport.DataSource = AccessoryDecoder.FindBySwitchboard(i);
         DigitalConnectionsReport.DataMember = "AccessoryConnections";
      }

      #endregion

      #region Private Members

      private void Initialize()
      {
         lblProjectName.Text = OTCContext.Project.Name;

         // Data bindings
         lblSwitchboardId.DataBindings.Add(new XRBinding("Text", null, "Switchboards.SwitchboardID"));
         lblSwitchboardTitle.DataBindings.Add(new XRBinding("Text", null, "Switchboards.Switchboard"));

         lblDecoderName.DataBindings.Add(new XRBinding("Text", null, "AccessoryConnections.Name"));
         lblDecoderModel.DataBindings.Add(new XRBinding("Text", null, "AccessoryConnections.Decoder"));
         lblDecoderOutput.DataBindings.Add(new XRBinding("Text", null, "AccessoryConnections.DecoderInput"));
         lblDecoderAddress.DataBindings.Add(new XRBinding("Text", null, "AccessoryConnections.Address"));
         lblConnectedTo.DataBindings.Add(new XRBinding("Text", null, "AccessoryConnections.ConnectTo"));
      }

      #endregion

   }
}
