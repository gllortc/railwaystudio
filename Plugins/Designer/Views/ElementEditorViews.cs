using System;
using System.Windows.Forms;
using Rwm.Otc;
using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class ElementEditorViews : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ElementEditorViews"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      /// <param name="element">Element.</param>
      public ElementEditorViews(Element element)
      {
         InitializeComponent();
         MapModelToView(element);
      }

      #endregion

      #region Properties

      public Element Element { get; private set; }

      #endregion

      #region Event Handlers

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      private void CmdOK_Click(object sender, EventArgs e)
      {
         if (!this.MapViewToModel()) return;

         try
         {
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

      private void MapModelToView(Element element)
      {
         this.Element = element;

         txtName.Text = element.Name;
         lblPosition.Text = element.Coordinates.ToString();
         lblType.Text = element.Properties.Description;
         lblID.Text = element.ID.ToString();
         picBlock.Size = OTCContext.Project.Theme.ElementSize;
         picBlock.Image = element.GetImage(OTCContext.Project.Theme, false);
         lblStatus.Text = "-";

         tabAccessoryConnections.PageVisible = element.Properties.IsAccessory;
         tabFeedbackConnections.PageVisible = element.Properties.IsFeedback;

         if (element.Properties.IsAccessory)
         {
            

            lblStatus.Text = string.Format("{0} ({1})",
                                           element.Properties.GetStatusDescription(element.AccessoryStatus),
                                           element.AccessoryStatus);

            eccAccessoryConnections.SetElement(this.Element);
         }

         if (element.Properties.IsFeedback)
         {
            fccFeedbackConnections.SetElement(this.Element);
         }

         amcActions.SetElement(this.Element);
      }

      private bool MapViewToModel()
      {
         // Get the properties
         this.Element.Name = txtName.Text.Trim();

         return true;
      }

      #endregion

   }
}