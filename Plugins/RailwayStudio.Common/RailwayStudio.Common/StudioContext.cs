﻿using DevExpress.XtraBars.Alerter;
using Rwm.Otc;

namespace Rwm.Studio.Plugins.Common
{
   public static class StudioContext
   {

      #region Constants

      const string SETUP_KEY_UI_SKIN = "rwm.studio.ui.skin-name";
      const string SETUP_KEY_PROJECT_LASTLOAD = "rwm.studio.projects.last.reload";
      const string SETUP_KEY_PROJECT_LASTOPEN = "rwm.studio.projects.last.path";

      #endregion

      #region Fields

      private static UI sUI = null;
      private static Find sFind = null;
      private static Utils sUtils = null;

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

      public static Utils Utils
      {
         get
         {
            if (StudioContext.sUtils == null) StudioContext.sUtils = new Utils();
            return StudioContext.sUtils;
         }
      }

      public static PluginManager PluginManager { get; private set; } = null;

      public static IContainerView MainView { get; set; } = null;

      public static string SkinName
      {
         get { return OTCContext.Settings.GetString(StudioContext.SETUP_KEY_UI_SKIN, "DevExpress Style"); }
         set { OTCContext.Settings.AddSetting(StudioContext.SETUP_KEY_UI_SKIN, value); }
      }

      public static bool OpenLastProject
      {
         get { return OTCContext.Settings.GetBoolean(StudioContext.SETUP_KEY_PROJECT_LASTLOAD); }
         set { OTCContext.Settings.AddSetting(StudioContext.SETUP_KEY_PROJECT_LASTLOAD, value); }
      }

      public static string LastOpenedProjectFile
      {
         get { return OTCContext.Settings.GetString(StudioContext.SETUP_KEY_PROJECT_LASTOPEN, string.Empty); }
         set { OTCContext.Settings.AddSetting(StudioContext.SETUP_KEY_PROJECT_LASTOPEN, value); }
      }

      #endregion

      #region Methods

      public static void Initialize(IContainerView mainView)
      {
         StudioContext.MainView = mainView;

         // Load installed packages
         StudioContext.PluginManager = new PluginManager();
         StudioContext.PluginManager.LoadPackages();
      }

      public static void OpenPluginModule(string guid, params object[] args)
      {
         StudioContext.MainView.OpenPluginModule(guid, args);
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

      public static void LogDebug(string message)
      {
         StudioContext.MainView.LogConsole.Debug(message);
      }

      public static void LogDebug(string message, params object[] args)
      {
         StudioContext.MainView.LogConsole.Debug(string.Format(message, args));
      }

      public static void AlertError(string caption, string text, bool playSound = true)
      {
         AlertInfo ai = new AlertInfo(string.Format("<b>{0}</b>", caption),
                                      text,
                                      null,
                                      Properties.Resources.ICO_ERROR_32,
                                      null,
                                      true);
         StudioContext.MainView.AlertControl.Show(StudioContext.MainView.ParentForm, ai);

         if (playSound)
            System.Media.SystemSounds.Exclamation.Play();
      }

      public static void AlertInformation(string caption, string text)
      {
         AlertInfo ai = new AlertInfo(string.Format("<b>{0}</b>", caption),
                                      text,
                                      null,
                                      Properties.Resources.ICO_INFORMATION_32,
                                      null,
                                      true);
         StudioContext.MainView.AlertControl.Show(StudioContext.MainView.ParentForm, ai);
      }

      #endregion

   }
}
