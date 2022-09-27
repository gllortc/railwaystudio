namespace Rwm.Otc.Layout.EasyConnect
{
   /// <summary>
   /// EasyConnect eMotion action<br/>
   /// Action to simulate a lamp failure.
   /// </summary>
   public class LampFailureAction : IEMotionAction
   {

      #region Constructors

      /// <summary>
      /// Return a new instance of <see cref="LampFailureAction"/>
      /// </summary>
      public LampFailureAction() { }

      /// <summary>
      /// Return a new instance of <see cref="LampFailureAction"/>
      /// </summary>
      public LampFailureAction(int output, int actionButtonIndex)
      {
         this.Output = output;
         this.ActionButtonIndex = actionButtonIndex;
      }

      #endregion

      #region Properties

      public string Name
      {
         get { return "Lamp failure"; }
      }

      public string Code
      {
         get { return "FLAMP"; }
      }

      public int[] LedPins 
      {
         get { return new int[] { this.Output }; }
      }

      public string LedPinsDescription
      {
         get { return this.Output.ToString(); }
      }

      public System.Drawing.Image SmallIcon
      {
         get { return Properties.Resources.ICO_EMACTION_LAMPF_16; }
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

      public int ActionButtonIndex { get; set; } = 0;

      /// <summary>
      /// Gets or sets the output pin where the LED is connected.
      /// </summary>
      public int Output { get; set; } = 1;

      /// <summary>
      /// Gets the duration in milliseconds (0 means always active)
      /// </summary>
      public int Duration { get; set; } = 0;


      #endregion

   }
}
