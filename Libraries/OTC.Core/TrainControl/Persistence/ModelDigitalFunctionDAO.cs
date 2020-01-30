using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Rwm.Otc.TrainControl.Persistence
{
   public class ModelDigitalFunctionDAO : DataConsumer
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = @"modelsdfunc";

      internal static string SQL_SELECT = @"modelid, funcid, description";

      #endregion

      #region Constructors

      /// <summary>
      /// Constructor de la clase.
      /// </summary>
      /// <param name="app">Una instáncia de RCApplication.</param>
      public ModelDigitalFunctionDAO() : base() { }

      #endregion

      #region Methods

      /// <summary>
      /// Actualiza la lista de funciones digitales.
      /// </summary>
      public void Add(CollectionModel model)
      {
         string sql = string.Empty;

         // Elimina los registros actuales
         this.DeleteByModel(model.ID);

         try
         {
            foreach (ModelDigitalFunction func in model.DigitalFunctions)
            {
               sql = @"INSERT INTO 
                           " + ModelDigitalFunctionDAO.SQL_TABLE + @" (" + ModelDigitalFunctionDAO.SQL_SELECT + @") 
                       VALUES 
                           (@modelid, @funcid, @description)";

               SetParameter("modelid", model.ID);
               SetParameter("funcid", func.Number);
               SetParameter("description", func.Name);

               ExecuteNonQuery(sql);
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
      /// Elimina las funciones difitales asociadas a un modelo
      /// </summary>
      public void DeleteByModel(long modelId)
      {
         string sql = string.Empty;

         try
         {
            Connect();
            sql = @"DELETE 
                    FROM 
                        " + ModelDigitalFunctionDAO.SQL_TABLE + @"
                    WHERE 
                        modelid = @modelid";

            SetParameter("modelid", modelId);

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
      /// Recupera un modelo de la colección.
      /// </summary>
      /// <param name="modelId">Identificador del modelo a recuperar.</param>
      /// <returns>Una instáncia de RCModel.</returns>
      /// <remarks>
      /// Los campos <c>modlights</c> y <c>moddigitaldec</c> se recuperan pero ya no son usados en la tabla.
      /// </remarks>
      public List<ModelDigitalFunction> GetByModel(long modelId)
      {
         string sql = string.Empty;
         ModelDigitalFunction item = null;
         List<ModelDigitalFunction> items = new List<ModelDigitalFunction>();

         try
         {
            Connect();

            // Get all associated digital functions
            sql = @"SELECT 
                        funcid, 
                        description 
                    FROM 
                        " + ModelDigitalFunctionDAO.SQL_TABLE + @" 
                    WHERE 
                        modelid = @modelid 
                    ORDER BY 
                        funcid ASC";

            SetParameter("modid", modelId);

            using (SQLiteDataReader read = ExecuteReader(sql))
            {
               while (read.Read())
               {
                  item = new ModelDigitalFunction();
                  item.ModelId = modelId;
                  item.Number = read.GetInt32(0);
                  item.Name = !read.IsDBNull(1) ? read.GetString(1).Trim() : string.Empty;

                  items.Add(item);
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

   }
}
