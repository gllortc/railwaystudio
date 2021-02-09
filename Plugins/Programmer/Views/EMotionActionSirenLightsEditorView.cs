using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Rwm.Otc.Layout.EasyConnect;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class EMotionActionSirenLightsEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="EMotionActionSirenLightsEditorView"/>.
      /// </summary>
      public EMotionActionSirenLightsEditorView()
      {
         InitializeComponent();
         MapModelToView(new SirenLightsAction());
      }

      /// <summary>
      /// Returns a new instance of <see cref="EMotionActionSirenLightsEditorView"/>.
      /// </summary>
      /// <param name="action">Action to edit.</param>
      public EMotionActionSirenLightsEditorView(SirenLightsAction action)
      {
         InitializeComponent();
         MapModelToView(action);
      }

      #endregion

      #region Properties

      public SirenLightsAction Action { get; private set; }

      #endregion

      #region Event Handlers

      private void CmdOK_Click(object sender, EventArgs e)
      {
         if (!MapViewToModel()) return;

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Private Members

      private void MapModelToView(SirenLightsAction action)
      {
         this.Action = action;

         cboButton.Properties.Items.Clear();
         cboButton.Properties.Items.Add(new ImageComboBoxItem("Always active"));
         cboButton.Properties.Items.Add(new ImageComboBoxItem("Activated by button 1"));
         cboButton.Properties.Items.Add(new ImageComboBoxItem("Activated by button 2"));

         spinOutput1.Value = this.Action.Output1;
         spinOutput2.Value = this.Action.Output2;
         cboButton.SelectedIndex = this.Action.ActionButtonIndex;
      }

      private bool MapViewToModel()
      {
         this.Action.Output1 = Decimal.ToInt32(spinOutput1.Value);
         this.Action.Output2 = Decimal.ToInt32(spinOutput2.Value);
         this.Action.ActionButtonIndex = cboButton.SelectedIndex;

         if (this.Action.Output1 < 1 || this.Action.Output1 > 8)
         {
            MessageBox.Show("eMotion module have 8 outputs only.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            spinOutput1.Focus();
            return false;
         }
         else if (this.Action.Output2 < 1 || this.Action.Output2 > 8)
         {
            MessageBox.Show("eMotion module have 8 outputs only.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            spinOutput2.Focus();
            return false;
         }
         else if (this.Action.Output1 == this.Action.Output2)
         {
            MessageBox.Show("LEDs should be connected on different outputs.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            spinOutput1.Focus();
            return false;
         }

         return true;
      }

      #endregion

   }
}