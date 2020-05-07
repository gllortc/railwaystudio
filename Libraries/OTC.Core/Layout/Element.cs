using System;
using System.Collections.Generic;
using System.Drawing;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Systems;
using Rwm.Otc.Themes;
using Rwm.Otc.Trains;
using Rwm.Otc.Utils;
using static Rwm.Otc.Data.ORMForeignCollection;

namespace Rwm.Otc.Layout
{

   #region Enumerations

   /// <summary>
   /// All element rotation positions.
   /// </summary>
   public enum RotationStep : int
   {
      /// <summary>North position (undefined).</summary>
      Step0 = 0,
      /// <summary>East position (undefined).</summary>
      Step90 = 1,
      /// <summary>South position (undefined).</summary>
      Step180 = 2,
      /// <summary>West position (undefined).</summary>
      Step270 = 3
   }

   #endregion

   [ORMTable("ELEMENTS")]
   public class Element : ORMEntity<Element>
   {

      #region Constants

      /// <summary>Default status for all blocks.</summary>
      public const int STATUS_UNDEFINED = 0;

      #endregion

      #region Constructors

      /// <summary>
      /// Return a new instance of <see cref="Element"/>.
      /// </summary>
      public Element() { }

      #endregion

      #region Events

      ///// <summary>
      ///// An event that clients can use to be notified whenever the elements of the list change.
      ///// </summary>
      //internal event EventHandler<ElementEventArgs> ImageChanged;

      /// <summary>
      /// Event raised when a train enter or leaves the element.
      /// </summary>
      internal event EventHandler<OccupationEventArgs> OccupationChanged;

      /// <summary>
      /// Event raised when a new feedback status is adopted by the element.
      /// </summary>
      internal event EventHandler<FeedbackEventArgs> FeedbackStatusChanged;

      /// <summary>
      /// Event raised when a new status is adopted by the element.
      /// </summary>
      internal event EventHandler<AccessoryEventArgs> AccessoryStatusChanged;

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; }

      /// <summary>
      /// Gets or sets the owner switchboard panel.
      /// </summary>
      [ORMProperty("switchboardid")]
      public Switchboard Switchboard { get; set; }

      /// <summary>
      /// Gets or sets the owner switchboard panel.
      /// </summary>
      [ORMProperty("type")]
      public ElementType Properties { get; set; }

      /// <summary>
      /// Columna en la que se sitúa el bloque (X).
      /// </summary>
      [ORMProperty("x")]
      public int X { get; set; }

      /// <summary>
      /// Fila en la que se sitúa el bloque (Y).
      /// </summary>
      [ORMProperty("y")]
      public int Y { get; set; }

      /// <summary>
      /// Rotación del elemento.
      /// </summary>
      [ORMProperty("rotation")]
      public RotationStep Rotation { get; set; }

      /// <summary>
      /// Nombre descriptivo del bloque.
      /// </summary>
      [ORMProperty("name")]
      public string Name { get; set; }

      /// <summary>
      /// Gets the current element status as an accessory element.
      /// </summary>
      [ORMProperty("status")]
      public int AccessoryStatus { get; private set; } = Element.STATUS_UNDEFINED;

      /// <summary>
      /// Gets the route element activated in the element.
      /// </summary>
      public RouteElement RouteElement { get; set; }

      /// <summary>
      /// Gets the current element feedback status.
      /// </summary>
      [ORMProperty("modelid")]
      public Train Train { get; set; }

      /// <summary>
      /// Gets or sets the list of event actions for the element.
      /// </summary>
      [ORMForeignCollection(OnDeleteActionTypes.DeleteInCascade)]
      public List<ElementAction> Actions { get; internal set; }

      /// <summary>
      /// Gets the coordinates for the element.
      /// </summary>
      public Coordinates Coordinates
      {
         get { return new Coordinates(this.X, this.Y); }
      }

      /// <summary>
      /// Gets or sets the list of output connections for the element.
      /// </summary>
      [ORMForeignCollection(OnDeleteActionTypes.DeleteInCascade)]
      public List<AccessoryDecoderConnection> AccessoryConnections { get; set; }

      /// <summary>
      /// Gets or sets the list of feedback input connections for the element.
      /// </summary>
      [ORMForeignCollection(OnDeleteActionTypes.DeleteInCascade)]
      public List<FeedbackEncoderConnection> FeedbackConnections { get; set; }

      /// <summary>
      /// Gets the current element feedback status.
      /// </summary>
      public bool FeedbackStatus { get; private set; }

      /// <summary>
      /// Gets a value indicating if the block is occupied.
      /// </summary>
      public bool IsBlockOccupied { get; private set; }

      /// <summary>
      /// Gets a value indicating if the element have one or more digital connections.
      /// </summary>
      public bool IsConnected
      {
         get { return (this.AccessoryConnections?.Count > 0); }
      }

      /// <summary>
      /// Gets a <see cref="System.String"/> representing the name of the element.
      /// </summary>
      public string DisplayName
      {
         get { return (!string.IsNullOrWhiteSpace(this.Name) ? this.Name : this.Coordinates.ToString()); }
      }

