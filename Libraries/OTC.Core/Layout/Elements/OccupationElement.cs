using Rwm.Otc.Systems;
using Rwm.Otc.Themes;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Rwm.Otc.Layout.Elements
{
   /// <summary>
   /// Implementation of a occupation element.
   /// </summary>
   public class OccupationElement : ElementBase, IFeedback, IBlock
   {

      #region Constants

      private static int BLOCK_TYPE = 3;

      public event EventHandler<FeedbackEventArgs> FeedbackStatusChanged;

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

      #region Fields

      private Rwm.Otc.TrainControl.CollectionModel train = null;

      #endregion

      #region Properties

      /// <summary>
      /// Gets the icon of the type of the bloc.
      /// </summary>
      public new Image TypeIcon
      {
         get { return (Image)global::Rwm.Otc.Properties.Resources.ICO_DESIGN_BLOCK_16; }
      }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      public new string TypeGroup
      {
         get { return "Operation"; }
      }

      /// <summary>
      /// Gets the type the description of the type of the bloc.
      /// </summary>
      public new string TypeDescription
      {
         get { return "Occupation element"; }
      }

      /// <summary>
      /// Gets the type of bloc.
      /// </summary>
      public new ElementBase.ElementType Type
      {
         get { return ElementType.OccupationBlock; }
      }

      /// <summary>
      /// Gets the current element status.
      /// </summary>
      public OccupationBlockType Status { get; private set; }

      /// <summary>
      /// Gets the number of blocks corresponding to width of the element.
      /// </summary>
      public new int Width
      {
         get { return 2; }
      }

      /// <summary>
      /// Rotación del elemento.
      /// </summary>
      public new RotationStep Rotation
      {
         get { return RotationStep.Step0; }
         set { } // Nothing to do 
      }

      #endregion

      #region IBlock implementation

      public bool IsOccupied 
      {
         get { return (this.Train != null); } 
      }

      public Rwm.Otc.TrainControl.CollectionModel Train 
      { 
         get { return train; }
         set
         {
            train = value;
            this.OnOccupationChanged(new OccupationEventArgs(this, value));
            this.OnImageChanged(new ElementEventArgs(this));
         }
      }

      /// <summary>
      /// Event raised when a new feedback status is adopted by the element.
      /// </summary>
      public event EventHandler<OccupationEventArgs> OccupationChanged;

      /// <summary>
      /// Event handler for the <c>OccupationChanged</c> event.
      /// </summary>
      /// <param name="e"></param>
      protected virtual void OnOccupationChanged(OccupationEventArgs e)
      {
         if (this.OccupationChanged != null)
         {
            this.OccupationChanged(this, e);
         }
      }

      #endregion

      #region IFeedback implementation

      /// <summary>
      /// Gets the current element status.
      /// </summary>
      public FeedbackStatus FeedbackStatus { get; private set; }

      /// <summary>
      /// Get the current status value.
      /// </summary>
      public int GetFeedbackStatus()
      {
         return (int)this.FeedbackStatus;
      }

      /// <summary>
      /// Set feedback status for the element.
      /// </summary>
      /// <param name="status">New feedback status to be adopted by the element.</param>
      public void SetFeedbackStatus(FeedbackStatus status)
      {
         this.FeedbackStatus = (FeedbackStatus)status;

         this.OnImageChanged(new ElementEventArgs(this));

         this.OnFeedbackStatusChanged(new FeedbackEventArgs(status));
      }

      // TODO: Check why this declaration generate ambiguity!!
      ///// <summary>
      ///// Event raised when a new feedback status is adopted by the element.
      ///// </summary>
      //public event EventHandler<FeedbackEventArgs> FeedbackStatusChanged;

      /// <summary>
      /// Event handler for the <c>FeedbackStatusChanged</c> event.
      /// </summary>
      /// <param name="e"></param>
      protected virtual void OnFeedbackStatusChanged(FeedbackEventArgs e)
      {
         if (this.FeedbackStatusChanged != null)
         {
            this.FeedbackStatusChanged(this, e);
         }
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         // Nothing to do here
      }

      #endregion


   }
}
