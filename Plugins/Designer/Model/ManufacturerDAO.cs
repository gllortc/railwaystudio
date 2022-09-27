using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using Rwm.Studio.Plugins.Collection.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Rwm.Studio.Plugins.Collection.Model
{
   public class ManufacturerDAO : CollectionDataEntity
   {

      #region Constants

      // SQL constants declarations
      internal static string SQL_TABLE = "builders";
      internal static string SQL_FIELDS_SELECT = "buildid,buildname,builddesc,buildurl,buildaddress";
      internal static string SQL_FIELDS_INSERT = "buildname,builddesc,buildurl,buildaddress";

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="ManufacturerDAO"/>.
      /// </summary>
      public ManufacturerDAO(XmlSettingsManager settings)
         : base(settings)
      {

      }

      #endregion

      #region Methods

      /// <summary>
      /// Agrega un nuevo fabricante.
      /// </summary>
      /// <param name="model">Una instáncia de RCManufacturer.</param>
      public void Add(Manufacturer manufacturer)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            // Agrega el registro
            sql = @"INSERT INTO 
                        " + ManufacturerDAO.SQL_TABLE + @" (" + ManufacturerDAO.SQL_FIELDS_INSERT + @") 
                    VALUES 
                           (@buildname,@builddesc,@buildurl,@buildaddress)";

            SetParameter("buildname", manufacturer.Name);
            SetParameter("builddesc", manufacturer.Description);
            SetParameter("buildaddress", manufacturer.Address);
            SetParameter("buildurl", manufacturer.URL);

            ExecuteNonQuery(sql);

            // Obtiene la ID del objeto
            sql = @"SELECT 
                        Max(buildid) AS id 
                    FROM 
                        " + ManufacturerDAO.SQL_TABLE;

            manufacturer.ID = (int)ExecuteScalar(sql);
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
      /// Actualiza los datos de un fabricante.
      /// </summary>
      /// <param name="model">Una instáncia de RCManufacturer.</param>
      public void Update(Manufacturer manufacturer)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"UPDATE 
                        " + ManufacturerDAO.SQL_TABLE + @" 
                    SET 
                        buildname=@buildname, 
                        builddesc=@builddesc, 
                        buildaddress=@buildaddress, 
                        buildurl=@buildurl 
                    WHERE 
                        buildid = @buildid";

            SetParameter("buildname", manufacturer.Name);
            SetParameter("builddesc", manufacturer.Description);
            SetParameter("buildaddress", manufacturer.Address);
            SetParameter("buildurl", manufacturer.URL);
            SetParameter("buildid", manufacturer.ID);

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
      /// Elimina un fabricante si no tiene ningún modelo asignado
      /// </summary>
      /// <param name="ItemID">Identificador del fabricante.</param>
      public void Delete(int itemId)
      {
         string sql = string.Empty;

         try
         {
            // Averigua el número de modelos asignados a este fabricante
            if (this.CountItems(itemId) > 0)
            {
               throw new Exception("No se puede eliminar este fabricante porqué tiene modelos asociados.");
            }

            Connect();

            sql = @"DELETE 
                    FROM 
                        " + ManufacturerDAO.SQL_TABLE + @" 
                    WHERE 
                        buildid = @BUILDID";

            SetParameter("BUILDID", itemId);
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
      /// <param name="itemid">Identificador.</param>
      /// <returns>Una instáncia de RCManufacturer.</returns>
      public Manufacturer GetByID(Int32 itemId)
      {
         return GetByID((Int32)itemId);
      }

      /// <summary>
      /// Recupera las propiedades de un fabricante.
      /// </summary>
      /// <param name="itemid">Identificador.</param>
      /// <returns>Una instáncia de RCManufacturer.</returns>
      public Manufacturer GetByID(Int64 itemId)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ManufacturerDAO.SQL_FIELDS_SELECT + @"
                  FROM 
                        " + ManufacturerDAO.SQL_TABLE + @" 
                  WHERE 
                        buildid = @buildid";

            SetParameter("buildid", itemId);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  return ManufacturerDAO.ReadEntityRecord(reader);
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
      /// Averigua el ID de un fabricante a partir de su nombre.
      /// </summary>
      /// <param name="name">Nombre del fabricante.</param>
      /// <returns>Identificador del registro.</returns>
      public Manufacturer GetByName(string name)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ManufacturerDAO.SQL_FIELDS_SELECT + @" 
                  FROM 
                        " + ManufacturerDAO.SQL_TABLE + @" 
                  WHERE 
                        LCase(buildname) = @buildname";

            SetParameter("buildname", name);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  return ManufacturerDAO.ReadEntityRecord(reader);
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

      ///// <summary>
      ///// Rellena un control ImageComboBoxEdit con una lista de fabricantes.
      ///// </summary>
      ///// <param name="comboBox">Control contenedor de la lista.</param>
      ///// <param name="defaultId">Identificador del elemento a preseleccionar.</param>
      //public void List(ComboBox comboBox, int defaultId)
      //{
      //   int idx = 0;
      //   OleDbCommand sqlCmd = null;
      //   OleDbDataReader sqlRead = null;

      //   string sql = "SELECT buildname,buildid " +
      //                "FROM builders " +
      //                "ORDER BY buildname Asc";
      //   try
      //   {
      //      Connect();
      //      sqlCmd = new OleDbCommand(sql, _app.Connection);
      //      sqlRead = sqlCmd.ExecuteReader();

      //      comboBox.Items.Clear();
      //      while (sqlRead.Read())
      //      {
      //         comboBox.Items.Add(new ComboBoxItem((string)sqlRead[0], (int)sqlRead[1]));
      //      }
      //      sqlRead.Close();

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
      //      sqlRead.Dispose();
      //      sqlCmd.Dispose();

      //      // _app.Disconnect();
      //   }
      //}

      ///// <summary>
      ///// Rellena un control ImageComboBoxEdit con una lista de fabricantes.
      ///// </summary>
      ///// <param name="comboBox">Control contenedor de la lista.</param>
      //public void List(ComboBox comboBox)
      //{
      //   this.List(comboBox, -1);
      //}

      ///// <summary>
      ///// Rellena un control ListView con una lista de fabricantes.
      ///// </summary>
      ///// <param name="listView">Control contenedor de la lista.</param>
      //public void ListView(ListView listView)
      //{
      //   OleDbCommand sqlCmd = null;
      //   OleDbDataReader sqlRead = null;

      //   try
      //   {

      //      // Genera la senténcia SQL que obtiene los elementos
      //      string sql = "SELECT buildid, buildname, buildurl " +
      //                   "FROM builders " +
      //                   "ORDER BY buildname Asc";

      //      // Configura el control ListView
      //      listView.Clear();
      //      listView.Columns.Add("Fabricante", 150);
      //      listView.Columns.Add("URL", 250);
      //      listView.View = System.Windows.Forms.View.Details;

      //      listView.SmallImageList = new ImageList();
      //      listView.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
      //      listView.SmallImageList.ImageSize = new System.Drawing.Size(16, 16);
      //      listView.SmallImageList.Images.Add("IMG_LOAD_16", global::Rwm.collection.Properties.Resources.IMG_LOAD_16);

      //      Connect();
      //      sqlCmd = new OleDbCommand(sql, _app.Connection);
      //      sqlRead = sqlCmd.ExecuteReader();
      //      while (sqlRead.Read())
      //      {
      //         System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem();
      //         item.Tag = sqlRead.GetInt32(0);
      //         item.Text = sqlRead.IsDBNull(1) ? string.Empty : sqlRead.GetString(1);
      //         item.SubItems.Add(sqlRead.IsDBNull(2) ? string.Empty : sqlRead.GetString(2));
      //         item.ImageKey = "IMG_LOAD_16";

      //         listView.Items.Add(item);
      //      }
      //      sqlRead.Close();
      //   }
      //   catch (Exception e)
      //   {
      //      DebugLogger.LogError(this, ex);

      //      throw;
      //   }
      //   finally
      //   {
      //      sqlRead.Dispose();
      //      sqlCmd.Dispose();

      //      // _app.Disconnect();
      //   }
      //}

      /// <summary>
      /// Calcula el número de modelos asignados a un fabricante.
      /// </summary>
      /// <param name="itemid">Identificador del fabricante.</param>
      /// <returns>El número de modelos asignados.</returns>
      public int CountItems(int itemId)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"SELECT 
                        Count(*) As nregs 
                    FROM 
                        models 
                    WHERE 
                        modbuilderid = @modbuilderid";

            SetParameter("modbuilderid", itemId);
            return (int)ExecuteScalar(sql); ;
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
      /// Get all manufacturers.
      /// </summary>
      /// <returns>The requested list filled with information.</returns>
      public List<Manufacturer> GetAll()
      {
         string sql = string.Empty;
         Manufacturer manufacturer;
         List<Manufacturer> manufacturers = new List<Manufacturer>();

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ManufacturerDAO.SQL_FIELDS_SELECT + @"
                    FROM 
                        " + ManufacturerDAO.SQL_TABLE + @" 
                    ORDER BY 
                        buildname";

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  manufacturer = ManufacturerDAO.ReadEntityRecord(reader);
                  if (manufacturer != null)
                  {
                     manufacturers.Add(manufacturer);
                  }
               }
            }

            return manufacturers;
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
      /// Get all categories as a <see cref="DataSource"/>.
      /// </summary>
      /// <returns>The requested <see cref="DataSource"/> filled with information.</returns>
      public System.Data.DataTable GetAllAsDataSource()
      {
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"SELECT 
                        buildid        As '#ID', 
                        buildname      As 'Nombre',
                        builddesc      As 'Descripción', 
                        buildurl       As 'URL',
                        buildaddress   As 'Dirección'
                    FROM 
                        " + ManufacturerDAO.SQL_TABLE + @" 
                    ORDER BY 
                        buildname";

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

      #region Static Members

      internal static Manufacturer ReadEntityRecord(SQLiteDataReader reader)
      {
         Manufacturer item = new Manufacturer();
         item.ID = reader.GetInt32(0);
         item.Name = (reader.IsDBNull(1) ? string.Empty : reader.GetString(1));
         item.Description = (reader.IsDBNull(2) ? string.Empty : reader.GetString(2));
         item.Address = (reader.IsDBNull(3) ? string.Empty : reader.GetString(3));
         item.URL = (reader.IsDBNull(4) ? string.Empty : reader.GetString(4));

         return item;
      }

      #endregion

   }
}
