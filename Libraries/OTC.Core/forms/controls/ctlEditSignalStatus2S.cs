using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace otc.forms.controls
{
   /// <summary>
   /// Implementa un control para seleccionar el estado de para los accesorios de dos estados.
   /// </summary>
   public partial class ctlEditSignalStatus2S : UserControl
   {
      /// <summary>Estado seleccionado en la lista.</summary>
      public otc.panels.OTCBlockStatusSignal2S Status;

      /// <summary>Provides an interface for a UITypeEditor to display Windows Forms or to display a control in a drop-down area from a property grid control in design mode.</summary>
      public IWindowsFormsEditorService wfes;

      /// <summary>
      /// Devuelve una instancia de ctlEditSignalStatus2S.
      /// </summary>
      /// <param name="status">Estado seleccionado en la lista.</param>
      public ctlEditSignalStatus2S(otc.panels.OTCBlockStatusSignal2S status)
      {
         InitializeComponent();

         switch (status)
         {
            case otc.panels.OTCBlockStatusSignal2S.Green: this.lstStates.SelectedIndex = 0; break;
            case otc.panels.OTCBlockStatusSignal2S.Red: this.lstStates.SelectedIndex = 1; break;
            default: this.lstStates.SelectedIndex = 2; break;
         }
      }

      private void lstStates_MouseClick(object sender, MouseEventArgs e)
      {
         switch (lstStates.SelectedIndex)
         {
            case 0: Status = otc.panels.OTCBlockStatusSignal2S.Green; break;
            case 1: Status = otc.panels.OTCBlockStatusSignal2S.Red; break;
            default: Status = otc.panels.OTCBlockStatusSignal2S.None; break;
         }
         wfes.CloseDropDown();
      }
   }
}
