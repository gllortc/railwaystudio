using System;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;

namespace Rwm.Otc.Layout
{
   /// <summary>
   /// Represents an action executable from the related element.
   /// </summary>
   [ORMTable("ELEMENT_ACTIONS")]
   public class ElementAction : ORMEntity<ElementAction>
   {

      #region Constants

      /// <summary>Status condition disabled.</summary>
      public const int CONDITION_DISABLED = -1;

      #endregion

      #region Enumeration

      public enum ActionTypes : int
      {
         ActivateRoute = 1,
         SetAccessoryStatus = 2,
         PlaySound = 3,
         ExecuteScript = 4,
         DeactivateRoute = 5
      }

      public enum EventType : int
      {
         Undefined = 0,
         OnAccessoryStatusChange = 1,
         OnSensorStatusChange = 2
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ElementAction"/>.
      /// </summary>
      public ElementAction() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; } = 0;

      [ORMProperty("elementid")]
      public Element Element { get; set; } = null;

      [ORMProperty("actiontype")]
      public ActionTypes Type { get; set; }

      [ORMProperty("eventtype")]
      public EventType Event { get; set; }

      [ORMProperty("description")]
      public string Description { get; set; } = string.Empty;

      [ORMProperty("conditionstatus")]
      public int ConditionStatus { get; set; } = ElementAction.CONDITION_DISABLED;

      /// <summary>
      /// Check if condition status is disabled.
      /// </summary>
      public bool IsConditionStatusDisabled
      {
         get { return (this.ConditionStatus == ElementAction.CONDITION_DISABLED); }
      }

      [ORMProperty("order")]
      public int Order { get; set; } = 0;

      [ORMProperty("intparam1")]
      public long IntegerParameter1 { get; set; } = 0;

      [ORMProperty("intparam2")]
      public long IntegerParameter2 { get; set; } = 0;

      [ORMProperty("strparam1")]
      public string StringParameter1 { get; set; } = string.Empty;

      [ORMProperty("strparam2")]
      public string StringParameter2 { get; set; } = string.Empty;

      /// <summary>
      /// Gets an icon associated to the type of action.
      /// </summary>
      public System.Drawing.Image Icon
      {
         get
         {
            switch (this.Type)
            {
               case ActionTypes.ActivateRoute: return Rwm.Otc.Properties.Resources.ICO_ROUTE_16;
               case ActionTypes.DeactivateRoute: return Properties.Resources.ICO_ROUTE_DEACTIVATE_16;
               case ActionTypes.PlaySound: return Rwm.Otc.Properties.Resources.ICO_SOUND_16;
               case ActionTypes.SetAccessoryStatus: return Rwm.Otc.Properties.Resources.ICO_BLOCK_SET_16;
               default: return Rwm.Otc.Properties.Resources.ICO_PROHIBITED_16;
            }
         }
      }

      /// <summary>
      /// Gets the associated small icon (16x16px).
      /// </summary>
      public static System.Drawing.Image SmallIcon
      {
         get { return Properties.Resources.ICO_ACTION_16; }
      }

      /// <summary>
      /// Gets the associated large icon (32x32px).
      /// </summary>
      public static System.Drawing.Image LargeIcon
      {
         get { return Properties.Resources.ICO_ACTION_32; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Execute the current action.
      /// </summary>
      public void Execute()
      {
         switch (this.Type)
         {
            case ActionTypes.ActivateRoute:        this.ExecuteActivateRoute();      break;
            case ActionTypes.DeactivateRoute:      this.ExecuteDeactivateRoute();    break;
            case ActionTypes.SetAccessoryStatus:   this.ExecuteSetAccessoryStatus(); break;
            case ActionTypes.PlaySound:            this.ExecutePlaySound();          break;
            default: break;
         }
      }

      #endregion

      #region Private Members

      private void ExecuteActivateRoute()
      {
         try
         {
            Route route = Route.Get(this.IntegerParameter1);
            route.Activate();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      private void ExecuteDeactivateRoute()
      {
         try
         {
            Route route = Route.Get(this.IntegerParameter1);
            route.Deactivate();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      private void ExecuteSetAccessoryStatus()
      {
         try
         {
            Element element = Element.Get(this.IntegerParameter1);
            if (element != null && this.IntegerParameter2 != Element.STATUS_UNDEFINED)
            {
               element.SetAccessoryStatus((int)this.IntegerParameter2);
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      private void ExecutePlaySound()
      {
         try
         {
            Sound sound = Sound.Get(this.IntegerParameter1);
            sound.Play();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      #endregion

   }
}
