using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Reflection;

namespace Rwm.Otc.Data.ORM
{
   public abstract class PersistentEntity<T> : DataManager<T>
   {

      #region Fields

      // Internal data declarations
      private static List<SQLiteParameter> parameters;
      private static Dictionary<long, object> database;

      #endregion

      #region Properties

      /// <summary>
      /// Gets the database connection.
      /// </summary>
      private static SQLiteConnection Connection { get; set; }

      /// <summary>
      /// Gets the database path (with filename).
      /// </summary>
      private static string DatabaseFile
      {
         get { return OTCContext.Settings.GetString(DataManager<T>.SETTINGS_DB_CURRENT); }
      }

      /// <summary>
      /// Gets the connection string to the current database.
      /// </summary>
      private static string ConnectionString
      {
         get
         {
            if (string.IsNullOrWhiteSpace(PersistentEntity<T>.DatabaseFile))
            {
               return string.Empty;
            }
            else
            {
               return "Data Source=" + PersistentEntity<T>.DatabaseFile + ";Pooling=true;FailIfMissing=false";
            }
         }
      }

      private static string[] SqlSelectByPrimaryKey { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Get the specified instance of the type.
      /// </summary>
      /// <param name="id">Instance primary key.</param>
      /// <returns>The specified instance.</returns>
      public static T Get(long id)
      {
         T      instance  = default(T);
         String tableName = ORMSqlManager<T>.GetTypeTableName();

         // Check if the instance is in memory
         if (PersistentEntity<T>.database == null)
            PersistentEntity<T>.database = new Dictionary<long, object>();
         if (PersistentEntity<T>.database.ContainsKey(id))
            return (T)PersistentEntity<T>.database[id];

         // Get the SQL sentence
         if (PersistentEntity<T>.SqlSelectByPrimaryKey == null)
         {
            // PersistentEntity<T>.SqlSelectByPrimaryKey = ORMSqlManager<T>.SelectByPrimaryKey(typeof(T));
         }

         // Connecto to database
         PersistentEntity<T>.Connect();

         //PersistentEntity<T>.

         //// Execute the SELECT sentence to retrieve the instance properties
         //using (SQLiteDataReader reader = ExecuteReader(PersistentEntity<T>.SqlSelectByPrimaryKey))
         //{
         //   if (reader.Read())
         //   {
         //      instance = PersistentEntity<T>.MapData(typeof(T), reader);
         //   }
         //}

         // Close the connection to database
         PersistentEntity<T>.Disconnect();

         // Store instance in memory database
         PersistentEntity<T>.database.Add(id, instance);

         return instance;
      }

      public void Save()
      {

      }

      #endregion

      #region Static methods

      /// <summary>
      /// Create a connection with the database.
      /// </summary>
      private static void Connect()
      {
         try
         {
            if (PersistentEntity<T>.Connection == null || !PersistentEntity<T>.Connection.ConnectionString.Equals(PersistentEntity<T>.ConnectionString))
            {
               PersistentEntity<T>.Connection = new SQLiteConnection(PersistentEntity<T>.ConnectionString);
               PersistentEntity<T>.Connection.Open();
            }
            else if (PersistentEntity<T>.Connection.State == ConnectionState.Closed)
            {
               PersistentEntity<T>.Connection.Open();
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
         finally
         {
            PersistentEntity<T>.parameters = new List<SQLiteParameter>();
         }
      }

      /// <summary>
      /// Close the current opened connection with the database.
      /// </summary>
      private static void Disconnect()
      {
         try
         {
            if (PersistentEntity<T>.Connection == null)
            {
               return;
            }

            PersistentEntity<T>.Connection.Close();
         }
         catch
         {
            // Discard the exceptions
         }
      }

      private static SQLiteDataReader ExecuteReader(string sql)
      {
         using (SQLiteCommand cmd = new SQLiteCommand(sql, PersistentEntity<T>.Connection))
         {
            PersistentEntity<T>.SetCommandParameters(cmd);

            return cmd.ExecuteReader();
         }
      }

      /// <summary>
      /// Set parameters to a SQL command.
      /// </summary>
      private static void SetCommandParameters(SQLiteCommand cmd)
      {
         cmd.Parameters.Clear();

         foreach (SQLiteParameter param in PersistentEntity<T>.parameters)
         {
            cmd.Parameters.Add(param);
         }

         PersistentEntity<T>.parameters.Clear();
      }

      public static T MapData(Type type, SQLiteDataReader reader)
      {
         T instance = (T)Activator.CreateInstance(typeof(T), new object[] { });

         foreach (var prop in type.GetProperties())
         {
            PersistentEntity<T>.SetValue(instance, prop, reader);
         }

         return instance;
      }

      private static void SetValue(object instance, PropertyInfo propertyInfo, SQLiteDataReader reader)
      {
         ORMProperty[] props = (ORMProperty[])propertyInfo.GetCustomAttributes(typeof(ORMProperty), false);
         if (props.Length > 0)
         {
            if (PersistentEntity<T>.IsOrmInstance(propertyInfo.PropertyType))
            {
               //var methodInfo = propertyInfo.PropertyType.GetMethod("Get", System.Reflection.BindingFlags.FlattenHierarchy
               //                                                            | System.Reflection.BindingFlags.Public
               //                                                            | System.Reflection.BindingFlags.Static);
               //methodInfo.Invoke(this, new object[] { (long)reader[props[0].FieldName] });


               //PersistentEntity<T> refInstance = (PersistentEntity<T>)Activator.CreateInstance(propertyInfo.PropertyType, new object[] { });
               //propertyInfo.SetValue(refInstance, PersistentEntity<T>.Get((long)reader[props[0].FieldName]));
            }
            else
            {
               propertyInfo.SetValue(instance, reader[props[0].FieldName]);
            }
         }

         propertyInfo.SetValue(instance, reader[props[0].FieldName]);
      }

      private static bool IsOrmInstance(Type type)
      {
         ORMTable[] tables = (ORMTable[])type.GetCustomAttributes(typeof(ORMTable), false);
         return (tables.Length > 0);
      }

      #endregion

   }
}
