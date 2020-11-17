using System;
using Rwm.Otc.Data;

namespace Rwm.Otc.Trains
{
   /// <summary>
   /// Implements a railway company.
   /// </summary>
   [ORMTable("COMPANIES")]
   public class Company : ORMEntity<Company>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Company"/>.
      /// </summary>
      public Company() : base() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; } = 0;

      /// <summary>
      /// Gets or sets the name of the railway company.
      /// </summary>
      [ORMProperty("NAME")]
      public string Name { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets the company acronym.
      /// </summary>
      [ORMProperty("ACRONYM")]
      public string Acronym { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets the description.
      /// </summary>
      [ORMProperty("DESCRIPTION")]
      public string Description { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets the companywebsite URL.
      /// </summary>
      [ORMProperty("WEB")]
      public string URL { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets the logo image filename.
      /// </summary>
      [ORMProperty("LOGOFILE")]
      [Obsolete]
      public string LogoFilename { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets the company logo image.
      /// </summary>
      [ORMProperty("LOGOIMAGE")]
      public System.Drawing.Image LogoImage { get; set; } = null;

      /// <summary>
      /// Gets the associated small icon (16x16px).
      /// </summary>
      public static System.Drawing.Image SmallIcon
      {
         get { return Properties.Resources.ICO_COMPANY_16; }
      }

      /// <summary>
      /// Gets the associated large icon (32x32px).
      /// </summary>
      public static System.Drawing.Image LargeIcon
      {
         get { return Properties.Resources.ICO_COMPANY_32; }
      }

      #endregion

   }
}
