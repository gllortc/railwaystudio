using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTab;
using Rwm.Otc;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Rwm.Otc.UI;
using Rwm.Otc.UI.Controls;

namespace Rwm.Studio.Plugins.Designer.Modules
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
         finally
         {
            this.RefreshViewStatus();
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

            this.Route.Activate();
         }
         catch (Exception ex)
         {
            MessageBox.Show(Logger.LogError(this, ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            this.RefreshViewStatus();
         }
      }

      /// <summary>
      /// Delete the selected route.
      /// </summary>
      internal void RouteDelete()
      {
         if (grdDataView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the route to delete.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            Route route = grdDataView.GetRow(grdDataView.GetSelectedRows()[0]) as Route;
            if (route == null) return;

            if (MessageBox.Show("Are you sure you want to delete the route " + route.Name + "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) 
               return;

            Route.Delete(route.ID);
            OTCContext.Project.Routes.Remove(route);

            this.ShowRoutesList();
         }
         catch (Exception ex)
         {
            MessageBox.Show(Logger.LogError(this, ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            this.RefreshViewStatus();
         }
      }

      /// <summary>
      /// Save the current loaded route.
      /// </summary>
      internal bool RouteSave()
      {
         try
         {
            if (!this.MapViewToEntity())
               return false;

            this.SaveCurrentRoute();

            return true;
         }
         catch (Exception ex)
         {
            MessageBox.Show(Logger.LogError(this, ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
         }
      }

      /// <summary>
      /// Save the current loaded route.
      /// </summary>
      internal void RouteSaveAndClose()
      {
         try
         {
            if (!this.MapViewToEntity()) return;

            this.SaveCurrentRoute();
            this.ShowRoutesList();
         }
         catch (Exception ex)
         {
            MessageBox.Show(Logger.LogError(this, ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            this.RefreshViewStatus();
         }
      }

      /// <summary>
      /// Close the opened route.
      /// </summary>
      internal void RouteClose()
      {
         if (this.HasChanges)
         {
            if (MessageBox.Show("The current route has unsaved changes. Do you want to save before exit?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
               if (!this.RouteSave()) return;
            }
         }

         try
         {
            this.Route = null;

            this.ShowRoutesList();
         }
         catch (Exception ex)
         {
            MessageBox.Show(Logger.LogError(this, ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            this.RefreshViewStatus();
         }
      }

      public void GenerateRouteName()
      {
         if (cboBlockFrom.SelectedBlock == null || cboBlockTo.SelectedBlock == null)
         {
            MessageBox.Show("To be able to generate a valid route name, you should specify both FROM and TO blocks.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboBlockFrom.Focus();
            return;
         }

         txtName.Text = cboBlockFrom.SelectedBlock.DisplayName + " → " + cboBlockTo.SelectedBlock.DisplayName;
         txtName.SelectAll();
         txtName.Focus();
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

         // Toggle controls visibility
         pnlRoute.Visible = true;
         grdData.Visible = false;

         Cursor.Current = Cursors.Default;
      }

      /// <summary>
      /// Clear all switchboards and hide tab pages.
      /// </summary>
      internal void ShowRoutesList()
      {
         Cursor.Current = Cursors.WaitCursor;

         // Clear all previous panels and routes
         this.Route = null;
         Route.ClearAll();
         tabPanels.TabPages.Clear();

         // Refresh routes list
         grdData.BeginUpdate();

         if (grdDataView.Columns.Count <= 0)
         {
            grdDataView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
            grdDataView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name", Width = 150 });
            grdDataView.Columns.Add(new GridColumn() { Caption = "Type", Visible = true, FieldName = "TypeDescription", Width = 80 });
            grdDataView.Columns.Add(new GridColumn() { Caption = "From", Visible = true, FieldName = "FromBlock.DisplayName", Width = 80 });
            grdDataView.Columns.Add(new GridColumn() { Caption = "To", Visible = true, FieldName = "ToBlock.DisplayName", Width = 80 });
            grdDataView.Columns.Add(new GridColumn() { Caption = "Description", Visible = true, FieldName = "Description" });

            grdDataView.Columns["Name"].AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
            grdDataView.Columns["Name"].OptionsColumn.FixedWidth = true;
            grdDataView.Columns["TypeDescription"].OptionsColumn.FixedWidth = true;
            grdDataView.Columns["FromBlock.DisplayName"].OptionsColumn.FixedWidth = true;
            grdDataView.Columns["ToBlock.DisplayName"].OptionsColumn.FixedWidth = true;
         }

         grdData.DataSource = null;
         grdData.DataSource = Route.FindAll();

         grdData.EndUpdate();

         // Toggle controls visibility
         pnlRoute.Visible = false;
         grdData.Visible = true;

         // Reset route changes
         this.HasChanges = false;

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
         txtDescription.Text = this.Route.Description;
         spnSwitchTime.EditValue = this.Route.SwitchTime;
         chkIsBlock.Checked = this.Route.IsBlock;
         cboBlockFrom.SetSelectedBlock(this.Route.FromBlock);
         cboBlockTo.SetSelectedBlock(this.Route.ToBlock);
         txtNotes.Text = this.Route.Notes;
      }

      private bool MapViewToEntity()
      {
         if (string.IsNullOrEmpty(txtName.Text.Trim()))
         {
            MessageBox.Show("You must provide a valid name for the route.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tabRoute.SelectedTabPage = tabRouteGeneral;
            txtName.Focus();
            return false;
         }
         else if (chkIsBlock.Checked && cboBlockFrom.SelectedBlock == null)
         {
            MessageBox.Show("For blocks interconnection routes you must provide the FROM block element.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tabRoute.SelectedTabPage = tabRouteGeneral;
            cboBlockFrom.Focus();
            return false;
         }
         else if (chkIsBlock.Checked && cboBlockTo.SelectedBlock == null)
         {
            MessageBox.Show("For blocks interconnection routes you must provide the TO block element.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tabRoute.SelectedTabPage = tabRouteGeneral;
            cboBlockTo.Focus();
            return false;
         }

         this.Route.Name = txtName.Text;
         this.Route.Description = txtDescription.Text;
         this.Route.Notes = txtNotes.Text;
         this.Route.SwitchTime = (int)(decimal)spnSwitchTime.EditValue;
         this.Route.IsBlock = chkIsBlock.Checked;
         // this.Route.IsBidirectionl = chkBidirectional.Checked;
         this.Route.FromBlock = cboBlockFrom.SelectedBlock;
         this.Route.ToBlock = cboBlockTo.SelectedBlock;

         return true;
      }

      private void SaveCurrentRoute()
      {
         // Save the route
         Route.Save(this.Route);
         foreach (RouteElement routeElement in this.Route.Elements)
         {
            if (routeElement.Element != null)
               RouteElement.Save(routeElement);
            else
               RouteElement.Delete(routeElement);  // unused route element
         }

         // Add the route into the project
         if (!OTCContext.Project.Routes.Contains(this.Route))
            OTCContext.Project.Routes.Add(this.Route);

         this.HasChanges = false;
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
            tabPanel.Image = Properties.Resources.ICO_SWITCHBOARD_16;
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

      ///// <summary>
      ///// Refresh the route involved connections list.
      ///// </summary>
      //private void RefreshConnectionsList()
      //{
      //   if (!this.IsRouteLoaded)
      //      return;

      //   grdConnect.BeginUpdate();

      //   grdConnectView.Columns.Clear();
      //   grdConnectView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
      //   grdConnectView.Columns.Add(new GridColumn() { Caption = "Element", Visible = true, FieldName = "Name" });
      //   grdConnectView.Columns.Add(new GridColumn() { Caption = "Status", Visible = true, FieldName = "Status", Width = 100 });
      //   grdConnectView.Columns.Add(new GridColumn() { Caption = "Decoder", Visible = true, FieldName = "Decoder", Width = 100 });
      //   grdConnectView.Columns.Add(new GridColumn() { Caption = "Output", Visible = true, FieldName = "Output", Width = 80 });
      //   grdConnectView.Columns.Add(new GridColumn() { Caption = "Address", Visible = true, FieldName = "Address", Width = 80 });

      //   grdConnectView.Columns["Output"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      //   grdConnectView.Columns["Output"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

      //   grdConnectView.Columns["Address"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      //   grdConnectView.Columns["Address"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

      //   grdConnect.DataSource = AccessoryDecoderConnection.List(this.Route);

      //   grdConnect.EndUpdate();
      //}

      #endregion

   }
}
