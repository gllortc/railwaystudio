using System;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Reflection;
using Rwm.Otc.Diagnostics;

namespace Rwm.Otc.Data
{
   public class ORMEntityMember
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ORMEntityMember"/>.
      /// </summary>
      public ORMEntityMember() { }

      /// <summary>
      /// Create a new instance of <see cref="ORMEntityMember"/>.
      /// </summary>
      /// <param name="property">Field property.</param>
      /// <returns>The new instance.</returns>
      public static ORMEntityMember CreateInstance(PropertyInfo property)
      {
         ORMProperty[] atts = (ORMProperty[])property.GetCustomAttributes(typeof(ORMProperty), false);
         if (atts.Length <= 0)
            return null;
         else
         {
            ORMEntityMember member = new ORMEntityMember();
            member.Initialize(property, atts[0]);
            return member;
         }
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the <see cref="Type"/> of the owner class.
      /// </summary>
      public Type OwnerType { get; private set; }

      /// <summary>
      /// Gets a value indicating if the member is the primary key.
      /// </summary>
      public bool IsPrimaryKey { get; private set; }

      /// <summary>
      /// Gets a value indicating if the member is a foreign key.
      /// </summary>
      public bool IsForeignField { get; private set; }

      /// <summary>
      /// Gets a value indicating if the member is a foreign key.
      /// </summary>
      public bool IsForeignCollection { get; private set; }

      /// <summary>
      /// Gets a value indicating if the member corresponds to a binary file storage.
      /// </summary>
      public bool IsFileField { get; private set; }

      /// <summary>
      /// Gets a value indicating if the member is a simple field.
      /// </summary>
      public bool IsField { get; private set; }

      /// <summary>
      /// Gets the ORM attribute assigned to the current member.
      /// </summary>
      public ORMProperty Attribute { get; private set; }

      /// <summary>
      /// Gets the <see cref="PropertyInfo"/> assigned to the current member.
      /// </summary>
      public PropertyInfo Property { get; private set; }

      /// <summary>
      /// Gets the type of the foreign collection (List{String} -> String).
      /// </summary>
      /// <remarks>
      /// This value will be <c>null</c> if member is not a foreign collection.
      /// </remarks>
      public Type ForeignCollectionType { get; private set; } = null;

      /// <summary>
      /// Gets the member corresponding to the foreign key for the foreign collection (Book.Pages -> Pages.BookID).
      /// </summary>
      /// <remarks>
      /// This value will be <c>null</c> if member is not a foreign collection.
      /// </remarks>
      public ORMEntityMember ForeignCollectionMember { get; private set; } = null;

      #endregion

      #region Methods

      /// <summary>
      /// Get the member value.
      /// </summary>
      /// <param name="instance">ORM instance.</param>
      /// <returns>The property instance value.</returns>
      public object GetValue(object instance, object defaultValue = null)
      {
         if (this.IsForeignField)
         {
            if (this.Property.GetValue(instance) is ORMIdentifiableEntity idObj) return idObj.ID;
         }
         else
         {
            return this.Property.GetValue(instance);
         }

         return defaultValue;
      }

      /// <summary>
      /// Get the member value.
      /// </summary>
      /// <param name="instance">ORM instance.</param>
      /// <returns>The property instance value.</returns>
      public object GetReaderValue(object instance, DbDataReader reader)
      {
         object value = null;

         try
         {
            if (this.IsForeignField)
            {
               int ordinal = reader.GetOrdinal(this.Attribute.FieldName);
               if (ordinal >= 0)
               {
                  if (reader[ordinal] is System.DBNull)
                  {
                     value = null;
                  }
                  else if (reader[ordinal] is System.Int64)
                  {
                     value = this.GetForeignFieldValue((long)reader[ordinal]);
                  }
                  else
                  {
                     Logger.LogError(this, "Foreign key type error: only Int64 (long) is supported but provided type is {0}", reader[ordinal].GetType().FullName);
                  }
               }
            }
            else
            {
               value = this.Property.GetValue(instance);
            }

            return value;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, "Error retrieving field {0}{1}{2}", this.Attribute.FieldName, Environment.NewLine, ex.ToString());
            throw ex;
         }
      }

      /// <summary>
      /// Set the property value for the specified instance.
      /// </summary>
      /// <param name="instance">ORM object instance.</param>
      /// <param name="value">Value to set.</param>
      public void SetValue(object instance, object value)
      {
         this.Property.SetValue(instance, value);
      }

