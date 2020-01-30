using System;

namespace RailwayStudio.Common
{

   public interface IPluginContainer
   {

      System.Windows.Forms.Form MainView { get; }

      Object[] PluginArguments { get; }

   }
}
