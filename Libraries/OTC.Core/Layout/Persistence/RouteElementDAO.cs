using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using System;

namespace Rwm.Otc.Layout.Persistence
{

   /// <summary>
   /// Manage the switchboard panels persistence in project database.
   /// </summary>
   public class RouteElementDAO : DataConsumer
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = "routeelements";
      internal static string SQL_FIELDS_SELECT = "id, routeid, elementid, status";
      internal static string SQL_FIELDS_INSERT = "routeid, elementid, status";

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="RouteElementDAO"/>.
      /// </summary>
      public RouteElementDAO() : base() { }

      #endregion

      #region Methods

//      /// <summary>
//      /// Adds a new route into the current project.
//      /// </summary>
//      /// <param name="item">The instance of <see cref="Route"/> corresponding to the new route.</param>
//      public void Add(RouteElement item)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].Add([{0}])", item);

//         try
//         {
//            Connect();

//            // Añade el registro
//            sql = @"INSERT INTO 
//                        " + RouteElementDAO.SQL_TABLE + @" (" + RouteElementDAO.SQL_FIELDS_INSERT + @") 
//                    VALUES 
//                        (@routeid, @elementid, @status)";

//            SetParameter("routeid", item.ID);
//            SetParameter("elementid", item.Element.ID);
//            SetParameter("status", item.AccessoryStatus);

//            ExecuteNonQuery(sql);

//            // Obtiene el nuevo ID
//            sql = @"SELECT 
//                        Max(id) As id 
//                    FROM 
//                        " + RouteElementDAO.SQL_TABLE;

//            item.ID = (int)ExecuteScalar(sql);
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

      /// <summary>
      /// Delete all rote elements related to the specified switchboard element.
      /// </summary>
      /// <param name="element"></param>
      public void DeleteByElement(Element element)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].DeleteByElement([{0}])", element);

         try
         {
            Connect();

            // Delete all related blocks
            sql = @"DELETE 
                    FROM 
                        " + RouteElementDAO.SQL_TABLE + @" 
                    WHERE 
                        elementid = @elementid";

            SetParameter("elementid", element.ID);

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

//      /// <summary>
//      /// Returns the specified route from database.
//      /// </summary>
//      /// <param name="id">The route unique identifier (DB).</param>
//      /// <returns>The requested <see cref="Route"/> instance filled with all data.</returns>
//      public RouteElement GetByID(long id)
//      {
//         string sql = string.Empty;
//         RouteElement item = null;

//         Logger.LogDebug(this, "[CLASS].GetByID({0})", id);

//         try
//         {
//            Connect();

//            // Get the route
//            sql = @"SELECT 
//                        " + RouteElementDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + RouteElementDAO.SQL_TABLE + @" 
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
//      /// Get all routes.
//      /// </summary>
//      /// <returns>The requested list filled with information.</returns>
//      public List<RouteElement> GetByRoute(Route route)
//      {
//         string sql = string.Empty;
//         RouteElement item = null;
//         List<RouteElement> items = new List<RouteElement>();

//         Logger.LogDebug(this, "[CLASS].GetByRoute([{0}])", route);

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                     " + RouteElementDAO.SQL_FIELDS_SELECT + @" 
//                 FROM 
//                     " + RouteElementDAO.SQL_TABLE + @" 
//                 WHERE 
//                     routeid = @routeid 
//                 ORDER BY 
//                     routeid Asc,
//                     id      Asc";

//            SetParameter("routeid", route.ID);

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
//      /// Get all routes.
//      /// </summary>
//      /// <returns>The requested list filled with information.</returns>
//      public IEnumerable<RouteElement> GetAll()
//      {
//         string sql = string.Empty;
//         RouteElement item = null;
//         List<RouteElement> items = new List<RouteElement>();

//         Logger.LogDebug(this, "[CLASS].GetAll()");

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                     " + RouteElementDAO.SQL_FIELDS_SELECT + @" 
//                 FROM 
//                     " + RouteElementDAO.SQL_TABLE + @" 
//                 WHERE 
//                     routeid > 0 
//                 ORDER BY 
//                     routeid Asc,
//                     id      Asc";

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

      ///// <summary>
      ///// Read a object from the current reader record.
      ///// </summary>
      //public RouteElement ReadEntityRecord(SQLiteDataReader reader)
      //{
      //   RouteElement record = new RouteElement();
      //   record.ID = reader.GetInt32(0);
      //   record.RouteID = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
      //   record.ElementID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
      //   record.AccessoryStatus = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

      //   return record;
      //}

      #endregion

   }
}
