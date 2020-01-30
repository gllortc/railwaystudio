using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace Rwm.Studio.Views
{
   public partial class SplashView : SplashScreen
   {
      public SplashView()
      {
         InitializeComponent();
      }

      #region Overrides

      public override void ProcessCommand(Enum cmd, object arg)
      {
         base.ProcessCommand(cmd, arg);
      }

      #endregion

      public enum SplashScreenCommand
      {
      }
   }
}