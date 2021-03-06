﻿using System;
using System.Collections.Generic;
using System.Drawing;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using static Rwm.Otc.Data.ORMForeignCollection;

namespace Rwm.Otc.Layout
{
   /// <summary>
   /// Implements a switchboard panel.
   /// </summary>
   [ORMTable("SWITCHBOARDS")]
   public class Switchboard : ORMEntity<Switchboard>, IEquatable<Switchboard>
   {

      #region Enumerations

      /// <summary>
      /// Global movement directions.
      /// </summary>
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
      /// Returns a new instance of <see cref="Switchboard"/>
      /// </summary>
      public Switchboard() : base()
      {
         this.Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; }

      /// <summary>
      /// Gets or sets the owner's project.
      /// </summary>
      [ORMProperty("PROJECTID")]
      public Project Project { get; set; }

      /// <summary>
      /// Gets or sets the switchboard name.
      /// </summary>
      [ORMProperty("NAME")]
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets the switchboard description/notes.
      /// </summary>
      [ORMProperty("DESCRIPTION")]
      public string Description { get; set; }

      /// <summary>
      /// Gets or sets the number of elements in X axis.
      /// </summary>
      [ORMProperty("WIDTH")]
      public int Width { get; set; }

      /// <summary>
      /// Gets or sets the number of elements in Y axis.
      /// </summary>
      [ORMProperty("HEIGHT")]
      public int Height { get; set; }

      /// <summary>
      /// Gets or sets the list of elements contained in the current switchboard.
      /// </summary>
      [ORMForeignCollection(OnDeleteActionTypes.DeleteInCascade)]
      public List<Element> Elements { get; set; }

      /// <summary>
      /// Gets the associated small icon (16x16px).
      /// </summary>
      public static Image SmallIcon
      {
         get { return Properties.Resources.ICO_SWITCHBOARD_16; }
      }

