using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Rwm.Otc.Layout.EasyConnect;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class EMotionActionFailigLampEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="EMotionActionFailigLampEditorView"/>.
      /// </summary>
      public EMotionActionFailigLampEditorView()
      {
         InitializeComponent();
         MapModelToView(new LampFailureAction());
      }

      /// <summary>
      /// Returns a new instance of <see cref="EMotionActionFailigLampEditorView"/>.
      /// </summary>
      /// <param name="action">Action to edit.</param>
      public EMotionActionFailigLampEditorView(LampFailureAction action)
      {
         InitializeComponent();
         MapModelToView(action);
      }

      #endregion

      #region Properties

      public LampFailureAction Action { get; private set; }

      #endregion

      #region Event Handlers

      private void cmdOK_Click(object sender, EventArgs e)
      {
         if (!MapViewToModel()) return;

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Private Members

      private void MapModelToView(LampFailureAction action)
      {
         this.Action = action;

         cboButton.Properties.Items.Clear();
         cboButton.Properties.Items.Add(new ImageComboBoxItem("Always active"));
         cboButton.Properties.Items.Add(new ImageComboBoxItem("Activated by button 1"));
         cboButton.Properties.Items.Add(new ImageComboBoxItem("Activated by button 2"));

         spinOutput.Value = this.Action.Output;
         cboButton.SelectedIndex = this.Action.ActionButtonIndex;
      }

      private bool MapViewToModel()
      {
         this.Action.Output = Decimal.ToInt32(spinOutput.Value);
         this.Action.ActionButtonIndex = cboButton.SelectedIndex;

         if (this.Action.Output < 1 || this.Action.Output > 8)
         {
            MessageBox.Show("eMotion module have 8 outputs only.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            spinOutput.Focus();
            return false;
         }

         return true;
      }

      #endregion

   }
}