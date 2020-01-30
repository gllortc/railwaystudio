using Rwm.Otc.Systems;
using Rwm.Otc.Themes;
using System.Collections.Generic;
using System.Drawing;

namespace Rwm.Otc.LayoutControl.Elements
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
      public override Image TypeIcon
      {
         get { return (Image)global::Rwm.Otc.Properties.Resources.ICO_DESIGN_STRIGHT_SENSOR_16; }
      }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      public override string TypeGroup
      {
         get { return "Automation"; }
      }

      /// <summary>
      /// Gets the type the description of the type of the bloc.
      /// </summary>
      public override string TypeDescription 
      {
         get { return "Stright sensor"; } 
      }

      /// <summary>
      /// Gets the type of bloc.
      /// </summary>
      public override ElementBase.ElementType Type
      {
         get { return ElementType.StrightSensor; }
      }

      /// <summary>
      /// Gets the current element status.
      /// </summary>
      public ElementFeedbackStatus FeedbackStatus { get; private set; }

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
      /// Rotate the element 90º to right direction.
      /// </summary>
      public override void Rotate()
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

      #region IFeedbackBlock implementation

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
      public void SetFeedbackStatus(int status)
      {
         this.FeedbackStatus = (ElementFeedbackStatus)status;

         this.OnImageChanged(new ElementEventArgs(this));

         this.OnFeedbackStatusChanged(new FeedbackEventArgs(status));
      }

      /// <summary>
      /// Get a list of available feedback status for the element.
      /// </summary>
      /// <returns>A <c>KeyValuePair</c> filled with the description and the integer value.</returns>
      public List<KeyValuePair<string, int>> GetAllFeedbackStatusValues()
      {
         var list = new List<KeyValuePair<string, int>>();

         foreach (var e in System.Enum.GetValues(typeof(ElementFeedbackStatus)))
         {
            list.Add(new KeyValuePair<string, int>(e.ToString(), (int)e));
         }

         return list;
      }

      /// <summary>
      /// Event raised when a new feedback status is adopted by the element.
      /// </summary>
      public event System.EventHandler<FeedbackEventArgs> FeedbackStatusChanged;

      protected virtual void OnFeedbackStatusChanged(FeedbackEventArgs e)
      {
         if (this.FeedbackStatusChanged != null)
         {
            this.FeedbackStatusChanged(this, e);
         }
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
         this.FeedbackStatus = ElementFeedbackStatus.Deactivated;
         this.FeedbackConnections = new ControlModuleConnection[1];
         this.ActivatedInRoute = false;
      }

      #endregion

   }
}
