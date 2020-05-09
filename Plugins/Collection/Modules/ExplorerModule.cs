using System;
using DevExpress.XtraBars;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Collection.Modules
{
   public partial class ExplorerModule : DevExpress.XtraBars.Ribbon.RibbonForm, IPluginModule
   {

      #region Constructors

      public ExplorerModule()
      {
         InitializeComponent();

         this.Description = new ExplorerModuleDescriptor();
      }

      #endregion

      #region IPluginModule Implementation

      /// <summary>
      /// Gets the plugin module description properties.
      /// </summary>
      public IPluginModuleDescriptor Description { get; private set; }

      public object StartupRibbonPage
      {
         get { return ribbon.Pages[0]; }
      }

      public object RibbonStatusBar
      {
         get { return ribbonStatusBar; }
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
         // Create the main tree list
         this.CreateTreeList();
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