      /// <summary>
      /// Gets the associated large icon (32x32px).
      /// </summary>
      public static Image LargeIcon
      {
         get { return Properties.Resources.ICO_SWITCHBOARD_32; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Move all blocks one position in the specified direction.
      /// </summary>
      /// <param name="direction">Movement direction.</param>
      public void Move(MoveDirection direction)
      {
         int index = 0;
         int horizontal = 0;
         int vertical = 0;
         Element[] items = this.Elements.ToArray();

         Logger.LogDebug(this, "[CLASS].Move({0})", direction);

         try
         {
            switch (direction)
            {
               case MoveDirection.Left:
                  horizontal = -1;
                  index = int.MaxValue;
                  break;

               case MoveDirection.Up:
                  vertical = -1;
                  index = int.MaxValue;
                  break;

               case MoveDirection.Down:
                  vertical = 1;
                  index = int.MinValue;
                  break;

               case MoveDirection.Right:
                  horizontal = 1;
                  index = int.MinValue;
                  break;
            }

            // Check if it is possible to move in the specified direction
            for (int i = 0; i < items.Length; i++)
            {
               switch (direction)
               {
                  case MoveDirection.Up:
                     index = (items[i].Y < index ? items[i].Y : index);
                     if (index <= 0) throw new Exception("Cannot move UP: one or more elements are placed in TOP of the current switchboard.");
                     break;

                  case MoveDirection.Down:
                     index = (items[i].Y > index ? items[i].Y : index);
                     if (index > this.Height - 2) throw new Exception("Cannot move DOWN: one or more elements are placed in BOTTOM of the current switchboard.");
                     break;

                  case MoveDirection.Left:
                     index = (items[i].X < index ? items[i].X : index);
                     if (index <= 0) throw new Exception("Cannot move LEFT: one or more elements are placed at the beggining of the current switchboard.");
                     break;

                  case MoveDirection.Right:
                     index = (items[i].X > index ? items[i].X : index);
                     if (index > this.Width - 2) throw new Exception("Cannot move RIGHT: one or more elements are placed at the end of the current switchboard.");
                     break;
               }
            }

            // Update database elements
            string sql = @"PRAGMA ignore_check_constraints=on;
                           BEGIN TRANSACTION;
                           UPDATE " + Element.TableName + @" 
                           SET x = x + :horizontal, y = y + :vertical 
                           WHERE switchboardid = :switchboardid; 
                           COMMIT;
                           PRAGMA ignore_check_constraints=off;";

            Connect();
            Element.SetParameter("horizontal", horizontal);
            Element.SetParameter("vertical", vertical);
            Element.SetParameter("switchboardid", this.ID);
            Element.ExecuteNonQuery(sql);

            // Update memory elements
            foreach (Element element in this.Elements)
            {
               switch (direction)
               {
                  case MoveDirection.Left:  element.X--; break;
                  case MoveDirection.Up:    element.Y--; break;
                  case MoveDirection.Down:  element.Y++; break;
                  case MoveDirection.Right: element.X++; break;
               }
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Check if a position is occupied by some element.
      /// </summary>
      /// <param name="coords">Coordinates to check.</param>
      /// <returns>A value indicating if the position is occupied.</returns>
      public bool IsOccupied(Point coords)
      {
         foreach (Element element in this.Elements)
         {
            if (coords.Equals(element.Coordinates))
            {
               return true;
            }
         }

         return false;
      }

      public Image GetImage()
      {
         Bitmap offScreenBmp;
         Point startP = new Point();
         Point endP = new Point();

         Logger.LogDebug(this, "[CLASS].GetImage()");

         offScreenBmp = new Bitmap(this.Width * OTCContext.Project.Theme.ElementSize.Width,
                                   this.Height * OTCContext.Project.Theme.ElementSize.Height);

         using (Graphics g = Graphics.FromImage(offScreenBmp))
         {
            try
            {
               g.Clear(SystemColors.Control);
            }
            catch
            {
               return null;
            }

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen pencil = new Pen(Color.LightGray, 1f);

            // Draw horizontal lines
            Point origin = new Point(0, 0);
            startP.X = origin.X;
            endP.X = origin.X + this.Width * OTCContext.Project.Theme.ElementSize.Width;
            for (int i = 0; i <= this.Height; i++)
            {
               startP.Y = origin.Y + i * OTCContext.Project.Theme.ElementSize.Height;
               endP.Y = startP.Y;
               g.DrawLine(pencil, startP, endP);
            }

            // Draw vertical lines
            startP.Y = origin.Y;
            endP.Y = origin.Y + this.Height * OTCContext.Project.Theme.ElementSize.Height;
            for (int i = 0; i <= this.Width; i++)
            {
               startP.X = origin.X + i * OTCContext.Project.Theme.ElementSize.Width;
               endP.X = startP.X;
               g.DrawLine(pencil, startP, endP);
            }

            // Paint blocks
            foreach (Element element in this.Elements)
            {
               g.DrawImage(element.GetImage(OTCContext.Project.Theme, false),
                           new Point(element.Coordinates.X * OTCContext.Project.Theme.ElementSize.Width,
                                     element.Coordinates.Y * OTCContext.Project.Theme.ElementSize.Height));
            }

            g.Dispose();
         }

         return offScreenBmp;
      }

      /// <summary>
      /// Check if two switchboards are equals.
      /// </summary>
      /// <param name="other">Switchboard to compare.</param>
      /// <returns>A value indicating if both switchboards are the same in current project.</returns>
      public bool Equals(Switchboard other)
      {
         if (other == null) return false;
         return (this.ID == other.ID);
      }

      /// <summary>
      /// Get an element by its coordinates.
      /// </summary>
      /// <param name="sb">Parent switchboard.</param>
      /// <param name="coords">Coordinates to check.</param>
      /// <returns>The requested element or <c>null</c> if coordinates are empty.</returns>
      public Element GetBlock(Point coords)
      {
         foreach (Element element in this.Elements)
         {
            if (element.IsInCoordinates(coords))
            {
               return element;
            }
         }

         return null;
      }

      /// <summary>
      /// Returns a string that represents the current object.
      /// </summary>
      /// <returns>A string representing the current object.</returns>
      public override string ToString()
      {
         return (string.IsNullOrWhiteSpace(this.Name) ? base.ToString() : this.Name);
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
         this.Elements = null;
      }

      #endregion

   }
}
