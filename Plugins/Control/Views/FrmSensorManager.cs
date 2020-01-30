using Rwm.Otc.Configuration;
using Rwm.Otc.LayoutControl;
using Rwm.Studio.Plugins.Control.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class FrmSensorManager : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public FrmSensorManager(XmlSettingsManager settings)
      {
         InitializeComponent();

         this.Settings = settings;
         this.Manager = new SensorModuleManager(this.Settings);

         ListDecoders();
      }

      #endregion

      #region Properties

      internal XmlSettingsManager Settings { get; private set; }

      internal SensorModuleManager Manager { get; private set; }

      #endregion

      #region Event Handlers

      private void grdDecodersView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         Graphics.DrawRowIcon(global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_MODULE_16, e);
      }

      private void cmdDecoderAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         FrmSensorEditor form = new FrmSensorEditor(this.Settings);
         form.ShowDialog(this);

         if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
         {
            ListDecoders();
         }
      }

      private void cmdDecoderEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdModulesView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the object you want to edit.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         DataRowView rowView = grdModulesView.GetRow(grdModulesView.GetSelectedRows()[0]) as DataRowView;
         if (rowView == null)
         {
            return;
         }

         SensorModule decoder = this.Manager.GetByID((Int64)rowView[0]);
         if (decoder == null)
         {
            return;
         }

         FrmSensorEditor form = new FrmSensorEditor(this.Settings, decoder);
         form.ShowDialog(this);

         if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
         {
            ListDecoders();
         }
      }

      private void cmdDecoderDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdModulesView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the object you want to delete.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         DataRowView rowView = grdModulesView.GetRow(grdModulesView.GetSelectedRows()[0]) as DataRowView;
         if (rowView == null)
         {
            return;
         }

         if (MessageBox.Show("Are you sure you want to delete the decoder " + (string)rowView[1] + " and all its related data and configurations?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
         {
            return;
         }

         try
         {
            this.Manager.Delete((Int64)rowView[0]);

            ListDecoders();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      #endregion

      #region Private Members

      private void ListDecoders()
      {
         try
         {
            grdModules.BeginUpdate();
            grdModules.DataSource = this.Manager.GetAllAsDataTable();
            grdModulesView.Columns[0].Visible = false;
            grdModules.EndUpdate();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      #endregion

   }
}