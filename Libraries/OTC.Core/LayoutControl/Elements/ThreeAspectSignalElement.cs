using Rwm.Otc.Themes;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Rwm.Otc.LayoutControl.Elements
{
   /// <summary>
   /// Implementation of triple turnout element (with digital function).
   /// </summary>
   public class ThreeAspectSignalElement : ElementBase, IAccessory, IRoutable
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
         Red = 1,
         /// <summary>Left position.</summary>
         Green = 2,
         /// <summary>Right position.</summary>
         YellowGreen = 3
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ThreeAspectSignalElement"/>.
      /// </summary>
      public ThreeAspectSignalElement()
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
      public override Image TypeIcon
      {
         get { return (Image)global::Rwm.Otc.Properties.Resources.ICO_DESIGN_SIGNAL3A_16; }
      }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      public override string TypeGroup
      {
         get { return "Signaling"; }
      }

      /// <summary>
      /// Gets the type the description of the type of the bloc.
      /// </summary>
      public override string TypeDescription
      {
         get { return "Three aspects"; }
      }

      /// <summary>
      /// Gets the type of bloc.
      /// </summary>
      public override ElementBase.ElementType Type
      {
         get { return ElementType.StrightThreeAspectSignal; }
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

      #region IAccessoryBlock implementation

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
            case (int)SignalStatus.Green:
               this.Status = SignalStatus.Green;
               break;

            case (int)SignalStatus.YellowGreen:
               this.Status = SignalStatus.YellowGreen;
               break;

            default:
               this.Status = SignalStatus.Red;
               break;
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
            case SignalStatus.Red:
               this.SetAccessoryStatus((int)SignalStatus.Green, sendToSystem);
               break;

            case SignalStatus.Green:
               this.SetAccessoryStatus((int)SignalStatus.YellowGreen, sendToSystem);
               break;

            case SignalStatus.YellowGreen:
               this.SetAccessoryStatus((int)SignalStatus.Red, sendToSystem);
               break;

            default:
               this.SetAccessoryStatus((int)SignalStatus.Red, sendToSystem);
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
      public ConnectionMap GetDefaultConnectionMap(int connectionIndex)
      {
         if (connectionIndex <= 0)
         {
            return new ConnectionMap(Convert.ToInt32("100101", 2));
         }
         else
         {
            return new ConnectionMap(Convert.ToInt32("101001", 2));
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
         switch (this.Status)
         {
            case SignalStatus.Undefined:
               this.Status = SignalStatus.Red;
               this.SetInRoute(true);
               break;

            case SignalStatus.Red:
               this.Status = SignalStatus.Green;
               this.SetInRoute(true);
               break;

            case SignalStatus.Green:
               this.Status = SignalStatus.YellowGreen;
               this.SetInRoute(true);
               break;

            default:
               this.Status = SignalStatus.Red;
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
         this.AccessoryConnections = new ControlModuleConnection[2];
         this.ActivatedInRoute = false;
      }

      #endregion

   }
}
