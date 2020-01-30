using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Rwm.Otc.Utils
{
   /// <summary>
   /// Utilities for <see cref="System.String"/> management.
   /// </summary>
   public class StringUtils
   {

      #region Constants

      /// <summary>Character code: ENTER</summary>
      private const string CHAR_CODE_ENTER = "[BR]";
      /// <summary>Character code: TAB</summary>
      private const string CHAR_CODE_TAB = "[TAB]";

      #endregion

      public static string SplitCamelCaseString(string s)
      {
         var r = new Regex(@"
                 (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

         return r.Replace(s, " ");
      }

      public static string ListToString(List<long> list)
      {
         string lst = string.Empty;

         foreach (long item in list)
         {
            lst += (!string.IsNullOrWhiteSpace(lst) ? ", " : string.Empty) + item;
         }
         return lst;
      }

      /// <summary>
      /// Replace extended codes for a string.
      /// </summary>
      /// <param name="text">Text to analyze.</param>
      /// <returns>The specified string with all special chars replaced.</returns>
      /// <remarks>
      /// Current supported codes:
      /// [BR]  - New line / Break
      /// [TAB] - Tab
      /// </remarks>
      static public string ReplaceTextCodes(string text)
      {
         return text.Replace(CHAR_CODE_ENTER, Environment.NewLine).
                     Replace(CHAR_CODE_TAB, "\\t");
      }

      /// <summary>
      /// Replace extended codes for a string and the format item in a specified string with the string representation 
      /// of a corresponding object in a specified array.
      /// </summary>
      /// <param name="text">A composite format string.</param>
      /// <param name="args">An object array that contains zero or more objects to format.</param>
      /// <returns>The specified string with all special chars replaced.</returns>
      /// <remarks>
      /// Current supported codes:
      /// [BR]  - New line / Break
      /// [TAB] - Tab
      /// </remarks>
      static public string ReplaceTextCodes(string text, params object[] args)
      {
         return string.Format(text.Replace(CHAR_CODE_ENTER, Environment.NewLine).
                                   Replace(CHAR_CODE_TAB, "\\t"),
                              args);
      }

   }
}
