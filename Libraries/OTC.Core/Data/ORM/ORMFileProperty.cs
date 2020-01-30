namespace Rwm.Otc.Data.ORM
{
   [System.AttributeUsage(System.AttributeTargets.Property)]
   public class ORMFileProperty : System.Attribute
   {
      public ORMFileProperty(string filenameFieldName, string blobFieldName)
      {
         this.FilenameFieldName = filenameFieldName;
         this.BlobFieldName = blobFieldName;
      }

      public string FilenameFieldName { get; private set; }

      public string BlobFieldName { get; private set; }
   }
}
