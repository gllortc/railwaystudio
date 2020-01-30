using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using System;

namespace Rwm.Otc.Layout.Persistence
{

   /// <summary>
   /// Manage the swithcboard panel blocks persistence in database.
   /// </summary>
   public class ElementDAO : DataConsumer
   {

      #region Constants

      // SQL declarations
      public static string SQL_TABLE = "elements";
      internal static string SQL_FIELDS_SELECT = "id, switchboardid, name, x, y, rotation, type, status";
      internal static string SQL_FIELDS_INSERT = "switchboardid, name, x, y, rotation, type, status";

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ElementDAO"/>.
      /// </summary>
      public ElementDAO() : base() { }

      #endregion

      #region Methods

//      /// <summary>
//      /// Adds a new panel into the current project.
//      /// </summary>
//      /// <param name="element">An implementation of <see cref="ElementBase"/> containing the data for new object.</param>
//      public void Add(Element element)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].Add([{0}])", element);

//         try
//         {
//            // Remove element in the current position
//            this.DeleteByCoords(element.Switchboard, element.Coordinates);

//            Connect();

//            // Create the new element
//            sql = @"INSERT INTO 
//                        " + ElementDAO.SQL_TABLE + @" (" + ElementDAO.SQL_FIELDS_INSERT + @") 
//                    VALUES 
//                        (@switchboardid, @name, @x, @y, @rotation, @type, @status)";

//            SetParameter("switchboardid", element.Switchboard.ID);
//            SetParameter("name", element.Name);
//            SetParameter("x", element.X);
//            SetParameter("y", element.Y);
//            SetParameter("rotation", element.Rotation);
//            SetParameter("type", element.Properties.ID);
//            SetParameter("status", element.AccessoryStatus);

//            ExecuteNonQuery(sql);

//            // Obtiene el nuevo ID
//            sql = @"SELECT 
//                        Max(id) As id 
//                    FROM 
//                        " + ElementDAO.SQL_TABLE;

//            element.ID = (int)ExecuteScalar(sql, 0);
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
//      /// Update the specified element data.
//      /// </summary>
//      /// <param name="element">An instance with the updated data.</param>
//      public void Update(Element element)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].Update([{0}])", element);

//         try
//         {
//            Connect();

//            sql = @"UPDATE 
//                        " + ElementDAO.SQL_TABLE + @" 
//                    SET 
//                        switchboardid = @switchboardid, 
//                        name = @name, 
//                        x = @x,
//                        y = @y,
//                        rotation = @rotation,
//                        type = @type,
//                        status = @status 
//                    WHERE 
//                        id = @id";

//            SetParameter("switchboardid", element.Switchboard.ID);
//            SetParameter("name", element.Name);
//            SetParameter("x", element.X);
//            SetParameter("y", element.Y);
//            SetParameter("rotation", element.Rotation);
//            SetParameter("type", element.Properties.ID);
//            SetParameter("status", element.AccessoryStatus);
//            SetParameter("id", element.ID);

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
//      /// Update the state of the specified element.
//      /// </summary>
//      /// <param name="element">Element with the updated status.</param>
//      public void UpdateStatus(Element element)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].UpdateStatus([{0}])", element);

//         try
//         {
//            Connect();

//            sql = @"UPDATE 
//                        " + ElementDAO.SQL_TABLE + @" 
//                    SET 
//                        status = @status
//                    WHERE 
//                        id = @id";

//            SetParameter("status", element.AccessoryStatus);
//            SetParameter("id", element.ID);

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
//      /// Delete a element and all its related data.
//      /// </summary>
//      /// <param name="id">Element unique identifier (DB).</param>
//      public int Delete(long id)
//      {
//         string sql = string.Empty;
//         Element element = null;

//         Logger.LogDebug(this, "[CLASS].Delete({0})", id);

//         try
//         {
//            // Get the element
//            element = Element.Get(id);
//            if (element == null) return 0;

//            // Unassign module connections
//            OTCContext.Project.LayoutManager.DeviceConnectionDAO.Unassign(element);

//            // Delete route elements
//            OTCContext.Project.LayoutManager.RouteElementDAO.DeleteByElement(element);

//            // Unassign route activators
//            OTCContext.Project.LayoutManager.RouteDAO.Unassign(element);

//            Connect();

//            // Delete element
//            sql = @"DELETE 
//                    FROM 
//                        " + ElementDAO.SQL_TABLE + @" 
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
//      /// Delete the element ubicated in the specified coordinates (and all its related information).
//      /// </summary>
//      /// <param name="sb">Switchboard where the element is placed.</param>
//      /// <param name="coords">The element position.</param>
//      public void DeleteByCoords(Switchboard sb, Coordinates coords)
//      {
//         int id;
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].DeleteByCoords([{0}], [{1}])", sb, coords);

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        id 
//                    FROM 
//                        " + ElementDAO.SQL_TABLE + @" 
//                    WHERE 
//                        switchboardid = @switchboardid And 
//                        x             = @x             And 
//                        y             = @y";

//            SetParameter("switchboardid", sb.ID);
//            SetParameter("x", coords.X);
//            SetParameter("y", coords.Y);

//            id = (int)ExecuteScalar(sql, 0);

//            Disconnect();

//            if (id != 0)
//            {
//               this.Delete(id);
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
//      /// Rotate a element and update the data into project database.
//      /// </summary>
//      /// <param name="element">The element that's being rotated.</param>
//      public void Rotate(Element element)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].Rotate([{0}])", element);

//         try
//         {
//            element.Rotate();

//            Connect();

//            sql = @"UPDATE 
//                        " + ElementDAO.SQL_TABLE + @" 
//                    SET 
//                        rotation = @rotation
//                    WHERE 
//                        id = @id";

//            SetParameter("rotation", element.Rotation);
//            SetParameter("id", element.ID);

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

