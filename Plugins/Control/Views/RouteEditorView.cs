using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Rwm.Otc;
using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class RouteEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public RouteEditorView()
      {
         this.SetData(new Route(OTCContext.Project));
      }

      public RouteEditorView(Route route)
      {
         this.SetData(route);
      }

      #endregion

      #region Properties

      public Route Route { get; private set; }

      #endregion

      #region Event Handlers

      private void RouteEditorView_Shown(object sender, EventArgs e)
      {
         txtName.SelectAll();
         txtName.Focus();
      }

      private void chkIsBlock_CheckedChanged(object sender, EventArgs e)
      {
         grpBlockConnections.Enabled = chkIsBlock.Checked;
         grpBlockBehaviour.Enabled = chkIsBlock.Checked;
      }

      private void CmdOk_Click(object sender, EventArgs e)
      {
         if (!this.GetData()) return;

         this.DialogResult = DialogResult.OK;
         return;
      }

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         return;
      }

      #endregion

      #region Methods

      private void SetData(Route route)
      {
         this.InitializeComponent();

         this.Route = route;

         txtName.Text = this.Route.Name;
         txtNotes.Text = this.Route.Description;
         spnSwitchTime.EditValue = this.Route.SwitchTime;
         chkIsBlock.Checked = this.Route.IsBlock;
         chkBidirectional.Checked = this.Route.IsBidirectionl;

         this.RefreshConnectionsList();
      }

      private bool GetData()
      {
         if (string.IsNullOrEmpty(txtName.Text.Trim()))
         {
            MessageBox.Show("You must provide a valid name for the route.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return false;
         }

         this.Route.Name = txtName.Text;
         this.Route.Description = txtNotes.Text;
         this.Route.SwitchTime = (int)(decimal)spnSwitchTime.EditValue;
         this.Route.IsBlock = chkIsBlock.Checked;
         this.Route.IsBidirectionl = chkBidirectional.Checked;

         return true;
      }

      private void RefreshConnectionsList()
      {
         dynamic connection;

         // Create the connections list
         List<ExpandoObject> connections = new List<ExpandoObject>();
         foreach (RouteElement routeElement in this.Route.Elements.OrderBy(o=>o.Element.ToString()))
         {
            if (routeElement.Element != null && routeElement.Element.Properties.NumberOfAccessoryConnections > 0)
            {
               for (int i=1; i<=routeElement.Element.Properties.NumberOfAccessoryConnections; i++)
               {
                  DeviceConnection deviceConnection = DeviceConnection.GetByIndex(routeElement.Element, i, Device.DeviceType.AccessoryDecoder);
                  if (deviceConnection != null)
                  {
                     connection = new ExpandoObject();
                     connection.ID = deviceConnection.ID;
                     connection.Name = (deviceConnection.Element != null ? deviceConnection.Element?.ToString() : "Bad connection!");
                     connection.Device = (deviceConnection.Device != null ? deviceConnection.Device?.Name : "Bad connection!");
                     connection.Output = deviceConnection.Output;
                     connection.Address = deviceConnection.Address;
                     connection.Status = routeElement.Element.Properties.GetStatusDescription(routeElement.AccessoryStatus);
                  }
                  else
                  {
                     connection = new ExpandoObject();
                     connection.ID = 0;
                     connection.Name = "Not connected";
                     connection.Device = "-";
                     connection.Output = "-";
                     connection.Address = "-";
                     connection.Status = "-";
                  }

                  connections.Add(connection);
               }
            }
         }

         grdConnect.BeginUpdate();

         grdConnectView.Columns.Clear();
         grdConnectView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Element", Visible = true, FieldName = "Name", Width = 200 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Device", Visible = true, FieldName = "Device", Width = 120 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Output", Visible = true, FieldName = "Output", Width = 80 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Address", Visible = true, FieldName = "Address", Width = 80 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Status", Visible = true, FieldName = "Status", Width = 120 });

         grdConnectView.Columns["Output"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Output"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

         grdConnectView.Columns["Address"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Address"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

         grdConnect.DataSource = connections;

         grdConnect.EndUpdate();
      }

      #endregion

   }
}
