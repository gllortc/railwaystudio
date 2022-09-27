using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class FindAddressView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public FindAddressView()
      {
         InitializeComponent();
         MapModelToView();
      }

      #endregion

      #region Event Handlers

      private void CmdAccept_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Private Members

      private void MapModelToView()
      {
         grdAddress.BeginUpdate();
         grdAddressView.OptionsBehavior.AutoPopulateColumns = false;
         grdAddress.DataSource = null;

         if (grdAddressView.Columns.Count <= 0)
         {
            grdAddressView.Columns.Clear();
            grdAddressView.OptionsBehavior.AutoPopulateColumns = false;
            grdAddressView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
            grdAddressView.Columns.Add(new GridColumn() { Caption = "Address", Visible = true, FieldName = "Address" });
            grdAddressView.Columns.Add(new GridColumn() { Caption = "Output", Visible = true, FieldName = "Index", Width = 30 });
            grdAddressView.Columns.Add(new GridColumn() { Caption = "Decoder", Visible = true, FieldName = "AccessoryDecoder.Name", Width = 30 });

            //grdAddressView.Columns["Outputs"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //grdAddressView.Columns["Outputs"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            //grdAddressView.Columns["ConnectionsCount"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //grdAddressView.Columns["ConnectionsCount"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         }

         grdAddress.DataSource = AccessoryDecoderOutput.FindAll();
         grdAddress.EndUpdate();
      }

      #endregion

   }
}
