using Rwm.Otc.Data;

namespace Rwm.Otc.Layout
{
   [ORMTable("LAYOUT_SECTIONS")]
   public class Section : ORMEntity<Section>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Section"/>.
      /// </summary>
      public Section() { }

      /// <summary>
      /// Returns a new instance of <see cref="Section"/>.
      /// </summary>
      public Section(Project project) 
      {
         this.Project = project;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; } = 0;

      /// <summary>
      /// Identificador único del elemento.
      /// </summary>
      [ORMProperty("PROJECTID")]
      public Project Project { get; set; } = null;

      /// <summary>
      /// Nombre descriptivo del bloque.
      /// </summary>
      [ORMProperty("NAME")]
      public string Name { get; set; } = string.Empty;

      /// <summary>
      /// Gets the icon of the type of the bloc.
      /// </summary>
      [ORMProperty("DESCRIPTION")]
      public string Description { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets the section schema picture.
      /// </summary>
      [ORMProperty("IMAGE")]
      public System.Drawing.Image Picture { get; set; }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      [ORMProperty("ACCSTARTADDRESS")]
      public int AccessoryStartAddress { get; set; }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      [ORMProperty("ACCENDADDRESS")]
      public int AccessoryEndAddress { get; set; }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      [ORMProperty("FBSTARTADDRESS")]
      public int FeedbackStartAddress { get; set; }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      [ORMProperty("FBENDADDRESS")]
      public int FeedbackEndAddress { get; set; }

      public string AccessoryAddressRange
      {
         get { return "001 - 075"; }
      }

      public string FeedbackAddressRange
      {
         get { return "-"; }
      }

      /// <summary>
      /// Gets the associated small icon (16x16px).
      /// </summary>
      public static System.Drawing.Image SmallIcon
      {
         get { return Properties.Resources.ICO_SECTION_16; }
      }

      /// <summary>
      /// Gets the associated large icon (32x32px).
      /// </summary>
      public static System.Drawing.Image LargeIcon
      {
         get { return Properties.Resources.ICO_SECTION_32; }
      }

      public static System.Drawing.Image GlobalSmallIcon
      {
         get { return Properties.Resources.ICO_SECTION_GLOBAL_16; }
      }

      #endregion

      #region Methods

      public override string ToString()
      {
         return string.Format("{0} (#{1})", this.Name, this.ID);
      }

      #endregion

   }
}
