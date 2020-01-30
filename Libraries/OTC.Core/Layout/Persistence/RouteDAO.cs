using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using System;

namespace Rwm.Otc.Layout.Persistence
{

   /// <summary>
   /// Manage the switchboard panels persistence in project database.
   /// </summary>
   public class RouteDAO : DataConsumer
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = "routes";
      internal static string SQL_FIELDS_SELECT = "id, name, description, fromBlock, toBlock, bidirectional";
      internal static string SQL_FIELDS_INSERT = "name, description, fromBlock, toBlock, bidirectional";

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="RouteDAO"/>.
      /// </summary>
      public RouteDAO() : base() { }

      #endregion

      #region Methods

//      /// <summary>
//      /// Adds a new route into the current project.
//      /// </summary>
//      /// <param name="route">The instance of <see cref="Route"/> corresponding to the new route.</param>
//      public void Add(Route route)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].Add([{0}])", route);

//         try
//         {
//            Connect();

//            // Añade el registro
//            sql = @"INSERT INTO 
//                        " + RouteDAO.SQL_TABLE + @" (" + RouteDAO.SQL_FIELDS_INSERT + @") 
//                    VALUES 
//                        (@name, @description, @fromBlock, @toBlock, @bidirectional)";

//            SetParameter("name", route.Name);
//            SetParameter("description", route.Description);
//            SetParameter("fromBlock", route.FromBlock != null ? route.FromBlock.ID : 0);
//            SetParameter("toBlock", route.ToBlock != null ? route.ToBlock.ID : 0);
//            SetParameter("bidirectional", route.IsBidirectionl);

//            ExecuteNonQuery(sql);

//            // Obtiene el nuevo ID
//            sql = @"SELECT 
//                        Max(id) As id 
//                    FROM 
//                        " + RouteDAO.SQL_TABLE;

//            route.ID = (int)ExecuteScalar(sql);

//            foreach (RouteElement item in route.Elements)
//            {
//               // Update the route information on element
//               item.RouteID = route.ID;

//               // Añade el registro
//               sql = @"INSERT INTO 
//                           " + RouteElementDAO.SQL_TABLE + @" (" + RouteElementDAO.SQL_FIELDS_INSERT + @") 
//                       VALUES 
//                           (@routeid, @blockid, @status)";

//               SetParameter("routeid", route.ID);
//               SetParameter("blockid", item.Element.ID);
//               SetParameter("status", item.AccessoryStatus);

//               ExecuteNonQuery(sql);

//               // Obtiene el nuevo ID
//               sql = @"SELECT 
//                           Max(id) As id 
//                       FROM 
//                           " + RouteElementDAO.SQL_TABLE;

//               item.ID = (int)ExecuteScalar(sql);
//               item.RouteID = route.ID;
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
//      /// Update the specified route data.
//      /// </summary>
//      /// <param name="route">An instance with the updated data.</param>
//      public void Update(Route route)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].Update([{0}])", route);

//         try
//         {
//            Connect();

//            // Update the record data
//            sql = @"UPDATE 
//                        " + RouteDAO.SQL_TABLE + @" 
//                    SET 
//                        name          = @name, 
//                        description   = @description, 
//                        fromBlock     = @fromBlock, 
//                        toBlock       = @toBlock, 
//                        bidirectional = @bidirectional
//                    WHERE 
//                        id = @id";

//            SetParameter("name", route.Name);
//            SetParameter("description", route.Description);
//            SetParameter("fromBlock", route.FromBlock != null ? route.FromBlock.ID : 0);
//            SetParameter("toBlock", route.ToBlock != null ? route.ToBlock.ID : 0);
//            SetParameter("bidirectional", route.IsBidirectionl);
//            SetParameter("id", route.ID);

//            ExecuteNonQuery(sql);

//            // Delete all related blocks
//            sql = @"DELETE 
//                    FROM 
//                        " + RouteElementDAO.SQL_TABLE + @" 
//                    WHERE 
//                        routeid = @routeid";

//            SetParameter("routeid", route.ID);

//            ExecuteNonQuery(sql);

//            // Re-insert all blocks
//            foreach (RouteElement element in route.Elements)
//            {
//               // Añade el registro
//               sql = @"INSERT INTO 
//                           " + RouteElementDAO.SQL_TABLE + @" (" + RouteElementDAO.SQL_FIELDS_INSERT + @") 
//                       VALUES 
//                           (@routeid, @blockid, @status)";

//               SetParameter("routeid", route.ID);
//               SetParameter("blockid", element.ElementID);
//               SetParameter("status", element.AccessoryStatus);

//               ExecuteNonQuery(sql);

//               // Obtiene el nuevo ID
//               sql = @"SELECT 
//                           Max(id) As id 
//                       FROM 
//                           " + RouteElementDAO.SQL_TABLE;

//               element.ID = (int)ExecuteScalar(sql);
//               element.RouteID = route.ID;
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
//      /// Delete the specified route.
//      /// </summary>
//      /// <param name="id">Route unique identifier (DB).</param>
//      public int Delete(long id)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].Delete({0})", id);

//         try
//         {
//            Connect();

//            // Delete all related blocks
//            sql = @"DELETE 
//                    FROM 
//                        " + RouteElementDAO.SQL_TABLE + @" 
//                    WHERE 
//                        routeid = @routeid";

//            SetParameter("routeid", id);
//            ExecuteNonQuery(sql);

//            // Delete the route
//            sql = @"DELETE 
//                    FROM 
//                        " + RouteDAO.SQL_TABLE + @" 
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

