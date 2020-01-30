using System;

namespace Rwm.Otc.Data.ORM
{
   [System.AttributeUsage(System.AttributeTargets.Property)]
   public class ORMProperty : System.Attribute
   {

      #region Constructors

      /// <summary>
      /// Return a new instance of attribute <see cref="ORMProperty"/>.
      /// </summary>
      /// <param name="fieldName">Physical field name.</param>
      public ORMProperty(string fieldName)
      {
         this.FieldName = fieldName;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the database table physical field name.
      /// </summary>
      public string FieldName { get; private set; }

      #endregion

      #region Methods

      public override string ToString()
      {
         return this.FieldName;
      }

      #endregion  

   }
}
