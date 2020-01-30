using System.Data;
using DevExpress.XtraReports.UI;
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
         this.ReportData = Device.FindByConnection();

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

         DigitalConnectionsReport.DataSource = Device.FindBySwitchboard(i);
         DigitalConnectionsReport.DataMember = "Connections";
      }

      #endregion

      #region Private Members

      private void Initialize()
      {
         // Data bindings
         lblSwitchboardId.DataBindings.Add(new XRBinding("Text", null, "Switchboards.SwitchboardID"));
         lblSwitchboardTitle.DataBindings.Add(new XRBinding("Text", null, "Switchboards.Switchboard"));

         lblDecoderName.DataBindings.Add(new XRBinding("Text", null, "Connections.Name"));
         lblDecoderModel.DataBindings.Add(new XRBinding("Text", null, "Connections.Decoder"));
         lblDecoderOutput.DataBindings.Add(new XRBinding("Text", null, "Connections.Output"));
         lblDecoderAddress.DataBindings.Add(new XRBinding("Text", null, "Connections.Address"));
         lblConnectedTo.DataBindings.Add(new XRBinding("Text", null, "Connections.ConnectTo"));
      }

      #endregion

   }
}
