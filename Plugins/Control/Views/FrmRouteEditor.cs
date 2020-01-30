using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using RailwayStudio.Common;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.UI;
using Rwm.Otc.UI.Controls;
using System;
using System.Data;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class FrmRouteEditor : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="FrmRouteEditor"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      public FrmRouteEditor()
      {
         InitializeComponent();

         this.Route = new Route();
         cboBlockFrom.RefreshElementsList();
         cboBlockTo.RefreshElementsList();
         this.ListActions();

         tabDecoderOutputs.PageVisible = false;

         this.ShowPanels();
      }

      /// <summary>
      /// Returns a new instance of <see cref="FrmRouteEditor"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      /// <param name="route">The decoder to edit in the editor dialogue.</param>
      public FrmRouteEditor(Route route)
      {
         InitializeComponent();

         this.Route = route;

         txtName.Text = this.Route.Name;
         txtNotes.Text = this.Route.Description;
         chkBidirectional.Checked = this.Route.IsBidirectionl;
         cboBlockFrom.SetSelectedElement(route.FromBlock);
         cboBlockTo.SetSelectedElement(route.ToBlock);
         this.ListActions(1);

         this.ShowPanels();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the route loaded in the editor.
      /// </summary>
      internal Route Route { get; private set; }

      #endregion

      #region Event Handlers

      private void FrmRouteEditor_Load(object sender, EventArgs e)
      {
         txtName.SelectAll();
         txtName.Focus();
      }

      /// <summary>
      /// Deactivate route in all switchboards
      /// </summary>
      private void FrmRouteEditor_FormClosed(object sender, FormClosedEventArgs e)
      {
         OTCContext.Project.ClearRoutes();
      }

      private void grdConnectView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_CONNECTION_16, e);
      }

      private void grdConnectView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
      {
         DataRowView drv = grdConnectView.GetRow(e.RowHandle) as DataRowView;
         if (drv != null)
         {
            if ((Int64)drv[0] <= 0)
            {
               e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
               e.Appearance.BackColor2 = System.Drawing.Color.FromArgb(192, 255, 192);
            }
         }
      }

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
      }

      private void cmdOk_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must provide a valid name for the route.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return;
         }
         else if (this.Route.Elements.Count <= 0)
         {
            MessageBox.Show("Routes should have at least one activated element.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         Cursor.Current = Cursors.WaitCursor;

         this.Route.Name = txtName.Text.Trim();
         this.Route.Description = txtNotes.Text.Trim();
         this.Route.FromBlock = cboBlockFrom.SelectedElement;
         this.Route.ToBlock = cboBlockTo.SelectedElement;
         this.Route.IsBidirectionl = chkBidirectional.Checked;

         try
         {
            Route.Save(this.Route);

            this.DialogResult = DialogResult.OK;
            this.Close();
         }
         catch (Exception ex)
         {
            Cursor.Current = Cursors.Default;

            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            Cursor.Current = Cursors.Default;
         }
      }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Static Members

      public static void ViewAddRoutePanel(Switchboard panel,
                                           Route route,
                                           XtraTabControl tabControl,
                                           XtraTabPage tabPage,
                                           SwitchboardRouteEditorControl.CellClickedEventHandler cellClickEvent,
                                           SwitchboardRouteEditorControl.BlockClickedEventHandler blockClickEvent,
                                           SwitchboardRouteEditorControl.BlockDoubleClickedEventHandler blockDoubleClickEvent)
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
         if (blockDoubleClickEvent != null) spcPanel.ElementDoubleClick += blockDoubleClickEvent;

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

      #endregion

      #region Private Members

      /// <summary>
      /// Create and paint all panels.
      /// </summary>
      private void ShowPanels()
      {
         Cursor.Current = Cursors.WaitCursor;

         // Clear all previous panels
         tabPanels.TabPages.Clear();

         // Draw all panels
         foreach (Switchboard sb in OTCContext.Project.Switchboards)
         {
            FrmRouteEditor.ViewAddRoutePanel(sb,
                                             this.Route, 
                                             tabPanels,
                                             null,
                                             spcPanel_CellClick,
                                             spcPanel_BlockClick,
                                             null);
         }

         // Select the first panel
         if (tabPanels.TabPages.Count > 0)
         {
            tabPanels.SelectedTabPage = tabPanels.TabPages[0];
         }

         Cursor.Current = Cursors.Default;
      }

      private void ListActions()
      {
         this.ListActions(-1);
      }

      private void ListActions(int selectedValue)
      {
         ImageComboBoxItem item = null;

         cboAction.Properties.Items.Clear();

         item = new ImageComboBoxItem();
         item.Description = "No action";
         item.Value = 0;
         item.ImageIndex = 3;
         cboAction.Properties.Items.Add(item);

         if (selectedValue == (int)item.Value) cboAction.SelectedItem = item;

         item = new ImageComboBoxItem();
         item.Description = "Stop train immediately";
         item.Value = 1;
         item.ImageIndex = 4;
         cboAction.Properties.Items.Add(item);

         if (selectedValue == (int)item.Value) cboAction.SelectedItem = item;

         item = new ImageComboBoxItem();
         item.Description = "Stop train using breaks";
         item.Value = 0;
         item.ImageIndex = 4;
         cboAction.Properties.Items.Add(item);

         if (selectedValue == (int)item.Value) cboAction.SelectedItem = item;
      }

      #endregion

   }
}