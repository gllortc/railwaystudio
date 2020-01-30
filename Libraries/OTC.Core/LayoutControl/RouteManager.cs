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
   /// Manage the switchboard panels persistence in project database.
   /// </summary>
   public class RouteManager : DataEntity
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = "routes";
      internal static string SQL_FIELDS_SELECT = "id, name, description, fromBlock, toBlock";
      internal static string SQL_FIELDS_INSERT = "name, description, fromBlock, toBlock";

      internal static string SQL_BLOCK_TABLE = "routeblocks";
      internal static string SQL_BLOCK_FIELDS_SELECT = "id, routeid, blockid, status";
      internal static string SQL_BLOCK_FIELDS_INSERT = "routeid, blockid, status";

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="RouteManager"/>.
      /// </summary>
      /// <param name="app">The current application settings.</param>
      public RouteManager(XmlSettingsManager settings) : base(settings) { }

      #endregion

      #region Methods

      /// <summary>
      /// Adds a new route into the current project.
      /// </summary>
      /// <param name="route">The instance of <see cref="Route"/> corresponding to the new route.</param>
      public void Add(Route route)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Add([{0}])", route);

         try
         {
            Connect();

            // Añade el registro
            sql = @"INSERT INTO 
                        " + RouteManager.SQL_TABLE + @" (" + RouteManager.SQL_FIELDS_INSERT + @") 
                    VALUES 
                        (@name, @description, @fromBlock, @toBlock)";

            SetParameter("name", route.Name);
            SetParameter("description", route.Description);
            SetParameter("fromBlock", route.FromBlock != null ? route.FromBlock.ID : 0);
            SetParameter("toBlock", route.ToBlock != null ? route.ToBlock.ID : 0);

            ExecuteNonQuery(sql);

            // Obtiene el nuevo ID
            sql = @"SELECT 
                        Max(id) As id 
                    FROM 
                        " + RouteManager.SQL_TABLE;

            route.ID = (int)ExecuteScalar(sql);

            foreach (RouteElement element in route.Elements)
            {
               // Update the route information on element
               element.RouteID = route.ID;

               // Añade el registro
               sql = @"INSERT INTO 
                           " + RouteManager.SQL_BLOCK_TABLE + @" (" + RouteManager.SQL_BLOCK_FIELDS_INSERT + @") 
                       VALUES 
                           (@routeid, @blockid, @status)";

               SetParameter("routeid", route.ID);
               SetParameter("blockid", element.ElementID);
               SetParameter("status", element.AccessoryStatus);

               ExecuteNonQuery(sql);

               // Obtiene el nuevo ID
               sql = @"SELECT 
                           Max(id) As id 
                       FROM 
                           " + RouteManager.SQL_BLOCK_TABLE;

               element.ID = (int)ExecuteScalar(sql);
               element.RouteID = route.ID;
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
      /// Update the specified route data.
      /// </summary>
      /// <param name="route">An instance with the updated data.</param>
      public void Update(Route route)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Update([{0}])", route);

         try
         {
            Connect();

            // Update the record data
            sql = @"UPDATE 
                        " + RouteManager.SQL_TABLE + @" 
                    SET 
                        name        = @name, 
                        description = @description, 
                        fromBlock   = @fromBlock, 
                        toBlock     = @toBlock 
                    WHERE 
                        id = @id";

            SetParameter("name", route.Name);
            SetParameter("description", route.Description);
            SetParameter("fromBlock", route.FromBlock != null ? route.FromBlock.ID : 0);
            SetParameter("toBlock", route.ToBlock != null ? route.ToBlock.ID : 0);
            SetParameter("id", route.ID);

            ExecuteNonQuery(sql);

            // Delete all related blocks
            sql = @"DELETE 
                    FROM 
                        " + RouteManager.SQL_BLOCK_TABLE + @" 
                    WHERE 
                        routeid = @routeid";

            SetParameter("routeid", route.ID);

            ExecuteNonQuery(sql);

            // Re-insert all blocks
            foreach (RouteElement element in route.Elements)
            {
               // Añade el registro
               sql = @"INSERT INTO 
                           " + RouteManager.SQL_BLOCK_TABLE + @" (" + RouteManager.SQL_BLOCK_FIELDS_INSERT + @") 
                       VALUES 
                           (@routeid, @blockid, @status)";

               SetParameter("routeid", route.ID);
               SetParameter("blockid", element.ElementID);
               SetParameter("status", element.AccessoryStatus);

               ExecuteNonQuery(sql);

               // Obtiene el nuevo ID
               sql = @"SELECT 
                           Max(id) As id 
                       FROM 
                           " + RouteManager.SQL_BLOCK_TABLE;

               element.ID = (int)ExecuteScalar(sql);
               element.RouteID = route.ID;
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
      /// Delete the specified route.
      /// </summary>
      /// <param name="id">Route unique identifier (DB).</param>
      public void Delete(Int32 id)
      {
         this.Delete((Int64)id);
      }

      /// <summary>
      /// Delete the specified route.
      /// </summary>
      /// <param name="id">Route unique identifier (DB).</param>
      public void Delete(Int64 id)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Delete({0})", id);

         try
         {
            Connect();

            // Delete all related blocks
            sql = @"DELETE 
                    FROM 
                        " + RouteManager.SQL_BLOCK_TABLE + @" 
                    WHERE 
                        routeid = @routeid";

            SetParameter("routeid", id);
            ExecuteNonQuery(sql);

            // Delete the route
            sql = @"DELETE 
                    FROM 
                        " + RouteManager.SQL_TABLE + @" 
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
      public Route GetByID(Int32 id)
      {
         return GetByID((Int64)id);
      }

      /// <summary>
      /// Returns the specified route from database.
      /// </summary>
      /// <param name="id">The route unique identifier (DB).</param>
      /// <returns>The requested <see cref="Route"/> instance filled with all data.</returns>
      public Route GetByID(Int64 id)
      {
         string sql = string.Empty;
         Route item = null;
         RouteElement subitem = null;

         Logger.LogDebug(this, "[CLASS].GetByID({0})", id);

         try
         {
            Connect();

            // Get the route
            sql = @"SELECT 
                        " + RouteManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + RouteManager.SQL_TABLE + @" 
                    WHERE 
                        id = @id";

            SetParameter("id", id);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  item = RouteManager.ReadEntityRecord(reader);
               }
            }

            if (item == null) return null;

            // Get the element status information
            sql = @"SELECT 
                        " + RouteManager.SQL_BLOCK_FIELDS_SELECT + @" 
                    FROM 
                        " + RouteManager.SQL_BLOCK_TABLE + @" 
                    WHERE 
                        routeid = @routeid";

            SetParameter("routeid", id);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  subitem = RouteManager.ReadSubentityRecord(reader);
                  if (subitem != null)
                  {
                     item.Elements.Add(subitem);
                  }
               }
            }

            // Get from/to elements
            if (item.FromBlockID > 0) item.FromBlock = OTCContext.Layout.ElementManager.GetByID(item.FromBlockID);
            if (item.ToBlockID > 0) item.ToBlock = OTCContext.Layout.ElementManager.GetByID(item.ToBlockID);

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
      /// Get all routes.
      /// </summary>
      /// <returns>The requested list filled with information.</returns>
      public List<Route> GetAll()
      {
         string sql = string.Empty;
         Route route = null;
         RouteElement elem = null;
         List<Route> routes = new List<Route>();

         Logger.LogDebug(this, "[CLASS].GetAll()");

         try
         {
            Connect();

            sql = @"SELECT 
                        " + RouteManager.SQL_FIELDS_SELECT + @"
                    FROM 
                        " + RouteManager.SQL_TABLE + @" 
                    ORDER BY 
                        name";

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  route = RouteManager.ReadEntityRecord(reader);
                  if (route != null)
                  {
                     routes.Add(route);
                  }
               }
            }

            // Get route element status information
            foreach (Route rout in routes)
            {
               sql = @"SELECT 
                        " + RouteManager.SQL_BLOCK_FIELDS_SELECT + @" 
                    FROM 
                        " + RouteManager.SQL_BLOCK_TABLE + @" 
                    WHERE 
                        routeid = @routeid";

               SetParameter("routeid", rout.ID);

               using (SQLiteDataReader reader = ExecuteReader(sql))
               {
                  while (reader.Read())
                  {
                     elem = RouteManager.ReadSubentityRecord(reader);
                     if (elem != null)
                     {
                        rout.Elements.Add(elem);
                     }
                  }
               }
            }

            // Get from/to elements
            foreach (Route rout in routes)
            {
               if (rout.FromBlockID > 0) rout.FromBlock = OTCContext.Layout.ElementManager.GetByID(rout.FromBlockID);
               if (rout.ToBlockID > 0) rout.ToBlock = OTCContext.Layout.ElementManager.GetByID(rout.ToBlockID);
            }

            return routes;
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
      /// Get all panels in an instance of <see cref="System.Data.DataTable"/>.
      /// </summary>
      /// <returns>The requested <see cref="System.Data.DataTable"/> filled with information.</returns>
      public System.Data.DataTable Find()
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Find()");

         try
         {
            Connect();

            sql = @"SELECT 
                        id          As '#ID', 
                        name        As 'Name', 
                        description As 'Description'
                    FROM 
                        " + RouteManager.SQL_TABLE + @" 
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
      /// Read a object from the current reader record.
      /// </summary>
      internal static Route ReadEntityRecord(SQLiteDataReader reader)
      {
         Route record = new Route();
         record.ID = reader.GetInt32(0);
         record.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
         record.Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
         record.FromBlockID = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
         record.ToBlockID = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);

         return record;
      }

      /// <summary>
      /// Read a object from the current reader record.
      /// </summary>
      internal static RouteElement ReadSubentityRecord(SQLiteDataReader reader)
      {
         RouteElement record = new RouteElement();
         record.ID = reader.GetInt32(0);
         record.RouteID = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
         record.ElementID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
         record.AccessoryStatus = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

         return record;
      }

      #endregion

   }
}
