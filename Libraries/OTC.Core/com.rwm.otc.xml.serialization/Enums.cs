namespace Rwm.Otc.xml.serialization
{

   /// <summary>
   /// Enumerates different kinds of exception handling policies as used by YAX Library.
   /// </summary>
   public enum OTCExceptionHandlingPolicies
   {
      /// <summary>
      /// Throws Both Warnings And Errors
      /// </summary>
      ThrowWarningsAndErrors,

      /// <summary>
      /// Throws Errors only (default)
      /// </summary>
      ThrowErrorsOnly,

      /// <summary>
      /// Does not throw exceptions, the errors can be accessed via the YAXParsingErrors instance
      /// </summary>
      DoNotThrow
   }

   /// <summary>
   /// Enumerates different possible behaviours of the library toward exceptions
   /// </summary>
   public enum OTCExceptionTypes
   {
      /// <summary>
      /// Ignore non-fatal exceptions; neither throw them, nor log them.
      /// </summary>
      Ignore,

      /// <summary>
      /// Treat exception as a warning
      /// </summary>
      Warning,

      /// <summary>
      /// Treat exception as an error
      /// </summary>
      Error
   }

   /// <summary>
   /// Enumerates different serialization options which could be set at construction time.
   /// </summary>
   public enum OTCSerializationOptions
   {
      /// <summary>
      /// Prevents serialization of null objects.
      /// </summary>
      DontSerializeNullObjects,

      /// <summary>
      /// Serializes null objects also (the default)
      /// </summary>
      SerializeNullObjects
   }

   /// <summary>
   /// Enumerates the possible ways of serializing collection classes
   /// </summary>
   public enum OTCCollectionSerializationTypes
   {
      /// <summary>
      /// Serializes each member of the collection, as a separate element, all enclosed in an element regarding the collection itself
      /// </summary>
      Recursive,

      /// <summary>
      /// Serializes each member of the collection, as a separate element, with no enclosing element for the collection
      /// </summary>
      RecursiveWithNoContainingElement,

      /// <summary>
      /// Serializes all members of the collection in one element separated by some delimiter, if possible.
      /// </summary>
      Serially
   }

   /// <summary>
   /// Enumerates possible XML node types upon which a property can be serialized.
   /// </summary>
   public enum OTCNodeTypes
   {
      /// <summary>
      /// Serialize data as an attribute for the base element
      /// </summary>
      Attribute,

      /// <summary>
      /// Serialize data as an element
      /// </summary>
      Element
   }

   /// <summary>
   /// Enumerates possible options for a serializable type
   /// </summary>
   public enum OTCSerializationFields
   {
      /// <summary>
      /// Serializes only the public properties (the default behaviour)
      /// </summary>
      PublicPropertiesOnly,

      /// <summary>
      /// Serializes all fields (properties or member variables) which are public, or non-public.
      /// </summary>
      AllFields,

      /// <summary>
      /// Serializes all fields (properties or member variables) which are public, or non-public, if attributed as <c>YAXSerializableField</c>
      /// </summary>
      AttributedFieldsOnly
   }

}
