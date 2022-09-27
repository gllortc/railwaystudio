using System;
using System.Collections.Generic;
using System.Drawing;
using Rwm.Otc.Data;
using Rwm.Otc.Properties;
using static Rwm.Otc.Data.ORMForeignCollection;

namespace Rwm.Otc.Layout
{
   [ORMTable("ELEMENT_TYPES")]
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
      /// Gets the name of the type of the bloc.
      /// </summary>
      [ORMProperty("NAME")]
      public string Name { get; set; }

      /// <summary>
      /// Gets the description of the type of the bloc.
      /// </summary>
      [ORMProperty("DESCRIPTION")]
      public string Description { get; set; }

      /// <summary>
      /// Columna en la que se sitúa el bloque (X).
      /// </summary>
      [ORMProperty("WIDTH")]
      public int Width { get; set; }

      /// <summary>
      /// Fila en la que se sitúa el bloque (Y).
      /// </summary>
      [ORMProperty("HEIGHT")]
      public int Height { get; set; }

      /// <summary>
      /// Gets or sets the icon ID.
      /// </summary>
      [ORMProperty("ICON")]
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
      [ORMProperty("GROUPKEY")]
      public string Group { get; set; }

      /// <summary>
      /// Gets or sets the number of rotations that can be applied to the blobk.
      /// </summary>
      [ORMProperty("ROTATIONSTEPS")]
      public int RotationSteps { get; set; }

      /// <summary>
      /// Gets or sets a value indicating the order of activation in a secuance.
      /// </summary>
      [ORMProperty("ACTIVATIONORDER")]
      public int ActivationOrder { get; set; }

      /// <summary>
      /// Gets or sets a value indicating if the block is acting as an accessory.
      /// </summary>
      [ORMProperty("ACCESSORY")]
      public bool IsAccessory { get; set; }

      /// <summary>
      /// Gets or sets the number of possible statuses for the accessory.
      /// </summary>
      [ORMProperty("ACCSTATS")]
      public int AccessoryMaxStats { get; set; }

      /// <summary>
      /// Gets or sets the number of accessory connections allowed by the modules.
      /// </summary>
      [ORMProperty("ACCNUMCONN")]
      public int NumberOfAccessoryConnections { get; set; } = 0;

      /// <summary>
      /// Gets or sets a value indicating if the block is acting as a feedback sensor.
      /// </summary>
      [ORMProperty("FEEDBACK")]
      public bool IsFeedback { get; set; }

      /// <summary>
      /// Gets or sets the number of feedback connections allowed by the modules.
      /// </summary>
      [ORMProperty("FBNUMCONN")]
      public int NumberOfFeedbackConnections { get; set; } = 0;

      /// <summary>
      /// Gets or sets the number of rotations that can be applied to the blobk.
      /// </summary>
      [ORMProperty("ROUTEABLE")]
      public bool IsRouteable { get; set; }

      /// <summary>
      /// Gets or sets a value indicating if the element is a block.
      /// </summary>
      [ORMProperty("OCCUPABLE")]
      public bool IsBlock { get; set; }

      /// <summary>
      /// Gets or sets a value indicating if the element is a destination block.
      /// </summary>
      [ORMProperty("DESTINATION")]
      public bool IsDestination { get; set; }

      /// <summary>
      /// Gets or sets the number of rotations that can be applied to the blobk.
      /// </summary>
      [ORMProperty("ALLOWACTIONS")]
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
