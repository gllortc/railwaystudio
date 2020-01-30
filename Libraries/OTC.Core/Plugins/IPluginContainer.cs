using DevExpress.XtraBars.Docking;
using Rwm.Otc.Configuration;
using Rwm.Otc.LayoutControl;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rwm.Otc.Plugins
{

   public enum PanelDockPosition
   {
      Left,
      Right,
      Bottom
   }

   public interface IPluginContainer
   {

      Project Project { get; }

      XmlSettingsManager Settings { get; }

      System.Windows.Forms.Form MainView { get; }

      Object[] PluginArguments { get; }

      void ShowObjectProperties(object objProperties);

      /// <summary>
      /// Add a new dockable panel showing a control.
      /// </summary>
      /// <param name="name">Panel name.</param>
      /// <param name="text">Text shown in the panel caption.</param>
      /// <param name="control">Control to be shown in the panel.</param>
      /// <param name="icon">Icon (16x16) for the panel tab.</param>
      /// <param name="dockStyle">Docking position.</param>
      DockPanel AddDockPanel(string name, string text, Control control, Image icon, DockingStyle dockStyle);

      /// <summary>
      /// Remove the specified dockable panel.
      /// </summary>
      /// <param name="name">Panel name.</param>
      void RemoveDockPanel(string name);

   }
}
