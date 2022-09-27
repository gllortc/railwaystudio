using System;

namespace Rwm.Otc.Layout.EasyConnect
{
   public interface IEMotionAction
   {
      /// <summary>
      /// Gets the action name.
      /// </summary>
      string Name { get; }

      /// <summary>
      /// Gets the action codename.
      /// </summary>
      string Code { get; }

      /// <summary>
      /// Gets the involved LED pins.
      /// </summary>
      int[] LedPins { get; }

      /// <summary>
      /// Gets the involved LED pins as a <see cref="String"/>.
      /// </summary>
      string LedPinsDescription { get; }

      /// <summary>
      /// Gets a text description on wich button activates the action.
      /// </summary>
      string ActivatedByDescription { get; }

      /// <summary>
      /// Gets the activation button index (0 means no button activated)
      /// </summary>
      int ActionButtonIndex { get; }

      /// <summary>
      /// Gets the duration in milliseconds (0 means always active)
      /// </summary>
      int Duration { get; }

      /// <summary>
      /// Gets an icon (16x16) representing the action.
      /// </summary>
      System.Drawing.Image SmallIcon { get; }

   }
}