      /// <summary>
      /// Gets a <see cref="Boolean"/> value indicating if the status has been confirmed from the command station.
      /// </summary>
      internal bool Statusconfirmed { get; private set; } = false;

      #endregion

      #region Methods

      /// <summary>
      /// Returns the image to show in switchboard panel.
      /// </summary>
      /// <param name="designMode">Indicate if the switchboard is in design mode.</param>
      /// <returns>The requested image.</returns>
      public Image GetImage(ITheme theme, bool designMode)
      {
         return theme.GetElementImage(this, designMode);
      }

      /// <summary>
      /// Returns the image to show in switchboard panel.
      /// </summary>
      /// <returns>The requested image.</returns>
      public Image GetImage(ITheme theme, int status)
      {
         return theme.GetElementImage(this, status);
      }

      ///// <summary>
      ///// Returns the size (in pixels) of the element.
      ///// </summary>
      ///// <returns>The requested image size.</returns>
      //public Size GetSize(ITheme theme)
      //{
      //   return new Size(theme.ElementSize.Width * this.Properties.Width, theme.ElementSize.Height);
      //}

      /// <summary>
      /// Rotate the element 90º to right direction.
      /// </summary>
      public void Rotate()
      {
         if (this.Rotation == RotationStep.Step0)
         {
            this.Rotation = RotationStep.Step90;
         }
         else if (this.Rotation == RotationStep.Step90)
         {
            this.Rotation = RotationStep.Step180;
         }
         else if (this.Rotation == RotationStep.Step180)
         {
            this.Rotation = RotationStep.Step270;
         }
         else
         {
            this.Rotation = RotationStep.Step0;
         }

         // Raise project events
         this.Switchboard.Project.ElementImageChanged(this);
      }

      /// <summary>
      /// Get all coordinates occupied by the element.
      /// </summary>
      /// <returns>An array with all used coordinates.</returns>
      public IEnumerable<Coordinates> GetUsedCoordinates()
      {
         int x = this.X;
         Coordinates[] coords = new Coordinates[this.Properties.Width];
         for (int i = 0; i < this.Properties.Width; i++)
         {
            coords[i] = new Coordinates(x, this.Y);
            x++;
         }
         return coords;
      }

      /// <summary>
      /// Check if an element is occupying a coordinates block.
      /// </summary>
      /// <param name="element">Element to check.</param>
      /// <param name="coords">Coordinates to check.</param>
      /// <returns>A value indicating if the element is ocuupying the specified coordinates.</returns>
      public bool IsInCoordinates(Coordinates coords)
      {
         Coordinates tc = this.Coordinates.Clone();

         for (int x = this.Coordinates.X; x < this.Coordinates.X + this.Properties.Width; x++)
         {
            if (coords.Equals(tc)) return true;
            tc.X++;
         }

         return false;
      }

      /// <summary>
      /// Set feedback status for the element.
      /// </summary>
      /// <param name="status">New feedback status to be adopted by the element.</param>
      public void SetAccessoryStatus(int status)
      {
         if (!this.Properties.IsAccessory) 
            return;

         // Set the new status
         this.AccessoryStatus = status;

         // Save the element with new status
         Element.Save(this);

         // Raise project events
         OTCContext.Project.ElementImageChanged(this);
      }

      /// <summary>
      /// Send a request to the digital system to acquire next status.
      /// </summary>
      /// <returns>The requested status for the element.</returns>
      public void RequestAccessoryNextStatus()
      {
         if (!this.Properties.IsAccessory)
            return;

         // Get status to acquire
         int newStatus = this.GetAccessoryNextStatus(this.AccessoryStatus);

         // Transform status into a requests
         if (this.Properties.NumberOfAccessoryConnections == 1)
         {
            if (this.AccessoryConnections.Count > 0)
               OTCContext.Project.DigitalSystem.OperateAccessory(this.AccessoryConnections[0].DecoderOutput.Address, newStatus);
         }
         else if (this.Properties.NumberOfAccessoryConnections == 2)
         {

         }
      }

      /// <summary>
      /// Gets a list of all possible status in an accessory.
      /// </summary>
      /// <returns>An array filled with all status values that can be used in the accessory.</returns>
      public int[] GetAllAccessoryStatusValues()
      {
         int[] status = new int[this.Properties.AccessoryMaxStats];
         for (int i = 1; i <= this.Properties.AccessoryMaxStats; i++)
         {
            status[i - 1] = i;
         }
         return status;
      }

      ///// <summary>
      ///// Returns the default connection map for the specified connection index.
      ///// </summary>
      ///// <returns>An instance of <see cref="ConnectionMap"/> with default settings.</returns>
      //public DeviceConnectionMap GetDefaultConnectionMap(int connectionIndex)
      //{
      //   return new DeviceConnectionMap(Convert.ToInt32("1001", 2));
      //}

