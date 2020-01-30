using System;
using System.Reflection;

namespace Rwm.Otc.xml.serialization
{

   /// <summary>
   /// A wrapper class for members which only can be properties or member variables
   /// </summary>
   internal class MemberWrapper
   {
      private MemberInfo m_memberInfo = null;
      private Type m_memberType;
      private UdtWrapper m_memberTypeWrapper = null;
      private PropertyInfo m_propertyInfoInstance = null;
      private FieldInfo m_fieldInfoInstance = null;
      private OTCCollectionAttribute m_collectionAttributeInstance = null;
      private OTCDictionaryAttribute m_dictionaryAttributeInstance = null;
      private bool m_isProperty = false;
      private string m_serializationLocation = string.Empty;
      private string m_alias = string.Empty;

      /// <summary>
      /// Initializes a new instance of the <see cref="MemberWrapper"/> class.
      /// </summary>
      /// <param name="memberInfo">The member-info to build this instance from.</param>
      /// <param name="callerSerializer">The caller serializer.</param>
      public MemberWrapper(MemberInfo memberInfo, OTCSerializer callerSerializer)
      {
         if (!(memberInfo.MemberType == MemberTypes.Property || memberInfo.MemberType == MemberTypes.Field))
            throw new Exception("Member must be either property or field");

         m_memberInfo = memberInfo;
         m_isProperty = (memberInfo.MemberType == MemberTypes.Property);

         this.Alias = m_memberInfo.Name;

         if (m_isProperty)
            m_propertyInfoInstance = (PropertyInfo)memberInfo;
         else
            m_fieldInfoInstance = (FieldInfo)memberInfo;

         if (m_isProperty)
            m_memberType = m_propertyInfoInstance.PropertyType;
         else
            m_memberType = m_fieldInfoInstance.FieldType;

         m_memberTypeWrapper = TypeWrappersPool.Pool.GetTypeWrapper(this.MemberType, callerSerializer);

         InitInstance();

         if (callerSerializer != null)
         {
            this.TreatErrorsAs = callerSerializer.DefaultExceptionType;
         }
         else
         {
            this.TreatErrorsAs = OTCExceptionTypes.Error;
         }

         foreach (var attr in m_memberInfo.GetCustomAttributes(false))
         {
            if (attr is OTCBaseAttribute)
               ProcessYAXAttribute(attr);
         }
      }

      #region Properties

      /// <summary>
      /// Gets the alias specified for this member.
      /// </summary>
      /// <value>The alias specified for this member.</value>
      public string Alias
      {
         get { return m_alias; }
         private set { m_alias = StringUtils.RefineSingleElement(value); }
      }

      /// <summary>
      /// Gets a value indicating whether the member corrsponding to this instance can be read from.
      /// </summary>
      /// <value><c>true</c> if the member corrsponding to this instance can be read from; otherwise, <c>false</c>.</value>
      public bool CanRead
      {
         get
         {
            if (m_isProperty)
            {
               return m_propertyInfoInstance.CanRead;
            }
            else
            {
               return true;
            }
         }
      }

      /// <summary>
      /// Gets a value indicating whether the member corrsponding to this instance can be written to.
      /// </summary>
      /// <value><c>true</c> if the member corrsponding to this instance can be written to; otherwise, <c>false</c>.</value>
      public bool CanWrite
      {
         get
         {
            if (m_isProperty)
            {
               return m_propertyInfoInstance.CanWrite;
            }
            else
            {
               return true;
            }
         }
      }

      /// <summary>
      /// Gets an array of comment lines.
      /// </summary>
      /// <value>The comment lines.</value>
      public string[] Comment { get; private set; }

      /// <summary>
      /// Gets the default value for this instance.
      /// </summary>
      /// <value>The default value for this instance.</value>
      public object DefaultValue { get; private set; }

      /// <summary>
      /// Gets the format specified for this value; <c>null</c> if no format is specified.
      /// </summary>
      /// <value>the format specified for this value; <c>null</c> if no format is specified.</value>
      public string Format { get; private set; }

      /// <summary>
      /// Gets a value indicating whether this instance has comments.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if this instance has comments; otherwise, <c>false</c>.
      /// </value>
      public bool HasComment
      {
         get { return Comment != null && Comment.Length > 0; }
      }

      /// <summary>
      /// Gets a value indicating whether this instance has format values specified
      /// </summary>
      /// <value>
      /// <c>true</c> if this instance has format values specified; otherwise, <c>false</c>.
      /// </value>
      public bool HasFormat
      {
         // empty string may be considered as a valid format
         get { return this.Format != null; }
      }

      /// <summary>
      /// Gets a value indicating whether this instance is attributed as dont serialize.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if this instance is attributed as dont serialize; otherwise, <c>false</c>.
      /// </value>
      public bool IsAttributedAsDontSerialize { get; private set; }

      /// <summary>
      /// Gets a value indicating whether this instance is attributed as not-collection.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if this instance is attributed as not-collection; otherwise, <c>false</c>.
      /// </value>
      public bool IsAttributedAsNotCollection { get; private set; }