      /// <summary>
      /// Move all switchboard blocks to the specified orientation.
      /// </summary>
      /// <param name="sb">Switchboard to move.</param>
      /// <param name="dir">Movement orientation.</param>
      public void Move(Switchboard sb, Switchboard.MoveDirection dir)
      {
         string dirSql;
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Move([{0}], {1})", sb, dir);

         try
         {
            switch (dir)
            {
               case Switchboard.MoveDirection.Up: dirSql = "y = y-1"; break;
               case Switchboard.MoveDirection.Down: dirSql = "y = y+1"; break;
               case Switchboard.MoveDirection.Left: dirSql = "x = x-1"; break;
               case Switchboard.MoveDirection.Right: dirSql = "x = x+1"; break;
               default: dirSql = string.Empty; break;
            }

            Connect();

            sql = @"UPDATE 
                        " + Element.TableName + @" 
                    SET 
                        " + dirSql + @"
                    WHERE 
                        switchboardid = @switchboardid";

            SetParameter("switchboardid", sb.ID);

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
//      /// Recupera las propiedades de una Administración/Operadora.
//      /// </summary>
//      /// <param name="id">The element unique identifier (DB).</param>
//      /// <returns>The requested instance of <see cref="ElementBase"/> or <c>null</c> if the element cannot be found.</returns>
//      public ElementBase GetByID(long id)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].GetByID({0})", id);

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + ElementDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + ElementDAO.SQL_TABLE + @" 
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
//      /// Gets all elements from a specified switchboard panel.
//      /// </summary>
//      /// <param name="panel">The switchboard panel.</param>
//      /// <returns>The requested list of <see cref="ElementBase"/>.</returns>
//      public List<Element> GetByPanel(Switchboard panel)
//      {
//         string sql = string.Empty;
//         Element item = null;
//         List<Element> items = new List<Element>();

//         Logger.LogDebug(this, "[CLASS].GetByPanel([{0}])", panel);

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + ElementDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + ElementDAO.SQL_TABLE + @" 
//                    WHERE 
//                        switchboardid = @switchboardid";

//            SetParameter("switchboardid", panel.ID);

//            using (SQLiteDataReader reader = ExecuteReader(sql))
//            {
//               while (reader.Read())
//               {
//                  item = this.ReadEntityRecord(reader);
//                  if (item != null)
//                  {
//                     item.Switchboard = panel;
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
//      /// Get a element by its coordinates.
//      /// </summary>
//      /// <param name="coords">The element position.</param>
//      /// <returns>The requested instance of <see cref="ElementBase"/> or <c>null</c> if the element cannot be found.</returns>
//      public Element GetByCoordinates(Coordinates coords)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].GetByCoordinates([{0}])", coords);

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + ElementDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + ElementDAO.SQL_TABLE + @" 
//                    WHERE 
//                        x = @x And 
//                        y = @y";

//            SetParameter("x", coords.X);
//            SetParameter("y", coords.Y);

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

      ///// <summary>
      ///// Get all elements.
      ///// </summary>
      ///// <returns>A list of elements controlable with accessory decoders.</returns>
      //public IEnumerable<Element> GetAll()
      //{
      //   return this.GetAll(Device.DeviceType.Undefined);
      //}

//      /// <summary>
//      /// Get all blocks.
//      /// </summary>
//      /// <param name="type">A value to filter blocks by its control connections.</param>
//      /// <returns>A list of blocks controlable with accessory decoders.</returns>
//      public IEnumerable<Element> GetAll(Device.DeviceType type)
//      {
//         string sql = string.Empty;
//         Element item = null;
//         List<Element> items = new List<Element>();

//         Logger.LogDebug(this, "[CLASS].GetAll({0})", type);

//         try
//         {
//            // Route.Get(4);
//            // Route.Get(4);

//            Connect();

//            sql = @"SELECT 
//                        " + ElementDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + ElementDAO.SQL_TABLE + @" 
//                    ORDER BY 
//                        name Asc, 
//                        id   Asc";

//            using (SQLiteDataReader reader = ExecuteReader(sql))
//            {
//               while (reader.Read())
//               {
//                  item = this.ReadEntityRecord(reader);
//                  if (item != null && 
//                      (type == Device.DeviceType.Undefined ||
//                       type == Device.DeviceType.AccessoryDecoder && item.AccessoryConnections != null && item.AccessoryConnections.Length > 0 ||
//                       type == Device.DeviceType.SensorModule && item.FeedbackConnections != null && item.FeedbackConnections.Length > 0))
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
      ///// Read a category from the current reader record.
      ///// </summary>
      //public Element ReadEntityRecord(SQLiteDataReader reader)
      //{
      //   "id, switchboardid, name, x, y, rotation, type, status"

      //   Element record = ElementDAO.CreateInstance(reader.GetInt32(6));
      //   record.ID = reader.GetInt64(0);
      //   record.Switchboard = null;
      //   record.SwitchboardID = reader.GetInt32(1);
      //   record.Name = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
      //   record.X = reader.IsDBNull(3) ? 1 : reader.GetInt32(3);
      //   record.Y = reader.IsDBNull(4) ? 1 : reader.GetInt32(4);
      //   record.Rotation = reader.IsDBNull(5) ? RotationStep.Step0 : (RotationStep)reader.GetInt32(5);

      //   if (ElementBase.IsAccessoryElement(record))
      //   {
      //      ((IAccessory)record).SetAccessoryStatus(reader.IsDBNull(7) ? ElementBase.STATUS_UNDEFINED : reader.GetInt32(7), false);
      //   }

      //   return record;
      //}

      #endregion

      //#region Static Members

      ///// <summary>
      ///// Creates a element instance from the specified type.
      ///// </summary>
      ///// <param name="type">Element type corresponding of the enumeration type.</param>
      ///// <returns>The requested instance.</returns>
      //public static Element CreateInstance(int type)
      //{
      //   return ElementDAO.CreateInstance((Element.ElementType)type);
      //}

      ///// <summary>
      ///// Creates a element instance from the specified type.
      ///// </summary>
      ///// <param name="type">Element type.</param>
      ///// <returns>The requested instance.</returns>
      //public static ElementBase CreateInstance(ElementBase.ElementType type, bool throwError = true)
      //{
      //   ElementBase instance;

      //   foreach (Type ctype in Assembly.GetExecutingAssembly().GetTypes())
      //   {
      //      if (ctype.IsClass && !ctype.IsAbstract && ctype.IsSubclassOf(typeof(ElementBase)))
      //      {
      //         instance = (ElementBase)Activator.CreateInstance(ctype);

      //         if (instance.Type == type)
      //         {
      //            return instance;
      //         }
      //      }
      //   }

      //   if (throwError)
      //      throw new LayoutConfigurationException("Cannot create instance of element of type #{0}", type);

      //   return null;
      //}

      //#endregion

      #region Private Members

      private string GetDirectionSql(Switchboard.MoveDirection dir)
      {
         switch (dir)
         {
            case Switchboard.MoveDirection.Up: return "y = y-1";
            case Switchboard.MoveDirection.Down: return "y = y+1";
            case Switchboard.MoveDirection.Left: return "x = x-1";
            case Switchboard.MoveDirection.Right: return "x = x+1";
            default: return string.Empty;
         }
      }

      #endregion

   }
}
