namespace Rwm.Otc.Data.ORM
{
   [System.AttributeUsage(System.AttributeTargets.Property)]
   public class ORMPrimaryKey : ORMProperty
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ORMPrimaryKey"/>.
      /// </summary>
      /// <param name="fieldName">Primary key field name.</param>
      public ORMPrimaryKey(string fieldName = "id") : base(fieldName) { }

      #endregion

   }
}