      ///// <summary>
      ///// Unassign route activators related to the specified switchboard element (occupation block).
      ///// </summary>
      ///// <param name="element">Occupation block removed.</param>
      //public void Unassign(Element element)
      //{
      //   string sql = string.Empty;

      //   Logger.LogDebug(this, "[CLASS].Unassign([{0}])", element);

      //   if (element == null) return;

      //   try
      //   {
      //      Connect();

      //      // Update the record data
      //      sql = @"UPDATE 
      //                  " + RouteDAO.SQL_TABLE + @" 
      //              SET 
      //                  fromBlock = 0
      //              WHERE 
      //                  fromBlock = @elementId;

      //              UPDATE 
      //                  " + RouteDAO.SQL_TABLE + @" 
      //              SET 
      //                  toBlock = 0
      //              WHERE 
      //                  toBlock = @elementId";

      //      SetParameter("elementId", element.ID);

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

//      /// <summary>
//      /// Returns the specified route from database.
//      /// </summary>
//      /// <param name="id">The route unique identifier (DB).</param>
//      /// <returns>The requested <see cref="Route"/> instance filled with all data.</returns>
//      public Route GetByID(long id)
//      {
//         string sql = string.Empty;
//         Route item = null;
//         RouteElement subitem = null;
//         RouteElementDAO reDao = new RouteElementDAO();

//         Logger.LogDebug(this, "[CLASS].GetByID({0})", id);

//         try
//         {
//            Connect();

//            // Get the route
//            sql = @"SELECT 
//                        " + RouteDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + RouteDAO.SQL_TABLE + @" 
//                    WHERE 
//                        id = @id";

//            SetParameter("id", id);

//            using (SQLiteDataReader reader = ExecuteReader(sql))
//            {
//               if (reader.Read())
//               {
//                  item = this.ReadEntityRecord(reader);
//               }
//            }

//            if (item == null) return null;

//            // Get the element status information
//            sql = @"SELECT 
//                        " + RouteElementDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + RouteElementDAO.SQL_TABLE + @" 
//                    WHERE 
//                        routeid = @routeid";

//            SetParameter("routeid", id);

//            using (SQLiteDataReader reader = ExecuteReader(sql))
//            {
//               while (reader.Read())
//               {
//                  subitem = reDao.ReadEntityRecord(reader);
//                  if (subitem != null)
//                  {
//                     item.Elements.Add(subitem);
//                  }
//               }
//            }

//            // Get from/to elements
//            if (item.FromBlockID > 0) item.FromBlock = OTCContext.Project.LayoutManager.ElementDAO.GetByID(item.FromBlockID);
//            if (item.ToBlockID > 0) item.ToBlock = OTCContext.Project.LayoutManager.ElementDAO.GetByID(item.ToBlockID);

//            return item;
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
//      /// Get a list of routes linking the specified blok element.
//      /// </summary>
//      /// <param name="fromBlockElement">Source/Destination block.</param>
//      /// <returns>The requested list of linking routes.</returns>
//      public List<Route> GetByElement(IBlock fromBlockElement, bool onlyFromBlock)
//      {
//         string sql = string.Empty;
//         Route item = null;
//         List<Route> items = new List<Route>();

//         Logger.LogDebug(this, "[CLASS].GetByBlock([{0}])", fromBlockElement);

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        r.id, 
//                        r.name, 
//                        r.description, 
//                        r.fromBlock, 
//                        r.toBlock, 
//                        r.bidirectional 
//                    FROM 
//                        " + ElementDAO.SQL_TABLE + @" b 
//                        Inner Join " + RouteDAO.SQL_TABLE + @" r On (r.fromBlock = b.id Or r.toBlock = b.id) 
//                    WHERE 
//                        (r.fromBlock = @fromid Or r.toBlock = @toid) And 
//                        type = @type 
//                    ORDER BY
//                        r.name Asc,
//                        r.id   Asc";

//            SetParameter("fromid", fromBlockElement.ID);
//            SetParameter("toid", onlyFromBlock ? -1 : fromBlockElement.ID);
//            SetParameter("type", ElementBase.ElementType.OccupationBlock);

//            using (SQLiteDataReader reader = ExecuteReader(sql))
//            {
//               if (reader.Read())
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
//      /// Get all routes.
//      /// </summary>
//      /// <returns>The requested list filled with information.</returns>
//      public IEnumerable<Route> GetAll()
//      {
//         string sql = string.Empty;
//         Route route = null;
//         List<Route> routes = new List<Route>();

//         Logger.LogDebug(this, "[CLASS].GetAll()");

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + RouteDAO.SQL_FIELDS_SELECT + @"
//                    FROM 
//                        " + RouteDAO.SQL_TABLE + @" 
//                    ORDER BY 
//                        name";

//            using (SQLiteDataReader reader = ExecuteReader(sql))
//            {
//               while (reader.Read())
//               {
//                  route = this.ReadEntityRecord(reader);
//                  if (route != null)
//                  {
//                     routes.Add(route);
//                  }
//               }
//            }

////            // Get route element status information
////            foreach (Route rout in routes)
////            {
////               sql = @"SELECT 
////                        " + RouteDAO.SQL_BLOCK_FIELDS_SELECT + @" 
////                    FROM 
////                        " + RouteDAO.SQL_BLOCK_TABLE + @" 
////                    WHERE 
////                        routeid = @routeid";

////               SetParameter("routeid", rout.ID);

////               using (SQLiteDataReader reader = ExecuteReader(sql))
////               {
////                  while (reader.Read())
////                  {
////                     elem = RouteDAO.ReadSubentityRecord(reader);
////                     if (elem != null)
////                     {
////                        rout.Elements.Add(elem);
////                     }
////                  }
////               }
////            }

//            return routes;
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
//      /// Get all routes.
//      /// </summary>
//      /// <returns>The requested <see cref="System.Data.DataTable"/> filled with information.</returns>
//      public System.Data.DataTable Find()
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].Find()");

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        id          As '#ID', 
//                        name        As 'Name', 
//                        description As 'Description'
//                    FROM 
//                        " + RouteDAO.SQL_TABLE + @" 
//                    ORDER BY 
//                        name";

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

      ///// <summary>
      ///// Read a object from the current reader record.
      ///// </summary>
      //public Route ReadEntityRecord(SQLiteDataReader reader)
      //{
      //   Route record = new Route();
      //   record.ID = reader.GetInt64(0);
      //   record.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
      //   record.Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
      //   record.FromBlockID = reader.IsDBNull(3) ? 0 : reader.GetInt64(3);
      //   record.ToBlockID = reader.IsDBNull(4) ? 0 : reader.GetInt64(4);
      //   record.IsBidirectionl = reader.IsDBNull(5) ? false : reader.GetBoolean(5);

      //   return record;
      //}

      #endregion

   }
}
