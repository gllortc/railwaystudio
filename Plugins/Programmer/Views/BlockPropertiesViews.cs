using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Designer.Controls;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class BlockPropertiesViews : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="BlockPropertiesViews"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      /// <param name="element">Element.</param>
      public BlockPropertiesViews(Element element)
      {
         InitializeComponent();

         this.Element = element;

         txtName.Text = element.Name;
         lblPosition.Text = element.Coordinates.ToString();
         lblType.Text = element.Properties.Description;
         lblID.Text = element.ID.ToString();
         picBlock.Size = OTCContext.Project.Theme.ElementSize;
         picBlock.Image = element.GetImage(OTCContext.Project.Theme, false);
         lblStatus.Text = "-";

         if (element.Properties.IsAccessory)
         {
            lblStatus.Text = string.Format("{0} ({1})",
                                           element.Properties.GetStatusDescription(element.AccessoryStatus),
                                           element.AccessoryStatus);
         }

         ListAccessoryConnections();
         ListFeedbackConnections();
         ListActions();
      }

      #endregion

      #region Properties

      public Element Element { get; private set; }

      public List<OutputEditorControl> Connections { get; private set; }

      // internal OutputStatusEditorControl StatusEditorControl { get; private set; }

      #endregion

      #region Event Handlers

      void Connection_ConnectionChanged(object sender, ConnectionChangedEventArgs e)
      {
         // Update the connection info
         // this.Element.AccessoryConnections[e.ConnectionIndex - 1] = e.Connection;

         // Refresh the connection map information
         // this.StatusEditorControl.Refresh();
      }

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      private void CmdOK_Click(object sender, EventArgs e)
      {
         try
         {
            // Get the properties
            this.Element.Name = txtName.Text.Trim();

            // Store the element properties
            Element.Save(this.Element);

            // Save the connections (inputs and outputs)
            foreach (AccessoryDecoderConnection output in this.Element.AccessoryConnections)
               AccessoryDecoderConnection.Save(output);

            // Save the actions
            foreach (ElementAction action in this.Element.Actions)
               ElementAction.Save(action);

            this.DialogResult = DialogResult.OK;
            this.Close();
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR storing data:" + Environment.NewLine + Environment.NewLine + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      #endregion

      #region Private Members

      private void ListAccessoryConnections()
      {
         OutputEditorControl control;
         AccessoryDecoderConnection connection;

         if (!this.Element.Properties.IsAccessory || this.Element.Properties.NumberOfAccessoryConnections <= 0)
         {
            tabAccessoryConnections.PageVisible = false;
            return;
         }

         // Create connection controls
         for (int i = 1; i <= this.Element.Properties.NumberOfAccessoryConnections; i++)
         {
            connection = AccessoryDecoderConnection.GetByIndex(this.Element, i);

            if (connection != null)
            {
               control = new OutputEditorControl(connection);
            }
            else
            {
               control = new OutputEditorControl(this.Element);
            }

            control.ConnectionIndex = i;
            control.Text = string.Format("Accessory connection {0}", i);
            control.Dock = DockStyle.Top;
            control.ConnectionChanged += Connection_ConnectionChanged;

            tabAccessoryInputs.Controls.Add(control);

            control.BringToFront();
         }

         //this.StatusEditorControl = new OutputStatusEditorControl(this.Element);
         //this.StatusEditorControl.Dock = DockStyle.Fill;
         //this.StatusEditorControl.MapChanged += StatusEditorControl_MapChanged;
         //tabAccessoryMap.Controls.Add(this.StatusEditorControl);

         //this.StatusEditorControl.Refresh();
      }

      private void ListFeedbackConnections()
      {
         InputEditorControl control;
         FeedbackEncoderConnection connection;

         if (!this.Element.Properties.IsFeedback || this.Element.Properties.NumberOfFeedbackConnections <= 0)
         {
            tabFeedbackConnections.PageVisible = false;
            return;
         }

         // Create connection controls
         for (int i = 1; i <= this.Element.Properties.NumberOfFeedbackConnections; i++)
         {
            connection = FeedbackEncoderConnection.GetByIndex(this.Element, i);

            if (connection != null)
            {
               control = new InputEditorControl(connection);
            }
            else
            {
               control = new InputEditorControl(this.Element);
            }

            control.ConnectionIndex = i;
            control.Text = string.Format("Sensor connection {0}", i);
            control.Dock = DockStyle.Top;

            tabFeedbackConnections.Controls.Add(control);

            control.BringToFront();
         }
      }

      private void ListActions()
      {
         if (!this.Element.Properties.ActionsAllowed)
         {
            tabBlockActions.PageVisible = false;
            return;
         }

         ActionManagerControl ctrl = new ActionManagerControl(this.Element);
         ctrl.Dock = DockStyle.Fill;

         tabBlockActions.Controls.Add(ctrl);
      }

      #endregion

   }
}