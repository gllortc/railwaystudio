using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Rwm.Otc.Layout.Persistence
{
   /// <summary>
   /// Manage all control modules.
   /// </summary>
   public class DeviceDAO : DataConsumer
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = "devices";
      internal static string SQL_FIELDS_SELECT = "id, name, manufacturer, model, outputs, startaddress, type, description";
      internal static string SQL_FIELDS_INSERT = "name, manufacturer, model, outputs, startaddress, type, description";

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="DeviceDAO"/>.
      /// </summary>
      public DeviceDAO() : base() { }

      #endregion

      #region Methods

//      /// <summary>
//      /// Adds a new module into the current project.
//      /// </summary>
//      /// <param name="device">An instance of <see cref="Device"/> containing the data.</param>
//      public void Add(Device device)
//      {
//         int addr = 0;
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].Add([{0}])", device);

//         try
//         {
//            Connect();

//            // Adds the new decoder
//            sql = @"INSERT INTO 
//                        " + DeviceDAO.SQL_TABLE + @" (" + DeviceDAO.SQL_FIELDS_INSERT + @") 
//                    VALUES 
//                        (@name, @manufacturer, @model, @outputs, @startaddress, @type, @description)";

//            SetParameter("name", device.Name);
//            SetParameter("manufacturer", device.Manufacturer);
//            SetParameter("model", device.Model);
//            SetParameter("outputs", device.Outputs);
//            SetParameter("startaddress", device.StartAddress);
//            SetParameter("type", device.Type);
//            SetParameter("description", device.Notes);

//            ExecuteNonQuery(sql);

//            // Gets the generated new ID
//            sql = @"SELECT 
//                        Max(id) As id 
//                    FROM 
//                        " + DeviceDAO.SQL_TABLE;

//            device.ID = (int)ExecuteScalar(sql);

//            Disconnect();

//            // Initialize the address for the sensor module
//            addr = device.StartAddress;

//            // Generate dummy connections with appropriate name
//            for (int i = 1; i <= device.Outputs; i++)
//            {
//               switch (device.Type)
//               {
//                  case Device.DeviceType.AccessoryDecoder:
//                     DeviceConnection.Save(new DeviceConnection(i.ToString(), device));
//                     break;

//                  case Device.DeviceType.SensorModule:
//                     DeviceConnection.Save(new DeviceConnection(i.ToString(), device, addr, i));
//                     break;
//               }

//               // Update address by sensor output group
//               if (i % 4 == 0) addr++;
//            }
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            throw;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

//      /// <summary>
//      /// Update the specified control module.
//      /// </summary>
//      /// <param name="device">An instance with the updated data.</param>
//      public void Update(Device device)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].Update([{0}])", device);

//         try
//         {
//            Connect();

//            sql = @"UPDATE 
//                        " + DeviceDAO.SQL_TABLE + @" 
//                    SET 
//                        name           = @name, 
//                        manufacturer   = @manufacturer, 
//                        model          = @model,
//                        outputs        = @outputs,
//                        startaddress   = @startaddress,
//                        type           = @type,
//                        description    = @description
//                    WHERE 
//                        id = @id";

//            SetParameter("name", device.Name);
//            SetParameter("manufacturer", device.Manufacturer);
//            SetParameter("model", device.Model);
//            SetParameter("outputs", device.Outputs);
//            SetParameter("startaddress", device.StartAddress);
//            SetParameter("type", device.Type);
//            SetParameter("description", device.Notes);
//            SetParameter("id", device.ID);

//            ExecuteNonQuery(sql);
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            throw;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

//      /// <summary>
//      /// Delete the specified control module.
//      /// </summary>
//      /// <param name="id">Control module unique identifier (DB).</param>
//      public int Delete(long id)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].Delete({0})", id);

//         try
//         {
//            Connect();

//            sql = @"DELETE 
//                    FROM 
//                        " + DeviceDAO.SQL_TABLE + @" 
//                    WHERE 
//                        id = @id";

//            SetParameter("id", id);

//            return ExecuteNonQuery(sql);
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            throw;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

