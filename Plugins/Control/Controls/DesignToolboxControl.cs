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
         DeviceManagerControl mmc = new DeviceManagerControl();
         mmc.BorderStyle = System.Windows.Forms.BorderStyle.None;
         mmc.Dock = DockStyle.Fill;
         mmc.Refresh();

         RouteManagerControl rmc = new RouteManagerControl(this.OwnerView, this.SwitchboardPanel);
         rmc.BorderStyle = System.Windows.Forms.BorderStyle.None;
         rmc.Dock = DockStyle.Fill;
         rmc.Refresh();

         SoundManagerControl smc = new SoundManagerControl(this.OwnerView);
         smc.BorderStyle = System.Windows.Forms.BorderStyle.None;
         smc.Dock = DockStyle.Fill;
         smc.Refresh();

         tabControlModules.Controls.Add(mmc);
         tabControlRoute.Controls.Add(rmc);
         tabControlSound.Controls.Add(smc);
      }
   }
}
