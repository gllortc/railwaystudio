namespace Rwm.Otc.Data
{
   [System.AttributeUsage(System.AttributeTargets.Property)]
   public class ORMProperty : System.Attribute
   {

      #region Constructors

      /// <summary>
      /// Return a new instance of attribute <see cref="ORMProperty"/>.
      /// </summary>
      /// <param name="fieldName">Physical field name.</param>
      public ORMProperty(string fieldName)
      {
         this.FieldName = fieldName;
      }

      /// <summary>
      /// Return a new instance of attribute <see cref="ORMProperty"/>.
      /// </summary>
      /// <param name="fieldName">Physical field name.</param>
      /// <param name="oneToOnePropertyName">Property name in related class for bidirectional properties.</param>
      public ORMProperty(string fieldName, string oneToOnePropertyName)
      {
         this.FieldName = fieldName;
         this.OneToOnePropertyName = oneToOnePropertyName;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the database table physical field name.
      /// </summary>
      public string FieldName { get; private set; }

      /// <summary>
      /// Gets the property name in related class for bidirectional properties.
      /// </summary>
      public string OneToOnePropertyName { get; private set; } = string.Empty;

      /// <summary>
      /// Gets the value indicating if the property is part of a one-to-one relation.
      /// </summary>
      public bool IsOneToOneProperty
      {
         get { return !string.IsNullOrWhiteSpace(this.OneToOnePropertyName); }
      }

      #endregion

      #region Methods

      public override string ToString()
      {
         return this.FieldName;
      }

      #endregion  

   }
}
