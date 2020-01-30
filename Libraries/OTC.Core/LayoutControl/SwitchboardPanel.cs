using Rwm.Otc.LayoutControl.Elements;
using Rwm.Otc.Utils;
using System;
using System.Collections.Generic;

namespace Rwm.Otc.LayoutControl
{
   /// <summary>
   /// Implements a switchboard panel.
   /// </summary>
   public class SwitchboardPanel : IEquatable<SwitchboardPanel>
   {

      #region Enumerations

      public enum MoveDirection
      {
         Up,
         Down,
         Left,
         Right
      }

      #endregion

      #region Construtors

      /// <summary>
      /// Returns a new instance of <see cref="SwitchboardPanel"/>
      /// </summary>
      public SwitchboardPanel()
      {
         Initialize();
      }

      /// <summary>
      /// Returns a new instance of <see cref="SwitchboardPanel"/>
      /// </summary>
      public SwitchboardPanel(int panelId)
      {
         Initialize();

         this.ID = panelId;
      }

      #endregion

      #region Properties

      public int ID { get; set; }

      public string Name { get; set; }

      public string Description { get; set; }

      public int Width { get; set; }

      public int Height { get; set; }

      public Project Project { get; set; }

      public List<ElementBase> Elements { get; set; }

      #endregion

      #region Methods
   
      public void Add(ElementBase newBlock)
      {
         this.Delete(newBlock);
         this.Elements.Add(newBlock);
      }

      public void Delete(ElementBase deletedBlock)
      {
         ElementBase toRemove = null;

         foreach (ElementBase element in this.Elements)
         {
            if (deletedBlock.Coordinates.Equals(element.Coordinates))
            {
               toRemove = element;
               break;
            }
         }

         if (toRemove != null)
         {
            this.Elements.Remove(toRemove);
         }
      }

      /// <summary>
      /// Move all blocks one position in the specified direction.
      /// </summary>
      /// <param name="direction">Movement direction.</param>
      public void Move(MoveDirection direction)
      {
         int index = 0;

         // Index initialization
         switch (direction)
         {
            case MoveDirection.Left:
            case MoveDirection.Up:
               index = int.MaxValue; 
               break;

            case MoveDirection.Down:
            case MoveDirection.Right:
               index = int.MinValue;
               break;
         }

         // Check if it is possible to move in the specified direction
         foreach (ElementBase element in this.Elements)
         {
            switch (direction)
            {
               case MoveDirection.Up:
                  index = (element.Y < index ? element.Y : index);
                  if (index <= 0) throw new Exception("Cannot move UP: one or more elements are placed in TOP of the current switchboard.");
                  break;

               case MoveDirection.Down:
                  index = (element.Y > index ? element.Y : index);
                  if (index > this.Height - 2) throw new Exception("Cannot move DOWN: one or more elements are placed in BOTTOM of the current switchboard.");
                  break;

               case MoveDirection.Left:
                  index = (element.X < index ? element.X : index);
                  if (index <= 0) throw new Exception("Cannot move LEFT: one or more elements are placed at the beggining of the current switchboard.");
                  break;

               case MoveDirection.Right:
                  index = (element.X > index ? element.X : index);
                  if (index > this.Width - 2) throw new Exception("Cannot move RIGHT: one or more elements are placed at the end of the current switchboard.");
                  break;
            }
         }

         foreach (ElementBase element in this.Elements)
         {
            switch (direction)
            {
               case MoveDirection.Up:     element.Y--;   break;
               case MoveDirection.Down:   element.Y++;   break;
               case MoveDirection.Left:   element.X--;   break;
               case MoveDirection.Right:  element.X++;   break;
            }
         }
      }

      /// <summary>
      /// Clear all activated route in the panel.
      /// </summary>
      public void ClearRoute()
      {
         foreach (ElementBase element in this.Elements)
         {
            if (ElementBase.IsRoutableElement(element))
            {
               ((IRoutable)element).SetInRoute(false);
            }
         }
      }

      /// <summary>
      /// Check if a position is occupied by some element.
      /// </summary>
      /// <param name="coords">Coordinates to check.</param>
      /// <returns>A value indicating if the position is occupied.</returns>
      public bool IsOccupied(Coordinates coords)
      {
         foreach (ElementBase element in this.Elements)
         {
            if (coords.Equals(element.Coordinates))
            {
               return true;
            }
         }

         return false;
      }

      public bool Equals(SwitchboardPanel other)
      {
         if (other == null) return false;
         return (this.ID == other.ID);
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ID = 0;
         this.Name = string.Empty;
         this.Description = string.Empty;
         this.Width = 0;
         this.Height = 0;
         this.Project = null;
         this.Elements = new List<ElementBase>();
      }

      #endregion

   }
}
