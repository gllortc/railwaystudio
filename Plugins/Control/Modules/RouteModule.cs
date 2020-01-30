using System;
using System.Drawing;
using DevExpress.XtraBars.Docking;
using RailwayStudio.Common;
using Rwm.Otc.UI.Controls;
using Rwm.Studio.Plugins.Control.Controls;

namespace Rwm.Studio.Plugins.Control.Modules
{
   public partial class RouteModule : DevExpress.XtraBars.Ribbon.RibbonForm, IPluginModule
   {

      #region Constants

      private const string MODULE_GUID = "6269D397-85FB-45A8-8FB5-EECD59640B29";

      private const string DOCKPANEL_DESIGN = "dpDesign";

      #endregion

      #region Constructors

      public RouteModule()
      {
         InitializeComponent();
         RefreshRouteList();
         CreateElementGallery();

         chkBlockPointer_ItemClick(null, null);
      }

      #endregion

      #region IPluginModule Implementation

      public Image LargeIcon
      {
         get { return Properties.Resources.ICO_DESIGN_32; }
      }

      public Image SmallIcon
      {
         get { return Properties.Resources.ICO_DESIGN_16; }
      }

      public string ModuleID
      {
         get { return MODULE_GUID; }
      }

      public string ModuleName
      {
         get { return "Route designer"; }
      }

      public string DocumentName
      {
         get { return this.ModuleName; }
      }

      public bool IsMultiInstance
      {
         get { return true; }
      }

      public object StartupRibbonPage
      {
         get { return rbpDesign; }
      }

      public object RibbonStatusBar
      {
         get { return ribbonStatusBar; }
      }

      public bool UseProject
      {
         get { return true; }
      }

      public void Initialize(params object[] args)
      {
         this.ShowPanels();
      }

      /// <summary>
      /// Add docable panels to environment.
      /// </summary>
      public void CreatePanels()
      {
         DesignToolboxControl ctrl = new DesignToolboxControl(this, this.SelectedSwitchboardPanel);
         ctrl.Refresh();

         StudioContext.UI.AddDockPanel(DOCKPANEL_DESIGN,
                                       "Automation toolbox",
                                       ctrl,
                                       global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_16,
                                       DockingStyle.Right);
      }

      /// <summary>
      /// Remove all dockable panels created when the module was loaded.
      /// </summary>
      public void DestoryPanels()
      {
         StudioContext.UI.RemoveDockPanel(DOCKPANEL_DESIGN);
      }

      #endregion

      #region Event Handlers

      private void cmdPanelAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.PanelAdd();
      }

      private void cmdPanelEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.PanelEdit();
      }

      private void cmdPanelThemes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.ThemesManager();
      }

      private void cmdPrintDigitalReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.PrintDigitalReport();
      }

      private void chkBlockPointer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         chkBlockPointer.Checked = true;
         chkBlockRotate.Checked = false;
         chkBlockDelete.Checked = false;
         chkBlockAdd.Checked = false;

         if (this.SelectedSwitchboardPanel != null)
         {
            this.SelectedSwitchboardPanel.SelectedDesignTool = SwitchboardDesignControl.DesignTools.Pointer;
         }
      }

      private void chkBlockRotate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         chkBlockPointer.Checked = false;
         chkBlockRotate.Checked = true;
         chkBlockDelete.Checked = false;
         chkBlockAdd.Checked = false;

         if (this.SelectedSwitchboardPanel != null)
         {
            this.SelectedSwitchboardPanel.SelectedDesignTool = SwitchboardDesignControl.DesignTools.Rotate;
         }
      }

      private void chkBlockDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         chkBlockPointer.Checked = false;
         chkBlockRotate.Checked = false;
         chkBlockDelete.Checked = true;
         chkBlockAdd.Checked = false;

         if (this.SelectedSwitchboardPanel != null)
         {
            this.SelectedSwitchboardPanel.SelectedDesignTool = SwitchboardDesignControl.DesignTools.Delete;
         }
      }

      private void chkBlockAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         chkBlockPointer.Checked = false;
         chkBlockRotate.Checked = false;
         chkBlockDelete.Checked = false;
         chkBlockAdd.Checked = true;

         if (this.SelectedSwitchboardPanel != null)
         {
            this.SelectedSwitchboardPanel.SelectedDesignTool = SwitchboardDesignControl.DesignTools.Add;
         }
      }

      private void cmdMoveUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.MoveUp();
      }

      private void cmdMoveDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.MoveDown();
      }

      private void cmdMoveLeft_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.MoveLeft();
      }

      private void cmdMoveRight_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.MoveRight();
      }

      #endregion

   }
}
