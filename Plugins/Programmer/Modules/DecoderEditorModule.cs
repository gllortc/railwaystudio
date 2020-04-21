using System;
using System.Drawing;
using DevExpress.XtraBars;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Designer.Modules
{
   public partial class DecoderEditorModule : DevExpress.XtraBars.Ribbon.RibbonForm, IPluginModule
   {

      #region Constants

      internal const string MODULE_GUID = "14BB4991-CC6A-4D3F-BB1C-E882DA6F6C26";

      #endregion

      #region Constructors

      public DecoderEditorModule()
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
         get { return Properties.Resources.ICO_MODULE_DEVICE_EDITOR_32; }
      }

      public Image SmallIcon
      {
         get { return Properties.Resources.ICO_DEVICE_16; }
      }

      public string Caption
      {
         get { return "Decoder editor"; }
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
         // this.CreateTreeList();
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

      private void DecoderEditorModule_Load(object sender, EventArgs e)
      {
         rtfOutput.ActiveView.BackColor = Color.DarkGray;
      }

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

      private void CmdBurn_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.DecoderProgram();
      }

        #endregion

    }
}