﻿using Rwm.Otc.LayoutControl.Actions;
using Rwm.Otc.Themes;
using Rwm.Otc.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Rwm.Otc.LayoutControl.Elements
{
   /// <summary>
   /// Abstract class that allows implement all types of blocks (single, turnouts, signals, etc).
   /// </summary>
   public abstract class ElementBase 
   {

      #region Constants

      /// <summary>Default status for all blocks.</summary>
      public const int STATUS_UNDEFINED = 0;

      #endregion

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

      /// <summary>
      /// All element types.
      /// </summary>
      public enum ElementType : int
      {
         /// <summary>Undefined element type.</summary>
         Undefined = 0,
         /// <summary>Stright element type.</summary>
         Stright = 1,
         /// <summary>Curved element type.</summary>
         Curve = 2,
         /// <summary>Stop buffer element type.</summary>
         StopBuffer = 3,
         /// <summary>Turnout left element type.</summary>
         TurnoutLeft = 10,
         /// <summary>Turnout right element type.</summary>
         TurnoutRight = 11,
         /// <summary>Turnout Y element type.</summary>
         TurnoutY = 12,
         /// <summary>Turnout triple element type.</summary>
         TurnoutTriple = 13,
         /// <summary>Double turnout right element type.</summary>
         DoubleTurnoutLeft = 15,
         /// <summary>Main signal element type.</summary>
         StrightTwoAspectSignal = 20,
         /// <summary>Main signal element type.</summary>
         StrightThreeAspectSignal = 21,
         /// <summary>Main signal element type.</summary>
         StrightAdvancedSignal = 22,
         /// <summary>Main signal element type.</summary>
         StrightShuntSignal = 23,
         /// <summary>Switch button (blue).</summary>
         SwitchButtonBlue = 30,
         /// <summary>Switch button (red).</summary>
         SwitchButtonRed = 31,
         /// <summary>Switch button (green).</summary>
         SwitchButtonGreen = 32,
         /// <summary>Switch button (yellow).</summary>
         SwitchButtonYellow = 33,
         /// <summary>Stright sensor.</summary>
         StrightSensor = 34,
         /// <summary>Occupation element.</summary>
         OccupationBlock = 40
      }

      /// <summary>
      /// Enumera los tipos de descodificadores de accesorios.
      /// </summary>
      public enum ElementFeedbackStatus : int
      {
         /// <summary>Accessory control module.</summary>
         Deactivated = 0,
         /// <summary>Accessory control module.</summary>
         Activated = 1
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ElementBase"/>.
      /// </summary>
      public ElementBase()
      {
         Initialize();
      }

      /// <summary>
      /// Returns a new instance of <see cref="ElementBase"/>.
      /// </summary>
      /// <param name="elementId">Element unique identifier (DB).</param>
      public ElementBase(int elementId)
      {
         Initialize();

         this.ID = elementId;
      }

      #endregion

      #region Events

      // An event that clients can use to be notified whenever the elements of the list change.
      internal event EventHandler<ElementEventArgs> ImageChanged;

      #endregion

      #region Properties

      /// <summary>
      /// Identificador único del elemento.
      /// </summary>
      [Browsable(false)]
      public int ID { get; internal set; }

      /// <summary>
      /// Gets or sets the owner switchboard panel.
      /// </summary>
      [Browsable(false)]
      public SwitchboardPanel SwitchboardPanel { get; set; }

      /// <summary>
      /// Columna en la que se sitúa el bloque (X).
      /// </summary>
      [Browsable(false)]
      public int X { get; set; }

      /// <summary>
      /// Fila en la que se sitúa el bloque (Y).
      /// </summary>
      [Browsable(false)]
      public int Y { get; set; }

      /// <summary>
      /// Gets the number of blocks corresponding to width of the element.
      /// </summary>
      [Browsable(false)]
      public virtual int Width 
      {
         get { return 1; }
      }

      /// <summary>
      /// Gets the coordinates for the element.
      /// </summary>
      public Coordinates Coordinates
      {
         get { return new Coordinates(this.X, this.Y); }
      }

      /// <summary>
      /// Rotación del elemento.
      /// </summary>
      [Browsable(false)]
      public virtual RotationStep Rotation { get; set; }

      /// <summary>
      /// Nombre descriptivo del bloque.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Gets the icon of the type of the bloc.
      /// </summary>
      [Browsable(false)]
      public abstract Image TypeIcon { get; }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      public abstract string TypeGroup { get; }

      /// <summary>
      /// Gets the description of the type of the bloc.
      /// </summary>
      public abstract string TypeDescription { get; }

      /// <summary>
      /// Gets the type of bloc.
      /// </summary>
      [Browsable(false)]
      public abstract ElementType Type { get; }

      /// <summary>
      /// Gets or sets the list of output connections (accessories) for the element.
      /// </summary>
      public ControlModuleConnection[] AccessoryConnections { get; set; }

      /// <summary>
      /// Gets or sets the list of input connections (sensors) for the element.
      /// </summary>
      public ControlModuleConnection[] FeedbackConnections { get; set; }

      /// <summary>
      /// Gets or sets the list of event actions for the element.
      /// </summary>
      public List<ElementAction> Actions { get; internal set; }

      #endregion

      #region Methods

      /// <summary>
      /// Returns the image to show in switchboard panel.
      /// </summary>
      /// <returns>The requested image.</returns>
      public virtual Image GetImage(ITheme theme, bool designMode)
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
         return new Size(theme.ElementSize.Width * this.Width, theme.ElementSize.Height);
      }

      /// <summary>
      /// Rotate the element 90º to right direction.
      /// </summary>
      public virtual void Rotate()
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

         // Raise events
         this.OnImageChanged(new ElementEventArgs(this));
      }

      /// <summary>
      /// Return a <see cref="System.String"/> representing the name of the element.
      /// </summary>
      /// <returns>The name of the element.</returns>
      public override string ToString()
      {
         return (!string.IsNullOrWhiteSpace(this.Name) ? this.Name : this.Coordinates.ToString());
      }

      #endregion

      #region Event Handlers

      /// <summary>
      /// The event-invoking method that derived classes can override.
      /// </summary>
      protected virtual void OnImageChanged(ElementEventArgs e)
      {
         EventHandler<ElementEventArgs> handler = ImageChanged;
         if (handler != null)
         {
            handler(this, e);
         }
      }

      #endregion

      #region Static Members

      /// <summary>
      /// Check if a element is controlled as an accessory.
      /// </summary>
      /// <param name="element">Element to check.</param>
      /// <returns><c>true</c> if the element can be controlled as an accesory or <c>false</c> in all other cases.</returns>
      public static bool IsAccessoryElement(ElementBase element)
      {
         return (typeof(IAccessory).IsAssignableFrom(element.GetType()));
      }

      /// <summary>
      /// Check if a element can send feedback signal.
      /// </summary>
      /// <param name="element">Element to check.</param>
      /// <returns><c>true</c> if the element can send feedback signal or <c>false</c> in all other cases.</returns>
      public static bool IsFeedbackElement(ElementBase element)
      {
         return (typeof(IFeedback).IsAssignableFrom(element.GetType()));
      }

      /// <summary>
      /// Check if a element can contain a train.
      /// </summary>
      /// <param name="element">Element to check.</param>
      /// <returns><c>true</c> if the element can contain a train or <c>false</c> in all other cases.</returns>
      public static bool IsBlockElement(ElementBase element)
      {
         return (typeof(IBlock).IsAssignableFrom(element.GetType()));
      }

      /// <summary>
      /// Check if a element can be included in a route.
      /// </summary>
      /// <param name="element">Element to check.</param>
      /// <returns><c>true</c> if the element is routable or <c>false</c> in all other cases.</returns>
      public static bool IsRoutableElement(ElementBase element)
      {
         return (typeof(IRoutable).IsAssignableFrom(element.GetType()));
      }

      /// <summary>
      /// Check if a element is controlled as an accessory.
      /// </summary>
      /// <param name="element">Element to check.</param>
      /// <returns><c>true</c> if the element can be controlled as an accesory or <c>false</c> in all other cases.</returns>
      public static int GetAccessoryStatus(ElementBase element)
      {
         IAccessory accElement = element as IAccessory;
         if (accElement != null)
         {
            return accElement.GetAccessoryStatus();
         }

         return ElementBase.STATUS_UNDEFINED;
      }

      /// <summary>
      /// Check if a element is controlled as an accessory.
      /// </summary>
      /// <param name="element">Element to check.</param>
      /// <returns><c>true</c> if the element can be controlled as an accesory or <c>false</c> in all other cases.</returns>
      public static int GetFeedbackStatus(ElementBase element)
      {
         IFeedback fbElement = element as IFeedback;
         if (fbElement != null)
         {
            return fbElement.GetFeedbackStatus();
         }

         return ElementBase.STATUS_UNDEFINED;
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ID = 0;
         this.SwitchboardPanel = null;
         this.X = 0;
         this.Y = 0;
         this.Rotation = RotationStep.Step0;
         this.Name = string.Empty;
         this.AccessoryConnections = null;
         this.FeedbackConnections = null;
         this.Actions = null;
      }

      #endregion

   }
}
