using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Rwm.Otc.LayoutControl
{
   /// <summary>
   /// Persistence manager for the sensor modules.
   /// </summary>
   public class SensorModuleManager : Data.DataEntity
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = "sensormodules";
      internal static string SQL_FIELDS_SELECT = "id, name, manufacturer, model, outputs, startaddress, type, description";
      internal static string SQL_FIELDS_INSERT = "name, manufacturer, model, outputs, startaddress, type, description";

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="SensorModuleManager"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      public SensorModuleManager(XmlSettingsManager settings) : base(settings) { }

      #endregion

      #region Methods

      /// <summary>
      /// Adds a new decoder into the current project.
      /// </summary>
      /// <param name="decoder">An instance of <see cref="SensorModule"/> containing the data.</param>
      public void Add(SensorModule decoder)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Add([{0}])", decoder);

         try
         {
            Connect();

            // Adds the new decoder
            sql = @"INSERT INTO 
                        " + SensorModuleManager.SQL_TABLE + @" (" + SensorModuleManager.SQL_FIELDS_INSERT + @") 
                    VALUES 
                        (@name, @manufacturer, @model, @outputs, @startaddress, @type, @description)";

            SetParameter("name", decoder.Name);
            SetParameter("manufacturer", decoder.Manufacturer);
            SetParameter("model", decoder.Model);
            SetParameter("outputs", decoder.Inputs);
            SetParameter("startaddress", decoder.StartAddress);
            SetParameter("type", decoder.Type);
            SetParameter("description", decoder.Notes);

            ExecuteNonQuery(sql);

            // Gets the generated new ID
            sql = @"SELECT 
                        Max(id) As id 
                    FROM 
                        " + SensorModuleManager.SQL_TABLE;

            decoder.ID = (int)ExecuteScalar(sql);
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
      /// Update the specified module.
      /// </summary>
      /// <param name="module">An instance with the updated data.</param>
      public void Update(SensorModule module)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Update([{0}])", module);

         try
         {
            Connect();

            sql = @"UPDATE 
                        " + SensorModuleManager.SQL_TABLE + @" 
                    SET 
                        name           = @name, 
                        manufacturer   = @manufacturer, 
                        model          = @model,
                        outputs        = @outputs,
                        startaddress   = @startaddress,
                        type           = @type,
                        description    = @description
                    WHERE 
                        id = @id";

            SetParameter("name", module.Name);
            SetParameter("manufacturer", module.Manufacturer);
            SetParameter("model", module.Model);
            SetParameter("outputs", module.Inputs);
            SetParameter("startaddress", module.StartAddress);
            SetParameter("type", module.Type);
            SetParameter("description", module.Notes);
            SetParameter("id", module.ID);

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
      /// Delete a panel and all its related data.
      /// </summary>
      /// <param name="id">Panel unique identifier (DB).</param>
      public void Delete(Int64 id)
      {
         this.Delete((Int32)id);
      }

      /// <summary>
      /// Delete a panel and all its related data.
      /// </summary>
      /// <param name="id">Panel unique identifier (DB).</param>
      public void Delete(int id)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Delete({0})", id);

         try
         {
            Connect();

            sql = @"DELETE 
                    FROM 
                        " + SensorModuleManager.SQL_TABLE + @" 
                    WHERE 
                        id = @id";

            SetParameter("id", id);

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
      /// Gets a module by its unique identifier.
      /// </summary>
      /// <param name="itemId">Module unique identifier (DB).</param>
      /// <returns>The requested instance of <see cref="SensorModule"/> or <c>null</c> if the module cannot be found.</returns>
      public SensorModule GetByID(Int32 itemId)
      {
         return GetByID((Int32)itemId);
      }

      /// <summary>
      /// Gets a module by its unique identifier.
      /// </summary>
      /// <param name="itemId">Module unique identifier (DB).</param>
      /// <returns>The requested instance of <see cref="SensorModule"/> or <c>null</c> if the module cannot be found.</returns>
      public SensorModule GetByID(Int64 itemId)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].GetByID({0})", itemId);

         try
         {
            Connect();

            sql = @"SELECT 
                        " + SensorModuleManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + SensorModuleManager.SQL_TABLE + @" 
                    WHERE 
                        id = @id";

            SetParameter("id", itemId);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  return SensorModuleManager.ReadEntityRecord(reader);
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
      /// Gets all blocks from a specified switchboard panel.
      /// </summary>
      /// <returns>The requested list of <see cref="BlockBase"/>.</returns>
      public List<SensorModule> GetAll()
      {
         string sql = string.Empty;
         SensorModule item = null;
         List<SensorModule> items = new List<SensorModule>();

         Logger.LogDebug(this, "[CLASS].GetAll()");

         try
         {
            Connect();

            sql = @"SELECT 
                        " + SensorModuleManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + SensorModuleManager.SQL_TABLE + @" 
                    ORDER BY 
                        name Asc";

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  item = SensorModuleManager.ReadEntityRecord(reader);
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
      /// Get all decoders information in an instance of <see cref="DataTable"/>.
      /// </summary>
      /// <returns>An instance of <see cref="DataTable"/> filled with the requested data.</returns>
      public DataTable GetAllAsDataTable()
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].GetAllAsDataTable()");

         try
         {
            Connect();

            sql = @"SELECT 
                        id             As ""#ID"", 
                        name           As ""Name"", 
                        manufacturer   As ""Manufacturer"", 
                        model          As ""Model"", 
                        outputs        As ""Num. Outputs"", 
                        startaddress   As ""Start Address""
                    FROM 
                        " + SensorModuleManager.SQL_TABLE + @" 
                    ORDER BY 
                        name Asc";

            return ExecuteDataTable(sql);
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
      /// Get a list of all module manufacturers.
      /// </summary>
      /// <returns>A list of <see cref="String"/> filled with the requested data.</returns>
      public List<String> GetAllManufacturers()
      {
         string sql = string.Empty;
         List<string> items = new List<string>();

         Logger.LogDebug(this, "[CLASS].GetAllManufacturers()");

         try
         {
            Connect();

            sql = @"SELECT DISTINCT 
                        manufacturer   As ""Manufacturer""
                    FROM 
                        " + SensorModuleManager.SQL_TABLE + @" 
                    ORDER BY 
                        manufacturer Asc";

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  if (!reader.IsDBNull(0))
                  {
                     items.Add(reader.GetString(0));
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
      /// Get a list of all module models.
      /// </summary>
      /// <returns>A list of <see cref="String"/> filled with the requested data.</returns>
      public List<String> GetAllModels()
      {
         string sql = string.Empty;
         List<string> items = new List<string>();

         Logger.LogDebug(this, "[CLASS].GetAllModels()");

         try
         {
            Connect();

            sql = @"SELECT DISTINCT 
                        model          As ""Model""
                    FROM 
                        " + SensorModuleManager.SQL_TABLE + @" 
                    ORDER BY 
                        model Asc";

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  if (!reader.IsDBNull(0))
                  {
                     items.Add(reader.GetString(0));
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
      /// Get all connections of the specified module.
      /// </summary>
      /// <param name="module">Module.</param>
      /// <returns></returns>
      public DataTable GetAllByModuleAsDataTable(SensorModule module)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].GetAllByModuleAsDataTable({0})", module);

         try
         {
            Connect();

            sql = @"SELECT 
                        ao.id       As ""#ID"", 
                        ao.name     As ""Output"", 
                        b.name      As ""Block"", 
                        ao.address  As ""Address"" 
                    FROM 
                        " + SensorInputManager.SQL_TABLE + @" ao
                        INNER JOIN " + BlockManager.SQL_TABLE + @" b On (ao.blockid = b.id)  
                    WHERE 
                        ao.decoderid = @decoderid 
                    ORDER BY 
                        ao.name Asc";

            SetParameter("decoderid", module.ID);

            DataTable dt = ExecuteDataTable(sql);

            for (int i = (dt.Rows.Count - 1); i < (module.Inputs - 1); i++)
            {
               dt.Rows.Add(new object[] { 0, "-", "<empty>", 0 });
            }

            return dt;
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

      #endregion

      #region Private Members

      /// <summary>
      /// Read a category from the current reader record.
      /// </summary>
      internal static SensorModule ReadEntityRecord(SQLiteDataReader reader)
      {
         SensorModule record = new SensorModule();
         record.ID = reader.GetInt32(0);
         record.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
         record.Manufacturer = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
         record.Model = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
         record.Inputs = reader.IsDBNull(4) ? 1 : reader.GetInt32(4);
         record.StartAddress = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
         record.Type = reader.IsDBNull(6) ? SensorModule.AccessoryDecoderType.Unknown : (SensorModule.AccessoryDecoderType)reader.GetInt32(6);
         record.Notes = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);

         return record;
      }

      #endregion

   }
}
