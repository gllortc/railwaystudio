using System.Collections.Generic;

namespace Rwm.Otc.Data.ORM
{
   /// <summary>
   /// SQL sentence execution context.
   /// </summary>
   internal class ORMSqlCommand
   {
      #region Constructors

      /// <summary>
      /// Return a new instance of <see cref="ORMSqlCommand"/>.
      /// </summary>
      public ORMSqlCommand() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the SQL sentence.
      /// </summary>
      public string SqlCommand { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets the primary key.
      /// </summary>
      public ORMEntityMember PrimaryKeyName { get; set; } = null;

      /// <summary>
      /// Gets the parameter list used in the query.
      /// </summary>
      public List<ORMEntityMember> Parameters { get; set; } = new List<ORMEntityMember>();

      #endregion

   }
}
