using System;
using System.Drawing;
using System.IO;

namespace Rwm.Otc.Utils
{
   /// <summary>
   /// Implementa las operaciones aritméticas para notación binaria.
   /// </summary>
   public class BinaryUtils
   {
      /// <summary>
      /// Devuelve el byte bajo de un valor.
      /// </summary>
      public static int LoByte(int word)
      {
         return (word & 0xFF);
      }

      /// <summary>
      /// Devuelve el byte alto de un valor.
      /// </summary>
      public static int HiByte(int word)
      {
         return ((word & 0xFF00) / 0x100);
      }

      /// <summary>
      /// Convierte dos bytes (alto y bajo) en un valor entero.
      /// </summary>
      public static short MakeWord(byte bLow, byte bHigh)
      {
         return (short)(bLow | (bHigh << 8));
      }

      /// <summary>
      /// Realiza la operación XOR sobre un array de bytes.
      /// </summary>
      /// <param name="values">Array de bytes.</param>
      public static short Xor(byte[] values)
      {
         return Xor(values, 0, values.Length);
      }

      /// <summary>
      /// Realiza la operación XOR sobre un array de bytes.
      /// </summary>
      /// <param name="values">Array de bytes.</param>
      /// <param name="length">Número de elementos para los que se desea realizar la operación empezando por el elemento 0.</param>
      public static short Xor(byte[] values, int length)
      {
         return Xor(values, 0, length);
      }

      /// <summary>
      /// Realiza la operación XOR sobre un array de bytes.
      /// </summary>
      /// <param name="values">Array de bytes.</param>
      /// <param name="start">Índice del elemento inicial.</param>
      /// <param name="length">Número de elementos para los que se desea realizar la operación empezando por el elemento apuntado por <code>start</code>.</param>
      public static short Xor(byte[] values, int start, int length)
      {
         short value = 0;

         for (int i = start; i < length - 1; i++)
         {
            value ^= values[i];
         }

         return value;
      }

      /// <summary>
      /// Gets a bit value from a byte.
      /// </summary>
      /// <param name="b">Byte.</param>
      /// <param name="bitNumber">Bit number.</param>
      /// <returns>The selected bit <see cref="Boolean"/> value.</returns>
      public static bool GetBit(byte b, int bitNumber)
      {
         return ((b & (1 << bitNumber - 1)) != 0);
      }

      public static string ImageToByteArray(Image image, System.Drawing.Imaging.ImageFormat format)
      {
         using (MemoryStream ms = new MemoryStream())
         {
            // Convert Image to byte[]
            image.Save(ms, format);
            byte[] imageBytes = ms.ToArray();

            // Convert byte[] to Base64 String
            return Convert.ToBase64String(imageBytes);
         }
      }

      public static byte[] ImageToByteArray(Image image)
      {
         using (MemoryStream ms = new MemoryStream())
         {
            // Convert Image to byte[]
            try
            {
               image.Save(ms, image.RawFormat);
               return ms.ToArray();
            }
            catch
            {
               // Discard the exception
            }

            foreach (var propertyInfo in typeof(System.Drawing.Imaging.ImageFormat).GetProperties())
            {
               if (propertyInfo.PropertyType == typeof(System.Drawing.Imaging.ImageFormat))
               {
                  try
                  {
                     image.Save(ms, (System.Drawing.Imaging.ImageFormat)propertyInfo.GetValue(null, null));
                     return ms.ToArray();
                  }
                  catch
                  {
                     // Discard the exception
                  }
               }
            }

            return ms.ToArray();  // void MemoryStream
         }
      }

      public static Image ByteArrayToImage(byte[] imageBytes)
      {
         // Convert byte[] to Image
         using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
         {
            ms.Write(imageBytes, 0, imageBytes.Length);
            return new Bitmap(ms);
         }
      }
   }
}
