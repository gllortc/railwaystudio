using DevExpress.XtraEditors.Controls;
using Rwm.Otc.Layout;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Designer.Controls
{
   public partial class PlaySoundActionControl : DevExpress.XtraEditors.XtraUserControl, IActionParametersEditor
   {

      #region Constructors

      public PlaySoundActionControl()
      {
         InitializeComponent();

         this.Action = null;
      }

      public PlaySoundActionControl(Rwm.Otc.Layout.ElementAction action)
      {
         InitializeComponent();

         this.Action = action;

         this.ListSounds(this.Action.IntegerParameter1);
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
         if (cboSound.SelectedItem == null)
         {
            MessageBox.Show("You must select the sound to play when the event will be fired.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
         }

         this.Action.IntegerParameter1 = ((Sound)((ImageComboBoxItem)cboSound.SelectedItem).Value).ID;

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
         this.ListSounds(-1);
      }

      private void ListSounds(long selectedId)
      {
         ImageComboBoxItem item;

         foreach (Sound sound in Sound.FindAll())
         {
            item = new ImageComboBoxItem();
            item.Description = sound.Name;
            item.Value = sound;
            item.ImageIndex = 0;

            cboSound.Properties.Items.Add(item);

            if (selectedId == sound.ID)
            {
               cboSound.SelectedItem = item;
            }
         }
      }

      #endregion

   }
}
