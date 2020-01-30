namespace Rwm.Studio.Plugins.Collection.Model
{
   public class ModelDigitalFunction
   {
      // Declaración de variables internas
      private int _modelId;
      private int _function;
      private string _name;

      /// <summary>
      /// Devuelve una instancia de RCModelDigitalFunction.
      /// </summary>
      public ModelDigitalFunction()
      {
         _modelId = 0;
         _function = 0;
         _name = string.Empty;
      }

      /// <summary>
      /// Devuelve una instancia de RCModelDigitalFunction.
      /// </summary>
      public ModelDigitalFunction(int modelId, int function, string name)
      {
         _modelId = modelId;
         _function = function;
         _name = name;
      }

      #region Properties

      /// <summary>
      /// Gets or sets el identificador del modelo al que está asociado.
      /// </summary>
      public int ModelId
      {
         get { return _modelId; }
         set { _modelId = value; }
      }

      /// <summary>
      /// Gets or sets el número de la función.
      /// </summary>
      public int FunctionId
      {
         get { return _function; }
         set { _function = value; }
      }

      /// <summary>
      /// Gets or sets la descripción de la función.
      /// </summary>
      public string Name
      {
         get { return _name; }
         set { _name = value; }
      }

      #endregion

   }
}
