using Rwm.Otc.Themes;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Rwm.Otc.LayoutControl.Elements
{
   /// <summary>
   /// Implementation of left turnout element (with digital function).
   /// </summary>
   public class SwitchButtonRedElement : ElementBase, IAccessory
   {

      #region Enumerations

      /// <summary>
      /// Enumerate all states of the element.
      /// </summary>
      public enum SwitchButtonStatus : int
      {
         /// <summary>The controller don't know the current status.</summary>
         Undefined = 0,
         /// <summary>Unpushed.</summary>
         Off = 1,
         /// <summary>Pushed.</summary>
         On = 2
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="SwitchButtonRedElement"/>.
      /// </summary>
      public SwitchButtonRedElement()
      {
         Initialize();
      }

      #endregion

      #region Properties

      public override ElementBase.RotationStep Rotation
      {
         get { return base.Rotation; }
         set { base.Rotation = RotationStep.Step0; }
      }

      /// <summary>
      /// Gets the icon of the type of the bloc.
      /// </summary>
      public override Image TypeIcon
      {
         get { return (Image)global::Rwm.Otc.Properties.Resources.ICO_DESIGN_SWITCH_RED_16; }
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
         get { return "Switch (red)"; }
      }

      /// <summary>
      /// Gets the type of bloc.
      /// </summary>
      public override ElementBase.ElementType Type
      {
         get { return ElementType.SwitchButtonRed; }
      }

      /// <summary>
      /// Gets the current element status.
      /// </summary>
      public SwitchButtonStatus Status { get; private set; }

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

      #region Events

      public event OnStatusChangeHandler OnStatusChange;

      public delegate void OnStatusChangeHandler(ElementBase sender);

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
            case (int)SwitchButtonStatus.Undefined:
            case (int)SwitchButtonStatus.Off:
               this.Status = SwitchButtonStatus.Off;
               break;

            default:
               this.Status = SwitchButtonStatus.On;
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
            case SwitchButtonStatus.Undefined:
            case SwitchButtonStatus.Off:
               this.SetAccessoryStatus((int)SwitchButtonStatus.On, sendToSystem);
               break;

            default:
               this.SetAccessoryStatus((int)SwitchButtonStatus.Off, sendToSystem);
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

         foreach (var e in System.Enum.GetValues(typeof(SwitchButtonStatus)))
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
         return new ConnectionMap(Convert.ToInt32("1001", 2));
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.Status = SwitchButtonStatus.Undefined;
         this.AccessoryConnections = new ControlModuleConnection[1];
      }

      #endregion

   }
}
