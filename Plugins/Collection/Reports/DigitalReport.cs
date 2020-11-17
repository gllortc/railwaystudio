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

      #region Event Handlers

      private void DigitalReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
      {
         System.Collections.Generic.ICollection<Train> data = Train.FindByQuery("moddigitaladd > 0");
         this.DataSource = data;

         Detail.SortFields.Add(new GroupField("Name"));
      }

      #endregion

      #region Private Members

      private void Initialize()
      {
         lblProjectName.Text = OTCContext.Project.Name;
         lblProjectCompany.Text = OTCContext.Project.CompanyName;
         picProjectCompanyLogo.Image = OTCContext.Project.CompanyLogo;

         // Data bindings
         lblTrainName.DataBindings.Add(new XRBinding("Text", null, "Name"));
         lblTrainManufacturer.DataBindings.Add(new XRBinding("Text", null, "Manufacturer.Name"));
         lblDecoderModel.DataBindings.Add(new XRBinding("Text", null, "DigitalDecoder.DisplayName"));
         lblDecoderAddress.DataBindings.Add(new XRBinding("Text", null, "DisplayDigitalAddress"));
         picTrainImage.DataBindings.Add(new XRBinding("Image", null, "Picture"));
      }

      #endregion

      
   }
}
