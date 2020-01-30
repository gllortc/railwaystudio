using Rwm.Otc.Layout;
using Rwm.Otc.Layout.Persistence;
using Rwm.Otc.Themes;

namespace Rwm.Otc
{
   /// <summary>
   /// Layout persistence management class.
   /// </summary>
   public class LayoutManager
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="LayoutManager"/>.
      /// </summary>
      public LayoutManager() { }

      #endregion

      #region Fields

      private static ElementDAO pElementManager = null;
      private static SwitchboardDAO pSwitchboardPanelManager = null;
      private static DeviceDAO pControlModuleManager = null;
      private static DeviceConnectionDAO pControlModuleConnectionManager = null;
      private static ElementActionDAO pElementActionManager = null;
      private static RouteDAO pRouteManager = null;
      private static RouteElementDAO pRouteElemManager = null;
      private static SoundDAO pSoundManager = null;
      private static ProjectDAO pProjectManager = null;

      #endregion

      #region Properties

      /// <summary>
      /// Gets the DAO manager for the projects.
      /// </summary>
      public ProjectDAO ProjectDAO
      {
         get
         {
            if (LayoutManager.pProjectManager == null) LayoutManager.pProjectManager = new ProjectDAO();
            return LayoutManager.pProjectManager;
         }
      }

      /// <summary>
      /// Gets the DAO manager for the blocks.
      /// </summary>
      public ElementDAO ElementDAO
      {
         get
         {
            if (LayoutManager.pElementManager == null) LayoutManager.pElementManager = new ElementDAO();
            return LayoutManager.pElementManager;
         }
      }

      /// <summary>
      /// Gets the DAO manager for the switchboards.
      /// </summary>
      public SwitchboardDAO SwitchboardDAO
      {
         get
         {
            if (LayoutManager.pSwitchboardPanelManager == null) LayoutManager.pSwitchboardPanelManager = new SwitchboardDAO();
            return LayoutManager.pSwitchboardPanelManager;
         }
      }

      /// <summary>
      /// Gets the DAO manager for the control modules (decoders).
      /// </summary>
      public DeviceDAO DeviceDAO
      {
         get
         {
            if (LayoutManager.pControlModuleManager == null) LayoutManager.pControlModuleManager = new DeviceDAO();
            return LayoutManager.pControlModuleManager;
         }
      }

      /// <summary>
      /// Gets the DAO manager for the connections to control modules (decoders).
      /// </summary>
      public DeviceConnectionDAO DeviceConnectionDAO
      {
         get
         {
            if (LayoutManager.pControlModuleConnectionManager == null) LayoutManager.pControlModuleConnectionManager = new DeviceConnectionDAO();
            return LayoutManager.pControlModuleConnectionManager;
         }
      }

      /// <summary>
      /// Gets the DAO manager for the element actions.
      /// </summary>
      public ElementActionDAO ElementActionDAO
      {
         get
         {
            if (LayoutManager.pElementActionManager == null) LayoutManager.pElementActionManager = new ElementActionDAO();
            return LayoutManager.pElementActionManager;
         }
      }

      /// <summary>
      /// Gets the DAO manager for the routes.
      /// </summary>
      public RouteDAO RouteDAO
      {
         get
         {
            if (LayoutManager.pRouteManager == null) LayoutManager.pRouteManager = new RouteDAO();
            return LayoutManager.pRouteManager;
         }
      }

      /// <summary>
      /// Gets the DAO manager for the routes.
      /// </summary>
      public RouteElementDAO RouteElementDAO
      {
         get
         {
            if (LayoutManager.pRouteElemManager == null) LayoutManager.pRouteElemManager = new RouteElementDAO();
            return LayoutManager.pRouteElemManager;
         }
      }

      /// <summary>
      /// Gets the DAO manager for the sounds.
      /// </summary>
      public SoundDAO SoundDAO
      {
         get
         {
            if (LayoutManager.pSoundManager == null) LayoutManager.pSoundManager = new SoundDAO();
            return LayoutManager.pSoundManager;
         }
      }

      #endregion

   }
}
