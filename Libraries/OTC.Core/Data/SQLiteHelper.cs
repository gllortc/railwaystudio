using System;
using System.Drawing;
using System.IO;

namespace Rwm.Otc.Data
{
   /// <summary>
   /// Implements various method to help using SQLite.
   /// </summary>
   public class SQLiteHelper
   {
      public static string ImageToByte(Image image, System.Drawing.Imaging.ImageFormat format)
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

      public static Image ByteToImage(byte[] imageBytes)
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
