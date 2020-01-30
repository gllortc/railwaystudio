using Rwm.Otc.Data.ORM;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Rwm.Otc.Data
{
   /// <summary>
   /// Base class to develop persistence managers for database entities.
   /// </summary>
   public abstract class DataManager<T> : DataConsumer
   {

      #region Properties

      private Dictionary<long, object> InMemoryTable { get; set; }

      private ORMCommand SqlSelectByPrimaryKey { get; set; }

      private ORMCommand SqlUpdate { get; set; }

      private ORMCommand SqlInsert { get; set; }

      private ORMCommand SqlDelete { get; set; } 

      #endregion

      #region Methods

      /// <summary>
      /// Adds a new instance into the database table.
      /// </summary>
      /// <param name="instance">The instance to add.</param>
      public virtual void Add(T instance) { }

      /// <summary>
      /// Update an existing instance.
      /// </summary>
      /// <param name="instance">The instance to update.</param>
      public virtual void Update(T instance) { }

      /// <summary>
      /// Save an instance into the database.
      /// </summary>
      /// <param name="instance">Instance to save.</param>
      public virtual long Save(T instance)
      {
         // Check if the instance is in memory
         if (this.InMemoryTable == null)
         {
            this.InMemoryTable = new Dictionary<long, object>();
         }

         // Check if is new object (ID <= 0)
         long id = this.GetPrimaryKeyValue(instance);

         if (id <= 0)
            // Create the new instance into DB
            return InsertDatabaseRecord(instance);
         else
            // Update the instance into DB
            return UpdateDatabaseRecord(instance);
      }

      /// <summary>
      /// Delete an existing instance.
      /// </summary>
      /// <param name="id">Instance unique identifier (DB).</param>
      public int Delete(Int32 id)
      {
         return this.Delete((Int64)id);
      }

      /// <summary>
      /// Delete an existing instance.
      /// </summary>
      /// <param name="id">Instance unique identifier (DB).</param>
      public virtual int Delete(Int64 id) 
      {
         // Check if the instance is in memory
         if (this.InMemoryTable == null)
         {
            this.InMemoryTable = new Dictionary<long, object>();
         }

         return this.DeleteDatabaseRecord(id);
      }

      /// <summary>
      /// Get the requested instance.
      /// </summary>
      /// <param name="id">Instance unique identifier (DB).</param>
      /// <returns>The requested instance or <c>null</c> if the instance cannot be found.</returns>
      public T GetByID(Int32 id)
      {
         return GetByID((Int64)id);
      }

      /// <summary>
      /// Get the requested instance.
      /// </summary>
      /// <param name="id">Instance unique identifier (DB).</param>
      /// <returns>The requested instance or <c>null</c> if the instance cannot be found.</returns>
      public virtual T GetByID(Int64 id)
      {
         T instance = default(T);

         // Check if the instance is in memory
         if (this.InMemoryTable == null)
         {
            this.InMemoryTable = new Dictionary<long, object>();
         }

         // Check if the instance is in memory
         if (this.InMemoryTable.ContainsKey(id))
         {
            instance = (T)this.InMemoryTable[id];
         }
         else
         {
            instance = this.ReadFromDatabase(id);

            // Store instance in memory database
            this.InMemoryTable.Add(id, instance);
         }

         return instance;
      }

      /// <summary>
      /// Gets all instances.
      /// </summary>
      /// <returns>The requested list of instances.</returns>
      public virtual IEnumerable<T> GetAll()
      {
         return new List<T>();
      }

      /// <summary>
      /// Read an instance from the database readed data.
      /// </summary>
      public abstract T ReadEntityRecord(SQLiteDataReader reader);

      #endregion

      #region Private Members

      /// <summary>
      /// Get the specified instance of the type.
      /// </summary>
      /// <param name="id">Instance primary key.</param>
      /// <returns>The specified instance.</returns>
      private T ReadFromDatabase(long id)
      {
         T instance = default(T);

         // Get the SQL sentence
         if (this.SqlSelectByPrimaryKey == null)
         {
            this.SqlSelectByPrimaryKey = ORMSqlManager<T>.GetSelectCommand(typeof(T));
         }

         // Connecto to database
         this.Connect();

         // Set command parameters
         this.SetParameter(this.SqlSelectByPrimaryKey.Parameters[0].FieldName, id);

         // Execute the SELECT sentence to retrieve the instance properties
         using (SQLiteDataReader reader = this.ExecuteReader(this.SqlSelectByPrimaryKey.SqlCommand))
         {
            if (reader.Read())
            {
               instance = this.MapData(typeof(T), reader);
            }
         }

         // Close the connection to database
         this.Disconnect();

         return instance;
      }

      /// <summary>
      /// Update an existing database record.
      /// </summary>
      /// <param name="instance">Instance to update.</param>
      /// <returns>The instance unique identifier.</returns>
      private long UpdateDatabaseRecord(T instance)
      {
         // Get the SQL sentence
         if (this.SqlUpdate == null)
         {
            this.SqlUpdate = ORMSqlManager<T>.GetUpdateCommand(typeof(T));
         }

         // Connecto to database
         this.Connect();

         // Set command parameters
         foreach (ORMProperty param in this.SqlUpdate.Parameters)
         {
            this.SetParameter(param.FieldName, this.GetPropertyValue(param, instance));
         }

         // Execute the SELECT sentence to retrieve the instance properties
         this.ExecuteNonQuery(this.SqlUpdate.SqlCommand);

         // Close the connection to database
         this.Disconnect();

         return this.GetPrimaryKeyValue(instance);
      }

      /// <summary>
      /// Create a new instance into database.
      /// </summary>
      /// <param name="instance">Instance to create.</param>
      /// <returns>The instance unique identifier.</returns>
      private long InsertDatabaseRecord(T instance)
      {
         long id = 0;

         // Get the SQL sentence
         if (this.SqlInsert == null)
         {
            this.SqlInsert = ORMSqlManager<T>.GetInsertCommand(typeof(T));
         }

         // Connecto to database
         this.Connect();

         // Set command parameters
         foreach (ORMProperty param in this.SqlInsert.Parameters)
         {
            this.SetParameter(param.FieldName, this.GetPropertyValue(param, instance));
         }

         // Execute the SELECT sentence to retrieve the instance properties
         this.ExecuteNonQuery(this.SqlInsert.SqlCommand);

         // Get the generated new record unique identifier
         id = this.ExecuteScalar("select max(" + this.GetPrimaryKey(instance).FieldName + ") from " + this.GetTableName(instance));
         this.SetPrimaryKeyValue(instance, id);

         // Close the connection to database
         this.Disconnect();

         // Created project is added to in-memory table
         this.InMemoryTable.Add(id, instance);

         return this.GetPrimaryKeyValue(instance);
      }

      /// <summary>
      /// Delete an existing instance from database.
      /// </summary>
      /// <param name="instance">Instance unique identifier.</param>
      private int DeleteDatabaseRecord(long id)
      {
         int rowsAffected = 0;

         // Get the SQL sentence
         if (this.SqlDelete == null)
         {
            this.SqlDelete = ORMSqlManager<T>.GetDeleteCommand();
         }

         // Connecto to database
         this.Connect();

         // Set command parameters
         foreach (ORMProperty param in this.SqlDelete.Parameters)
         {
            this.SetParameter(param.FieldName, id);
         }

         // Execute the SQL command
         rowsAffected = this.ExecuteNonQuery(this.SqlDelete.SqlCommand);

         // Close the connection to database
         this.Disconnect();

         // Delete the instance from in-memory database
         if (this.InMemoryTable.ContainsKey(id))
            this.InMemoryTable.Remove(id);

         return rowsAffected;
      }

      private T MapData(Type type, SQLiteDataReader reader)
      {
         T instance = (T)Activator.CreateInstance(typeof(T), new object[] { });

         foreach (var prop in type.GetProperties())
         {
            this.SetValue(instance, prop, reader);
         }

         return instance;
      }

      private void SetValue(object instance, PropertyInfo propertyInfo, SQLiteDataReader reader)
      {
         ORMProperty[] props = (ORMProperty[])propertyInfo.GetCustomAttributes(typeof(ORMProperty), false);
         if (props.Length > 0)
         {
            if (propertyInfo.PropertyType == typeof(String))
            {
               propertyInfo.SetValue(instance, reader.GetString(reader.GetOrdinal(props[0].FieldName)));
            }
            else if (propertyInfo.PropertyType == typeof(Boolean))
            {
               propertyInfo.SetValue(instance, (Int64)reader[props[0].FieldName] > 0 ? true : false);
            }
            else if (propertyInfo.PropertyType == typeof(Int32))
            {
               propertyInfo.SetValue(instance, reader.GetInt32(reader.GetOrdinal(props[0].FieldName)));
            }
            else if (propertyInfo.PropertyType == typeof(Int64))
            {
               propertyInfo.SetValue(instance, reader.GetInt64(reader.GetOrdinal(props[0].FieldName)));
            }
            else if (propertyInfo.PropertyType == typeof(Decimal))
            {
               propertyInfo.SetValue(instance, reader.GetDecimal(reader.GetOrdinal(props[0].FieldName)));
            }
            else if (propertyInfo.PropertyType == typeof(Double))
            {
               propertyInfo.SetValue(instance, reader.GetDouble(reader.GetOrdinal(props[0].FieldName)));
            }
            else if (propertyInfo.PropertyType == typeof(DateTime))
            {
               if (reader[props[0].FieldName].GetType() != typeof(System.DBNull))
                  propertyInfo.SetValue(instance, reader.GetDateTime(reader.GetOrdinal(props[0].FieldName)));
               else
                  propertyInfo.SetValue(instance, DateTime.MinValue);
            }
            else if (propertyInfo.PropertyType.IsEnum)
            {
               string enumName = Enum.GetName(propertyInfo.PropertyType, reader[props[0].FieldName]);
               propertyInfo.SetValue(instance, Enum.Parse(propertyInfo.PropertyType, enumName));
            }
            else if (propertyInfo.PropertyType == typeof(Image))
            {
               if (reader[props[0].FieldName].GetType() != typeof(System.DBNull))
                  propertyInfo.SetValue(instance, Image.FromStream(reader.GetStream(reader.GetOrdinal(props[0].FieldName))));
            }
            else if (propertyInfo.PropertyType.BaseType == typeof(Stream))
            {
               // TODO: File PROPERTIES
               //if (reader[props[0].FieldName].GetType() != typeof(System.DBNull))
               //   propertyInfo.SetValue(instance, reader.GetStream(reader.GetOrdinal(props[0].FieldName)));
            }
            else if (this.IsOrmInstance(propertyInfo.PropertyType))
            {
               propertyInfo.SetValue(instance, this.GetORMInstance(propertyInfo.PropertyType, 
                                                                   (long)reader[props[0].FieldName]));
            }
            else 
            {
               throw new Exception("Data mapping error: Not supported data type conversion for type " + propertyInfo.PropertyType.FullName);
            }
         }
      }

      private bool IsOrmInstance(Type type)
      {
         ORMTable[] tables = (ORMTable[])type.GetCustomAttributes(typeof(ORMTable), false);
         return (tables.Length > 0);
      }

      private ORMProperty GetPrimaryKey(T instance)
      {
         foreach (var propertyInfo in typeof(T).GetProperties())
         {
            ORMProperty[] props = (ORMProperty[])propertyInfo.GetCustomAttributes(typeof(ORMProperty), false);
            foreach (ORMProperty ormProperty in props)
            {
               if (ormProperty.PrimaryKey) 
                  return ormProperty;
            }
         }

         return null;
      }

      private long GetPrimaryKeyValue(T instance)
      {
         foreach (var propertyInfo in typeof(T).GetProperties())
         {
            ORMProperty[] props = (ORMProperty[])propertyInfo.GetCustomAttributes(typeof(ORMProperty), false);
            foreach (ORMProperty ormProperty in props)
            {
               if (ormProperty.PrimaryKey)
                  return (long)propertyInfo.GetValue(instance);
            }
         }

         return -1;
      }

      private bool SetPrimaryKeyValue(T instance, long value)
      {
         foreach (var propertyInfo in typeof(T).GetProperties())
         {
            ORMProperty[] props = (ORMProperty[])propertyInfo.GetCustomAttributes(typeof(ORMProperty), false);
            foreach (ORMProperty ormProperty in props)
            {
               if (ormProperty.PrimaryKey)
               {
                  propertyInfo.SetValue(instance, value);
                  return true;
               }
            }
         }

         return false;
      }

      private object GetPropertyValue(ORMProperty property, T instance)
      {
         foreach (var propertyInfo in typeof(T).GetProperties())
         {
            ORMProperty[] props = (ORMProperty[])propertyInfo.GetCustomAttributes(typeof(ORMProperty), false);
            foreach (ORMProperty ormProperty in props)
            {
               if (ormProperty.FieldName.Equals(property.FieldName))
                  return propertyInfo.GetValue(instance);
            }
         }

         return -1;
      }

      private string GetTableName(T instance)
      {
         ORMTable[] tables = (ORMTable[])typeof(T).GetCustomAttributes(typeof(ORMTable), false);
         if (tables.Length > 0)
            return tables[0].TableName;

         return null;
      }

      private object GetORMInstance(Type type, long id)
      {
         return null;

         //// Create new instance of the ORM type
         //object instance = Activator.CreateInstance(type);

         //// Invoke the Get method
         //var methodInfo = type.GetMethod("Get", 
         //                                BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static);
         //return methodInfo.Invoke(this, new object[] { id });
      }

      #endregion

   }
}
