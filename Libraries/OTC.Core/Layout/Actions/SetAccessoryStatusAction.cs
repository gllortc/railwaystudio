using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using System;
using System.Drawing;

namespace Rwm.Otc.Layout.Actions
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
      public long AffectedElementID
      {
         get { return this.IntegerParameter1; }
         set { this.IntegerParameter1 = value; }
      }

      /// <summary>
      /// Gets or sets the status to be set to the specified element.
      /// </summary>
      public long Status
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
      public override void Execute(Element element, Project project)
      {
         try
         {
            element.SetAccessoryStatus((int)this.Status);
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
