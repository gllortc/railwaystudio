using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraTab;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.UI;
using Rwm.Otc.UI.Controls;
using Rwm.Studio.Plugins.Common;
using Rwm.Studio.Plugins.Common.Reports;
using Rwm.Studio.Plugins.Designer.Reports;
using Rwm.Studio.Plugins.Designer.Views;

namespace Rwm.Studio.Plugins.Designer.Modules
{
   public partial class DesignModule
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
         SwitchboardEditorView form = new SwitchboardEditorView();
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

         SwitchboardEditorView form = new SwitchboardEditorView((Switchboard)tabPanels.SelectedTabPage.Tag);
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

      internal void ManageLayoutAreas()
      {
         ModulesManagerView form = new ModulesManagerView();
         form.ShowDialog(this);
      }

      internal void ManageDecoders()
      {
         DecodersManagerView form = new DecodersManagerView();
         form.ShowDialog(this);
      }

      internal void ManageLayoutSounds()
      {
         SoundsManagerView form = new SoundsManagerView();
         form.ShowDialog(this);
      }

      internal void PrintDigitalReport()
      {
         try
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
            StudioContext.OpenPluginModule(PluginManager.PLUGIN_REPORTVIEWER, rpt);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      internal void PrintDigitalReportBySections()
      {
         try
         {
            // Generate the report
            DigitalReportByModule rpt = new DigitalReportByModule();
            rpt.CreateDocument();

            // Generate the cover
            CoverReport cover = new CoverReport(rpt.DisplayName);
            cover.CreateDocument();

            // Merge the documents
            rpt.Pages.Insert(0, cover.Pages[0]);

            // Open the document into the repport viewer plug-in
            StudioContext.OpenPluginModule(PluginManager.PLUGIN_REPORTVIEWER, rpt);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
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

      //void spcPanel_CellClick(object sender, Rwm.Otc.Controls.CellClickEventArgs e)
      //{
      //   switch (this.EditMode)
      //   {
      //      case EditorMode.Add:
      //         this.SelectedSwitchboardPanel.BlockAdd(this.CurrentCellType, e.X, e.Y);
      //         break;

      //      case EditorMode.Delete:
      //         ((SwitchboardPanelControl)sender).BlockDelete(e.X, e.Y);
      //         break;

      //      case EditorMode.Rotate:
      //         this.SelectedSwitchboardPanel.RotateBlock(e.X, e.Y);
      //         break;

      //      case EditorMode.RouteRecord:
      //         e.Element.ActivatedInRoute = !e.Element.ActivatedInRoute;
      //         this.SelectedSwitchboardPanel.RepaintBlock(e.Element.Coordinates);
      //         this.SelectedSwitchboardPanel.SelectCell(e.Element.Coordinates);
      //         break;

      //      case EditorMode.Pointer:
      //         if (this.CurrentCellType != null)
      //         {
      //            this.SelectedSwitchboardPanel.SelectCell(e.X, e.Y);
      //         }
      //         break;

      //      default:
      //         // TODO: Select element and show properties
      //         break;
      //   }

      //   // Show element properties
      //   this.Context.ShowObjectProperties(e.Element);
      //}

      void spcPanel_BlockDoubleClick(object sender, CellClickEventArgs e)
      {
         ElementEditorViews form = new ElementEditorViews(e.Element);
         form.ShowDialog(this);
      }

      #endregion

      #region Static Members

      public static void ViewAddPanel(Switchboard panel,
                                      XtraTabControl tabControl,
                                      XtraTabPage tabPage,
                                      SwitchboardDesignControl.CellClickedEventHandler cellClickEvent,
                                      SwitchboardDesignControl.BlockClickedEventHandler blockClickEvent,
                                      SwitchboardDesignControl.BlockDoubleClickedEventHandler blockDoubleClickEvent)
      {
         XtraTabPage tabPanel;

         tabControl.SuspendLayout();

         // Generate the grid
         SwitchboardDesignControl spcPanel = new SwitchboardDesignControl(panel);
         spcPanel.Dock = DockStyle.Fill;
         spcPanel.Location = new System.Drawing.Point(5, 5);
         spcPanel.Name = "grdPanel" + panel.ID;
         spcPanel.BorderStyle = BorderStyle.FixedSingle;

         // Enable grid events
         if (cellClickEvent != null) spcPanel.CellClick += cellClickEvent;
         if (blockClickEvent != null) spcPanel.ElementClick += blockClickEvent;
         if (blockDoubleClickEvent != null) spcPanel.BlockDoubleClick += blockDoubleClickEvent;

         // Generate the tab page
         if (tabPage == null)
         {
            tabPanel = new XtraTabPage();

            // tabPanel.Controls.Add(grdPanel);
            tabPanel.Name = "tabPanel" + panel.ID;
            tabPanel.Padding = new Padding(5);
            tabPanel.Text = panel.Name;
            tabPanel.Image = Switchboard.SmallIcon;
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
