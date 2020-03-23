using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Rwm.Otc.Diagnostics;
using static Rwm.Otc.Data.ORM.ORMForeignCollection;

namespace Rwm.Otc.Data.ORM
{
   /// <summary>
   /// Implements the ORM core for persistent objects.
   /// </summary>
   /// <typeparam name="T">Type of object to manage.</typeparam>
   public class ORMEntity<T> : ORMSqliteDriver, ORMIdentifiableEntity
   {

      #region Constructors

      /// <summary>
      /// Initialize the static data for all instances of <see cref="ORMEntity"/>.
      /// </summary>
      static ORMEntity()
      {
         if (ORMEntity<T>.InMemoryTable == null)
            ORMEntity<T>.InMemoryTable = new Dictionary<long, T>();

         if (ORMEntity<T>.SqlDialect == null)
            ORMEntity<T>.SqlDialect = new ORMSqliteDialect<T>();

         if (ORMEntity<T>.ORMStructure == null)
            ORMEntity<T>.ORMStructure = new ORMEntityStructure(typeof(T));
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the ORM internal structure.
      /// </summary>
      public static ORMEntityStructure ORMStructure { get; private set; }

      /// <summary>
      /// Gets or sets the dictionary acting as a cache of the database table.
      /// </summary>
      private static Dictionary<long, T> InMemoryTable { get; set; }

      /// <summary>
      /// Gets or sets the SQL generator.
      /// </summary>
      private static ORMSqliteDialect<T> SqlDialect { get; set; }

      /// <summary>
      /// Gets the associated database table name.
      /// </summary>
      public static string TableName
      {
         get { return ORMEntity<T>.ORMStructure.Table.TableName; }
      }

      /// <summary>
      /// Gets a value indicating id the instance is new (without identifier) or an existing instance (with identifier).
      /// </summary>
      public bool IsNew
      {
         get { return (this.ID <= 0); }
      }

      /// <summary>
      /// Gets the instance unique identifier.
      /// </summary>
      public virtual long ID { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Save an instance into the database.
      /// </summary>
      /// <remarks>
      /// This method won't store the foreign collection values. It must be performed manually.
      /// </remarks>
      /// <param name="instance">Instance to save.</param>
      public static long Save(T instance)
      {
         // Check if is new object (ID <= 0)
         long id = ORMEntity<T>.GetPrimaryKeyValue(instance);

         if (id <= 0)
            // Create the new instance into DB
            return ORMEntity<T>.InsertDatabaseRecord(instance);
         else
            // Update the instance into DB
            return ORMEntity<T>.UpdateDatabaseRecord(instance);
      }

      /// <summary>
      /// Delete an existing instance.
      /// </summary>
      /// <param name="instance">Instance to delete.</param>
      public static int Delete(T instance)
      {
         return ORMEntity<T>.Delete((instance as ORMIdentifiableEntity).ID);
      }

      /// <summary>
      /// Delete an existing instance.
      /// </summary>
      /// <param name="id">Instance unique identifier (DB).</param>
      public static int Delete(Int32 id)
      {
         return ORMEntity<T>.Delete((Int64)id);
      }

      /// <summary>
      /// Delete an existing instance.
      /// </summary>
      /// <param name="id">Instance unique identifier (DB).</param>
      public static int Delete(Int64 id)
      {
         return ORMEntity<T>.DeleteDatabaseRecord(id);
      }

      /// <summary>
      /// Get the requested instance.
      /// </summary>
      /// <param name="id">Instance unique identifier (DB).</param>
      /// <returns>The requested instance or <c>null</c> if the instance cannot be found.</returns>
      public static T Get(Int32 id)
      {
         return ORMEntity<T>.Get((Int64)id, true);
      }

      /// <summary>
      /// Get the requested instance.
      /// </summary>
      /// <param name="id">Instance unique identifier (DB).</param>
      /// <returns>The requested instance or <c>null</c> if the instance cannot be found.</returns>
      public static T Get(Int64 id, bool closeConnection = true)
      {
         T instance;

         // Check if the instance is in memory
         if (ORMEntity<T>.InMemoryTable.ContainsKey(id))
         {
            instance = ORMEntity<T>.InMemoryTable[id];
         }
         else
         {
            instance = ORMEntity<T>.ReadFromDatabase(id, closeConnection);
         }

         return instance;
      }

      /// <summary>
      /// Gets all instances.
      /// </summary>
      /// <returns>The requested list of instances.</returns>
      public static ICollection<T> FindAll()
      {
         return ORMEntity<T>.ReadAllRecords();
      }

      /// <summary>
      /// Gets all instances.
      /// </summary>
      /// <returns>The requested list of instances.</returns>
      public static ICollection<T> FindBy(string propertyName, object value, bool closeConnection = true)
      {
         return ORMEntity<T>.ReadRecords(propertyName, value, closeConnection);
      }

      /// <summary>
      /// Gets all instances.
      /// </summary>
      /// <returns>The requested list of instances.</returns>
      public static ICollection<T> ExecuteQuery(string sql, bool closeConnection = true)
      {
         return ORMEntity<T>.ReadQueryRecords(sql, closeConnection);
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Add an instance into in-memory table.
      /// </summary>
      private static void AddInMemoryTable(long id, T instance)
      {
         if (!ORMEntity<T>.InMemoryTable.ContainsKey(id))
            ORMEntity<T>.InMemoryTable.Add(id, instance);
         else if (ORMEntity<T>.InMemoryTable[id] == null && instance != null)
            ORMEntity<T>.InMemoryTable[id] = instance;
      }

      /// <summary>
      /// Get the specified instance of the type.
      /// </summary>
      /// <param name="id">Instance primary key.</param>
      /// <returns>The specified instance.</returns>
      private static T ReadFromDatabase(long id, bool closeConnection = true)
      {
         T instance = default;
         ORMSqlCommand cmd = ORMEntity<T>.SqlDialect.GetSelectCommand();

         // Connecto to database
         ORMEntity<T>.Connect();

         // Set command parameters
         ORMEntity<T>.SetParameter(cmd.PrimaryKeyName, id);

         // Execute the SELECT sentence to retrieve the instance properties
         using (DbDataReader reader = ORMEntity<T>.ExecuteReader(cmd.SqlCommand))
         {
            if (reader.Read())
            {
               instance = ORMEntity<T>.MapData(typeof(T), reader);
            }
         }

         // Close the connection to database
         if (closeConnection)
            ORMEntity<T>.Disconnect();

         return instance;
      }

      /// <summary>
      /// Update an existing database record.
      /// </summary>
      /// <param name="instance">Instance to update.</param>
      /// <returns>The instance unique identifier.</returns>
      private static long UpdateDatabaseRecord(T instance)
      {
         object value;
         ORMSqlCommand cmd = ORMEntity<T>.SqlDialect.GetUpdateCommand();

         // Connecto to database
         ORMEntity<T>.Connect();

         // Set command parameters
         ORMEntity<T>.SetParameter(cmd.PrimaryKeyName, cmd.PrimaryKeyName.GetValue(instance));
         foreach (ORMEntityMember param in cmd.Parameters)
         {
            value = param.GetValue(instance);
            ORMEntity<T>.SetParameter(param, value is null ? DBNull.Value : value);
         }

         // Execute the SELECT sentence to retrieve the instance properties
         ORMEntity<T>.ExecuteNonQuery(cmd.SqlCommand);

         // Close the connection to database
         ORMEntity<T>.Disconnect();

         return ((ORMIdentifiableEntity)instance).ID;
      }

      /// <summary>
      /// Create a new instance into database.
      /// </summary>
      /// <param name="instance">Instance to create.</param>
      /// <returns>The instance unique identifier.</returns>
      private static long InsertDatabaseRecord(T instance)
      {
         object value;
         ORMSqlCommand cmd = ORMEntity<T>.SqlDialect.GetInsertCommand();

         // Connecto to database
         ORMEntity<T>.Connect();

         // Set command parameters
         foreach (ORMEntityMember param in cmd.Parameters)
         {
            value = param.GetValue(instance);
            ORMEntity<T>.SetParameter(param, value is null ? DBNull.Value : value);
         }

         // Execute the SELECT sentence to retrieve the instance properties
         ORMEntity<T>.ExecuteNonQuery(cmd.SqlCommand);
         long id = ExecuteScalar(SqlDialect.GetNewIDCommand().SqlCommand);

         // Set the generated new record unique identifier to the current instance
         ORMEntity<T>.ORMStructure.PrimaryKey.SetValue(instance, id);

         // Close the connection to database
         ORMEntity<T>.Disconnect();

         // Created project is added to in-memory table
         ORMEntity<T>.AddInMemoryTable(id, instance);

         return ((ORMIdentifiableEntity)instance).ID;
      }

      /// <summary>
      /// Delete an existing instance from database.
      /// </summary>
      /// <param name="instance">Instance unique identifier.</param>
      private static int DeleteDatabaseRecord(long id)
      {
         ORMSqlCommand cmd = ORMEntity<T>.SqlDialect.GetDeleteCommand();

         // Delete foreign records
         ORMEntity<T>.DeleteDatabaseForeignRecords(id);

         // Connecto to database
         ORMEntity<T>.Connect();

         // Set command parameters
         ORMEntity<T>.SetParameter(cmd.PrimaryKeyName, id);

         // Execute the SQL command
         int rowsAffected = ExecuteNonQuery(cmd.SqlCommand);

         // Close the connection to database
         ORMEntity<T>.Disconnect();

         // Delete the instance from in-memory database
         if (ORMEntity<T>.InMemoryTable.ContainsKey(id))
            ORMEntity<T>.InMemoryTable.Remove(id);

         return rowsAffected;
      }

      /// <summary>
      /// Delete an existing instance from database.
      /// </summary>
      /// <param name="instance">Instance unique identifier.</param>
      private static int DeleteDatabaseForeignRecords(long id)
      {
         int rowsAffected = 0;
         object dummy;
         T instance = default;
         Type foreignType;
         MethodInfo deleteMethod;

         // Check if there are any foreign collection to delete in cascade
         foreach (ORMEntityMember member in ORMEntity<T>.ORMStructure.ForeignCollections)
         {
            // Get the owner instance
            if (instance == null) instance = ORMEntity<T>.Get(id);

            if (((ORMForeignCollection)member.Attribute).OnDeleteAction == OnDeleteActionTypes.DeleteInCascade)
            {
               // Get the method GET(long)
               foreignType = member.ForeignCollectionType;
               foreignType = typeof(ORMEntity<>).MakeGenericType(foreignType);
               deleteMethod = foreignType.GetMethod("Delete", new Type[] { typeof(Int64) });

               // Delete each instance in collection
               foreach (long objId in ORMEntity<T>.GetForeignCollectionIdentifiers(instance, member))
               {
                  // Invoke the method
                  dummy = Activator.CreateInstance(foreignType);
                  rowsAffected += (int)deleteMethod.Invoke(dummy, new object[] { objId });
               }
            }
         }

         return rowsAffected;
      }

      /// <summary>
      /// Get the specified instance of the type.
      /// </summary>
      /// <param name="id">Instance primary key.</param>
      /// <returns>The specified instance.</returns>
      private static ICollection<T> ReadAllRecords()
      {
         List<long> ids = new List<long>();
         List<T> list = new List<T>();
         ORMSqlCommand cmd = ORMEntity<T>.SqlDialect.GetSelectAllCommand();

         // Connecto to database
         ORMEntity<T>.Connect();

         // Execute the SELECT sentence to retrieve the instance properties
         using (DbDataReader reader = ORMEntity<T>.ExecuteReader(cmd.SqlCommand))
         {
            while (reader.Read()) ids.Add((long)reader[0]);
         }

         // Close the connection to database
         ORMEntity<T>.Disconnect();

         // Get all instances
         foreach (long id in ids)
         {
            if (!ORMEntity<T>.InMemoryTable.ContainsKey(id))
            {
               T instance = ORMEntity<T>.Get(id);
               list.Add(instance);
            }
            else
            {
               list.Add(ORMEntity<T>.InMemoryTable[id]);
            }
         }

         return list;
      }

      /// <summary>
      /// Get the specified instance of the type.
      /// </summary>
      /// <param name="id">Instance primary key.</param>
      /// <returns>The specified instance.</returns>
      private static ICollection<T> ReadRecords(string propertyName, object value, bool closeConnection = true)
      {
         List<long> ids = new List<long>();
         List<T> list = new List<T>();
         ORMSqlCommand cmd = ORMEntity<T>.SqlDialect.GetSelectByFieldCommand(propertyName);

         // Connecto to database
         ORMEntity<T>.Connect();

         // Set filter parameter
         ORMEntity<T>.SetParameter(cmd.Parameters[0], value);

         // Execute the SELECT sentence to retrieve the instance properties
         using (DbDataReader reader = ORMEntity<T>.ExecuteReader(cmd.SqlCommand))
         {
            while (reader.Read()) ids.Add((long)reader[0]);
         }

         // Close the connection to database
         if (closeConnection) ORMEntity<T>.Disconnect();

         // Get all instances
         foreach (long id in ids)
         {
            if (!ORMEntity<T>.InMemoryTable.ContainsKey(id))
            {
               T instance = ORMEntity<T>.Get(id, closeConnection);
               list.Add(instance);
            }
            else
            {
               list.Add(ORMEntity<T>.InMemoryTable[id]);
            }
         }

         return list;
      }

      /// <summary>
      /// Get the specified instance of the type.
      /// </summary>
      /// <param name="id">Instance primary key.</param>
      /// <returns>The specified instance.</returns>
      private static ICollection<T> ReadQueryRecords(string sql, bool closeConnection = true)
      {
         List<long> ids = new List<long>();
         List<T> list = new List<T>();
         ORMSqlCommand cmd = ORMEntity<T>.SqlDialect.GetSelectByQuery(sql);

         // Connecto to database
         ORMEntity<T>.Connect();

         // Execute the SELECT sentence to retrieve the instance properties
         using (DbDataReader reader = ORMEntity<T>.ExecuteReader(cmd.SqlCommand))
         {
            while (reader.Read()) ids.Add((long)reader[0]);
         }

         // Close the connection to database
         if (closeConnection) ORMEntity<T>.Disconnect();

         // Get all instances
         foreach (long id in ids)
         {
            if (!ORMEntity<T>.InMemoryTable.ContainsKey(id))
            {
               T instance = ORMEntity<T>.Get(id, closeConnection);
               list.Add(instance);
            }
            else
            {
               list.Add(ORMEntity<T>.InMemoryTable[id]);
            }
         }

         return list;
      }

      /// <summary>
      /// Maps the database readed data into a new instance.
      /// </summary>
      private static T MapData(Type type, DbDataReader reader)
      {
         object value;

         try
         {
            // Create the new instance
            T instance = (T)Activator.CreateInstance(typeof(T), new object[] { });

            // Add primary key
            ORMEntity<T>.ORMStructure.PrimaryKey.SetValue(instance, reader);

            // After object is identified, add it to the memory table
            ORMEntity<T>.AddInMemoryTable(((ORMIdentifiableEntity)instance).ID, instance);

            foreach (ORMEntityMember member in ORMEntity<T>.ORMStructure)
            {
               value = null;

               if (member.IsForeignField)
               {
                  value = member.GetReaderValue(instance, reader);
                  member.SetValue(instance, value);
               }
               else if (member.IsForeignCollection)
               {
                  value = ORMEntity<T>.GetORMForeignCollection(member, instance);
                  member.SetValue(instance, value);
               }
               else
               {
                  member.SetValue(instance, reader);
               }
            }

            return instance;
         }
         catch (Exception ex)
         {
            Logger.LogError(ex);
            throw ex;
         }
      }

      private static object GetORMForeignCollection(ORMEntityMember member, object instance)
      {
         // Get the unique identifier
         long id = (long)ORMEntity<T>.ORMStructure.GetPrimaryKeyValue(instance);
         if (id <= 0) return null;

         // Get the method GET(long)
         Type at = typeof(ORMEntity<>).MakeGenericType(member.ForeignCollectionType);
         MethodInfo methodInfo = at.GetMethod("FindBy", new Type[] { typeof(String), typeof(Int64), typeof(Boolean) });

         // Invoke the method
         object dummy = Activator.CreateInstance(member.ForeignCollectionType);
         return methodInfo.Invoke(dummy, new object[] { member.ForeignCollectionMember.Property.Name, id, false });
      }

      /// <summary>
      /// Get all <see cref="ORMProperty"/> corresponding to the type properties marked as a foreign collections.
      /// </summary>
      /// <param name="type">Type of class for which we're getting the properties.</param>
      /// <returns>The requested list of attributes or an empty array if the table doesn't have any marked property as a foreign collection.</returns>
      private static List<Int64> GetForeignCollectionIdentifiers(object instance, ORMEntityMember member)
      {
         List<Int64> identifiers = new List<Int64>();

         if (member.Property != null)
         {
            object collectionValue = (IEnumerable<ORMIdentifiableEntity>)member.Property.GetValue(instance);
            if (collectionValue != null)
            {
               foreach (var fValue in (IEnumerable<ORMIdentifiableEntity>)member.Property.GetValue(instance))
               {
                  identifiers.Add(fValue.ID);
               }
            }
         }

         return identifiers;
      }

      /// <summary>
      /// Get the primary key value of an ORM instance.
      /// </summary>
      private static long GetPrimaryKeyValue(object instance)
      {
         foreach (PropertyInfo pk in instance.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(ORMPrimaryKey), false)))
         {
            return (long)pk.GetValue(instance);
         }

         return -1;
      }

      #endregion

   }
}
