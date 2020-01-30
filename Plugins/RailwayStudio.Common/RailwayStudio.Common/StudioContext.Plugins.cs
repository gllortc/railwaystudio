using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraNavBar;
using Rwm.Otc.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace RailwayStudio.Common
{
   public class Plugins
   {

      #region Properties

      

      #endregion

      #region Methods

      

      

      #endregion

      #region Private Members

      

      #endregion

      #region Event Handlers

      /// <summary>
      /// Event captured to remove all panels created by the module.
      /// </summary>
      void PluginModule_FormClosing(object sender, FormClosingEventArgs e)
      {
         IPluginModule module = sender as IPluginModule;
         if (module != null)
         {
            module.DestoryPanels();
         }
      }

      /// <summary>
      /// Event captured to launch a plugin module.
      /// </summary>
      void PluginItem_LinkClicked(object sender, NavBarLinkEventArgs e)
      {
         this.LoadPlugin(e.Link.Item.Tag as PluginModule);
      }

      #endregion

   }
}
