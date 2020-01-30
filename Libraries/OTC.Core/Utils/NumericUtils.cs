using System.Globalization;
using System.Text.RegularExpressions;

namespace Rwm.Otc.Utils
{
   /// <summary>
   /// Clase que contiene  métodos para el tratamiento de valores numéricos.
   /// </summary>
   public class NumericUtils
   {
      /// <summary>
      /// Convierte una cadena de texto a un número entero.
      /// </summary>
      /// <param name="text">Cadena de texto a convertir.</param>
      /// <returns>Un valor <see cref="int"/> que representa el valor numérico del texto convertido.</returns>
      public static int Val(string text)
      {
         string ch = string.Empty;
         string val = "0";

         for (int i = 0; i <= text.Length - 1; i++)
         {
            ch = text.Substring(i, 1);
            switch (ch)
            {
               case "0":
               case "1":
               case "2":
               case "3":
               case "4":
               case "5":
               case "6":
               case "7":
               case "8":
               case "9": val += ch; break;
               default: break;
            }
         }
         return int.Parse(val);
      }

      /// <summary>
      /// Indica si una cadena contiene un valor entero.
      /// </summary>
      /// <param name="text">Cadena de texto a comprobar.</param>
      /// <returns><c>true</c> si la cadena contiene un número entero o <c>false</c> en cualquier otro caso.</returns>
      public static bool IsNumeric(string text)
      {
         return Regex.IsMatch(text, "^\\d+$");
      }

      /// <summary>
      /// Indica si una cadena contiene un valor decimal.
      /// </summary>
      /// <param name="text">Cadena de texto a comprobar.</param>
      /// <returns><c>true</c> si la cadena contiene un número decimal o <c>false</c> en cualquier otro caso.</returns>
      public static bool IsDecimal(string text)
      {
         // Obtiene el símbolo separador decimal (segun cultura del equipo local)
         CultureInfo culture = CultureInfo.CurrentCulture;
         NumberFormatInfo number = culture.NumberFormat;

         // Paresea el número según separador decimal adecuado
         return Regex.IsMatch(text, "^\\d+(\\" + number.CurrencyDecimalSeparator + "\\d+)?$");
      }

      public static int ToInteger(string text)
      {
         return ToInteger(text, 0);
      }

      public static int ToInteger(string text, int defaultValue)
      {
         int num;

         if (int.TryParse(text, out num))
         {
            return num;
         }
         else
         {
            return defaultValue;
         }
      }
   }
}
