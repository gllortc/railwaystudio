using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using Rwm.Otc;
using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class AccesoryConnectionFindView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public AccesoryConnectionFindView(AccessoryDecoderConnection connection = null)
      {
         InitializeComponent();

         this.SelectedDecoder = connection?.Decoder;
         this.SelectedConnection = connection;

         this.RefreshListDecoders();
      }

      #endregion

      #region Properties

      public AccessoryDecoderConnection SelectedConnection { get; private set; } = null;

      public AccessoryDecoder SelectedDecoder { get; private set; } = null;

      #endregion

      #region Event Handlers

      private void TvwConnections_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
      {
         if (e.Node.HasChildren)
         {
            txtAddress.EditValue = 0;
            txtSwitchTime.EditValue = 0;
            grpDigital.Enabled = false;
            cmdOK.Enabled = false;
            return;
         }

         if (e.Node.Tag == null)
         {
            txtAddress.EditValue = Int32.Parse(e.Node.ParentNode[1].ToString()) + Int32.Parse(e.Node[0].ToString());
            txtSwitchTime.EditValue = 0;
         }
         else
         {
            AccessoryDecoderConnection connection = e.Node.Tag as AccessoryDecoderConnection;
            txtAddress.EditValue = connection.Address;
            txtSwitchTime.EditValue = connection.SwitchTime;
         }

         grpDigital.Enabled = true;
         cmdOK.Enabled = true;
      }

      private void GrdDecodersView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
      {
         this.SelectedDecoder = grdDecodersView.GetRow(e.RowHandle) as AccessoryDecoder;
         this.RefreshDecoderOutputs();

         this.SelectedDecoder = null;
         txtAddress.EditValue = String.Empty;
         txtSwitchTime.EditValue = String.Empty;
         cmdOK.Enabled = false;
         grpDigital.Enabled = false;
      }

      private void GrdOutputsView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
      {
         this.SelectedConnection = grdOutputsView.GetRow(e.FocusedRowHandle) as AccessoryDecoderConnection;

         if (this.SelectedConnection != null)
         {
            txtAddress.EditValue = this.SelectedConnection.Address;
            txtSwitchTime.EditValue = this.SelectedConnection.SwitchTime;

            cmdOK.Enabled = true;
            grpDigital.Enabled = true;
         }
      }

      private void CmdOK_Click(object sender, EventArgs e)
      {
         if (this.SelectedConnection == null)
         {
            MessageBox.Show("You must select the control module output you want to connect the element.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         //else if (tvwConnections.FocusedNode.StateImageIndex == 3)
         //{
         //   if (MessageBox.Show("The selected output is used by another element. Really you want to share this output?",
         //                       Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
         //   {
         //      return;
         //   }
         //}

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.SelectedDecoder = null;
         this.SelectedConnection = null;

         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Private Members

      private void RefreshListDecoders()
      {
         grdDecoders.BeginUpdate();
         grdDecodersView.OptionsBehavior.AutoPopulateColumns = false;
         grdDecoders.DataSource = null;

         if (grdDecodersView.Columns.Count <= 0)
         {
            grdDecodersView.Columns.Clear();
            grdDecodersView.OptionsBehavior.AutoPopulateColumns = false;
            grdDecodersView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
            grdDecodersView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name" });
            grdDecodersView.Columns.Add(new GridColumn() { Caption = "Outputs", Visible = true, FieldName = "Outputs", Width = 30 });
            grdDecodersView.Columns.Add(new GridColumn() { Caption = "Used", Visible = true, FieldName = "ConnectionsCount", Width = 30 });

            grdDecodersView.Columns["Outputs"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdDecodersView.Columns["Outputs"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            grdDecodersView.Columns["ConnectionsCount"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdDecodersView.Columns["ConnectionsCount"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         }

         grdDecoders.DataSource = OTCContext.Project.AccessoryDecoders;
         grdDecoders.EndUpdate();

         // Preselect a decoder if connection is selected
         if (this.SelectedConnection != null)
         {
            int rowHandle = grdDecodersView.LocateByValue("ID", this.SelectedConnection.Decoder.ID);
            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
               this.SelectedDecoder = this.SelectedConnection.Decoder;
               grdDecodersView.FocusedRowHandle = rowHandle;
            }
         }
         else
            grdDecodersView.ClearSelection();
      }

      private void RefreshDecoderOutputs()
      {
         int currentAddress;
         Dictionary<int, AccessoryDecoderConnection> connections = new Dictionary<int, AccessoryDecoderConnection>();

         if (this.SelectedDecoder == null)
            return;

         // Create the non existing connections
         foreach (AccessoryDecoderConnection connection in this.SelectedDecoder.Connections)
            connections.Add(connection.DecoderOutput, connection);

         currentAddress = this.SelectedDecoder.StartAddress;
         for (int output = 1; output <= this.SelectedDecoder.Outputs; output++)
         {
            if (!connections.ContainsKey(output))
            {
               connections.Add(output, new AccessoryDecoderConnection() { DecoderOutput = output, Decoder = this.SelectedDecoder, Element = null, SwitchTime = 0 });
               currentAddress++;
            }
         }

         grdOutputs.BeginUpdate();
         grdOutputsView.OptionsBehavior.AutoPopulateColumns = false;
         grdOutputs.DataSource = null;

         if (grdOutputsView.Columns.Count <= 0)
         {
            grdOutputsView.Columns.Clear();
            grdOutputsView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
            grdOutputsView.Columns.Add(new GridColumn() { Caption = "Output", Visible = true, FieldName = "DecoderOutput", Width = 35 });
            grdOutputsView.Columns.Add(new GridColumn() { Caption = "Address", Visible = true, FieldName = "Address", Width = 50 });
            grdOutputsView.Columns.Add(new GridColumn() { Caption = "Element", Visible = true, FieldName = "Element.DisplayName" });
            grdOutputsView.Columns.Add(new GridColumn() { Caption = "Pin", Visible = true, FieldName = "ElementPinIndex", Width = 35 });
            grdOutputsView.Columns.Add(new GridColumn() { Caption = "Switch time", Visible = true, FieldName = "SwitchTime", Width = 40 });

            grdOutputsView.Columns["DecoderOutput"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdOutputsView.Columns["DecoderOutput"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdOutputsView.Columns["DecoderOutput"].OptionsColumn.AllowEdit = false;

            grdOutputsView.Columns["Address"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdOutputsView.Columns["Address"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdOutputsView.Columns["Address"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdOutputsView.Columns["Address"].DisplayFormat.FormatString = "{0:d4}";
            grdOutputsView.Columns["Address"].OptionsColumn.AllowEdit = true;

            grdOutputsView.Columns["Element.DisplayName"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdOutputsView.Columns["Element.DisplayName"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdOutputsView.Columns["Element.DisplayName"].OptionsColumn.AllowEdit = false;

            grdOutputsView.Columns["ElementPinIndex"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdOutputsView.Columns["ElementPinIndex"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdOutputsView.Columns["ElementPinIndex"].OptionsColumn.AllowEdit = false;

            grdOutputsView.Columns["SwitchTime"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            grdOutputsView.Columns["SwitchTime"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            grdOutputsView.Columns["SwitchTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdOutputsView.Columns["SwitchTime"].DisplayFormat.FormatString = "{0:d} ms";
            grdOutputsView.Columns["SwitchTime"].OptionsColumn.AllowEdit = true;
         }

         grdOutputsView.ViewCaption = this.SelectedDecoder.Name + " outputs";

         grdOutputs.DataSource = connections.Values;
         grdOutputs.EndUpdate();
      }

      #endregion

   }
}