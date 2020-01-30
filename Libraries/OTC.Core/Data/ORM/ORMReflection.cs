using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rwm.Otc.Data.ORM
{
   /// <summary>
   /// Reflection utilities for the ORM entities.
   /// </summary>
   class ORMReflection
   {
      /// <summary>
      /// Check if the specified type is an ORM entity.
      /// </summary>
      /// <param name="type">Type to check.</param>
      /// <returns>A value indicating if the type is an ORM instance or not.</returns>
      public static bool IsOrmInstance(Type type)
      {
         ORMTable[] tables = (ORMTable[])type.GetCustomAttributes(typeof(ORMTable), false);
         return (tables.Length > 0);
      }

      /// <summary>
      /// Check if the specified type is an ORM foreig collection.
      /// These collections are list of ORMEntity classes.
      /// </summary>
      /// <param name="type">Type to check.</param>
      /// <returns>A value indicating if the type is an ORM foreign colelction or not.</returns>
      public static bool IsOrmForeignCollection(Type type)
      {
         if (type is IEnumerable)
            return ORMReflection.IsOrmInstance(type.GetGenericArguments()[0]);
         else
            return false;
      }

      /// <summary>
      /// Gets the ORM table attribute for the specified type.
      /// </summary>
      /// <param name="type">Type to check.</param>
      /// <returns>The requestes ORMTable instance or null if the type is not an ORM entity.</returns>
      public static ORMTable GetORMTable(Type type)
      {
         ORMTable[] tables;

         // Generate FROM clause
         tables = (ORMTable[])type.GetCustomAttributes(typeof(ORMTable), false);
         if (tables.Length > 0)
         {
            return (ORMTable)tables[0];
         }

         return null;
      }

      /// <summary>
      /// Get the <see cref="ORMProperty"/> corresponding to the specified property.
      /// </summary>
      /// <param name="type">Type of class for which we're getting the property.</param>
      /// <param name="propertyName">The name of the property.</param>
      /// <returns>The requestes attribute or null if the table doesn't have the property or the property doesn't have the attribute <see cref="ORMProperty"/>.</returns>
      public static ORMProperty GetORMProperty(Type type, string propertyName)
      {
         foreach (var propertyInfo in type.GetProperties())
         {
            if (propertyInfo.Name.Equals(propertyName))
            {
               ORMProperty[] props = (ORMProperty[])propertyInfo.GetCustomAttributes(typeof(ORMProperty), false);
               if (props.Length > 0)
                  return props[0];
            }
         }

         return null;
      }

      /// <summary>
      /// Get all <see cref="ORMProperty"/> corresponding to the type properties marked as a field.
      /// </summary>
      /// <param name="type">Type of class for which we're getting the properties.</param>
      /// <returns>The requestes attribute or an empty array if the table doesn't have any marked property with the attribute <see cref="ORMProperty"/>.</returns>
      public static List<ORMProperty> GetORMFields(Type type)
      {
         List<ORMProperty> fields = new List<ORMProperty>();

         foreach (var propertyInfo in type.GetProperties())
         {
            ORMProperty[] props = (ORMProperty[])propertyInfo.GetCustomAttributes(typeof(ORMProperty), false);
            foreach (ORMProperty ormProperty in props)
            {
               fields.Add(ormProperty);
            }
         }

         return fields;
      }

      ///// <summary>
      ///// Get all <see cref="ORMProperty"/> corresponding to the type properties marked as a foreign collections.
      ///// </summary>
      ///// <param name="type">Type of class for which we're getting the properties.</param>
      ///// <returns>The requested list of attributes or an empty array if the table doesn't have any marked property as a foreign collection.</returns>
      //public static List<ORMProperty> GetORMForeignCollections(Type type)
      //{
      //   return ORMReflection.GetORMPropertiesByType(type, PropertyType.ForeignCollection);
      //}

      /// <summary>
      /// Get all <see cref="ORMProperty"/> corresponding to the type properties marked as a foreign collections.
      /// </summary>
      /// <param name="type">Type of class for which we're getting the properties.</param>
      /// <returns>The requested list of attributes or an empty array if the table doesn't have any marked property as a foreign collection.</returns>
      public static ORMProperty GetORMForeignCollection(PropertyInfo propertyInfo)
      {
         ORMProperty[] props = (ORMProperty[])propertyInfo.GetCustomAttributes(typeof(ORMProperty), false);
         if (props.Length > 0)
            return props[0];
         else
            return null;
      }

      /// <summary>
      /// Get the <see cref="PropertyInfo"/> corresponding to the primary key.
      /// </summary>
      /// <param name="type">Type of class for which we're getting the primary key.</param>
      /// <returns>The requested instance or null if the table doesn't have declared a primary key.</returns>
      public static PropertyInfo GetPrimaryKeyProperty(Type type)
      {
         foreach (PropertyInfo pk in type.GetProperties().Where(prop => prop.IsDefined(typeof(ORMPrimaryKey), false)))
         {
            return pk;
         }

         return null;
      }

      /// <summary>
      /// Get the <see cref="ORMPrimaryKey"/> corresponding to the class property.
      /// </summary>
      /// <param name="type">Type of class for which we're getting the primary key.</param>
      /// <returns>The requested instance or null if the table doesn't have declared a primary key.</returns>
      public static ORMPrimaryKey GetPrimaryKey(PropertyInfo propertyInfo)
      {
         object[] pks = propertyInfo.GetCustomAttributes(typeof(ORMPrimaryKey), false);
         if (pks?.Length > 0) return (ORMPrimaryKey)pks[0];
         return null;
      }

      /// <summary>
      /// Get the primary key value of an ORM instance.
      /// </summary>
      /// <param name="instance">ORM instance.</param>
      /// <returns>The requested <see cref="Int64"/> value or <c>null</c> if the instance is not an ORM entity.</returns>
      public static long GetPrimaryKeyValue(object instance)
      {
         foreach (PropertyInfo pk in instance.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(ORMPrimaryKey), false)))
         {
            return (long)pk.GetValue(instance);
         }

         return -1;
      }

      /// <summary>
      /// Get the primary key value of an ORM instance.
      /// </summary>
      /// <param name="instance">ORM instance.</param>
      /// <returns>The requested <see cref="Int64"/> value or <c>null</c> if the instance is not an ORM entity.</returns>
      public static bool SetPrimaryKeyValue(object instance, long value)
      {
         foreach (PropertyInfo pk in instance.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(ORMPrimaryKey), false)))
         {
            pk.SetValue(instance, value);
            return true;
         }

         return false;
      }

      ///// <summary>
      ///// Get all <see cref="ORMProperty"/> corresponding to the type properties marked as a foreign collections.
      ///// </summary>
      ///// <param name="type">Type of class for which we're getting the properties.</param>
      ///// <returns>The requested list of attributes or an empty array if the table doesn't have any marked property as a foreign collection.</returns>
      //public static List<PropertyInfo> GetForeignCollectionProperties(Type type)
      //{
      //   List<PropertyInfo> fields = new List<PropertyInfo>();

      //   foreach (var propertyInfo in type.GetProperties())
      //   {
      //      ORMProperty[] props = (ORMProperty[])propertyInfo.GetCustomAttributes(typeof(ORMProperty), false);
      //      foreach (ORMProperty ormProperty in props)
      //      {
      //         if (ormProperty.Type == PropertyType.ForeignCollection)
      //            fields.Add(propertyInfo);
      //      }
      //   }

      //   return fields;
      //}

      ///// <summary>
      ///// Return the foreign property pointing to the primary type.
      ///// </summary>
      ///// <param name="primaryType">Primary type.</param>
      ///// <param name="foreignType">Type that contains a property (single or enumerable) pointing to the primary type.</param>
      ///// <returns>The requested <see cref="PropertyInfo"/> or <c>null</c> if property cannot be found.</returns>
      //public static PropertyInfo GetForeignCollectionKeyProperty(Type primaryType, Type foreignType)
      //{
      //   if (foreignType == null)
      //      return null;

      //   foreach (PropertyInfo primaryProperty in primaryType.GetProperties())
      //   {
      //      ORMProperty[] ormPrimaryPropertyAtts = (ORMProperty[])primaryProperty.GetCustomAttributes(typeof(ORMProperty), false);
      //      if (ormPrimaryPropertyAtts.Length > 0)
      //      {
      //         if (ormPrimaryPropertyAtts[0].Type == PropertyType.ForeignCollection)
      //         {
      //            Type[] listType = primaryProperty.PropertyType.GetGenericArguments();
      //            if (listType.Length > 0 && listType[0] == foreignType)
      //            {
      //               foreach (PropertyInfo foreignProperty in foreignType.GetProperties())
      //               {
      //                  ORMProperty[] ormForeigPropertyAtts = (ORMProperty[])foreignProperty.GetCustomAttributes(typeof(ORMProperty), false);
      //                  if (ormForeigPropertyAtts.Length > 0)
      //                  {
      //                     if (ormForeigPropertyAtts[0].Type == PropertyType.ForeignField && foreignProperty.PropertyType == primaryType)
      //                     {
      //                        return foreignProperty;
      //                     }
      //                  }
      //               }
      //            }
      //         }
      //      }
      //   }

      //   return null;
      //}

      /// <summary>
      /// Get all <see cref="ORMProperty"/> corresponding to the type properties marked as a foreign collections.
      /// </summary>
      /// <param name="type">Type of class for which we're getting the properties.</param>
      /// <returns>The requested list of attributes or an empty array if the table doesn't have any marked property as a foreign collection.</returns>
      public static List<Int64> GetForeignCollectionIdentifiers(object instance, PropertyInfo property)
      {
         object collectionValue = null;
         List<Int64> identifiers = new List<Int64>();

         if (property != null)
         {
            collectionValue = (IEnumerable<ORMIdentifiableEntity>)property.GetValue(instance);
            if (collectionValue != null)
            {
               foreach (var fValue in (IEnumerable<ORMIdentifiableEntity>)property.GetValue(instance))
               {
                  identifiers.Add(fValue.ID);
               }
            }
         }

         return identifiers;
      }

      #region Private Members

      //private static List<ORMProperty> GetORMPropertiesByType(Type type, PropertyType typeOfProperty)
      //{
      //   List<ORMProperty> fields = new List<ORMProperty>();

      //   foreach (var propertyInfo in type.GetProperties())
      //   {
      //      ORMProperty[] props = (ORMProperty[])propertyInfo.GetCustomAttributes(typeof(ORMProperty), false);
      //      foreach (ORMProperty ormProperty in props)
      //      {
      //         if (ormProperty.Type != typeOfProperty)
      //            fields.Add(ormProperty);
      //      }
      //   }

      //   return fields;
      //}

      #endregion

   }
}
