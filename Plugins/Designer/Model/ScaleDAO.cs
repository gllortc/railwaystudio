using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using Rwm.Studio.Plugins.Collection.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Rwm.Studio.Plugins.Collection.Model
{
   public class ScaleDAO : CollectionDataEntity
   {

      #region Constants

      // SQL constant declarations
      internal static string SQL_TABLE = "scales";
      internal static string SQL_FIELDS_SELECT = "scid,scname,scscale,sctwidth,scrtwidth";
      internal static string SQL_FIELDS_INSERT = "scname,scscale,sctwidth,scrtwidth";

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="ScaleDAO"/>.
      /// </summary>
      public ScaleDAO(XmlSettingsManager settings)
         : base(settings)
      {

      }

      #endregion

      #region Methods

      /// <summary>
      /// Agrega una nueva escala.
      /// </summary>
      /// <param name="model">Una instáncia de RCScale.</param>
      public void Add(Scale scale)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            // Agrega el nuevo registro
            sql = @"INSERT INTO 
                        " + ScaleDAO.SQL_TABLE + @" (" + ScaleDAO.SQL_FIELDS_INSERT + @") 
                    VALUES 
                        (@scname, @scscale, @sctwidth, @scrtwidth)";

            SetParameter("scname", scale.Name);
            SetParameter("scscale", scale.ScaleNotation);
            SetParameter("sctwidth", scale.TrackWidthScale);
            SetParameter("scrtwidth", scale.TrackWidthReal);

            ExecuteNonQuery(sql);

            // Obtiene el nuevo ID
            sql = @"SELECT 
                        Max(scid) As id 
                    FROM 
                        " + ScaleDAO.SQL_TABLE;

            scale.ID = (int)ExecuteScalar(sql);
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
      /// Actualiza los datos de una escala.
      /// </summary>
      /// <param name="model">Una instáncia de RCScale.</param>
      public void Update(Scale scale)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"UPDATE 
                        " + ScaleDAO.SQL_TABLE + @" 
                    SET 
                        scname = @scname, 
                        scscale = @scscale, 
                        sctwidth = @sctwidth, 
                        scrtwidth = @scrtwidth 
                    WHERE 
                        scid = @scid";

            SetParameter("scname", scale.Name);
            SetParameter("scscale", scale.ScaleNotation);
            SetParameter("sctwidth", scale.TrackWidthScale);
            SetParameter("scrtwidth", scale.TrackWidthReal);
            SetParameter("scid", scale.ID);

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
      /// Elimina una escala si no tiene ningún modelo asignado
      /// </summary>
      /// <param name="ItemID">Identificador de la escala.</param>
      public void Delete(int itemId)
      {
         string sql = string.Empty;

         try
         {
            // Averigua el número de modelos asignados a esta categoria
            if (this.CountItems(itemId) > 0)
            {
               throw new Exception("No se puede eliminar esta escala/galga porqué tiene modelos asociados.");
            }

            Connect();

            sql = @"DELETE 
                    FROM 
                        " + ScaleDAO.SQL_TABLE + @" 
                    WHERE 
                        scid = @scid";

            SetParameter("scid", itemId);
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
      /// Recupera las propiedades de una escala.
      /// </summary>
      /// <param name="itemid">Identificador.</param>
      /// <returns>Una instáncia de RCScale.</returns>
      public Scale GetByID(Int64 itemId)
      {
         return GetByID((Int32)itemId);
      }

      /// <summary>
      /// Recupera las propiedades de una escala.
      /// </summary>
      /// <param name="itemid">Identificador.</param>
      /// <returns>Una instáncia de RCScale.</returns>
      public Scale GetByID(int itemId)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ScaleDAO.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + ScaleDAO.SQL_TABLE + @" 
                    WHERE 
                        scid = @scid";

            SetParameter("scid", itemId);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  return ScaleDAO.ReadEntityRecord(reader);
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
      /// Recupera las propiedades de una escala.
      /// </summary>
      /// <param name="itemid">Identificador.</param>
      /// <returns>Una instáncia de RCScale.</returns>
      public Scale GetByName(string name)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ScaleDAO.SQL_FIELDS_SELECT + @"
                    FROM 
                        " + ScaleDAO.SQL_TABLE + @" 
                    WHERE 
                        scname = @scname";

            SetParameter("scname", name);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  return ScaleDAO.ReadEntityRecord(reader);
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
      /// Averigua el ID de una escala a partir de su nombre.
      /// </summary>
      /// <param name="name">Nombre de la escala.</param>
      /// <returns>Identificador del registro.</returns>
      public Scale GetId(string name)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ScaleDAO.SQL_FIELDS_SELECT + @"
                    FROM 
                        " + ScaleDAO.SQL_TABLE + @" 
                    WHERE 
                        LCase(scname) = @scname";

            SetParameter("@scname", name.ToLower().Trim());

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  return ScaleDAO.ReadEntityRecord(reader);
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
      ///// Rellena un control ImageComboBoxItem con una lista de escalas.
      ///// </summary>
      ///// <param name="comboBox">Control contenedor del listado.</param>
      ///// <param name="defaultId">Identificador del elemento preseleccionado.</param>
      //public void List(ComboBox comboBox, int defaultId)
      //{
      //   int idx = 0;
      //   OleDbCommand cmd = null;
      //   OleDbDataReader reader = null;

      //   try
      //   {
      //      string sql = "SELECT scname,scid FROM scales";

      //      Connect();
      //      cmd = new OleDbCommand(sql, _app.Connection);
      //      reader = cmd.ExecuteReader();

      //      comboBox.Items.Clear();
      //      while (reader.Read())
      //      {
      //         comboBox.Items.Add(new ComboBoxItem(reader.GetString(0), reader.GetInt32(1)));
      //      }
      //      reader.Close();

      //      if (defaultId > 0)
      //      {
      //         foreach (ComboBoxItem item in comboBox.Items)
      //         {
      //            if ((int)item.Value == defaultId)
      //            {
      //               comboBox.SelectedIndex = idx;
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
      ///// Rellena un control ImageComboBoxItem con una lista de escalas.
      ///// </summary>
      ///// <param name="comboBox">Control contenedor del listado.</param>
      //public void List(ComboBox comboBox)
      //{
      //   this.List(comboBox, -1);
      //}

      ///// <summary>
      ///// Rellena un control ListView con una lista de escalas.
      ///// </summary>
      ///// <param name="listView">Control contenedor de la lista.</param>
      //public void ListView(ListView listView)
      //{
      //   OleDbCommand cmd = null;
      //   OleDbDataReader reader = null;

      //   try
      //   {
      //      // Genera la senténcia SQL que obtiene los elementos
      //      string sql = "SELECT scid, scname, scscale FROM scales ORDER BY scname";

      //      // Configura el control ListView
      //      listView.Clear();
      //      listView.Columns.Add("Escala", 150);
      //      listView.Columns.Add("Ratio", 250);
      //      listView.View = System.Windows.Forms.View.Details;

      //      listView.SmallImageList = new ImageList();
      //      listView.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
      //      listView.SmallImageList.ImageSize = new System.Drawing.Size(16, 16);
      //      listView.SmallImageList.Images.Add("IMG_SCALE", global::Rwm.collection.Properties.Resources.IMG_SCALE_16);

      //      Connect();
      //      cmd = new OleDbCommand(sql, _app.Connection);
      //      reader = cmd.ExecuteReader();
      //      while (reader.Read())
      //      {
      //         System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem();
      //         item.Tag = reader.GetInt32(0);
      //         item.Text = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
      //         item.SubItems.Add(reader.IsDBNull(2) ? string.Empty : reader.GetString(2));
      //         item.ImageKey = "IMG_SCALE";

      //         listView.Items.Add(item);
      //      }
      //      reader.Close();

      //      // if (listView.Items.Count > 0)
      //      //   listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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

      /// <summary>
      /// Calcula el número de modelos asignados a una escala.
      /// </summary>
      /// <param name="itemId">Identificador de la escalao.</param>
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
                        modscale = @modscale";

            SetParameter("modscale", itemId);
            return (int)ExecuteScalar(sql);
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
      /// Recupera las propiedades de una escala.
      /// </summary>
      /// <param name="Name">Nombre o denominación de la escala.</param>
      /// <returns>Una instancia de <see cref="RCScale"/> si encuentra la escala o <c>null</c> en cualquier otro caso.</returns>
      public Scale Item(string Name)
      {
         // Obtiene el ID de la escala a buscar

         return null;
      }

      /// <summary>
      /// Get all scales.
      /// </summary>
      /// <returns>The requested list filled with information.</returns>
      public List<Scale> GetAll()
      {
         string sql = string.Empty;
         Scale scale;
         List<Scale> scales = new List<Scale>();

         try
         {
            Connect();

            sql = @"SELECT 
                        " + ScaleDAO.SQL_FIELDS_SELECT + @"
                    FROM 
                        " + ScaleDAO.SQL_TABLE + @" 
                    ORDER BY 
                        scname ASC";

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  scale = ScaleDAO.ReadEntityRecord(reader);
                  if (scale != null)
                  {
                     scales.Add(scale);
                  }
               }
            }

            return scales;
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
      public System.Data.DataTable GetAllAsDataTable()
      {
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"SELECT 
                        scid        As '#ID', 
                        scname      As 'Nombre',
                        scscale     As 'Representación', 
                        sctwidth    As 'Ancho a escala (mm)',
                        scrtwidth   As 'Ancho real (mm)'
                    FROM 
                        " + ScaleDAO.SQL_TABLE + @" 
                    ORDER BY 
                        scname";

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

      internal static Scale ReadEntityRecord(SQLiteDataReader reader)
      {
         Scale item = new Scale();
         item.ID = reader.GetInt32(0); ;
         item.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
         item.ScaleNotation = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
         item.TrackWidthScale = reader.IsDBNull(3) ? 0.0d : reader.GetDouble(3);
         item.TrackWidthReal = reader.IsDBNull(4) ? 0.0d : reader.GetDouble(4);

         return item;
      }

      #endregion

   }
}
