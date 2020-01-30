using System;
using System.IO;

namespace Rwm.Otc.Utils
{
   internal class IOUtils
   {
      public static String GetFilePath(String path, String filename)
      {
         path = path.Trim();
         filename = filename.Trim();

         return (filename.EndsWith(Path.PathSeparator.ToString()) ? path + filename : path + Path.PathSeparator + filename);
      }

      public static String GetFilenameFromString(string str)
      {
         foreach (char c in Path.GetInvalidFileNameChars())
         {
            str = str.Replace(c, '_');
         }

         return str;
      }
   }
}
