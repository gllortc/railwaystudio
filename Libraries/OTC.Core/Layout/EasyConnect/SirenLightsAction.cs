namespace Rwm.Otc.Layout.EasyConnect
{
   /// <summary>
   /// EasyConnect eMotion action<br/>
   /// Action to simulate a siren lights.
   /// </summary>
   public class SirenLightsAction : IEMotionAction
   {

      #region Constructors

      /// <summary>
      /// Return a new instance of <see cref="SirenLightsAction"/>
      /// </summary>
      public SirenLightsAction() { }

      /// <summary>
      /// Return a new instance of <see cref="SirenLightsAction"/>
      /// </summary>
      public SirenLightsAction(int output1, int output2, int actionButtonIndex)
      {
         this.Output1 = output1;
         this.Output2 = output2;
         this.ActionButtonIndex = actionButtonIndex;
      }

      #endregion

      #region Properties

      public string Name
      {
         get { return "Siren lights"; }
      }

      public string Code
      {
         get { return "SIREN"; }
      }

      public int[] LedPins
      {
         get { return new int[] { this.Output1, this.Output2 }; }
      }

      public string LedPinsDescription
      {
         get { return this.Output1.ToString() + ", " + this.Output2.ToString(); }
      }

      public System.Drawing.Image SmallIcon
      {
         get { return Properties.Resources.ICO_EMACTION_SIREN_16; }
      }

      public string ActivatedByDescription
      {
         get 
         {
            if (this.ActionButtonIndex <= 0)
               return "Always active";
            else
               return "By button " + this.ActionButtonIndex.ToString(); 
         }
      }

      /// <summary>
      /// Gets or sets the output pin where the LED 1 is connected.
      /// </summary>
      public int Output1 { get; set; } = 1;

      /// <summary>
      /// Gets or sets the output pin where the LED 2 is connected.
      /// </summary>
      public int Output2 { get; set; } = 2;

      /// <summary>
      /// Gets or sets the changing time (in ms).
      /// </summary>
      public int Interval { get; set; } = 500;

      /// <summary>
      /// Gets or sets the push button index where the action is associated.
      /// </summary>
      public int ActionButtonIndex { get; set; } = 0;

      #endregion

   }
}
