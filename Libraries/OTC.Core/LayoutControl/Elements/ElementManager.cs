using Rwm.Otc.Configuration;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Utils;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Reflection;

namespace Rwm.Otc.LayoutControl.Elements
{

   /// <summary>
   /// Manage the swithcboard panel blocks persistence in database.
   /// </summary>
   public class ElementManager : DataEntity
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = "blocks";
      internal static string SQL_FIELDS_SELECT = "id, panelid, name, x, y, rotation, type, status";
      internal static string SQL_FIELDS_INSERT = "panelid, name, x, y, rotation, type, status";

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="ElementManager"/>.
      /// </summary>
      /// <param name="app">Una instáncia de RCApplication.</param>
      public ElementManager(XmlSettingsManager settings) : base(settings) { }

      #endregion

      #region Methods

      /// <summary>
      /// Adds a new panel into the current project.
      /// </summary>
      /// <param name="element">An implementation of <see cref="ElementBase"/> containing the data for new object.</param>
      public void Add(ElementBase element)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Add([{0}])", element);

         try
         {
            // Remove element in the current position
            this.DeleteByCoords(element.Coordinates);

            Connect();

            // Create the new element
            sql = @"INSERT INTO 
                        " + ElementManager.SQL_TABLE + @" (" + ElementManager.SQL_FIELDS_INSERT + @") 
                    VALUES 
                        (@panelid, @name, @x, @y, @rotation, @type, @status)";

            SetParameter("panelid", element.SwitchboardPanel.ID);
            SetParameter("name", element.Name);
            SetParameter("x", element.X);
            SetParameter("y", element.Y);
            SetParameter("rotation", element.Rotation);
            SetParameter("type", element.Type);
            SetParameter("status", ElementBase.GetAccessoryStatus(element));

            ExecuteNonQuery(sql);

            // Obtiene el nuevo ID
            sql = @"SELECT 
                        Max(id) As id 
                    FROM 
                        " + ElementManager.SQL_TABLE;

            element.ID = (int)ExecuteScalar(sql, 0);
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
      /// Update the specified element data.
      /// </summary>
      /// <param name="element">An instance with the updated data.</param>
      public void Update(ElementBase element)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Update([{0}])", element);

         try
         {
            Connect();

            sql = @"UPDATE 
                        " + ElementManager.SQL_TABLE + @" 
                    SET 
                        panelid = @panelid, 
                        name = @name, 
                        x = @x,
                        y = @y,
                        rotation = @rotation,
                        type = @type,
                        status = @status 
                    WHERE 
                        id = @id";

            SetParameter("panelid", element.SwitchboardPanel.ID);
            SetParameter("name", element.Name);
            SetParameter("x", element.X);
            SetParameter("y", element.Y);
            SetParameter("rotation", element.Rotation);
            SetParameter("type", element.Type);
            SetParameter("status", ElementBase.GetAccessoryStatus(element));
            SetParameter("id", element.ID);

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
      /// Update the state of the specified element.
      /// </summary>
      /// <param name="element">Element with the updated status.</param>
      public void UpdateStatus(ElementBase element)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].UpdateStatus([{0}])", element);

         try
         {
            Connect();

            sql = @"UPDATE 
                        " + ElementManager.SQL_TABLE + @" 
                    SET 
                        status = @status
                    WHERE 
                        id = @id";

            SetParameter("status", ElementBase.GetAccessoryStatus(element));
            SetParameter("id", element.ID);

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
      /// Delete a element and all its related data.
      /// </summary>
      /// <param name="id">Element unique identifier (DB).</param>
      public void Delete(int id)
      {
         string sql = string.Empty;
         ElementBase element = null;

         Logger.LogDebug(this, "[CLASS].Delete({0})", id);

         try
         {
            // Get the element
            element = this.GetByID(id);

            // Unasign module connection
            ControlModuleConnectionManager bManager = new ControlModuleConnectionManager(this.Settings);
            bManager.Unassign(element);

            Connect();

            // Delete element
            sql = @"DELETE 
                    FROM 
                        " + ElementManager.SQL_TABLE + @" 
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
      /// <param name="coords">The element position.</param>
      public void DeleteByCoords(Coordinates coords)
      {
         int id;
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].DeleteByCoords([{0}])", coords);

         try
         {
            Connect();

            sql = @"SELECT 
                        id 
                    FROM 
                        " + ElementManager.SQL_TABLE + @" 
                    WHERE 
                        x = @x And 
                        y = @y";

            SetParameter("x", coords.X);
            SetParameter("y", coords.Y);

            id = (int)ExecuteScalar(sql, 0);

            Disconnect();

            if (id != 0)
            {
               this.Delete(id);
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
      /// Rotate a element and update the data into project database.
      /// </summary>
      /// <param name="element">The element that's being rotated.</param>
      public void Rotate(ElementBase element)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].Rotate([{0}])", element);

         try
         {
            element.Rotate();

            Connect();

            sql = @"UPDATE 
                        " + ElementManager.SQL_TABLE + @" 
                    SET 
                        rotation = @rotation
                    WHERE 
                        id = @id";

            SetParameter("rotation", element.Rotation);
            SetParameter("id", element.ID);

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
      /// <param name="itemId">Identificador.</param>
      /// <returns>Una instáncia de RCManufacturer.</returns>
      public ElementBase GetByID(Int32 itemId)
      {
         return GetByID((Int64)itemId);
      }

      /// <summary>
      /// Recupera las propiedades de una Administración/Operadora.
      /// </summary>
      /// <param name="id">The element unique identifier (DB).</param>
      /// <returns>The requested instance of <see cref="ElementBase"/> or <c>null</c> if the element cannot be found.</returns>
      public ElementBase GetByID(Int64 id)
      {
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].GetByID({0})", id);

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ElementManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ElementManager.SQL_TABLE + @" 
                    WHERE 
                        id = @id";

            SetParameter("id", id);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  return ElementManager.ReadEntityRecord(reader);
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
      /// Gets all elements from a specified switchboard panel.
      /// </summary>
      /// <param name="panel">The switchboard panel.</param>
      /// <returns>The requested list of <see cref="ElementBase"/>.</returns>
      public List<ElementBase> GetByPanel(SwitchboardPanel panel)
      {
         string sql = string.Empty;
         ElementBase item = null;
         List<ElementBase> items = new List<ElementBase>();

         Logger.LogDebug(this, "[CLASS].GetByPanel([{0}])", panel);

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ElementManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ElementManager.SQL_TABLE + @" 
                    WHERE 
                        panelid = @panelid";

            SetParameter("panelid", panel.ID);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  item = ElementManager.ReadEntityRecord(reader);
                  if (item != null)
                  {
                     item.SwitchboardPanel = panel;
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
      /// Get a element by its coordinates.
      /// </summary>
      /// <param name="coords">The element position.</param>
      /// <returns>The requested instance of <see cref="ElementBase"/> or <c>null</c> if the element cannot be found.</returns>
      public ElementBase GetByCoordinates(Coordinates coords)
      {
         int id;
         string sql = string.Empty;

         Logger.LogDebug(this, "[CLASS].GetByCoordinates([{0}])", coords);

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ElementManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ElementManager.SQL_TABLE + @" 
                    WHERE 
                        x = @x And 
                        y = @y";

            SetParameter("x", coords.X);
            SetParameter("y", coords.Y);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  return ElementManager.ReadEntityRecord(reader);
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
      /// Get all elements.
      /// </summary>
      /// <returns>A list of elements controlable with accessory decoders.</returns>
      public IEnumerable<ElementBase> GetAll()
      {
         return this.GetAll(ControlModule.ModuleType.Undefined);
      }

      /// <summary>
      /// Get all blocks.
      /// </summary>
      /// <param name="controlType">A value to filter blocks by its control connections.</param>
      /// <returns>A list of blocks controlable with accessory decoders.</returns>
      public IEnumerable<ElementBase> GetAll(ControlModule.ModuleType controlType)
      {
         string sql = string.Empty;
         ElementBase item = null;
         List<ElementBase> items = new List<ElementBase>();

         Logger.LogDebug(this, "[CLASS].GetAll({0})", controlType);

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ElementManager.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ElementManager.SQL_TABLE + @" 
                    ORDER BY 
                        name Asc, 
                        id   Asc";

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  item = ElementManager.ReadEntityRecord(reader);
                  if (item != null && 
                      (controlType == ControlModule.ModuleType.Undefined ||
                       controlType == ControlModule.ModuleType.Accessory && item.AccessoryConnections != null && item.AccessoryConnections.Length > 0 ||
                       controlType == ControlModule.ModuleType.Sensor && item.FeedbackConnections != null && item.FeedbackConnections.Length > 0))
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

      #endregion

      #region Static Members

      /// <summary>
      /// Creates a element instance from the specified type.
      /// </summary>
      /// <param name="elementType">Element type corresponding of the enumeration type.</param>
      /// <returns>The requested instance.</returns>
      public static ElementBase CreateInstance(int elementType)
      {
         return ElementManager.CreateInstance((ElementBase.ElementType)elementType);
      }

      /// <summary>
      /// Creates a element instance from the specified type.
      /// </summary>
      /// <param name="blockType">Element type.</param>
      /// <returns>The requested instance.</returns>
      public static ElementBase CreateInstance(ElementBase.ElementType blockType)
      {
         ElementBase instance;

         foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
         {
            if (type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(ElementBase)))
            {
               instance = (ElementBase)Activator.CreateInstance(type);

               if (instance.Type == blockType)
               {
                  return instance;
               }
            }
         }

         throw new LayoutConfigurationException("Cannot create instance of element of type #{0}", blockType);
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Read a category from the current reader record.
      /// </summary>
      internal static ElementBase ReadEntityRecord(SQLiteDataReader reader)
      {
         //"id, panelid, name, x, y, rotation, type, status"

         ElementBase record = ElementManager.CreateInstance(reader.GetInt32(6));
         record.ID = reader.GetInt32(0);
         record.SwitchboardPanel = new SwitchboardPanel(reader.GetInt32(1));
         record.Name = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
         record.X = reader.IsDBNull(3) ? 1 : reader.GetInt32(3);
         record.Y = reader.IsDBNull(4) ? 1 : reader.GetInt32(4);
         record.Rotation = reader.IsDBNull(5) ? ElementBase.RotationStep.Step0 : (ElementBase.RotationStep)reader.GetInt32(5);

         if (ElementBase.IsAccessoryElement(record))
         {
            ((IAccessory)record).SetAccessoryStatus(reader.IsDBNull(7) ? ElementBase.STATUS_UNDEFINED : reader.GetInt32(7), false);
         }

         return record;
      }

      #endregion

   }
}
