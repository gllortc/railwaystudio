using System;
using System.Drawing;
using DevExpress.XtraBars;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Collection.Modules
{
   public partial class ExplorerModule : DevExpress.XtraBars.Ribbon.RibbonForm, IPluginModule
   {

      #region Constants

      private const string MODULE_GUID = "D1117691-F1AE-42C7-BF77-620E0361D711";

      #endregion

      #region Constructors

      public ExplorerModule()
      {
         InitializeComponent();
      }

      #endregion

      #region IPluginModule Implementation

      public string ID
      {
         get { return MODULE_GUID; }
      }

      public object StartupRibbonPage
      {
         get { return ribbon.Pages[0]; }
      }

      public object RibbonStatusBar
      {
         get { return ribbonStatusBar; }
      }

      public Image LargeIcon
      {
         get { return Properties.Resources.ICO_APP_32; }
      }

      public Image SmallIcon
      {
         get { return Properties.Resources.ICO_DATAMANAGER_16; }
      }

      public string Caption
      {
         get { return "Collection Explorer"; }
      }

      public string DocumentName
      {
         get { return string.Empty; }
      }

      public bool IsMultiInstance
      {
         get { return false; }
      }

      public bool UseProject
      {
         get { return true; }
      }

      public void Initialize(params object[] args)
      {
         // Check the database version
         //CollectionDataEntity cde = new CollectionDataEntity(OTCContext.Settings);
         //cde.CheckDatabase();

         // Create the main tree list
         this.CreateTreeList();
      }

      /// <summary>
      /// Add docable panels to environment.
      /// </summary>
      public void CreatePanels()
      {
         // Nothing to do
      }

      /// <summary>
      /// Remove all dockable panels created when the module was loaded.
      /// </summary>
      public void DestoryPanels()
      {
         // Nothing to do
      }

      #endregion

      #region Event Handlers

      private void TlsFolders_Click(object sender, EventArgs e)
      {
         this.Refresh();
      }

      private void CmdDataAdd_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.AddItem();
      }

      private void CmdDataEdit_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.EditItem();
      }

      private void CmdDataDelete_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.DeleteItem();
      }

      private void CmdReportsDigitalAddresses_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.ReportsDigitalAddresses();
      }

      private void CmdPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.Print();
      }

      private void GrdDataView_DoubleClick(object sender, EventArgs e)
      {
         if (grdDataView.SelectedRowsCount > 0)
         {
            this.EditItem();
         }
      }

        #endregion

    }
}