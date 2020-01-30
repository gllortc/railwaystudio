using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTab;
using RailwayStudio.Common;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.UI;
using Rwm.Otc.UI.Controls;
using Rwm.Studio.Plugins.Control.Reports;
using Rwm.Studio.Plugins.Control.Views;

namespace Rwm.Studio.Plugins.Control.Modules
{
   public partial class RouteModule
   {

      #region Properties

      internal SwitchboardDesignControl SelectedSwitchboardPanel
      {
         get
         {
            if (tabPanels.TabPages.Count <= 0)
            {
               return null;
            }
            else
            {
               if (tabPanels.SelectedTabPage.Controls.Count <= 0)
               {
                  return null;
               }
               else
               {
                  return tabPanels.SelectedTabPage.Controls[0] as SwitchboardDesignControl;
               }
            }
         }
      }

      #endregion

      #region Methods

      internal void PanelAdd()
      {
         PanelEditorView form = new PanelEditorView();
         form.ShowDialog(this);

         if (form.DialogResult == DialogResult.OK)
         {
            DesignModule.ViewAddPanel(form.Switchboard,
                                      this.tabPanels,
                                      null,
                                      null,
                                      null,
                                      spcPanel_BlockDoubleClick);
         }
      }

      internal void PanelEdit()
      {
         if (tabPanels.TabPages.Count <= 0)
         {
            MessageBox.Show("There are no switchboard panels in the current project.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         PanelEditorView form = new PanelEditorView((Switchboard)tabPanels.SelectedTabPage.Tag);
         form.ShowDialog(this);

         if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
         {
            DesignModule.ViewAddPanel(form.Switchboard,
                                      this.tabPanels,
                                      tabPanels.SelectedTabPage,
                                      null,
                                      null,
                                      spcPanel_BlockDoubleClick);
         }
      }

      internal void MoveUp()
      {
         try
         {
            this.SelectedSwitchboardPanel.Switchboard.Move(Switchboard.MoveDirection.Up);
            this.SelectedSwitchboardPanel.Refresh();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }

      internal void MoveDown()
      {
         try
         {
            this.SelectedSwitchboardPanel.Switchboard.Move(Switchboard.MoveDirection.Down);
            this.SelectedSwitchboardPanel.Refresh();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }

      internal void MoveLeft()
      {
         try
         {
            this.SelectedSwitchboardPanel.Switchboard.Move(Switchboard.MoveDirection.Left);
            this.SelectedSwitchboardPanel.Refresh();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }

      internal void MoveRight()
      {
         try
         {
            this.SelectedSwitchboardPanel.Switchboard.Move(Switchboard.MoveDirection.Right);
            this.SelectedSwitchboardPanel.Refresh();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }

      internal void ThemesManager()
      {
         ThemeManagerView form = new ThemeManagerView();
         form.ShowDialog(this);
      }

      internal void PrintDigitalReport()
      {
         // Generate the report
         DigitalReport rpt = new DigitalReport();
         rpt.CreateDocument();

         // Generate the cover
         CoverReport cover = new CoverReport(rpt.DisplayName);
         cover.CreateDocument();

         // Merge the documents
         rpt.Pages.Insert(0, cover.Pages[0]);

         // Open the document into the repport viewer plug-in
         StudioContext.MainView.OpenPluginModule(PluginManager.PLUGIN_REPORTVIEWER, rpt);
      }

      /// <summary>
      /// Create and paint all panels.
      /// </summary>
      internal void ShowPanels()
      {
         Cursor.Current = Cursors.WaitCursor;

         // Clear all previous panels
         tabPanels.TabPages.Clear();

         // Draw all panels
         foreach (Switchboard panel in OTCContext.Project.Switchboards)
         {
            DesignModule.ViewAddPanel(panel,
                                      this.tabPanels,
                                      null,
                                      null,
                                      null,
                                      spcPanel_BlockDoubleClick);
         }

         // Select the first panel
         if (tabPanels.TabPages.Count > 0)
         {
            tabPanels.SelectedTabPage = tabPanels.TabPages[0];
         }

         Cursor.Current = Cursors.Default;
      }

      internal void SetDesignToolbarStatus(bool enabled)
      {
         rpgPanels.Enabled = enabled;
         rpgBlocks.Enabled = enabled;
      }

      #endregion

      #region Event Handlers

      void GalleryItemClick(object sender, GalleryItemClickEventArgs e)
      {
         if (e.Item.Tag == null)
         {
            SwitchboardDesignControl.AddBlockType = null;
            // this.CurrentCellType = null;
         }
         else
         {
            SwitchboardDesignControl.AddBlockType = (ElementType)e.Item.Tag;
            // this.CurrentCellType = (Type)e.Item.Tag;
         }
      }

      void spcPanel_BlockDoubleClick(object sender, CellClickEventArgs e)
      {
         BlockPropertiesViews form = new BlockPropertiesViews(e.Element);
         form.ShowDialog(this);
      }

      #endregion

      #region Static Members

      public static void ViewAddPanel(Switchboard panel,
                                      XtraTabControl tabControl,
                                      XtraTabPage tabPage,
                                      SwitchboardRouteEditorControl.CellClickedEventHandler cellClickEvent,
                                      SwitchboardRouteEditorControl.BlockClickedEventHandler blockClickEvent)
      {
         XtraTabPage tabPanel;

         tabControl.SuspendLayout();

         // Generate the grid
         SwitchboardRouteEditorControl spcPanel = new SwitchboardRouteEditorControl(panel);
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

      #endregion

      #region Private Members

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
      }

      /// <summary>
      /// Fill the element gallery of all types of element.
      /// </summary>
      private void CreateElementGallery()
      {
         GalleryItem item = null;
         GalleryItemGroup group = null;
         List<Element> elements = new List<Element>();
         Assembly asm = Assembly.GetAssembly(typeof(Element));

         rgbElements.Gallery.ShowGroupCaption = false;
         rgbElements.Gallery.ShowItemText = true;
         rgbElements.Gallery.ColumnCount = 4;
         rgbElements.Gallery.Groups.Clear();

         foreach (ElementType eType in ElementType.FindAll())
         {
            // If group doesn't exist, create it
            if (!this.ExistsGalleryGroup(eType.Group))
            {
               group = new GalleryItemGroup();
               group.Caption = eType.Group;

               rgbElements.Gallery.Groups.Add(group);
            }

            // Add the element inside the group
            item = new GalleryItem();
            item.Caption = eType.Name;
            item.Description = eType.Description;
            item.Image = eType.TypeIcon;
            item.Tag = eType;
            item.ItemClick += GalleryItemClick;

            this.GetGalleryGroup(eType.Group).Items.Add(item);
         }

         // Select the first item
         rgbElements.Gallery.Groups[0].Items[0].Checked = true;
      }

      private bool ExistsGalleryGroup(string name)
      {
         foreach (GalleryItemGroup group in rgbElements.Gallery.Groups)
         {
            if (group.Caption.Equals(name))
            {
               return true;
            }
         }

         return false;
      }

      private GalleryItemGroup GetGalleryGroup(string name)
      {
         foreach (GalleryItemGroup group in rgbElements.Gallery.Groups)
         {
            if (group.Caption.Equals(name))
            {
               return group;
            }
         }

         return null;
      }

      #endregion

   }
}
