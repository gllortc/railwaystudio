namespace Rwm.Otc.Data
{
   [System.AttributeUsage(System.AttributeTargets.Property)]
   public class ORMForeignCollection : ORMProperty
   {

      #region Enumerations

      /// <summary>
      /// Row deletion strategies.
      /// </summary>
      public enum OnDeleteActionTypes
      {
         NoAction,
         DeleteInCascade
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Return a new instance of <see cref="ORMForeignCollection"/>.
      /// </summary>
      /// <param name="onDeleteAction">On row deletion strategy.</param>
      public ORMForeignCollection(OnDeleteActionTypes onDeleteAction = OnDeleteActionTypes.NoAction) : base(string.Empty) 
      {
         this.OnDeleteAction = onDeleteAction;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the row deletion strategy.
      /// </summary>
      public OnDeleteActionTypes OnDeleteAction { get; private set; }

      #endregion

   }
}
