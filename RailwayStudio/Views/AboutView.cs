using System;
using System.Windows.Forms;

namespace Rwm.Studio.Views
{
   public partial class AboutView : DevExpress.XtraEditors.XtraForm
   {
      public AboutView()
      {
         InitializeComponent();

         lblProductName.Text = Application.ProductName;
         lblProductVersion.Text = "Version " + Application.ProductVersion;
      }

      private void cmdClose_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.Close();
      }
   }
}