//      /// <summary>
//      /// Gets a control module by its identifier.
//      /// </summary>
//      /// <param name="id">Control module unique identifier (DB).</param>
//      /// <returns>The requested instance of <see cref="Device"/> or <c>null</c> if the module cannot be found.</returns>
//      public Device GetByID(long id)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].GetByID({0})", id);

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + DeviceDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + DeviceDAO.SQL_TABLE + @" 
//                    WHERE 
//                        id = @id";

//            SetParameter("id", id);

//            using (SQLiteDataReader reader = ExecuteReader(sql))
//            {
//               if (reader.Read())
//               {
//                  return this.ReadEntityRecord(reader);
//               }
//            }

//            return null;
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            throw;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

//      /// <summary>
//      /// Gets all control modules.
//      /// </summary>
//      /// <returns>The requested list of <see cref="Device"/>.</returns>
//      public IEnumerable<Device> GetAll()
//      {
//         string sql = string.Empty;
//         Device item = null;
//         List<Device> items = new List<Device>();

//         Logger.LogDebug(this, "[CLASS].GetAll()");

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + DeviceDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + DeviceDAO.SQL_TABLE + @" 
//                    ORDER BY 
//                        name Asc";

//            using (SQLiteDataReader reader = ExecuteReader(sql))
//            {
//               while (reader.Read())
//               {
//                  item = this.ReadEntityRecord(reader);
//                  if (item != null)
//                  {
//                     items.Add(item);
//                  }
//               }
//            }

//            return items;
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            throw;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

//      /// <summary>
//      /// Get all decoders information in an instance of <see cref="DataTable"/>.
//      /// </summary>
//      /// <returns>An instance of <see cref="DataTable"/> filled with the requested data.</returns>
//      public List<Device> GetByType(Device.DeviceType type)
//      {
//         string sql = string.Empty;
//         Device item = null;
//         List<Device> items = new List<Device>();

//         Logger.LogDebug(this, "[CLASS].GetByType({0})", type);

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + DeviceDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + DeviceDAO.SQL_TABLE + @" 
//                    WHERE 
//                        type = @type 
//                    ORDER BY 
//                        name Asc";

//            SetParameter("type", (int)type);

//            using (SQLiteDataReader reader = ExecuteReader(sql))
//            {
//               while (reader.Read())
//               {
//                  item = this.ReadEntityRecord(reader);
//                  if (item != null)
//                  {
//                     items.Add(item);
//                  }
//               }
//            }

//            return items;
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            throw;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

//      /// <summary>
//      /// Get all control devices.
//      /// </summary>
//      /// <returns>An instance of <see cref="System.Data.DataTable"/> filled with all data.</returns>
//      public System.Data.DataTable Find()
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].Find()");

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        id, 
//                        type,
//                        name           As ""Name"", 
//                        manufacturer   As ""Manufacturer"", 
//                        model          As ""Model"", 
//                        (SELECT Count(*)
//                         FROM   " + DeviceConnectionDAO.SQL_TABLE + @" cmc 
//                         WHERE  cmc.deviceid = cm.id)||'/'||outputs As ""Connections""
//                    FROM 
//                        " + DeviceDAO.SQL_TABLE + @" cm 
//                    ORDER BY 
//                        cm.name Asc";

//            return ExecuteDataTable(sql);
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            throw;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

//      /// <summary>
//      /// Get all decoders information in an instance of <see cref="DataTable"/>.
//      /// </summary>
//      /// <returns>An instance of <see cref="DataTable"/> filled with the requested data.</returns>
//      public System.Data.DataTable FindByType(Device.DeviceType type)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].GetByTypeAsDataTable({0})", type);

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        cm.id             As ""#ID"", 
//                        cm.name           As ""Name"", 
//                        cm.manufacturer   As ""Manufacturer"", 
//                        cm.model          As ""Model"", 
//                        cm.outputs        As """ + (type == Device.DeviceType.AccessoryDecoder ? "Outputs" : "Inputs") + @""", 
//                        (SELECT Count(*)
//                         FROM   " + DeviceConnectionDAO.SQL_TABLE + @" cmc 
//                         WHERE  cmc.deviceid = cm.id) As ""Used""
//                    FROM 
//                        " + DeviceDAO.SQL_TABLE + @" cm 
//                    WHERE 
//                        cm.type = @type 
//                    ORDER BY 
//                        cm.name Asc";

