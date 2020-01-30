using System;
using Rwm.Otc.Configuration;

namespace Rwm.Otc.Diagnostics
{
   public interface ILogger
   {
      /// <summary>
      /// Gets the current level for the logger.
      /// </summary>
      Logger.LogLevel CurrentLogLevel { get; }

      void Initialize(XmlSettingsItem settings);

      /// <summary>
      /// Log an error.
      /// </summary>
      /// <param name="sender">Object from the logger is called.</param>
      /// <param name="message">Descriptive error message.</param>
      /// <param name="args">A list of parameters to format the message.</param>
      void LogError(object sender, string message, params object[] args);

      /// <summary>
      /// Log a informative text.
      /// </summary>
      /// <param name="sender">Object from the logger is called.</param>
      /// <param name="message">Message.</param>
      /// <param name="args">A list of parameters to format the message.</param>
      void LogInfo(object sender, string message, params object[] args);

      /// <summary>
      /// Log an informative text
      /// </summary>
      /// <param name="sender">Object from the logger is called.</param>
      /// <param name="message">Message.</param>
      /// <param name="args">A list of parameters to format the message.</param>
      void LogWarning(object sender, string message, params object[] args);

      /// <summary>
      /// Log an informative text
      /// </summary>
      /// <param name="sender">Object from the logger is called.</param>
      /// <param name="message">Message.</param>
      /// <param name="args">A list of parameters to format the message.</param>
      void LogDebug(object sender, string message, params object[] args);

      /// <summary>
      /// Log a critical error or warning.
      /// </summary>
      /// <param name="sender">Object from the logger is called.</param>
      /// <param name="message">Descriptive error message.</param>
      /// <param name="args">A list of parameters to format the message.</param>
      void LogCritical(object sender, string message, params object[] args);
   }
}
