using Rwm.Otc.Layout;
using Rwm.Otc.Themes;

namespace Rwm.Otc.Layout.Persistence
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

      private static DeviceDAO pControlModuleManager = null;

      #endregion

      #region Properties

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

      #endregion

   }
}
