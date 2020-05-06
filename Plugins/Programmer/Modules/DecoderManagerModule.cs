using System;
using DevExpress.XtraBars;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Designer.Modules
{
   public partial class DecoderManagerModule : DevExpress.XtraBars.Ribbon.RibbonForm, IPluginModule
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="DecoderManagerModule"/>.
      /// </summary>
      public DecoderManagerModule()
      {
         InitializeComponent();

         this.Description = new DecoderManagerModuleDescriptor();
      }

      #endregion

      #region IPluginModule Implementation

      /// <summary>
      /// Gets the plugin module description properties.
      /// </summary>
      public IPluginModuleDescriptor Description { get; private set; }

      //public string ID
      //{
      //   get { return MODULE_GUID; }
      //}

      public object StartupRibbonPage
      {
         get { return ribbon.Pages[0]; }
      }

      public object RibbonStatusBar
      {
         get { return ribbonStatusBar; }
      }

      //public Image LargeIcon
      //{
      //   get { return Properties.Resources.ICO_MODULE_DEVICE_MANAGER_32; }
      //}

      //public Image SmallIcon
      //{
      //   get { return Properties.Resources.ICO_DEVICE_FOLDER_16; }
      //}

      //public string Caption
      //{
      //   get { return "Digital device manager"; }
      //}

      public string DocumentName
      {
         get { return this.Description.Caption; }
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
         this.Text = this.Description.Caption;

         // Create the main tree list
         this.InitializeTreeList();
         this.RefreshTreeList();
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

      private void TlsDecoders_DoubleClick(object sender, EventArgs e)
      {
         this.EditItem();
      }

      private void TlsDecoders_Click(object sender, EventArgs e)
      {
         cmdDecoderProgram.Enabled = false;
         if (tlsDecoders.Selection.Count > 0)
         {
            DevExpress.XtraTreeList.Nodes.TreeListNode node = tlsDecoders.Selection[0];
            if (node.Tag != null && node.Tag is Otc.Layout.AccessoryDecoder)
            {
               cmdDecoderProgram.Enabled = true;
            }
         }
      }

      private void CmdAccessoryDecoderAdd_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.AccessoryDecoderAdd();
      }

      private void CmdDeviceAddRwmAcc_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.RwmAccessoryDecoderAdd();
      }

      private void CmdDeviceAddGenericFb_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.FeedbackEncoderAdd();
      }

      private void CmdDeviceEdit_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.EditItem();
      }

      private void CmdDeviceDelete_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.DeleteItem();
      }

      private void CmdDecoderProgram_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.DecoderProgram();
      }

      private void CmdViewByType_CheckedChanged(object sender, ItemClickEventArgs e)
      {
         this.SetListByType();
      }

      private void CmdViewByArea_CheckedChanged(object sender, ItemClickEventArgs e)
      {
         this.SetListByArea();
      }

      private void CmdRefreshView_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.RefreshTreeList();
      }

      private void CmdReportsDigitalAddresses_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.ReportsDigitalAddresses();
      }

      #endregion

   }
}