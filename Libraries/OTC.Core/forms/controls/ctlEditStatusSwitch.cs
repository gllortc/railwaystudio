using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace otc.forms.controls
{
   /// <summary>
   /// Implementa un control para seleccionar el estado para los accesorios de commutación (switches).
   /// </summary>
   [System.Drawing.ToolboxBitmap(@"C:\Documents and Settings\Administrador\Mis documentos\Visual Studio 2008\Projects\RC2008\RailwayCommon\Resources\BlockStatusCtrl.bmp")]
   public partial class ctlEditStatusSwitch : UserControl
   {
      /// <summary>Estado seleccionado en la lista.</summary>
      public otc.panels.OTCBlockStatusSwitch Status;

      /// <summary>Provides an interface for a UITypeEditor to display Windows Forms or to display a control in a drop-down area from a property grid control in design mode.</summary>
      public IWindowsFormsEditorService wfes;

      /// <summary>
      /// Devuelve una instancia de ctlEditStatusSwitch.
      /// </summary>
      /// <param name="status">Estado seleccionado del accesorio.</param>
      public ctlEditStatusSwitch(otc.panels.OTCBlockStatusSwitch status)
      {
         InitializeComponent();

         switch (status)
         {
            case otc.panels.OTCBlockStatusSwitch.Off: this.lstStates.SelectedIndex = 0; break;
            case otc.panels.OTCBlockStatusSwitch.On: this.lstStates.SelectedIndex = 1; break;
            default: this.lstStates.SelectedIndex = 2; break;
         }
      }

      private void lstStates_MouseClick(object sender, MouseEventArgs e)
      {
         switch (lstStates.SelectedIndex)
         {
            case 0: Status = otc.panels.OTCBlockStatusSwitch.Off; break;
            case 1: Status = otc.panels.OTCBlockStatusSwitch.On; break;
            default: Status = otc.panels.OTCBlockStatusSwitch.None; break;
         }
         wfes.CloseDropDown();
      }
   }
}
