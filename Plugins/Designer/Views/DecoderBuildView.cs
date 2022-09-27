using System;
using System.Windows.Forms;
using Rwm.Otc.Diagnostics;
using Rwm.Studio.Plugins.Designer.Arduino;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class DecoderBuildView : DevExpress.XtraEditors.XtraForm
   {
      public DecoderBuildView()
      {
         InitializeComponent();
      }

      private void CmdClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void CmdBurn_Click(object sender, EventArgs e)
      {
         try
         {
            Sketch sketch = new Sketch(new Otc.Layout.AccessoryDecoder());
            sketch.Create(false);
            sketch.Build(txtOutput);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
   }
}
