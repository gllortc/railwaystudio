using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace otc.forms.controls
{
   /// <summary>
   /// Implementa un control para seleccionar el estado para los accesorios de cambio de vía (turnouts).
   /// </summary>
   public partial class ctlEditTurnoutStatus : UserControl
   {
      private otc.panels.OTCBlockStatusTurnout _status = otc.panels.OTCBlockStatusTurnout.None;

      /// <summary>Provides an interface for a UITypeEditor to display Windows Forms or to display a control in a drop-down area from a property grid control in design mode.</summary>
      public IWindowsFormsEditorService wfes;

      /// <summary>
      /// Devuelve una instancia de ctlEditTurnoutStatus.
      /// </summary>
      /// <param name="status">Estado actual del accesorio para mostrar en la lista.</param>
      public ctlEditTurnoutStatus(otc.panels.OTCBlockStatusTurnout status)
      {
         InitializeComponent();

         switch (status)
         {
            case otc.panels.OTCBlockStatusTurnout.Straight: lstStates.SelectedIndex = 0; break;
            case otc.panels.OTCBlockStatusTurnout.Turned: lstStates.SelectedIndex = 1; break;
            default: lstStates.SelectedIndex = 2; break;
         }
      }

      /// <summary>
      /// Devuelve el estado seleccionado en la lista.
      /// </summary>
      public otc.panels.OTCBlockStatusTurnout Status
      {
         get { return _status; }
      }

      private void lstStates_MouseClick(object sender, MouseEventArgs e)
      {
         switch (lstStates.SelectedIndex)
         {
            case 0: _status = otc.panels.OTCBlockStatusTurnout.Straight; break;
            case 1: _status = otc.panels.OTCBlockStatusTurnout.Turned; break;
            default: _status = otc.panels.OTCBlockStatusTurnout.None; break;
         }
         wfes.CloseDropDown();
      }
   }
}
