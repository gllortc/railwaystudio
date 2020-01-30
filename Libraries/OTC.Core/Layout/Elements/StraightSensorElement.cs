using Rwm.Otc.Systems;
using Rwm.Otc.Themes;
using System.Collections.Generic;
using System.Drawing;

namespace Rwm.Otc.Layout.Elements
{
   /// <summary>
   /// Implementation of a sensor stright element.
   /// </summary>
   public class StraightSensorElement : ElementBase, IFeedback, IRoutable
   {

      #region Constants

      private static int BLOCK_TYPE = 1;

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="StraightSensorElement"/>.
      /// </summary>
      public StraightSensorElement()
      {
         Initialize();
      }

      #endregion

      #region Events

      public event OnSensorChangedHandler OnSensorChanged;

      public delegate void OnSensorChangedHandler(ElementBase sender);

      #endregion

      #region Properties

      /// <summary>
      /// Gets the icon of the type of the bloc.
      /// </summary>
      public new Image TypeIcon
      {
         get { return (Image)global::Rwm.Otc.Properties.Resources.ICO_DESIGN_STRIGHT_SENSOR_16; }
      }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      public new string TypeGroup
      {
         get { return "Automation"; }
      }

      /// <summary>
      /// Gets the type the description of the type of the bloc.
      /// </summary>
      public new string TypeDescription 
      {
         get { return "Stright sensor"; } 
      }

      /// <summary>
      /// Gets the type of bloc.
      /// </summary>
      public new ElementBase.ElementType Type
      {
         get { return ElementType.StrightSensor; }
      }

      /// <summary>
      /// Gets the current element status.
      /// </summary>
      public FeedbackStatus FeedbackStatus { get; private set; }

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

      #region IFeedback implementation

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
         this.FeedbackStatus = status;

         this.OnImageChanged(new ElementEventArgs(this));

         this.OnFeedbackStatusChanged(new FeedbackEventArgs(status));
      }

      /// <summary>
      /// Event raised when a new feedback status is adopted by the element.
      /// </summary>
      public event System.EventHandler<FeedbackEventArgs> FeedbackStatusChanged;

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

      #region IRoutable implementation

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
         this.FeedbackStatus = FeedbackStatus.Deactivated;
         this.FeedbackConnections = new DeviceConnection[1];
         this.ActivatedInRoute = false;
      }

      #endregion

   }
}
