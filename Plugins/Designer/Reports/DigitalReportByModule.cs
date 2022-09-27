using System.Data;
using System.Linq;
using DevExpress.XtraReports.UI;
using Rwm.Otc.Layout;
using Rwm.Otc.Utils;

namespace Rwm.Studio.Plugins.Designer.Reports
{
   public partial class DigitalReportByModule : XtraReport
   {

      #region Constructors

      public DigitalReportByModule()
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

         this.DataSource = Module.FindAll().OrderBy(o => o.Name).ToList();
         // this.DataMember = Section.TableName;
      }

      private void AccessoryConnectionsReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
      {
         // Accessory decoders report data bindings
         int moduleId = NumericUtils.ToInteger(lblModuleId.Text);
         System.Collections.Generic.ICollection<AccessoryDecoderOutput> data = AccessoryDecoderOutput.FindByModule(moduleId);
         AccessoryConnectionsReport.DataSource = data;

         // Hide the accessory decodres section when no data is present
         AccessoryConnectionGroupHeader.Visible = (data.Count > 0);
         AccessoryConnectionsDetail.Visible = (data.Count > 0);
      }

      private void FeedbackConnectionsReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
      {
         // Accessory decoders report data bindings
         int moduleId = NumericUtils.ToInteger(lblModuleId.Text);
         System.Collections.Generic.ICollection<FeedbackEncoderInput> data = FeedbackEncoderInput.FindByModule(moduleId);
         FeedbackConnectionsReport.DataSource = data;

         // Hide the feedback encoders section when no data is present
         FeedbackConnectionsGroupHeader.Visible = (data.Count > 0);
         FeedbackConnectionsDetail.Visible = (data.Count > 0);
      }

      #endregion

      #region Private Members

      private void Initialize()
      {
         picProjectLogo.Image = Otc.OTCContext.Project.CompanyLogo;
         lblProjectCompany.Text = Otc.OTCContext.Project.CompanyName;

         // Data grouping settings
         AccessoryConnectionGroupHeader.GroupFields.Add(new GroupField("AccessoryDecoder.ID"));
         FeedbackConnectionsGroupHeader.GroupFields.Add(new GroupField("FeedbackEncoder.ID"));

         // Data bindings for module
         lblModuleId.DataBindings.Add(new XRBinding("Text", null, "ID"));
         lblModuleName.DataBindings.Add(new XRBinding("Text", null, "Name"));
         imgSchemaImage.DataBindings.Add(new XRBinding("Image", null, "Picture"));
         lblModuleAccRange.DataBindings.Add(new XRBinding("Text", null, "AccessoryAddressRange"));
         lblModuleFbRange.DataBindings.Add(new XRBinding("Text", null, "FeedbackAddressRange"));
         chkModulePowerBus.DataBindings.Add(new XRBinding("Checked", null, "ConnectedToPowerBus"));
         chkModuleSystemBus.DataBindings.Add(new XRBinding("Checked", null, "ConnectedToControlBus"));
         chkModuleCommandBus.DataBindings.Add(new XRBinding("Checked", null, "ConnectedToCommandBus"));

         // Data bindings for accessory decoder
         lblDecoderName.DataBindings.Add(new XRBinding("Text", null, "AccessoryDecoder.Name"));
         lblDecoderModel.DataBindings.Add(new XRBinding("Text", null, "AccessoryDecoder.ModelDescription"));

         // Data bindings for accessory decoder outputs
         lblOutputIndex.DataBindings.Add(new XRBinding("Text", null, "Index"));
         lblOutputAddress.DataBindings.Add(new XRBinding("Text", null, "DisplayAddress"));
         lblOutputConnection.DataBindings.Add(new XRBinding("Text", null, "AccessoryConnection.Element.DisplayName"));
         lblOutputSetup.DataBindings.Add(new XRBinding("Text", null, "DisplayConfiguration"));

         // Data bindings for feedback encoders
         lblEncoderName.DataBindings.Add(new XRBinding("Text", null, "FeedbackEncoder.Name"));
         lblEncoderModel.DataBindings.Add(new XRBinding("Text", null, "FeedbackEncoder.ModelDescription"));

         // Data bindings for feedback encoder inputs
         lblEncoderInputIndex.DataBindings.Add(new XRBinding("Text", null, "Index"));
         lblEncoderInputAddress.DataBindings.Add(new XRBinding("Text", null, "DisplayAddress"));
         lblEncoderInputGroup.DataBindings.Add(new XRBinding("Text", null, "PointAddress"));
         lblEncoderInputConnection.DataBindings.Add(new XRBinding("Text", null, "FeedbackConnection.Element.DisplayName"));
         // lblOutputSetup.DataBindings.Add(new XRBinding("Text", null, "DisplayConfiguration"));
      }

      #endregion

   }
}
