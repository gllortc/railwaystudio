using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.Utils;
using Rwm.Studio.Plugins.Control.Controls;
using System;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class ActionEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constants

      private const int STATUS_UNKNOWN = 0;

      #endregion

      #region Constructors

      public ActionEditorView(Element ownerBlock, Rwm.Otc.Layout.ElementAction action)
      {
         InitializeComponent();

         this.Action = action;
         this.OwnerBlock = ownerBlock;

         this.ShowData();
      }

      #endregion

      #region Properties

      internal Element OwnerBlock { get; private set; }

      internal Rwm.Otc.Layout.ElementAction Action { get; private set; }

      internal IActionParametersEditor Editor { get; private set; }

      internal Rwm.Otc.Layout.ElementAction.EventType SelectedEvent
      {
         get
         {
            if (cboEvent.SelectedItem == null)
            {
               return Rwm.Otc.Layout.ElementAction.EventType.Undefined;
            }
            else
            {
               ImageComboBoxItem item = cboEvent.SelectedItem as ImageComboBoxItem;
               return (Rwm.Otc.Layout.ElementAction.EventType)item.Value;
            }
         }
      }

      internal int SelectedStatusFilter
      {
         get
         {
            if (cboStatus.SelectedItem == null)
            {
               return 0;
            }
            else
            {
               ImageComboBoxItem item = cboStatus.SelectedItem as ImageComboBoxItem;
               return ((AccessoryStatus)item.Value).Status;
            }
         }
      }

      #endregion

      #region Event Handlers

      private void FrmActionEditor_Load(object sender, EventArgs e)
      {
         txtDescription.SelectAll();
         txtDescription.Focus();
      }

      private void cmdOK_Click(object sender, System.EventArgs e)
      {
         if (string.IsNullOrWhiteSpace(txtDescription.Text))
         {
            MessageBox.Show("You must provide a valid descriptive name for the current action.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         else if (cboEvent.SelectedItem == null)
         {
            MessageBox.Show("You must select the event you want to execute the current action.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         else if (!this.Editor.CheckData())
         {
            return;
         }

         try
         {
            this.Action.Element = this.OwnerBlock;
            this.Action.Description = txtDescription.Text.Trim();
            this.Action.Event = this.SelectedEvent;
            this.Action.ConditionStatus = this.SelectedStatusFilter;

            ElementAction.Save(this.Action);

            this.OwnerBlock.Actions.Add(this.Action);

            this.DialogResult = DialogResult.OK;
            this.Close();
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR storing action: " + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void cmdCancel_Click(object sender, System.EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Private Members

      private void ShowData()
      {
         txtDescription.Text = this.Action.Description;
         ListEvents(this.Action.Event);
         ListStatus(this.Action.ConditionStatus);
         ShowActionParameters();
      }

      /// <summary>
      /// Show the appropriate editor control without comparations to allow create 
      /// new editors without revisiong this code.
      /// </summary>
      private void ShowActionParameters()
      {
         XtraUserControl ctrl = null;

         switch (this.Action.Type)
         {
            case ElementAction.ActionTypes.ActivateRoute:
               ctrl = new ActivateRouteActionControl(this.Action);
               ctrl.Dock = DockStyle.Top;
               ctrl.Enabled = true;
               break;

            case ElementAction.ActionTypes.PlaySound:
               ctrl = new PlaySoundActionControl(this.Action);
               ctrl.Dock = DockStyle.Top;
               ctrl.Enabled = true;
               break;

            case ElementAction.ActionTypes.SetAccessoryStatus:
               ctrl = new SetAccessoryStatusActionControl(this.Action);
               ctrl.Dock = DockStyle.Top;
               ctrl.Enabled = true;
               break;
         }

         this.Controls.Add(ctrl);

         ctrl.BringToFront();

         this.Editor = ctrl as IActionParametersEditor;
      }

      private void ListEvents(Rwm.Otc.Layout.ElementAction.EventType selectedEvent)
      {
         ImageComboBoxItem item;

         cboEvent.Properties.Items.Clear();

         item = new ImageComboBoxItem();
         item.Description = StringUtils.SplitCamelCaseString(Rwm.Otc.Layout.ElementAction.EventType.OnAccessoryStatusChange.ToString());
         item.Value = Rwm.Otc.Layout.ElementAction.EventType.OnAccessoryStatusChange;
         item.ImageIndex = 0;
         cboEvent.Properties.Items.Add(item);

         if (selectedEvent == Rwm.Otc.Layout.ElementAction.EventType.OnAccessoryStatusChange)
         {
            cboEvent.SelectedItem = item;
         }

         item = new ImageComboBoxItem();
         item.Description = StringUtils.SplitCamelCaseString(Rwm.Otc.Layout.ElementAction.EventType.OnSensorStatusChange.ToString());
         item.Value = Rwm.Otc.Layout.ElementAction.EventType.OnSensorStatusChange;
         item.ImageIndex = 0;
         cboEvent.Properties.Items.Add(item);

         if (selectedEvent == Rwm.Otc.Layout.ElementAction.EventType.OnSensorStatusChange)
         {
            cboEvent.SelectedItem = item;
         }
      }

      private void ListStatus(int selectedStatus)
      {
         ImageComboBoxItem item;

         cboStatus.Properties.Items.Clear();

         item = new ImageComboBoxItem();
         item.Description = "No status filter";
         item.Value = ElementAction.CONDITION_DISABLED;
         item.ImageIndex = 3;

         cboStatus.Properties.Items.Add(item);
         cboStatus.SelectedItem = item;

         foreach (AccessoryStatus enumInfo in this.OwnerBlock.Properties.AccessoryStatus)
         {
            if (enumInfo.Status > ActionEditorView.STATUS_UNKNOWN)
            {
               item = new ImageComboBoxItem();
               item.Description = StringUtils.SplitCamelCaseString(enumInfo.Name);
               item.Value = enumInfo;
               item.ImageIndex = 2;

               cboStatus.Properties.Items.Add(item);

               if (enumInfo.Status == selectedStatus)
               {
                  cboStatus.SelectedItem = item;
               }
            }
         }
      }

      #endregion

   }
}