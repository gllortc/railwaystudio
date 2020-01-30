using System;

namespace Rwm.Otc.Data
{
   public class FileType
   {

      #region Constructors

      public FileType()
      {
         this.Filename = string.Empty;
         this.Blob = null;
      }

      #endregion

      #region Properties

      public String Filename { get; set; }

      public byte[] Blob { get; set; }

      #endregion

      #region Methods

      public void Open() 
      { 
      }

      #endregion

   }
}
