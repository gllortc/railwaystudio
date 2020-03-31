using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTab;
using Rwm.Otc;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Rwm.Otc.UI;
using Rwm.Otc.UI.Controls;

namespace Rwm.Studio.Plugins.Control.Modules
{
   public partial class RouteModule
   {

      #region Properties

      internal Route Route { get; private set; } = null;

      private bool HasChanges { get; set; } = false;

      internal bool IsRouteLoaded
      {
         get { return (this.Route != null); }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Create a new route.
      /// </summary>
      internal void RouteAdd()
      {
         if (this.IsRouteLoaded)
            return;

         try
         {
            this.Route = new Route(OTCContext.Project);

            this.MapEntityToView();
            this.ShowSwitchboards();
         }
         catch (Exception ex)
         {
            MessageBox.Show(Logger.LogError(this, ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      /// <summary>
      /// Open the selected route for edit.
      /// </summary>
      internal void RouteEdit()
      {
         if (this.IsRouteLoaded)
         {
            return;
         }
         else if (OTCContext.Project.Switchboards.Count <= 0)
         {
            MessageBox.Show("There are no switchboards created in the current project.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         else if (grdDataView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the route to edit.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            this.Route = grdDataView.GetRow(grdDataView.GetSelectedRows()[0]) as Route;
            if (this.Route == null) return;

            this.MapEntityToView();
            this.ShowSwitchboards();
         }
         catch (Exception ex)
         {
            MessageBox.Show(Logger.LogError(this, ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      internal void RouteDelete()
      {
         if (grdDataView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the route to delete.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            this.Route = grdDataView.GetRow(grdDataView.GetSelectedRows()[0]) as Route;
            if (this.Route == null) return;

            if (MessageBox.Show("Are you sure you want to delete the route " + this.Route.Name + "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) 
               return;

            // Relpaced by cascade deletion
            //foreach (RouteElement routeElement in this.Route.Elements)
            //{
            //   RouteElement.Delete(routeElement.ID);
            //}

            Route.Delete(this.Route.ID);
            OTCContext.Project.Routes.Remove(this.Route);

            this.RefreshRouteList();
         }
         catch (Exception ex)
         {
            MessageBox.Show(Logger.LogError(this, ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      ///// <summary>
      ///// Open the selected route for edit.
      ///// </summary>
      //internal void RouteProperties()
      //{
      //   if (tabPanels.TabPages.Count <= 0)
      //   {
      //      MessageBox.Show("There are no switchboards created in the current project.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
      //      return;
      //   }
      //   else if (grdDataView.SelectedRowsCount <= 0)
      //   {
      //      MessageBox.Show("You must select the route to edit.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
      //      return;
      //   }

      //   try
      //   {
      //      this.Route = grdDataView.GetRow(grdDataView.GetSelectedRows()[0]) as Route;
      //      if (this.Route == null) return;

      //      RouteEditorView form = new RouteEditorView(this.Route);
      //      form.ShowDialog(this);
      //   }
      //   catch (Exception ex)
      //   {
      //      MessageBox.Show(Logger.LogError(this, ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      //   }
      //}

      internal bool RouteSave()
      {
         try
         {
            // TODO: This secuence should be implemented inside the ORM layer

            // Save the route
            Otc.Layout.Route.Save(this.Route);

            // Save the route elements
            foreach (RouteElement routeElement in this.Route.Elements)
            {
               RouteElement.Save(routeElement);
            }

            // Add the route into the project
            if (!OTCContext.Project.Routes.Contains(this.Route))
               OTCContext.Project.Routes.Add(this.Route);

            this.HasChanges = false;

            return true;
         }
         catch (Exception ex)
         {
            MessageBox.Show(Logger.LogError(this, ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
         }
      }

      internal void RouteClose()
      {
         if (this.HasChanges)
            if (MessageBox.Show("The current route has unsaved changes. Do you want to save before exit?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
               if (!this.RouteSave())
                  return;

         try
         {
            this.RefreshRouteList();
         }
         catch (Exception ex)
         {
            MessageBox.Show(Logger.LogError(this, ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      /// <summary>
      /// Create and paint all switchboards and show them into tab pages.
      /// </summary>
      internal void ShowSwitchboards()
      {
         Cursor.Current = Cursors.WaitCursor;

         // Clear all previous panels
         tabPanels.TabPages.Clear();

         // Draw all panels
         foreach (Switchboard panel in OTCContext.Project.Switchboards)
         {
            this.ViewRoutePanel(panel,
                                this.Route,
                                tabPanels,
                                null,
                                spcPanel_CellClick,
                                spcPanel_BlockClick);
         }

         // Select the first panel
         if (tabPanels.TabPages.Count > 0)
         {
            tabPanels.SelectedTabPage = tabPanels.TabPages[0];
         }

         splitRoute.Visible = true;
         grdData.Visible = false;

         Cursor.Current = Cursors.Default;
      }

      /// <summary>
      /// Clear all switchboards and hide tab pages.
      /// </summary>
      internal void HideSwitchboards()
      {
         Cursor.Current = Cursors.WaitCursor;

         // Clear all previous panels
         tabPanels.TabPages.Clear();

         splitRoute.Visible = false;
         grdData.Visible = true;

         Cursor.Current = Cursors.Default;
      }

      internal void RefreshViewStatus()
      {
         rpgRoutes.Enabled = !this.IsRouteLoaded;
         rpgRoute.Enabled = this.IsRouteLoaded;
      }

      #endregion

      #region Event Handlers

      void spcPanel_CellClick(object sender, CellClickEventArgs e)
      {
         if (e.Control == null) return;
         e.Control.UnselectCell();
         e.Control.SelectCell(e.X, e.Y);
      }

      void spcPanel_BlockClick(object sender, CellClickEventArgs e)
      {
         if (e.Control == null) return;
         e.Control.SelectCell(e.Element.Coordinates);

         this.HasChanges = true;
      }

      #endregion

      #region Private Members

      private void MapEntityToView()
      {
         txtName.Text = this.Route.Name;
         txtNotes.Text = this.Route.Description;
         spnSwitchTime.EditValue = this.Route.SwitchTime;
         chkIsBlock.Checked = this.Route.IsBlock;
         chkBidirectional.Checked = this.Route.IsBidirectionl;

         this.RefreshConnectionsList();
      }

      private bool MapViewToEntity()
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

      private void ViewRoutePanel(Switchboard panel,
                                  Route route,
                                  XtraTabControl tabControl,
                                  XtraTabPage tabPage,
                                  SwitchboardRouteEditorControl.CellClickedEventHandler cellClickEvent,
                                  SwitchboardRouteEditorControl.BlockClickedEventHandler blockClickEvent)
      {
         XtraTabPage tabPanel;

         tabControl.SuspendLayout();

         // Generate the grid
         SwitchboardRouteEditorControl spcPanel = new SwitchboardRouteEditorControl(panel, route);
         spcPanel.Dock = DockStyle.Fill;
         spcPanel.Location = new System.Drawing.Point(5, 5);
         spcPanel.Name = "grdPanel" + panel.ID;
         spcPanel.BorderStyle = BorderStyle.FixedSingle;
         spcPanel.DesignModeEnabled = true;

         // Enable grid events
         if (cellClickEvent != null) spcPanel.CellClick += cellClickEvent;
         if (blockClickEvent != null) spcPanel.ElementClick += blockClickEvent;

         // Generate the tab page
         if (tabPage == null)
         {
            tabPanel = new XtraTabPage();

            // tabPanel.Controls.Add(grdPanel);
            tabPanel.Name = "tabPanel" + panel.ID;
            tabPanel.Padding = new Padding(5);
            tabPanel.Text = panel.Name;
            tabPanel.Image = Properties.Resources.ICO_PANEL_16;
            tabPanel.Tag = panel;
            tabPanel.Controls.Add(spcPanel);
         }
         else
         {
            // Clear all page contents
            tabPage.Controls.Clear();

            tabPanel = tabPage;
         }

         tabControl.TabPages.Add(tabPanel);

         // Select the new panel
         tabControl.SelectedTabPage = tabPanel;

         tabControl.ResumeLayout(false);
      }

      /// <summary>
      /// Refresh the current route list.
      /// </summary>
      private void RefreshRouteList()
      {
         grdData.BeginUpdate();

         grdDataView.Columns.Clear();
         grdDataView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
         grdDataView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name", Width = 300 });
         grdDataView.Columns.Add(new GridColumn() { Caption = "Block", Visible = true, FieldName = "IsBlock", Width = 80 });
         grdDataView.Columns.Add(new GridColumn() { Caption = "Elements", Visible = true, FieldName = "ElementsCount", Width = 80 });

         grdDataView.Columns["ElementsCount"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdDataView.Columns["ElementsCount"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

         grdData.DataSource = Route.FindAll();

         grdData.EndUpdate();

         grdData.Dock = DockStyle.Fill;
         grdData.Visible = true;
      }

      private void RefreshConnectionsList()
      {
         dynamic connection;

         // Create the connections list
         List<ExpandoObject> connections = new List<ExpandoObject>();
         foreach (RouteElement routeElement in this.Route.Elements.OrderBy(o => o.Element?.ToString()))
         {
            if (routeElement.Element != null && routeElement.Element.Properties.NumberOfAccessoryConnections > 0)
            {
               for (int i = 1; i <= routeElement.Element.Properties.NumberOfAccessoryConnections; i++)
               {
                  AccessoryDecoderConnection deviceConnection = AccessoryDecoderConnection.GetByIndex(routeElement.Element, i);
                  if (deviceConnection != null)
                  {
                     connection = new ExpandoObject();
                     connection.ID = deviceConnection.ID;
                     connection.IsValid = true;
                     connection.Name = (deviceConnection.Element != null ? deviceConnection.Element?.ToString() : "Bad connection!");
                     connection.Device = (deviceConnection.Decoder != null ? deviceConnection.Decoder?.Name : "Bad connection!");
                     connection.Output = deviceConnection.DecoderOutput;
                     connection.Address = deviceConnection.Address;
                     connection.Status = routeElement.Element.Properties.GetStatusDescription(routeElement.AccessoryStatus);
                  }
                  else
                  {
                     connection = new ExpandoObject();
                     connection.ID = 0;
                     connection.IsValid = false;
                     connection.Name = routeElement.Element.ToString();
                     connection.Device = "-";
                     connection.Output = "-";
                     connection.Address = "-";
                     connection.Status = routeElement.Element.Properties.GetStatusDescription(routeElement.AccessoryStatus);
                  }

                  connections.Add(connection);
               }
            }
         }

         grdConnect.BeginUpdate();

         grdConnectView.Columns.Clear();
         grdConnectView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Element", Visible = true, FieldName = "Name", Width = 200 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Status", Visible = true, FieldName = "Status", Width = 120 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Device", Visible = true, FieldName = "Device", Width = 120 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "DecoderInput", Visible = true, FieldName = "DecoderInput", Width = 80 });
         grdConnectView.Columns.Add(new GridColumn() { Caption = "Address", Visible = true, FieldName = "Address", Width = 80 });

         grdConnectView.Columns["DecoderInput"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["DecoderInput"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

         grdConnectView.Columns["Address"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdConnectView.Columns["Address"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

         grdConnect.DataSource = connections;

         grdConnect.EndUpdate();
      }

      #endregion

   }
}
