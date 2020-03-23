using Rwm.Otc.Configuration;
using Rwm.Otc.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Rwm.Otc.Diagnostics
{
   /// <summary>
   /// Enable automatic logging functionallity for all applications.
   /// </summary>
   /// <remarks>
   /// The configuration for the loggers must be placed in the settings file for the calling application.
   /// </remarks>
   public static class Logger
   {

      #region Constants

      /// <summary>Name of the file that enables logging for application.</summary>
      public const string SETTING_LOG_LEVEL = "level";

      /// <summary>Name of the file that enables logging for application.</summary>
      public const string SETTING_LOG_ASSEMBLY_FILE = "log.assembly";

      /// <summary>Name of the file that enables logging for application.</summary>
      public const string SETTING_LOG_ASSEMBLY_CLASS = "log.class";

      /// <summary>DateTime format to show timestamp on LOG entries</summary>
      public const string FORMAT_DATETIME_LONG = "dd/MM/yyyy hh:mm:ss.fff";

      /// <summary>Replacement TAG for class type.</summary>
      public const string CHAR_CODE_TYPE_NAME = "[CLASS]";

      #endregion

      #region Enumerations

      public enum LogLevel : int
      {
         /// <summary>Error messages (exceptions).</summary>
         Error = 1,
         /// <summary>Warning messages (trapped and controlled errors).</summary>
         Warn = 2,
         /// <summary>Informative messages.</summary>
         Info = 3,
         /// <summary>Debug data.</summary>
         Debug = 4,
         /// <summary>Critical warnings and errors.</summary>
         Critical = 5
      }

      #endregion

      #region Constructors

      static Logger()
      {
         Assembly assembly;
         ILogger logger;

         Logger.Loggers = new List<ILogger>();

         try
         {
            // Load settings
            Logger.Settings = new XmlSettingsManager();
            Logger.Settings.LoadSettings();

            // Load modules from settings
            Logger.ModuleManager = new LoggerSettingsManager(Logger.Settings);

            // If no loggers are appended, a FileLogger with ERROR level will be appended to ensure LOG all application exceptions
            if (Logger.ModuleManager.LoggerModules.Count <= 0)
            {
               XmlSettingsItem module = new XmlSettingsItem("FileLogger", typeof(FileLogger).FullName);
               module.AddSetting(Logger.SETTING_LOG_LEVEL, LogLevel.Error.ToString());
               Logger.ModuleManager.LoggerModules.Add(module);
            }

            // Generate the logger instances
            foreach (XmlSettingsItem module in Logger.ModuleManager.LoggerModules)
            {
               assembly = Assembly.GetExecutingAssembly();
               logger = (ILogger)assembly.CreateInstance(module.Value);

               if (logger != null)
               {
                  logger.Initialize(module);

                  Logger.Loggers.Add(logger);
               }
            }

            // To minimize the memory usage
            assembly = null;
            logger = null;
         }
         catch
         {
            // Empty settings
         }
      }

      #endregion

      #region Properties

      public static XmlSettingsManager Settings { get; private set; }

      public static LoggerSettingsManager ModuleManager { get; private set; }

      public static List<ILogger> Loggers { get; private set; }

      #endregion

      #region Methods

      /// <summary>
      /// Log an error.
      /// </summary>
      /// <param name="message">Descriptive error message.</param>
      public static string LogError(string message)
      {
         return Logger.LogError(null, message, new object[] { });
      }

      /// <summary>
      /// Log an error.
      /// </summary>
      /// <param name="sender">Object from the logger is called.</param>
      /// <param name="message">Descriptive error message.</param>
      public static string LogError(object sender, string message)
      {
         return Logger.LogError(sender, message, new object[] { });
      }

      /// <summary>
      /// Log an error.
      /// </summary>
      /// <param name="sender">Object from the logger is called.</param>
      /// <param name="message">Descriptive error message.</param>
      /// <param name="args">A list of parameters to format the message.</param>
      public static string LogError(object sender, string message, params object[] args)
      {
         message = message.Replace(CHAR_CODE_TYPE_NAME, (sender != null ? sender.GetType().Name : "[object]"));
         message = StringUtils.ReplaceTextCodes(message, args);

         foreach (ILogger logger in Logger.Loggers)
         {
            if (Logger.IsLoggableEntry(LogLevel.Error, logger.CurrentLogLevel))
            {
               logger.LogError(sender, message);
            }
         }

         return message;
      }

      /// <summary>
      /// Log an error.
      /// </summary>
      /// <param name="exception">An exception instance.</param>
      public static string LogError(Exception exception)
      {
         return Logger.LogError(null, exception.ToString());
      }

      /// <summary>
      /// Log an error.
      /// </summary>
      /// <param name="sender">Object from the logger is called.</param>
      /// <param name="exception">An exception instance.</param>
      public static string LogError(object sender, Exception exception)
      {
         return Logger.LogError(sender, exception.ToString());
      }

      /// <summary>
      /// Log a informative text
      /// </summary>
      /// <param name="message">Message.</param>
      public static string LogWarning(string message)
      {
         return Logger.LogWarning(null, message, new object[] { });
      }

      /// <summary>
      /// Log a informative text
      /// </summary>
      /// <param name="sender">Object from the logger is called.</param>
      /// <param name="message">Message.</param>
      public static string LogWarning(object sender, string message)
      {
         return Logger.LogWarning(sender, message, new object[] { });
      }

      /// <summary>
      /// Log a informative text
      /// </summary>
      /// <param name="sender">Object from the logger is called.</param>
      /// <param name="message">Message.</param>
      /// <param name="args">A list of parameters to format the message.</param>
      public static string LogWarning(object sender, string message, params object[] args)
      {
         message = message.Replace(CHAR_CODE_TYPE_NAME, (sender != null ? sender.GetType().Name : "[object]"));

         foreach (ILogger logger in Logger.Loggers)
         {
            if (Logger.IsLoggableEntry(LogLevel.Warn, logger.CurrentLogLevel))
            {
               logger.LogWarning(sender, StringUtils.ReplaceTextCodes(message, args));
            }
         }

         return StringUtils.ReplaceTextCodes(message, args);
      }

      /// <summary>
      /// Log a informative text.
      /// </summary>
      /// <param name="message">Message.</param>
      public static string LogInfo(string message)
      {
         return Logger.LogInfo(null, message, new object[] { });
      }

      /// <summary>
      /// Log a informative text.
      /// </summary>
      /// <param name="sender">Object from the logger is called.</param>
      /// <param name="message">Message.</param>
      public static string LogInfo(object sender, string message)
      {
         return Logger.LogInfo(sender, message, new object[] { });
      }

      /// <summary>
      /// Log an informative text.
      /// </summary>
      /// <param name="sender">Object from the logger is called.</param>
      /// <param name="message">Message.</param>
      /// <param name="args">A list of parameters to format the message.</param>
      public static string LogInfo(object sender, string message, params object[] args)
      {
         message = message.Replace(CHAR_CODE_TYPE_NAME, (sender != null ? sender.GetType().Name : "[object]"));

         foreach (ILogger logger in Logger.Loggers)
         {
            if (Logger.IsLoggableEntry(LogLevel.Info, logger.CurrentLogLevel))
            {
               logger.LogInfo(sender, StringUtils.ReplaceTextCodes(message, args));
            }
         }

         return StringUtils.ReplaceTextCodes(message, args);
      }

      /// <summary>
      /// Log a debug information text.
      /// </summary>
      /// <param name="message">Message.</param>
      public static string LogDebug(string message)
      {
         return Logger.LogDebug(null, message, new object[] { });
      }

      /// <summary>
      /// Log a debug information text.
      /// </summary>
      /// <param name="sender">Object from the logger is called.</param>
      /// <param name="message">Message.</param>
      public static string LogDebug(object sender, string message)
      {
         return Logger.LogDebug(sender, message, new object[] { });
      }

      /// <summary>
      /// Log a debug information text.
      /// </summary>
      /// <param name="sender">Object from the logger is called.</param>
      /// <param name="message">Message.</param>
      /// <param name="args">A list of parameters to format the message.</param>
      public static string LogDebug(object sender, string message, params object[] args)
      {
         message = message.Replace(CHAR_CODE_TYPE_NAME, (sender != null ? sender.GetType().Name : "[object]"));

         foreach (ILogger logger in Logger.Loggers)
         {
            if (Logger.IsLoggableEntry(LogLevel.Debug, logger.CurrentLogLevel))
            {
               logger.LogDebug(sender, StringUtils.ReplaceTextCodes(message, args));
            }
         }

         return StringUtils.ReplaceTextCodes(message, args);
      }

      /// <summary>
      /// Log a critical error or warning.
      /// </summary>
      /// <param name="message">Descriptive error message.</param>
      public static string LogCritical(string message)
      {
         return Logger.LogCritical(null, message, new object[] { });
      }

      /// <summary>
      /// Log a critical error or warning.
      /// </summary>
      /// <param name="sender">Object from the logger is called.</param>
      /// <param name="message">Descriptive error message.</param>
      public static string LogCritical(object sender, string message)
      {
         return Logger.LogCritical(sender, message, new object[] { });
      }

      /// <summary>
      /// Log an error.
      /// </summary>
      /// <param name="exception">An exception instance.</param>
      public static string LogCritical(Exception exception)
      {
         return Logger.LogCritical(null, exception.ToString());
      }

      /// <summary>
      /// Log an error.
      /// </summary>
      /// <param name="sender">Object from the logger is called.</param>
      /// <param name="exception">An exception instance.</param>
      public static string LogCritical(object sender, Exception exception)
      {
         return Logger.LogCritical(sender, exception.ToString());
      }

      /// <summary>
      /// Log an error.
      /// </summary>
      /// <param name="sender">Object from the logger is called.</param>
      /// <param name="message">Descriptive error message.</param>
      /// <param name="args">A list of parameters to format the message.</param>
      public static string LogCritical(object sender, string message, params object[] args)
      {
         message = message.Replace(CHAR_CODE_TYPE_NAME, (sender != null ? sender.GetType().Name : "[object]"));

         foreach (ILogger logger in Logger.Loggers)
         {
            if (Logger.IsLoggableEntry(LogLevel.Critical, logger.CurrentLogLevel))
            {
               logger.LogCritical(sender, StringUtils.ReplaceTextCodes(message, args));
            }
         }

         return StringUtils.ReplaceTextCodes(message, args);
      }

      /// <summary>
      /// Convert a string to a LOG level.
      /// </summary>
      /// <param name="text">String to convert.</param>
      /// <returns>The LOG level matching the specified string.</returns>
      public static Logger.LogLevel StringToLogLevel(string text)
      {
         switch (text.Trim().ToUpper())
         {
            case "INF":
            case "INFO":
            case "INFORMATION":
               return Logger.LogLevel.Info;

            case "WARN":
            case "WARNING":
               return Logger.LogLevel.Warn;

            case "DEBUG":
               return Logger.LogLevel.Debug;

            case "CRITICAL":
               return Logger.LogLevel.Critical;

            default:
               return Logger.LogLevel.Error;
         }
      }

      /// <summary>
      /// Check if an entry level must be logged using the current log level.
      /// </summary>
      /// <param name="entryLevel"></param>
      /// <param name="logCurrentLevel"></param>
      /// <returns></returns>
      public static bool IsLoggableEntry(Logger.LogLevel entryLevel, Logger.LogLevel logCurrentLevel)
      {
         if (entryLevel == LogLevel.Critical)
         {
            return true;
         }

         switch (logCurrentLevel)
         {
            case LogLevel.Debug:
               return true;

            case LogLevel.Info:
               return (entryLevel == LogLevel.Info || entryLevel == LogLevel.Warn || entryLevel == LogLevel.Error);

            case LogLevel.Warn:
               return (entryLevel == LogLevel.Warn || entryLevel == LogLevel.Error);

            case LogLevel.Error:
               return (entryLevel == LogLevel.Error);
         }

         return false;
      }

      #endregion

   }
}
