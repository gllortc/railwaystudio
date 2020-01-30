using Rwm.Otc.Systems;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Rwm.Otc.Layout.Elements
{
   /// <summary>
   /// Implementation of triple turnout element (with digital function).
   /// </summary>
   public class AdvancedSignalElement : ElementBase, IAccessory, IRoutable
   {

      #region Enumerations

      /// <summary>
      /// Enumerate all states of the element.
      /// </summary>
      public enum SignalStatus : int
      {
         /// <summary>The controller don't know the current status.</summary>
         Undefined = 0,
         /// <summary>Stright position.</summary>
         Proceed = 1,
         /// <summary>Left position.</summary>
         ProceedReducedSpeed = 2,
         /// <summary>Right position.</summary>
         StopExpected = 3
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="AdvancedSignalElement"/>.
      /// </summary>
      public AdvancedSignalElement()
      {
         Initialize();
      }

      #endregion

      #region Events

      public event OnStatusChangeHandler OnStatusChange;

      public delegate void OnStatusChangeHandler(ElementBase sender);

      #endregion

      #region Properties

      /// <summary>
      /// Gets the icon of the type of the bloc.
      /// </summary>
      public new Image TypeIcon
      {
         get { return (Image)global::Rwm.Otc.Properties.Resources.ICO_DESIGN_SIGNALADV_16; }
      }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      public new string TypeGroup
      {
         get { return "Signaling"; }
      }

      /// <summary>
      /// Gets the type the description of the type of the bloc.
      /// </summary>
      public new string TypeDescription
      {
         get { return "Advanced"; }
      }

      /// <summary>
      /// Gets the type of bloc.
      /// </summary>
      public new ElementBase.ElementType Type
      {
         get { return ElementType.StrightAdvancedSignal; }
      }

      /// <summary>
      /// Gets the current element status.
      /// </summary>
      public SignalStatus Status { get; private set; }

      /// <summary>
      /// Gets the digital address (1) assigned to turnout
      /// </summary>
      public int Address1
      {
         get
         {
            if (this.AccessoryConnections == null || this.AccessoryConnections.Length <= 2 || this.AccessoryConnections[0] == null)
            {
               return 0;
            }

            return this.AccessoryConnections[0].Address;
         }
      }

      /// <summary>
      /// Gets the digital address (2) assigned to turnout
      /// </summary>
      public int Address2
      {
         get
         {
            if (this.AccessoryConnections == null || this.AccessoryConnections.Length <= 2 || this.AccessoryConnections[1] == null)
            {
               return 0;
            }

            return this.AccessoryConnections[1].Address;
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
      /// <param name="sendToSystem">A value indicating if the new status must be sent to digital system.</param>
      public void SetAccessoryStatus(int status, bool sendToSystem)
      {
         switch (status)
         {
            case (int)SignalStatus.StopExpected:
               this.Status = SignalStatus.StopExpected;
               break;

            case (int)SignalStatus.ProceedReducedSpeed:
               this.Status = SignalStatus.ProceedReducedSpeed;
               break;

            default:
               this.Status = SignalStatus.Proceed;
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
      /// <param name="sendToSystem">A value indicating if the new status must be sent to digital system.</param>
      /// <returns>The new status adopted by the element.</returns>
      public int SetAccessoryNextStatus(bool sendToSystem)
      {
         switch (this.Status)
         {
            case SignalStatus.StopExpected:
               this.SetAccessoryStatus((int)SignalStatus.Proceed, sendToSystem);
               break;

            case SignalStatus.Proceed:
               this.SetAccessoryStatus((int)SignalStatus.ProceedReducedSpeed, sendToSystem);
               break;

            case SignalStatus.ProceedReducedSpeed:
               this.SetAccessoryStatus((int)SignalStatus.StopExpected, sendToSystem);
               break;

            default:
               this.SetAccessoryStatus((int)SignalStatus.Proceed, sendToSystem);
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

         foreach (var e in System.Enum.GetValues(typeof(SignalStatus)))
         {
            list.Add(new KeyValuePair<string, int>(e.ToString(), (int)e));
         }

         return list;
      }

      /// <summary>
      /// Event raised when a new status is adopted by the element.
      /// </summary>
      public event System.EventHandler<AccessoryEventArgs> AccessoryStatusChanged;

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
         if (connectionIndex <= 0)
         {
            return new DeviceConnectionMap(Convert.ToInt32("100101", 2));
         }
         else
         {
            return new DeviceConnectionMap(Convert.ToInt32("101001", 2));
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
         switch (this.Status)
         {
            case SignalStatus.Undefined:
               this.Status = SignalStatus.Proceed;
               this.SetInRoute(true);
               break;

            case SignalStatus.Proceed:
               this.Status = SignalStatus.ProceedReducedSpeed;
               this.SetInRoute(true);
               break;

            case SignalStatus.ProceedReducedSpeed:
               this.Status = SignalStatus.StopExpected;
               this.SetInRoute(true);
               break;

            default:
               this.Status = SignalStatus.StopExpected;
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
         this.Status = SignalStatus.Undefined;
         this.AccessoryConnections = new DeviceConnection[2];
         this.ActivatedInRoute = false;
      }

      #endregion

   }
}
