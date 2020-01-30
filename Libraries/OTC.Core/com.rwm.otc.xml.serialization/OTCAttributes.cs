using System;

namespace Rwm.Otc.xml.serialization
{

   /// <summary>
   /// The base class for all attributes defined in YAXLib.
   /// </summary>
   [AttributeUsage(AttributeTargets.All)]
   public abstract class OTCBaseAttribute : System.Attribute { }

   /// <summary>
   /// Creates a comment node per each line of the comment string provided.
   /// This attribute is applicable to classes, structures, fields, and properties.
   /// </summary>
   [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field | AttributeTargets.Property)]
   public class OTCCommentAttribute : OTCBaseAttribute
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="OTCCommentAttribute"/> class.
      /// </summary>
      /// <param name="comment">The comment.</param>
      public OTCCommentAttribute(string comment)
      {
         this.Comment = comment;
      }

      #region Properties

      /// <summary>
      /// Gets or sets the comment.
      /// </summary>
      /// <value>The comment.</value>
      public string Comment { get; set; }

      #endregion
   }

   /// <summary>
   /// Add this attribute to types, structs or classes which you want to override their default serialization behaviour. This attribute is optional.
   /// This attribute is applicable to classes and structures.
   /// </summary>
   [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
   public class OTCSerializableTypeAttribute : OTCBaseAttribute
   {
      private bool m_isOptionSet = false;
      private OTCSerializationOptions m_serializationOptions = OTCSerializationOptions.SerializeNullObjects;

      /// <summary>
      /// Initializes a new instance of the <see cref="OTCSerializableTypeAttribute"/> class.
      /// </summary>
      public OTCSerializableTypeAttribute()
      {
         this.FieldsToSerialize = OTCSerializationFields.PublicPropertiesOnly;
      }

      #region Properties

      /// <summary>
      /// Gets or sets the fields which YAXLib selects for serialization
      /// </summary>
      /// <value>The fields to serialize.</value>
      public OTCSerializationFields FieldsToSerialize { get; set; }

      /// <summary>
      /// Gets or sets the serialization options.
      /// </summary>
      /// <value>The options.</value>
      public OTCSerializationOptions Options
      {
         get { return m_serializationOptions; }
         set 
         { 
            m_serializationOptions = value;
            m_isOptionSet = true;
         }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Determines whether the serialization options property has been explicitly
      /// set by the user.
      /// </summary>
      /// <returns>
      /// 	<c>true</c> if the serialization options property has been explicitly
      /// set by the user; otherwise, <c>false</c>.
      /// </returns>
      public bool IsSerializationOptionSet()
      {
         return m_isOptionSet;
      }

      #endregion
   }

   /// <summary>
   /// Add this attribute to properties or fields which you wish to be serialized, when 
   /// the enclosing class uses the <c>OTCSerializableType</c> attribute in which <c>FieldsToSerialize</c>
   /// has been set to <c>AttributedFieldsOnly</c>.
   /// This attribute is applicable to fields and properties.
   /// </summary>
   [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
   public class OTCSerializableFieldAttribute : OTCBaseAttribute { }

   /// <summary>
   /// Makes a property to appear as an attribute for the enclosing class (i.e. the parent element) if possible.
   /// This attribute is applicable to fields and properties only.
   /// </summary>
   [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
   public class OTCAttributeForClassAttribute : OTCBaseAttribute { }

   /// <summary>
   /// Makes a field or property to appear as an attribute for another element, if possible.
   /// This attribute is applicable to fields and properties.
   /// </summary>
   [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
   public class OTCAttributeForAttribute : OTCBaseAttribute
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="OTCAttributeForAttribute"/> class.
      /// </summary>
      /// <param name="parent">The element of which the property becomes an attribute.</param>
      public OTCAttributeForAttribute(string parent)
      {
         this.Parent = parent;
      }

      #region Properties

      /// <summary>
      /// Gets or sets the element of which the property becomes an attribute.
      /// </summary>
      public string Parent { get; set; }

      #endregion
   }

   /// <summary>
   /// Prevents serialization of some field or property.
   /// This attribute is applicable to fields and properties.
   /// </summary>
   [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
   public class OTCDontSerializeAttribute : OTCBaseAttribute { }

   /// <summary>
   /// Defines an alias for the field, property, class, or struct under 
   /// which it will be serialized. This attribute is applicable to fields, 
   /// properties, classes, and structs.
   /// </summary>
   [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct)]
   public class OTCSerializeAsAttribute : OTCBaseAttribute
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="OTCSerializeAsAttribute"/> class.
      /// </summary>
      /// <param name="serializeAs">the alias for the property under which the property will be serialized.</param>
      public OTCSerializeAsAttribute(string serializeAs)
      {
         this.SerializeAs = serializeAs;
      }

      #region Properties

      /// <summary>
      /// Gets or sets the alias for the property under which the property will be serialized.
      /// </summary>
      public string SerializeAs { get; set; }

      #endregion
   }

   /// <summary>
   /// Makes a property or field to appear as a child element 
   /// for another element. This attribute is applicable to fields and properties.
   /// </summary>
   [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
   public class OTCElementForAttribute : OTCBaseAttribute
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="OTCElementForAttribute"/> class.
      /// </summary>
      /// <param name="parent">The element of which the property becomes a child element.</param>
      public OTCElementForAttribute(string parent)
      {
         this.Parent = parent;
      }

      #region Properties

      /// <summary>
      /// Gets or sets the element of which the property becomes a child element.
      /// </summary>
      /// <value>The element of which the property becomes a child element.</value>
      public string Parent { get; set; }

      #endregion
   }

   /// <summary>
   /// Controls the serialization of collection instances.
   /// This attribute is applicable to fields and properties.
   /// </summary>
   [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
   public class OTCCollectionAttribute : OTCBaseAttribute
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="OTCCollectionAttribute"/> class.
      /// </summary>
      /// <param name="serType">type of the serialization of the collection.</param>
      public OTCCollectionAttribute(OTCCollectionSerializationTypes serType)
      {
         this.SerializationType = serType;
         this.SeparateBy = " ";
         this.EachElementName = null;
         this.IsWhiteSpaceSeparator = true;
      }

      #region Properties

      /// <summary>
      /// Gets or sets the type of the serialization of the collection.
      /// </summary>
      /// <value>The type of the serialization of the collection.</value>
      public OTCCollectionSerializationTypes SerializationType { get; set; }

      /// <summary>
      /// Gets or sets the string to separate collection items, if the Serialization type is set to <c>Serially</c>.
      /// </summary>
      /// <value>the string to separate collection items, if the Serialization Type is set to <c>Serially</c>.</value>
      public string SeparateBy { get; set; }

      /// <summary>
      /// Gets or sets the name of each child element corresponding to the collection members, if the Serialization type is set to <c>Recursive</c>.
      /// </summary>
      /// <value>The name of each child element corresponding to the collection members, if the Serialization type is set to <c>Recursive</c>.</value>
      public string EachElementName { get; set; }

      /// <summary>
      /// Gets or sets a value indicating whether white space characters are to be
      /// treated as sparators or not.
      /// </summary>
      /// <value>
      /// <c>true</c> if white space separator characters are to be
      /// treated as sparators; otherwise, <c>false</c>.
      /// </value>
      public bool IsWhiteSpaceSeparator { get; set; }

      #endregion
   }

   /// <summary>
   /// Controls the serialization of generic Dictionary instances.
   /// This attribute is applicable to fields and properties.
   /// </summary>
   [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
   public class OTCDictionaryAttribute : OTCBaseAttribute
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="OTCDictionaryAttribute"/> class.
      /// </summary>
      public OTCDictionaryAttribute()
      {
         this.KeyName = null;
         this.ValueName = null;
         this.EachPairName = null;
         this.SerializeKeyAs = OTCNodeTypes.Element;
         this.SerializeValueAs = OTCNodeTypes.Element;
         this.KeyFormatString = null;
         this.ValueFormatString = null;
      }

      #region Properties

      /// <summary>
      /// Gets or sets the alias for the key part of the dicitonary.
      /// </summary>
      /// <value></value>
      public string KeyName { get; set; }

      /// <summary>
      /// Gets or sets alias for the value part of the dicitonary.
      /// </summary>
      /// <value></value>
      public string ValueName { get; set; }

      /// <summary>
      /// Gets or sets alias for the element containing the Key-Value pair.
      /// </summary>
      /// <value></value>
      public string EachPairName { get; set; }

      /// <summary>
      /// Gets or sets the node type according to which the key part of the dictionary is serialized.
      /// </summary>
      /// <value></value>
      public OTCNodeTypes SerializeKeyAs { get; set; }

      /// <summary>
      /// Gets or sets the node type according to which the value part of the dictionary is serialized.
      /// </summary>
      /// <value></value>
      public OTCNodeTypes SerializeValueAs { get; set; }

      /// <summary>
      /// Gets or sets the key format string.
      /// </summary>
      /// <value></value>
      public string KeyFormatString { get; set; }

      /// <summary>
      /// Gets or sets the value format string.
      /// </summary>
      /// <value></value>
      public string ValueFormatString { get; set; }

      #endregion
   }

   /// <summary>
   /// Specifies the behavior of the deserialization method, if the element/attribute corresponding to this property is missed in the XML input.
   /// This attribute is applicable to fields and properties.
   /// </summary>
   [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
   public class OTCErrorIfMissedAttribute : OTCBaseAttribute
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="OTCErrorIfMissedAttribute"/> class.
      /// </summary>
      /// <param name="treatAs">The value indicating this situation is going to be treated as Error or Warning.</param>
      public OTCErrorIfMissedAttribute(OTCExceptionTypes treatAs)
      {
         this.TreatAs = treatAs;
         this.DefaultValue = null;
      }

      #region Properties

      /// <summary>
      /// Gets or sets the value indicating this situation is going to be treated as Error or Warning.
      /// </summary>
      /// <value>The value indicating this situation is going to be treated as Error or Warning.</value>
      public OTCExceptionTypes TreatAs { get; set; }

      /// <summary>
      /// Gets or sets the default value for the property if the element/attribute corresponding to this property is missed in the XML input.
      /// Setting <c>null</c> means do nothing.
      /// </summary>
      /// <value>The default value.</value>
      public object DefaultValue { get; set; }

      #endregion
   }

   /// <summary>
   /// Specifies the format string provided for serializing data. The format string is the parameter passed to the <c>ToString</c> method.
   /// If this attribute is applied to collection classes, the format, therefore, is applied to the collection members.
   /// This attribute is applicable to fields and properties.
   /// </summary>
   [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
   public class OTCFormatAttribute : OTCBaseAttribute
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="OTCFormatAttribute"/> class.
      /// </summary>
      /// <param name="format">The format string.</param>
      public OTCFormatAttribute(string format)
      {
         this.Format = format;
      }

      #region Properties

      /// <summary>
      /// Gets or sets the format string needed to serialize data. The format string is the parameter 
      /// passed to the <c>ToString</c> method.
      /// </summary>
      /// <value></value>
      public string Format { get; set; }

      #endregion
   }

   /// <summary>
   /// Specifies that a particular class, or a particular property or variable type, that is 
   /// driven from <c>IEnumerable</c> should not be treated as a collection class/object.
   /// This attribute is applicable to fields, properties, classes, and structs.
   /// </summary>
   [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct)]
   public class OTCNotCollectionAttribute : OTCBaseAttribute { }

   /// <summary>
   /// Specifies an alias for an enum member.
   /// This attribute is applicable to enum members.
   /// </summary>
   [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
   public class OTCEnumAttribute : OTCBaseAttribute
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="OTCEnumAttribute"/> class.
      /// </summary>
      /// <param name="alias">The alias.</param>
      public OTCEnumAttribute(string alias)
      {
         this.Alias = alias.Trim();
      }

      #region Properties

      /// <summary>
      /// Gets the alias for the enum member.
      /// </summary>
      /// <value>The alias for the enum member.</value>
      public string Alias { get; private set; }

      #endregion
   }

}
