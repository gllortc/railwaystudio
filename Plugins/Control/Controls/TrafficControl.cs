using System;
using System.Collections.Generic;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.Layout.Traffic;

namespace Rwm.Studio.Plugins.Control.Controls
{
   public partial class TrafficControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="TrafficControl"/>.
      /// </summary>
      /// <param name="settings"></param>
      /// <param name="control"></param>
      public TrafficControl()
      {
         InitializeComponent();
      }

      #endregion

      #region Properties

      private static System.Timers.Timer Timer { get; set; }

      #endregion

      #region Methods

      public void Start()
      {
         if (TrafficControl.Timer == null)
         {
            TrafficControl.Timer = new System.Timers.Timer(2000);
            TrafficControl.Timer.Elapsed += Timer_Elapsed;
         }

         TrafficControl.Timer.Start();
      }

      public void Stop()
      {
         TrafficControl.Timer.Stop();
      }

      public void RefreshTrafficList()
      {
         if (tvwTraffic.InvokeRequired)
         {
            tvwTraffic.Invoke((Action)delegate
            {
               this.FillTrafficList();
            });
         }
         else
            this.FillTrafficList();
      }

      private void FillTrafficList()
      {
         TreeListColumn col;

         if (tvwTraffic.Columns.Count <= 0)
         {
            tvwTraffic.BeginUpdate();

            col = tvwTraffic.Columns.Add();
            col.Caption = "INfo";
            col.VisibleIndex = 0;

            tvwTraffic.EndUpdate();
         }

         tvwTraffic.BeginUnboundLoad();

         tvwTraffic.Nodes.Clear();

         foreach (Itinerary troute in TrafficManager.ActiveItineraries)
         {
            // Create the traffic node
            TreeListNode trafficNode = tvwTraffic.AppendNode(new object[] { troute.ToString() }, null);
            trafficNode.StateImageIndex = 0;
            trafficNode.Tag = troute;

            foreach (Route route in troute.PendingRoutes)
            {
               // Create the traffic node
               TreeListNode routeNode = tvwTraffic.AppendNode(new object[] { route.ToString() }, trafficNode);
               routeNode.StateImageIndex = (!route.IsActive ? 1 : 2);
            }

            trafficNode.Expand();
         }

         tvwTraffic.EndUnboundLoad();
      }

      #endregion

      #region Event Handlers

      private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
      {
         this.RefreshTrafficList();
      }

      #endregion

   }
}
