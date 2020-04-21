using System.Windows.Forms;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Ribbon;
using Rwm.Studio.Plugins.Common.Controls;

namespace Rwm.Studio.Plugins.Common
{
   public interface IContainerView
   {

      #region Properties

      IWin32Window HwndHandle { get; }

      RibbonForm ParentForm { get; }

      DockManager DockManager { get; }

      RibbonControl RibbonControl { get; }

      ConsoleControl LogConsole { get; }

      AlertControl AlertControl { get; }

      #endregion

      #region Methods

      void OpenPluginModule(string guid, params object[] args);

      #endregion

   }
}
