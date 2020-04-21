using System.Drawing;
using Rwm.Otc.UI.Controls;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Control.Modules
{
   public partial class DesignModule : DevExpress.XtraBars.Ribbon.RibbonForm, IPluginModule
   {

      #region Constants

      private const string MODULE_GUID = "4EF23483-C174-424C-B079-36DA9A8FB5D5";

      private const string DOCKPANEL_DESIGN = "dpDesign";

      #endregion

      #region Constructors

      public DesignModule()
      {
         InitializeComponent();
         CreateElementGallery();

         ChkBlockPointer_ItemClick(null, null);
      }

      #endregion

      #region IPluginModule Implementation

      public Image LargeIcon
      {
         get { return global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_DESIGN_32; }
      }

      public Image SmallIcon
      {
         get { return global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_DESIGN_16; }
      }

      public string ID
      {
         get { return MODULE_GUID; }
      }

      public string Caption
      {
         get { return "Layout designer"; }
      }

      public string DocumentName
      {
         get { return this.Caption; }
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
         //DesignToolboxControl ctrl = new DesignToolboxControl(this, this.SelectedSwitchboardPanel);
         //ctrl.Refresh();

         //StudioContext.UI.AddDockPanel(DOCKPANEL_DESIGN,
         //                              "Automation toolbox",
         //                              ctrl,
         //                              global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ROUTE_16,
         //                              DockingStyle.Right);
      }

      /// <summary>
      /// Remove all dockable panels created when the module was loaded.
      /// </summary>
      public void DestoryPanels()
      {
         //StudioContext.UI.RemoveDockPanel(DOCKPANEL_DESIGN);
      }

      #endregion

      #region Event Handlers

      private void CmdPanelAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.PanelAdd();
      }

      private void CmdPanelEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.PanelEdit();
      }

      private void CmdPanelThemes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.ThemesManager();
      }

      private void CmdPrintDigitalReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.PrintDigitalReport();
      }

      private void ChkBlockPointer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

      private void ChkBlockRotate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

      private void ChkBlockDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

      private void ChkBlockAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

      private void CmdMoveUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.MoveUp();
      }

      private void CmdMoveDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.MoveDown();
      }

      private void CmdMoveLeft_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.MoveLeft();
      }

      private void CmdMoveRight_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.MoveRight();
      }

      private void CmdResourcesAreas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.ManageLayoutAreas();
      }

      private void cmdResourcesDecoders_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.ManageDecoders();
      }

      private void CmdResourcesSounds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.ManageLayoutSounds();
      }

      #endregion

   }
}