      /// <summary>
      /// Gets a value indicating whether this instance is attributed as serializable.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if this instance is attributed as serializable; otherwise, <c>false</c>.
      /// </value>
      public bool IsAttributedAsSerializable { get; private set; }

      /// <summary>
      /// Gets a value indicating whether this instance is serialized as an XML attribute.
      /// </summary>
      /// <value>
      /// <c>true</c> if this instance is serialized as an XML attribute; otherwise, <c>false</c>.
      /// </value>
      public bool IsSerializedAsAttribute { get; private set; }

      /// <summary>
      /// Gets a value indicating whether this instance is serialized as an XML element.
      /// </summary>
      /// <value>
      /// <c>true</c> if this instance is serialized as an XML element; otherwise, <c>false</c>.
      /// </value>
      public bool IsSerializedAsElement
      {
         get { return !this.IsSerializedAsAttribute; }
      }

      /// <summary>
      /// Gets the type of the member.
      /// </summary>
      /// <value>The type of the member.</value>
      public Type MemberType
      {
         get { return m_memberType; }
      }

      /// <summary>
      /// Gets the type wrapper instance corrsponding to the member-type of this instance.
      /// </summary>
      /// <value>The type wrapper instance corrsponding to the member-type of this instance.</value>
      public UdtWrapper MemberTypeWrapper
      {
         get { return m_memberTypeWrapper; }
      }

      /// <summary>
      /// Gets the original of this member (as opposed to its alias).
      /// </summary>
      /// <value>The original of this member .</value>
      public string OriginalName
      {
         get { return this.m_memberInfo.Name; }
      }

      /// <summary>
      /// Gets the serialization location.
      /// </summary>
      /// <value>The serialization location.</value>
      public string SerializationLocation
      {
         get { return m_serializationLocation; }
         private set { m_serializationLocation = StringUtils.RefineLocationString(value); }
      }

      /// <summary>
      /// Gets the exception type for this instance in case of encountering missing values
      /// </summary>
      /// <value>The exception type for this instance in case of encountering missing values</value>
      public OTCExceptionTypes TreatErrorsAs { get; private set; }

      /// <summary>
      /// Gets the collection attribute instance.
      /// </summary>
      /// <value>The collection attribute instance.</value>
      public OTCCollectionAttribute CollectionAttributeInstance
      {
         get { return m_collectionAttributeInstance; }
      }

      /// <summary>
      /// Gets the dictionary attribute instance.
      /// </summary>
      /// <value>The dictionary attribute instance.</value>
      public OTCDictionaryAttribute DictionaryAttributeInstance
      {
         get { return m_dictionaryAttributeInstance; }
      }

      /// <summary>
      /// Gets a value indicating whether this instance is treated as a collection.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if this instance is treated as a collection; otherwise, <c>false</c>.
      /// </value>
      public bool IsTreatedAsCollection
      {
         get { return !IsAttributedAsNotCollection && m_memberTypeWrapper.IsTreatedAsCollection; }
      }

