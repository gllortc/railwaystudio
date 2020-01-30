using DevExpress.XtraGrid.Views.Grid;
using RailwayStudio.Common;
using Rwm.Otc;
using Rwm.Otc.Layout;
using System;
using System.Data;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class FrmModuleSelector : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public FrmModuleSelector(Device.DeviceType type)
      {
         InitializeComponent();

         this.SelectedModule = null;
         this.Type = type;

         switch (type)
         {
            case Device.DeviceType.SensorModule:
               this.CurrentGridView = grdSensorView;
               ListSensorModules();
               break;

            default:
               this.CurrentGridView = grdAccessoryView;
               ListAccessoryModules();
               break;
         }
      }

      #endregion

      #region Properties

      public Device SelectedModule { get; private set; }

      internal Device.DeviceType Type { get; private set; }

      private GridView CurrentGridView { get; set; }

      #endregion

      #region Event Handlers

      private void grdAccessoryView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_MODULE_16, e);
      }

      private void grdSensorView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_MODULE_16, e);
      }

      private void grdAccessoryView_RowClick(object sender, RowClickEventArgs e)
      {
         if (e.Clicks == 2)
         {
            this.EditAccessoryModule();
         }
      }

      private void grdSensorView_RowClick(object sender, RowClickEventArgs e)
      {
         if (e.Clicks == 2)
         {
            this.EditSensorModule();
         }
      }

      private void cmdModuleAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (tabModules.SelectedTabPage == tabModulesAccessories)
         {
            this.AddAccessoryModule();
         }
         else if (tabModules.SelectedTabPage == tabModulesSensors)
         {
            this.AddSensorModule();
         }
      }

      private void cmdModuleEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (tabModules.SelectedTabPage == tabModulesAccessories)
         {
            this.EditAccessoryModule();
         }
         else if (tabModules.SelectedTabPage == tabModulesSensors)
         {
            this.EditSensorModule();
         }
      }

      private void cmdModuleDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (tabModules.SelectedTabPage == tabModulesAccessories)
         {
            this.DeleteAccessoryModule();
         }
         else if (tabModules.SelectedTabPage == tabModulesSensors)
         {
            this.DeleteSensorModule();
         }
      }

      private void cmdSelect_Click(object sender, EventArgs e)
      {
         if (this.CurrentGridView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select a module.", 
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         DataRowView drv = this.CurrentGridView.GetRow(this.CurrentGridView.GetSelectedRows()[0]) as DataRowView;
         if (drv != null)
         {
            this.SelectedModule = OTCContext.Project.SensorModules.Get((int)drv[0]);

            this.DialogResult = DialogResult.OK;
            this.Close();
         }
      }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Static Members

      public static Device SelectModule(IWin32Window owner, Device.DeviceType type)
      {
         FrmModuleSelector form = new FrmModuleSelector(type);
         form.ShowDialog(owner);

         if (form.DialogResult == DialogResult.OK)
         {
            return form.SelectedModule;
         }

         return null;
      }

      #endregion

      #region Private Members

      private void ListAccessoryModules()
      {
         tabModulesAccessories.PageVisible = true;
         tabModulesSensors.PageVisible = false;

         try
         {
            grdAccessory.BeginUpdate();
            grdAccessory.DataSource = OTCContext.Project.Manager.DeviceDAO.FindByType(Device.DeviceType.AccessoryDecoder);
            grdAccessoryView.Columns[0].Visible = false;
            grdAccessory.EndUpdate();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void ListSensorModules()
      {
         tabModulesAccessories.PageVisible = false;
         tabModulesSensors.PageVisible = true;

         try
         {
            grdSensor.BeginUpdate();
            grdSensor.DataSource = OTCContext.Project.Manager.DeviceDAO.FindByType(Device.DeviceType.SensorModule);
            grdSensorView.Columns[0].Visible = false;
            grdSensor.EndUpdate();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void AddAccessoryModule()
      {
         FrmAccessoryEditor form = new FrmAccessoryEditor();
         form.ShowDialog(this);

         if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
         {
            ListAccessoryModules();
         }
      }

      private void AddSensorModule()
      {
         FrmSensorEditor form = new FrmSensorEditor();
         form.ShowDialog(this);

         if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
         {
            ListSensorModules();
         }
      }

      private void EditAccessoryModule()
      {
         if (grdAccessoryView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the object you want to edit.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         DataRowView rowView = grdAccessoryView.GetRow(grdAccessoryView.GetSelectedRows()[0]) as DataRowView;
         if (rowView == null)
         {
            return;
         }

         Device module = OTCContext.Project.AccessoryModules.Get((int)rowView[0]);
         if (module == null)
         {
            return;
         }

         FrmAccessoryEditor form = new FrmAccessoryEditor(module);
         form.ShowDialog(this);

         if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
         {
            ListAccessoryModules();
         }
      }

      private void EditSensorModule()
      {
         if (grdSensorView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the object you want to edit.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         DataRowView rowView = grdSensorView.GetRow(grdSensorView.GetSelectedRows()[0]) as DataRowView;
         if (rowView == null)
         {
            return;
         }

         Device module = OTCContext.Project.SensorModules.Get((int)rowView[0]);
         if (module == null)
         {
            return;
         }

         FrmSensorEditor form = new FrmSensorEditor(module);
         form.ShowDialog(this);

         if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
         {
            ListSensorModules();
         }
      }

      public void DeleteAccessoryModule()
      {
         if (grdAccessoryView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the object you want to delete.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         DataRowView rowView = grdAccessoryView.GetRow(grdAccessoryView.GetSelectedRows()[0]) as DataRowView;
         if (rowView == null)
         {
            return;
         }

         if (MessageBox.Show("Are you sure you want to delete the module " + (string)rowView[1] + " and all its related data and configurations?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
         {
            return;
         }

         try
         {
            OTCContext.Project.AccessoryModules.Remove((int)rowView[0]);

            ListAccessoryModules();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      public void DeleteSensorModule()
      {
         if (grdSensorView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the object you want to delete.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         DataRowView rowView = grdSensorView.GetRow(grdSensorView.GetSelectedRows()[0]) as DataRowView;
         if (rowView == null)
         {
            return;
         }

         if (MessageBox.Show("Are you sure you want to delete the module " + (string)rowView[1] + " and all its related data and configurations?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
         {
            return;
         }

         try
         {
            OTCContext.Project.SensorModules.Remove((int)rowView[0]);

            ListSensorModules();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      #endregion

   }
}