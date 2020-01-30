using Rwm.Otc.Systems;
using Rwm.Otc.Themes;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Rwm.Otc.Layout.Elements
{
   /// <summary>
   /// Implementation of left turnout element (with digital function).
   /// </summary>
   public class LeftTurnoutElement : ElementBase, IAccessory, IRoutable
   {

      #region Enumerations

      /// <summary>
      /// Enumerate all states of the element.
      /// </summary>
      public enum TurnoutStatus : int
      {
         /// <summary>The controller don't know the current status.</summary>
         Undefined = 0,
         /// <summary>Stright position.</summary>
         Stright = 1,
         /// <summary>Curved position.</summary>
         Curved = 2
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="LeftTurnoutElement"/>.
      /// </summary>
      public LeftTurnoutElement()
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
         get { return (Image)global::Rwm.Otc.Properties.Resources.ICO_DESIGN_TURNOUT_LEFT_16; }
      }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      public new string TypeGroup
      {
         get { return "Turnouts"; }
      }

      /// <summary>
      /// Gets the type the description of the type of the bloc.
      /// </summary>
      public new string TypeDescription
      {
         get { return "Left"; }
      }

      /// <summary>
      /// Gets the type of bloc.
      /// </summary>
      public new ElementBase.ElementType Type
      {
         get { return ElementType.TurnoutLeft; }
      }

      /// <summary>
      /// Gets the current element status.
      /// </summary>
      public TurnoutStatus Status { get; private set; }

      /// <summary>
      /// Gets the digital address assigned to turnout
      /// </summary>
      public int Address
      {
         get
         {
            if (this.AccessoryConnections == null || this.AccessoryConnections.Length <= 0 || this.AccessoryConnections[0] == null)
            {
               return 0;
            }

            return this.AccessoryConnections[0].Address;
         }
      }

      #endregion

      #region IAccessory implementation

      /// <summary>
      /// Get the current status value.
      /// </summary>
      public int GetAccessoryStatus()
      {
         return (int)this.Status;
      }

      /// <summary>
      /// Set status for the element.
      /// </summary>
      /// <param name="status">New status to be adopted by the element.</param>
      /// <param name="sendToSystem">A value indicating if the command should be sent to the digital system.</param>
      public void SetAccessoryStatus(int status, bool sendToSystem)
      {
         switch ((TurnoutStatus)status)
         {
            case TurnoutStatus.Undefined:
            case TurnoutStatus.Stright:
               this.Status = TurnoutStatus.Stright;
               break;

            default:
               this.Status = TurnoutStatus.Curved;
               break;
         }

         // Send the command to the digital system
         if (sendToSystem)
         {
            OTCContext.Project.DigitalSystem.SetAccessoryStatus(this);
         }

         this.OnImageChanged(new ElementEventArgs(this));

         this.OnAccessoryStatusChanged(new AccessoryEventArgs((int)this.Status));
      }

      /// <summary>
      /// Set next status for the element.
      /// </summary>
      /// <param name="sendToSystem">A value indicating if the command should be sent to the digital system.</param>
      /// <returns>The new status adopted by the element.</returns>
      public int SetAccessoryNextStatus(bool sendToSystem)
      {
         switch (this.Status)
         {
            case TurnoutStatus.Undefined:
            case TurnoutStatus.Curved:
               this.SetAccessoryStatus((int)TurnoutStatus.Stright, sendToSystem);
               break;

            default:
               this.SetAccessoryStatus((int)TurnoutStatus.Curved, sendToSystem);
               break;
         }

         return (int)this.Status;
      }

      /// <summary>
      /// Returns the description of the current status.
      /// </summary>
      /// <returns>A string containing the current status description.</returns>
      public string GetCurrentAccessoryStatusDescription()
      {
         return this.Status.ToString();
      }

      /// <summary>
      /// Get a list of available status for the element.
      /// </summary>
      /// <returns>A <c>KeyValuePair</c> filled with the description and the integer value.</returns>
      public List<KeyValuePair<string, int>> GetAllAccessoryStatusValues()
      {
         var list = new List<KeyValuePair<string, int>>();

         foreach (var e in System.Enum.GetValues(typeof(TurnoutStatus)))
         {
            list.Add(new KeyValuePair<string, int>(e.ToString(), (int)e));
         }

         return list;
      }

      /// <summary>
      /// Event raised when a new status is adopted by the element.
      /// </summary>
      public event System.EventHandler<AccessoryEventArgs> AccessoryStatusChanged;

      /// <summary>
      /// Delegate for the <see cref="AccessoryStatusChanged"/> event.
      /// </summary>
      protected virtual void OnAccessoryStatusChanged(AccessoryEventArgs e)
      {
         if (this.AccessoryStatusChanged != null)
         {
            this.AccessoryStatusChanged(this, e);
         }
      }

      /// <summary>
      /// Returns the default connection map for the specified connection index.
      /// </summary>
      /// <returns>An instance of <see cref="ConnectionMap"/> with default settings.</returns>
      public DeviceConnectionMap GetDefaultConnectionMap(int connectionIndex)
      {
         return new DeviceConnectionMap(Convert.ToInt32("1001", 2));
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
         switch (this.Status)
         {
            case TurnoutStatus.Undefined:
               this.Status = TurnoutStatus.Stright;
               this.SetInRoute(true);
               break;

            case TurnoutStatus.Stright:
               this.Status = TurnoutStatus.Curved;
               this.SetInRoute(true);
               break;

            default:
               this.Status = TurnoutStatus.Undefined;
               this.SetInRoute(false);
               break;
         }

         // Raise events
         this.OnImageChanged(new ElementEventArgs(this));
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
         this.Status = TurnoutStatus.Undefined;
         this.AccessoryConnections = new DeviceConnection[1];
         this.ActivatedInRoute = false;
      }

      #endregion

   }
}
