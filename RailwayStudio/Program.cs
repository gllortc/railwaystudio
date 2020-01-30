using System;
using System.Windows.Forms;

namespace Rwm.Studio
{
   static class Program
   {

      #region Constants

      public const string SETUP_KEY_UI_SKIN = "rwm.studio.ui.skin-name";

      public const string SETUP_KEY_PROJECT_LASTLOAD = "rwm.studio.projects.last-load";

      public const string SETUP_KEY_PROJECT_LASTOPEN = "rwm.studio.projects.last-open";

      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new Views.MainView());
      }
   }
}
