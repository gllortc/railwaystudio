﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Rwm.Otc;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Rwm.Otc.Layout.Traffic;
using Rwm.Otc.Systems;
using Rwm.Otc.Trains;
using Rwm.Studio.Plugins.Common;
using Rwm.Studio.Plugins.Common.Controls;

namespace Rwm.Studio.Plugins.Control.Controls
{
   /// <summary>
   /// Control to command a switchboard.
   /// </summary>
   public partial class SwitchboardCommandControl : SwitchboardControlBase
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="SwitchboardCommandControl"/>.
      /// </summary>
      /// <param name="switchboard">Switchboard to paint.</param>
      public SwitchboardCommandControl(Switchboard switchboard)
         : base(switchboard, false)
      {
         InitializeComponent();

         this.Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the pop-up menu for the IBlock elements.
      /// </summary>
      internal ContextMenuStrip BlockMenu { get; private set; }

      #endregion

      #region Methods

      public void SetSensorStatus(Point coords, bool status)
      {
         Element element = this.Switchboard.GetBlock(coords);
         if (element != null)
         {
            element.SetFeedbackStatus(status);

            this.RepaintCoordinates(coords);
         }
      }

      #endregion

      #region Events

      // An event that clients can use to be notified whenever the elements of the list change.
      public event BlockAssignmentChangedEventHandler BlockAssignmentChanged;

      // A delegate type for hooking up change notifications.
      public delegate void BlockAssignmentChangedEventHandler(object sender, EventArgs e);

      #endregion

      #region Event Handlers

      protected override void OnMouseDown(MouseEventArgs e)
      {
         try
         {
            // Get the clicked element
            Element element = this.GetElementByMouseCoordinates(e);
            if (element == null) return;

            // Activate the element feedback sensor
            element.FeedbackOperate(FeedbackStatus.Enabled);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
         }
      }

      protected override void OnMouseUp(MouseEventArgs e)
      {
         try
         {
            // Get the clicked element
            Element element = this.GetElementByMouseCoordinates(e);
            if (element == null) return;

            // Accessory element clicked
            element.AccessoryOperate();

            // Deactivate the element feedback sensor
            element.FeedbackOperate(FeedbackStatus.Disabled);

            // Block element clicked
            if (element.Properties.IsBlock) this.ShowBlockMenu(element);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
         }
      }

      private void OnDragOver(object sender, DragEventArgs e)
      {
         e.Effect = DragDropEffects.None;

         if (this.Enabled)
         {
            Element element = this.GetElementByMouseCoordinates(e);
            if (element == null) return;

            if (element.Properties.IsBlock)
            {
               e.Effect = DragDropEffects.All;
            }
         }
      }

      private void OnDragDrop(object sender, DragEventArgs e)
      {
         if (e.Data.GetDataPresent(typeof(Train)))
         {
            Element element = this.GetElementByMouseCoordinates(e);
            if (element == null) return;

            if (element.Properties.IsBlock)
            {
               if (!(e.Data.GetData(typeof(Train)) is Train train)) return;

               Element.AssignTrain(train, element);

               this.BlockAssignmentChanged?.Invoke(this, new EventArgs());
            }
         }
      }

      /// <summary>
      /// Handle all project elements image changed event to repaint affected elements.
      /// </summary>
      void Project_OnElementImageChanged(object sender, ElementEventArgs e)
      {
         // Repaint cell picture
         if (e.Element != null)
         {
            this.RepaintCoordinates(e.Element.Coordinates);
         }
      }

      void CmdBlockAssign_ItemClick(object sender, EventArgs e)
      {
         if (!(((ToolStripItem)sender).Tag is Element blockElement))
            return;

         Train selectedTrain = StudioContext.Find.Train("Assign train to block");
         if (selectedTrain == null)
            return;

         // Unassign previous train(s)
         Element.UnassignBlock(blockElement);

         // Assign selected train
         Element.AssignTrain(selectedTrain, blockElement);

         // Raise events
         this.BlockAssignmentChanged?.Invoke(this, new EventArgs());
      }

      void CmdBlockUnassign_ItemClick(object sender, EventArgs e)
      {
         if (((ToolStripItem)sender).Tag is Element blockElement)
         {
            Element.UnassignBlock(blockElement);

            this.BlockAssignmentChanged?.Invoke(this, new EventArgs());
         }
      }

      void CmdBlockRouteAssign_ItemClick(object sender, EventArgs e)
      {
         // Get the toolstrip
         if (!(sender is ToolStripMenuItem item)) return;

         // Get the route to activate
         if (!(item.Tag is Itinerary troute)) return;

         try
         {
            OTCContext.Project.TrafficManager.AddItinerary(troute);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      void CmdBlockSensorActivated_ItemClick(object sender, EventArgs e)
      {
         if (((ToolStripItem)sender).Tag is Element element)
         {
            // Simulate a feedback impulse
            OTCContext.Project.DigitalSystem.SetSensorStatus(element, FeedbackStatus.Enabled);
            System.Threading.Thread.Sleep(500);
            OTCContext.Project.DigitalSystem.SetSensorStatus(element, FeedbackStatus.Disabled);
         }
      }

      #endregion

      #region Private Members

      private void Initialize()
      {
         // Create the context menu for the control
         this.CreateContextMenu();

         // Suscribe to project events
         OTCContext.Project.OnElementImageChanged += Project_OnElementImageChanged;

         // Enable drag&drop for the trains in block elements
         this.AllowDrop = true;
         this.DragOver += OnDragOver;
         this.DragDrop += OnDragDrop;
      }

      /// <summary>
      /// Create the block elements pop-up menu.
      /// </summary>
      private void CreateContextMenu()
      {
         if (this.BlockMenu == null)
         {
            this.BlockMenu = new ContextMenuStrip();
            this.BlockMenu.Items.Add("&Aassign train", Properties.Resources.ICO_BLOCK_ASSIGN_16, new EventHandler(CmdBlockAssign_ItemClick));
            this.BlockMenu.Items.Add("&Unassign train (remove)", Properties.Resources.ICO_BLOCK_CLEAR_16, new EventHandler(CmdBlockUnassign_ItemClick));
            this.BlockMenu.Items.Add("Set &destination", Properties.Resources.ICO_BLOCK_GO_16);
            this.BlockMenu.Items.Add("-");
            this.BlockMenu.Items.Add("Activate &sensor", FeedbackEncoderInput.SmallIcon, new EventHandler(CmdBlockSensorActivated_ItemClick));
         }
      }

      /// <summary>
      /// Create the block elements pop-up menu.
      /// </summary>
      private void ShowBlockMenu(Element blockElement)
      {
         ToolStripMenuItem destItem = null;

         this.BlockMenu.Items[0].Enabled = true;
         this.BlockMenu.Items[0].Tag = blockElement;
         this.BlockMenu.Items[1].Enabled = blockElement.IsBlockOccupied;
         this.BlockMenu.Items[1].Tag = blockElement;
         this.BlockMenu.Items[2].Enabled = blockElement.IsBlockOccupied;

         destItem = this.BlockMenu.Items[2] as ToolStripMenuItem;

         // Clear previous destination menu items
         for (int i = 0; i < destItem.DropDownItems.Count; i++) destItem.DropDownItems[i].Dispose();
         destItem.DropDownItems.Clear();

         // Get all destinations
         foreach (Element block in OTCContext.Project.TrafficManager.GetDestinationsFromBlock(blockElement))
         {
            destItem.DropDownItems.Add(string.Format("{0}", block.DisplayName), null, new EventHandler(CmdBlockRouteAssign_ItemClick));
            destItem.DropDownItems[destItem.DropDownItems.Count - 1].Tag = new Itinerary(blockElement.Train, blockElement, block);

            //if (dest.FromBlock.ID != blockElement.ID)
            //{
            //   destItem.DropDownItems.Add(string.Format("{0} (route {1})", dest.FromBlock, dest), null, new EventHandler(CmdBlockRouteAssign_ItemClick));
            //   destItem.DropDownItems[destItem.DropDownItems.Count - 1].Tag = dest;
            //}
            //else if (dest.ToBlock.ID != blockElement.ID)
            //{
            //   destItem.DropDownItems.Add(string.Format("{0} (route {1})", dest.ToBlock.Name, dest), null, new EventHandler(CmdBlockRouteAssign_ItemClick));
            //   destItem.DropDownItems[destItem.DropDownItems.Count - 1].Tag = dest;
            //}
         }

         // Add an empty item in case of no destinations was found
         if (destItem.DropDownItems.Count <= 0)
         {
            destItem.DropDownItems.Add("No destination available");
            destItem.DropDownItems[destItem.DropDownItems.Count - 1].Enabled = false;
         }

         this.BlockMenu.Show(Cursor.Position);
      }

      #endregion

   }
}
