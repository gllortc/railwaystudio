using Rwm.Otc.Themes;
using System.Drawing;

namespace Rwm.Otc.LayoutControl.Elements
{
   /// <summary>
   /// Implementation of a curve element.
   /// </summary>
   public class CurveElement : ElementBase, IRoutable
   {

      #region Constants

      private static int BLOCK_TYPE = 2;

      #endregion

      #region Enumerations

      /// <summary>
      /// Enumerate all types of static blocks.
      /// </summary>
      public enum StaticBlockType : int
      {
         Stright = 0, 
         Curved = 1, 
         Crossing = 2, 
         Bumper = 3, 
         LevelCrossing = 4
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="CurveElement"/>.
      /// </summary>
      public CurveElement()
      {
         Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the icon of the type of the bloc.
      /// </summary>
      public override Image TypeIcon
      {
         get { return (Image)global::Rwm.Otc.Properties.Resources.ICO_DESIGN_CURVE_16; }
      }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      public override string TypeGroup
      {
         get { return "Static"; }
      }

      /// <summary>
      /// Gets the type the description of the type of the bloc.
      /// </summary>
      public override string TypeDescription 
      {
         get { return "Curve"; } 
      }

      /// <summary>
      /// Gets the type of bloc.
      /// </summary>
      public override ElementBase.ElementType Type
      {
         get { return ElementType.Curve; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Returns the image to show in switchboard panel.
      /// </summary>
      /// <returns>The requested image.</returns>
      public override Image GetImage(ITheme theme, bool designMode)
      {
         return theme.GetElementImage(this, designMode);
      }

      #endregion

      #region IRoutable

      /// <summary>
      /// Gets or sets a value indicating if the element is activated in a route.
      /// </summary>
      public bool ActivatedInRoute { get; private set; }

      /// <summary>
      /// Set next status for the element.
      /// </summary>
      /// <returns>A value indicating if the element must be repainted.</returns>
      public void SetRouteNextStatus()
      {
         this.SetInRoute(!this.ActivatedInRoute);
      }

      /// <summary>
      /// Activate/deactivate the element in a route). 
      /// </summary>
      /// <param name="activated">A value indicating if the element will be activated or deactivated.</param>
      public void SetInRoute(bool activated)
      {
         this.ActivatedInRoute = activated;

         // Raise events
         this.OnImageChanged(new ElementEventArgs(this));
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ActivatedInRoute = false;
      }

      #endregion

   }
}
