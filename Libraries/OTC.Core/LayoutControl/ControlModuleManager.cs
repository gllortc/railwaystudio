using Rwm.Otc.Configuration;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Rwm.Otc.LayoutControl
{
   /// <summary>
   /// Manage all control modules.
   /// </summary>
   public class ControlModuleManager : DataEntity
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = "accessorymodules";
      internal static string SQL_FIELDS_SELECT = "id, name, manufacturer, model, outputs, startaddress, type, description";
      internal static string SQL_FIELDS_INSERT = "name, manufacturer, model, outputs, startaddress, type, description";

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="ControlModuleManager"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      public ControlModuleManager(XmlSettingsManager settings) : base(settings) { }

      #endregion

      #region Methods

      /// <summary>
      /// Adds a new module into the current project.
      /// </summary>
      /// <param name="module">An instance of <see cref="ControlModule"/> containing the data.</param>
      public void Add(ControlModule module)
      {
         int addr = 0;
         string sql = string.Empty;
         ControlModuleConnectionManager connManager = null;

         Logger.LogDebug(this, "[CLASS].Add([{0}])", module);

         try
         {
            Connect();

            // Adds the new decoder
            sql = @"INSERT INTO 
                        " + ControlModuleManager.SQL_TABLE + @" (" + ControlModuleManager.SQL_FIELDS_INSERT + @") 
                    VALUES 
                        (@name, @manufacturer, @model, @outputs, @startaddress, @type, @description)";

            SetParameter("name", module.Name);
            SetParameter("manufacturer", module.Manufacturer);
            SetParameter("model", module.Model);
            SetParameter("outputs", module.Outputs);
            SetParameter("startaddress", module.StartAddress);
            SetParameter("type", module.Type);
            SetParameter("description", module.Notes);

            ExecuteNonQuery(sql);

            // Gets the generated new ID
            sql = @"SELECT 
                        Max(id) As id 
                    FROM 
                        " + ControlModuleManager.SQL_TABLE;

            module.ID = (int)ExecuteScalar(sql);

            Disconnect();

            // Initialize the address for the sensor module
            addr = module.StartAddress;

            // Generate dummy connections with appropriate name
            connManager = new ControlModuleConnectionManager(this.Settings);
            for (int i = 1; i <= module.Outputs; i++)
            {
               switch (module.Type)
               {
                  case ControlModule.ModuleType.Accessory:
                     connManager.Add(new ControlModuleConnection(i.ToString(), module));
                     break;

                  case ControlModule.ModuleType.Sensor:
                     connManager.Add(new ControlModuleConnection(i.ToString(), module, addr, i));
                     break;
               }

               // Update address by sensor output group
               if (i % 4 == 0) addr++;
            }
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
      /// Update the specified control module.
      /// </summary>
      /// <param name="module">An instance with the updated data.</param>
      public void Update(ControlModule module)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Update([{0}])", module);

         try
         {
            Connect();

            sql = @"UPDATE 
                        " + ControlModuleManager.SQL_TABLE + @" 
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
            SetParameter("outputs", module.Outputs);
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
      /// Delete the specified control module.
      /// </summary>
      /// <param name="id">Control module unique identifier (DB).</param>
      public void Delete(Int64 id)
      {
         this.Delete((Int32)id);
      }

      /// <summary>
      /// Delete the specified control module.
      /// </summary>
      /// <param name="id">Control module unique identifier (DB).</param>
      public void Delete(int id)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Delete({0})", id);

         try
         {
            Connect();

            sql = @"DELETE 
                    FROM 
                        " + ControlModuleManager.SQL_TABLE + @" 
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
      /// Gets a control module by its identifier.
      /// </summary>
      /// <param name="id">Control module unique identifier (DB).</param>
      /// <returns>The requested instance of <see cref="ControlModule"/> or <c>null</c> if the module cannot be found.</returns>
      public ControlModule GetByID(Int32 id)
      {
         return GetByID((Int64)id);
      }

      /// <summary>
      /// Gets a control module by its identifier.
      /// </summary>
      /// <param name="id">Control module unique identifier (DB).</param>
      /// <returns>The requested instance of <see cref="ControlModule"/> or <c>null</c> if the module cannot be found.</returns>
      public ControlModule GetByID(Int64 id)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].GetByID({0})", id);

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ControlModuleManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ControlModuleManager.SQL_TABLE + @" 
                    WHERE 
                        id = @id";

            SetParameter("id", id);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  return ControlModuleManager.ReadEntityRecord(reader);
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
      /// Gets all control modules.
      /// </summary>
      /// <returns>The requested list of <see cref="ControlModule"/>.</returns>
      public List<ControlModule> GetAll()
      {
         string sql = string.Empty;
         ControlModule item = null;
         List<ControlModule> items = new List<ControlModule>();

         Logger.LogDebug(this, "[CLASS].GetAll()");

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ControlModuleManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ControlModuleManager.SQL_TABLE + @" 
                    ORDER BY 
                        name Asc";

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  item = ControlModuleManager.ReadEntityRecord(reader);
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
      public List<ControlModule> GetByType(ControlModule.ModuleType type)
      {
         string sql = string.Empty;
         ControlModule item = null;
         List<ControlModule> items = new List<ControlModule>();

         Logger.LogDebug(this, "[CLASS].GetByType({0})", type);

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ControlModuleManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ControlModuleManager.SQL_TABLE + @" 
                    WHERE 
                        type = @type 
                    ORDER BY 
                        name Asc";

            SetParameter("type", (int)type);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  item = ControlModuleManager.ReadEntityRecord(reader);
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
      /// Get all modules as <see cref="DataTable"/>.
      /// </summary>
      /// <returns>An instance of <see cref="DataTable"/> filled with all data.</returns>
      public System.Data.DataTable FindAll()
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].GetAllAsDataTable()");

         try
         {
            Connect();

            sql = @"SELECT 
                        id, 
                        type,
                        name           As ""Name"", 
                        manufacturer   As ""Manufacturer"", 
                        model          As ""Model"", 
                        (SELECT Count(*)
                         FROM   " + ControlModuleConnectionManager.SQL_TABLE + @" cmc 
                         WHERE  cmc.decoderid = cm.id)||'/'||outputs As ""Connections""
                    FROM 
                        " + ControlModuleManager.SQL_TABLE + @" cm 
                    ORDER BY 
                        cm.name Asc";

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
      /// Get all decoders information in an instance of <see cref="DataTable"/>.
      /// </summary>
      /// <returns>An instance of <see cref="DataTable"/> filled with the requested data.</returns>
      public System.Data.DataTable FindByType(ControlModule.ModuleType type)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].GetByTypeAsDataTable({0})", type);

         try
         {
            Connect();

            sql = @"SELECT 
                        cm.id             As ""#ID"", 
                        cm.name           As ""Name"", 
                        cm.manufacturer   As ""Manufacturer"", 
                        cm.model          As ""Model"", 
                        cm.outputs        As """ + (type == ControlModule.ModuleType.Accessory ? "Outputs" : "Inputs") + @""", 
                        (SELECT Count(*)
                         FROM   " + ControlModuleConnectionManager.SQL_TABLE + @" cmc 
                         WHERE  cmc.decoderid = cm.id) As ""Used""
                    FROM 
                        " + ControlModuleManager.SQL_TABLE + @" cm 
                    WHERE 
                        cm.type = @type 
                    ORDER BY 
                        cm.name Asc";

            SetParameter("type", (int)type);

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
      /// Get a list of all decoder manufacturers.
      /// </summary>
      /// <returns>A list of <see cref="String"/> filled with the requested data.</returns>
      public List<String> GetAllManufacturers()
      {
         string sql = string.Empty;
         List<string> items = new List<string>();

         Logger.LogDebug(this, "[CLASS].GetAllManufacturersAsDataTable()");

         try
         {
            Connect();

            sql = @"SELECT DISTINCT 
                        manufacturer   As ""Manufacturer""
                    FROM 
                        " + ControlModuleManager.SQL_TABLE + @" 
                    WHERE 
                        manufacturer <> '' 
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
      /// Get a list of all decoder models.
      /// </summary>
      /// <returns>A list of <see cref="String"/> filled with the requested data.</returns>
      public List<String> GetAllModels()
      {
         string sql = string.Empty;
         List<string> items = new List<string>();

         Logger.LogDebug(this, "[CLASS].GetAllModelsAsDataTable()");

         try
         {
            Connect();

            sql = @"SELECT DISTINCT 
                        model          As ""Model""
                    FROM 
                        " + ControlModuleManager.SQL_TABLE + @" 
                    WHERE 
                        model <> '' 
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
      /// Check if a digital address is used.
      /// </summary>
      /// <param name="address">Address to check.</param>
      /// <param name="type">Type of address.</param>
      /// <returns><c>true</c> if the address is used or <c>false</c> if the address is free.</returns>
      public bool IsAddressUsed(int address, ControlModule.ModuleType type)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].IsAddressUsed({0}, {1})", address, type);

         try
         {
            Connect();

            sql = @"SELECT DISTINCT 
                        Count(*) 
                    FROM 
                        " + ControlModuleManager.SQL_TABLE + @" 
                    WHERE 
                        address = @address And 
                        type = @type";

            SetParameter("address", address);
            SetParameter("type", (int)type);

            return (ExecuteScalar(sql) > 0);
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
      internal static ControlModule ReadEntityRecord(SQLiteDataReader reader)
      {
         ControlModule record = new ControlModule();
         record.ID = reader.GetInt32(0);
         record.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
         record.Manufacturer = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
         record.Model = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
         record.Outputs = reader.IsDBNull(4) ? 1 : reader.GetInt32(4);
         record.StartAddress = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
         record.Type = reader.IsDBNull(6) ? ControlModule.ModuleType.Accessory : (ControlModule.ModuleType)reader.GetInt32(6);
         record.Notes = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);

         return record;
      }

      #endregion

   }
}
