using System;
using System.Windows.Forms;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Rwm.Otc.Systems;
using Rwm.Otc.Utils;

namespace Rwm.Otc.UI.Controls
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

      public void SetSensorStatus(Coordinates coords, bool status)
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
      public event BlockAssignTrainEventHandler BlockAssignTrain;

      // A delegate type for hooking up change notifications.
      public delegate void BlockAssignTrainEventHandler(object sender, Element e);

      // An event that clients can use to be notified whenever the elements of the list change.
      public event BlockUnassignTrainEventHandler BlockUnassignTrain;

      // A delegate type for hooking up change notifications.
      public delegate void BlockUnassignTrainEventHandler(object sender, Element e);

      #endregion

      #region Event Handlers

      protected override void OnMouseDown(MouseEventArgs e)
      {
         try
         {
            Coordinates coords = new Coordinates((e.X + this.HorizontalScroll.Value) / OTCContext.Project.Theme.ElementSize.Width,
                                              (e.Y + this.VerticalScroll.Value) / OTCContext.Project.Theme.ElementSize.Height);

            // Get the affected element
            Element element = this.Switchboard.GetBlock(coords);
            if (element == null) return;

            if (OTCContext.Project.AllowManualSensorActivation && element.Properties.IsFeedback && !element.Properties.IsBlock)
            {
               element.SetFeedbackStatus(true);

               this.ExecuteActions(element,
                                   Rwm.Otc.Layout.ElementAction.EventType.OnSensorStatusChange,
                                   (int)FeedbackStatus.Activated);
            }
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
            // Adapt click coordinates to an element click
            Coordinates coords = new Coordinates((e.X + this.HorizontalScroll.Value) / OTCContext.Project.Theme.ElementSize.Width,
                                                 (e.Y + this.VerticalScroll.Value) / OTCContext.Project.Theme.ElementSize.Height);

            // Get the clicked element
            Element element = this.Switchboard.GetBlock(coords);
            if (element == null) return;

            // Accessory element clicked
            if (element.Properties.IsAccessory)
            {
               // Request the next status to the command station
               element.RequestAccessoryNextStatus();

               // Store the new status
               Element.Save(element);

               // Execute element associated actions
               this.ExecuteActions(element,
                                   Rwm.Otc.Layout.ElementAction.EventType.OnAccessoryStatusChange,
                                   element.AccessoryStatus);
            }

            // Feedback element clicked (manual activation)
            if (element.Properties.IsFeedback && OTCContext.Project.AllowManualSensorActivation && !element.Properties.IsBlock)
            {
               element.SetFeedbackStatus(false);

               this.ExecuteActions(element,
                                   Rwm.Otc.Layout.ElementAction.EventType.OnSensorStatusChange,
                                   (int)FeedbackStatus.Deactivated);
            }

            // Block element clicked
            if (element.Properties.IsBlock)
            {
               this.ShowBlockMenu(element);
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
         }
      }

      //void Project_FeedbackStatusChanged(object sender, FeedbackEventArgs e)
      //{
      //   ElementBase element = sender as ElementBase;
      //   if (element != null && element.Switchboard.Equals(this.Switchboard))
      //   {
      //      this.sys

      //      StudioContext.LogInformation("Feedback signal received in element {0} (status {1})",
      //                                   element.Name, e.NewStatus);
      //   }
      //}

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
         if (this.BlockAssignTrain != null)
         {
            if (((ToolStripItem)sender).Tag is Element blockElement)
            {
               this.BlockAssignTrain(this, blockElement);
            }
         }
      }

      void CmdBlockUnassign_ItemClick(object sender, EventArgs e)
      {
         if (this.BlockUnassignTrain != null)
         {
            if (((ToolStripItem)sender).Tag is Element blockElement)
            {
               this.BlockUnassignTrain(this, blockElement);
            }
         }
      }

      void CmdBlockRouteAssign_ItemClick(object sender, EventArgs e)
      {
         // Get the toolstrip
         if (!(sender is ToolStripMenuItem item)) return;

         // Get the route to activate
         if (!(item.Tag is Route route)) return;

         // Activate the route
         route.Activate();
      }

      void CmdBlockSensorActivated_ItemClick(object sender, EventArgs e)
      {
         if (((ToolStripItem)sender).Tag is Element element)
         {
            // Simulate a feedback impulse
            OTCContext.Project.DigitalSystem.SetSensorStatus(element, FeedbackStatus.Activated);
            System.Threading.Thread.Sleep(500);
            OTCContext.Project.DigitalSystem.SetSensorStatus(element, FeedbackStatus.Deactivated);
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
      }

      /// <summary>
      /// Execute actions for the specified element.
      /// </summary>
      private void ExecuteActions(Element element, Rwm.Otc.Layout.ElementAction.EventType eventType, int elementStatus)
      {
         if (!OTCContext.Project.ExecuteBlockActions || element.Actions == null || element.Actions.Count <= 0) return;

         foreach (Rwm.Otc.Layout.ElementAction action in element.Actions)
         {
            if (action.Event == eventType)
            {
               if (action.IsConditionStatusDisabled ||
                  (!action.IsConditionStatusDisabled && action.ConditionStatus == elementStatus))
               {
                  action.Execute();
               }
            }
         }
      }

      /// <summary>
      /// Create the block elements pop-up menu.
      /// </summary>
      private void CreateContextMenu()
      {
         if (this.BlockMenu == null)
         {
            this.BlockMenu = new ContextMenuStrip();
            this.BlockMenu.Items.Add("&Assign train...", Properties.Resources.ICO_BLOCK_ASSIGN_16, new EventHandler(CmdBlockAssign_ItemClick));
            this.BlockMenu.Items.Add("&Unassign train (remove)", Properties.Resources.ICO_BLOCK_CLEAR_16, new EventHandler(CmdBlockUnassign_ItemClick));
            this.BlockMenu.Items.Add("Set &destination", Properties.Resources.ICO_BLOCK_GO_16);
            this.BlockMenu.Items.Add("-");
            this.BlockMenu.Items.Add("Activate &sensor", Properties.Resources.ICO_SENSORS_16, new EventHandler(CmdBlockSensorActivated_ItemClick));
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
         foreach (Route dest in OTCContext.Project.GetDestinations(blockElement))
         {
            if (dest.FromBlock.ID != blockElement.ID)
            {
               destItem.DropDownItems.Add(string.Format("{0} (route {1})", dest.FromBlock, dest), null, new EventHandler(CmdBlockRouteAssign_ItemClick));
               destItem.DropDownItems[destItem.DropDownItems.Count - 1].Tag = dest;
            }
            else if (dest.ToBlock.ID != blockElement.ID)
            {
               destItem.DropDownItems.Add(string.Format("{0} (route {1})", dest.ToBlock.Name, dest), null, new EventHandler(CmdBlockRouteAssign_ItemClick));
               destItem.DropDownItems[destItem.DropDownItems.Count - 1].Tag = dest;
            }
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