      /// <summary>
      /// Gets a value indicating whether this instance is treated as a dictionary.
      /// </summary>
      /// <value>
      /// <c>true</c> if this instance is treated as a dictionary; otherwise, <c>false</c>.
      /// </value>
      public bool IsTreatedAsDictionary
      {
         get { return !IsAttributedAsNotCollection && m_memberTypeWrapper.IsTreatedAsDictionary; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Gets the original value of this member in the specified object
      /// </summary>
      /// <param name="obj">The object whose value corresponding to this instance, must be retreived.</param>
      /// <param name="index">The array of indeces (usually <c>null</c>).</param>
      /// <returns>the original value of this member in the specified object</returns>
      public object GetOriginalValue(object obj, object[] index)
      {
         if (m_isProperty)
         {
            return m_propertyInfoInstance.GetValue(obj, index);
         }
         else
         {
            return m_fieldInfoInstance.GetValue(obj);
         }
      }

      /// <summary>
      /// Gets the processed value of this member in the specified object
      /// </summary>
      /// <param name="obj">The object whose value corresponding to this instance, must be retreived.</param>
      /// <returns>the processed value of this member in the specified object</returns>
      public object GetValue(object obj)
      {
         object elementValue = GetOriginalValue(obj, null);

         if (elementValue == null)
            return null;

         if (m_memberTypeWrapper.IsEnum)
         {
            return m_memberTypeWrapper.EnumWrapper.GetAlias(elementValue);
         }

         // trying to build the element value
         if (this.HasFormat && !this.IsTreatedAsCollection)
         {
            // do the formatting. If formatting succeeds the type of 
            // the elementValue will become 'System.String'
            elementValue = ReflectionUtils.TryFormatObject(elementValue, this.Format);
         }

         return elementValue;
      }

      /// <summary>
      /// Sets the value of this member in the specified object
      /// </summary>
      /// <param name="obj">The object whose member corresponding to this instance, must be given value.</param>
      /// <param name="value">The value.</param>
      public void SetValue(object obj, object value)
      {
         if (m_isProperty)
         {
            m_propertyInfoInstance.SetValue(obj, value, null);
         }
         else
         {
            m_fieldInfoInstance.SetValue(obj, value);
         }
      }

      /// <summary>
      /// Determines whether this instance of <c>MemberWrapper</c> can be serialized.
      /// </summary>
      /// <param name="serializationFields">The serialization fields.</param>
      /// <returns>
      /// <c>true</c> if this instance of <c>MemberWrapper</c> can be serialized; otherwise, <c>false</c>.
      /// </returns>
      public bool IsAllowedToBeSerialized(OTCSerializationFields serializationFields)
      {
         if (serializationFields == OTCSerializationFields.AllFields)
            return !this.IsAttributedAsDontSerialize;
         else if (serializationFields == OTCSerializationFields.AttributedFieldsOnly)
            return !this.IsAttributedAsDontSerialize && this.IsAttributedAsSerializable;
         else if (serializationFields == OTCSerializationFields.PublicPropertiesOnly)
            return !this.IsAttributedAsDontSerialize && m_isProperty && ReflectionUtils.IsPublicProperty(m_propertyInfoInstance);
         else
            throw new Exception("Unknown serialization field option");
      }

      /// <summary>
      /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
      /// </summary>
      /// <returns>
      /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
      /// </returns>
      public override string ToString()
      {
         return m_memberInfo.ToString();
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initializes this instance of <c>MemberWrapper</c>.
      /// </summary>
      private void InitInstance()
      {
         this.Comment = null;
         this.IsAttributedAsSerializable = false;
         this.IsAttributedAsDontSerialize = false;
         this.IsAttributedAsNotCollection = false;
         this.IsSerializedAsAttribute = false;
         this.SerializationLocation = ".";
         this.Format = null;
         InitDefaultValue();
      }

      /// <summary>
      /// Initializes the default value for this instance of <c>MemberWrapper</c>.
      /// </summary>
      private void InitDefaultValue()
      {
         if (this.MemberType.IsValueType)
            this.DefaultValue = this.MemberType.InvokeMember(string.Empty, System.Reflection.BindingFlags.CreateInstance, null, null, new object[0]);
         else
            this.DefaultValue = null;
      }

      /// <summary>
      /// Processes the specified attribute which is an instance of <c>YAXAttribute</c>.
      /// </summary>
      /// <param name="attr">The attribute to process.</param>
      private void ProcessYAXAttribute(object attr)
      {
         if (attr is OTCCommentAttribute)
         {
            string comment = (attr as OTCCommentAttribute).Comment;
            if (!String.IsNullOrEmpty(comment))
            {
               string[] comments = comment.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
               for (int i = 0; i < comments.Length; i++)
               {
                  comments[i] = String.Format(" {0} ", comments[i].Trim());
               }

               this.Comment = comments;
            }
         }
         else if (attr is OTCSerializableFieldAttribute)
         {
            this.IsAttributedAsSerializable = true;
         }
         else if (attr is OTCAttributeForClassAttribute)
         {
            if (ReflectionUtils.IsBasicType(this.MemberType))
            {
               this.IsSerializedAsAttribute = true;
               this.SerializationLocation = ".";
            }
         }
         else if (attr is OTCAttributeForAttribute)
         {
            if (ReflectionUtils.IsBasicType(this.MemberType))
            {
               this.IsSerializedAsAttribute = true;
               this.SerializationLocation = (attr as OTCAttributeForAttribute).Parent;
            }
         }
         else if (attr is OTCDontSerializeAttribute)
         {
            this.IsAttributedAsDontSerialize = true;
         }
         else if (attr is OTCSerializeAsAttribute)
         {
            this.Alias = (attr as OTCSerializeAsAttribute).SerializeAs;
         }
         else if (attr is OTCElementForAttribute)
         {
            this.IsSerializedAsAttribute = false;
            this.SerializationLocation = (attr as OTCElementForAttribute).Parent;
         }
         else if (attr is OTCCollectionAttribute)
         {
            m_collectionAttributeInstance = attr as OTCCollectionAttribute;
         }
         else if (attr is OTCDictionaryAttribute)
         {
            m_dictionaryAttributeInstance = attr as OTCDictionaryAttribute;
         }
         else if (attr is OTCErrorIfMissedAttribute)
         {
            OTCErrorIfMissedAttribute temp = attr as OTCErrorIfMissedAttribute;
            this.DefaultValue = temp.DefaultValue;
            this.TreatErrorsAs = temp.TreatAs;
         }
         else if (attr is OTCFormatAttribute)
         {
            this.Format = (attr as OTCFormatAttribute).Format;
         }
         else if (attr is OTCNotCollectionAttribute)
         {
            // arrays are always treated as collections
            if (!ReflectionUtils.IsArray(this.MemberType))
               this.IsAttributedAsNotCollection = true;
         }
         else if (attr is OTCSerializableTypeAttribute)
         {
            // this should not happen
            throw new Exception("This attribute is not applicable to fields and properties!");
         }
         else
         {
            throw new Exception("Added new attribute type to the library but not yet processed!");
         }
      }

      #endregion

   }
}
