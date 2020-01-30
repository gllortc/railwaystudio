using Rwm.Otc.Configuration;
using System;

namespace Rwm.Studio.Views
{
   public partial class FrmPluginEditorOld : DevExpress.XtraEditors.XtraForm
   {
      public FrmPluginEditorOld(XmlSettingsManager settings)
      {
         InitializeComponent();

         this.Settings = settings;
      }

      public XmlSettingsManager Settings { get; private set; }

      private void cmdAccept_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.Close();
      }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.Close();
      }
   }
}