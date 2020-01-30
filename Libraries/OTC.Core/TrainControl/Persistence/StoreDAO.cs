using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Rwm.Otc.TrainControl.Persistence
{
   /// <summary>
   /// Gestor de comercios.
   /// </summary>
   public class StoreDAO : DataManager<Store>
   {

      #region Constants

      // SQL constant declarations
      internal static string SQL_TABLE = "stores";
      internal static string SQL_FIELDS_SELECT = "storeid,storename,storeaddress,storephone,storemail,storeurl,storedesc";
      internal static string SQL_FIELDS_INSERT = "storename,storeaddress,storephone,storemail,storeurl,storedesc";

      #endregion

      #region Constructors

      /// <summary>
      /// Constructor de la clase.
      /// </summary>
      /// <param name="app">Ina instáncia de RCApplication.</param>
      public StoreDAO() : base() { }

      #endregion

      #region Methods

//      /// <summary>
//      /// Agrega un nuevo comercio.
//      /// </summary>
//      /// <param name="model">Una instáncia de RCStore.</param>
//      public override void Add(Store store)
//      {
//         string sql = string.Empty;

//         try
//         {
//            Connect();

//            // Agrega el nuevo registro
//            sql = @"INSERT INTO 
//                        " + StoreDAO.SQL_TABLE + @" (" + StoreDAO.SQL_FIELDS_INSERT + @") 
//                    VALUES 
//                        (@storename,@storeaddress,@storephone,@storemail,@storeurl,@storedesc)";

//            SetParameter("storename", store.Name);
//            SetParameter("storeaddress", store.Address);
//            SetParameter("storephone", store.Phone);
//            SetParameter("storemail", store.Mail);
//            SetParameter("storeurl", store.URL);
//            SetParameter("storedesc", store.Description);
//            ExecuteNonQuery(sql);

//            // Obtiene el nuevo ID
//            sql = @"SELECT 
//                        Max(storeid) As id 
//                    FROM 
//                        " + StoreDAO.SQL_TABLE;

//            store.ID = (int)ExecuteScalar(sql);
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
//      /// Actualiza los datos de un comercio.
//      /// </summary>
//      /// <param name="model">Una instáncia de RCStore.</param>
//      public override void Update(Store store)
//      {
//         string sql = string.Empty;

//         try
//         {
//            Connect();

//            sql = @"UPDATE 
//                        " + StoreDAO.SQL_TABLE + @" 
//                    SET 
//                        storename = @storename, 
//                        storeaddress = @storeaddress, 
//                        storephone = @storephone, 
//                        storemail = @storemail, 
//                        storeurl = @storeurl,
//                        storedesc = @storedesc 
//                    WHERE 
//                        storeid = @storeid";

//            SetParameter("storename", store.Name);
//            SetParameter("storeaddress", store.Address);
//            SetParameter("storephone", store.Phone);
//            SetParameter("storemail", store.Mail);
//            SetParameter("storeurl", store.URL);
//            SetParameter("storedesc", store.Description);
//            SetParameter("storeid", store.ID);
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
//      /// Elimina un comercio si no tiene ningún modelo asignado
//      /// </summary>
//      /// <param name="ItemID">Identificador del comercio.</param>
//      public override int Delete(long itemId)
//      {
//         string sql = string.Empty;

//         try
//         {
//            // Averigua el número de modelos asignados a esta categoria
//            if (this.CountItems(itemId) > 0)
//            {
//               throw new Exception("This store cannot be deleted because it has related models.");
//            }

//            Connect();

//            sql = @"DELETE 
//                    FROM 
//                        " + StoreDAO.SQL_TABLE + @" 
//                    WHERE 
//                        storeid = @storeid";

//            SetParameter("storeid", itemId);
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
//      /// Recupera un modelo de la colección.
//      /// </summary>
//      /// <param name="itemid">Identificador del modelo.</param>
//      /// <returns>Una instáncia de RCStore.</returns>
//      public override Store GetByID(long itemId)
//      {
//         string sql = string.Empty;

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + StoreDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + StoreDAO.SQL_TABLE + @" 
//                    WHERE 
//                        storeid=@storeid";

            
//            SetParameter("storeid", itemId);

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
//      /// Recupera un modelo de la colección.
//      /// </summary>
//      /// <param name="itemid">Identificador del modelo.</param>
//      /// <returns>Una instáncia de RCStore.</returns>
//      public Store GetByName(string name)
//      {
//         string sql = string.Empty;

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + StoreDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + StoreDAO.SQL_TABLE + @" 
//                    WHERE 
//                        storename=@storename";


//            SetParameter("storename", name);

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
//      /// Get all stores.
//      /// </summary>
//      /// <returns>A list filled with all requested instances.</returns>
//      public override IEnumerable<Store> GetAll()
//      {
//         string sql = string.Empty;
//         Store store = null;
//         List<Store> stores = new List<Store>();

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + StoreDAO.SQL_FIELDS_SELECT + @" 
//                    FROM 
//                        " + StoreDAO.SQL_TABLE + @" 
//                    ORDER BY 
//                        storename ASC";

//            using (SQLiteDataReader reader = ExecuteReader(sql))
//            {
//               while (reader.Read())
//               {
//                  store = this.ReadEntityRecord(reader);
//                  if (store != null)
//                  {
//                     stores.Add(store);
//                  }
//               }
//            }

//            return stores;
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
//      /// Get all objects as a <see cref="DataTable"/>.
//      /// </summary>
//      /// <returns>The requested <see cref="DataTable"/> filled with information.</returns>
//      public System.Data.DataTable GetAllAsDataTable()
//      {
//         string sql = string.Empty;

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        storeid     As '#ID', 
//                        storename   As 'Name',
//                        storephone  As 'Phone', 
//                        storemail   As 'Mail',
//                        storeurl    As 'URL'
//                    FROM 
//                        " + StoreDAO.SQL_TABLE + @" 
//                    ORDER BY 
//                        storename";

//            return this.ExecuteDataTable(sql);
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
      ///// Rellena un control ComboBox con una lista de centros comerciales.
      ///// </summary>
      ///// <param name="comboBox">Control contenedor.</param>
      ///// <param name="defaultId">ID del elemento preseleccionado.</param>
      //public void List(ComboBox comboBox, int defaultId)
      //{
      //   int idx = 0;
      //   OleDbCommand cmd = null;
      //   OleDbDataReader reader = null;

      //   string sql = "SELECT storename,storeid FROM stores ORDER BY storename ASC";

      //   try
      //   {
      //      // Rellena la lista desplegable
      //      Connect();
      //      cmd = new OleDbCommand(sql, _app.Connection);
      //      reader = cmd.ExecuteReader();

      //      comboBox.Items.Clear();
      //      while (reader.Read())
      //      {
      //         comboBox.Items.Add(new ComboBoxItem(reader.GetString(0), reader.GetInt32(1)));
      //      }
      //      reader.Close();

      //      // Preselecciona el elemento indicado
      //      if (defaultId > 0)
      //      {
      //         foreach (ComboBoxItem item in comboBox.Items)
      //         {
      //            if (Rwm.Otc.Math.Numeric.Val(item.Value.ToString()) == defaultId)
      //            {
      //               comboBox.SelectedItem = item;
      //               break;
      //            }
      //            idx++;
      //         }
      //      }
      //   }
      //   catch (Exception e)
      //   {
      //      DebugLogger.LogError(this, ex);

      //      throw;
      //   }
      //   finally
      //   {
      //      reader.Dispose();
      //      cmd.Dispose();
      //      // _app.Disconnect();
      //   }
      //}

      ///// <summary>
      ///// Rellena un control ComboBox con una lista de centros comerciales.
      ///// </summary>
      ///// <param name="comboBox">Control contenedor.</param>
      //public void List(ComboBox comboBox)
      //{
      //   this.List(comboBox, -1);
      //}

      ///// <summary>
      ///// Rellena un control ListView con una lista de centros comerciales.
      ///// </summary>
      ///// <param name="listView">Control contenedor de la lista.</param>
      //public void ListView(ListView listView)
      //{
      //   OleDbCommand cmd = null;
      //   OleDbDataReader reader = null;

      //   try
      //   {
      //      // Genera la senténcia SQL que obtiene los elementos
      //      string sql = "SELECT storeid,storename,storeurl FROM stores ORDER BY storename";

      //      // Configura el control ListView
      //      listView.Items.Clear();
      //      listView.Columns.Clear();
      //      listView.Columns.Add("Comercio", 150);
      //      listView.Columns.Add("URL", 250);
      //      listView.View = System.Windows.Forms.View.Details;

      //      listView.SmallImageList = new ImageList();
      //      listView.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
      //      listView.SmallImageList.ImageSize = new System.Drawing.Size(16, 16);
      //      listView.SmallImageList.Images.Add("IMG_STORE", global::Rwm.collection.Properties.Resources.IMG_SHOP_16);

      //      Connect();
      //      cmd = new OleDbCommand(sql, _app.Connection);
      //      reader = cmd.ExecuteReader();
      //      while (reader.Read())
      //      {
      //         System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem();
      //         item.Tag = reader.GetInt32(0);
      //         item.Text = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
      //         item.SubItems.Add(reader.IsDBNull(2) ? string.Empty : reader.GetString(2));
      //         item.ImageKey = "IMG_STORE";

      //         listView.Items.Add(item);
      //      }
      //      reader.Close();

      //      // if (listView.Items.Count > 0)
      //      //   listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
      //   }
      //   catch (Exception ex)
      //   {
      //      DebugLogger.LogError(this, ex);

      //      throw ex;
      //   }
      //   finally
      //   {
      //      Disconnect();
      //   }
      //}

//      /// <summary>
//      /// Calcula el número de modelos asignados a un comercio.
//      /// </summary>
//      /// <param name="itemId">Identificador del comercio.</param>
//      /// <returns>El número de modelos asignados.</returns>
//      public int CountItems(long itemId)
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
//                        modstoreid = @modstoreid";

            
//            SetParameter("modstoreid", itemId);
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

      public override Store ReadEntityRecord(SQLiteDataReader reader)
      {
         Store item = new Store();
         item.ID = reader.GetInt32(0);
         item.Name = reader.GetString(1);
         item.Address = (reader.IsDBNull(2)) ? string.Empty : reader.GetString(2);
         item.Phone = (reader.IsDBNull(3)) ? string.Empty : reader.GetString(3);
         item.Mail = (reader.IsDBNull(4)) ? string.Empty : reader.GetString(4);
         item.URL = (reader.IsDBNull(5)) ? string.Empty : reader.GetString(5);
         item.Description = (reader.IsDBNull(6)) ? string.Empty : reader.GetString(6);

         return item;
      }

      #endregion

   }
}
