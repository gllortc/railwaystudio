using System;
using System.Windows.Forms;

namespace otc.windows.forms
{
   /// <summary>
   /// Implementa una clase para el manejo del cursor del mouse.
   /// </summary>
   class CursorEx 
   {
      /// <summary>
      /// Aquí no ha d'anar!!!!
      /// </summary>
      /// <param name="CursorName"></param>
      /// <returns></returns>
      public static Cursor LoadCursor(string CursorName)
      {
         Cursor cursor = null;
         String name;
         IntPtr hcursor = IntPtr.Zero;
         IntPtr hinst = IntPtr.Zero;
         uint errcode;

         //Name = "ProLogic.Cursors." + CursorName + ".CUR";
         name = "ProLogic.Cursor1.CUR";

         hinst = Win32.GetModuleHandleW(null);

         hcursor = Win32.LoadImage(hinst, name, Win32.IMAGE_CURSOR, 0, 0, 
                                   Win32.LR_DEFAULTCOLOR | Win32.LR_DEFAULTSIZE | Win32.LR_SHARED);
         //HCursor = Win32.LoadCursor (HInst, Name);
         if (hcursor.ToInt32() == 0)
         {
            errcode = Win32.GetLastError();
         }
         else
            cursor = new Cursor(hcursor);

         return (cursor);
      }
   }
}
