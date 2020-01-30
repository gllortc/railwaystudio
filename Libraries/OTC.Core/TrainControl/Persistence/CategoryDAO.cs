using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Rwm.Otc.TrainControl.Persistence
{
   public class CategoryDAO : DataManager<Category>
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = "types";
      internal static string SQL_FIELDS_SELECT = "typeid, typename, typeicon, typemaint";
      internal static string SQL_FIELDS_INSERT = "typename, typeicon, typemaint";

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="CategoryDAO"/>.
      /// </summary>
      /// <param name="app">Ina instáncia de RCApplication.</param>
      public CategoryDAO() : base() { }

      #endregion

      #region Methods

//      /// <summary>
//      /// Agrega una nueva categoria.
//      /// </summary>
//      /// <param name="model">Una instáncia de RCModelType que representa los datos de la nueva categoria.</param>
//      public override void Add(Category category)
//      {
//         string sql = string.Empty;

//         try
//         {
//            Connect();

//            // Agrega el nuevo registro
//            sql = @"INSERT INTO 
//                        " + CategoryDAO.SQL_TABLE + @" (" + CategoryDAO.SQL_FIELDS_INSERT + @") 
//                    VALUES 
//                        (@name, @icon, @maintenance)";

//            SetParameter("name", category.Name);
//            SetParameter("icon", category.Icon);
//            SetParameter("maintenance", category.HaveMaintenance);

//            ExecuteNonQuery(sql);

//            // Obtiene el ID del nuevo elemento
//            sql = @"SELECT 
//                        Max(typeid) AS id 
//                    FROM 
//                        " + SQL_TABLE;

//            category.ID = (int)ExecuteScalar(sql);
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
//      /// Actualiza los datos de una categoria.
//      /// </summary>
//      /// <param name="model">Una instáncia de RCModelType que representa la categoria.</param>
//      public override void Update(Category category)
//      {
//         string sql = string.Empty;

//         try
//         {
//            Connect();

//            sql = @"UPDATE 
//                        " + CategoryDAO.SQL_TABLE + @" 
//                    SET 
//                        typename = @typename, 
//                        typemaint = @typemaint, 
//                        typeicon = @typeicon 
//                    WHERE 
//                        typeid = @typeid";

//            SetParameter("typename", category.Name);
//            SetParameter("typemaint", category.HaveMaintenance);
//            SetParameter("typeicon", category.Icon);
//            SetParameter("typeid", category.ID);

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
//      /// Elimina una categoria si no tiene ningún modelo asignado
//      /// </summary>
//      /// <param name="ItemID">Identificador de la categoria.</param>
//      public override int Delete(long itemId)
//      {
//         string sql = string.Empty;

//         try
//         {
//            // Averigua el número de modelos asignados a esta categoria
//            if (this.GetRelatedModelsCount(itemId) > 0)
//            {
//               throw new Exception("This category cannot be deleted because it has related models.");
//            }

//            // Elimina el registro
//            Connect();

//            sql = @"DELETE 
//                    FROM 
//                        " + CategoryDAO.SQL_TABLE + @" 
//                    WHERE 
//                        typeid = @typeid";

//            SetParameter("typeid", itemId);
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
//      /// Recupera una categoría de la colección.
//      /// </summary>
//      /// <param name="name">Nombre de la categoria.</param>
//      /// <returns>Una instáncia de <see cref="RCCategory"/> si la encuentra o <c>null</c> en cualquier otro caso.</returns>
//      public Category GetByName(string name)
//      {
//         string sql = string.Empty;
//         Category category = null;

//         try
//         {
//            // Asegura la conexión de datos
//            Connect();

//            // Averigua si existe alguna coincidencia
//            sql = @"SELECT 
//                        " + CategoryDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + CategoryDAO.SQL_TABLE + @" 
//                    WHERE 
//                        LCase(typename) = @typename";

//            SetParameter("typename", name);
//            using (SQLiteDataReader reader = ExecuteReader(sql))
//            {
//               if (reader.Read())
//               {
//                  return this.ReadEntityRecord(reader);
//               }
//            }

//            return category;
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            return null;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

//      /// <summary>
//      /// Recupera una categoría de la colección.
//      /// </summary>
//      /// <param name="itemid">Identificador de la categoria.</param>
//      /// <returns>Una instáncia de <see cref="RCCategory"/> o <c>null</c> en cualquier otro caso.</returns>
//      public override Category GetByID(long categoryId)
//      {
//         string sql = string.Empty;

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + CategoryDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + CategoryDAO.SQL_TABLE + @" 
//                    WHERE 
//                        typeid = @typeid";

//            SetParameter("typeid", categoryId);
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
//      /// Get all categories.
//      /// </summary>
//      /// <returns>A list filled with all requested instances.</returns>
//      public override IEnumerable<Category> GetAll()
//      {
//         string sql = string.Empty;
//         Category category = null;
//         List<Category> categories = new List<Category>();

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + CategoryDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + CategoryDAO.SQL_TABLE + @" 
//                    ORDER BY 
//                        typename ASC";

//            using (SQLiteDataReader reader = ExecuteReader(sql))
//            {
//               while (reader.Read())
//               {
//                  category = this.ReadEntityRecord(reader);
//                  if (category != null)
//                  {
//                     categories.Add(category);
//                  }
//               }
//            }

//            return categories;
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
//      /// Calcula el número de modelos asignados a una categoria.
//      /// </summary>
//      /// <param name="itemid">Identificador de la categoría.</param>
//      /// <returns>El número de modelos asignados.</returns>
//      public int GetRelatedModelsCount(long itemId)
//      {
//         string sql = string.Empty;

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        Count(*) As nregs 
//                    FROM 
//                        " + ModelDAO.SQL_TABLE + @" 
//                    WHERE 
//                        modtypeid = @modtypeid";

//            SetParameter("modtypeid", itemId);
//            return (int)ExecuteScalar(sql);
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
//      /// Averigua el ID de una categoria a partir de su nombre.
//      /// </summary>
//      /// <param name="name">Nombre de la categoria.</param>
//      /// <returns>Identificador del registro.</returns>
//      public int GetId(string name)
//      {
//         int id;
//         string sql = string.Empty;

//         try
//         {
//            // Asegura la conexión de datos
//            Connect();

//            // Averigua si existe alguna coincidencia
//            sql = @"SELECT 
//                        Count(*) As regs 
//                    FROM 
//                        " + CategoryDAO.SQL_TABLE + @" 
//                    WHERE 
//                        LCase(typename) = @typename";

//            SetParameter("typename", name.ToLower().Trim());
//            id = (int)ExecuteScalar(sql);
//            if (id > 0)
//            {
//               // Obtiene el registro
//               sql = @"SELECT 
//                           typeid 
//                       FROM 
//                           " + CategoryDAO.SQL_TABLE + @" 
//                       WHERE 
//                           LCase(typename) = @typename";

//               SetParameter("typename", name.ToLower().Trim());
//               return (int)ExecuteScalar(sql);
//            }
//            else
//            {
//               // Obtiene la primera categoria disponible
//               sql = @"SELECT 
//                           Top 1 typeid 
//                       FROM 
//                           " + CategoryDAO.SQL_TABLE + @" 
//                       ORDER BY 
//                           typename";

//               return (int)ExecuteScalar(sql);
//            }
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            return 0;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

      /// <summary>
      /// Get all categories as a <see cref="DataSource"/>.
      /// </summary>
      /// <returns>The requested <see cref="DataSource"/> filled with information.</returns>
      public System.Data.DataTable GetAllAsDataSource()
      {
         string sql = string.Empty;
         List<Category> categories = new List<Category>();

         try
         {
            Connect();

            sql = @"SELECT 
                        typeid      As '#ID', 
                        typename    As 'Name', 
                        typeicon    As 'Icon', 
                        typemaint   As 'Maintenance'
                    FROM 
                        " + CategoryDAO.SQL_TABLE + @" 
                    ORDER BY 
                        typename";

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

      /// <summary>
      /// Read a category from the current reader record.
      /// </summary>
      public override Category ReadEntityRecord(SQLiteDataReader reader)
      {
         Category record = new Category();
         record.ID = reader.GetInt32(0);
         record.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
         record.Icon = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
         record.HaveMaintenance = reader.IsDBNull(3) ? false : reader.GetBoolean(3);

         return record;
      }

      #endregion

   }
}
