using Rwm.Otc.Data;

namespace Rwm.Otc.Layout
{
   [ORMTable("LAYOUT_MODULES")]
   public class Module : ORMEntity<Module>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Module"/>.
      /// </summary>
      public Module() { }

      /// <summary>
      /// Returns a new instance of <see cref="Module"/>.
      /// </summary>
      public Module(Project project) 
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

      /// <summary>
      /// Gets or sets a value indicating if the layout section is connected to a power bus.
      /// </summary>
      [ORMProperty("POWERBUS")]
      public bool ConnectedToPowerBus { get; set; }

      /// <summary>
      /// Gets or sets a value indicating if the layout section is connected to a control bus.
      /// </summary>
      [ORMProperty("CONTROLBUS")]
      public bool ConnectedToControlBus { get; set; }

      /// <summary>
      /// Gets or sets a value indicating if the layout section is connected to a command control bus.
      /// </summary>
      [ORMProperty("COMMANDBUS")]
      public bool ConnectedToCommandBus { get; set; }

      /// <summary>
      /// Gets a string containing de description of the accessory address range.
      /// </summary>
      public string AccessoryAddressRange
      {
         get 
         {
            if (this.AccessoryStartAddress <= 0 && this.AccessoryEndAddress <= 0)
               return "Not definded";
            else if (this.AccessoryStartAddress >= this.AccessoryEndAddress)
               return "Bad definition";
            else
               return this.AccessoryStartAddress.ToString("0000") + " - " + this.AccessoryEndAddress.ToString("0000"); 
         }
      }

      /// <summary>
      /// Gets a string containing de description of the feedback address range.
      /// </summary>
      public string FeedbackAddressRange
      {
         get
         {
            if (this.FeedbackStartAddress <= 0 && this.FeedbackEndAddress <= 0)
               return "Not definded";
            else if (this.FeedbackStartAddress >= this.FeedbackEndAddress)
               return "Bad definition";
            else
               return this.FeedbackStartAddress.ToString("0000") + " - " + this.FeedbackEndAddress.ToString("0000");
         }
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
