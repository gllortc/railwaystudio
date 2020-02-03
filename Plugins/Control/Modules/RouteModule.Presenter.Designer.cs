using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTab;
using Rwm.Otc;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Rwm.Otc.UI;
using Rwm.Otc.UI.Controls;
using Rwm.Studio.Plugins.Control.Views;

namespace Rwm.Studio.Plugins.Control.Modules
{
   public partial class RouteModule
   {

      #region Properties

      internal Route Route { get; private set; } = null;

      private bool HasChanges { get; set; } = false;

      #endregion

      #region Methods

      /// <summary>
      /// Create a new route.
      /// </summary>
      internal void RouteAdd()
      {
         try
         {
            RouteEditorView form = new RouteEditorView();
            form.ShowDialog(this);

            if (form.DialogResult == DialogResult.OK)
            {
               this.Route = form.Route;
               if (this.Route == null) return;

               this.ShowSwitchboards();

               cmdRouteAdd.Enabled = false;
               cmdRouteEdit.Enabled = false;
               cmdRouteDelete.Enabled = false;
               cmdRouteProperties.Enabled = true;
               cmdRouteSave.Enabled = true;
               cmdRouteClose.Enabled = true;
            }
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
         if (tabPanels.TabPages.Count <= 0)
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

            this.ShowSwitchboards();

            cmdRouteAdd.Enabled = false;
            cmdRouteEdit.Enabled = false;
            cmdRouteDelete.Enabled = false;
            cmdRouteProperties.Enabled = true;
            cmdRouteSave.Enabled = true;
            cmdRouteClose.Enabled = true;
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

      /// <summary>
      /// Open the selected route for edit.
      /// </summary>
      internal void RouteProperties()
      {
         if (tabPanels.TabPages.Count <= 0)
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

            RouteEditorView form = new RouteEditorView(this.Route);
            form.ShowDialog(this);
         }
         catch (Exception ex)
         {
            MessageBox.Show(Logger.LogError(this, ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

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
            cmdRouteAdd.Enabled = true;
            cmdRouteEdit.Enabled = true;
            cmdRouteDelete.Enabled = true;
            cmdRouteProperties.Enabled = false;
            cmdRouteSave.Enabled = false;
            cmdRouteClose.Enabled = false;

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

         tabPanels.Visible = true;
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

         tabPanels.Visible = false;
         grdData.Visible = true;

         Cursor.Current = Cursors.Default;
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
         grdDataView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name" });
         grdDataView.Columns.Add(new GridColumn() { Caption = "Elements", Visible = true, FieldName = "ElementsCount", Width = 100 });

         grdDataView.Columns["ElementsCount"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdDataView.Columns["ElementsCount"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

         grdData.DataSource = Route.FindAll();

         grdData.EndUpdate();

         grdData.Dock = DockStyle.Fill;
         grdData.Visible = true;
      }

      #endregion

   }
}
