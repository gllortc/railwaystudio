using Rwm.Otc.Data;

namespace Rwm.Otc.Layout.Persistence
{
   /// <summary>
   /// Manage all control modules.
   /// </summary>
   public class ElementModelDAO : DataConsumer
   {

      #region Constants

      // SQL declarations
      public static string SQL_TABLE = "elementmodel";
      internal static string SQL_FIELDS = "elementid, modelid";

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ElementModelDAO"/>.
      /// </summary>
      public ElementModelDAO() : base() { }

      #endregion

      #region Methods

//      /// <summary>
//      /// Adds a new model into a block element.
//      /// </summary>
//      /// <param name="element">Block element.</param>
//      /// <param name="model">Model.</param>
//      public void Add(Element element, CollectionModel model)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].Add([{0}], [{1}])", element, model);

//         try
//         {
//            Connect();

//            // Remove other model assignation(s)
//            sql = @"DELETE
//                    FROM 
//                        " + ElementModelDAO.SQL_TABLE + @" 
//                    WHERE 
//                        modelid = @modelid";

//            SetParameter("modelid", model.ID);
//            ExecuteNonQuery(sql);

//            // Adds the new decoder
//            sql = @"INSERT INTO 
//                        " + ElementModelDAO.SQL_TABLE + @" (" + ElementModelDAO.SQL_FIELDS + @") 
//                    VALUES 
//                        (@elementid, @modelid)";

//            SetParameter("elementid", element.ID);
//            SetParameter("modelid", model.ID);
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
//      /// Delete the specified occupation info.
//      /// </summary>
//      /// <param name="element">Element to remove.</param>
//      public void Delete(Element element)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].Delete([{0}])", element);

//         try
//         {
//            Connect();

//            sql = @"DELETE 
//                    FROM 
//                        " + ElementModelDAO.SQL_TABLE + @" 
//                    WHERE 
//                        elementid = @elementid";

//            SetParameter("elementid", element.ID);

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
//      /// Gets the train that is occuping the block.
//      /// </summary>
//      /// <param name="element">Element to check.</param>
//      /// <returns>The requested instance of <see cref="Device"/> or <c>null</c> if the module cannot be found.</returns>
//      public CollectionModel GetByElement(Element element)
//      {
//         string sql = string.Empty;

//         Logger.LogDebug(this, "[CLASS].GetByElement([{0}])", element);

//         if (element == null) return null;

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        modelid 
//                    FROM 
//                        " + ElementModelDAO.SQL_TABLE + @" 
//                    WHERE 
//                        elementid = @elementid";

//            SetParameter("elementid", element.ID);            
//            long modelId = ExecuteScalar(sql, 0);

//            if (modelId == 0) return null;

//            // TrainControl.Persistence.ModelDAO mdao = new TrainControl.Persistence.ModelDAO();
//            return CollectionModel.Get(modelId);
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

      #endregion

   }
}
