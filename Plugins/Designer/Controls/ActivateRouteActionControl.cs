using DevExpress.XtraEditors.Controls;
using Rwm.Otc.Layout;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Designer.Controls
{
   public partial class ActivateRouteActionControl : DevExpress.XtraEditors.XtraUserControl, IActionParametersEditor
   {

      #region Constructors

      public ActivateRouteActionControl()
      {
         InitializeComponent();

         this.Action = null;
      }

      public ActivateRouteActionControl(ElementAction action)
      {
         InitializeComponent();

         this.Action = action;

         this.ListRoutes(this.Action.IntegerParameter1);
      }

      #endregion

      #region Properties

      public ElementAction Action { get; private set; }

      #endregion

      #region Methods

      /// <summary>
      /// Check if edited data is valid for the parameters introduced.
      /// </summary>
      /// <returns>A value indicating if the data is valid or not.</returns>
      public bool CheckData()
      {
         if (cboRoute.SelectedItem == null)
         {
            MessageBox.Show("You must select the route to activate when the event will be fired.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
         }

         this.Action.IntegerParameter1 = ((Route)((ImageComboBoxItem)cboRoute.SelectedItem).Value).ID;

         return true;
      }

      public bool CheckSupportedActionType(Rwm.Otc.Layout.ElementAction action)
      {
         return (action.GetType() == typeof(Rwm.Otc.Layout.ElementAction));
      }

      #endregion

      #region Private Members

      private void ListRoutes()
      {
         this.ListRoutes(-1);
      }

      private void ListRoutes(long selectedId)
      {
         ImageComboBoxItem item;

         foreach (Route route in Route.FindAll())
         {
            item = new ImageComboBoxItem();
            item.Description = route.Name;
            item.Value = route;
            item.ImageIndex = 0;

            cboRoute.Properties.Items.Add(item);

            if (selectedId == route.ID)
            {
               cboRoute.SelectedItem = item;
            }
         }
      }

      #endregion

   }
}