      /// <summary>
      /// Set feedback status for the element.
      /// </summary>
      /// <param name="status">New feedback status to be adopted by the element.</param>
      public void SetFeedbackStatus(bool status)
      {
         if (!this.Properties.IsFeedback)
            return;

         this.FeedbackStatus = status;

         // Raise project events
         OTCContext.Project.ElementImageChanged(this);
      }

      ///// <summary>
      ///// Set route next status for the element.
      ///// </summary>
      ///// <returns>A value indicating if the element must be repainted.</returns>
      //public void SetRouteNextStatus()
      //{
      //   if (!this.Properties.IsRouteable) 
      //      return;

      //   int newStatus = this.GetAccessoryNextStatus(this.RouteStatus);
      //   if (newStatus <= 1) this.IsActivatedInRoute = !this.IsActivatedInRoute;

      //   // Raise project events
      //   OTCContext.Project.ElementImageChanged(this);
      //}

      ///// <summary>
      ///// Activate/deactivate the element in a route). 
      ///// </summary>
      ///// <param name="activated">A value indicating if the element will be activated or deactivated.</param>
      //public void SetInRoute(bool activated)
      //{
      //   if (!this.Properties.IsRouteable)
      //      return;

      //   this.IsActivatedInRoute = activated;

      //   // Raise project events
      //   OTCContext.Project.ElementImageChanged(this);
      //}

      /// <summary>
      /// Return a <see cref="System.String"/> representing the name of the element.
      /// </summary>
      /// <returns>The name of the element.</returns>
      public override string ToString()
      {
         return this.DisplayName;
      }

      #endregion

      #region Event Handlers

      /// <summary>
      /// Event handler for the <c>FeedbackStatusChanged</c> event.
      /// </summary>
      /// <param name="e"></param>
      protected virtual void OnFeedbackStatusChanged(FeedbackEventArgs e)
      {
         this.FeedbackStatusChanged?.Invoke(this, e);
      }

      /// <summary>
      /// Event handler for the <c>BlockStatusChanged</c> event.
      /// </summary>
      /// <param name="e"></param>
      protected virtual void OnBlockStatusChanged(OccupationEventArgs e)
      {
         this.OccupationChanged?.Invoke(this, e);
      }

      /// <summary>
      /// Event handler for the <c>AccessoryStatusChanged</c> event.
      /// </summary>
      /// <param name="e"></param>
      protected virtual void OnAccessoryStatusChanged(AccessoryEventArgs e)
      {
         this.AccessoryStatusChanged?.Invoke(this, e);
      }

      #endregion

      #region Static Members

      /// <summary>
      /// Get an <see cref="Element"/> by its accessory address.
      /// </summary>
      /// <param name="address">Digital address.</param>
      /// <returns>The related <see cref="Element"/> or <c>null</c> if no <see cref="Element"/> is connected to the specified address.</returns>
      public static Element GetByAccessoryAddress(int address)
      {
         foreach (Element element in Element.FindAll())
         {
            foreach (AccessoryDecoderConnection connection in element.AccessoryConnections)
            {
               if (connection.DecoderOutput.Address == address)
                  return element;
            }
         }

         return null;
      }

      /// <summary>
      /// Get an <see cref="Element"/> by its feedback address.
      /// </summary>
      /// <param name="address">Digital address.</param>
      /// <returns>The related <see cref="Element"/> or <c>null</c> if no <see cref="Element"/> is connected to the specified address.</returns>
      public static Element GetByFeedbackAddress(int address, int pointAddress)
      {
         foreach (Element element in Element.FindAll())
         {
            foreach (FeedbackEncoderConnection connection in element.FeedbackConnections)
            {
               if (connection.EncoderInput.Address == address && connection.EncoderInput.PointAddress == pointAddress)
                  return element;
            }
         }

         return null;
      }

      /// <summary>
      /// Move all switchboard blocks to the specified orientation.
      /// </summary>
      /// <param name="element">Switchboard to move.</param>
      /// <param name="dir">Movement orientation.</param>
      public static void Move(Element element, Switchboard.MoveDirection dir)
      {
         Logger.LogDebug("Rwm.Otc.Layout.Element.Move([" + element.ToString() + "], " + dir.ToString() + ")");

         try
         {
            switch (dir)
            {
               case Switchboard.MoveDirection.Up:
                  element.Y--;
                  break;
               case Switchboard.MoveDirection.Down:
                  element.Y++;
                  break;
               case Switchboard.MoveDirection.Left:
                  element.X--;
                  break;
               case Switchboard.MoveDirection.Right:
                  element.X++;
                  break;
               default:
                  break;
            }

            Element.Save(element);
         }
         catch (Exception ex)
         {
            Logger.LogError(ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Gets the next status for the specified current status.
      /// </summary>
      private int GetAccessoryNextStatus(int currentStatus = Element.STATUS_UNDEFINED)
      {
         int newStatus;

         // Get status to acquire
         if (currentStatus <= Element.STATUS_UNDEFINED)
            newStatus = 1;
         else if (this.AccessoryStatus == this.Properties.AccessoryMaxStats)
            newStatus = 1;
         else
            newStatus = currentStatus + 1;

         return newStatus;
      }

      #endregion

   }
}
