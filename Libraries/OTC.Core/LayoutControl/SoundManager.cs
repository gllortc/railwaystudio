using Rwm.Otc.Configuration;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Rwm.Otc.LayoutControl
{
   /// <summary>
   /// Sounds data manager.
   /// </summary>
   public class SoundManager : DataEntity
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = "sounds";
      internal static string SQL_FIELDS_SELECT = "id, name, filename, sounddata";
      internal static string SQL_FIELDS_INSERT = "name, filename, sounddata";

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="SoundManager"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      public SoundManager(XmlSettingsManager settings) : base(settings) { }

      #endregion

      #region Methods

      /// <summary>
      /// Adds a new sound.
      /// </summary>
      /// <param name="sound">Sound to insert.</param>
      /// <param name="path">Filename + path to sound file.</param>
      public void Add(Sound sound, string path)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Add([{0}], '{1}')", sound, path);

         try
         {
            if (!File.Exists(path))
            {
               throw new FileNotFoundException();
            }

            Connect();

            sql = @"INSERT INTO 
                        " + SoundManager.SQL_TABLE + @" (" + SoundManager.SQL_FIELDS_INSERT + @") 
                    VALUES 
                        (@name, @filename, @sounddata)";

            SetParameter("name", sound.Name);
            SetParameter("filename", Path.GetFileName(path));
            SetParameter("sounddata", File.ReadAllBytes(path));

            ExecuteNonQuery(sql);

            // Gets the new generated ID
            sql = @"SELECT 
                        Max(id) As id 
                    FROM 
                        " + SoundManager.SQL_TABLE;

            sound.ID = (int)ExecuteScalar(sql, 0);

            sound.Filename = Path.GetFileName(path);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Update the specified sound.
      /// </summary>
      /// <param name="sound">The sound to update.</param>
      /// <remarks>
      /// The sound binary data won't be modified.
      /// </remarks>
      public void Update(Sound sound)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Update([{0}])", sound);

         try
         {
            Connect();

            sql = @"UPDATE 
                        " + SoundManager.SQL_TABLE + @" 
                    SET 
                        name = @name, 
                        filename = @filename 
                    WHERE 
                        id = @id";

            SetParameter("id", sound.ID);
            SetParameter("name", sound.Name);
            SetParameter("filename", sound.Filename);

            ExecuteNonQuery(sql);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Update the specified sound.
      /// </summary>
      /// <param name="sound">The sound to update.</param>
      /// <param name="path">Path + filename to file to update.</param>
      public void Update(Sound sound, string path)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Update([{0}])", sound);

         try
         {
            if (!File.Exists(path))
            {
               throw new FileNotFoundException();
            }

            Connect();

            sql = @"UPDATE 
                        " + SoundManager.SQL_TABLE + @" 
                    SET 
                        name = @name, 
                        filename = @filename 
                    WHERE 
                        id = @id";

            SetParameter("id", sound.ID);
            SetParameter("name", sound.Name);
            SetParameter("filename", Path.GetFileName(path));
            SetParameter("sounddata", File.ReadAllBytes(path));

            ExecuteNonQuery(sql);

            sound.Filename = Path.GetFileName(path);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Delete a sound.
      /// </summary>
      /// <param name="id">Sound unique identifier (DB).</param>
      public void Delete(Int32 itemId)
      {
         this.Delete((Int64)itemId);
      }

      /// <summary>
      /// Delete a sound.
      /// </summary>
      /// <param name="id">Sound unique identifier (DB).</param>
      public void Delete(Int64 itemId)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Delete({0})", itemId);

         try
         {
            Connect();

            sql = @"DELETE 
                    FROM 
                        " + SoundManager.SQL_TABLE + @" 
                    WHERE 
                        id = @id";

            SetParameter("id", itemId);
            ExecuteNonQuery(sql);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Get all routes.
      /// </summary>
      /// <returns>The requested list filled with information.</returns>
      public List<Sound> GetAll()
      {
         string sql = string.Empty;
         Sound item;
         List<Sound> items = new List<Sound>();

         Logger.LogDebug(this, "[CLASS].GetAll()");

         try
         {
            Connect();

            sql = @"SELECT 
                        " + SoundManager.SQL_FIELDS_SELECT + @"
                    FROM 
                        " + SoundManager.SQL_TABLE + @" 
                    ORDER BY 
                        name";

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  item = SoundManager.ReadEntityRecord(reader, false);
                  if (item != null)
                  {
                     items.Add(item);
                  }
               }
            }

            return items;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Get a sound by its unique identifier.
      /// </summary>
      /// <param name="itemId">Sound unique identifier (DB).</param>
      /// <param name="readSoundData">A value indicating if the sound must be loaded into a stream.</param>
      /// <returns>The requested <see cref="Sound"/> instance or <c>null</c> if the specified sound doesn't exists.</returns>
      public Sound GetByID(Int32 itemId, bool readSoundData)
      {
         return GetByID((Int64)itemId, readSoundData);
      }

      /// <summary>
      /// Get a sound by its unique identifier.
      /// </summary>
      /// <param name="itemId">Sound unique identifier (DB).</param>
      /// <param name="readSoundData">A value indicating if the sound must be loaded into a stream.</param>
      /// <returns>The requested <see cref="Sound"/> instance or <c>null</c> if the specified sound doesn't exists.</returns>
      public Sound GetByID(Int64 itemId, bool readSoundData)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].GetByID({0})", itemId);

         try
         {
            Connect();

            sql = @"SELECT 
                        " + SoundManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + SoundManager.SQL_TABLE + @" 
                    WHERE 
                        id = @id";

            SetParameter("id", itemId);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  return SoundManager.ReadEntityRecord(reader, readSoundData);
               }
            }

            return null;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Gets all sounds.
      /// </summary>
      /// <returns>The requested instance of <see cref="DataTable"/>.</returns>
      public System.Data.DataTable FindAll()
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].FindAll()");

         try
         {
            Connect();

            sql = @"SELECT 
                        id, 
                        name     As ""Name"", 
                        filename As ""SoundFile""
                    FROM 
                        " + SoundManager.SQL_TABLE + @" 
                    ORDER BY 
                        name";

            return ExecuteDataTable(sql);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      /// <summary>
      /// Play a sound.
      /// </summary>
      /// <param name="itemId">Sound unique identifier (DB).</param>
      public void PlaySound(Int32 itemId, Project project)
      {
         this.PlaySound((Int64)itemId, project);
      }

      /// <summary>
      /// Play a sound.
      /// </summary>
      /// <param name="itemId">Sound unique identifier (DB).</param>
      public void PlaySound(Int64 itemId, Project project)
      {
         bool played = false;
         string path = string.Empty;
         Sound sound = null;

         try
         {
            sound = this.GetByID(itemId, false);

            path = Path.Combine(GetCacheFolder(), sound.GetCacheFilename(project));
            if (!File.Exists(path))
            {
               sound = this.GetByID(itemId, true);
               sound.SoundStream.Seek(0, SeekOrigin.Begin);
               using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
               {
                  sound.SoundStream.CopyTo(fs);
                  fs.Flush();
               }
            }

            if (File.Exists(path))
            {
               played = true;

               System.Media.SoundPlayer player = new System.Media.SoundPlayer(path);
               player.Play();
            }

            if (!played)
            {
               System.Media.SystemSounds.Beep.Play();
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      #endregion

      #region Static Members

      /// <summary>
      /// Read an entity from the current reader record.
      /// </summary>
      internal static Sound ReadEntityRecord(SQLiteDataReader reader, bool getFileData)
      {
         Sound record = new Sound();
         record.ID = reader.GetInt32(0);
         record.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
         record.Filename = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);

         if (getFileData)
         {
            record.SoundStream = SoundManager.ReadSoundFile(reader);
         }

         return record;
      }

      /// <summary>
      /// Read the sound file contents into a <see cref="MemoryStream"/>.
      /// </summary>
      internal static Stream ReadSoundFile(SQLiteDataReader reader)
      {
         const int CHUNK_SIZE = 2 * 1024;
         byte[] buffer = new byte[CHUNK_SIZE];
         long bytesRead;
         long fieldOffset = 0;
         MemoryStream stream = new MemoryStream();

         while ((bytesRead = reader.GetBytes(3, fieldOffset, buffer, 0, buffer.Length)) > 0)
         {
            stream.Write(buffer, 0, (int)bytesRead);
            fieldOffset += bytesRead;
         }

         return stream;
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
