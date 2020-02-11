using Rwm.Otc.UI.Controls;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Controls
{
   public partial class DesignToolboxControl : DevExpress.XtraEditors.XtraUserControl
   {
      public DesignToolboxControl(Form ownerView, SwitchboardDesignControl panel)
      {
         InitializeComponent();

         this.OwnerView = OwnerView;
         this.SwitchboardPanel = panel;

         Initialize();
      }

      internal Form OwnerView { get; private set; }

      internal SwitchboardDesignControl SwitchboardPanel { get; private set; }

      private void Initialize()
      {
         AccessoryDecoderManagerControl mmc = new AccessoryDecoderManagerControl();
         mmc.BorderStyle = BorderStyle.None;
         mmc.Dock = DockStyle.Fill;
         mmc.Refresh();

         FeedbackDecoderManagerControl fmc = new FeedbackDecoderManagerControl();
         fmc.BorderStyle = BorderStyle.None;
         fmc.Dock = DockStyle.Fill;
         fmc.Refresh();

         SoundManagerControl smc = new SoundManagerControl(this.OwnerView);
         smc.BorderStyle = BorderStyle.None;
         smc.Dock = DockStyle.Fill;
         smc.Refresh();

         tabControlAccessories.Controls.Add(mmc);
         tabControlFeedback.Controls.Add(fmc);
         tabControlSound.Controls.Add(smc);
      }
   }
}
