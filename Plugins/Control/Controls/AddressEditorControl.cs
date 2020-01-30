using DevExpress.Utils;
using Rwm.Otc;
using Rwm.Otc.Layout;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Controls
{
   public partial class AddressEditorControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      public AddressEditorControl()
      {
         InitializeComponent();
      }

      #endregion

      #region Properties

      public int Address
      {
         get 
         {
            int value = 0;
            if (int.TryParse(txtAddress.EditValue.ToString(), out value))
            {
               return value;
            }
            return 0; 
         }
         set { txtAddress.Text = value.ToString(); }
      }

      #endregion

      #region Methods

      protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
      {
         height = 22;
         base.SetBoundsCore(x, y, width, height, specified);
      }

      #endregion

      #region Event Handlers

      private void txtAddress_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
      {
         if (e.Button.Index == 2)
         {
            this.CheckAddress();
         }
      }

      #endregion

      #region Private Members

      private void CheckAddress()
      {
         string title = string.Empty;
         string msg = string.Empty;
         List<DeviceConnection> connections = null;
         SuperToolTip sttInfo = new SuperToolTip();
         ToolTipTitleItem sttTitle = new ToolTipTitleItem();
         ToolTipItem sttItem = new ToolTipItem();

         // Obtain all duplicated addresses
         connections.AddRange(DeviceConnection.GetDuplicated());

         if (this.Address <= 0)
         {
            title = "INFORMATION";
            msg = "Accessory addresses must start at address 1. A connection with address 0 mens that the connection is disabled.";

            sttTitle.Appearance.Image = Properties.Resources.ICO_INFORMATION_16;
         }
         else if (connections.Count > 0)
         {
            title = "WARNING";
            msg = string.Format("The address {0} is used in other {1} accessory connection(s).", this.Address, connections.Count);

            sttTitle.Appearance.Image = Properties.Resources.ICO_ERROR_16;
         }
         else
         {
            title = "INFORMATION";
            msg = string.Format("Accessory address is valid. Used only in the current connection.");

            sttTitle.Appearance.Image = Properties.Resources.ICO_INFORMATION_16;
         }

         sttTitle.Appearance.Options.UseImage = true;
         sttTitle.Text = title;
         sttItem.LeftIndent = 6;
         sttItem.Text = msg;
         sttInfo.Items.Add(sttTitle);
         sttInfo.Items.Add(sttItem);

         var sea = new ToolTipControllerShowEventArgs();
         sea.SuperTip = sttInfo;
         sea.ToolTipType = ToolTipType.SuperTip;
         toolTipController.ShowHint(sea, Cursor.Position);
      }

      #endregion

   }
}
