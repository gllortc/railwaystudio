using Rwm.Otc.Configuration;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Rwm.Otc.Diagnostics
{
   /// <summary>
   /// Debugger class that allow applications to write log files.
   /// </summary>
   /// <remarks>
   /// The current log file is located on:
   /// [DLL or APP path]\LOGS\[YEAR]\[MONTH]\EMDEP_[Date in format yyyyMMdd].log
   /// </remarks>
   public class FileLogger : ILogger
   {

      #region Properties

      /// <summary>
      /// Gets the configuration instance of the current logger module.
      /// </summary>
      public XmlSettingsItem Settings { get; private set; }

      /// <summary>
      /// Gets the full name of the current LOG file.
      /// </summary>
      public string Filename 
      { 
         get
         {
             return Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), 
                                 "LOGS", 
                                 DateTime.Now.Year.ToString("D4"), 
                                 DateTime.Now.Month.ToString("D2"),
                                 "RWM_" + DateTime.Now.ToString("yyyyMMdd") + ".log");
         }
      }

      /// <summary>
      /// Gets the current LOG level.
      /// </summary>
      public Logger.LogLevel CurrentLogLevel 
      { 
         get { return Logger.StringToLogLevel(this.Settings.GetString(Logger.SETTING_LOG_LEVEL)); }
      }

      #endregion

      #region ILogger Implementation

      public void Initialize(XmlSettingsItem settings)
      {
         this.Settings = settings;
      }

      public void LogInfo(object sender, string message, params object[] args)
      {
         WriteLogEntry(Logger.LogLevel.Info, sender, message, args);
      }

      public void LogWarning(object sender, string message, params object[] args)
      {
         WriteLogEntry(Logger.LogLevel.Warn, sender, message, args);
      }

      public void LogDebug(object sender, string message, params object[] args)
      {
         WriteLogEntry(Logger.LogLevel.Debug, sender, message, args);
      }

      public void LogError(object sender, string message, params object[] args)
      {
         WriteLogEntry(Logger.LogLevel.Error, sender, message, args);
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
            // Ensure folder LOGS is created
            DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(this.Filename));
            if (!dir.Exists)
            {
               dir.Create();
            }

            // Ensure that the LOG file is created
            //FileInfo file = new FileInfo(DebugLogger.CurrentLogFilename);
            //if (!file.Exists)
            //{
            //   file.Create();

            //   LogInfo(sender, "LOG file created by {0}", Application.ProductName);
            //}

            // Generate text for entry
            StringBuilder txt = new StringBuilder();
            txt.AppendLine(string.Format("{0} - {1} at {2}", 
                                         DateTime.Now.ToString(Logger.FORMAT_DATETIME_LONG),
                                         level.ToString().ToUpper(),
                                         sender != null ? sender.GetType().Assembly.FullName : Application.ProductName));
            txt.AppendLine(string.Format(message, args));

            using (StreamWriter sw = File.AppendText(this.Filename))
            {
               sw.WriteLine(txt.ToString());
            }

            // Set all used instances to null to minimize memory usage
            txt = null;
            dir = null;
            // file = null;
         }
         catch
         {
            // This class can't thrown exceptions
            // Any exception is ignored
         }
      }

      #endregion

   }
}
