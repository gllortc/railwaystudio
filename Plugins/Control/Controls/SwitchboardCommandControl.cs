using RailwayStudio.Common;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.Layout.Actions;
using Rwm.Otc.Layout.Elements;
using Rwm.Otc.Systems;
using Rwm.Otc.Utils;
using System;
using System.Windows.Forms;

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
      public SwitchboardCommandControl() : base(false) { }

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
      /// Gets or sets a value indicating if the actions must be disabled or not.
      /// </summary>
      public bool ActionsDisabled { get; set; }

      /// <summary>
      /// Gets or sets a value indicating if sensorscan be manually activated or not.
      /// </summary>
      public bool AllowManualSensorActivation { get; set; }

      /// <summary>
      /// Gets the pop-up menu for the IBlock elements.
      /// </summary>
      internal ContextMenuStrip BlockMenu { get; private set; }

      #endregion

      #region Methods

      public void SetSensorStatus(Coordinates coords, FeedbackStatus status)
      {
         ElementBase element = OTCContext.Project.Elements.Get(this.Switchboard, coords);
         if (element != null)
         {
            IFeedback fbBlock = element as IFeedback;
            fbBlock.SetFeedbackStatus(status);

            this.RepaintCoordinates(coords);
         }
      }

      #endregion

      #region Events

      // A delegate type for hooking up change notifications.
      //public delegate void BlockClickEventHandler(object sender, Rwm.Otc.Controls.CellClickEventArgs e);

      //// An event that clients can use to be notified whenever the elements of the list change.
      //public event BlockClickEventHandler BlockClick;

      // An event that clients can use to be notified whenever the elements of the list change.
      public event BlockAssignTrainEventHandler BlockAssignTrain;

      // A delegate type for hooking up change notifications.
      public delegate void BlockAssignTrainEventHandler(object sender, IBlock e);

      // An event that clients can use to be notified whenever the elements of the list change.
      public event BlockUnassignTrainEventHandler BlockUnassignTrain;

      // A delegate type for hooking up change notifications.
      public delegate void BlockUnassignTrainEventHandler(object sender, IBlock e);

      // An event that clients can use to be notified whenever the elements of the list change.
      public event SensorManuallyActivatedEventHandler SensorManuallyActivated;

      // A delegate type for hooking up change notifications.
      public delegate void SensorManuallyActivatedEventHandler(object sender, CellClickEventArgs e, FeedbackStatus status);

      #endregion

      #region Event Handlers

      protected override void OnMouseDown(MouseEventArgs e)
      {
         Coordinates coords = new Coordinates((e.X + this.HorizontalScroll.Value) / OTCContext.Project.Theme.ElementSize.Width,
                                              (e.Y + this.VerticalScroll.Value) / OTCContext.Project.Theme.ElementSize.Height);

         // Get the affected element
         ElementBase element = OTCContext.Project.Elements.Get(this.Switchboard, coords);
         if (element == null)
         {
            return;
         }

         if (ElementBase.IsFeedbackElement(element) && !ElementBase.IsBlockElement(element))
         {
            IFeedback fbBlock = element as IFeedback;

            fbBlock.SetFeedbackStatus(FeedbackStatus.Activated);

            this.ExecuteActions(element,
                                ElementAction.ExecutionEventType.OnSensorStatusChange,
                                (int)FeedbackStatus.Activated);
         }
      }

      protected override void OnMouseUp(MouseEventArgs e)
      {
         // Adapt click coordinates to an element click
         Coordinates coords = new Coordinates((e.X + this.HorizontalScroll.Value) / OTCContext.Project.Theme.ElementSize.Width,
                                              (e.Y + this.VerticalScroll.Value) / OTCContext.Project.Theme.ElementSize.Height);

         // Get the clicked element
         ElementBase element = OTCContext.Project.Elements.Get(this.Switchboard, coords);
         if (element == null) return;

         // Accessory element clicked
         if (ElementBase.IsAccessoryElement(element))
         {
            // Update the element status
            IAccessory accElement = element as IAccessory;
            accElement.SetAccessoryNextStatus(true);

            // Store the new status
            OTCContext.Project.Update(element);

            // Execute element associated actions
            this.ExecuteActions(element,
                                ElementAction.ExecutionEventType.OnAccessoryStatusChange,
                                ElementBase.GetAccessoryStatus(element));
         }

         // Feedback element clicked (manual activation)
         if (ElementBase.IsFeedbackElement(element) && !ElementBase.IsBlockElement(element))
         {
            IFeedback fbElement = element as IFeedback;

            fbElement.SetFeedbackStatus((int)FeedbackStatus.Deactivated);

            this.ExecuteActions(element,
                                ElementAction.ExecutionEventType.OnSensorStatusChange,
                                (int)FeedbackStatus.Deactivated);
         }

         // Block element clicked
         if (ElementBase.IsBlockElement(element))
         {
            this.ShowBlockMenu(element as IBlock);
         }
      }

      void Project_FeedbackStatusChanged(object sender, FeedbackEventArgs e)
      {
         ElementBase element = sender as ElementBase;
         if (element != null && element.Switchboard.Equals(this.Switchboard))
         {
            StudioContext.LogInformation("Feedback signal received in element {0} (status {1})",
                                         element.Name, e.NewStatus);
         }
      }

      void Project_BlockImageChanged(object sender, ElementEventArgs e)
      {
         // Repaint cell picture
         if (e.Element != null && e.Element.Switchboard.Equals(this.Switchboard))
         {
            this.RepaintCoordinates(e.Element.Coordinates);
         }
      }

      void cmdBlockAssign_ItemClick(object sender, EventArgs e)
      {
         if (this.BlockAssignTrain != null)
         {
            IBlock blockElement = ((ToolStripItem)sender).Tag as IBlock;
            if (blockElement != null)
            {
               this.BlockAssignTrain(this, blockElement);
            }
         }
      }

      void cmdBlockUnassign_ItemClick(object sender, EventArgs e)
      {
         if (this.BlockUnassignTrain != null)
         {
            IBlock blockElement = ((ToolStripItem)sender).Tag as IBlock;
            if (blockElement != null)
            {
               this.BlockUnassignTrain(this, blockElement);
            }
         }
      }

      void cmdBlockRouteAssign_ItemClick(object sender, EventArgs e)
      {
         // Get the toolstrip
         ToolStripMenuItem item = sender as ToolStripMenuItem;
         if (item == null) return;

         // Get the route to activate
         Route route = item.Tag as Route;
         if (route == null) return;

         // Activate the route
         OTCContext.Project.ActivateRoute(route);
      }

      void cmdBlockSensorActivated_ItemClick(object sender, EventArgs e)
      {
         ElementBase element = ((ToolStripItem)sender).Tag as ElementBase;
         if (element != null)
         {
            IBlock blockElement = element as IBlock;
            if (blockElement != null)
            {
               // Simulate a feedback impulse
               this.SensorManuallyActivated(this,
                                            new CellClickEventArgs(this, element.Coordinates, element),
                                            FeedbackStatus.Activated);
               System.Threading.Thread.Sleep(500);
               this.SensorManuallyActivated(this,
                                            new CellClickEventArgs(this, element.Coordinates, element),
                                            FeedbackStatus.Deactivated);
            }
         }
      }

      #endregion

      #region Private Members

      private void Initialize()
      {
         this.ActionsDisabled = false;
         this.AllowManualSensorActivation = false;

         // Create the context menu for the control
         this.CreateContextMenu();

         // Register project events
         OTCContext.Project.ElementImageChanged += Project_BlockImageChanged;
         OTCContext.Project.FeedbackStatusChanged += Project_FeedbackStatusChanged;
      }

      /// <summary>
      /// Execute actions for the specified element.
      /// </summary>
      private void ExecuteActions(ElementBase element, ElementAction.ExecutionEventType eventType, int elementStatus)
      {
         if (element.Actions == null || element.Actions.Count <= 0) return;

         foreach (ElementAction action in element.Actions)
         {
            if (action.EventType == eventType)
            {
               if (action.ConditionParentStatus == ElementAction.CONDITION_DISABLED ||
                  (action.ConditionParentStatus != ElementAction.CONDITION_DISABLED && action.ConditionParentStatus == elementStatus))
               {
                  action.Execute(element, OTCContext.Project);
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
            this.BlockMenu.Items.Add("&Assign train...", Properties.Resources.ICO_BLOCK_ASSIGN_16, new EventHandler(cmdBlockAssign_ItemClick));
            this.BlockMenu.Items.Add("&Unassign train (remove)", Properties.Resources.ICO_BLOCK_CLEAR_16, new EventHandler(cmdBlockUnassign_ItemClick));
            this.BlockMenu.Items.Add("Set &destination", Properties.Resources.ICO_BLOCK_GO_16);
            this.BlockMenu.Items.Add("-");
            this.BlockMenu.Items.Add("Activate &sensor", Properties.Resources.ICO_SENSORS_16, new EventHandler(cmdBlockSensorActivated_ItemClick));
         }
      }

      /// <summary>
      /// Create the block elements pop-up menu.
      /// </summary>
      private void ShowBlockMenu(IBlock blockElement)
      {
         ToolStripMenuItem destItem = null;

         this.BlockMenu.Items[0].Enabled = true;
         this.BlockMenu.Items[0].Tag = blockElement;
         this.BlockMenu.Items[1].Enabled = blockElement.IsOccupied;
         this.BlockMenu.Items[1].Tag = blockElement;
         this.BlockMenu.Items[2].Enabled = blockElement.IsOccupied;

         destItem = this.BlockMenu.Items[2] as ToolStripMenuItem;

         // Clear previous destination menu items
         for (int i = 0; i < destItem.DropDownItems.Count; i++) destItem.DropDownItems[i].Dispose();
         destItem.DropDownItems.Clear();

         // Get all destinations
         foreach (Route dest in OTCContext.Project.GetDestinations(blockElement))
         {
            if (dest.FromBlock.ID != blockElement.ID)
            {
               destItem.DropDownItems.Add(string.Format("{0} (route {1})", dest.FromBlock, dest), null, new EventHandler(cmdBlockRouteAssign_ItemClick));
               destItem.DropDownItems[destItem.DropDownItems.Count - 1].Tag = dest;
            }
            else if (dest.ToBlock.ID != blockElement.ID)
            {
               destItem.DropDownItems.Add(string.Format("{0} (route {1})", dest.ToBlock.Name, dest), null, new EventHandler(cmdBlockRouteAssign_ItemClick));
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
