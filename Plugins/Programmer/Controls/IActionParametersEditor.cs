namespace Rwm.Studio.Plugins.Designer.Controls
{
   interface IActionParametersEditor 
   {

      Rwm.Otc.Layout.ElementAction Action { get; }

      bool CheckSupportedActionType(Otc.Layout.ElementAction action);

      /// <summary>
      /// Check if edited data is valid for the parameters introduced.
      /// </summary>
      /// <returns>A value indicating if the data is valid or not.</returns>
      bool CheckData();

   }
}
