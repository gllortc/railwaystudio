using Rwm.Otc.Themes;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Rwm.Otc.LayoutControl.Elements
{
   /// <summary>
   /// Implementation of triple turnout element (with digital function).
   /// </summary>
   public class TripleTurnoutElement : ElementBase, IAccessory, IRoutable
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
         /// <summary>Right position.</summary>
         Right = 2,
         /// <summary>Left position.</summary>
         Left = 3
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="TripleTurnoutElement"/>.
      /// </summary>
      public TripleTurnoutElement()
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
         get { return (Image)global::Rwm.Otc.Properties.Resources.ICO_DESIGN_TURNOUT_TRIPLE_16; }
      }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      public override string TypeGroup
      {
         get { return "Turnouts"; }
      }

      /// <summary>
      /// Gets the type the description of the type of the bloc.
      /// </summary>
      public override string TypeDescription
      {
         get { return "Triple"; }
      }

      /// <summary>
      /// Gets the type of bloc.
      /// </summary>
      public override ElementBase.ElementType Type
      {
         get { return ElementType.TurnoutTriple; }
      }

      /// <summary>
      /// Gets the current element status.
      /// </summary>
      public TurnoutStatus Status { get; private set; }

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
            case (int)TurnoutStatus.Right:
               this.Status = TurnoutStatus.Right;
               break;

            case (int)TurnoutStatus.Left:
               this.Status = TurnoutStatus.Left;
               break;

            default:
               this.Status = TurnoutStatus.Stright;
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
            case TurnoutStatus.Right:
               this.SetAccessoryStatus((int)TurnoutStatus.Left, sendToSystem);
               break;

            case TurnoutStatus.Left:
               this.SetAccessoryStatus((int)TurnoutStatus.Stright, sendToSystem);
               break;

            case TurnoutStatus.Stright:
               this.SetAccessoryStatus((int)TurnoutStatus.Right, sendToSystem);
               break;

            default:
               this.SetAccessoryStatus((int)TurnoutStatus.Stright, sendToSystem);
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
            return new ConnectionMap(37);
         }
         else
         {
            return new ConnectionMap(25);
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
            case TurnoutStatus.Undefined:
               this.Status = TurnoutStatus.Right;
               this.SetInRoute(true);
               break;

            case TurnoutStatus.Right:
               this.Status = TurnoutStatus.Stright;
               this.SetInRoute(true);
               break;

            case TurnoutStatus.Stright:
               this.Status = TurnoutStatus.Left;
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
         this.AccessoryConnections = new ControlModuleConnection[2];
         this.ActivatedInRoute = false;
      }

      #endregion

   }
}
