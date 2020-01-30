using Rwm.Otc.Themes;
using System.Collections.Generic;
using System.Drawing;

namespace Rwm.Otc.LayoutControl.Blocks
{
   /// <summary>
   /// Implementation of right turnout block (with digital function).
   /// </summary>
   public class RightDoubleTurnoutBlock : BlockBase
   {

      #region Enumerations

      /// <summary>
      /// Enumerate all types of static blocks.
      /// </summary>
      public enum RightDoubleTurnoutStatus : int
      {
         Undefined = 0,
         Right = 0, 
         Left = 1
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="RightDoubleTurnoutBlock"/>.
      /// </summary>
      public RightDoubleTurnoutBlock()
      {
         Initialize();
      }

      #endregion

      #region Events

      public event OnStatusChangeHandler OnStatusChange;

      public delegate void OnStatusChangeHandler(BlockBase sender);

      #endregion

      #region Properties

      /// <summary>
      /// Gets the icon of the type of the bloc.
      /// </summary>
      public override Image TypeIcon
      {
         get { return (Image)global::Rwm.Otc.Properties.Resources.B_105.ToBitmap(); }
      }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      public override string TypeGroup
      {
         get { return "Turnouts"; }
      }

      /// <summary>
      /// Gets the type the description of the type of the bloc.
      /// </summary>
      public override string TypeDescription
      {
         get { return "Double right"; }
      }

      /// <summary>
      /// Gets the type of bloc.
      /// </summary>
      public override BlockBase.BlockType Type
      {
         get { return BlockType.DoubleTurnoutRight; }
      }

      /// <summary>
      /// Gets the current block status.
      /// </summary>
      public RightDoubleTurnoutStatus Status { get; private set; }

      #endregion

      #region Methods

      /// <summary>
      /// Returns the image to show in switchboard panel.
      /// </summary>
      /// <returns>The requested image.</returns>
      public override Image GetImage(ITheme theme, bool designMode)
      {
         return theme.GetBlockImage(this, designMode);
      }

      /// <summary>
      /// Get a list of available status for the block.
      /// </summary>
      /// <returns>A <c>KeyValuePair</c> filled with the description and the integer value.</returns>
      public override List<KeyValuePair<string, int>> GetAllStatusValues()
      {
         var list = new List<KeyValuePair<string, int>>();

         foreach (var e in System.Enum.GetValues(typeof(RightDoubleTurnoutStatus)))
         {
            list.Add(new KeyValuePair<string, int>(e.ToString(), (int)e));
         }

         return list;
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.Status = RightDoubleTurnoutStatus.Left;
         this.AccessoryConnections = new ControlModuleConnection[2];
      }

      #endregion

   }
}
