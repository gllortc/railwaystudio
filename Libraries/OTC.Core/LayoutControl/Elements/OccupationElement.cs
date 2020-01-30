using Rwm.Otc.Themes;
using System.Drawing;

namespace Rwm.Otc.LayoutControl.Elements
{
   /// <summary>
   /// Implementation of a occupation element.
   /// </summary>
   public class OccupationElement : ElementBase, IRoutable, IBlock
   {

      #region Constants

      private static int BLOCK_TYPE = 3;

      #endregion

      #region Enumerations

      /// <summary>
      /// Enumerate all types of static blocks.
      /// </summary>
      public enum OccupationBlockType : int
      {
         Free = 0,
         Occupied = 1
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="OccupationElement"/>.
      /// </summary>
      public OccupationElement()
      {
         Initialize();
      }

      /// <summary>
      /// Returns a new instance of <see cref="OccupationElement"/>.
      /// </summary>
      public OccupationElement(int elementId) : base(elementId)
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
         get { return (Image)global::Rwm.Otc.Properties.Resources.ICO_DESIGN_BLOCK_16; }
      }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      public override string TypeGroup
      {
         get { return "Operation"; }
      }

      /// <summary>
      /// Gets the type the description of the type of the bloc.
      /// </summary>
      public override string TypeDescription
      {
         get { return "Occupation element"; }
      }

      /// <summary>
      /// Gets the type of bloc.
      /// </summary>
      public override ElementBase.ElementType Type
      {
         get { return ElementType.OccupationBlock; }
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

      /// <summary>
      /// Gets the current element status.
      /// </summary>
      public OccupationBlockType Status { get; private set; }

      /// <summary>
      /// Gets the number of blocks corresponding to width of the element.
      /// </summary>
      public override int Width
      {
         get { return 2; }
      }

      /// <summary>
      /// Rotación del elemento.
      /// </summary>
      public override RotationStep Rotation
      {
         get { return RotationStep.Step0; }
         set { } // Nothing to do 
      }

      #endregion

      #region IRoutableBlock implementation

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

      #region IBlock implementation

      public bool IsOccupied 
      {
         get { return (this.Train != null); } 
      }

      public Rwm.Otc.TrainControl.CollectionModel Train { get; set; }

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
