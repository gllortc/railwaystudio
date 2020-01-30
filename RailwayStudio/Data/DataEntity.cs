using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Rwm.collection.Data
{
   public class DataEntity
   {
      // Internal data declarations
      private List<SQLiteParameter> parameters;
      private string sqlSentence;
      private CommandType sqlType;

      /// <summary>Database current version.</summary>
      public const string DB_CURRENT_VERSION = "3.5";

      /// <summary>Database version 3.5</summary>
      public const string DB_VERSION_3_5 = DB_CURRENT_VERSION;
      /// <summary>Database version 1.0</summary>
      public const string DB_VERSION_1_0 = "1.0";

      #region Enumerations

      public enum CommandType
      {
         Select,
         Insert,
         Update,
         Delete
      }

      #endregion

      #region Properties

      public string DatabasePath
      {
         get { return Path.Combine(Application.StartupPath, "data"); }
      }

      public string DatabaseFile
      {
         get { return Path.Combine(Path.Combine(Application.StartupPath, "data"), "rwmrc.db"); }
      }

      public string ConnectionString
      {
         get { return "Data Source=" + this.DatabaseFile + ";Pooling=true;FailIfMissing=false"; }
      }

      public string DatabaseVersion
      {
         get { return GetDatabaseVersion(); }
      }

      public SQLiteConnection Connection { get; private set; }

      #endregion

      #region Methods

      public void Connect()
      {
         try
         {
            if (this.Connection == null)
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
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            this.parameters = new List<SQLiteParameter>();
         }
      }

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

      public void SetParameter(string varName, object value)
      {
         if (value is System.Drawing.Image)
         {
            Image img = value as Image;

            SQLiteParameter parameter = new SQLiteParameter(varName, System.Data.DbType.Binary);
            parameter.Value = SQLiteHelper.ImageToByte(img, img.RawFormat);

            this.parameters.Add(parameter);
         }
         else
         {
            this.parameters.Add(new SQLiteParameter(varName, value));
         }
      }

      public void SetCommand(string sql, CommandType type)
      {
         sqlType = type;
         sqlSentence = sql;
      }

      public SQLiteDataReader ExecuteReader(string sql)
      {
         using (SQLiteCommand cmd = new SQLiteCommand(sqlSentence, this.Connection))
         {
            cmd.CommandText = sql;

            foreach (SQLiteParameter param in parameters)
            {
               cmd.Parameters.Add(param);
            }

            return cmd.ExecuteReader();
         }
      }

      public void ExecuteNonQuery(string sql)
      {
         using (SQLiteCommand cmd = new SQLiteCommand(sqlSentence, this.Connection))
         {
            cmd.CommandText = sql;

            foreach (SQLiteParameter param in parameters)
            {
               cmd.Parameters.Add(param);
            }

            cmd.ExecuteNonQuery();
         }
      }

      public long ExecuteScalar(string sql)
      {
         using (SQLiteCommand cmd = new SQLiteCommand(sqlSentence, this.Connection))
         {
            cmd.CommandText = sql;

            foreach (SQLiteParameter param in parameters)
            {
               cmd.Parameters.Add(param);
            }

            return (long)cmd.ExecuteScalar();
         }
      }

      public System.Data.DataTable ExecuteDataTable(string sql)
      {
         using (SQLiteCommand cmd = new SQLiteCommand(sqlSentence, this.Connection))
         {
            cmd.CommandText = sql;

            foreach (SQLiteParameter param in parameters)
            {
               cmd.Parameters.Add(param);
            }

            using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
            {
               System.Data.DataTable dt = new System.Data.DataTable();
               da.Fill(dt);

               return dt;
            }
         }
      }

      /// <summary>
      /// Ensure that the database exist and is compatible with the latest version.
      /// </summary>
      public void CheckDatabase()
      {
         string currentDbVer = string.Empty;
         string sql = string.Empty;

         try
         {
            if (!Directory.Exists(this.DatabasePath))
            {
               Directory.CreateDirectory(this.DatabasePath);
            }

            if (!File.Exists(this.DatabaseFile))
            {
               SQLiteConnection.CreateFile(this.DatabaseFile);
               Update_V1_0();
            }

            currentDbVer = GetDatabaseVersion();
            if (GetDatabaseVersion().CompareTo(DB_VERSION_3_5) < 0) Update_V3_5();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      #endregion

      #region Private Members

      private string GetDatabaseVersion()
      {
         string sql = string.Empty;

         try
         {
            using (SQLiteConnection conn = new SQLiteConnection(this.ConnectionString))
            {
               conn.Open();

               using (SQLiteCommand cmd = new SQLiteCommand(conn))
               {
                  sql = @"SELECT 
                           sdvalue 
                       FROM
                           sysdata 
                       WHERE
                           sdkey = 'DB.VERSION'";
                  cmd.CommandText = sql;

                  using (SQLiteDataReader reader = cmd.ExecuteReader())
                  {
                     if (reader.Read())
                     {
                        return reader.GetString(0);
                     }
                  }
               }
            }

            return string.Empty;
         }
         catch (Exception ex)
         {
            throw;
         }
      }

      private void SetDatabaseVersion(string versionNumber)
      {
         Int64 nRows;
         string sql = string.Empty;

         using (SQLiteConnection conn = new SQLiteConnection(this.ConnectionString))
         {
            conn.Open();

            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
               sql = @"SELECT 
                           Count(*) 
                       FROM 
                           sysdata 
                       WHERE
                           sdkey = @key";

               cmd.CommandText = sql;
               cmd.Parameters.Add(new SQLiteParameter("key", "DB.VERSION"));
               nRows = (Int64)cmd.ExecuteScalar();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
               if (nRows <= 0)
               {
                  sql = @"INSERT INTO sysdata (sdkey, sdvalue) 
                          VALUES (@key, @version)";
               }
               else
               {
                  sql = @"UPDATE 
                              sysdata 
                          SET 
                              sdvalue = @version 
                          WHERE 
                              sdkey = @key";
               }

               cmd.CommandText = sql;
               cmd.Parameters.Add(new SQLiteParameter("key", "DB.VERSION"));
               cmd.Parameters.Add(new SQLiteParameter("version", versionNumber));
               cmd.ExecuteNonQuery();
            }

            conn.Close();
         }
      }

      private void Update_V1_0()
      {
         string sql = string.Empty;

         try
         {
            using (SQLiteConnection conn = new SQLiteConnection(this.ConnectionString))
            {
               conn.Open();

               using (SQLiteCommand cmd = new SQLiteCommand(conn))
               {
                  sql = @"CREATE TABLE sysdata (
                           sdkey             text primary key,
                           sdvalue           text)";

                  cmd.CommandText = sql;
                  cmd.ExecuteNonQuery();
               }

               using (SQLiteCommand cmd = new SQLiteCommand(conn))
               {
                  sql = @"INSERT INTO sysdata (sdkey, sdvalue) 
                          VALUES (@key, @value)";

                  cmd.CommandText = sql;
                  cmd.Parameters.Add(new SQLiteParameter("key", "DB.CREATOR"));
                  cmd.Parameters.Add(new SQLiteParameter("value", Application.ProductName));
                  cmd.ExecuteNonQuery();
               }

               conn.Close();
            }

            SetDatabaseVersion(DB_VERSION_1_0);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      private void Update_V3_5()
      {
         string sql = string.Empty;

         using (SQLiteConnection conn = new SQLiteConnection(this.ConnectionString))
         {
            conn.Open();

            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
               sql = @"CREATE TABLE admins (
                           adminid           integer primary key autoincrement,
                           adminname         text,
                           admindesc         text,
                           adminurl          text,
                           adminfile         text,
                           adminimage        text)";

               cmd.CommandText = sql;
               cmd.ExecuteNonQuery();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
               sql = @"CREATE TABLE builders (
                           buildid           integer primary key autoincrement,
                           buildname         text,
                           builddesc         text,
                           buildurl          text,
                           buildaddress      text)";

               cmd.CommandText = sql;
               cmd.ExecuteNonQuery();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
               sql = @"CREATE TABLE cars (
                           carid             integer primary key autoincrement,
                           carmodelid        integer,
                           caradminid        integer,
                           carnumber         text,
                           carepoche         integer,
                           cartype           text,
                           cartypepre        text,
                           cartypepost       text,
                           caruic            text,
                           cardesc           text,
                           carmaxspeed       integer,
                           carlong           real,
                           carlongaxels      real,
                           carweight         real,
                           carloadlong       real,
                           carloadsurf       real,
                           carloadvol        real,
                           carloaddesc       text,
                           caroptions        integer)";

               cmd.CommandText = sql;
               cmd.ExecuteNonQuery();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
               sql = @"CREATE TABLE decoders (
                           decid             integer primary key autoincrement,
                           decname           text,
                           decdesc           text,
                           decfile           text,
                           decurl            text)";

               cmd.CommandText = sql;
               cmd.ExecuteNonQuery();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
               sql = @"CREATE TABLE images (
                           imgid             integer primary key autoincrement,
                           imgmodelid        integer,
                           imgname           text,
                           imgdesc           text,
                           imgfile           text)";

               cmd.CommandText = sql;
               cmd.ExecuteNonQuery();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
               sql = @"CREATE TABLE maintenance (
                           actionid          integer primary key autoincrement,
                           actionmodelid     integer,
                           actiondate        integer,
                           actionname        text,
                           actiondesc        text)";

               cmd.CommandText = sql;
               cmd.ExecuteNonQuery();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
               sql = @"CREATE TABLE models (
                           modid             integer primary key autoincrement,
                           modadminid        integer,
                           modstoreid        integer,
                           modname           text,
                           modpaint          text,
                           modepoche         integer,
                           modtypeid         integer,
                           modref            text,
                           modbuilderid      integer,
                           modscale          integer,
                           modcatprice       real,
                           modbuyprice       real,
                           modbuydate        integer,
                           modnem            integer,
                           modkkk            integer,
                           modpant           integer,
                           modsound          integer,
                           modlim            integer,
                           modlimyear        text,
                           modlights         integer,
                           modfrontlights    integer,
                           moddesc           text,
                           modphoto          text,
                           modlength         integer,
                           modunits          integer,
                           moddigitaladd     integer,
                           moddigitaldec     text,
                           moddecoderid      integer,
                           modregnumber      text,
                           modtype           text,
                           modtypeuic        text,
                           modframe          integer,
                           modlightinterior  integer,
                           modlightrear      integer,
                           moddecointerior   integer,
                           moddigitalconn    integer,
                           modbuypending     integer,
                           modsrvtotalhours  integer,
                           modsrvrevhours    integer)";

               cmd.CommandText = sql;
               cmd.ExecuteNonQuery();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
               sql = @"CREATE TABLE modelsdfunc (
                           modelid           integer,
                           funcid            integer,
                           description       text)";

               cmd.CommandText = sql;
               cmd.ExecuteNonQuery();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
               sql = @"CREATE TABLE modelsrevs (
                           id                integer primary key autoincrement,
                           modelid           integer,
                           revdate           integer,
                           servicehours      real,
                           runninghours      real,
                           description       text,
                           author            text)";

               cmd.CommandText = sql;
               cmd.ExecuteNonQuery();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
               sql = @"CREATE TABLE scales (
                           scid              integer primary key autoincrement,
                           scname            text,
                           scscale           text,
                           sctwidth          real,
                           scrtwidth         real)";

               cmd.CommandText = sql;
               cmd.ExecuteNonQuery();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
               sql = @"CREATE TABLE stores (
                           storeid           integer primary key autoincrement,
                           storename         text,
                           storeaddress      text,
                           storephone        text,
                           storemail         text,
                           storeurl          text,
                           storedesc         text)";

               cmd.CommandText = sql;
               cmd.ExecuteNonQuery();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
               sql = @"CREATE TABLE types (
                           typeid            integer primary key autoincrement,
                           typename          text, 
                           typeicon          text, 
                           typemaint         integer)";

               cmd.CommandText = sql;
               cmd.ExecuteNonQuery();
            }
         }

         SetDatabaseVersion(DB_VERSION_3_5);
      }

      #endregion

   }
}
