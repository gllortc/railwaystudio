using DevExpress.XtraEditors.Controls;
using Rwm.Otc;
using Rwm.Otc.Layout;
using Rwm.Otc.Utils;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Designer.Controls
{
   public partial class SetAccessoryStatusActionControl : DevExpress.XtraEditors.XtraUserControl, IActionParametersEditor
   {

      #region Constructors

      public SetAccessoryStatusActionControl()
      {
         InitializeComponent();

         this.Action = null;
      }

      public SetAccessoryStatusActionControl(Rwm.Otc.Layout.ElementAction action)
      {
         InitializeComponent();

         this.Action = action;

         this.ListElements(this.Action.IntegerParameter1);
      }

      #endregion

      #region Properties

      public Element SelectedBlock
      {
         get { return ((ImageComboBoxItem)cboElement.SelectedItem).Value as Element; }
      }

      public ElementAction Action { get; private set; }

      #endregion

      #region Methods

      /// <summary>
      /// Check if edited data is valid for the parameters introduced.
      /// </summary>
      /// <returns>A value indicating if the data is valid or not.</returns>
      public bool CheckData()
      {
         if (cboElement.SelectedItem == null)
         {
            MessageBox.Show("You must select the element you want to set when the event will be fired.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
         }
         else if (cboStatus.SelectedItem == null)
         {
            MessageBox.Show("You must select the status you want to set for the selected element when the event will be fired.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
         }

         this.Action.IntegerParameter1 = ((Element)((ImageComboBoxItem)cboElement.SelectedItem).Value).ID;
         this.Action.IntegerParameter2 = ((AccessoryStatus)((ImageComboBoxItem)cboStatus.SelectedItem).Value).Status;

         return true;
      }

      public bool CheckSupportedActionType(Rwm.Otc.Layout.ElementAction action)
      {
         return (action.GetType() == typeof(Rwm.Otc.Layout.ElementAction));
      }

      #endregion

      #region Event Handlers

      private void cboSound_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         if (this.SelectedBlock == null)
         {
            return;
         }

         this.ListStatus((int)this.Action.IntegerParameter2);
      }

      #endregion

      #region Private Members

      private void ListRoutes()
      {
         this.ListElements(-1);
      }

      private void ListElements(long selectedId)
      {
         ImageComboBoxItem item;

         foreach (Element element in Element.FindAll())
         {
            if (element.Properties.IsAccessory)
            {
               imlElements.Images.Add(element.GetImage(OTCContext.Project.Theme, true));

               item = new ImageComboBoxItem();
               item.Description = element.ToString();
               item.Value = element;
               item.ImageIndex = imlElements.Images.Count - 1;

               cboElement.Properties.Items.Add(item);

               if (selectedId == element.ID)
               {
                  cboElement.SelectedItem = item;
               }
            }
         }
      }

      private void ListStatus(int selectedStatus)
      {
         ImageComboBoxItem item;

         imlStatus.Images.Clear();
         cboStatus.Properties.Items.Clear();

         if (this.SelectedBlock == null)
         {
            return;
         }

         foreach (AccessoryStatus status in this.SelectedBlock.Properties.AccessoryStatus)
         {
            imlStatus.Images.Add(this.SelectedBlock.GetImage(OTCContext.Project.Theme, status.Status));

            item = new ImageComboBoxItem();
            item.Description = StringUtils.SplitCamelCaseString(status.Name);
            item.Value = status;
            item.ImageIndex = imlStatus.Images.Count - 1;

            cboStatus.Properties.Items.Add(item);

            if (selectedStatus == status.Status)
            {
               cboStatus.SelectedItem = item;
            }
         }
      }

      #endregion

   }
}
