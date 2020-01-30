using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace otc.forms
{

   #region class OTCForms

   /// <summary>
   /// Clase que permite el acceso a los formularios estandarizados de OTC.
   /// </summary>
   public class OTCForms
   {
      /// <summary>
      /// Proporciona el icono estándar para formularios y/o aplicaciones.
      /// </summary>
      public static Icon Icon
      {
         get { return global::otc.Properties.Resources.ICO_FORMS; }
      }

      /// <summary>
      /// Reproduce un archivo de sonido WAV.
      /// </summary>
      /// <param name="wavFile"></param>
      public static void PlaySound(string wavFile)
      {
         if (String.IsNullOrEmpty(wavFile)) return;

         FileInfo file = new FileInfo(wavFile);
         if (!file.Exists) return;

         System.Media.SoundPlayer player = new System.Media.SoundPlayer(file.FullName);
         player.Play();
      }

      /// <summary>
      /// Indica si se trata de una tecla válida en un camp de sólo lectura.
      /// </summary>
      internal static bool IsValidKeyForReadOnlyFields(Keys key)
      {
         switch (key)
         {
            case (Keys.Up):
            case (Keys.Down):
            case (Keys.Left):
            case (Keys.Right):
            case (Keys.PageUp):
            case (Keys.PageDown):
            case (Keys.F1):
            case (Keys.F2):
            case (Keys.F3):
            case (Keys.F4):
            case (Keys.F5):
            case (Keys.F6):
            case (Keys.F7):
            case (Keys.F8):
            case (Keys.F9):
            case (Keys.F10):
            case (Keys.F11):
            case (Keys.F12):
            case (Keys.F13):
            case (Keys.F14):
            case (Keys.F15):
            case (Keys.F16):
            case (Keys.F17):
            case (Keys.F18):
            case (Keys.F19):
            case (Keys.F20):
            case (Keys.F21):
            case (Keys.F22):
            case (Keys.F23):
            case (Keys.F24):
            case (Keys.Shift):
            case (Keys.ShiftKey):
            case (Keys.Control):
            case (Keys.ControlKey):
            case (Keys.CapsLock):
            case (Keys.Scroll):
            case (Keys.Alt):
            case (Keys.Apps):
            case (Keys.End):
            case (Keys.Escape):
            case (Keys.Help):
            case (Keys.Home):
            case (Keys.Insert):
            case (Keys.LButton):
            case (Keys.LControlKey):
            case (Keys.LMenu):
            case (Keys.MButton):
            case (Keys.Menu):
            case (Keys.VolumeDown):
            case (Keys.VolumeMute):
            case (Keys.VolumeUp):
            case (Keys.XButton1):
            case (Keys.XButton2):
            case (Keys.Zoom):
               return true;
            default:
               return false;
         }
      }
   }

   #endregion

}
