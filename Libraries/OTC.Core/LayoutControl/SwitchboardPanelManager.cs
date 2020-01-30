using Rwm.Otc.Configuration;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.LayoutControl.Elements;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Rwm.Otc.LayoutControl
{

   /// <summary>
   /// Manage the switchboard panels persistence in project database.
   /// </summary>
   public class SwitchboardPanelManager : DataEntity
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = "panels";
      internal static string SQL_FIELDS_SELECT = "id, name, description, width, height";
      internal static string SQL_FIELDS_INSERT = "name, description, width, height";

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="AdministrationDAO"/>.
      /// </summary>
      /// <param name="app">Una instáncia de RCApplication.</param>
      public SwitchboardPanelManager(XmlSettingsManager settings) : base(settings) { }

      #endregion

      #region Methods

      /// <summary>
      /// Adds a new panel into the current project.
      /// </summary>
      /// <param name="panel">An instance of <see cref="SwitchboardPanel"/> containing the data for the new panel.</param>
      public void Add(SwitchboardPanel panel)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Add([{0}])", panel);

         try
         {
            Connect();

            // Añade el registro
            sql = @"INSERT INTO 
                        " + SwitchboardPanelManager.SQL_TABLE + @" (" + SwitchboardPanelManager.SQL_FIELDS_INSERT + @") 
                    VALUES 
                        (@name, @description, @width, @height)";

            SetParameter("name", panel.Name);
            SetParameter("description", panel.Description);
            SetParameter("width", panel.Width);
            SetParameter("height", panel.Height);

            ExecuteNonQuery(sql);

            // Obtiene el nuevo ID
            sql = @"SELECT 
                        Max(id) As id 
                    FROM 
                        " + SwitchboardPanelManager.SQL_TABLE;

            panel.ID = (int)ExecuteScalar(sql);
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
      /// Update the specified switchboard panel data.
      /// </summary>
      /// <param name="panel">An instance with the updated data.</param>
      public void Update(SwitchboardPanel panel)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Update([{0}])", panel);

         try
         {
            Connect();

            sql = @"UPDATE 
                        " + SwitchboardPanelManager.SQL_TABLE + @" 
                    SET 
                        name        = @name, 
                        description = @description, 
                        width       = @width,
                        height      = @height 
                    WHERE 
                        id = @id";

            SetParameter("name", panel.Name);
            SetParameter("description", panel.Description);
            SetParameter("width", panel.Width);
            SetParameter("height", panel.Height);
            SetParameter("id", panel.ID);

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
      public void Delete(int id)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Delete({0})", id);

         try
         {
            Connect();

            // Delete related blocks
            sql = @"DELETE 
                    FROM 
                        " + ElementManager.SQL_TABLE + @" 
                    WHERE 
                        panelid = @panelid";

            SetParameter("panelid", id);
            ExecuteNonQuery(sql);

            // Delete the switchboard panel
            sql = @"DELETE 
                    FROM 
                        " + SwitchboardPanelManager.SQL_TABLE + @" 
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
      /// Returns the specified switchboard panel from database.
      /// </summary>
      /// <param name="id">The switchboard panel unique identifier (DB).</param>
      /// <returns>The requested <see cref="SwitchboardPanel"/> instance filled with all data.</returns>
      public SwitchboardPanel GetByID(Int32 id)
      {
         return GetByID((Int64)id);
      }

      /// <summary>
      /// Returns the specified switchboard panel from database.
      /// </summary>
      /// <param name="id">The switchboard panel unique identifier (DB).</param>
      /// <returns>The requested <see cref="SwitchboardPanel"/> instance filled with all data.</returns>
      public SwitchboardPanel GetByID(Int64 id)
      {
         string sql = string.Empty;
         SwitchboardPanel item = null;

         Logger.LogDebug(this, "[CLASS].GetByID({0})", id);

         try
         {
            Connect();

            sql = @"SELECT 
                        " + SwitchboardPanelManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + SwitchboardPanelManager.SQL_TABLE + @" 
                    WHERE 
                        id = @id";

            SetParameter("id", id);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  item = ReadEntityRecord(reader);
               }
            }

            return item;
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
      /// Gets a panel by its name.
      /// </summary>
      /// <param name="name">The panel's name.</param>
      /// <returns>The requested instance of <see cref="SwitchboardPanel"/>.</returns>
      public SwitchboardPanel GetByName(string name)
      {
         string sql = string.Empty;
         SwitchboardPanel item = null;

         Logger.LogDebug(this, "[CLASS].GetByName({0})", name);

         try
         {
            Connect();

            sql = @"SELECT 
                        " + SwitchboardPanelManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + SwitchboardPanelManager.SQL_TABLE + @" 
                    WHERE 
                        LCase(name) = @name";

            SetParameter("name", name);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  item = SwitchboardPanelManager.ReadEntityRecord(reader);
               }
            }

            return item;
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
      /// Get all railway companies.
      /// </summary>
      /// <returns>The requested list filled with information.</returns>
      public List<SwitchboardPanel> GetAll()
      {
         string sql = string.Empty;
         SwitchboardPanel admin;
         List<SwitchboardPanel> admins = new List<SwitchboardPanel>();

         Logger.LogDebug(this, "[CLASS].GetAll()");

         try
         {
            Connect();

            sql = @"SELECT 
                        " + SwitchboardPanelManager.SQL_FIELDS_SELECT + @"
                    FROM 
                        " + SwitchboardPanelManager.SQL_TABLE + @" 
                    ORDER BY 
                        name";

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  admin = SwitchboardPanelManager.ReadEntityRecord(reader);
                  if (admin != null)
                  {
                     admins.Add(admin);
                  }
               }
            }

            return admins;
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
      /// Get all panels in an instance of <see cref="DataTable"/>.
      /// </summary>
      /// <returns>The requested <see cref="DataTable"/> filled with information.</returns>
      public System.Data.DataTable GetAllAsDataTable()
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].GetAllAsDataTable()");

         try
         {
            Connect();

            sql = @"SELECT 
                        id       As '#ID', 
                        name     As 'Name', 
                        width    As 'Width',
                        height   As 'Height'
                    FROM 
                        " + SwitchboardPanelManager.SQL_TABLE + @" 
                    ORDER BY 
                        name";

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

      #endregion

      #region Private Members

      /// <summary>
      /// Read a category from the current reader record.
      /// </summary>
      internal static SwitchboardPanel ReadEntityRecord(SQLiteDataReader reader)
      {
         SwitchboardPanel record = new SwitchboardPanel();
         record.ID = reader.GetInt32(0);
         record.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
         record.Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
         record.Width = reader.IsDBNull(3) ? 1 : reader.GetInt32(3);
         record.Height = reader.IsDBNull(4) ? 1 : reader.GetInt32(4);

         return record;
      }

      #endregion

   }
}
