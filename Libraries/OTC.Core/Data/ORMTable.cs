namespace Rwm.Otc.Data
{
   /// <summary>
   /// Enable the persistence for the marked class.
   /// </summary>
   [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
   public class ORMTable : System.Attribute
   {
      /// <summary>
      /// Return a new instance of <see cref="ORMTable"/>.
      /// </summary>
      /// <param name="tableName"></param>
      public ORMTable(string tableName)
      {
         this.TableName = tableName;
      }

      /// <summary>
      /// Gets the physical table name.
      /// </summary>
      public string TableName { get; private set; }

   }
}
