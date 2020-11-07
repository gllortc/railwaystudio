namespace Rwm.Studio.Plugins.Collection.Model
{
   /// <summary>
   /// Represents a model manufacturer.
   /// </summary>
   public class Manufacturer : IIdentifiableObject
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Manufacturer"/>.
      /// </summary>
      public Manufacturer()
      {
         Initialize();
      }

      #endregion

      #region Properties

      public int ID { get; set; }

      public string Name { get; set; }

      public string Description { get; set; }

      public string Address { get; set; }

      public string URL { get; set; }

      #endregion

      #region Private Members

      /// <summary>
      /// Initializes the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ID = 0;
         this.Name = string.Empty;
         this.Description = string.Empty;
         this.Address = string.Empty;
         this.URL = string.Empty;
      }

      #endregion

   }
}
