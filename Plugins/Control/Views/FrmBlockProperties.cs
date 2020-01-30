using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Control.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class FrmBlockProperties : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="FrmBlockProperties"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      /// <param name="element">Element.</param>
      public FrmBlockProperties(Element element)
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

         ListOutputs();
         ListInputs();
         ListActions();
      }

      #endregion

      #region Properties

      public Element Element { get; private set; }

      public List<OutputEditorControl> Connections { get; private set; }

      internal OutputStatusEditorControl StatusEditorControl { get; private set; }

      #endregion

      #region Event Handlers

      void connection_ConnectionChanged(object sender, ConnectionChangedEventArgs e)
      {
         // Update the connection info
         this.Element.AccessoryConnections[e.ConnectionIndex - 1] = e.Connection;

         // Refresh the connection map information
         this.StatusEditorControl.Refresh();
      }

      void StatusEditorControl_MapChanged(object sender, MapChangedEventArgs e)
      {
         foreach (DeviceConnection connection in this.Element.AccessoryConnections)
         {
            if (connection != null)
               DeviceConnection.Save(connection);
         }
      }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.Close();
      }

      private void cmdOK_Click(object sender, EventArgs e)
      {
         try
         {
            // Get the properties
            this.Element.Name = txtName.Text.Trim();

            // Store the element properties
            Element.Save(this.Element);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
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

      private void ListOutputs()
      {
         OutputEditorControl connection;

         if (!this.Element.Properties.IsAccessory)
         {
            tabBlockOutputs.PageVisible = false;
            return;
         }

         // Get element outputs
         // this.Element.AccessoryConnections = DeviceConnection.FindBy("Element", this.Element);

         // Create connection controls
         for (int i = 0; i < this.Element.Properties.NumConnections; i++)
         {
            if (this.Element.AccessoryConnections.Count > i && this.Element.AccessoryConnections[i] != null)
            {
               connection = new OutputEditorControl(this.Element.AccessoryConnections[i]);
            }
            else
            {
               connection = new OutputEditorControl(this.Element);
            }

            connection.ConnectionIndex = i + 1;
            connection.Text = string.Format("Accessory connection {0}", i + 1);
            connection.Dock = System.Windows.Forms.DockStyle.Top;
            connection.ConnectionChanged += connection_ConnectionChanged;

            tabAccessoryConnections.Controls.Add(connection);

            connection.BringToFront();
         }

         this.StatusEditorControl = new OutputStatusEditorControl(this.Element);
         this.StatusEditorControl.Dock = DockStyle.Fill;
         this.StatusEditorControl.MapChanged += StatusEditorControl_MapChanged;
         tabAccessorySetup.Controls.Add(this.StatusEditorControl);

         this.StatusEditorControl.Refresh();
      }

      private void ListInputs()
      {
         InputEditorControl connection;

         if (!this.Element.Properties.IsFeedback)
         {
            tabBlockInputs.PageVisible = false;
            return;
         }

         // Get element inputs
         this.Element.FeedbackConnections = OTCContext.Project.GetDeviceConnections(this.Element, Device.DeviceType.SensorModule);

         // Create connection controls
         for (int i = 0; i < this.Element.FeedbackConnections.Length; i++)
         {
            if (this.Element.FeedbackConnections[i] != null)
            {
               connection = new InputEditorControl(this.Element.FeedbackConnections[i]);
            }
            else
            {
               connection = new InputEditorControl(this.Element);
            }

            connection.ConnectionIndex = i + 1;
            connection.Text = string.Format("Sensor connection {0}", i + 1);
            connection.Dock = System.Windows.Forms.DockStyle.Top;

            tabBlockInputs.Controls.Add(connection);

            connection.BringToFront();
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