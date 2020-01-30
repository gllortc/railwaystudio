using System;
using System.Runtime.InteropServices;

namespace otc.windows
{
   /// <summary>
   /// Implementa una clase para las llamadas directas a la API de Windows.
   /// </summary>
   class Win32
   {
      public const uint IMAGE_BITMAP = 0;
      public const uint IMAGE_ICON = 1;
      public const uint IMAGE_CURSOR = 2;

      public const uint LR_DEFAULTCOLOR = 0x0000;
      public const uint LR_MONOCHROME = 0x0001;
      public const uint LR_COLOR = 0x0002;
      public const uint LR_COPYRETURNORG = 0x0004;
      public const uint LR_COPYDELETEORG = 0x0008;
      public const uint LR_LOADFROMFILE = 0x0010;
      public const uint LR_LOADTRANSPARENT = 0x0020;
      public const uint LR_DEFAULTSIZE = 0x0040;
      public const uint LR_VGACOLOR = 0x0080;
      public const uint LR_LOADMAP3DCOLORS = 0x1000;
      public const uint LR_CREATEDIBSECTION = 0x2000;
      public const uint LR_COPYFROMRESOURCE = 0x4000;
      public const uint LR_SHARED = 0x8000;


      [DllImport("User32.dll")]
      public static extern IntPtr LoadImage(IntPtr hinst,

      [MarshalAs(UnmanagedType.LPTStr)] string lpszName,
      uint uType,
      int cxDesired,
      int cyDesired,
      uint fuLoad);

      [DllImport("User32.dll")]
      public static extern IntPtr LoadCursor(IntPtr hinst,
      [MarshalAs(UnmanagedType.LPTStr)] string lpszName);

      [DllImport("kernel32.dll")]
      public extern static IntPtr
      GetModuleHandleW([MarshalAs(UnmanagedType.LPStr)] string lpModuleName);

      [DllImport("kernel32.dll")]
      public extern static uint GetLastError();
   }
}
