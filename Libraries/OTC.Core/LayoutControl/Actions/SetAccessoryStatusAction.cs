using Rwm.Otc.Diagnostics;
using Rwm.Otc.LayoutControl.Elements;
using System;
using System.Drawing;

namespace Rwm.Otc.LayoutControl.Actions
{
   /// <summary>
   /// Action to set a certain status in the specified element.
   /// </summary>
   public class SetAccessoryStatusAction : ElementAction
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="SetAccessoryStatusAction"/>.
      /// </summary>
      public SetAccessoryStatusAction() : base() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the icon assigned to the action.
      /// </summary>
      public override Image Icon
      {
         get { return Otc.Properties.Resources.ICO_BLOCK_SET_16; }
      }

      /// <summary>
      /// Gets or sets the element unique identifier (DB) to be set.
      /// </summary>
      public int ElementID
      {
         get { return this.IntegerParameter1; }
         set { this.IntegerParameter1 = value; }
      }

      /// <summary>
      /// Gets or sets the status to be set to the specified element.
      /// </summary>
      public int Status
      {
         get { return this.IntegerParameter2; }
         set { this.IntegerParameter2 = value; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Execute the action.
      /// </summary>
      /// <param name="element">Parameter to remove!</param>
      /// <param name="project">Project where the action must be executed.</param>
      /// <param name="system">System used to execute the digital commands.</param>
      public override void Execute(ElementBase element, Project project, Rwm.Otc.Systems.IDigitalSystem system)
      {
         try
         {
            if (project.Elements.ContainsKey(this.ElementID))
            {
               IAccessory accElement = project.Elements[this.ElementID] as IAccessory;
               if (accElement != null)
               {
                  accElement.SetAccessoryStatus(this.Status, true);
               }
            }
            else
            {
               Logger.LogWarning(this, 
                                 "Cannot execute SetAccessoryStatusAction #{0}: element #{1} not found in project",
                                 this.ID, this.ElementID);
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw;
         }
      }

      #endregion

   }
}
