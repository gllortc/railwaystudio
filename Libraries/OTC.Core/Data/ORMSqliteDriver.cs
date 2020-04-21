using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Utils;

namespace Rwm.Otc.Data
{
   public class ORMSqliteDriver
   {

      // Internal data declarations
      private static List<SQLiteParameter> parameters;

      #region Enumerations

      public enum CommandType
      {
         Select,
         Insert,
         Update,
         Delete
      }

      #endregion

      #region Constants

      internal static string SQL_REGISTRY_TABLE = "SYS_REGISTRY";
      internal static string SQL_REGISTRY_FIELDS = "key, value";

      /// <summary>Settings key that contains the current project database connection string.</summary>
      public const string SETTINGS_DB_CURRENT = "db.current";

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ORMSqliteDriver"/>.
      /// </summary>
      public ORMSqliteDriver()
      {
         this.DatabaseChecked = false;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the database path (with filename).
      /// </summary>
      public static string DatabaseFile
      {
         get { return OTCContext.Settings.GetString(ORMSqliteDriver.SETTINGS_DB_CURRENT); }
      }

      /// <summary>
      /// Gets the connection string to the current database.
      /// </summary>
      public static string ConnectionString
      {
         get
         {
            if (string.IsNullOrWhiteSpace(ORMSqliteDriver.DatabaseFile))
            {
               return string.Empty;
            }
            else
            {
               return "Data Source=" + ORMSqliteDriver.DatabaseFile + ";Pooling=true;FailIfMissing=false";
            }
         }
      }

      /// <summary>
      /// Gets the database connection.
      /// </summary>
      public static SQLiteConnection Connection { get; private set; }

      /// <summary>
      /// Gets a value indicating if the database structure is checked.
      /// </summary>
      public bool DatabaseChecked { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Create a connection with the database.
      /// </summary>
      public static void Connect()
      {
         try
         {
            if (ORMSqliteDriver.Connection == null || !ORMSqliteDriver.Connection.ConnectionString.Equals(ORMSqliteDriver.ConnectionString))
            {
               ORMSqliteDriver.Connection = new SQLiteConnection(ORMSqliteDriver.ConnectionString);
               ORMSqliteDriver.Connection.Open();
            }
            else if (ORMSqliteDriver.Connection.State == ConnectionState.Closed)
            {
               ORMSqliteDriver.Connection.Open();
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
         finally
         {
            ORMSqliteDriver.parameters = new List<SQLiteParameter>();
         }
      }

      /// <summary>
      /// Close the current opened connection with the database.
      /// </summary>
      public static void Disconnect()
      {
         try
         {
            if (ORMSqliteDriver.Connection == null)
            {
               return;
            }

            ORMSqliteDriver.Connection.Close();
         }
         catch
         {
            // Discard the exceptions
         }
      }

      /// <summary>
      /// Check the database structure and ensure that the structure is created and updated.
      /// </summary>
      public virtual void CheckDatabase()
      {
         return;
      }

      /// <summary>
      /// Sets a parameter for a command execution.
      /// </summary>
      /// <param name="member">ORM member that contains the parameter name (should be the same as database field name).</param>
      /// <param name="value">Parameter value.</param>
      public static void SetParameter(ORMEntityMember member, object value)
      {
         SQLiteParameter sqlParam;

         try
         {
            if (value is Image)
            {
               Image img = value as Image;
               sqlParam = new SQLiteParameter(member.Attribute.FieldName, DbType.Binary);
               sqlParam.Value = (byte[])BinaryUtils.ImageToByteArray(img);
            }
            else if (value is byte[])
            {
               sqlParam = new SQLiteParameter(member.Attribute.FieldName, DbType.Binary, ((byte[])value).Length);
               sqlParam.Value = value;
            }
            else if (ReflectionUtils.IsSubclassOfRawGeneric(typeof(ORMEntity<>), value.GetType()))
            {
               // Get primary key value of the ORMEntity instance
               sqlParam = new SQLiteParameter(member.Attribute.FieldName, ORMSqliteDriver.GetPrimaryKeyValue(value));
            }
            else
            {
               sqlParam = new SQLiteParameter(member.Attribute.FieldName, value);
            }

            ORMSqliteDriver.parameters.Add(sqlParam);
         }
         catch (Exception ex)
         {
            Logger.LogError(ex);
            throw ex;
         }
      }

      /// <summary>
      /// Sets a parameter for a command execution.
      /// </summary>
      /// <param name="name">Parameter name.</param>
      /// <param name="value">parameter value.</param>
      public static void SetParameter(string name, object value)
      {
         ORMSqliteDriver.parameters.Add(new SQLiteParameter(name, value));
      }

      /// <summary>
      /// Execute a query command.
      /// </summary>
      /// <param name="sql">SQL sentence to execute.</param>
      /// <returns>A <see cref="DbDataReader"/> instance for data accessing.</returns>
      public static DbDataReader ExecuteReader(string sql)
      {
         using (SQLiteCommand cmd = new SQLiteCommand(sql, ORMSqliteDriver.Connection))
         {
            ORMSqliteDriver.SetCommandParameters(cmd);

            return cmd.ExecuteReader();
         }
      }

      /// <summary>
      /// Execute a SQL sentence for INSERT, UPDATE or DELETE.
      /// </summary>
      /// <param name="sql">SQL sentence to execute.</param>
      /// <returns>An integer with the number of affected rows.</returns>
      public static int ExecuteNonQuery(string sql)
      {
         using (SQLiteCommand cmd = new SQLiteCommand(sql, ORMSqliteDriver.Connection))
         {
            ORMSqliteDriver.SetCommandParameters(cmd);

            return cmd.ExecuteNonQuery();
         }
      }

      /// <summary>
      /// Execute a query command that returns an integer (<see cref="Int64">/>).
      /// </summary>
      /// <param name="sql">SQL sentence to execute.</param>
      /// <returns>The resulting <see cref="Int64"/> value.</returns>
      public static long ExecuteScalar(string sql)
      {
         using (SQLiteCommand cmd = new SQLiteCommand(sql, ORMSqliteDriver.Connection))
         {
            ORMSqliteDriver.SetCommandParameters(cmd);

            return (long)cmd.ExecuteScalar();
         }
      }

      /// <summary>
      /// Execute a query command that returns an integer (<see cref="Int64"/>).
      /// </summary>
      /// <param name="sql">SQL sentence to execute.</param>
      /// <param name="defaultValue">Returning value when the query doesn't result any value.</param>
      /// <returns>The resulting <see cref="Int64"/> value.</returns>
      public static long ExecuteScalar(string sql, long defaultValue)
      {
         using (SQLiteCommand cmd = new SQLiteCommand(sql, ORMSqliteDriver.Connection))
         {
            ORMSqliteDriver.SetCommandParameters(cmd);

            object res = cmd.ExecuteScalar();
            if (res == null)
            {
               return defaultValue;
            }
            else
            {
               return (long)res;
            }
         }
      }

      public static byte[] ExecuteBlob(string sql)
      {
         using (SQLiteCommand cmd = new SQLiteCommand(sql, ORMSqliteDriver.Connection))
         {
            ORMSqliteDriver.SetCommandParameters(cmd);

            return (byte[])cmd.ExecuteScalar();
         }
      }

      /// <summary>
      /// Execute a query command that returns a single <see cref="String"/> value.
      /// </summary>
      /// <param name="sql">SQL sentence to execute.</param>
      /// <returns>The resulting <see cref="String"/> value.</returns>
      public static string ExecuteString(string sql)
      {
         return ORMSqliteDriver.ExecuteString(sql, string.Empty);
      }

      /// <summary>
      /// Execute a query command that returns a single <see cref="String"/> value.
      /// </summary>
      /// <param name="sql">SQL sentence to execute.</param>
      /// <param name="defaultValue">Returning value when the query doesn't result any value.</param>
      /// <returns>The resulting <see cref="String"/> value.</returns>
      public static string ExecuteString(string sql, string defaultValue)
      {
         using (SQLiteCommand cmd = new SQLiteCommand(sql, ORMSqliteDriver.Connection))
         {
            ORMSqliteDriver.SetCommandParameters(cmd);

            object res = cmd.ExecuteScalar();
            if (res == null)
            {
               return defaultValue;
            }
            else
            {
               return res as string;
            }
         }
      }

      /// <summary>
      /// Execute a query and return the values in a <see cref="DataTable"/> instance.
      /// </summary>
      /// <param name="sql">SQL sentence.</param>
      /// <returns>A <see cref="DataTable"/> instance filled with the query results.</returns>
      public static DataTable ExecuteDataTable(string sql)
      {
         using (SQLiteCommand cmd = new SQLiteCommand(sql, ORMSqliteDriver.Connection))
         {
            ORMSqliteDriver.SetCommandParameters(cmd);

            using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
            {
               System.Data.DataTable dt = new System.Data.DataTable();
               da.Fill(dt);

               return dt;
            }
         }
      }

      public void AddRegistryValue(string key, DateTime value)
      {
         SetProperty(key, value.ToString("yyyyMMdd hh:mm:ss"));
      }

      public void AddRegistryValue(string key, bool value)
      {
         SetProperty(key, value ? "1" : "0");
      }

      public void AddRegistryValue(string key, int value)
      {
         SetProperty(key, value.ToString());
      }

      public void SetProperty(string key, string value)
      {
         Int64 nRows;

         try
         {
            Connect();

            string sql = @"SELECT 
                               Count(*) 
                           FROM 
                               " + ORMSqliteDriver.SQL_REGISTRY_TABLE + @" 
                           WHERE
                               key = @key";
            parameters.Add(new SQLiteParameter("key", key));
            nRows = ExecuteScalar(sql);

            if (nRows <= 0)
            {
               sql = @"INSERT INTO 
                           " + ORMSqliteDriver.SQL_REGISTRY_TABLE + @" (" + ORMSqliteDriver.SQL_REGISTRY_FIELDS + @") 
                       VALUES 
                           (@key, @value)";
            }
            else
            {
               sql = @"UPDATE 
                           " + ORMSqliteDriver.SQL_REGISTRY_TABLE + @" 
                       SET 
                           value = @value 
                       WHERE 
                           key = @key";
            }

            parameters.Add(new SQLiteParameter("key", key));
            parameters.Add(new SQLiteParameter("value", value));

            ExecuteNonQuery(sql);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Get registry property.
      /// </summary>
      /// <param name="key">Value key.</param>
      /// <returns>The value associated to the specified key.</returns>
      public string GetPropertyString(string key)
      {
         return this.GetPropertyString(key, string.Empty);
      }

      /// <summary>
      /// Get registry property.
      /// </summary>
      /// <param name="key">Value key.</param>
      /// <param name="defaultValue">Default value.</param>
      /// <returns>The value associated to the specified key.</returns>
      public string GetPropertyString(string key, string defaultValue)
      {
         try
         {
            Connect();

            string sql = @"SELECT 
                               value 
                           FROM 
                               " + ORMSqliteDriver.SQL_REGISTRY_TABLE + @" 
                           WHERE
                               key = @key";

            parameters.Add(new SQLiteParameter("key", key));

            string value = ExecuteString(sql);
            return (string.IsNullOrWhiteSpace(value) ? defaultValue : value);
         }
         catch
         {
            return defaultValue;
         }
         finally
         {
            Disconnect();
         }
      }

      public int GetPropertyInteger(string key, int defaultValue)
      {
         string value = GetPropertyString(key);

         if (int.TryParse(value, out int result))
         {
            return result;
         }
         else
         {
            return defaultValue;
         }
      }

      /// <summary>
      /// Create table if not exists.
      /// </summary>
      /// <param name="tableName">Table name.</param>
      /// <param name="sql">SQL sentence to create the table.</param>
      public void CreateTable(string tableName, string ddl)
      {
         try
         {
            Connect();

            string sql = @"SELECT 
                               Count(name)
                           FROM 
                               sqlite_master 
                           WHERE 
                               type = 'table' And 
                               name = @name;";
            parameters.Add(new SQLiteParameter("name", tableName));

            if (ExecuteScalar(sql) <= 0)
            {
               ExecuteNonQuery(ddl);
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
         }
         finally
         {
            Disconnect();
         }
      }

      public void BeginTransaction()
      {
         // Not supported by SQLite
      }

      public void Commit()
      {
         // Not supported by SQLite
      }

      public void Rollback()
      {
         // Not supported by SQLite
      }

      #endregion

      #region Static Members

      public static string GetConnectionString(XmlSettingsManager settings)
      {
         return GetConnectionString(settings.GetString(ORMSqliteDriver.SETTINGS_DB_CURRENT));
      }

      public static string GetConnectionString(string filename)
      {
         return "Data Source=" + filename + ";Pooling=true;FailIfMissing=false";
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Set parameters to a SQL command.
      /// </summary>
      private static void SetCommandParameters(SQLiteCommand cmd)
      {
         cmd.Parameters.Clear();

         foreach (SQLiteParameter param in parameters)
         {
            cmd.Parameters.Add(param);
         }

         parameters.Clear();
      }

      /// <summary>
      /// Get the primary key value of an ORM instance.
      /// </summary>
      private static long GetPrimaryKeyValue(object instance)
      {
         foreach (System.Reflection.PropertyInfo pk in instance.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(ORMPrimaryKey), false)))
         {
            return (long)pk.GetValue(instance);
         }

         return -1;
      }

      #endregion

   }
}
