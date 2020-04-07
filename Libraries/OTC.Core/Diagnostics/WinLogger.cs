using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Rwm.Otc.Configuration;

namespace Rwm.Otc.Diagnostics
{
   /// <summary>
   /// Debugger class that allow applications to write log files.
   /// </summary>
   /// <remarks>
   /// The current log file is located on:
   /// [DLL or APP path]\LOGS\[YEAR]\[MONTH]\RWM_[Date in format yyyyMMdd].log
   /// </remarks>
   public class WinLogger : ILogger
   {

      #region Constants

      /// <summary>Name of the windows LOG file.</summary>
      public const string SETTING_LOG_NAME = "name";

      /// <summary>Source for the current LOG file.</summary>
      public const string SETTING_LOG_SOURCE = "source";

      #endregion

      #region Properties

      /// <summary>
      /// Gets the configuration instance of the current logger module.
      /// </summary>
      public XmlSettingsItem Settings { get; private set; }

      internal EventLog Log { get; private set; }

      /// <summary>
      /// Gets the current LOG level.
      /// </summary>
      public Logger.LogLevel CurrentLogLevel
      {
         get { return Logger.StringToLogLevel(this.Settings.GetString(Logger.SETTING_LOG_LEVEL)); }
      }

      #endregion

      #region ILogger Implementation

      /// <summary>
      /// Initialize the logger with the settings loaded.
      /// </summary>
      /// <param name="settings">Settings for the corresponding plugin module.</param>
      public void Initialize(XmlSettingsItem settings)
      {
         this.Settings = settings;

         // Get the service name
         string name = this.Settings.GetString(SETTING_LOG_NAME, Application.ProductName);

         // Get the service source
         string source = this.Settings.GetString(SETTING_LOG_SOURCE, string.Empty);
         if (string.IsNullOrEmpty(source))
         {
            source = "RWM";
         }

         try
         {
            // Ensure that the log source exists
            if (!EventLog.SourceExists(source))
            {
               EventLog.CreateEventSource(source, name);
            }
         }
         catch 
         {
            Application.DoEvents();
         }

         // Generate log instance
         this.Log = new EventLog();
         this.Log.Log = name;
         this.Log.Source = source;
      }

      public void LogInfo(object sender, string message, params object[] args)
      {
         WriteLogEntry(Logger.LogLevel.Info, sender, message, args);
      }

      public void LogWarning(object sender, string message, params object[] args)
      {
         WriteLogEntry(Logger.LogLevel.Warn, sender, message, args);
      }

      public void LogError(object sender, string message, params object[] args)
      {
         WriteLogEntry(Logger.LogLevel.Error, sender, message, args);
      }

      public void LogDebug(object sender, string message, params object[] args)
      {
         WriteLogEntry(Logger.LogLevel.Debug, sender, message, args);
      }

      public void LogCritical(object sender, string message, params object[] args)
      {
         WriteLogEntry(Logger.LogLevel.Critical, sender, message, args);
      }

      #endregion

      #region Private Members

      private void WriteLogEntry(Logger.LogLevel level, object sender, string message, params object[] args)
      {
         try
         {
            // Generate text for entry
            StringBuilder txt = new StringBuilder();
            txt.AppendLine(string.Format(message, args));

            this.Log.WriteEntry(txt.ToString(), ConvertLogLevel(level));

            // Set all used instances to null to minimize memory usage
            txt = null;
         }
         catch 
         {
            // try to write on an existing source on different Windows LOG file
            try
            {
               this.Log.Log = string.Empty;
            }
            catch
            {
               
            }
         }
      }

      private EventLogEntryType ConvertLogLevel(Logger.LogLevel level)
      {
         switch (level)
         {
            case Logger.LogLevel.Info:
               return EventLogEntryType.Information;

            case Logger.LogLevel.Warn:
               return EventLogEntryType.Warning;

            case Logger.LogLevel.Debug:
               return EventLogEntryType.SuccessAudit;

            default:
               return EventLogEntryType.Error;
         }
      }

      #endregion

   }
}
