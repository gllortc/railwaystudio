using System;
using System.Collections.Generic;
using System.Drawing;
using Rwm.Otc.Data.ORM;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Systems;
using Rwm.Otc.Themes;
using Rwm.Otc.TrainControl;
using Rwm.Otc.Utils;
using static Rwm.Otc.Data.ORM.ORMForeignCollection;

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

   [ORMTable("elements")]
   public class Element : ORMEntity<Element>
   {

      #region Constants

      /// <summary>Default status for all blocks.</summary>
      public const int STATUS_UNDEFINED = 0;

      #endregion

      #region Constructors

      public Element()
      {
         this.Initialize();
      }

      #endregion

      #region Events

      /// <summary>
      /// An event that clients can use to be notified whenever the elements of the list change.
      /// </summary>
      internal event EventHandler<ElementEventArgs> ImageChanged;

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
      /// Gets the current element feedback status.
      /// </summary>
      [ORMProperty("status")]
      public int AccessoryStatus { get; private set; }

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
      public List<FeedbackDecoderConnection> FeedbackConnections { get; set; }

      /// <summary>
      /// Gets the current element feedback status.
      /// </summary>
      public bool FeedbackStatus { get; private set; }

      /// <summary>
      /// Gets a value indicating if the block is occupied.
      /// </summary>
      public bool IsBlockOccupied { get; private set; }

      /// <summary>
      /// Gets or sets a value indicating if the block is activated in currect active route.
      /// </summary>
      public bool IsActivatedInRoute { get; private set; }

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

      #endregion

      #region Methods

      /// <summary>
      /// Returns the image to show in switchboard panel.
      /// </summary>
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

      /// <summary>
      /// Returns the size (in pixels) of the element.
      /// </summary>
      /// <returns>The requested image size.</returns>
      public Size GetSize(ITheme theme)
      {
         return new Size(theme.ElementSize.Width * this.Properties.Width, theme.ElementSize.Height);
      }

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
         this.SetAccessoryStatus(status, true);
      }

      /// <summary>
      /// Set feedback status for the element.
      /// </summary>
      /// <param name="status">New feedback status to be adopted by the element.</param>
      public void SetAccessoryStatus(int status, bool sendToSystem)
      {
         this.AccessoryStatus = status;

         // Send the command to the digital system
         if (sendToSystem)
         {
            OTCContext.Project.DigitalSystem.SetAccessoryStatus(this);
         }

         // Raise project events
         OTCContext.Project.ElementImageChanged(this);
         OTCContext.Project.AccessoryStatusChanged(this);
      }

      /// <summary>
      /// Set next status for the element.
      /// </summary>
      /// <param name="sendToSystem">A value indicating if the new status must be sent to digital system.</param>
      /// <returns>The new status adopted by the element.</returns>
      public int SetAccessoryNextStatus(bool sendToSystem)
      {
         if (!this.Properties.IsAccessory)
            return Element.STATUS_UNDEFINED;

         if (this.AccessoryStatus <= Element.STATUS_UNDEFINED)
            this.SetAccessoryStatus(1);
         else if (this.AccessoryStatus == this.Properties.AccessoryMaxStats)
            this.SetAccessoryStatus(1);
         else
            this.SetAccessoryStatus(this.AccessoryStatus + 1);

         return this.AccessoryStatus;
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

      /// <summary>
      /// Returns the default connection map for the specified connection index.
      /// </summary>
      /// <returns>An instance of <see cref="ConnectionMap"/> with default settings.</returns>
      public DeviceConnectionMap GetDefaultConnectionMap(int connectionIndex)
      {
         return new DeviceConnectionMap(Convert.ToInt32("1001", 2));
      }

      /// <summary>
      /// Set feedback status for the element.
      /// </summary>
      /// <param name="status">New feedback status to be adopted by the element.</param>
      public void SetFeedbackStatus(bool status)
      {
         this.FeedbackStatus = status;

         // Raise project events
         OTCContext.Project.ElementImageChanged(this);
         OTCContext.Project.FeedbackStatusChanged(this);
      }

      /// <summary>
      /// Set next status for the element.
      /// </summary>
      /// <returns>A value indicating if the element must be repainted.</returns>
      public void SetRouteNextStatus()
      {
         this.SetInRoute(!this.IsActivatedInRoute);
      }

      /// <summary>
      /// Activate/deactivate the element in a route). 
      /// </summary>
      /// <param name="activated">A value indicating if the element will be activated or deactivated.</param>
      public void SetInRoute(bool activated)
      {
         if (!this.Properties.IsRouteable)
            return;

         this.IsActivatedInRoute = activated;

         // Raise project events
         OTCContext.Project.ElementImageChanged(this);
      }

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
      /// Get an <see cref="Element"/> by its digital address.
      /// </summary>
      /// <param name="address">Digital address.</param>
      /// <returns>The related <see cref="Element"/> or <c>null</c> if no <see cref="Element"/> is connected to the specified address.</returns>
      public static Element GetByConnectionAddress(int address)
      {
         foreach (Element element in Element.FindAll())
         {
            foreach (AccessoryDecoderConnection connection in element.AccessoryConnections)
            {
               if (connection.Address == address)
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

      private void Initialize()
      {
         this.AccessoryStatus = Element.STATUS_UNDEFINED;
      }

      #endregion

   }
}
