using System;
using Rwm.Otc.TrainControl;

namespace RailwayStudio.Common.Views
{
   public partial class TrainAddressView : DevExpress.XtraEditors.XtraForm
   {
      public TrainAddressView()
      {
         InitializeComponent();
      }

      public TrainAddressView(uint address)
      {
         InitializeComponent();

         txtAddress.EditValue = address;
      }

      private void CmdClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void TxtAddress_EditValueChanged(object sender, EventArgs e)
      {
         TrainDigitalAddress address = new TrainDigitalAddress((uint)Decimal.ToInt32((decimal)txtAddress.EditValue));
         txtCv1.EditValue = address.CV1;
         txtCv17.EditValue = address.CV17;
         txtCv18.EditValue = address.CV18;
      }
   }
}
