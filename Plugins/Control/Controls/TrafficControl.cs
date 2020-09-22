using System;
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

         // Initialize the tree list
         tvwTraffic.BeginUpdate();
         TreeListColumn col = tvwTraffic.Columns.Add();
         col.Caption = "Info";
         col.VisibleIndex = 0;
         tvwTraffic.EndUpdate();

         if (OTCContext.Project != null) 
            OTCContext.Project.TrafficManager.TrafficStatusChanged += TrafficManager_TrafficStatusChanged;
      }

      #endregion

      #region Event Handlers

      private void TrafficManager_TrafficStatusChanged(object sender, EventArgs e)
      {
         if (tvwTraffic.InvokeRequired)
         {
            tvwTraffic.Invoke((Action)delegate
            {
               this.RefreshTrafficList();
            });
         }
         else
         {
            this.RefreshTrafficList();
         }
      }

      private void CmdTrafficStart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         cmdTrafficStart.Enabled = false;
         cmdTrafficPause.Enabled = true;
         cmdTrafficStop.Enabled = true;

         OTCContext.Project.TrafficManager.Start();
      }

      private void CmdTrafficPause_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         cmdTrafficStart.Enabled = true;
         cmdTrafficPause.Enabled = false;
         cmdTrafficStop.Enabled = true;

         OTCContext.Project.TrafficManager.Pause();
      }

      private void CmdTrafficStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         cmdTrafficStart.Enabled = true;
         cmdTrafficPause.Enabled = false;
         cmdTrafficStop.Enabled = false;

         OTCContext.Project.TrafficManager.Stop();
      }

      #endregion

      #region Private Members

      private void RefreshTrafficList()
      {
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

   }
}
