using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Rwm.Otc.LayoutControl
{
   public class SensorInputManager : Data.DataEntity
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = "accessoryoutputs";
      internal static string SQL_FIELDS_SELECT = "id, decoderid, blockid, name, address, switchtime, out1, out2";
      internal static string SQL_FIELDS_INSERT = "decoderid, blockid, name, address, switchtime, out1, out2";

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="SensorInputManager"/>.
      /// </summary>
      /// <param name="settings">The current application settings.</param>
      public SensorInputManager(XmlSettingsManager settings) : base(settings) { }

      #endregion

      #region Methods

      /// <summary>
      /// Adds a new output to an existing decoder.
      /// </summary>
      /// <param name="output">An instance of <see cref="SwitchboardPanel"/> containing the data for the new panel.</param>
      public void Add(ModuleConnection output)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Add([{0}])", output);

         try
         {
            // Check if related decoder exists
            CheckDecoderExists(output);

            Connect();

            output.ID = (int)ExecuteScalar(sql);

            // Añade el registro
            sql = @"INSERT INTO 
                        " + ModuleConnectionManager.SQL_TABLE + @" (" + ModuleConnectionManager.SQL_FIELDS_INSERT + @") 
                    VALUES 
                        (@decoderid, @blockid, @name, @address, @switchtime, @out1, @out2)";

            SetParameter("decoderid", output.DecoderID);
            SetParameter("blockid", output.BlockID);
            SetParameter("name", output.Name);
            SetParameter("address", output.Address);
            SetParameter("switchtime", output.SwitchTime);
            SetParameter("out1", output.Output1);
            SetParameter("out2", output.Output2);

            ExecuteNonQuery(sql);

            // Obtiene el nuevo ID
            sql = @"SELECT 
                        Max(id) As id 
                    FROM 
                        " + ModuleConnectionManager.SQL_TABLE;

            output.ID = (int)ExecuteScalar(sql);
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
      /// <param name="output">An instance with the updated data.</param>
      public void Update(ModuleConnection output)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Update([{0}])", output);

         try
         {
            // Check if related decoder exists
            CheckDecoderExists(output);

            Connect();

            sql = @"UPDATE 
                        " + ModuleConnectionManager.SQL_TABLE + @" 
                    SET 
                        decoderid = @decoderid, 
                        blockid = @blockid, 
                        name = @name, 
                        address = @address, 
                        switchtime = @switchtime, 
                        out1 = @out1, 
                        out2 = @out2
                    WHERE 
                        id = @id";

            SetParameter("decoderid", output.DecoderID);
            SetParameter("blockid", output.BlockID);
            SetParameter("name", output.Name);
            SetParameter("address", output.Address);
            SetParameter("switchtime", output.SwitchTime);
            SetParameter("out1", output.Output1);
            SetParameter("out2", output.Output2);
            SetParameter("id", output.ID);

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
                        " + ModuleConnectionManager.SQL_TABLE + @" 
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
      /// Recupera las propiedades de un fabricante.
      /// </summary>
      /// <param name="itemid">Identificador.</param>
      /// <returns>Una instáncia de RCManufacturer.</returns>
      public ModuleConnection GetByID(Int32 itemId)
      {
         return GetByID((Int32)itemId);
      }

      /// <summary>
      /// Recupera las propiedades de una Administración/Operadora.
      /// </summary>
      /// <param name="itemid">Identificador.</param>
      /// <returns>Una instáncia de RCAdministration.</returns>
      public ModuleConnection GetByID(Int64 id)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].GetByID({0})", id);

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ModuleConnectionManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ModuleConnectionManager.SQL_TABLE + @" 
                    WHERE 
                        id = @id";

            SetParameter("id", id);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  return ModuleConnectionManager.ReadEntityRecord(reader);
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
      /// <returns>The requested list of <see cref="BlockBase"/>.</returns>
      public List<ModuleConnection> GetByDecoder(int decoderId)
      {
         string sql = string.Empty;
         ModuleConnection item = null;
         List<ModuleConnection> items = new List<ModuleConnection>();

         Logger.LogDebug(this, "[CLASS].GetByDecoder({0})", decoderId);

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ModuleConnectionManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ModuleConnectionManager.SQL_TABLE + @" 
                    WHERE 
                        panelid = @panelid";

            SetParameter("panelid", decoderId);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  item = ModuleConnectionManager.ReadEntityRecord(reader);
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
      /// <param name="moduleId">Module unique identifier (DB).</param>
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
                        " + ModuleConnectionManager.SQL_TABLE + @" ao
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
      internal static ModuleConnection ReadEntityRecord(SQLiteDataReader reader)
      {
         ModuleConnection record = new ModuleConnection();
         record.ID = reader.GetInt32(0);
         record.DecoderID = reader.GetInt32(1);
         record.BlockID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
         record.Name = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
         record.Address = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
         record.SwitchTime = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
         record.Output1 = reader.IsDBNull(6) ? ModuleConnection.DecoderFunctionOutputStatus.Unknown : (ModuleConnection.DecoderFunctionOutputStatus)reader.GetInt32(6);
         record.Output2 = reader.IsDBNull(7) ? ModuleConnection.DecoderFunctionOutputStatus.Unknown : (ModuleConnection.DecoderFunctionOutputStatus)reader.GetInt32(7);

         return record;
      }

      private void CheckDecoderExists(ModuleConnection output)
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

      #endregion

   }
}
