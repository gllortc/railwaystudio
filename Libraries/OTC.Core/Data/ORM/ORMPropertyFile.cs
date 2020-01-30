namespace Rwm.Otc.Data.ORM
{
   [System.AttributeUsage(System.AttributeTargets.Property)]
   public class ORMPropertyFile : ORMProperty
   {

      #region Constructors

      /// <summary>
      /// returns a new instance of <see cref="ORMPropertyFile"/>.
      /// </summary>
      /// <param name="filenameFieldName">The name of the field containing the file name.</param>
      /// <param name="blobFieldName">The name of the field containing the BLOB (bynary data) of file.</param>
      public ORMPropertyFile(string filenameFieldName, string blobFieldName) : base(filenameFieldName)
      {
         this.FilenameFieldName = filenameFieldName;
         this.BlobFieldName = blobFieldName;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the name or the field used to store the filename.
      /// </summary>
      public string FilenameFieldName { get; private set; }

      /// <summary>
      /// Gets the name or the field used to store the BLOB binary contents of the file.
      /// </summary>
      public string BlobFieldName { get; private set; }

      #endregion

   }
}
