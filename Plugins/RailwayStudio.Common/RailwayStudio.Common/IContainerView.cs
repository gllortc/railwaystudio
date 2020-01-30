using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Ribbon;
using RailwayStudio.Common.Controls;
using System.Windows.Forms;

namespace RailwayStudio.Common
{
   public interface IContainerView
   {

      IWin32Window HwndHandle { get; }

      RibbonForm ParentForm { get; }

      DockManager DockManager { get; }

      RibbonControl RibbonControl { get; }

      ConsoleControl LogConsole { get; }

      void Close();

      void OpenPluginModule(string className, params object[] args);

   }
}