//            SetParameter("type", (int)type);

//            return ExecuteDataTable(sql);
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            throw;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

      /// <summary>
      /// Get all decoders information in an instance of <see cref="DataTable"/>.
      /// </summary>
      /// <returns>An instance of <see cref="DataTable"/> filled with the requested data.</returns>
      public DataSet FindByConnection()
      {
         string sql = string.Empty;
         DataSet ds = new DataSet();

         Logger.LogDebug(this, "[CLASS].FindByConnection()");

         try
         {
            Connect();

            sql = @"SELECT 
                        s.id    as ""SwitchboardID"",
                        s.name  as ""Switchboard""
                    FROM 
                        " + Switchboard.TableName + @" s
                    ORDER BY 
                        s.name  Asc";

            ds.Tables.Add(this.ExecuteDataTable(sql));
            ds.Tables[0].TableName = "Switchboards";

            sql = @"SELECT 
                        s.id                             as ""SwitchboardID"",
                        s.name                           as ""Switchboard"",
                        d.name                           as ""Name"", 
                        d.manufacturer || ' ' || d.model as ""Decoder"",
                        dc.name                          as ""Output"",
                        dc.address                       as ""Address"",
                        e.name                           as ""ConnectTo"" 
                    FROM 
                        " + Switchboard.TableName + @" s
                        Inner Join " + Element.TableName + @" e           On (e.switchboardid = s.id)
                        Inner Join " + DeviceConnection.TableName + @" dc On (e.id = dc.elementid)
                        Inner Join " + Device.TableName + @" d            On (d.id = dc.deviceid)
                    ORDER BY 
                        s.name  Asc,
                        d.name  Asc,
                        dc.name Asc";

            ds.Tables.Add(this.ExecuteDataTable(sql));
            ds.Tables[1].TableName = "Connections";

            // Create a relation to be used in reports
            ds.Relations.Add(new DataRelation("SwitchboardConnection",
                                              ds.Tables["Switchboards"].Columns["SwitchboardID"],
                                              ds.Tables["Connections"].Columns["SwitchboardID"]));

            return ds;
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
      public DataSet FindBySwitchboard(int switchboardId)
      {
         string sql = string.Empty;
         DataSet ds = new DataSet();

         Logger.LogDebug(this, "[CLASS].FindBySwitchboard({0})", switchboardId);

         try
         {
            Connect();

            sql = @"SELECT 
                        s.id                             as ""SwitchboardID"",
                        s.name                           as ""Switchboard"",
                        d.name                           as ""Name"", 
                        d.manufacturer || ' ' || d.model as ""Decoder"",
                        dc.name                          as ""Output"",
                        dc.address                       as ""Address"",
                        CASE 
                           WHEN (e.name <> '') THEN e.name
                           ELSE ('X:' || (e.x + 1) || ' Y:' || (e.y + 1))
                        END                              as ""ConnectTo"" 
                    FROM 
                        " + Switchboard.TableName + @" s
                        Inner Join " + Element.TableName + @" e           On (e.switchboardid = s.id)
                        Inner Join " + DeviceConnection.TableName + @" dc On (e.id = dc.elementid)
                        Inner Join " + Device.TableName + @" d            On (d.id = dc.deviceid) 
                    WHERE 
                        s.id = @sbid
                    ORDER BY 
                        s.name  Asc,
                        d.name  Asc,
                        dc.name Asc";

            this.SetParameter("sbid", switchboardId);

            ds.Tables.Add(this.ExecuteDataTable(sql));
            ds.Tables[0].TableName = "Connections";

            return ds;
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

      ///// <summary>
      ///// Get a list of all decoder models.
      ///// </summary>
      ///// <returns>A list of <see cref="String"/> filled with the requested data.</returns>
      //public List<String> GetAllModels()
      //{
      //   string sql = string.Empty;
      //   List<string> items = new List<string>();

      //   Logger.LogDebug(this, "[CLASS].GetAllModels()");

      //   try
      //   {
      //      Connect();

      //      sql = @"SELECT DISTINCT 
      //                  model          As ""Model""
      //              FROM 
      //                  " + DeviceDAO.SQL_TABLE + @" 
      //              WHERE 
      //                  model <> '' 
      //              ORDER BY 
      //                  model Asc";

      //      using (SQLiteDataReader reader = ExecuteReader(sql))
      //      {
      //         while (reader.Read())
      //         {
      //            if (!reader.IsDBNull(0))
      //            {
      //               items.Add(reader.GetString(0));
      //            }
      //         }
      //      }

      //      return items;
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

      //      /// <summary>
      //      /// Get a list of all decoder manufacturers.
      //      /// </summary>
      //      /// <returns>A list of <see cref="String"/> filled with the requested data.</returns>
      //      public List<String> GetAllManufacturers()
      //      {
      //         string sql = string.Empty;
      //         List<string> items = new List<string>();

      //         Logger.LogDebug(this, "[CLASS].GetAllManufacturers()");

      //         try
      //         {
      //            Connect();

      //            sql = @"SELECT DISTINCT 
      //                        manufacturer   As ""Manufacturer""
      //                    FROM 
      //                        " + DeviceDAO.SQL_TABLE + @" 
      //                    WHERE 
      //                        manufacturer <> '' 
      //                    ORDER BY 
      //                        manufacturer Asc";

      //            using (SQLiteDataReader reader = ExecuteReader(sql))
      //            {
      //               while (reader.Read())
      //               {
      //                  if (!reader.IsDBNull(0))
      //                  {
      //                     items.Add(reader.GetString(0));
      //                  }
      //               }
      //            }

      //            return items;
      //         }
      //         catch (Exception ex)
      //         {
      //            Logger.LogError(this, ex);

      //            throw;
      //         }
      //         finally
      //         {
      //            Disconnect();
      //         }
      //      }

      //      /// <summary>
      //      /// Check if a digital address is used.
      //      /// </summary>
      //      /// <param name="address">Address to check.</param>
      //      /// <param name="type">Type of address.</param>
      //      /// <returns><c>true</c> if the address is used or <c>false</c> if the address is free.</returns>
      //      public bool IsAddressUsed(int address, Device.DeviceType type)
      //      {
      //         string sql = string.Empty;

      //         Logger.LogDebug(this, "[CLASS].IsAddressUsed({0}, {1})", address, type);

      //         try
      //         {
      //            Connect();

      //            sql = @"SELECT DISTINCT 
      //                        Count(*) 
      //                    FROM 
      //                        " + DeviceDAO.SQL_TABLE + @" 
      //                    WHERE 
      //                        address = @address And 
      //                        type = @type";

      //            SetParameter("address", address);
      //            SetParameter("type", (int)type);

      //            return (ExecuteScalar(sql) > 0);
      //         }
      //         catch (Exception ex)
      //         {
      //            Logger.LogError(this, ex);

      //            throw;
      //         }
      //         finally
      //         {
      //            Disconnect();
      //         }
      //      }

      ///// <summary>
      ///// Read a category from the current reader record.
      ///// </summary>
      //public Device ReadEntityRecord(SQLiteDataReader reader)
      //{
      //   Device record = new Device();
      //   record.ID = reader.GetInt32(0);
      //   record.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
      //   record.Manufacturer = null; //  reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
      //   record.Model = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
      //   record.Outputs = reader.IsDBNull(4) ? 1 : reader.GetInt32(4);
      //   record.StartAddress = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
      //   record.Type = reader.IsDBNull(6) ? Device.DeviceType.AccessoryDecoder : (Device.DeviceType)reader.GetInt32(6);
      //   record.Notes = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);

      //   return record;
      //}

      #endregion

   }
}
