﻿using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using RailwayStudio.Common;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Control.Views;

namespace Rwm.Studio.Plugins.Control.Controls
{
   public partial class AccessoryDecoderManagerControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      public AccessoryDecoderManagerControl()
      {
         InitializeComponent();
      }

      #endregion

      #region Methods

      public override void Refresh()
      {
         try
         {
            grdModule.BeginUpdate();

            grdModuleView.Columns.Clear();
            grdModuleView.Columns.Add(new GridColumn() { Caption = "Device", Visible = true, FieldName = "Name" });
            grdModuleView.Columns.Add(new GridColumn() { Caption = "Connections", Visible = true, FieldName = "ConnectionsCount", Width = 45 });

            grdModuleView.Columns["ConnectionsCount"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdModuleView.Columns["ConnectionsCount"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            grdModule.DataSource = AccessoryDecoder.FindAll();

            grdModule.EndUpdate();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

         base.Refresh();
      }

      #endregion

      #region Event Handlers

      private void GrdModuleView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         if (grdModuleView.GetRow(e.RowHandle) is AccessoryDecoder device)
         {
            StudioContext.UI.DrawRowIcon(device.Icon, e);
         }
      }

      private void CmdDecoderAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.AddModule();
      }

      private void CmdModuleEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.EditModule();
      }

      private void CmdModuleDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.DeleteModule();
      }

      private void GrdModuleView_DoubleClick(object sender, EventArgs e)
      {
         if (grdModuleView.SelectedRowsCount <= 0)
         {
            return;
         }

         this.EditModule();
      }

      #endregion

      #region Private Members

      private void AddModule()
      {
         AccessoryDeviceEditorView form = new AccessoryDeviceEditorView();
         form.ShowDialog(this);

         if (form.DialogResult == DialogResult.OK)
         {
            this.Refresh();
         }
      }

      private void EditModule()
      {
         if (grdModuleView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the module you want to edit.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         if (!(grdModuleView.GetRow(grdModuleView.GetSelectedRows()[0]) is AccessoryDecoder decoder))
         {
            return;
         }

         AccessoryDeviceEditorView form = new AccessoryDeviceEditorView(decoder);
         form.ShowDialog(this);

         if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
         {
            this.Refresh();
         }
      }

      public void DeleteModule()
      {
         if (grdModuleView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the control device you want to delete.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         if (!(grdModuleView.GetRow(grdModuleView.GetSelectedRows()[0]) is AccessoryDecoder decoder)) return;

         if (MessageBox.Show("Are you sure you want to delete the module " + decoder.Name + " and all its related data and configurations?", 
                             Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
         {
            return;
         }

         try
         {
            AccessoryDecoder.Delete(decoder.ID);

            // Also remove the module in current project
            OTCContext.Project.AccessoryDecoders.Remove(decoder);

            this.Refresh();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

        #endregion

    }
}
