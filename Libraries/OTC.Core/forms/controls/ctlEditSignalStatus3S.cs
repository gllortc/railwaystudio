using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace otc.forms.controls
{
   /// <summary>
   /// Implementa un control para seleccionar el estado de para los accesorios de tres estados.
   /// </summary>
   [System.Drawing.ToolboxBitmap(@"C:\Documents and Settings\Administrador\Mis documentos\Visual Studio 2008\Projects\RC2008\RailwayCommon\Resources\BlockStatusCtrl.bmp")]
   public partial class ctlEditSignalStatus3S : UserControl
   {
      /// <summary>Estado seleccionado en la lista.</summary>
      public otc.panels.OTCBlockStatusSignal3S Status;

      /// <summary>Provides an interface for a UITypeEditor to display Windows Forms or to display a control in a drop-down area from a property grid control in design mode.</summary>
      public IWindowsFormsEditorService wfes;

      /// <summary>
      /// Devuelve una instancia de ctlEditSignalStatus3S.
      /// </summary>
      /// <param name="status">Estado seleccionado en la lista.</param>
      public ctlEditSignalStatus3S(otc.panels.OTCBlockStatusSignal3S status)
      {
         InitializeComponent();

         switch (status)
         {
            case otc.panels.OTCBlockStatusSignal3S.Green: this.lstStates.SelectedIndex = 0; break;
            case otc.panels.OTCBlockStatusSignal3S.Yellow: this.lstStates.SelectedIndex = 1; break;
            case otc.panels.OTCBlockStatusSignal3S.Red: this.lstStates.SelectedIndex = 2; break;
            default: this.lstStates.SelectedIndex = 3; break;
         }
      }

      private void lstStates_MouseClick(object sender, MouseEventArgs e)
      {
         switch (lstStates.SelectedIndex)
         {
            case 0: Status = otc.panels.OTCBlockStatusSignal3S.Green; break;
            case 1: Status = otc.panels.OTCBlockStatusSignal3S.Yellow; break;
            case 2: Status = otc.panels.OTCBlockStatusSignal3S.Red; break;
            default: Status = otc.panels.OTCBlockStatusSignal3S.None; break;
         }
         wfes.CloseDropDown();
      }
   }
}
