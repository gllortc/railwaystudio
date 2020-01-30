using Rwm.Otc.Configuration;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.LayoutControl.Elements;
using Rwm.Otc.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Rwm.Otc.LayoutControl
{
   /// <summary>
   /// Manage the connections between blocks and control modules.
   /// </summary>
   public class ControlModuleConnectionManager : DataEntity
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = "accessoryoutputs";
      internal static string SQL_FIELDS_SELECT = "id, [index], decoderid, blockid, name, address, output, switchtime, out1, out2";
      internal static string SQL_FIELDS_INSERT = "[index], decoderid, blockid, name, address, output, switchtime, out1, out2";

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="ControlModuleConnectionManager"/>.
      /// </summary>
      /// <param name="settings">The current application settings.</param>
      public ControlModuleConnectionManager(XmlSettingsManager settings) : base(settings) { }

      #endregion

      #region Methods

      /// <summary>
      /// Adds a new output to an existing decoder.
      /// </summary>
      /// <param name="connection">An instance of <see cref="ControlModuleConnection"/> containing the data for the new connection.</param>
      public void Add(ControlModuleConnection connection)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Add([{0}])", connection);

         try
         {
            // Check if related module exists
            CheckDecoderExists(connection);

            Connect();

            // Añade el registro
            sql = @"INSERT INTO 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" (" + ControlModuleConnectionManager.SQL_FIELDS_INSERT + @") 
                    VALUES 
                        (@index, @decoderid, @blockid, @name, @address, @output, @switchtime, @out1, @out2)";

            SetParameter("index", connection.Index);
            SetParameter("decoderid", connection.DecoderID);
            SetParameter("blockid", connection.ElementID);
            SetParameter("name", connection.Name);
            SetParameter("address", connection.Address);
            SetParameter("output", connection.Output);
            SetParameter("switchtime", connection.SwitchTime);
            SetParameter("out1", connection.OutputMap.Map);
            SetParameter("out2", connection.Output2);

            ExecuteNonQuery(sql);

            // Obtiene el nuevo ID
            sql = @"SELECT 
                        Max(id) As id 
                    FROM 
                        " + ControlModuleConnectionManager.SQL_TABLE;

            connection.ID = (int)ExecuteScalar(sql);
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
      /// Update the specified connection.
      /// </summary>
      /// <param name="connection">An instance with the updated data.</param>
      public void Update(ControlModuleConnection connection)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Update([{0}])", connection);

         try
         {
            // Check if related decoder exists
            CheckDecoderExists(connection);

            Connect();

            sql = @"UPDATE 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" 
                    SET 
                        [index]    = @index,
                        decoderid  = @decoderid, 
                        blockid    = @blockid, 
                        name       = @name, 
                        address    = @address, 
                        output     = @output, 
                        switchtime = @switchtime, 
                        out1       = @out1, 
                        out2       = @out2
                    WHERE 
                        id = @id";

            SetParameter("index", connection.Index);
            SetParameter("decoderid", connection.DecoderID);
            SetParameter("blockid", connection.ElementID);
            SetParameter("name", connection.Name);
            SetParameter("address", connection.Address);
            SetParameter("output", connection.Output);
            SetParameter("switchtime", connection.SwitchTime);
            SetParameter("out1", connection.OutputMap.Map);
            SetParameter("out2", connection.Output2);
            SetParameter("id", connection.ID);

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
      /// Update the specified connection address.
      /// </summary>
      /// <param name="outputId">Output unique identifier (DB).</param>
      /// <param name="address">Address to set.</param>
      public void UpdateAddress(long outputId, long address)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].UpdateAddress({0}, {1})", outputId, address);

         try
         {
            Connect();

            sql = @"UPDATE 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" 
                    SET 
                        address = @address 
                    WHERE 
                        id = @id";

            SetParameter("address", address);
            SetParameter("id", outputId);

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
      /// Delete the specified decoder output.
      /// </summary>
      /// <param name="id">Decoder output unique identifier (DB).</param>
      public void Delete(int id)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Delete({0})", id);

         try
         {
            Connect();

            sql = @"DELETE 
                    FROM 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" 
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
      /// Get the requestes connection.
      /// </summary>
      /// <param name="id">Connection unique identifier (DB).</param>
      /// <returns>The requested instance of <see cref="ControlModuleConnection"/> or <c>null</c> if the connection cannot be found.</returns>
      public ControlModuleConnection GetByID(Int32 id)
      {
         return GetByID((Int64)id);
      }

      /// <summary>
      /// Get the requestes connection.
      /// </summary>
      /// <param name="id">Connection unique identifier (DB).</param>
      /// <returns>The requested instance of <see cref="ControlModuleConnection"/> or <c>null</c> if the connection cannot be found.</returns>
      public ControlModuleConnection GetByID(Int64 id)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].GetByID({0})", id);

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ControlModuleConnectionManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" 
                    WHERE 
                        id = @id";

            SetParameter("id", id);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  return ControlModuleConnectionManager.ReadEntityRecord(reader);
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
      /// <param name="decoderId">The switchboard panel unique identifier (DB).</param>
      /// <returns>The requested list of <see cref="ElementBase"/>.</returns>
      public List<ControlModuleConnection> GetByDecoder(int decoderId)
      {
         string sql = string.Empty;
         ControlModule module = null;
         ControlModuleConnection item = null;
         List<ControlModuleConnection> items = new List<ControlModuleConnection>();

         Logger.LogDebug(this, "[CLASS].GetByDecoder({0})", decoderId);

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ControlModuleManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ControlModuleManager.SQL_TABLE + @" 
                    WHERE 
                        id = @id";

            SetParameter("id", decoderId);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  module = ControlModuleManager.ReadEntityRecord(reader);
               }
            }

            if (module == null)
            {
               return items;
            }

            sql = @"SELECT 
                        " + ControlModuleConnectionManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" 
                    WHERE 
                        decoderid = @decoderid 
                    ORDER BY 
                        name";

            SetParameter("decoderid", decoderId);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  item = ControlModuleConnectionManager.ReadEntityRecord(reader);
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
      /// Gets all connections for the specified element.
      /// </summary>
      /// <param name="element">Element.</param>
      /// <returns>The requested list of <see cref="ControlModuleConnection"/> related to the specified element.</returns>
      public ControlModuleConnection[] GetByElement(ElementBase element)
      {
         return this.GetByElement(element, ControlModule.ModuleType.Undefined);
      }

      /// <summary>
      /// Gets connections of the specified type for the specified element.
      /// </summary>
      /// <param name="element">Element.</param>
      /// <param name="type">Type of element.</param>
      /// <returns>The requested list of <see cref="ControlModuleConnection"/> related to the specified element.</returns>
      public ControlModuleConnection[] GetByElement(ElementBase element, ControlModule.ModuleType type)
      {
         string sql = string.Empty;
         ControlModuleConnection item = null;
         ControlModuleConnection[] items = null;

         Logger.LogDebug(this,
                         "[CLASS].GetByElement([{0}], {1})",
                         (element != null ? element.ID.ToString() : "null"), type);

         // Return an empty array if element is null or doesn't have outputs
         if (element == null)
         {
            return new ControlModuleConnection[0];
         }
         else if (type == ControlModule.ModuleType.Accessory && (element.AccessoryConnections == null || element.AccessoryConnections.Length <= 0))
         {
            return new ControlModuleConnection[0];
         }
         else if (type == ControlModule.ModuleType.Sensor && (element.FeedbackConnections == null || element.FeedbackConnections.Length <= 0))
         {
            return new ControlModuleConnection[0];
         }

         try
         {
            switch (type)
            {
               case ControlModule.ModuleType.Accessory:
                  items = new ControlModuleConnection[element.AccessoryConnections.Length];
                  break;

               case ControlModule.ModuleType.Sensor:
                  items = new ControlModuleConnection[element.FeedbackConnections.Length];
                  break;
            }

            Connect();

            sql = @"SELECT 
                        " + ControlModuleConnectionManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" con 
                    WHERE 
                        blockid = @blockid And 
                        @type   = (SELECT type 
                                   FROM   " + ControlModuleManager.SQL_TABLE + @" deco 
                                   WHERE  con.decoderid = deco.id) 
                    ORDER BY 
                        [index] Asc,
                        id      Asc";

            SetParameter("blockid", element.ID);
            SetParameter("type", (int)type);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  item = ControlModuleConnectionManager.ReadEntityRecord(reader);
                  if (item != null && item.Index <= items.Length)
                  {
                     items[item.Index - 1] = item;
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
      /// Gets all connection for the specified element.
      /// </summary>
      /// <returns>The requested list of <see cref="ControlModuleConnection"/> related to the specified element.</returns>
      public List<ControlModuleConnection> GetDuplicated()
      {
         string sql = string.Empty;
         ControlModuleConnection item = null;
         List<long> repeated = new List<long>();
         List<ControlModuleConnection> items = new List<ControlModuleConnection>();

         Logger.LogDebug(this, "[CLASS].GetDuplicated()");

         try
         {
            Connect();

            // Get repeated addresses
            sql = @"SELECT 
                        address, 
                        COUNT(*) c 
                    FROM 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" 
                    GROUP BY 
                        address 
                    HAVING 
                        c > 1;";

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  repeated.Add(reader.GetInt64(0));
               }
            }

            // Get connections with repeated addresses
            sql = @"SELECT 
                        " + ControlModuleConnectionManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" 
                    WHERE 
                        address in (@lst) 
                    ORDER BY 
                        id";

            SetParameter("lst", StringUtils.ListToString(repeated));

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  item = ControlModuleConnectionManager.ReadEntityRecord(reader);
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
      /// Gets all connections using the same digital address.
      /// </summary>
      /// <param name="address">Digital address.</param>
      /// <returns>The requested list of <see cref="ControlModuleConnection"/> related to the specified address.</returns>
      public List<ControlModuleConnection> GetDuplicated(int address)
      {
         string sql = string.Empty;
         ControlModuleConnection item = null;
         List<long> repeated = new List<long>();
         List<ControlModuleConnection> items = new List<ControlModuleConnection>();

         Logger.LogDebug(this, "[CLASS].GetDuplicated({0})", address);

         try
         {
            Connect();

            // Get repeated addresses
            sql = @"SELECT 
                        address, 
                        COUNT(*) c 
                    FROM 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" 
                    GROUP BY 
                        address 
                    HAVING 
                        c > 1 And
                        address = @address;";

            SetParameter("address", address);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  repeated.Add(reader.GetInt64(0));
               }
            }

            // Get connections with repeated addresses
            sql = @"SELECT 
                        " + ControlModuleConnectionManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" 
                    WHERE 
                        address = @address 
                    ORDER BY 
                        id";

            SetParameter("address", address);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  item = ControlModuleConnectionManager.ReadEntityRecord(reader);
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
      /// Get all connections of the specified module.
      /// </summary>
      /// <param name="module">Module.</param>
      /// <returns></returns>
      public System.Data.DataTable FindByModule(ControlModule module)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].FindByModule({0})", module);

         try
         {
            Connect();

            sql = @"SELECT DISTINCT 
                        ao.id       As ""#ID"", 
                        ao.name     As ""Output"", 
                        b.name      As ""Block"", 
                        ao.address  As ""Address"", 
                        ao.blockid  As ""BlockID""
                    FROM 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" ao 
                        LEFT JOIN " + ElementManager.SQL_TABLE + @" b On ao.blockid = b.id 
                    WHERE 
                        ao.decoderid = @decoderid 
                    ORDER BY 
                        ao.name  Asc, 
                        ao.[index] Asc";

            SetParameter("decoderid", module.ID);

            System.Data.DataTable dt = ExecuteDataTable(sql);

            foreach (DataRow row in dt.Rows)
            {
               if ((Int64)row[4] == 0)
               {
                  row[2] = "<empty>";
               }
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

      /// <summary>
      /// Gets connections of the specified type for the specified element.
      /// </summary>
      /// <param name="element">Element.</param>
      /// <param name="type">Type of control module.</param>
      /// <returns>The requested list of <see cref="ControlModuleConnection"/> related to the specified element.</returns>
      public System.Data.DataTable FindByElement(ElementBase element, ControlModule.ModuleType type)
      {
         int items = 0;
         string sql = string.Empty;
         DataRow row = null;

         Logger.LogDebug(this,
                         "[CLASS].FindByElement([{0}], {1})",
                         (element != null ? element.ID.ToString() : "null"), type);

         // Return an empty array if element is null or doesn't have outputs
         if (element == null)
         {
            return null;
         }
         else if (type == ControlModule.ModuleType.Accessory && (element.AccessoryConnections == null || element.AccessoryConnections.Length <= 0))
         {
            return null;
         }
         else if (type == ControlModule.ModuleType.Sensor && (element.FeedbackConnections == null || element.FeedbackConnections.Length <= 0))
         {
            return null;
         }

         try
         {
            switch (type)
            {
               case ControlModule.ModuleType.Accessory:
                  items = element.AccessoryConnections.Length;
                  break;

               case ControlModule.ModuleType.Sensor:
                  items = element.FeedbackConnections.Length;
                  break;
            }

            // Generate the data table
            System.Data.DataTable dt = new System.Data.DataTable("Connections");
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Index", typeof(int));
            dt.Columns.Add("Module", typeof(string));
            dt.Columns.Add("Output", typeof(string));
            dt.Columns.Add("Address", typeof(int));

            // Fill table with empty rows
            for (int i = 0; i < items; i++)
            {
               dt.Rows.Add(0, 0, "Not connected", string.Empty, 0);
            }

            Connect();

            sql = @"SELECT 
                        cmc.id, 
                        cmc.[index], 
                        cm.name, 
                        cmc.name, 
                        cmc.address
                    FROM 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" cmc 
                        Inner Join " + ControlModuleManager.SQL_TABLE + @" cm On (cm.""id"" = cmc.""decoderid"") 
                    WHERE 
                        blockid = @blockid And 
                        @type   = (SELECT type 
                                   FROM   " + ControlModuleManager.SQL_TABLE + @" deco 
                                   WHERE  cmc.decoderid = deco.id) 
                    ORDER BY 
                        cmc.[index] Asc,
                        cmc.id      Asc";

            SetParameter("blockid", element.ID);
            SetParameter("type", (int)type);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  // Update the row data
                  row = dt.Rows[reader.GetInt32(1) - 1];
                  row.ItemArray = new object[] 
                  {
                     reader.GetInt32(0), 
                     reader.GetInt32(1), 
                     reader.GetString(2), 
                     reader.GetString(3),
                     reader.GetInt32(4)
                  };
               }
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

      /// <summary>
      /// Get next free address.
      /// </summary>
      /// <param name="type">Type of element.</param>
      /// <returns>An integer value indicating the </returns>
      public int GetNextFree(ControlModule.ModuleType type)
      {
         long idx = 0;
         long numAdds = 0;
         long[] adds = null;
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].GetNextFree({0})", type);

         try
         {
            Connect();

            sql = @"SELECT DISTINCT 
                        Max(address) 
                    FROM 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" 
                    WHERE 
                        address > 0";

            numAdds = ExecuteScalar(sql);

            if (numAdds <= 0)
            {
               return 1;
            }

            // Generate an empty vector to store addresses
            adds = new long[numAdds];
            for (int i = 0; i < numAdds; i++) adds[i] = 0;

            sql = @"SELECT DISTINCT 
                        address 
                    FROM 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" 
                    WHERE 
                        address > 0";

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  idx = reader.GetInt64(0);
                  adds[idx - 1] = idx;
               }
            }

            for (int i = 0; i < numAdds; i++)
            {
               if (adds[i] == 0)
               {
                  return i + 1;
               }
            }

            return 1;
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
      /// Update the specified connection.
      /// </summary>
      /// <param name="connectionId">Connection unique identifier (DB).</param>
      /// <param name="connectionIndex">Index of the connection in the control.</param>
      /// <param name="element">Element unique identifier (DB).</param>
      public void Assign(int connectionId, int connectionIndex, IAccessory element)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Assign({0}, {1}, {2})", connectionId, connectionIndex, element.ID);

         try
         {
            Connect();

            sql = @"UPDATE 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" 
                    SET 
                        blockid = @blockid, 
                        [index] = @index, 
                        out1    = @out1
                    WHERE 
                        id = @id";

            SetParameter("blockid", element.ID);
            SetParameter("index", connectionIndex);
            SetParameter("out1", element.GetDefaultConnectionMap(connectionIndex).Map);
            SetParameter("id", connectionId);

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
      /// Update the specified connection.
      /// </summary>
      /// <param name="connectionId">Connection unique identifier (DB).</param>
      public void Unassign(int connectionId)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Unassign({0})", connectionId);

         try
         {
            Connect();

            sql = @"UPDATE 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" 
                    SET 
                        blockid = 0, 
                        [index] = 0
                    WHERE 
                        id = @id";

            SetParameter("id", connectionId);

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
      /// Update the specified connection.
      /// </summary>
      /// <param name="coordinates">An instance with the updated data.</param>
      public void Unassign(Coordinates coordinates)
      {
         string sql = string.Empty;
         ElementBase element = null;

         Logger.LogDebug(this, "[CLASS].Unassign([{0}])", coordinates);

         // Get the associated element in the specified position
         ElementManager bManager = new ElementManager(this.Settings);
         element = bManager.GetByCoordinates(coordinates);
         if (element == null)
         {
            return;
         }

         // Unassign selected element
         this.Unassign(element);
      }

      /// <summary>
      /// Update the specified connection.
      /// </summary>
      /// <param name="element">An instance with the updated data.</param>
      public void Unassign(ElementBase element)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Unassign([{0}])", element);

         try
         {
            Connect();

            sql = @"UPDATE 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" 
                    SET 
                        blockid = 0, 
                        [index] = 0,
                        out1    = 0
                    WHERE 
                        blockid = @blockid";

            SetParameter("blockid", element.ID);

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
      /// Update the specified connection.
      /// </summary>
      /// <param name="connection">An instance with the updated data.</param>
      public void SetConnectionMap(ControlModuleConnection connection)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].SetConnectionMap([{0}])", connection);

         try
         {
            // Check if related decoder exists
            CheckDecoderExists(connection);

            Connect();

            sql = @"UPDATE 
                        " + ControlModuleConnectionManager.SQL_TABLE + @" 
                    SET 
                        out1 = @out1
                    WHERE 
                        id = @id";

            SetParameter("out1", connection.OutputMap.Map);
            SetParameter("id", connection.ID);

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

      #endregion

      #region Private Members

      /// <summary>
      /// Read a category from the current reader record.
      /// </summary>
      internal static ControlModuleConnection ReadEntityRecord(SQLiteDataReader reader)
      {
         ControlModuleConnection record = new ControlModuleConnection();
         record.ID = reader.GetInt32(0);
         record.Index = reader.GetInt32(1);
         record.DecoderID = reader.GetInt32(2);
         record.ElementID = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
         record.Name = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
         record.Address = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
         record.Output = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
         record.SwitchTime = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
         record.OutputMap = new ConnectionMap(reader.IsDBNull(8) ? 0 : reader.GetInt32(8));
         record.Output2 = reader.IsDBNull(9) ? ControlModuleConnection.DecoderFunctionOutputStatus.Unknown : (ControlModuleConnection.DecoderFunctionOutputStatus)reader.GetInt32(9);

         return record;
      }

      private void CheckDecoderExists(ControlModuleConnection output)
      {
         // Check if the decoder is informed
         if (output.DecoderID <= 0)
         {
            throw new LayoutConfigurationException("Cannot create a decoder output without related decoder.");
         }

         // Check if the decoder is in database
         ControlModuleManager decManager = new ControlModuleManager(this.Settings);
         if (decManager.GetByID(output.DecoderID) == null)
         {
            throw new LayoutConfigurationException("Cannot create a decoder output: related decoder #{0} not found.", output.DecoderID);
         }
      }

      private int GetFreeNumber(System.Data.DataTable dt, int startNumber)
      {
         if (startNumber < 1)
         {
            startNumber = 1;
         }

         foreach (DataRow row in dt.Rows)
         {
            if ((Int64)row[0] == startNumber)
            {
               startNumber = GetFreeNumber(dt, startNumber + 1);
               break;
            }
         }

         return startNumber;
      }

      private string GetFreeNumber(List<ControlModuleConnection> connections, int startNumber)
      {
         if (startNumber < 1)
         {
            startNumber = 1;
         }

         foreach (ControlModuleConnection row in connections)
         {
            if (row.Name.Equals(startNumber.ToString()))
            {
               startNumber = int.Parse(GetFreeNumber(connections, startNumber + 1));
               break;
            }
         }

         return startNumber.ToString();
      }

      #endregion

   }
}
