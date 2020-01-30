using System;
using System.Collections.Generic;
using System.Drawing;
using Rwm.Otc.Data.ORM;
using Rwm.Otc.Properties;
using static Rwm.Otc.Data.ORM.ORMForeignCollection;

namespace Rwm.Otc.Layout
{
   [ORMTable("elementtypes")]
   public class ElementType : ORMEntity<ElementType>
   {

      #region Constructors

      public ElementType() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; }

      /// <summary>
      /// Columna en la que se sitúa el bloque (X).
      /// </summary>
      [ORMProperty("width")]
      public int Width { get; set; }

      /// <summary>
      /// Fila en la que se sitúa el bloque (Y).
      /// </summary>
      [ORMProperty("height")]
      public int Height { get; set; }

      /// <summary>
      /// Gets or sets the icon ID.
      /// </summary>
      [ORMProperty("icon")]
      public string IconID { get; set; }

      /// <summary>
      /// Gets the icon of the type of the bloc.
      /// </summary>
      public Image TypeIcon 
      {
         get { return (Image)Resources.ResourceManager.GetObject(this.IconID); }
      }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      [ORMProperty("groupkey")]
      public string Group { get; set; }

      /// <summary>
      /// Gets the name of the type of the bloc.
      /// </summary>
      [ORMProperty("name")]
      public string Name { get; set; }

      /// <summary>
      /// Gets the description of the type of the bloc.
      /// </summary>
      [ORMProperty("description")]
      public string Description { get; set; }

      /// <summary>
      /// Gets or sets the number of rotations that can be applied to the blobk.
      /// </summary>
      [ORMProperty("rotationsteps")]
      public int RotationSteps { get; set; }

      /// <summary>
      /// Gets or sets the number of rotations that can be applied to the blobk.
      /// </summary>
      [ORMProperty("accessory")]
      public bool IsAccessory { get; set; }

      /// <summary>
      /// Gets or sets the number of possible statuses for the accessory.
      /// </summary>
      [ORMProperty("accessorystats")]
      public int AccessoryMaxStats { get; set; }

      /// <summary>
      /// Gets or sets the number of accessory connections allowed by the modules.
      /// </summary>
      [ORMProperty("numconnacc")]
      public int NumberOfAccessoryConnections { get; set; } = 0;

      /// <summary>
      /// Gets or sets the number of feedback connections allowed by the modules.
      /// </summary>
      [ORMProperty("numconnfeed")]
      public int NumberOfFeedbackConnections { get; set; } = 0;

      /// <summary>
      /// Gets or sets the number of rotations that can be applied to the blobk.
      /// </summary>
      [ORMProperty("feedback")]
      public bool IsFeedback { get; set; }

      /// <summary>
      /// Gets or sets the number of rotations that can be applied to the blobk.
      /// </summary>
      [ORMProperty("routeable")]
      public bool IsRouteable { get; set; }

      /// <summary>
      /// Gets or sets the number of rotations that can be applied to the blobk.
      /// </summary>
      [ORMProperty("occupable")]
      public bool IsBlock { get; set; }

      /// <summary>
      /// Gets or sets the number of rotations that can be applied to the blobk.
      /// </summary>
      [ORMProperty("allowactions")]
      public bool ActionsAllowed { get; set; }

      /// <summary>
      /// Gets or sets the list of accessory possible status.
      /// </summary>
      [ORMForeignCollection(OnDeleteActionTypes.DeleteInCascade)]
      public List<AccessoryStatus> AccessoryStatus { get; set; }

      #endregion

      #region Methods

      public string GetStatusDescription(int status)
      {
         foreach (AccessoryStatus accStatus in this.AccessoryStatus)
         {
            if (accStatus.Status == status)
               return accStatus.Name;
         }

         return String.Empty;
      }

      #endregion

   }
}
