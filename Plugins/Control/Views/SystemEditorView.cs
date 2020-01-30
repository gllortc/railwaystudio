using System;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class SystemEditorView : DevExpress.XtraEditors.XtraForm
   {
      public SystemEditorView()
      {
         InitializeComponent();
      }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.Close();
      }

      private void cmdOK_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.Close();
      }
   }
}