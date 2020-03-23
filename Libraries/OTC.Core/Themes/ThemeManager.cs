using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Utils;

namespace Rwm.Otc.Themes
{

   /// <summary>
   /// Manage the swithcboard panel blocks persistence in database.
   /// </summary>
   public class ThemeManager
   {

      #region Constants

      // SQL declarations
      internal static string SETTINGS_THEMES_KEY = "otc.theme";

      internal static string SETTINGS_THEME_CLASS = "theme.class";
      internal static string SETTINGS_THEME_PATH = "theme.path";

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="ThemeManager"/>.
      /// </summary>
      /// <param name="settings">The current application settings.</param>
      public ThemeManager(XmlSettingsManager settings)
      {
         this.Settings = settings;

         // Load available themes
         this.Themes = this.GetAll();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the current application settings.
      /// </summary>
      public XmlSettingsManager Settings { get; private set; }

      /// <summary>
      /// Gets the current application settings.
      /// </summary>
      public List<ITheme> Themes { get; private set; }

      /// <summary>
      /// Gets a value indicating if there is a selected theme.
      /// </summary>
      public bool IsThemeSelected
      {
         get { return (this.GetTheme() != null); }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Sets the theme used to render the switchboard panels.
      /// </summary>
      public void SetTheme(ITheme theme)
      {
         this.SetTheme(theme.GetType());
      }

      /// <summary>
      /// Sets the theme used to render the switchboard panels.
      /// </summary>
      public void SetTheme(Type type)
      {
         Logger.LogDebug(this, "[CLASS].SetTheme([{0}])", type.FullName);

         try
         {
            XmlSettingsItem item = new XmlSettingsItem(ThemeManager.SETTINGS_THEMES_KEY, string.Empty);
            item.AddSetting(ThemeManager.SETTINGS_THEME_PATH, ReflectionUtils.GetAssemblyFile(type));
            item.AddSetting(ThemeManager.SETTINGS_THEME_CLASS, type.FullName);

            this.Settings.AddSetting(item);
            this.Settings.SaveSettings();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      /// <summary>
      /// Sets the theme used to render the switchboard panels.
      /// </summary>
      public ITheme GetTheme()
      {
         XmlSettingsItem item = null;
         ITheme theme = null;

         Logger.LogDebug(this, "[CLASS].GetTheme()");

         try
         {
            if (this.Themes == null || this.Themes.Count <= 0) this.GetAll();

            item = this.Settings.GetItem(ThemeManager.SETTINGS_THEMES_KEY);
            if (item != null && !string.IsNullOrWhiteSpace(item.Value))
            {
               Assembly assembly = Assembly.LoadFrom(item.GetString(ThemeManager.SETTINGS_THEME_PATH));
               Type type = assembly.GetType(item.GetString(ThemeManager.SETTINGS_THEME_CLASS));

               theme = (ITheme)Activator.CreateInstance(type);
            }

            if (theme == null && this.Themes.Count > 0)
            {
               theme = this.Themes[0];
            }

            return theme;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      /// <summary>
      /// Get all theme instances included in the application directory.
      /// </summary>
      /// <returns>A lis of all theme instances.</returns>
      public List<ITheme> GetAll()
      {
         Assembly assembly;
         List<ITheme> themes = new List<ITheme>();

         Logger.LogDebug(this, "[CLASS].GetAll()");

         try
         {
            foreach (string path in System.IO.Directory.GetFiles(ReflectionUtils.GetCurrentAssemblyPath(), "*.dll"))
            {
               try
               {
                  assembly = Assembly.LoadFile(path);
                  foreach (Type type in assembly.GetTypes())
                  {
                     if (typeof(ITheme).IsAssignableFrom(type) && !type.IsInterface)
                     {
                        themes.Add((ITheme)Activator.CreateInstance(type));
                     }
                  }
               }
               catch (Exception ex)
               {
                  Logger.LogError(this, ex);
               }
            }

            if (themes.Count <= 0)
            {
               throw new Exception("There are no available themes.");
            }
            
            return themes;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      /// <summary>
      /// Gets all themes in an instance of <see cref="DataTable"/>.
      /// </summary>
      /// <returns>The requested instance of <see cref="DataTable"/>.</returns>
      public DataTable Find()
      {
         DataTable dt;

         Logger.LogDebug(this, "[CLASS].GetAllAsDataTable()");

         try
         {
            dt = new DataTable("Themes");
            dt.Columns.Add("GUID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Type", typeof(Type));

            foreach (ITheme item in this.GetAll())
            {
               dt.Rows.Add(new object[] { item.ID,
                                          item.Name,
                                          string.Empty,
                                          item.GetType() });
            }

            return dt;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      #endregion

   }
}
