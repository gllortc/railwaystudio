﻿using System;
using DevExpress.XtraBars;
using Rwm.Otc.Trains;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Collection.Modules
{
   public partial class ModelModule : DevExpress.XtraBars.Ribbon.RibbonForm, IPluginModule
   {

      //#region Constants

      //internal const string MODULE_GUID = "8458EC08-4224-42B0-8CF5-84FCD5AAFB3C";

      //#endregion

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

      //public string ID
      //{
      //   get { return ModelModule.MODULE_GUID; }
      //}

      //public Image LargeIcon
      //{
      //   get { return Properties.Resources.ICO_MODEL_EDIT_32; }
      //}

      //public Image SmallIcon
      //{
      //   get { return Properties.Resources.ICO_MODEL_EDIT_16; }
      //}

      //public string Caption
      //{
      //   get { return "Model editor"; }
      //}

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

      public void Initialize(params object[] args)
      {
         this.UpdatePicture = false;

         this.FillLists();

         // Load requested model
         if (args != null && args.Length >= 1 && args[0].GetType() == typeof(Int64))
         {
            this.CurrentModel = Train.Get((Int64)args[0]); // OTCContext.Project.TrainManager.ModelDAO.GetByID((Int64)args[0]);
         }
         
         this.SetData();
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

      private void picImage_EditValueChanged(object sender, EventArgs e)
      {
         this.UpdatePicture = true;
      }

      private void cmdFileSave_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.Save();
      }

      private void cmdProperties_Click(object sender, EventArgs e)
      {
         pmnProperties.ShowPopup(MousePosition);
      }

      #endregion

   }
}