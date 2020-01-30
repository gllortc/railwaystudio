using Rwm.Otc.Diagnostics;
using Rwm.Otc.LayoutControl.Elements;
using System;
using System.Drawing;

namespace Rwm.Otc.LayoutControl.Actions
{
   /// <summary>
   /// Action to play a sound.
   /// </summary>
   public class PlaySoundAction : ElementAction
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="PlaySoundAction"/>.
      /// </summary>
      public PlaySoundAction() : base() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the icon assigned to the action.
      /// </summary>
      public override Image Icon
      {
         get { return Otc.Properties.Resources.ICO_SOUND_16; }
      }

      /// <summary>
      /// Gets or sets the sound unique identifier (DB) that should be played.
      /// </summary>
      public int SoundID
      {
         get { return this.IntegerParameter1; }
         set { this.IntegerParameter1 = value; }
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
            OTCContext.Layout.SoundManager.PlaySound(this.SoundID, project);
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
