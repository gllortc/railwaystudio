﻿using RailwayStudio.Common.Views;
using Rwm.Otc;
using Rwm.Otc.Data;
using Rwm.Otc.Systems;
using System.IO;
using System.Windows.Forms;

namespace RailwayStudio.Common
{
   public static class StudioContext
   {

      #region Constants

      public const string SETUP_KEY_PROJECT_LASTLOAD = "rwm.studio.projects.last-load";
      public const string SETUP_KEY_PROJECT_LASTOPEN = "rwm.studio.projects.last-open";

      #endregion

      #region Fields

      private static UI sUI = null;
      private static Find sFind = null;

      #endregion

      #region Properties

      public static UI UI
      {
         get
         {
            if (StudioContext.sUI == null) StudioContext.sUI = new UI();
            return StudioContext.sUI;
         }
      }

      public static Find Find
      {
         get
         {
            if (StudioContext.sFind == null) StudioContext.sFind = new Find();
            return StudioContext.sFind;
         }
      }

      public static IContainerView MainView { get; set; }

      #endregion

      #region Methods

      public static void Initialize(IContainerView mainView)
      {
         StudioContext.MainView = mainView;
      }

      public static void CreateProject(IWin32Window owner)
      {
         ProjectEditorView form = new ProjectEditorView();
         form.ShowDialog(owner);

         if (form.DialogResult == DialogResult.OK)
         {
            OTCContext.Settings.AddSetting(StudioContext.SETUP_KEY_PROJECT_LASTOPEN, OTCContext.Project.Filename);
            OTCContext.Settings.SaveSettings();

            // Link the digital system to the output console
            OTCContext.Project.OnDigitalSystemInfo += DigitalSystem_SystemInformation;
         }
      }

      public static void OpenProject(IWin32Window owner)
      {
         OpenFileDialog form = new OpenFileDialog();
         form.CheckFileExists = true;
         form.Filter = "OTC projects|*.otc|All files|*.*";

         if (form.ShowDialog(owner) == System.Windows.Forms.DialogResult.OK)
         {
            // Load project
            OTCContext.OpenProject(form.FileName);

            // Register listeners
            OTCContext.Project.DigitalSystem.SystemInformation += DigitalSystem_SystemInformation;

            OTCContext.Settings.AddSetting(StudioContext.SETUP_KEY_PROJECT_LASTOPEN, form.FileName);
            OTCContext.Settings.SaveSettings();
         }
      }

      public static void LoadLastProject()
      {
         string lastFile = string.Empty;

         if (!OTCContext.Settings.GetBoolean(StudioContext.SETUP_KEY_PROJECT_LASTLOAD))
         {
            return;
         }

         lastFile = OTCContext.Settings.GetString(StudioContext.SETUP_KEY_PROJECT_LASTOPEN, "<nofile>");
         if (!File.Exists(lastFile))
         {
            return;
         }

         OTCContext.Settings.AddSetting(DataConsumer.SETTINGS_DB_CURRENT, lastFile);

         // Load project
         OTCContext.OpenProject(lastFile);

         // Register listeners
         OTCContext.Project.DigitalSystem.SystemInformation += DigitalSystem_SystemInformation;

         // Show information in console
         StudioContext.LogInformation("Project {0} loaded (from {1})",
                                      Path.GetFileName(lastFile),
                                      Path.GetFullPath(lastFile));
      }

      public static void LogInformation(string message)
      {
         StudioContext.MainView.LogConsole.Information(message);
      }

      public static void LogInformation(string message, params object[] args)
      {
         StudioContext.MainView.LogConsole.Information(string.Format(message, args));
      }

      public static void LogWarning(string message)
      {
         StudioContext.MainView.LogConsole.Warning(message);
      }

      public static void LogWarning(string message, params object[] args)
      {
         StudioContext.MainView.LogConsole.Warning(string.Format(message, args));
      }

      public static void LogError(string message)
      {
         StudioContext.MainView.LogConsole.Error(message);
      }

      public static void LogError(string message, params object[] args)
      {
         StudioContext.MainView.LogConsole.Error(string.Format(message, args));
      }

      #endregion

      #region Event Handlers

      static void DigitalSystem_SystemInformation(object sender, SystemInfoEventArgs e)
      {
         switch (e.Type)
         {
            case SystemInfoEventArgs.MessageType.Error:
               StudioContext.LogError(e.Message);
               break;

            case SystemInfoEventArgs.MessageType.Warning:
               StudioContext.LogWarning(e.Message);
               break;

            default:
               StudioContext.LogInformation(e.Message);
               break;
         }
      }

      #endregion

   }
}