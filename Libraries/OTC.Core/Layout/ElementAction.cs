using System;
using System.Drawing;
using Rwm.Otc.Data.ORM;
using Rwm.Otc.Diagnostics;

namespace Rwm.Otc.Layout
{
   [ORMTable("actions")]
   public class ElementAction : ORMEntity<ElementAction>
   {

      #region Constants

      /// <summary>Status condition disabled.</summary>
      public static int CONDITION_DISABLED = -1;

      #endregion

      #region Enumeration

      public enum ActionTypes : int
      {
         ActivateRoute = 1,
         SetAccessoryStatus = 2,
         PlaySound = 3,
         ExecuteScript = 4
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
      public ElementAction() 
      {
         this.ConditionStatus = ElementAction.CONDITION_DISABLED;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; }

      [ORMProperty("elementid")]
      public Element Element { get; set; }

      [ORMProperty("actiontype")]
      public ActionTypes Type { get; set; }

      [ORMProperty("eventtype")]
      public EventType Event { get; set; }

      [ORMProperty("description")]
      public string Description { get; set; }

      [ORMProperty("conditionstatus")]
      public int ConditionStatus { get; set; }

      [ORMProperty("order")]
      public int Order { get; set; }

      [ORMProperty("intparam1")]
      public long IntegerParameter1 { get; set; }

      [ORMProperty("intparam2")]
      public long IntegerParameter2 { get; set; }

      [ORMProperty("strparam1")]
      public string StringParameter1 { get; set; }

      [ORMProperty("strparam2")]
      public string StringParameter2 { get; set; }

      /// <summary>
      /// Gets an icon associated to the type of action.
      /// </summary>
      public Image Icon
      {
         get
         {
            switch (this.Type)
            {
               case ActionTypes.ActivateRoute: return Rwm.Otc.Properties.Resources.ICO_ROUTE_16;
               case ActionTypes.PlaySound: return Rwm.Otc.Properties.Resources.ICO_SOUND_16;
               case ActionTypes.SetAccessoryStatus: return Rwm.Otc.Properties.Resources.ICO_BLOCK_SET_16;
               default: return Rwm.Otc.Properties.Resources.ICO_PROHIBITED_16;
            }
         }
      }

      #endregion

      #region Methods

      public void Execute()
      {
         switch (this.Type)
         {
            case ActionTypes.ActivateRoute:        this.ExecuteActivateRoute(); break;
            case ActionTypes.SetAccessoryStatus:   this.ExecuteSetAccessoryStatus(); break;
            case ActionTypes.PlaySound: this.ExecutePlaySound(); break;
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
            throw;
         }
      }

      private void ExecuteSetAccessoryStatus()
      {
         try
         {
            Element element = Element.Get(this.IntegerParameter1);
            element.SetAccessoryStatus((int)this.IntegerParameter2);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
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
            throw;
         }
      }

      #endregion

   }
}
