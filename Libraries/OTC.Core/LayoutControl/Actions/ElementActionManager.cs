using Rwm.Otc.Configuration;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Rwm.Otc.LayoutControl.Actions
{

   /// <summary>
   /// Manage the swithcboard panel elements persistence in database.
   /// </summary>
   public class ElementActionManager : DataEntity
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = "actions";
      internal static string SQL_FIELDS_SELECT = "id, blockid, type, eventtype, description, conditionstatus, intparam1, intparam2";
      internal static string SQL_FIELDS_INSERT = "blockid, type, eventtype, description, conditionstatus, intparam1, intparam2";

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="ElementActionManager"/>.
      /// </summary>
      /// <param name="settings">Current application settings.</param>
      public ElementActionManager(XmlSettingsManager settings) : base(settings) { }

      #endregion

      #region Methods

      /// <summary>
      /// Adds a new panel into the current project.
      /// </summary>
      /// <param name="action">An implementation of <see cref="ElementAction"/> containing the data for new object.</param>
      public void Add(ElementAction action)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Add([{0}])", action);

         try
         {
            Connect();

            // Añade el registro
            sql = @"INSERT INTO 
                        " + ElementActionManager.SQL_TABLE + @" (" + ElementActionManager.SQL_FIELDS_INSERT + @") 
                    VALUES 
                        (@blockid, @type, @eventtype, @description, @conditionstatus, @intparam1, @intparam2)";

            SetParameter("blockid", action.OwnerElementID);
            SetParameter("type", action.ActionType);
            SetParameter("eventtype", (int)action.EventType);
            SetParameter("description", action.Description);
            SetParameter("conditionstatus", action.ConditionParentStatus);
            SetParameter("intparam1", action.IntegerParameter1);
            SetParameter("intparam2", action.IntegerParameter2);

            ExecuteNonQuery(sql);

            // Obtiene el nuevo ID
            sql = @"SELECT 
                        Max(id) As id 
                    FROM 
                        " + ElementActionManager.SQL_TABLE;

            action.ID = (int)ExecuteScalar(sql, 0);
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
      /// Update the specified action data.
      /// </summary>
      /// <param name="action">An instance with the updated data.</param>
      public void Update(ElementAction action)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Update([{0}])", action);

         try
         {
            Connect();

            sql = @"UPDATE 
                        " + ElementActionManager.SQL_TABLE + @" 
                    SET 
                        blockid         = @blockid, 
                        type            = @type, 
                        eventtype       = @eventtype,
                        description     = @description,
                        conditionstatus = @conditionstatus, 
                        intparam1       = @intparam1, 
                        intparam2       = @intparam2 
                    WHERE 
                        id = @id";

            SetParameter("blockid", action.OwnerElementID);
            SetParameter("type", action.ActionType);
            SetParameter("eventtype", (int)action.EventType);
            SetParameter("description", action.Description);
            SetParameter("intparam1", action.IntegerParameter1);
            SetParameter("intparam2", action.IntegerParameter2);
            SetParameter("conditionstatus", action.ConditionParentStatus);
            SetParameter("id", action.ID);

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

            sql = @"DELETE 
                    FROM 
                        " + ElementActionManager.SQL_TABLE + @" 
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
      /// Delete the element ubicated in the specified coordinates (and all its related information).
      /// </summary>
      /// <param name="ownerElementId">The element position.</param>
      public void DeleteByElement(int ownerElementId)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].DeleteByElement([{0}])", ownerElementId);

         try
         {
            Connect();

            sql = @"DELETE 
                    FROM 
                        " + ElementActionManager.SQL_TABLE + @" 
                    WHERE 
                        blockid = @blockid";

            SetParameter("blockid", ownerElementId);
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
      /// Get an action by its ID.
      /// </summary>
      /// <param name="itemId">Action unique identifier (DB)..</param>
      /// <returns>The requested action or <c>null</c> if the identifier doesn't exists in project.</returns>
      public ElementAction GetByID(Int32 itemId)
      {
         return this.GetByID((Int64)itemId);
      }

      /// <summary>
      /// Get an action by its ID.
      /// </summary>
      /// <param name="itemId">Action unique identifier (DB)..</param>
      /// <returns>The requested action or <c>null</c> if the identifier doesn't exists in project.</returns>
      public ElementAction GetByID(Int64 itemId)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].GetByID({0})", itemId);

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ElementActionManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ElementActionManager.SQL_TABLE + @" 
                    WHERE 
                        id = @id";

            SetParameter("id", itemId);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  return ElementActionManager.ReadEntityRecord(reader);
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
      /// Recupera las propiedades de un fabricante.
      /// </summary>
      /// <param name="ownerElementId">Identificador.</param>
      /// <returns>Una instáncia de RCManufacturer.</returns>
      public List<ElementAction> GetByElement(Int32 ownerElementId)
      {
         return this.GetByElement((Int64)ownerElementId);
      }

      /// <summary>
      /// Gets all blocks from a specified switchboard panel.
      /// </summary>
      /// <param name="ownerElementId">The switchboard panel unique identifier (DB).</param>
      /// <returns>The requested list of <see cref="ElementAction"/>.</returns>
      public List<ElementAction> GetByElement(Int64 ownerElementId)
      {
         string sql = string.Empty;
         ElementAction item = null;
         List<ElementAction> items = new List<ElementAction>();

         Logger.LogDebug(this, "[CLASS].GetByElement({0})", ownerElementId);

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ElementActionManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ElementActionManager.SQL_TABLE + @" 
                    WHERE 
                        blockid = @blockid";

            SetParameter("blockid", ownerElementId);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  item = ElementActionManager.ReadEntityRecord(reader);
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
      /// Gets all elements from a specified switchboard panel.
      /// </summary>
      /// <param name="itemId">The switchboard panel unique identifier (DB).</param>
      /// <returns>The requested list of <see cref="BlockBase"/>.</returns>
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
                        " + ElementActionManager.SQL_TABLE + @" 
                    WHERE 
                        blockid = @blockid 
                    ORDER BY 
                        executionorder Asc";

            SetParameter("blockid", itemId);

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
      internal static ElementAction ReadEntityRecord(SQLiteDataReader reader)
      {
         string typeName = (reader.IsDBNull(5) ? string.Empty : reader.GetString(2));
         ElementAction record = ElementAction.CreateActionInstance(typeName);

         if (record != null)
         {
            record.ID = reader.GetInt32(0);
            record.OwnerElementID = reader.GetInt32(1);
            record.ActionType = typeName;
            record.EventType = (Rwm.Otc.LayoutControl.Actions.ElementAction.ExecutionEventType)(reader.IsDBNull(3) ? (int)Rwm.Otc.LayoutControl.Actions.ElementAction.ExecutionEventType.Undefined : reader.GetInt32(3));
            record.Description = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            record.ConditionParentStatus = reader.GetInt32(5);
            record.IntegerParameter1 = reader.GetInt32(6);
            record.IntegerParameter2 = reader.GetInt32(7);

            return record;
         }

         throw new ArgumentException("Not supported event " + typeName);
      }

      #endregion

   }
}
