using System;
using System.Data.SQLite;
using System.IO;
using Rwm.Otc.Data;

namespace Rwm.Otc.Layout.Persistence
{
   /// <summary>
   /// Sounds data manager.
   /// </summary>
   public class ProjectDAO : DataConsumer
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = "projects";
      internal static string SQL_FIELDS_SELECT = "id, name, description, version";
      internal static string SQL_FIELDS_INSERT = "name, description, version";

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ProjectDAO"/>.
      /// </summary>
      public ProjectDAO() : base() { }

      #endregion

      #region Methods

      ///// <summary>
      ///// Adds a new sound.
      ///// </summary>
      ///// <param name="item">Sound to insert.</param>
      //public void Add(Project item)
      //{
      //   string sql = string.Empty;

      //   Logger.LogDebug(this, "[CLASS].Add([{0}])", item);

      //   try
      //   {
      //      Connect();

      //      sql = @"INSERT INTO 
      //                  " + ProjectDAO.SQL_TABLE + @" (" + ProjectDAO.SQL_FIELDS_INSERT + @") 
      //              VALUES 
      //                  (@name, @description, @version)";

      //      SetParameter("name", item.Name);
      //      SetParameter("description", item.Description);
      //      SetParameter("version", item.Version);

      //      ExecuteNonQuery(sql);

      //      // Gets the new generated ID
      //      sql = @"SELECT 
      //                  Max(id) As id 
      //              FROM 
      //                  " + ProjectDAO.SQL_TABLE;

      //      item.ID = (Int64)ExecuteScalar(sql, 0);
      //   }
      //   catch (Exception ex)
      //   {
      //      Logger.LogError(this, ex);

      //      throw;
      //   }
      //   finally
      //   {
      //      Disconnect();
      //   }
      //}

      ///// <summary>
      ///// Update the specified sound.
      ///// </summary>
      ///// <param name="item">The sound to update.</param>
      //public void Update(Project item)
      //{
      //   string sql = string.Empty;

      //   Logger.LogDebug(this, "[CLASS].Update([{0}])", item);

      //   try
      //   {
      //      Connect();


      //      sql = @"UPDATE 
      //                  " + ProjectDAO.SQL_TABLE + @" 
      //              SET 
      //                  name = @name, 
      //                  description = @description, 
      //                  version = @version 
      //              WHERE 
      //                  id = @id";

      //      SetParameter("id", item.ID);
      //      SetParameter("name", item.Name);
      //      SetParameter("description", item.Description);
      //      SetParameter("version", item.Version);

      //      ExecuteNonQuery(sql);
      //   }
      //   catch (Exception ex)
      //   {
      //      Logger.LogError(this, ex);

      //      throw;
      //   }
      //   finally
      //   {
      //      Disconnect();
      //   }
      //}

      ///// <summary>
      ///// Get a sound by its unique identifier.
      ///// </summary>
      ///// <returns>The requested <see cref="Sound"/> instance or <c>null</c> if the specified sound doesn't exists.</returns>
      //public Project Get(Project project)
      //{
      //   string sql = string.Empty;

      //   Logger.LogDebug(this, "[CLASS].Get([{0}])", project);

      //   try
      //   {
      //      Connect();

      //      sql = @"SELECT 
      //                  " + ProjectDAO.SQL_FIELDS_SELECT + @" 
      //              FROM 
      //                  " + ProjectDAO.SQL_TABLE + @" 
      //              ORDER BY 
      //                  id Asc
      //              LIMIT 1";

      //      using (SQLiteDataReader reader = ExecuteReader(sql))
      //      {
      //         if (reader.Read())
      //            return this.ReadEntityRecord(project, reader);
      //      }

      //      return null;
      //   }
      //   catch (Exception ex)
      //   {
      //      Logger.LogError(this, ex);

      //      throw;
      //   }
      //   finally
      //   {
      //      Disconnect();
      //   }
      //}

      public Project ReadEntityRecord(Project project, SQLiteDataReader reader)
      {
         project.ID = reader.GetInt32(0);
         project.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
         project.Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
         project.Version = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
         return project;
      }

      #endregion

      #region Private Members

      private string GetCacheFolder()
      {
         string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
         if (Environment.OSVersion.Version.Major >= 6)
         {
            path = Directory.GetParent(path).ToString();
         }

         path = Path.Combine(path, "Railwaymania", "RailwayStudio", "SoundCache");

         if (!Directory.Exists(path))
         {
            Directory.CreateDirectory(path);
         }

         return path;
      }

      #endregion

   }
}
