using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;

namespace Rwm.Otc.Data
{
   [Obsolete]
   public class DataConsumer
   {
      // Internal data declarations
      private List<SQLiteParameter> parameters;

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

      internal static string SQL_REGISTRY_TABLE = "sysregistry";
      internal static string SQL_REGISTRY_FIELDS = "key, value";

      /// <summary>Settings key that contains the current project database connection string.</summary>
      public const string SETTINGS_DB_CURRENT = "db.current";

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="DataConsumer"/>.
      /// </summary>
      public DataConsumer()
      {
         this.DatabaseChecked = false;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the database path (with filename).
      /// </summary>
      public string DatabaseFile
      {
         get { return OTCContext.Settings.GetString(DataConsumer.SETTINGS_DB_CURRENT); }
      }

      /// <summary>
      /// Gets the connection string to the current database.
      /// </summary>
      public string ConnectionString
      {
         get
         {
            if (string.IsNullOrWhiteSpace(this.DatabaseFile))
            {
               return string.Empty;
            }
            else
            {
               return "Data Source=" + this.DatabaseFile + ";Pooling=true;FailIfMissing=false";
            }
         }
      }

      /// <summary>
      /// Gets the database connection.
      /// </summary>
      public SQLiteConnection Connection { get; private set; }

      /// <summary>
      /// Gets a value indicating if the database structure is checked.
      /// </summary>
      public bool DatabaseChecked { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Create a connection with the database.
      /// </summary>
      public void Connect()
      {
         try
         {
            if (this.Connection == null || !this.Connection.ConnectionString.Equals(this.ConnectionString))
            {
               this.Connection = new SQLiteConnection(this.ConnectionString);
               this.Connection.Open();
            }
            else if (this.Connection.State == ConnectionState.Closed)
            {
               this.Connection.Open();
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
         finally
         {
            this.parameters = new List<SQLiteParameter>();
         }
      }

      /// <summary>
      /// Close the current opened connection with the database.
      /// </summary>
      public void Disconnect()
      {
         try
         {
            if (this.Connection == null)
            {
               return;
            }

            this.Connection.Close();
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

      public void SetParameter(string varName, object value)
      {
         if (value is System.Drawing.Image)
         {
            Image img = value as Image;

            SQLiteParameter parameter = new SQLiteParameter(varName, System.Data.DbType.Binary);
            parameter.Value = ImageToByte(img, img.RawFormat);

            this.parameters.Add(parameter);
         }
         else if (value is byte[])
         {
            SQLiteParameter param = new SQLiteParameter(varName, DbType.Binary, ((byte[])value).Length);
            param.Value = value;

            this.parameters.Add(param);
         }
         else
         {
            this.parameters.Add(new SQLiteParameter(varName, value));
         }
      }

      public SQLiteDataReader ExecuteReader(string sql)
      {
         using (SQLiteCommand cmd = new SQLiteCommand(sql, this.Connection))
         {
            SetCommandParameters(cmd);

            return cmd.ExecuteReader();
         }
      }

      public int ExecuteNonQuery(string sql)
      {
         using (SQLiteCommand cmd = new SQLiteCommand(sql, this.Connection))
         {
            SetCommandParameters(cmd);

            return cmd.ExecuteNonQuery();
         }
      }

      public long ExecuteScalar(string sql)
      {
         using (SQLiteCommand cmd = new SQLiteCommand(sql, this.Connection))
         {
            SetCommandParameters(cmd);

            return (long)cmd.ExecuteScalar();
         }
      }

      public long ExecuteScalar(string sql, long defaultValue)
      {
         object res = null;

         using (SQLiteCommand cmd = new SQLiteCommand(sql, this.Connection))
         {
            SetCommandParameters(cmd);

            res = cmd.ExecuteScalar();
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

      public byte[] ExecuteBlob(string sql)
      {
         using (SQLiteCommand cmd = new SQLiteCommand(sql, this.Connection))
         {
            SetCommandParameters(cmd);

            return (byte[])cmd.ExecuteScalar();
         }
      }

      public string ExecuteString(string sql)
      {
         return ExecuteString(sql, string.Empty);
      }

      public string ExecuteString(string sql, string defaultValue)
      {
         object res = null;

         using (SQLiteCommand cmd = new SQLiteCommand(sql, this.Connection))
         {
            SetCommandParameters(cmd);

            res = cmd.ExecuteScalar();
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
      /// Execute a query and return the values in a <see cref="System.Data.DataTable"/> instance.
      /// </summary>
      /// <param name="sql">SQL sentence.</param>
      /// <returns>A <see cref="System.Data.DataTable"/> instance filled with the query results.</returns>
      public System.Data.DataTable ExecuteDataTable(string sql)
      {
         using (SQLiteCommand cmd = new SQLiteCommand(sql, this.Connection))
         {
            SetCommandParameters(cmd);

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
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"SELECT 
                        Count(*) 
                    FROM 
                        " + DataConsumer.SQL_REGISTRY_TABLE + @" 
                    WHERE
                        key = @key";

            SetParameter("key", key);
            nRows = ExecuteScalar(sql);

            if (nRows <= 0)
            {
               sql = @"INSERT INTO 
                           " + DataConsumer.SQL_REGISTRY_TABLE + @" (" + DataConsumer.SQL_REGISTRY_FIELDS + @") 
                       VALUES 
                           (@key, @value)";
            }
            else
            {
               sql = @"UPDATE 
                           " + DataConsumer.SQL_REGISTRY_TABLE + @" 
                       SET 
                           value = @value 
                       WHERE 
                           key = @key";
            }

            SetParameter("key", key);
            SetParameter("value", value);

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
         string sql = string.Empty;
         string value = string.Empty;

         try
         {
            Connect();

            sql = @"SELECT 
                        value 
                    FROM 
                        " + DataConsumer.SQL_REGISTRY_TABLE + @" 
                    WHERE
                        key = @key";

            SetParameter("key", key);

            value = ExecuteString(sql);

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
         int result;
         string value = GetPropertyString(key);

         if (int.TryParse(value, out result))
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
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"SELECT 
                        Count(name)
                    FROM 
                        sqlite_master 
                    WHERE 
                        type = 'table' And 
                        name = @name;";

            SetParameter("name", tableName);

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
         return GetConnectionString(settings.GetString(DataConsumer.SETTINGS_DB_CURRENT));
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
      private void SetCommandParameters(SQLiteCommand cmd)
      {
         cmd.Parameters.Clear();

         foreach (SQLiteParameter param in parameters)
         {
            cmd.Parameters.Add(param);
         }

         parameters.Clear();
      }

      private static string ImageToByte(Image image, System.Drawing.Imaging.ImageFormat format)
      {
         using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
         {
            // Convert Image to byte[]
            image.Save(ms, format);
            byte[] imageBytes = ms.ToArray();

            // Convert byte[] to Base64 String
            return Convert.ToBase64String(imageBytes);
         }
      }

      #endregion

   }
}
