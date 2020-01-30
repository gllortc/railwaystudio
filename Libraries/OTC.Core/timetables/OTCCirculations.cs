using System;
using otc.forms.controls;

namespace otc.timetables
{

   #region class OTCCirculations

   /// <summary>
   /// Implementa una tabla de horarios de circulaciones de OTC.
   /// </summary>
   public class OTCCirculations
   {
      /// <summary>
      /// Enumera los tipos de circulación admitidas en un panel horario.
      /// </summary>
      public enum OTCCirculationTypes : int
      {
         /// <summary>Sin definir.</summary>
         None = 0,
         /// <summary>InterRegio.</summary>
         InterRegio = 1,
         /// <summary>InterCity.</summary>
         InterCity = 2,
         /// <summary>EuroCity.</summary>
         EuroCity = 3,
         /// <summary>Trans Europ Express (TEE).</summary>
         TEE = 4
      }

      /// <summary>
      /// Genera una lista de tipos de circulación
      /// </summary>
      /// <param name="control">Control contenedor de la lista</param>
      /// <param name="selected">Valor seleccionado por defecto</param>
      public static void TypesList(ImageComboBox control, OTCCirculationTypes selected)
      {
         ImageComboBoxItem item = null;

         foreach (OTCCirculationTypes val in Enum.GetValues(typeof(OTCCirculationTypes)))
         {
            item = new ImageComboBoxItem(OTCCirculations.TypeName(val), (int)val);
            control.Items.Add(item);
            if (selected == val) control.SelectedItem = item;
         }
      }

      /// <summary>
      /// Genera una lista de tipos de circulación
      /// </summary>
      /// <param name="control">Control contenedor de la lista</param>
      public static void TypesList(ImageComboBox control)
      {
         OTCCirculations.TypesList(control, OTCCirculationTypes.None);
      }

      /// <summary>
      /// Obtiene el nombre correspondiente al tipo de circulación.
      /// </summary>
      /// <param name="type">Tipo de circulación</param>
      /// <returns>El nombre del tipo</returns>
      public static string TypeName(OTCCirculations.OTCCirculationTypes type)
      {
         switch (type)
         {
            case OTCCirculations.OTCCirculationTypes.EuroCity:
               return "EuroCity";

            case OTCCirculations.OTCCirculationTypes.InterCity:
               return "InterCity";

            case OTCCirculations.OTCCirculationTypes.InterRegio:
               return "InterRegio";

            case OTCCirculations.OTCCirculationTypes.TEE:
               return "TEE";
         }
         return "";
      }
   }

   #endregion

}
