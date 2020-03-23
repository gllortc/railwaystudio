using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraNavBar;
using RailwayStudio.Common;
using Rwm.Otc;
using Rwm.Otc.Diagnostics;

namespace Rwm.Studio.Views.Controllers
{
   public class MainController 
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="MainController"/>.
      /// </summary>
      /// <param name="settings">The current application settings.</param>
      /// <param name="mainView">Main vire (form).</param>
      public MainController(IContainerView mainView)
      {
         Initialize();

         this.MainView = mainView;

         // Enable application visual styles
         DevExpress.Skins.SkinManager.EnableFormSkins();
         DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
         DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = OTCContext.Settings.GetString(Program.SETUP_KEY_UI_SKIN, "DevExpress Style");
      }

      #endregion

      #region Properties

      internal IContainerView MainView { get; private set; }

      internal List<PluginModule> Modules { get; private set; }

      public object[] PluginArguments
      {
         get { throw new System.NotImplementedException(); }
      }

      #endregion

      #region Event Handlers

      /// <summary>
      /// Event captured to remove all panels created by the module.
      /// </summary>
      void PluginModule_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (sender is IPluginModule module)
         {
            module.DestoryPanels();
         }
      }

      /// <summary>
      /// Event captured to launch a plugin module.
      /// </summary>
      void PluginItem_LinkClicked(object sender, NavBarLinkEventArgs e)
      {
         this.LoadPlugin(e.Link.Item.Tag as PluginModule);
      }

      #endregion

      #region Methods

      public bool OpenProject()
      {
         try
         {
            StudioContext.OpenProject(this.MainView.HwndHandle);
            return true;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            MessageBox.Show("ERROR loading project: " + Environment.NewLine + Environment.NewLine + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
         }
      }

      public bool CreateProject()
      {
         try
         {
            StudioContext.CreateProject(this.MainView.HwndHandle);
            return true;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            MessageBox.Show("ERROR creating project: " + Environment.NewLine + Environment.NewLine + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
         }
      }

      public void Exit()
      {
         this.MainView.Close();
         Environment.Exit(0);
      }

      public void Configure()
      {
         SettingsView config = new SettingsView();
         config.ShowDialog(this.MainView.HwndHandle);
      }

      internal void About()
      {
         AboutView form = new AboutView();
         form.ShowDialog(this.MainView.HwndHandle);
      }

      public void LoadToolbox(NavBarControl navBar)
      {
         NavBarGroup group;
         NavBarItem item;
         PluginModule module;
         IPlugin pluginInstance;
         IPluginModule moduleInstance;

         this.Modules = new List<PluginModule>();

         PluginManager manager = new PluginManager();
         foreach (Plugin plugin in manager.GetAll())
         {
            if (File.Exists(plugin.File))
            {
               group = new NavBarGroup();
               group.Name = "rpgPlugins";
               group.Caption = plugin.Name;
               group.Expanded = true;
               group.GroupStyle = NavBarGroupStyle.LargeIconsList;

               Assembly lib = Assembly.LoadFile(plugin.File);
               foreach (Type type in lib.GetExportedTypes())
               {
                  module = new PluginModule();
                  module.ID = string.Empty;
                  module.Filename = plugin.File;
                  module.Class = type.FullName;

                  if (type.IsClass && typeof(IPlugin).IsAssignableFrom(type))
                  {
                     pluginInstance = Activator.CreateInstance(type) as IPlugin;
                     group.Name = pluginInstance.Name;
                     group.SmallImage = pluginInstance.SmallIcon;
                     group.LargeImage = pluginInstance.LargeIcon;
                  }
                  else if (type.IsClass && typeof(IPluginModule).IsAssignableFrom(type))
                  {
                     moduleInstance = Activator.CreateInstance(type) as IPluginModule;
                     if (moduleInstance != null)
                     {
                        module.ID = moduleInstance.ModuleID;

                        item = new NavBarItem();
                        item.Tag = module;
                        item.Caption = moduleInstance.ModuleName;
                        item.SmallImage = moduleInstance.SmallIcon;
                        item.LargeImage = moduleInstance.LargeIcon;
                        item.LinkClicked += PluginItem_LinkClicked;

                        group.ItemLinks.Add(item);

                        this.Modules.Add(module);
                     }
                  }
               }

               navBar.Groups.Add(group);
            }
         }
      }

      public void OpenPluginModule(string className, params object[] args)
      {
         Logger.LogDebug(this, "[CLASS].OpenPluginModule('{0}', {1})", className, args);

         foreach (PluginModule module in this.Modules)
         {
            if (module.Class.Equals(className) || module.ID.Equals(className))
            {
               this.LoadPlugin(module, args);
            }
         }
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.Modules = new List<PluginModule>();
      }

      private void LoadPlugin(PluginModule plugin)
      {
         this.LoadPlugin(plugin, null);
      }

      private void LoadPlugin(PluginModule plugin, params object[] args)
      {
         try
         {
            Assembly lib = Assembly.LoadFile(plugin.Filename);
            Type type = lib.GetType(plugin.Class);
            IPluginModule moduleInstance = Activator.CreateInstance(type) as IPluginModule;

            if (moduleInstance is Form form)
            {
               // Show the main form of the plugin module
               form.MdiParent = this.MainView.ParentForm;
               form.Tag = moduleInstance;
               form.FormClosing += PluginModule_FormClosing;
               form.Show();

               // Select the default ribbon page for the plugin module
               if (moduleInstance.StartupRibbonPage != null && moduleInstance.StartupRibbonPage is RibbonPage)
               {
                  this.MainView.RibbonControl.SelectedPage = moduleInstance.StartupRibbonPage as RibbonPage;
               }

               // Initialize the module
               moduleInstance.Initialize(args);
               moduleInstance.CreatePanels();

               // Merge status bar (not merged by default)
               if (moduleInstance.RibbonStatusBar != null)
               {
                  this.MainView.RibbonControl.StatusBar.MergeStatusBar((RibbonStatusBar)moduleInstance.RibbonStatusBar);
               }
            }
            else
            {
               MessageBox.Show("ERROR loading plugin module:" +
                               Environment.NewLine + Environment.NewLine +
                               "The specified class " + plugin.GetType().Name + " is not a plugin module implementation.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

      #endregion

   }
}
