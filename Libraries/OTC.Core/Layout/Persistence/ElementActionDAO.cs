using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Rwm.Otc.Layout.Persistence
{

   /// <summary>
   /// Manage the swithcboard panel elements persistence in database.
   /// </summary>
   public class ElementActionDAO : DataConsumer
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = "actions";
      internal static string SQL_FIELDS_SELECT = "id, elementid, type, eventtype, description, conditionstatus, intparam1, intparam2";
      internal static string SQL_FIELDS_INSERT = "elementid, type, eventtype, description, conditionstatus, intparam1, intparam2";

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="ElementActionDAO"/>.
      /// </summary>
      public ElementActionDAO() : base() { }

      #endregion

      #region Methods

//      /// <summary>
//      /// Adds a new panel into the current project.
//      /// </summary>
//      /// <param name="action">An implementation of <see cref="ElementAction"/> containing the data for new object.</param>
//      public void Add(ElementAction action)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].Add([{0}])", action);

//         try
//         {
//            Connect();

//            // Añade el registro
//            sql = @"INSERT INTO 
//                        " + ElementActionDAO.SQL_TABLE + @" (" + ElementActionDAO.SQL_FIELDS_INSERT + @") 
//                    VALUES 
//                        (@elementid, @type, @eventtype, @description, @conditionstatus, @intparam1, @intparam2)";

//            SetParameter("elementid", action.Element.ID);
//            SetParameter("type", action.ActionType);
//            SetParameter("eventtype", (int)action.EventType);
//            SetParameter("description", action.Description);
//            SetParameter("conditionstatus", action.ConditionParentStatus);
//            SetParameter("intparam1", action.IntegerParameter1);
//            SetParameter("intparam2", action.IntegerParameter2);

//            ExecuteNonQuery(sql);

//            // Obtiene el nuevo ID
//            sql = @"SELECT 
//                        Max(id) As id 
//                    FROM 
//                        " + ElementActionDAO.SQL_TABLE;

//            action.ID = (int)ExecuteScalar(sql, 0);
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
//      /// Update the specified action data.
//      /// </summary>
//      /// <param name="action">An instance with the updated data.</param>
//      public void Update(ElementAction action)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].Update([{0}])", action);

//         try
//         {
//            Connect();

//            sql = @"UPDATE 
//                        " + ElementActionDAO.SQL_TABLE + @" 
//                    SET 
//                        elementid       = @elementid, 
//                        type            = @type, 
//                        eventtype       = @eventtype,
//                        description     = @description,
//                        conditionstatus = @conditionstatus, 
//                        intparam1       = @intparam1, 
//                        intparam2       = @intparam2 
//                    WHERE 
//                        id = @id";

//            SetParameter("elementid", action.Element.ID);
//            SetParameter("type", action.ActionType);
//            SetParameter("eventtype", (int)action.EventType);
//            SetParameter("description", action.Description);
//            SetParameter("intparam1", action.IntegerParameter1);
//            SetParameter("intparam2", action.IntegerParameter2);
//            SetParameter("conditionstatus", action.ConditionParentStatus);
//            SetParameter("id", action.ID);

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
//      /// Delete a panel and all its related data.
//      /// </summary>
//      /// <param name="id">Panel unique identifier (DB).</param>
//      public int Delete(long id)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].Delete({0})", id);

//         try
//         {
//            Connect();

//            sql = @"DELETE 
//                    FROM 
//                        " + ElementActionDAO.SQL_TABLE + @" 
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
//      /// <param name="ownerElementId">The element position.</param>
//      public void DeleteByElement(int ownerElementId)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].DeleteByElement([{0}])", ownerElementId);

//         try
//         {
//            Connect();

//            sql = @"DELETE 
//                    FROM 
//                        " + ElementActionDAO.SQL_TABLE + @" 
//                    WHERE 
//                        elementid = @elementid";

//            SetParameter("elementid", ownerElementId);
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
//      /// Get all actions in project.
//      /// </summary>
//      /// <returns>The requested list of actions in project.</returns>
//      public IEnumerable<ElementAction> GetAll()
//      {
//         string sql = string.Empty;
//         ElementAction item = null;
//         List<ElementAction> items = new List<ElementAction>();

//         Logger.LogDebug(this, "[CLASS].GetAll()");

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + ElementActionDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + ElementActionDAO.SQL_TABLE + @" 
//                    ORDER BY 
//                        elementid Asc";

//            using (SQLiteDataReader reader = ExecuteReader(sql))
//            {
//               while (reader.Read())
//               {
//                  item = this.ReadEntityRecord(reader);
//                  if (item != null) items.Add(item);
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
//      /// Get an action by its ID.
//      /// </summary>
//      /// <param name="itemId">Action unique identifier (DB)..</param>
//      /// <returns>The requested action or <c>null</c> if the identifier doesn't exists in project.</returns>
//      public ElementAction GetByID(long itemId)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].GetByID({0})", itemId);

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + ElementActionDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + ElementActionDAO.SQL_TABLE + @" 
//                    WHERE 
//                        id = @id";

//            SetParameter("id", itemId);

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
//      /// Recupera las propiedades de un fabricante.
//      /// </summary>
//      /// <param name="ownerElementId">Identificador.</param>
//      /// <returns>Una instáncia de RCManufacturer.</returns>
//      public List<ElementAction> GetByElement(Int32 ownerElementId)
//      {
//         return this.GetByElement((Int64)ownerElementId);
//      }

//      /// <summary>
//      /// Gets all blocks from a specified switchboard panel.
//      /// </summary>
//      /// <param name="ownerElementId">The switchboard panel unique identifier (DB).</param>
//      /// <returns>The requested list of <see cref="ElementAction"/>.</returns>
//      public List<ElementAction> GetByElement(Int64 ownerElementId)
//      {
//         string sql = string.Empty;
//         ElementAction item = null;
//         List<ElementAction> items = new List<ElementAction>();

//         Logger.LogDebug(this, "[CLASS].GetByElement({0})", ownerElementId);

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + ElementActionDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + ElementActionDAO.SQL_TABLE + @" 
//                    WHERE 
//                        elementid = @elementid";

//            SetParameter("elementid", ownerElementId);

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

      /// <summary>
      /// Gets all actions related to an element.
      /// </summary>
      /// <param name="itemId">The switchboard panel unique identifier (DB).</param>
      /// <returns>The requested list in a <see cref="System.Data.DataTable"/>.</returns>
      public System.Data.DataTable FindByElement(Int64 itemId)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].FindByElement({0})", itemId);

         try
         {
            Connect();

            sql = @"SELECT 
                        id          As ""ID"", 
                        description As ""Name"", 
                        type        As ""Type"" , 
                        eventtype   As ""Fire on"" 
                    FROM 
                        " + ElementActionDAO.SQL_TABLE + @" 
                    WHERE 
                        elementid = @elementid 
                    ORDER BY 
                        executionorder Asc";

            SetParameter("elementid", itemId);

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

      ///// <summary>
      ///// Read a category from the current reader record.
      ///// </summary>
      //public ElementAction ReadEntityRecord(SQLiteDataReader reader)
      //{
      //   string typeName = (reader.IsDBNull(5) ? string.Empty : reader.GetString(2));
      //   ElementAction record = ElementAction.CreateActionInstance(typeName);

      //   if (record != null)
      //   {
      //      record.ID = reader.GetInt64(0);
      //      record.Element = null;
      //      record.ElementID = reader.GetInt32(1);
      //      record.ActionType = typeName;
      //      record.EventType = (Actions.ElementAction.ExecutionEventType)(reader.IsDBNull(3) ? (int)Actions.ElementAction.ExecutionEventType.Undefined : reader.GetInt32(3));
      //      record.Description = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
      //      record.ConditionParentStatus = reader.GetInt32(5);
      //      record.IntegerParameter1 = reader.GetInt32(6);
      //      record.IntegerParameter2 = reader.GetInt32(7);

      //      return record;
      //   }

      //   throw new ArgumentException("Not supported event " + typeName);
      //}

      #endregion

   }
}
