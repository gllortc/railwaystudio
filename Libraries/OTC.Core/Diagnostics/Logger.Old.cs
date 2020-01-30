using System;
using System.IO;
using System.Reflection;
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
   public static class Logger
   {

      #region Constants

      /// <summary>Name of the file that enables logging for application.</summary>
      public const string DEBUG_FILE_NAME = "debug.log";

      /// <summary>DateTime format to show timestamp on LOG entries</summary>
      private const string FORMAT_DATETIME_LONG = "dd/MM/yyyy hh:mm:ss.fff";

      #endregion

      #region Static Properties

      /// <summary>
      /// Indicates if this class is in debug mode.
      /// </summary>
      public static bool IsDebuggerEnabled
      {
         get 
         { 
            return File.Exists(Logger.EnableDebugModeFilename); 
         }
      }

      /// <summary>
      /// Returns the filename and path of the file tah enables DEBUG MODE.
      /// </summary>
      public static string EnableDebugModeFilename
      {
         get 
         {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);

            return Path.Combine(Path.GetDirectoryName(path), Logger.DEBUG_FILE_NAME); 
         }
      }

      /// <summary>
      /// Returns the current active log file (name and path).
      /// </summary>
      public static string CurrentLogFilename
      {
         get
         {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            
            string logsPath = Path.GetDirectoryName(path);
            logsPath = Path.Combine(Path.GetDirectoryName(path), "logs");
            logsPath = Path.Combine(logsPath, DateTime.Now.ToString("yyyy"));
            logsPath = Path.Combine(logsPath, DateTime.Now.ToString("MM"));

            return Path.Combine(logsPath, "RWM_OTC_" + DateTime.Now.ToString("yyyyMMdd") + ".log"); 
         }
      }

      #endregion

      #region Static Methods

      /// <summary>
      /// Forces to enable logging.
      /// </summary>
      public static void EnableLogs()
      {
         FileInfo file = new FileInfo(Logger.EnableDebugModeFilename);
         if (!file.Exists)
         {
            file.Create();
         }
      }

      /// <summary>
      /// Forces to disable logging.
      /// </summary>
      public static void DisableLogs()
      {
         FileInfo file = new FileInfo(Logger.EnableDebugModeFilename);
         if (file.Exists)
         {
            file.Delete();
         }
      }

      /// <summary>
      /// Log an error.
      /// </summary>
      /// <param name="message">Descriptive error message.</param>
      public static void LogError(string message)
      {
         Logger.LogError(message, null, null);
      }

      /// <summary>
      /// Log an error.
      /// </summary>
      /// <param name="message">Descriptive error message.</param>
      /// <param name="context">Descriptive context (method, class...) that informs where the error was produced.</param>
      public static void LogError(string message, string context)
      {
         Logger.LogError(message, context, null);
      }

      /// <summary>
      /// Log an error.
      /// </summary>
      /// <param name="message">Descriptive error message.</param>
      /// <param name="exception">An exception instance.</param>
      public static void LogError(string message, Exception exception)
      {
         Logger.LogError(message, null, exception);
      }

      /// <summary>
      /// Log an error.
      /// </summary>
      /// <param name="message">Descriptive error message.</param>
      /// <param name="exception">An exception instance.</param>
      public static void LogError(object objectContext, Exception exception)
      {
         Logger.LogError(objectContext.GetType().FullName, null, exception);
      }

      /// <summary>
      /// Log an error.
      /// </summary>
      /// <param name="message">Descriptive error message.</param>
      /// <param name="context">Descriptive context (method, class...) that informs where the error was produced.</param>
      /// <param name="exception">An exception instance.</param>
      public static void LogError(string message, string context, Exception exception)
      {
         // If not enabled, stop flow
         if (!Logger.IsDebuggerEnabled)
         {
            return;
         }

         try
         {
            CheckForLogFile();

            // Generate the log text
            StringBuilder txt = new StringBuilder();
            txt.Append(DateTime.Now.ToString(Logger.FORMAT_DATETIME_LONG) + " - ERROR");
            if (!string.IsNullOrEmpty(context))
            {
               txt.Append(" at " + context);
            }
            txt.AppendLine(" : ");
            txt.AppendLine(message);
            if (exception != null)
            {
               txt.AppendLine("Stack trace:");
               txt.AppendLine(exception.ToString());
            }

            // Append text to log file
            using (StreamWriter sw = File.AppendText(Logger.CurrentLogFilename))
            {
               sw.WriteLine(txt.ToString());
            }
         }
         catch
         {
            // This class can't thrown exceptions
            // Any exception is ignored
         }
      }

      /// <summary>
      /// Log a informative text.
      /// </summary>
      /// <param name="message">Message.</param>
      public static void LogInfo(string message)
      {
         Logger.LogInfo(message, string.Empty);
      }

      /// <summary>
      /// Log a informative text.
      /// </summary>
      /// <param name="message">Message.</param>
      /// <param name="context">Context.</param>
      public static void LogInfo(string message, string context)
      {
         // If not enabled, stop flow
         if (!Logger.IsDebuggerEnabled)
         {
            return;
         }

         try
         {
            CheckForLogFile();

            // Generate the log text
            StringBuilder txt = new StringBuilder();
            txt.AppendLine(DateTime.Now.ToString(Logger.FORMAT_DATETIME_LONG) + " - INFO : " + context);
            txt.AppendLine("   " + message);

            // Append text to log file
            using (StreamWriter sw = File.AppendText(Logger.CurrentLogFilename))
            {
               sw.WriteLine(txt.ToString());
            }
         }
         catch
         {
            // This class can't thrown exceptions
            // Any exception is ignored
         }
      }

      /// <summary>
      /// Log a warning text
      /// </summary>
      /// <param name="message">Descriptive error message.</param>
      /// <param name="exception">An exception instance.</param>
      public static void LogWarning(object objectContext, string message, params object[] args)
      {
         Logger.LogWarning(objectContext.GetType().FullName, string.Format(message, args));
      }

      /// <summary>
      /// Log a warning text
      /// </summary>
      /// <param name="message">Message.</param>
      public static void LogWarning(string message)
      {
         Logger.LogWarning(message, null);
      }

      /// <summary>
      /// Log a warning text
      /// </summary>
      /// <param name="message">Message.</param>
      /// <param name="context">Descriptive context (method, class...) that informs where the warning was produced.</param>
      public static void LogWarning(string context, string message)
      {
         // If not enabled, stop flow
         if (!Logger.IsDebuggerEnabled)
         {
            return;
         }

         try
         {
            CheckForLogFile();

            // Generate the log text
            StringBuilder txt = new StringBuilder();
            txt.Append(DateTime.Now.ToString(Logger.FORMAT_DATETIME_LONG) + " - WARN");
            if (!string.IsNullOrEmpty(context))
            {
               txt.Append(" at " + context);
            }
            txt.AppendLine(" : ");
            txt.AppendLine(message);

            // Append text to log file
            using (StreamWriter sw = File.AppendText(Logger.CurrentLogFilename))
            {
               sw.WriteLine(txt.ToString());
            }
         }
         catch
         {
            // This class can't thrown exceptions
            // Any exception is ignored
         }
      }

      /// <summary>
      /// Log a informative text.
      /// </summary>
      /// <param name="message">Message.</param>
      public static void LogDebug(string message)
      {
         Logger.LogDebug(message, string.Empty);
      }

      /// <summary>
      /// Log a informative text.
      /// </summary>
      /// <param name="message">Message.</param>
      /// <param name="context">Context.</param>
      public static void LogDebug(object contextObject, string message, params object[] args)
      {
         // If not enabled, stop flow
         if (!Logger.IsDebuggerEnabled)
         {
            return;
         }

         try
         {
            CheckForLogFile();

            // Generate the log text
            StringBuilder txt = new StringBuilder();
            txt.AppendLine(DateTime.Now.ToString(Logger.FORMAT_DATETIME_LONG) + " - INFO at " + contextObject.GetType().FullName);
            txt.AppendLine("   " + string.Format(message, args));

            // Append text to log file
            using (StreamWriter sw = File.AppendText(Logger.CurrentLogFilename))
            {
               sw.WriteLine(txt.ToString());
            }
         }
         catch
         {
            // This class can't thrown exceptions
            // Any exception is ignored
         }
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Ensure that the log file is created and located in the correct folder.
      /// </summary>
      /// <remarks>
      /// The current log file is located on:
      /// [DLL or APP path]\LOGS\[YEAR]\[MONTH]\EMDEP_[Date in format yyyyMMdd].log
      /// </remarks>
      private static void CheckForLogFile()
      {
         // Ensure folder LOGS is created
         DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(Logger.CurrentLogFilename));
         if (!dir.Exists)
         {
            dir.Create();
         }

         // Ensure that the LOG file is created
         FileInfo file = new FileInfo(Logger.CurrentLogFilename);
         if (!file.Exists)
         {
            using (StreamWriter sw = file.CreateText())
            {
               sw.WriteLine(DateTime.Now.ToString(Logger.FORMAT_DATETIME_LONG) + " - INFO : LOG file created by " + Application.ProductName);
            }
         }

         dir = null;
         file = null;
      }

      #endregion

   }
}