      /// <summary>
      /// Set the property value for the specified instance.
      /// </summary>
      /// <param name="instance">ORM object instance.</param>
      /// <param name="value">Value to set.</param>
      public void SetValue(object instance, DbDataReader reader, object parentInstance = null)
      {
         if (reader[this.Attribute.FieldName] is System.DBNull)
         {
            // Let the default value
            return;
         }

         if (this.IsFileField)
         {
            throw new Exception(Logger.LogError(this, "Data mapping error: Not supported FILE fields in property {0}", this.Property.PropertyType.FullName));
         }
         else if (this.Property.PropertyType == typeof(String))
         {
            this.Property.SetValue(instance, reader.GetString(reader.GetOrdinal(this.Attribute.FieldName)));
         }
         else if (this.Property.PropertyType == typeof(Boolean))
         {
            this.Property.SetValue(instance, (Int64)reader[this.Attribute.FieldName] > 0 ? true : false);
         }
         else if (this.Property.PropertyType == typeof(Int32))
         {
            this.Property.SetValue(instance, reader.GetInt32(reader.GetOrdinal(this.Attribute.FieldName)));
         }
         else if (this.Property.PropertyType == typeof(Int64))
         {
            this.Property.SetValue(instance, reader.GetInt64(reader.GetOrdinal(this.Attribute.FieldName)));
         }
         else if (this.Property.PropertyType == typeof(Decimal))
         {
            this.Property.SetValue(instance, reader.GetDecimal(reader.GetOrdinal(this.Attribute.FieldName)));
         }
         else if (this.Property.PropertyType == typeof(Double))
         {
            this.Property.SetValue(instance, reader.GetDouble(reader.GetOrdinal(this.Attribute.FieldName)));
         }
         else if (this.Property.PropertyType == typeof(DateTime))
         {
            if (reader[this.Attribute.FieldName].GetType() != typeof(System.DBNull))
               this.Property.SetValue(instance, reader.GetDateTime(reader.GetOrdinal(this.Attribute.FieldName)));
            else
               this.Property.SetValue(instance, DateTime.MinValue);
         }
         else if (this.Property.PropertyType.IsEnum)
         {
            string enumName = Enum.GetName(this.Property.PropertyType, reader[this.Attribute.FieldName]);
            this.Property.SetValue(instance, Enum.Parse(this.Property.PropertyType, enumName));
         }
         else if (this.Property.PropertyType == typeof(Image))
         {
            if (reader[this.Attribute.FieldName].GetType() == typeof(System.DBNull) || reader[this.Attribute.FieldName] == System.DBNull.Value)
               this.Property.SetValue(instance, null);
            else
               this.Property.SetValue(instance, Image.FromStream(reader.GetStream(reader.GetOrdinal(this.Attribute.FieldName))));
         }
         else if (this.Property.PropertyType.BaseType == typeof(Stream))
         {
            Logger.LogWarning(this, "Stream fields not supported!");

            // TODO: File PROPERTIES
            //if (reader[props[0].FieldName].GetType() != typeof(System.DBNull))
            //   propertyInfo.SetValue(instance, reader.GetStream(reader.GetOrdinal(props[0].FieldName)));
         }
         else
         {
            throw new Exception(Logger.LogError(this, "Data mapping error: Not supported data type conversion for type {0}", this.Property.PropertyType.FullName));
         }
      }

      public override string ToString()
      {
         return "[" + this.Property.Name + " : " + this.Attribute.FieldName + "]";
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize(PropertyInfo property, ORMProperty attribute)
      {
         this.Property = property;
         this.Attribute = attribute;
         this.OwnerType = this.Property.DeclaringType;

         this.IsFileField = (this.Attribute is ORMPropertyFile);
         this.IsForeignField = this.IsOrmInstance(this.Property.PropertyType);
         this.IsForeignCollection = (this.Attribute is ORMForeignCollection);
         this.IsPrimaryKey = (this.Attribute is ORMPrimaryKey);
         this.IsField = !this.IsForeignField && !this.IsForeignCollection && !this.IsPrimaryKey && !this.IsFileField;

         if (this.IsForeignCollection)
         {
            this.ForeignCollectionType = this.Property.PropertyType.GetGenericArguments()[0];
            this.ForeignCollectionMember = this.GetForeignFieldMember(this.ForeignCollectionType);
         }
      }

      /// <summary>
      /// Check if the specified type is an ORM entity.
      /// </summary>
      /// <param name="type">Type to check.</param>
      /// <returns>A value indicating if the type is an ORM instance or not.</returns>
      private bool IsOrmInstance(Type type)
      {
         ORMTable[] tables = (ORMTable[])type.GetCustomAttributes(typeof(ORMTable), false);
         return (tables.Length > 0);
      }

      /// <summary>
      /// Check if the specified type is an ORM entity.
      /// </summary>
      /// <param name="ffType">Type to check.</param>
      /// <returns>A value indicating if the type is an ORM instance or not.</returns>
      private ORMEntityMember GetForeignFieldMember(Type ffType)
      {
         // Get the generic property
         Type at = typeof(ORMEntity<>).MakeGenericType(ffType);
         PropertyInfo propertyInfo = at.GetProperty("ORMStructure");

         // Get the entity structure from the generic type
         object ffDummyInstance = Activator.CreateInstance(typeof(ORMEntityMember));
         ORMEntityStructure structure = (ORMEntityStructure)propertyInfo.GetValue(ffDummyInstance);

         // Find the foreign field into the class ORM structure
         foreach (ORMEntityMember member in structure)
         {
            if (member.Property.PropertyType.Equals(this.OwnerType))
               return member;
         }

         return null;
      }

      private object GetForeignFieldValue(long id)
      {
         // Get the method GET(long)
         Type at = typeof(ORMEntity<>).MakeGenericType(this.Property.PropertyType);
         MethodInfo methodInfo = at.GetMethod("Get", new Type[] { typeof(Int64), typeof(Boolean) });

         // Invoke the method
         object dummy = Activator.CreateInstance(this.Property.PropertyType);
         object instance = methodInfo.Invoke(dummy, new object[] { id, false });

         return instance;
      }

      #endregion

   }
}
