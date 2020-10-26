using System;
using DevExpress.XtraBars;
using Rwm.Otc.Trains;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Collection.Modules
{
   public partial class ModelModule : DevExpress.XtraBars.Ribbon.RibbonForm, IPluginModule
   {

      #region Constructors

      public ModelModule()
      {
         InitializeComponent();

         this.Description = new ModelModuleDescriptor();
         this.CurrentModel = new Train();
      }

      #endregion

      #region IPluginModule Implementation

      /// <summary>
      /// Gets the plugin module description properties.
      /// </summary>
      public IPluginModuleDescriptor Description { get; private set; }

      public string DocumentName
      {
         get { return this.CurrentModel.Name; }
      }

      public bool IsMultiInstance
      {
         get { return true; }
      }

      public bool UseProject
      {
         get { return true; }
      }

      public object StartupRibbonPage
      {
         get { return rbpModel; }
      }

      public object RibbonStatusBar
      {
         get { return ribbonStatusBar; }
      }

      /// <summary>
      /// Initialize the plug-in module.
      /// </summary>
      /// <param name="args">args[0] (optional): Train instance unique identifier.</param>
      public void Initialize(params object[] args)
      {
         Train train;

         this.UpdatePicture = false;

         if (args != null && args.Length >= 1 && args[0].GetType() == typeof(long))
         {
            // Load requested model for edit
            train = Train.Get((long)args[0]);
         }
         else
         {
            train = new Train();
         }

         this.MapModelToView(train);
      }

      #endregion

      #region Event Handlers

      private void TabModel_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
      {
         rpgEditClipboard.Visible = (tabModel.SelectedTabPage == tabModelMaintenance);
         rpgEditFormat.Visible = (tabModel.SelectedTabPage == tabModelMaintenance);
         rpgEditParagraph.Visible = (tabModel.SelectedTabPage == tabModelMaintenance);
      }

      private void PicImage_EditValueChanged(object sender, EventArgs e)
      {
         this.UpdatePicture = true;
      }

      private void CmdFileSave_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.Save();
      }

      private void CmdProperties_Click(object sender, EventArgs e)
      {
         pmnProperties.ShowPopup(MousePosition);
      }

      #endregion

   }
}