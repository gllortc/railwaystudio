using System;
using System.Collections.Generic;

namespace Rwm.Otc.Data.ORM
{
   internal class ORMCommand
   {
      #region Constructors

      public ORMCommand()
      {
         this.SqlCommand = String.Empty;
         this.PrimaryKeyName = String.Empty;
         this.Parameters = new List<ORMProperty>();
      }

      #endregion

      #region Properties

      public string SqlCommand { get; set; }

      public string PrimaryKeyName { get; set; }

      public List<ORMProperty> Parameters { get; set; }

      #endregion

   }
}
