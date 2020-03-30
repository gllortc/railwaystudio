using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Rwm.Otc.TrainControl.Persistence
{
   public class ModelRevisionDAO : DataConsumer
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = @"modelsrevs";

      internal static string SQL_SELECT = @"id, modelid, revdate, servicehours, runninghours, description, author";

      internal static string SQL_INSERT = @"modelid, revdate, servicehours, runninghours, description, author";

      #endregion

      #region Constructors

      /// <summary>
      /// Constructor de la clase.
      /// </summary>
      /// <param name="app">Una instáncia de RCApplication.</param>
      public ModelRevisionDAO() : base() { }

      #endregion

      #region Methods

      /// <summary>
      /// Actualiza la lista de funciones digitales.
      /// </summary>
      public void Add(CollectionModel model)
      {
         string sql = string.Empty;

         // Delete current data
         this.DeleteByModel(model.ID);

         try
         {
//            foreach (ModelRevision revision in model.MaintenanceRevisions)
//            {
//               sql = @"INSERT INTO 
//                           " + ModelRevisionDAO.SQL_TABLE + @" (" + ModelRevisionDAO.SQL_INSERT + @") 
//                       VALUES 
//                           (@modelid, @revdate, @servicehours, @runninghours, @description, @author)";

//               SetParameter("modelid", model.ID);
//               SetParameter("revdate", revision.Date);
//               SetParameter("servicehours", revision.ServiceHours);
//               SetParameter("runninghours", revision.RevisionHours);
//               SetParameter("description", revision.Description);
//               SetParameter("author", revision.Author);

//               ExecuteNonQuery(sql);
//            }
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
                        " + ModelRevisionDAO.SQL_TABLE + @"
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
      public List<ModelRevision> GetByModel(long modelId)
      {
         string sql = string.Empty;
         ModelRevision item = null;
         List<ModelRevision> items = new List<ModelRevision>();

         try
         {
            Connect();

            // Get all associated digital functions
            sql = @"SELECT 
                        " + ModelRevisionDAO.SQL_SELECT + @"
                    FROM 
                        " + ModelRevisionDAO.SQL_TABLE + @" 
                    WHERE 
                        modelid = @modelid 
                    ORDER BY 
                        revdate ASC";

            SetParameter("modid", modelId);

            using (SQLiteDataReader read = ExecuteReader(sql))
            {
               while (read.Read())
               {
                  item = new ModelRevision();
                  item.ID = read.GetInt32(0);
                  item.ModelId = read.GetInt32(1);
                  item.Date = read.GetDateTime(2);
                  item.ServiceHours = read.GetInt32(3);
                  item.RevisionHours = read.GetInt32(4);
                  item.Description = read.GetString(5);
                  item.Author = !read.IsDBNull(6) ? read.GetString(6) : string.Empty;

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
