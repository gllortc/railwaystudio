﻿using Rwm.Otc.Themes;
using System.Drawing;

namespace Rwm.Otc.Layout.Elements
{
   /// <summary>
   /// Implementation of a straight element.
   /// </summary>
   public class StraightElement : ElementBase, IRoutable
   {

      #region Constants

      private static int BLOCK_TYPE = 1;

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
      /// Returns a new instance of <see cref="StraightElement"/>.
      /// </summary>
      public StraightElement()
      {
         Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the icon of the type of the bloc.
      /// </summary>
      public new Image TypeIcon
      {
         get { return (Image)global::Rwm.Otc.Properties.Resources.ICO_DESIGN_STRIGHT_16; }
      }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      public new string TypeGroup
      {
         get { return "Static"; }
      }

      /// <summary>
      /// Gets the type the description of the type of the bloc.
      /// </summary>
      public new string TypeDescription 
      {
         get { return "Stright"; } 
      }

      /// <summary>
      /// Gets the type of bloc.
      /// </summary>
      public new ElementBase.ElementType Type
      {
         get { return ElementType.Stright; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Rotate the element 90º to right direction.
      /// </summary>
      public new void Rotate()
      {
         if (this.Rotation == RotationStep.Step0)
         {
            this.Rotation = RotationStep.Step90;
         }
         else
         {
            this.Rotation = RotationStep.Step0;
         }

         // Raise events
         this.OnImageChanged(new ElementEventArgs(this));
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