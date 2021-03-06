﻿using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraNavBar;
using Rwm.Otc;
using Rwm.Otc.Diagnostics;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Views
{
   public partial class MainView
   {

      #region Properties

      public bool IsProjectLoaded
      {
         get { return (OTCContext.Project != null); }
      }

      #endregion

      #region Methods

      internal void Exit()
      {
         this.Close();
         Environment.Exit(0);
      }

      internal void Settings()
      {
         SettingsView config = new SettingsView();
         config.ShowDialog(this);

         if (config.DialogResult == DialogResult.OK)
         {
            if (config.RefreshPluginsBar)
               this.LoadToolbox(nbcPlugins);

            this.RefreshViewStatus();
         }
      }

      internal void About()
      {
         AboutView form = new AboutView();
         form.ShowDialog(this);
      }

      /// <summary>
      /// Selects and open a project file.
      /// </summary>
      internal async void ProjectOpen()
      {
         try
         {
            OpenFileDialog form = new OpenFileDialog();
            form.CheckFileExists = true;
            form.Filter = "OTC projects (*.otc)|*.otc|All files|*.*";

            if (form.ShowDialog(this) == DialogResult.OK)
            {
               await OTCContext.OpenProject(form.FileName);

               StudioContext.LastOpenedProjectFile = form.FileName;
               OTCContext.Settings.SaveSettings();
            }

            this.RefreshViewStatus();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      /// <summary>
      /// Opens the last used project (if exists).
      /// </summary>
      internal async Task ProjectOpenLast()
      {
         if (!StudioContext.OpenLastProject)
         {
            return;
         }
         else if (!File.Exists(StudioContext.LastOpenedProjectFile))
         {
            return;
         }

         beiProgress.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

         await OTCContext.OpenProject(StudioContext.LastOpenedProjectFile);
         this.RefreshViewStatus();

         // Show information in console
         StudioContext.LogInformation("Project {0} loaded (from {1})", OTCContext.Project.Name, StudioContext.LastOpenedProjectFile);

         beiProgress.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

         return;
      }

      /// <summary>
      /// Shows the project dialogue to create a new one.
      /// </summary>
      internal void ProjectCreate()
      {
         try
         {
            this.ProjectClose();

            ProjectEditorView form = new ProjectEditorView();
            if (form.ShowDialog(this) == DialogResult.OK)
            {

            }

            this.RefreshViewStatus();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      /// <summary>
      /// Shows the project properties to view/edit the data.
      /// </summary>
      internal void ProjectEdit()
      {
         try
         {
            ProjectEditorView form = new ProjectEditorView(OTCContext.Project);
            form.ShowDialog(this);

            this.RefreshViewStatus();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      /// <summary>
      /// Close the current opened project.
      /// </summary>
      internal void ProjectClose()
      {
         try
         {
            if (this.IsProjectLoaded)
            {
               StudioContext.LastOpenedProjectFile = OTCContext.Project.Filename;
               OTCContext.Settings.SaveSettings();

               OTCContext.Initialize();
            }

            this.RefreshViewStatus();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      /// <summary>
      /// Refresh the status (and data) for all controls.
      /// </summary>
      internal void RefreshViewStatus()
      {
         cmdProjectEdit.Enabled = this.IsProjectLoaded;
         cmdProjectClose.Enabled = this.IsProjectLoaded;

         cmdBarButtonProject.Caption = (this.IsProjectLoaded ? OTCContext.Project.Name : "<no project>");
         cmdBarButtonProject.Enabled = this.IsProjectLoaded;

         nbcPlugins.Enabled = this.IsProjectLoaded;
      }

      public void OpenPluginModule(string moduleID, params object[] args)
      {
         Logger.LogDebug(this, "[CLASS].OpenPluginModule('{0}', {1})", moduleID, args);

         IPluginModule module = StudioContext.PluginManager.GetPluginModule(moduleID);
         if (module != null)
         {
            this.LoadPlugin(module, args);
         }
      }

      private void LoadPlugin(IPluginModuleDescriptor plugin)
      {
         IPluginModule module = StudioContext.PluginManager.GetPluginModule(plugin.ID);
         if (module != null)
         {
            this.LoadPlugin(module, null);
         }
      }

      private void LoadPlugin(IPluginModule module, params object[] args)
      {
         Logger.LogDebug(this, "[CLASS].LoadPlugin([{0}], [args:{1}])", module, args);

         try
         {
            if (module is Form form)
            {
               // Show the main form of the plugin module
               form.MdiParent = this.ParentForm;
               form.Tag = module;
               form.Show();

               // Select the default ribbon page for the plugin module
               if (module.StartupRibbonPage != null && module.StartupRibbonPage is RibbonPage)
               {
                  this.RibbonControl.SelectedPage = module.StartupRibbonPage as RibbonPage;
               }

               // Initialize the module
               module.Initialize(args);

               // Merge status bar (not merged by default)
               if (module.RibbonStatusBar != null)
               {
                  this.RibbonControl.StatusBar.MergeStatusBar((RibbonStatusBar)module.RibbonStatusBar);
               }
            }
            else
            {
               MessageBox.Show("ERROR loading plugin module:" +
                               Environment.NewLine + Environment.NewLine +
                               "The specified class " + module.GetType().Name + " is not a plugin module implementation.", 
                               Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            MessageBox.Show("ERROR loading plugin module:" +
                            Environment.NewLine + Environment.NewLine +
                            ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void LoadToolbox(NavBarControl navBar)
      {
         NavBarGroup group;
         NavBarItem item;

         // Clear navigation bar
         navBar.Items.Clear();
         navBar.Groups.Clear();

         foreach (IPluginPackage package in StudioContext.PluginManager.InstalledPackages)
         {
            group = new NavBarGroup();
            group.Name = "rpgPlugins";
            group.Caption = package.Name;
            group.Expanded = true;
            group.GroupStyle = NavBarGroupStyle.LargeIconsList;
            group.Tag = package;

            foreach (IPluginModuleDescriptor module in package.Modules)
            {
               item = new NavBarItem();
               item.Tag = module;
               item.Caption = module.Caption;
               item.SmallImage = module.SmallIcon;
               item.LargeImage = module.LargeIcon;
               item.LinkClicked += PluginItem_LinkClicked;

               group.ItemLinks.Add(item);
            }

            navBar.Groups.Add(group);
         }
      }

      #endregion

      #region Event Handlers

      /// <summary>
      /// Event captured to launch a plugin module.
      /// </summary>
      void PluginItem_LinkClicked(object sender, NavBarLinkEventArgs e)
      {
         this.LoadPlugin(e.Link.Item.Tag as IPluginModuleDescriptor);
      }

      #endregion

   }
}
